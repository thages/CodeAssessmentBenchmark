using Benchmark.Contracts;
using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

namespace Benchmark.Collections;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class ArraySegment : ICodeAssessment
{
    [Benchmark(Baseline = true)]
    public void WithCopy()
    {
        int[] myArr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        var segment = new int[4];
        Array.Copy(myArr, 4, segment, 0, 4);
        
        for (var i = 0; i < segment.Length; i++)
            Console.WriteLine(segment[i]);
        
    }

    [Benchmark]
    public void WithArraySegment()
    {
        int[] myArr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        ArraySegment<int> segment = new(myArr, 4, 4);

        for (var i = 0; i < segment.Count; i++)
        {
            Console.WriteLine(segment[i]);
        }
    }
}