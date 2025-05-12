using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Series_Analyzer
{
    public class Program
    {
        static List<int> numbers = new List<int>();
        static void InputRequest()
        {
            bool isStoper = true;

            while (isStoper)
            {
                Console.WriteLine("enter positive number");
                string input = Console.ReadLine();
                if (input == "stop")
                {
                    if (numbers.Count >=3) 
                    { isStoper = false;}
                }
                else
                {
                    if (IntCheck(input) && PosCheck(input))
                        numbers.Add(int.Parse(input));
                }
            }
        }

        static bool IntCheck(string a)
        {
            int b;
            if (int.TryParse(a,out b))
                return true;
            return false;
        }

        static bool PosCheck(string a)
        {
            if (int.Parse(a) > 0)
                return true;
            return false;
        }

        static void ProprietyCheck(string[] args)
        {
            foreach (string arg in args)
            {
                if (IntCheck(arg) && PosCheck(arg))
                    numbers.Add(int.Parse(arg));
            }
        }


        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                InputRequest();
            }
            else
            {
                ProprietyCheck(args);
            }

                //menu(args)
        }
    }
}
