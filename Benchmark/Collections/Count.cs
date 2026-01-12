using BenchmarkDotNet.Attributes;

namespace Benchmark.Collections;

public class Count
{
    private readonly List<string> _lista;

    public Count()
    {
       _lista = new List<string>(){ "a", "b", "c" };
    }

    [Benchmark]
    public bool PropCount() => _lista.Count > 0;

    [Benchmark]
    public bool MethodCount() => _lista.Count() > 0;

    [Benchmark]
    public bool MethodAny() => _lista.Any();
}