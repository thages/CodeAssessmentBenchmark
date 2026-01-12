using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

namespace Benchmark.Collections;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class PatternMatch
{
    [Benchmark(Baseline = true)]
    public void DefaultValidation()
    {
        List<int>  numbers = new(){ 1, 2, 3 };

        if ((numbers.ElementAt(0) == 0 || numbers.ElementAt(0) == 1)
            && numbers.ElementAt(1) >= 2
            && numbers.ElementAt(2) >= 3)
        {
            //Do something;
        }
    }

    [Benchmark]
    public void PatternList()
    {
        List<int> numbers = [ 1, 2, 3 ];
        
        if (numbers is [0 or 1, >= 2, >= 3])
        {
            //Do something;
        }
    }
    
   
}