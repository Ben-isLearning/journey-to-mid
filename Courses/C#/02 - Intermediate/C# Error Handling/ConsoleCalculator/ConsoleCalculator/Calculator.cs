﻿using System.Runtime.CompilerServices;

namespace ConsoleCalculator;

public class Calculator
{
    public int Calculate(int num1, int num2, string operation)
    {
        if (operation == "/")
        {
            return Divide(num1, num2);
        }
        else {
            throw new ArgumentOutOfRangeException(nameof(operation), "The mathematical operator is not supported.");

            //Console.WriteLine("Unknown Operation.");
            //return 0;
        }
    }

    private int Divide(int num1, int num2) => num1 / num2; 
}
