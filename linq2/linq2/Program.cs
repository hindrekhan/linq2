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
            int count = (from word in data.Substring(0)
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
            Character[] characters = new Character[256];

            for (int i = 0; i < 256; i++)
            {
                characters[i].character = Convert.ToChar(i);
                characters[i].count = (from letter in data.ToList()
                                       where letter == Convert.ToChar(i)
                                       select letter).Count();
            }

            var a = characters.OrderByDescending(w => w.count).ToList();

            for (int i = 0; i < a.Count(); i++)
            {
                Console.WriteLine(a.ElementAt(i).character + ": " + a.ElementAt(i).count);
            }

            /*foreach(Character c in characters)
            {
                Console.WriteLine(c.character + ": " + c.count);
            }*/
        }

        //4
        static void PrintUniqueWords(string data)
        {
            var l = (from i in data.Split().Distinct()
                        select i);

            for (int i = 0; i < l.Count(); i++)
                Console.WriteLine(l.ElementAt(i));

        }

        static void Main(string[] args)
        {
            string data = System.IO.File.ReadAllText("../../tekst.txt");

            //1
            //PrintWordCount(data);

            //2
            //PrintDifferentLetters(data);

            //3
            PrintLetters(data);

            //4
           // PrintUniqueWords(data);

            Console.ReadLine();
        }
    }
}
