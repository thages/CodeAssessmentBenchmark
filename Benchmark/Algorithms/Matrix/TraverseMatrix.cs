using Benchmark.Contracts;
using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace Benchmark.Algorithms.Matrix;

[Config(typeof(BenchConfig))]
[HideColumns(Column.Job, Column.RatioSD, Column.AllocRatio)]
[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class TraverseMatrix : ICodeAssessment
{
    public static string Name => typeof(TraverseMatrix).FullName ?? string.Empty; 

    [Benchmark]
    public void Recursive()
    {
        
        Traverse(Constants.Matrix,0,0);
    }
    
    public void Traverse(List<List<int>> matrix, int i, int j)
    {
        var m = matrix[i].Count;
        var n = matrix.Count;
        
        // If the current position is the bottom-right corner of
        // the matrix
        if (i == n - 1 && j == m - 1)
        {
            // Print the value at that position
            //Console.WriteLine(matrix[i][j]);
            // End the recursion
            return;
        }
 
        // Print the value at the current position
        //Console.Write($"{matrix[i][j]}, ");
 
        // If the end of the current row has not been reached
        if (j < m - 1)
        {
            // Move right
            Traverse(matrix, i, j + 1);
        }
        // If the end of the current column has been reached
        else if (i < n - 1)
        {
            // Move down to the next row
            Traverse(matrix, i + 1, 0);
        }
    }

    [Benchmark(Baseline = true)]
    public void Loop()
    {
        
        ForLoop(Constants.Matrix);
    }
    
    public void ForLoop(List<List<int>> matrix)
    {
        int count = 0;
        
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                count++;
            }
        }
    }
}