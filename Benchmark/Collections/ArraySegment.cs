using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using TraceReloggerLib;

namespace Benchmark.Collections;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class ArraySegment
{
    [Benchmark(Baseline = true)]
    public void WithCopy()
    {
        int[] myArr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        int[] segment = new int[4];
        Array.Copy(myArr, 4, segment, 0, 4);
        
        for (int i = 0; i < segment.Length; i++)
            Console.WriteLine(segment[i]);
        
    // Console.WriteLine(string.Join(Environment.NewLine,segment));
    }

    [Benchmark]
    public void WithArraySegment()
    {
        int[] myArr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        ArraySegment<int> segment = new(myArr, 4, 4);

        for (int i = 0; i < segment.Count; i++)
        {
            Console.WriteLine(segment[i]);
        }

        // Console.WriteLine(string.Join(Environment.NewLine,segment));
    }
}