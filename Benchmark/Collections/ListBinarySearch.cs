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
public class ListBinarySearch
{
    private readonly List<string> fruits;
    public ListBinarySearch()
    {
        fruits = ["tangerine", "apple", "kiwi", "pineapple", "strawberry", "grape"];
        fruits.Sort();
    }
    
    [Benchmark]
    public void BinarySearch()
    {
        
        var index = fruits.BinarySearch("apple");
        // if (index >= 0)
        // {
        //     fruits.Insert(index, "banana");
        // }

       // return fruits;
    }
        
    [Benchmark(Baseline = true)]
    public void IndexOf()
    {


        var index = fruits.IndexOf("apple");
        // if (index > 0)
        // {
        //     fruits.Insert(index, "banana");
        // }

        //return fruits;
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