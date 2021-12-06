using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading.Tasks;

namespace myproject {

    class Program {

        static void Main(string[] args) {
            //obtain and process/handle user input
            string fname = "";
            string lname = "";
            string option = "";

            while (true) {

                Console.WriteLine("WELCOME TO MATCH CALCULATOR");
                Console.WriteLine("............................");
                Console.WriteLine("CHOOSE YOUR OPTION AND PRESS ENTER!");
                Console.WriteLine("OPTION 1: ENTER 1 TO ENTER TWO NAMES AND GET THEIR MATCH PERCENTAGE!");
                Console.WriteLine("OPTION 2: ENTER 2 TO ENTER THE CSV FILENAME AND MATCH MANY NAMES!");
                Console.WriteLine("OPTION 3: ENTER 3 TO QUIT!");
                Console.Write(":");
                option = Console.ReadLine();

                //cater for different console options

                if (option == "1") {

                    while (true) {
                        Console.Write("Enter the first name: ");
                        fname = Console.ReadLine();

                        Console.Write("Enter the second name: ");
                        lname = Console.ReadLine();

                        string check = fname + lname;
                        bool result = check.All(Char.IsLetter);

                        if (!result) {
                            Console.WriteLine("Please Enter Valid Input!");
                            Console.WriteLine();
                            continue;
                        } else {
                            break;
                        }
                    }

                    Console.WriteLine(produceOutput(fname, lname));



                } else if (option == "3") {
                    System.Environment.Exit(0);

                } else if (option == "2") {

                    Console.Write("Enter the CSV filename: ");
                    string fileName = Console.ReadLine();

                    

                    using(var reader = new StreamReader(fileName)) {
                        List < string > names = new List < string > ();
                        List < string > genders = new List < string > ();

                        while (!reader.EndOfStream) {
                            var line = reader.ReadLine();
                            //Console.WriteLine(line);
                            var values = line.Split(',');

                            names.Add(values[0]);
                            genders.Add(values[1]);
                        }
                    Console.WriteLine("CSV file successfully Read!\n");
                    Console.WriteLine("Processing Input...\n");
                        //remove dublicates
                        for (int i = 0; i < names.Count; i++) {

                            for (int j = i + 1; j < names.Count; j++) {
                                if (names[i] == names[j] && genders[i] == genders[j]) {


                                    names.RemoveAt(j);
                                    genders.RemoveAt(j);


                                }
                            }
                        }

                        //create different lists of males and females
                        List < string > males = new List < string > ();
                        List < string > females = new List < string > ();


                        //print new without dublicates
                        for (int i = 0; i < names.Count; i++) {

                            //Console.Write("name: " + names[i]);
                            //Console.Write("  gender: " + genders[i]);
                            //Console.WriteLine();
                            if (genders[i] == "m") {
                                males.Add(names[i]);
                            } else if (genders[i] == "f") {
                                females.Add(names[i]);
                            }
                        }
                        //Console.WriteLine("females:");
                        for (int i = 0; i < females.Count; i++) {
                            //Console.WriteLine(females[i]);


                        }
                        //Console.WriteLine();
                      
                        Console.WriteLine("Completed Processing Input..");

                        //write to output file

                        try {
                            //Pass the filepath and filename to the StreamWriter Constructor
                            StreamWriter sw = new StreamWriter("Output.txt");
                            
                            //Write the lines of text
                            for (int i = 0; i < males.Count; i++) {

                                //run the matches calculator against all females.
                                for (int j = 0; j < females.Count; j++) {

                                    sw.WriteLine(produceOutput(males[i], females[j]));

                                }

                            }
                            
                            sw.Close();
                            Console.WriteLine("Output Written To Output.txt! \n");
                        } catch (Exception e) {
                            Console.WriteLine("Exception: " + e.Message);
                        } 

                    }


                } else {
                    Console.WriteLine("Please Enter A Valid Option!");
                }


            }

        }
        static string calculateMatch(string sentence) {
            //create temp string
            string temporary = sentence;
            string occuranceString = "";
            string sumString = "";



            //loop as long as string has chars
            while (temporary.Length > 0) {

                //count occurance of each char
                char ch = temporary[0];
                int frequency = temporary.Count(f => (f == ch));
                //Console.WriteLine("frequency of:" + temporary[0] + " is " + frequency);
                occuranceString = occuranceString + frequency;


                //remove current indice
                temporary = temporary.Replace(temporary[0].ToString(), String.Empty);

            }

      
            sumString = produceSums(occuranceString);

            return produceMatches(sumString);

        }
        static string produceOutput(string fname, string lname) {
            string name1 = fname.ToLower();
            string name2 = lname.ToLower();

            string check = fname + lname;
            bool result = check.All(Char.IsLetter);

            if (!result) {
                return("Input is invalid, Please Enter Valid Input!");
            } 

            string sentence = name1 + " matches " + name2;
            sentence = String.Concat(sentence.Where(c => !Char.IsWhiteSpace(c)));
            //calculate match percentage print results
            int percentage = Int32.Parse(calculateMatch(sentence));

            //check if % greater or less than 80
            if (percentage >= 80) {
                return (fname + " matches " + lname + " " + percentage + "%, good match \n");

            } else {
                return (fname + " matches " + lname + " " + percentage + " % \n");

            }
        }

        static string produceSums(string occuranceString) {
            string myString = "";

            while (occuranceString.Length > 1) {
                int sum = 0;
                int left = (int) Char.GetNumericValue(occuranceString[0]);
                int right = (int) Char.GetNumericValue(occuranceString[occuranceString.Length - 1]);
                sum = left + right;
                myString = myString + "" + sum.ToString();
                occuranceString = occuranceString.Remove(0, 1);
                occuranceString = occuranceString.Remove((occuranceString.Length) - 1);


                if (occuranceString.Length == 1) {
                    myString = myString + "" + occuranceString;

                }
            }

            return myString;
        }

        static string produceMatches(string sumString) {
            if (sumString.Length == 2) {
                return sumString;
            } else {
                return produceMatches(produceSums(sumString));
            }

        }

    }
}