using System.Security.AccessControl;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using System.Linq;

namespace Benchmark.Collections;

[MemoryDiagnoser]
public class Spread
{

   [Benchmark]
   public  List<int> SpreadOperator()
   {
      List<int> numbers = [4, 5];
      List<int> number = [..numbers];
      return [1, 2, 3,.. numbers];
   }

   [Benchmark(Baseline = true)]
   public List<int> AddRange()
   {
      List<int> numbers = new() { 4, 5 };
      List<int> result = new() { 1, 2, 3};

      int[] teste = new int[2] { 1, 2 };

      int[] teste2 = new int[2]{ 3, 4 };
      
      result.AddRange(numbers);
      
      return result;
   }
   
}