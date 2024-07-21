using HesapMakinesiii.Data;
using HesapMakinesiii.Models;
using System;
using System.Linq;

public class CalculatorService
{
    private readonly ApplicationDbContext _context;

    public CalculatorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public double PerformCalculation(double number1, double number2, string operation)
    {
        double result = 0;

        switch (operation)
        {
            case "+":
                result = number1 + number2;
                break;
            case "-":
                result = number1 - number2;
                break;
            case "*":
                result = number1 * number2;
                break;
            case "/":
                if (number2 == 0)
                    throw new DivideByZeroException("Division by zero is not allowed.");
                result = number1 / number2;
                break;
        }

        var calculationHistory = new CalculationHistory
        {
            Number1 = number1,
            Number2 = number2,
            Operation = operation,
            Result = result,
        };

        try
        {
            _context.CalculationHistories.Add(calculationHistory);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            throw;
        }

        return result;
    }

    public double PerformMultipleCalculations(string expression)
    {
        var operations = new[] { "+", "-", "*", "/" };
        var parts = expression.Split(operations, StringSplitOptions.RemoveEmptyEntries);
        var operators = expression.Where(c => operations.Contains(c.ToString())).ToArray();

        if (parts.Length == 0 || operators.Length == 0)
            throw new ArgumentException("Invalid expression.");

        double result = double.Parse(parts[0]);

        for (int i = 0; i < operators.Length; i++)
        {
            double number = double.Parse(parts[i + 1]);
            string operation = operators[i].ToString();

            result = PerformCalculation(result, number, operation);
        }

        return result;
    }
}
