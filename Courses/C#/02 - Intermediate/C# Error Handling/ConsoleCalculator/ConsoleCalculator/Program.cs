using ConsoleCalculator;
using static System.Console;

WriteLine("Enter first number"); 
int number1 = int.Parse(Console.ReadLine()!);

WriteLine("Enter second number");
int number2 = int.Parse(Console.ReadLine()!);

WriteLine("Enter operation");
string operation = ReadLine()!.ToUpperInvariant();

var calculator = new Calculator();
var result = calculator.Calculate(number1, number2, operation);

DisplayResult(result);

WriteLine("\nPress enter to exit.");
ReadLine();


static void DisplayResult(int result) => WriteLine($"Result is: {result}");