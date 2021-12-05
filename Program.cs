using System;
using System.Collections;

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
            string temporary = firstname;



            //loop as long as string has chars
            while (temporary.Length > 0)
            {

                char ch = temporary[0];
                int frequency = temporary.Count(f => (f == ch));
                Console.WriteLine("frequency of:" + temporary[0] + " is " + frequency);

                //remove current indice
                temporary = temporary.Replace(temporary[0].ToString(), String.Empty);

                //print new word
                Console.WriteLine("new string is :" + temporary);
                Console.WriteLine();

            }

        }


    }

}









