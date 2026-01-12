using BenchmarkDotNet.Attributes;

namespace Benchmark.Variables;

[MemoryDiagnoser]
public class BoolValidation
{
    [Benchmark]
    public bool HashSetTest()
    {
        var hash = new HashSet<bool>()
        {
            true,
            true
        };

        return !hash.Contains(false);
    }

    [Benchmark]
    public bool Variables()
    {
        var a = true;
        var b = true;

        return !a || !b;
    }
}