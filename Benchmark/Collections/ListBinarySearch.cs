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
public class ListBinarySearch : ICodeAssessment
{
    private readonly List<string> _fruits;
    public ListBinarySearch()
    {
        _fruits = ["tangerine", "apple", "kiwi", "pineapple", "strawberry", "grape"];
        _fruits.Sort();
    }
    
    [Benchmark]
    public void BinarySearch()
    {
        _ = _fruits.BinarySearch("apple");
    }
        
    [Benchmark(Baseline = true)]
    public void IndexOf()
    {
        _ = _fruits.IndexOf("apple");
    }
}