using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Password_Cracker
{
    internal class Program
    {


        static char[] combo =            {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j' ,'k','l','m','n','o','p',
                        'q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','C','L','M','N','O','P',
                        'Q','R','S','T','U','V','X','Y','Z','!','?',' ','*','-','+'};
        //your password
        static string FindPassword;
        static int combinati;
        static string space;
        static int Characters;

        static void Main(string[] args)
        {
            Console.Title = "Password Cracker";


            space = " ";
            int Count;
            Console.WriteLine("Enter your Password:");

            //initialize password
            FindPassword = (Console.ReadLine());
            Characters = FindPassword.Length;
            Console.Clear();

            DateTime today = DateTime.Now;
            today.ToString("yyyy-MM-dd_HH:mm:ss");
            Console.WriteLine(space);
            Console.WriteLine("START:\t{0}", today);

            for (Count = 0; Count <= 8; Count++)
            {
                Recurse(Count, 0, "");
            }
        }

        static string Sha256(string FindPassword) //Hash the Password
        {

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] password = Encoding.UTF8.GetBytes(FindPassword);
                byte[] hash = sha256.ComputeHash(password);


                StringBuilder stringHash = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    stringHash.Append(hash[i].ToString("x2"));
                }

                return stringHash.ToString();
            }

        }




        static void Recurse(int Length, int Position, string Base)
        {
            int Count = 0;

            for (Count = 0; Count < combo.Length; Count++)
            {
                combinati++;
                if (Position < Length - 1)
                {
                    Recurse(Length, Position + 1, Base + combo[Count]);
                }
                if (Base + combo[Count] == FindPassword)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Your password is: " + FindPassword);
                    Console.WriteLine("Your password is: " + Characters + " character ");
                    Console.ForegroundColor = ConsoleColor.White;
                    DateTime today = DateTime.Now;
                    today.ToString("yyyy-MM-dd_HH:mm:ss");
                    Console.WriteLine(space);
                    Console.WriteLine("END:\t{0}\nCombi:\t{1}", today, combinati);
                    Console.ReadLine();
                    Environment.Exit(0); // 


                }
            
            
            
           
            }
            
            
            
            
            }
        }
    }
