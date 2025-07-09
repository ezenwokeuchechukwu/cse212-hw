using System;
using System.IO;
using Xunit;

public class ComplexStackSolutionTest
{
    [Fact]
    public void Main_PrintsExpectedOutputs()
    {
        // Arrange
        var sw = new StringWriter();
        Console.SetOut(sw);

        // Act
        ComplexStackSolution.Main();

        // Assert
        var outputLines = sw.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        Assert.Equal(3, outputLines.Length);

        // 1st test: True (balanced)
        Assert.Equal("True", outputLines[0]);
        // 2nd test: False (wrong bracket)
        Assert.Equal("False", outputLines[1]);
        // 3rd test: False (missing closing bracket)
        Assert.Equal("False", outputLines[2]);
    }
}