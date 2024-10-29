
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите математическое выражение:");
        string? input = Console.ReadLine();
        input = ReplaceVar(input);
        
        try
        {
            string[] rpn= InfixToRPN(input);
            double result = EvaluateRPN(rpn);
            Console.WriteLine($"Результат: {result}"); 
        }
       catch (Exception ex)       { Console.WriteLine($"Ошибка: {ex.Message}");}
    }

    static private string ReplaceVar(string expression)
    {
        char[] alphabet = new char[] { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
        
        string? variableString = "";
        var variableNames = Regex.Matches(expression, @"[a-zA-Z]+" );

        foreach (Match match in variableNames)
        {
            string variable = match.Value;

            if (!IsMathFunction(variable))
            {
                variableString += variable;
            }
        }

        foreach (var variable in variableString)
        {
            Console.WriteLine($"Введите переменную {variable}: ");
            string? newInput;

            // ввод - строка
            while (true)
            {
                newInput = Console.ReadLine();
                if (double.TryParse(newInput, out _))
                    break;
                else
                    Console.WriteLine("Некорректный ввод. Повторите ввод для переменной " + variable + ": ");
            }

            expression = Regex.Replace(expression, $@"\b{variable}\b", newInput);
        }
        return expression;
    }
    private static bool IsMathFunction(string variable)
    {
        switch (variable)
        {
            case "sqrt":
            case "ln":
            case "cos":
            case "sin":
            case "tan":
            case "abs":
            case "log":
            case "min":
            case "max":
            case "%":
            case "exp":
            case "floor":
            case "(-1)*":
                return true;
            default:
                return false;
        }
    }

    static string[] InfixToRPN(string str)
    {
        MyStack<string> operators = new MyStack<string>();
        string? output = "";
        foreach (string token in ParseTokens(str))
        {
            if (double.TryParse(token, out _))
            {
                output += token + " ";
            }
            
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (operators.Size() > 0 && operators.Peek() != "(")
                {
                    output += operators.Pop();
                }
                operators.Pop(); // Удаляем "("
            }
            else // оператор или функция
            {
                while (operators.Size() > 0 && Priority(operators.Peek()) >= Priority(token))
                {
                    output += operators.Pop();
                }
                operators.Push(token);
            }
        }

        while (operators.Size() > 0)
        {
            output += operators.Pop();
        }

        return output.Split();
    }

    static IEnumerable<string> ParseTokens(string input)
    {
        char[] delimiters = new char[] { ' ', '(', ')', ','};
        return input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    }

    static int Priority(string op)
    {
        return op switch
        {
            "+" or "-" => 1,
            "*" or "/" or "%" => 2,
            "^" => 3,
            "sqrt" or "sin" or "cos" or "tan" or "ln" or "log" or "min" or "max" or "floor" or "(-1)*" or "exp" or "abs"=> 4,
            _ => 0
        };
    }

    static double EvaluateRPN(string[] rpn)
    {
        MyStack<double> stack = new MyStack<double>();
        string? oper = "";
        for(int i = 0; i < rpn.Length; i++)
        {
            if(!double.TryParse(rpn[i], out _))
            {
                for(int j = 0; j < rpn.Length; j++)
                {
                    if (double.TryParse(rpn[j], out double num))
                    {
                        stack.Push(num);
                    }
                    else if (!double.TryParse(rpn[j], out _)) oper += rpn[j];
                }
                switch (oper)
                {
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        oper = "";
                        break;
                    case "-":
                        double subtrahend = stack.Pop();
                        stack.Push(stack.Pop() - subtrahend);
                        oper = "";
                        break;
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        oper = "";
                        break;
                    case "/":
                        double divisor = stack.Pop();
                        stack.Push(stack.Pop() / divisor);
                        oper = "";
                        break;
                    case "%":
                        double second = stack.Pop();
                        stack.Push(stack.Pop() % second);
                        oper = "";
                        break;
                    case "^":
                        double exponent = stack.Pop();
                        stack.Push(Math.Pow(stack.Pop(), exponent));
                        oper = "";
                        break;
                    case "abs":
                        stack.Push(Math.Abs(stack.Pop()));
                        oper = "";
                        break;
                    case "exp":
                        stack.Push(Math.Exp(stack.Pop()));
                        oper = "";
                        break;
                    case "sqrt":
                        stack.Push(Math.Sqrt(stack.Pop()));
                        oper = "";
                        break;
                    case "sin":
                        stack.Push(Math.Sin(stack.Pop()));
                        oper = "";
                        break;
                    case "cos":
                        stack.Push(Math.Cos(stack.Pop()));
                        oper = "";
                        break;
                    case "tan":
                        stack.Push(Math.Tan(stack.Pop()));
                        oper = "";
                        break;
                    case "ln":
                        stack.Push(Math.Log(stack.Pop()));
                        oper = "";
                        break;
                    case "log":
                        stack.Push(Math.Log10(stack.Pop()));
                        oper = "";
                        break;
                    case "min":
                        double minSecond = stack.Pop();
                        stack.Push(Math.Min(stack.Pop(), minSecond));
                        oper = "";
                        break;
                    case "max":
                        double maxSecond = stack.Pop();
                        stack.Push(Math.Max(stack.Pop(), maxSecond));
                        oper = "";
                        break;
                    case "floor":
                        stack.Push(Math.Floor(stack.Pop()));
                        oper = "";
                        break;
                    case "(-1)*":
                        stack.Push((-1) * stack.Pop());
                        oper = "";
                        break;
                    default:
                        throw new InvalidOperationException($"Неизвестный оператор: {rpn[i]}");
                }
                break;
            }
            if (double.TryParse(rpn[i], out double number))
            {
                stack.Push(number);
            }
            else
            {
                switch (rpn[i])
                {
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        oper = "";
                        break;
                    case "-":
                        double subtrahend = stack.Pop();
                        stack.Push(stack.Pop() - subtrahend);
                        oper = "";
                        break;
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        oper = "";
                        break;
                    case "/":
                        double divisor = stack.Pop();
                        stack.Push(stack.Pop() / divisor);
                        oper = "";
                        break;
                    case "%":
                        double second = stack.Pop();
                        stack.Push(stack.Pop() % second);
                        oper = "";
                        break;
                    case "^":
                        double exponent = stack.Pop();
                        stack.Push(Math.Pow(stack.Pop(), exponent));
                        oper = "";
                        break;
                    
                    default:
                        throw new InvalidOperationException($"Неизвестный оператор: {rpn[i]}");
                    }
                }
            }
        return stack.Pop();
    }
    
}
