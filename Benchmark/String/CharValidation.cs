using Benchmark.Contracts;
using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace Benchmark.String;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class CharValidation : ICodeAssessment
{
    [Benchmark]
    public bool CharMethod()
    {
        char c = 'a';
        return char.IsLetter(c);
    }
    
    [Benchmark(Baseline = true)]
    public bool CustomMethod()
    {
        char c = 'a';
        return c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');
    }
}