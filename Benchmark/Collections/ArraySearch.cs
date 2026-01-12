using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

namespace Benchmark.Collections;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class ArraySearch
{
    private readonly List<string> fruits;
    private readonly string[] fruitsArr;
    public ArraySearch()
    {
        fruits = ["tangerine", "apple", "kiwi", "pineapple", "strawberry", "grape"];
        fruitsArr = ["tangerine", "apple", "kiwi", "pineapple", "strawberry", "grape"];
    }
    
    [Benchmark]
    public void BinarySearch()
    {
        var index = fruits.BinarySearch("apple");
    }
    
    [Benchmark]
    public void BinarySearchArr()
    {
        var index = Array.BinarySearch(fruitsArr, "apple");
    }
    
    [Benchmark(Baseline = true)]
    public void IndexOf()
    {
        var index = fruits.IndexOf("apple");
    }
    
    [Benchmark]
    public void IndexOfArr()
    {
        var index = Array.IndexOf(fruitsArr, "apple");
    }

    [Benchmark]
    public void Linq()
    {
        var index = fruits.Where(e => e == "apple");
    }
    
    [Benchmark]
    public void LinqArr()
    {
        var index = fruitsArr.Where(e => e == "apple");
    }
}