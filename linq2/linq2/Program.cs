using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq2
{
    class Program
    {
        struct Character
        {
            public char character;
            public int count;
        };

        //1
        static void PrintWordCount(string data)
        {
            int count = (from word in data.Split()
                         select word).Count();

            Console.WriteLine("Number of words: " + count);
        }

        //2
        static void PrintDifferentLetters(string data)
        {
            int count = (from letter in data.ToList().Distinct()
                         where letter != ' '
                         select letter).Count();

            Console.WriteLine("Number different letters: " + count);
        }

        //3
        static void PrintLetters(string data)
        {
            Console.WriteLine("Word frequency:");

            Character[] characters = new Character[94];

            for (int i = 33; i < 126; i++)
            {
                characters[i - 33].character = Convert.ToChar(i);
                characters[i - 33].count = (from letter in data.ToList()
                                       where Char.ToUpper(letter) == Convert.ToChar(i)
                                       select letter).Count();
            }

            var a = characters.OrderByDescending(w => w.count).ToList();

            for (int i = 0; i < a.Count(); i++)
            {
                Console.WriteLine("'" +a.ElementAt(i).character + "': " + a.ElementAt(i).count);
            }

        }

        //4
        static void PrintUniqueWords(string data)
        {
            var l = (from i in data.Split().Distinct()
                        select i);

            for (int i = 0; i < l.Count(); i++)
                Console.WriteLine(l.ElementAt(i));
        }

        static void Pause()
        {
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            string data = System.IO.File.ReadAllText("../../tekst.txt");

            //1
            PrintWordCount(data);
            Pause();

            //2
            PrintDifferentLetters(data);
            Pause();

            //3
            PrintLetters(data);
            Pause();

            //4
            PrintUniqueWords(data);

            Console.ReadLine();
        }
    }
}
