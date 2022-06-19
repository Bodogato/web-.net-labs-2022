using MyDictionary.Models;
using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new OwnDictionary<string, string>();
            dict.Add("name", "Ben");
            dict.Add("age", "40");
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            dict.Remove("name");
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}
