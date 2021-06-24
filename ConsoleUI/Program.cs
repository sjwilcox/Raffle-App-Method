using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    
    
    class Program
    {
        
        static void Main(string[] args)
        {

            List<string> guestList = GetUserInfo();
            MultiLineAnimation();
            foreach (string guest in guestList)
            {
                GenerateRandomNumber(min, max);
                AddGuestsRaffle(raffleNumber, guest);
            }

            PrintWinner();

            Console.ReadLine();

        }

        //Start writing your code here
        private static Dictionary<int, string> raffleDict = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random _rdm = new Random();

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string guest = Console.ReadLine();
            return guest;
        }

        
        public static List<string> GetUserInfo()
        {
            List<string> guests = new List<string>();
            string otherGuest;
            do
            {
                string name = GetUserInput("Please enter a name: ");
                guests.Add(name);
                otherGuest = GetUserInput("Do you want to add another name? ");
                

            } while (otherGuest == "yes");
            return guests;
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            
            raffleNumber = _rdm.Next(min, max);
            return raffleNumber;
        }

        public static string AddGuestsRaffle(int raffleNumber, string guest) 
        {
            
            raffleDict.Add(raffleNumber, guest);
            return null;
        }
        public static void PrintGuestName()
        {
            foreach (KeyValuePair<int, string> rafName in raffleDict)
            {
                Console.WriteLine($"{rafName.Value} {rafName.Key}");
            }
        }

        private static int GetRaffleNumber(Dictionary<int, string> people)
        {
            int index = _rdm.Next(people.Count);
            KeyValuePair<int, string> pair = people.ElementAt(index);
            int winner = pair.Key;
            return winner;
        }

        public static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(raffleDict);
            Console.WriteLine($"the winner is {raffleDict[winnerNumber]} with the #{winnerNumber}");
        }



        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
