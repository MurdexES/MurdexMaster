using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Serl;

namespace DictionaryService
{
    internal class Dictionary : ISerialiazation
    {
        public Dictionary() { }
        public Dictionary(List<TranslationPair> TranslationPairs, string firstLanguageName, string lastLanguageName)
        {
            translationPairs = TranslationPairs;
            FirstLanguageName = firstLanguageName;
            LastLanguageName = lastLanguageName;
        }

        public void CreateDictionary()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--Create Dictionary--");

            Console.WriteLine("Enter First language original one: ");
            FirstLanguageName = Console.ReadLine();

            Console.WriteLine("Enter Last language on which you want to translate: ");
            LastLanguageName = Console.ReadLine();
        }

        public void PrintDictionary()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--All Translations--");

            Console.WriteLine($"{FirstLanguageName.ToUpper()} -- {LastLanguageName.ToUpper()}");

            for (int i = 0; i < translationPairs.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}");
                translationPairs[i].PrintTranslationPair();
            }
        }

        public void RemoveWord()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int indx = new();

            PrintDictionary();

            Console.WriteLine("Enter index of word to remove: ");

            indx = int.Parse(Console.ReadLine());

            translationPairs.RemoveAt(indx);
        }

        public void AddWord()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int indx = new();
            TranslationPair tmp = new();

            tmp = tmp.CreateTraslationPair();

            translationPairs.Add(tmp);
        }

        public void ChangeWord()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int indx = new();
            string tmp_copy;
            StringBuilder new_word;

            Console.WriteLine("Changes can be applied only on language on which you translate so you can write words only on this language: \n" +
                "Enter index of word you want to change: ");
            indx = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new word to translation: ");
            
            tmp_copy = Console.ReadLine();
            new_word = new StringBuilder(tmp_copy);

            translationPairs[indx].LastLanguageTranslation.Append(new_word);
        }

        public void EditDictionary()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int choice = new();

            Console.WriteLine("\t\t--Edititng Menu--\n" +
                "1 - Add word\n" +
                "2 - Change word\n" +
                "3 - Remove word\n" +
                "4 - Exit\n" +
                "Enter your choice: "
                );
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddWord();
                    break;
                case 2:
                    ChangeWord();
                    break;
                case 3: 
                    RemoveWord();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Error");
                    break;
            }

        }

        public void FindWord()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            StringBuilder tmp = new();
            string tmp_copy;
            bool key = true;
            int i = 0;

            Console.WriteLine($"Enter word on {FirstLanguageName.ToUpper()} to find its translation: ");

            tmp_copy = Console.ReadLine();
            tmp = new StringBuilder(tmp_copy);

            while (key)
            {
                if (translationPairs[i].FirstLanguageTranslation == tmp)
                {
                    translationPairs[i].PrintTranslationPair();
                    key = false;
                }
                i++;
            }
        }

        public void SaveToFile()
        {
            Serializator service = new();

            var json = service.Serialize(this);

            using FileStream fs = new("dictionary_data.json", FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            sw.Write(json);
        }

        public List<TranslationPair> translationPairs { get; set; } 
        public string FirstLanguageName { get; set; }
        public string LastLanguageName { get; set; }
    }

    class TranslationPair : ISerialiazation
    {
        public TranslationPair () { }

        public TranslationPair(StringBuilder firstLanguageTranslation, StringBuilder[] lastLanguageTranslation)
        {
            FirstLanguageTranslation = firstLanguageTranslation;
            LastLanguageTranslation = lastLanguageTranslation;
        }

        public StringBuilder[] CreateTranslation()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--Create Translation--");
            Console.WriteLine("Enter number of words: ");

            int numb = Int32.Parse(Console.ReadLine());
            string tmp_copy;

            StringBuilder[] tmp = new StringBuilder[numb];

            for (int i = 0; i < numb; i++)
            {
                Console.WriteLine("Enter word : ");
                
                tmp_copy = Console.ReadLine();
                tmp[i] = new StringBuilder(tmp_copy);
            }

            return tmp;
        }

        public TranslationPair CreateTraslationPair()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string tmp_copy;

            Console.WriteLine("--Creating Translation Pair--");

            Console.WriteLine("Enter original word: ");
            tmp_copy = Console.ReadLine();

            StringBuilder tmpFirstLanguage = new StringBuilder(tmp_copy);
            StringBuilder[] tmpLastLanguage = CreateTranslation();

            TranslationPair tmp = new TranslationPair(tmpFirstLanguage, tmpLastLanguage);

            return tmp;
        }
  
        public void PrintTranslationPair()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Original Language: ");

            for (int i = 0; i < FirstLanguageTranslation.Length; i++)
            {
                Console.WriteLine(FirstLanguageTranslation[i] + " ");
            }

            Console.WriteLine("Translated Language: ");

            for (int i = 0; i < LastLanguageTranslation.Length; i++)
            {
                Console.WriteLine(LastLanguageTranslation[i] + " ");
            }
        }

        public void SaveWord()
        {
            Serializator service = new();

            var json = service.Serialize(this);

            using FileStream fs = new("res_file.json", FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            sw.Write(json);
        }

        public StringBuilder FirstLanguageTranslation { get => FirstLanguageTranslation; set => FirstLanguageTranslation = value; }
        public StringBuilder[] LastLanguageTranslation { get => LastLanguageTranslation; set => LastLanguageTranslation = value; }
    }
}
