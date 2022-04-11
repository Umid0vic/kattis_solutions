//https://open.kattis.com/problems/addingwords

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static string clear = "clear";
    static string def = "def";
    static string calc = "calc";
    static Dictionary<string, int> wordsToNumbers = new Dictionary<string, int>();

    static void Main(string[] args)
    {
        string line = string.Empty;
        
        while ((line = Console.ReadLine()) != null)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                Calculate(line);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }

    static void Calculate(string line)
    {
        int number;
        string[] inputs = line.Split(" ");
        if (inputs[0] == clear)
        {
            wordsToNumbers.Clear();
        }
        else if (inputs[0] == def)
        {
            number = int.Parse(inputs[2]);

            if (!wordsToNumbers.ContainsKey(inputs[1]))
            {
                wordsToNumbers.Add(inputs[1], number);
            }
            else
            {
                wordsToNumbers[inputs[1]] = number;
            }
        }
        else if(inputs[0] == calc)
        {
            var wordsToCalculate = line.Substring(5, line.Length - 5);
            var expression = line.Substring(5, line.Length - 7).Split(' ');
            var sum = 0;

            for (var i = 0; i < expression.Length; i++)
            {
                if (i == 0)
                {
                    sum = wordsToNumbers.ContainsKey(expression[i])? wordsToNumbers[expression[i]] : int.MinValue;
                }

                if (sum != int.MinValue)
                {
                    if (expression[i] == "+")
                    {
                        if (!wordsToNumbers.ContainsKey(expression[i + 1]))
                        {
                            sum = int.MinValue;
                        }
                        else
                        {
                            sum += wordsToNumbers[expression[i + 1]];
                            i++;
                        }
                    }
                    else if (expression[i] == "-")
                    {
                        if (!wordsToNumbers.ContainsKey(expression[i + 1]))
                        {
                            sum = int.MinValue;
                        }
                        else
                        {
                            sum -= wordsToNumbers[expression[i + 1]];
                            i++;
                        }
                    }
                }
            }

            if (wordsToNumbers.ContainsValue(sum))
            {
                Console.WriteLine(wordsToCalculate + " " + wordsToNumbers.FirstOrDefault(w => w.Value == sum).Key);
            }
            else
            {
                Console.WriteLine(wordsToCalculate + " " + "unknown");
            }
        }
        else
        {
            Console.WriteLine("The input is not valid!");

        }
    }
}

/*

Sample input:
def foo 3
calc foo + bar =
def bar 7
def programming 10
calc foo + bar =
def is 4
def fun 8
calc programming - is + fun =
def fun 1
calc programming - is + fun =
clear

Sample output:
foo + bar = unknown
foo + bar = programming
programming - is + fun = unknown
programming - is + fun = bar

*/