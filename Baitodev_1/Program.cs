using System;
using System.Collections.Generic;
using System.IO;

namespace Baitodev_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] TxtData = new String[0];
            String TxtWordDirectory = Directory.GetCurrentDirectory() + ("\\WordGame.txt");
            if (File.Exists(TxtWordDirectory))
            {
                TxtData = File.ReadAllLines(TxtWordDirectory);
            }
            else
            {
                TxtData = new String[] { "soda", "ice", "cat","coat","dog" };
                File.WriteAllLines(TxtWordDirectory, TxtData);
            }

            Boolean ContinueGame = true;
            while (ContinueGame)
            {
                Random NRandom = new Random();
                int TxtL = NRandom.Next(TxtData.Length - 1);
                Char[] WordGame = TxtData[TxtL].ToCharArray();
                Char[] IncompletW = new Char[WordGame.Length];
                for (int i = 0; i < WordGame.Length; i++)
                {
                    IncompletW[i] = '_';
                }
                Boolean Win = true;
                while (Win)
                {
                    Console.WriteLine("Write:        end game writing:exit");
                    Console.WriteLine(new String(IncompletW));
                    String UserWorld = Console.ReadLine();

                    if (UserWorld.Equals("exit"))
                    {
                        ContinueGame = false;
                        break;
                    }
                    else
                    {
                        if (UserWorld.Length > 1)
                        {
                            if (UserWorld.Equals(new String(WordGame)))
                            {
                                Console.WriteLine("Correct!!, you Win!");
                                Win = false;
                            }
                            else
                            {
                                Console.WriteLine("Sorry!!, try again");
                            }

                        }
                        else
                        {
                            for (int i = 0; i < WordGame.Length; i++)
                            {
                                if (WordGame[i].ToString().Equals(UserWorld))
                                {
                                    IncompletW[i] = WordGame[i];
                                }
                            }
                        }

                        if (new String(IncompletW).Equals(new String(WordGame)))
                        {
                            Console.WriteLine("Correct!!, you Win!");
                            Win = false;
                        }

                    }

                }


            }
        }
    }
}
