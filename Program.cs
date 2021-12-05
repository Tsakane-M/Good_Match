namespace myproject
{

    class Program
    {

        static void Main(string[] args)
        {

            string fname, lname;
            Console.Write("Enter your firstname: ");
            fname = Console.ReadLine();
            Console.Write("Enter your lastname: ");
            lname = Console.ReadLine();
            Console.Write("Your fullname is " + fname + " " + lname);

        }
    }
}