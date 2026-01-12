using Benchmark.Contracts;
using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace Benchmark.Collections;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class CollectionExpressions : ICodeAssessment
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
}