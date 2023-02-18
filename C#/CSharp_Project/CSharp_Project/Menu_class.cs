using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionaryService;

namespace MenuService
{
    internal static class Menu
    {
        static Menu() { }

        public static void StartMenu()
        {
            Console.Clear();


            int choice = 0;
            int tmpIndx = 0;
            Dictionary MainDictionary = new();


            Console.WriteLine("~--Menu--~\n" +
                "1 - Create Dictionary\n" +
                "2 - Edit Dictionary\n" +
                "3 - Show Dictionary\n" +
                "4 - Search The Word\n" +
                "5 - Save To File Dictionary\n" +
                "6 - Save To File Word\n" +
                "7 - Exit Program\n" +
                "Press on number: \n"
                );
            ConsoleKeyInfo UserInput = Console.ReadKey();


            if (char.IsDigit(UserInput.KeyChar))
            {
                choice = Int32.Parse(UserInput.KeyChar.ToString());
            }
            else
            {
                Console.WriteLine("Wrong Key!!!");
                Menu.StartMenu();
            }


            switch (choice)
            {
                case 1:
                    MainDictionary.CreateDictionary();
                    Menu.StartMenu();
                    break;
                
                case 2:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("You cannot edit empty dictionary!!\n You have to create it first!");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    break;
                
                case 3:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("Cannot Print null dictionary!!\n You have to create it first!");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        Console.WriteLine("Cannot Print empty dictionary!!\n You have to add translations to it!");
                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.PrintDictionary();
                        Menu.StartMenu();
                    }
                    break;
                
                case 4:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("Cannot Find translation in null dictionary!!\n You have to create it first!");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        Console.WriteLine("Cannot Find word in empty dictionary!!\n You have to add translations to it!");
                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.FindWord();
                        Menu.StartMenu();
                    }
                    break;
                
                case 5:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("Cannot Save null dictionary!!\n You have to create it first!");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        Console.WriteLine("Cannot Save empty dictionary!!\n You have to add translations to it!");
                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        MainDictionary.SaveToFile();
                        Menu.StartMenu();
                    }
                    break;
                
                case 6:
                    if (MainDictionary == null)
                    {
                        Console.WriteLine("Cannot Save word from null dictionary!!\n You have to create it first!");
                        MainDictionary.CreateDictionary();
                        Menu.StartMenu();
                    }
                    else if (MainDictionary.translationPairs.Count != 0)
                    {
                        Console.WriteLine("Cannot Save word from empty dictionary!!\n You have to add translations to it!");
                        MainDictionary.EditDictionary();
                        Menu.StartMenu();
                    }
                    else
                    {
                        Console.WriteLine("Enter index of word you want to Save: ");
                        tmpIndx = int.Parse(Console.ReadLine());

                        MainDictionary.translationPairs[tmpIndx - 1].SaveWord();
                        Menu.StartMenu();
                    }
                    break;
                case 7:
                    Console.WriteLine("Leaving...");
                    return;
                default:
                    Console.WriteLine("ERROR!!");
                    Menu.StartMenu();
                    break;
            }
        }
    }
}


