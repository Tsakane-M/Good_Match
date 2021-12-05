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
            string sumString = "";



            //loop as long as string has chars
            while (temporary.Length > 0)
            {

                //count occurance of each char
                char ch = temporary[0];
                int frequency = temporary.Count(f => (f == ch));
                //Console.WriteLine("frequency of:" + temporary[0] + " is " + frequency);
                occuranceString = occuranceString + frequency;


                //remove current indice
                temporary = temporary.Replace(temporary[0].ToString(), String.Empty);

                //print new word
                //Console.WriteLine("new string is :" + temporary);
                //Console.WriteLine();


            }
            Console.WriteLine("OccuranceString: " + occuranceString);
            //use occurance string to calculate 2 digit number
            sumString = produceSums(occuranceString);

            Console.WriteLine("The string of sums is: " + sumString);
            Console.WriteLine("The string of matches is: " + produceMatches(sumString));




            static string produceSums(string occuranceString)
            {
                string myString = "";

                while (occuranceString.Length > 1)
                {
                    int sum = 0;
                    int left = (int)Char.GetNumericValue(occuranceString[0]);
                    int right = (int)Char.GetNumericValue(occuranceString[occuranceString.Length - 1]);
                    sum = left + right;
                    myString = myString + "" + sum.ToString();
                    occuranceString = occuranceString.Remove(0, 1);
                    occuranceString = occuranceString.Remove((occuranceString.Length) - 1);


                    if (occuranceString.Length == 1)
                    {
                        myString = myString + "" + occuranceString;

                    }
                }
                return myString;
            }

            static string produceMatches(string sumString)
            {
                if (sumString.Length == 2)
                {
                    return sumString;
                }
                else
                {
                    return produceMatches(produceSums(sumString));
                }



            }



        }


    }

}











