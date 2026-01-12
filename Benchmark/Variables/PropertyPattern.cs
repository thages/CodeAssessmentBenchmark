using Benchmark.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace Benchmark.Variables;

[Config(typeof(Config))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]

public class PropertyPattern
{
    [Benchmark]
    public string VarPattern()
    {
        Person person = new()
        {  
            Name = "José",
            Address = new Address()
            {
                City = "São Paulo"
            }
        };

        if (person is { Name: "José", Address.City: var city })
        {
           return city;
        }

        return string.Empty;
    }

    [Benchmark(Baseline = true)]
    public string DefaultProperty()
    {
        Person person = new()
        {
            Name = "José",
            Address = new Address()
            {
                City = "São Paulo"
            }
        };

        if (person != null && 
            person.Name == "José" &&
            person.Address != null)
        {
            return person.Address.City;
        }
        
        return string.Empty;
    }
    
    private class Config : ManualConfig
    {
        public Config()
        {
            AddJob(Job.Default.WithId(".NET 8").WithRuntime(CoreRuntime.Core80));

            SummaryStyle =
                SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
        }
    }
}
