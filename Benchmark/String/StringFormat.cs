using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace Benchmark.String;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class StringFormat
{
    [Benchmark(Baseline = true)]
    public string ToString()
    {
        DateTime thisDate1 = new DateTime(2024, 2, 09);
        return $"Today is {thisDate1.ToString("MMMM dd, yyyy")}.";
    }

    [Benchmark]
    public string StringInterpolationFormat()
    {
        DateTime thisDate1 = new DateTime(2024, 2, 09);
        return $"Today is {thisDate1:MMMM dd, yyyy}.";
    }

    [Benchmark]
    public string StringFormatter()
    {
        DateTime thisDate1 = new DateTime(2024, 2, 09);
        return $"Today is {string.Format("{0:MMMM dd, yyyy}",thisDate1)}.";
    }
}