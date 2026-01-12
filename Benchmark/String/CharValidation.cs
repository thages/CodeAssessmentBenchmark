using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace Benchmark.String;

[Config(typeof(Config))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class CharValidation
{
    [Benchmark]
    public bool CharMethod()
    {
        char c = 'a';
        return char.IsLetter(c);
    }
    
    [Benchmark(Baseline = true)]
    public bool CustomMethod()
    {
        char c = 'a';
        return c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');
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