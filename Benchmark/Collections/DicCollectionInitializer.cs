using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace Benchmark.Collections;

using static ConsoleKey;

[Config(typeof(Config))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class DicCollectionInitializer
{
    [Benchmark]
    public Dictionary<ConsoleKey,string> CollectionInitializer()
    {
       return new()
        {
            [UpArrow] =  $"Pressed {nameof(UpArrow)}",
            [DownArrow] =  $"Pressed {nameof(DownArrow)}",
            [LeftArrow] =  $"Pressed {nameof(LeftArrow)}",
            [RightArrow] =  $"Pressed {nameof(RightArrow)}",
            [Enter] =  $"Pressed {nameof(Enter)}",
        };
    }

    [Benchmark(Baseline = true)]
    public Dictionary<ConsoleKey, string> RegularInitializer()
    {
        Dictionary<ConsoleKey, string> actions = new();
        
        actions.Add(UpArrow, $"Pressed {nameof(UpArrow)}");
        actions.Add(DownArrow, $"Pressed {nameof(DownArrow)}");
        actions.Add(LeftArrow, $"Pressed {nameof(LeftArrow)}");
        actions.Add(RightArrow, $"Pressed {nameof(RightArrow)}");
        actions.Add(Enter, $"Pressed {nameof(Enter)}");
        
        return actions;
    }
    
    // public Dictionary<ConsoleKey,Func<string>> CollectionInitializer()
    // {
    //     return new()
    //     {
    //         [UpArrow] =  () => $"Pressed {nameof(UpArrow)}",
    //         [DownArrow] =  () => $"Pressed {nameof(DownArrow)}",
    //         [LeftArrow] =  () => $"Pressed {nameof(LeftArrow)}",
    //         [RightArrow] =  () => $"Pressed {nameof(RightArrow)}",
    //         [Enter] =  () => $"Pressed {nameof(Enter)}",
    //     };
    // }
    //
    // [Benchmark(Baseline = true)]
    // public Dictionary<ConsoleKey, Func<string>> StandardInitializer()
    // {
    //     Dictionary<ConsoleKey, Func<string>> actions = new();
    //     
    //     actions.Add(UpArrow, () => $"Pressed {nameof(UpArrow)}");
    //     actions.Add(DownArrow, () => $"Pressed {nameof(DownArrow)}");
    //     actions.Add(LeftArrow, () => $"Pressed {nameof(LeftArrow)}");
    //     actions.Add(RightArrow, () => $"Pressed {nameof(RightArrow)}");
    //     actions.Add(Enter, () => $"Pressed {nameof(Enter)}");
    //     
    //     return actions;
    // }
     
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