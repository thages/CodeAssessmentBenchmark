using System.Reflection;
using Benchmark.Contracts;
using System.Collections.Generic;
using System.Linq;
using Benchmark.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark;

public static class Program
{
    public static void Main(string[] args)
    {
        var types  = Assembly.GetExecutingAssembly().GetTypes();
        var codeType = typeof(ICodeAssessment);
        var codeAssessments = types.Where(t => codeType.IsAssignableFrom(t) && !t.IsInterface).ToArray();
        
        var separator = new string('*', 10);
        
        Console.WriteLine("{0} Select Your Assessment {0} ", separator);
        
        for (var i = 0; i < codeAssessments.Length; i++ )        
        {
            Console.WriteLine($"[{i}] - {codeAssessments[i].Name}");
        }

        var selected = int.TryParse(Console.ReadLine(), out var index) ? index : 0;
        if (index < 0 || index >= codeAssessments.Length)
        {
            Console.WriteLine("Invalid option");
            return ;
        }
        var assessment = codeAssessments[selected];
        BenchmarkRunner.Run(assessment);
    }
}



