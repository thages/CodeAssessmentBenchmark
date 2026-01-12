using Benchmark.Contracts;
using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

namespace Benchmark.Collections;

using static ConsoleKey;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class DicCollectionInitializer : ICodeAssessment
{
    [Benchmark]
    public Dictionary<ConsoleKey,string> CollectionInitializer()
    {
       return new Dictionary<ConsoleKey, string>
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
}