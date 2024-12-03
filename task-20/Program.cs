using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class VariableInfo
{
    public VariableType Type { get; }
    public string Value { get; }

    public VariableInfo(VariableType type, string value)
    {
        Type = type;
        Value = value;
    }
}

public enum VariableType
{
    Int,
    Float,
    Double
}

class Program
{
    static void Main(string[] args)
    {
        string path = "input.txt";
        try
        {
            MyHashMap<string, VariableInfo> variables = new MyHashMap<string, VariableInfo>(); // Храним переменные
            string pattern = @"^\s*(int|float|double)\s+([a-zA-Z_][a-zA-Z0-9_]*)(\s*=\s*(-?\d+|(-?\d+\.\d*)))?\s*;";
            

            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                string currentDefinition = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    currentDefinition += line.Trim() + " ";

                    // Проверяем, закончено ли определение
                    if (line.Trim().EndsWith(";"))
                    {
                        Match match = Regex.Match(currentDefinition, pattern);
                        if (match.Success)
                        {
                            VariableType varType = GetVariableType(match.Groups[1].Value);
                            string varName = match.Groups[2].Value;
                            string? value = match.Groups[4].Success ? match.Groups[4].Value : "0"; // По умолчанию 0, если нет значения

                            if (!variables.ContainsKey(varName))
                            {
                                variables.Put(varName, new VariableInfo(varType, value));
                            }
                             else if (variables.ContainsKey(varName))
                            {
                                Console.WriteLine($"Переопределение переменной: {varName}");
                            }
                        }
                        else Console.WriteLine($"Некорректное определение: {line}");

                        // Сбросить текущее определение
                        currentDefinition = string.Empty;
                    }
                }
            }

            // Записываем результат в файл
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                foreach (var pair in variables.EntrySet())
                {
                    sw.WriteLine($"{pair.Value.Type} => {pair.Key} = {pair.Value.Value};");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

    }

    static VariableType GetVariableType(string typeString)
    {
        return typeString switch
        {
            "int" => VariableType.Int,
            "float" => VariableType.Float,
            "double" => VariableType.Double,
            _ => throw new ArgumentException("Некорректный тип переменной")
        };
    }
}