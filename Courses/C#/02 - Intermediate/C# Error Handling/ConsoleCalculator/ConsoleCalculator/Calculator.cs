using System.Runtime.CompilerServices;

namespace ConsoleCalculator;

public class Calculator
{
    public int Calculate(int num1, int num2, string operation)
    {
       
        string nonNullOperation =
            operation ?? throw new ArgumentNullException(nameof(operation));

        if (nonNullOperation == "/")
        {
            try
            {
                return Divide(num1, num2);
            } 
            catch (DivideByZeroException ex) 
            {
                Console.WriteLine("...Logging...");
                //Log.Error(ex);
                //throw; 
                throw new ArithmeticException("An error occurred during calculation.", ex);
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(operation), "The mathematical operator is not supported.");

            //Console.WriteLine("Unknown Operation.");
            //return 0;
        }
    }

    private int Divide(int num1, int num2) => num1 / num2;
}
