//https://open.kattis.com/problems/judgingmoose

using System;
using System.IO;

class ProblemB {
    public static void Main(){
        string value = Console.ReadLine();
        int[] arrOfTines = value.Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
        int a = arrOfTines[0];
        int b = arrOfTines[1];

        if (a < 0 || b < 0||(a==0 && b == 0 )|| (a>20 || b>20)) {
            Console.WriteLine("Not a moose");
        }else if(a == b){
            int sum = a + b;
            Console.WriteLine("Even "+ sum);
        }else{
            Console.WriteLine("Odd "+ Math.Max(a, b)*2);
        }
    }
}