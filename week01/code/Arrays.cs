using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // Step 1: Create a new array of type double[] with size equal to 'length'.
        // Step 2: Use a for loop that runs from 0 to length-1.
        // Step 3: In each iteration, calculate the multiple as number * (i + 1)
        //         and store it in the corresponding index of the array.
        // Step 4: After the loop, return the filled array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // Step 1: Determine how many elements are in the list using data.Count.
        // Step 2: Slice the last 'amount' elements using GetRange to get the part to move to the front.
        // Step 3: Slice the first part (from 0 to count - amount) using GetRange.
        // Step 4: Clear the original list using data.Clear().
        // Step 5: Add the rotated part (last few elements) first using AddRange().
        // Step 6: Add the remaining front part afterward using AddRange().

        int count = data.Count;

        List<int> rotatedPart = data.GetRange(count - amount, amount);
        List<int> remainingPart = data.GetRange(0, count - amount);

        data.Clear();
        data.AddRange(rotatedPart);
        data.AddRange(remainingPart);
    }
}
