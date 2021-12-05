using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace myproject
{

    class Program
    {

        static void Main(string[] args)
        {

            string fname = "";
            string lname = "";
            Console.Write("Enter the name: ");
            fname = Console.ReadLine();
            //Console.Write("Enter the second name: ");
            //lname = Console.ReadLine();
            calculateMatch(fname, lname);

        }

        static void calculateMatch(string firstname, string secondname)
        {
            //create temp string
            string temp = firstname;
            string temporary = String.Concat(temp.Where(c => !Char.IsWhiteSpace(c)));
            string occuranceString = "";



            //loop as long as string has chars
            while (temporary.Length > 0)
            {

                //count occurance of each char
                char ch = temporary[0];
                int frequency = temporary.Count(f => (f == ch));
                Console.WriteLine("frequency of:" + temporary[0] + " is " + frequency);
                occuranceString = occuranceString + frequency;
                Console.WriteLine("OccuranceString: " + occuranceString);

                //remove current indice
                temporary = temporary.Replace(temporary[0].ToString(), String.Empty);

                //print new word
                Console.WriteLine("new string is :" + temporary);
                Console.WriteLine();

            }

        }


    }

}









