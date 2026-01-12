using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace Benchmark.Collections;

[Config(typeof(Config))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class CollectionExpressions
{
    [Benchmark(Baseline = true)]
    public List<string> RegularList()
    {
        return new List<string> { "apple", "banana", "orange" };
    }

    [Benchmark]
    public List<string> ColExpressionList()
    {
        return ["apple", "banana", "orange"];
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