using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace The_Series_Analyzer
{
    public class Program
    {
        static List<int> numbers = new List<int>();
        static void inputRequest()
        {
            bool stopper = true;
            while (stopper)
            { 
                numbers.Clear();
                Console.WriteLine("Enter a series of at least 3 positive numbers.");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');
                stopper = integrityCheck(parts);
            }
        }

        static bool integrityCheck(string[] args)
        {
            foreach (string arg in args)
            {
                if (intCheck(arg) && posCheck(arg))
                {
                    numbers.Add(int.Parse(arg));
                }
                else
                {
                    Console.WriteLine("wrong input");
                    return true;
                }
            }
            if (numbers.Count < 3)
                return true;
            
            return false;

        }

        static bool intCheck(string obj)
        {
            int check;
            if (int.TryParse(obj, out check))
                return true;
            return false;
        }

        static bool posCheck(string obj)
        {
            if (int.Parse(obj) > 0)
                return true;
            return false;
        }


        static void menu(List<int> series)
        {
            bool stopper = true;
            do
            {
                printMenu();
                string choice = Console.ReadLine();
                stopper = checkChoice(choice);
            }
            while (stopper);
        }

        static void printMenu()
        {
            Console.WriteLine("\n====== Series Analyzer Menu ======\n" +
                              "Please choose an option by typing the corresponding letter:\n\n" +
                              "a. Enter a new series of numbers\n" +
                              "b. Show the series (original order)\n" +
                              "c. Show the series in reverse order\n" +
                              "d. Show the series sorted from low to high\n" +
                              "e. Show the maximum value\n" +
                              "f. Show the minimum value\n" +
                              "g. Show the average of the series\n" +
                              "h. Show how many numbers are in the series\n" +
                              "i. Show the sum of all numbers\n" +
                              "j. Exit the program\n");
        }

        static bool checkChoice(string choice)
        {
            switch (choice)
            {
                case "a":
                    inputRequest();
                    return true;

                case "b":
                    Console.WriteLine("The series in original order:");
                    printSeries(numbers);
                    return true;
                
                case "c":
                    Console.WriteLine("The series in reverse order:");
                    reversPrintSeries(numbers);
                    return true;
                
                case "d":
                    Console.WriteLine("The sorted series (low to high):");
                    sortSeries(numbers);
                    return true;

                case "e":
                    Console.Write("The maximum value is: ");
                    show(maxValSeries(numbers));
                    return true;
                    
                case "f":
                    Console.Write("The minimum value is: ");
                    show(minValSeries(numbers));
                    return true;

                case "g":
                    Console.Write("The average of the series is: ");
                    show(averageSeries(numbers));
                    return true;
                    
                case "h":
                    Console.Write("The number of elements in the series is: ");
                    show(lenSeries(numbers));
                    return true;
                    
                case "i":
                    Console.Write("The sum of the series is: ");
                    show(sumSeries(numbers));
                    return true;

                case "j":
                    Console.WriteLine("goodbye"); 
                    return false;

                default:
                    Console.WriteLine("wrong choice");
                    return true;
            } 
                
        }

        static void printSeries(List<int> series)
        {
            foreach (int i in series) 
                show(i);
        }

        static void reversPrintSeries(List<int> series)
        {
            for (int i = series.Count - 1; i >= 0; i--)
                show(series[i]);
        }

        static void sortSeries(List<int> series)
        {
            List<int> sorted = new List<int>(series);
            bool isUnsort = true;
            while(isUnsort)
            {
                isUnsort = false;
                for (int i = 0; i < sorted.Count -1; i++)
                {
                    if (sorted[i] > sorted[i + 1])
                    {
                        int tmp = sorted[i];
                        sorted[i] = sorted[i + 1];
                        sorted[i + 1] = tmp;
                        isUnsort = true;
                    }    

                }
            }
            printSeries(sorted);
        }

        static int maxValSeries(List<int> series)
        {
            int maxVal = series[0];
            foreach (int i in series)
                if (i > maxVal)
                    maxVal = i;
            return maxVal;
        }

        static int minValSeries(List<int> series)
        {
            int minVal = series[0];
            foreach (int i in series)
                if (i < minVal)
                    minVal = i;
            return minVal;
        }

        static float averageSeries(List<int> series)
        {
            float average = (float)sumSeries(series)/lenSeries(series);
            return average; 
        }

        static int lenSeries(List<int> series)
        {
            int len = 0;
            foreach (int i in series)
                len++;
            return len;
        }

        static int sumSeries(List<int> series)
        {
            int sum = 0;
            foreach(int i in series)
                sum += i;
            return sum;
        }


        static void show(float f)
            { Console.WriteLine(f); }

        static void show(int i)
            { Console.WriteLine(i); }


        static void Main(string[] args)
        {
            if (args.Length < 3 || integrityCheck(args))
                inputRequest();
            
            menu(numbers);
        }
    }
}
