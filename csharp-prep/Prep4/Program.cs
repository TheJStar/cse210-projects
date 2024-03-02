using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();
        int number;
        int sum = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter Number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0){
                numberList.Add(number);
            }
            else {
                break;
            }
        }

        foreach (int num in numberList) {
            // sum of all numbers
            sum += num;
        }

        // the average of all numbers
        float average = ((float)sum)/numberList.Count;

        // largest number
        int largestNumber = numberList[0];
        foreach (int num in numberList){
            if (num > largestNumber){
                largestNumber = num;
            }
        }

        // gets the first positive number
        int smallestPositiveNumber = 0;
        foreach (int num in numberList) {
            if (num > 0) {
                smallestPositiveNumber = num;
                break;
            }
        }
        // gets smallest positive number
        foreach (int num in numberList) {
            if (num < smallestPositiveNumber && num > 0) {
                smallestPositiveNumber = num;
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");

        List<int> sortedNumbers = numberList.OrderBy(n => n).ToList();
        foreach (int num in sortedNumbers) {
            Console.WriteLine(num);
        }
    }
}