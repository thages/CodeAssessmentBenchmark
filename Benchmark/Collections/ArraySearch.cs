using Benchmark.Contracts;
using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

namespace Benchmark.Collections;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class ArraySearch : ICodeAssessment
{
    private readonly List<string> _fruits = ["tangerine", "apple", "kiwi", "pineapple", "strawberry", "grape"];
    private readonly string[] _fruitsArr = ["tangerine", "apple", "kiwi", "pineapple", "strawberry", "grape"];

    [Benchmark]
    public void BinarySearch()
    {
        var index = _fruits.BinarySearch("apple");
    }
    
    [Benchmark]
    public void BinarySearchArr()
    {
        var index = Array.BinarySearch(_fruitsArr, "apple");
    }
    
    [Benchmark(Baseline = true)]
    public void IndexOf()
    {
        var index = _fruits.IndexOf("apple");
    }
    
    [Benchmark]
    public void IndexOfArr()
    {
        var index = Array.IndexOf(_fruitsArr, "apple");
    }

    [Benchmark]
    public void Linq()
    {
        var index = _fruits.Where(e => e == "apple");
    }
    
    [Benchmark]
    public void LinqArr()
    {
        var index = _fruitsArr.Where(e => e == "apple");
    }
}