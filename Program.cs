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
            Console.Write("Enter the first name: ");
            fname = Console.ReadLine();
            //Console.Write("Enter the second name: ");
            //lname = Console.ReadLine();
            calculateMatch(fname, lname);

        }

        static void calculateMatch(string firstname, string secondname)
        {
            string temporary = firstname;
            var indicesToBeRemoved = new ArrayList();

            //iterate through the string for each char in string
            for (int i = 0; i < firstname.Length - 1; i++)
            {
                //for each char iterate through all the other chars in the word
                for (int j = i + 1; j < firstname.Length; j++)
                {
                    //if char matches our char
                    if (firstname[i] == firstname[j])
                    {
                        //add char indice to array
                        indicesToBeRemoved.Add(j);
                    }
                }
                //show all char indices to be removed
                Console.WriteLine("for " + firstname[i] + "we remove: ");
                PrintValues(indicesToBeRemoved);
                indicesToBeRemoved.Clear();
            }
        }
        //remove all similar chars at their indices
        //for (int k = 0; k < indicesToBeRemoved.size(); k++)
        // {
        // temporary = temporary.Replace(indicesToBeRemoved[i].ToString(), String.Empty);
        // }
        // Console.WriteLine(temporary);
        //}
        // }


        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }





    }
}