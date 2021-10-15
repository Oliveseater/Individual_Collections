using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;

namespace ForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            /*
            Stack collekt = new Stack();

            char Backspace = '#';
            string str = Console.ReadLine();

            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == Backspace)
                {
                    str = str.Remove(i - 1, 2);
                    i = i - 2;
                }
            }
            Console.WriteLine(str);
            collekt.Push(str);
            */
            //2
            
            Queue line = new Queue();

            StreamReader sr = File.OpenText("tekst.txt");

            string strok = null;
            string letters = "уеыаоэяиюУЕЫАОЭЯИЮ";
            string lettersSogl = "ЙБВГДЖЗКЛМНПРСТФХЦЧШЩЪЬбвгджзйклмнпрстфхцчшщъь";
            string[] sort1 = new string[100];
            string[] sort2 = new string[100];

            while (!sr.EndOfStream)
            {
                strok = sr.ReadLine();
                string[] words = strok.Split(new char[] { ' ' });
                Console.WriteLine(strok);

                for (int i = 0; i < words.Length; i++)
                {
                    //поиск гласных
                    for (int j = 0; j < letters.Length; j++)
                    {
                        if (words[i].Substring(0, 1) == letters[j].ToString())
                        {
                            sort1[i] = words[i];
                        }
                    }
                    //поиск согласных
                    for (int z = 0; z < lettersSogl.Length; z++)
                    {
                        if (words[i].Substring(0, 1) == lettersSogl[z].ToString())
                        {
                            sort2[i] = words[i];
                        }
                    }
                    
                }
            }

            //сортировка гласных
            for(int a = 0; a < sort1.Length - 1; a++)
            {
                for(int b = a; b >= 0; b--)
                {
                    if(String.Compare(sort1[b], sort1[b+1]) > 0)
                    {
                        string s = sort1[b];
                        sort1[b] = sort1[b + 1];
                        sort1[b + 1] = s;
                    }
                }
            }
            
            //сортировка согласных
            for (int qa = 0; qa < sort2.Length - 1; qa++)
            {
                for (int qb = qa; qb >= 0; qb--)
                {
                    if (String.Compare(sort2[qb], sort2[qb + 1]) > 0)
                    {
                        string s = sort2[qb];
                        sort2[qb] = sort2[qb + 1];
                        sort2[qb + 1] = s;
                    }
                }
            }

            // вывод гласных
            for (int d = 0; d < sort1.Length; d++)
            {
                Console.Write(sort1[d]);
                line.Enqueue(sort1[d] + " ");
            }
                  
            // вывод согласных
            for (int qd = 0; qd < sort2.Length; qd++)
            {
                Console.Write(sort2[qd]);
                line.Enqueue(sort2[qd] + " ");
            }                 
               
            //Console.Write(line);
            sr.Close();
        }
    }
}
