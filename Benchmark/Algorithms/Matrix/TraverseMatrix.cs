using Benchmark.Contracts;
using Benchmark.Helpers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;

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
        
        if (i == n - 1 && j == m - 1)
        {
            return;
        }
        
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