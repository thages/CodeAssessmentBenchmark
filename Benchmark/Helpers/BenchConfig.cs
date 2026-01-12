using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace Benchmark.Helpers;

public class BenchConfig : ManualConfig
{
    public BenchConfig()
    {
        AddJob(Job.Default.WithId(".NET 8").WithRuntime(CoreRuntime.Core80));

        SummaryStyle =
            SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
    }
}