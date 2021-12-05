using System;

namespace myproject
{

    class Program
    {

        static void Main(string[] args)
        {

            string fname, lname;
            Console.Write("Enter the first name: ");
            fname = Console.ReadLine();
            Console.Write("Enter the second name: ");
            lname = Console.ReadLine();
            calculateMatch(fname, lname);

        }

        static void calculateMatch(string firstname, string secondname)
        {
            Console.Write(firstname + " " + secondname);
        }
    }
}