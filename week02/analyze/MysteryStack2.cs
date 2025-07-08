using System;
using System.Collections.Generic;

public static class MysteryStack2
{
    public static float Run(string text)
    {
        var stack = new Stack<float>();

        foreach (var token in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            switch (token)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "^":
                case "%":
                    if (stack.Count < 2)
                        throw new ApplicationException($"Invalid Case 1! Not enough operands for '{token}'");

                    float operand2 = stack.Pop();
                    float operand1 = stack.Pop();

                    float result = token switch
                    {
                        "+" => operand1 + operand2,
                        "-" => operand1 - operand2,
                        "*" => operand1 * operand2,
                        "/" => operand2 == 0 
                            ? throw new ApplicationException("Invalid Case 2! Division by zero") 
                            : operand1 / operand2,
                        "^" => (float)Math.Pow(operand1, operand2),
                        "%" => operand2 == 0 
                            ? throw new ApplicationException("Invalid Case 2! Modulus by zero") 
                            : operand1 % operand2,
                        _ => throw new ApplicationException($"Invalid operator '{token}'")
                    };

                    stack.Push(result);
                    break;

                case "neg":
                    if (stack.Count < 1)
                        throw new ApplicationException("Invalid Case 1! Not enough operands for 'neg'");
                    stack.Push(-stack.Pop());
                    break;

                default:
                    if (float.TryParse(token, out float number))
                    {
                        stack.Push(number);
                    }
                    else
                    {
                        throw new ApplicationException($"Invalid Case 3! Unrecognized token '{token}'");
                    }
                    break;
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4! Final stack must contain exactly one result");

        return stack.Pop();
    }
}
