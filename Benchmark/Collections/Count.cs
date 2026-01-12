using Benchmark.Contracts;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Collections;

public class Count : ICodeAssessment
{
    private readonly List<string> _list = ["a", "b", "c"];

    [Benchmark]
    public bool PropCount() => _list.Count > 0;

    [Benchmark]
    public bool MethodCount() => _list.Count() > 0;

    [Benchmark]
    public bool MethodAny() => _list.Any();
}