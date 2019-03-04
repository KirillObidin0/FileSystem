using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        public struct WhatFor
        {

        }
        static void Main(string[] args)
        {
            Console.Write("Введите откуда: ");
            string PathFrom = Console.ReadLine();
            Console.Write("Введите куда: ");
            string PathTo = Console.ReadLine();

            DirectoryInfo DirPathFrom = new DirectoryInfo(PathFrom);
            DirectoryInfo DirPathTo = new DirectoryInfo(PathTo);

            if (!DirPathFrom.Exists||!DirPathTo.Exists)
            {
                throw new Exception("Wrong path");
            }

            Dictionary<string, bool> ExtentionList = new Dictionary<string, bool>();
            Dictionary<string, bool> ExtentionListCh = new Dictionary<string, bool>();
            foreach (FileInfo item in DirPathFrom.GetFiles())
            {
                if (!ExtentionList.ContainsKey(item.Extension))
                    ExtentionList.Add(item.Extension, false);
            }
            foreach (var item in ExtentionList)
            {
                Console.WriteLine("Does {0} fits you?",item.Key);
                if (Console.ReadLine()=="yes")
                {
                    ExtentionListCh.Add(item.Key, true);
                }
            }
            foreach (var ext in ExtentionListCh)
            {
                Console.WriteLine("-------------{0}-------------",ext.Key);
                foreach (FileInfo file in DirPathFrom.GetFiles("*"+ext.Key))
                {
                    Console.WriteLine("--> {0}",file.FullName);
                }
                Console.WriteLine("Total: {0} files", DirPathFrom.GetFiles("*" + ext.Key).Length);
            }
            List<char> list = new List<char>();
            foreach (var ext in ExtentionListCh)
            {
                foreach (var file in DirPathFrom.GetFiles("*"+ext.Key))
                {
                    list.AddRange(FindNonLetters(file.Name.Substring(0, file.Name.LastIndexOf('.'))));
                }
            }
            list = list.Distinct().ToList();

            foreach (var item in collection)
            {

            }
        }
        public static List<char> FindNonLetters(string FileName)
        {
            List<char> nonLetters = new List<char>();
            foreach (var item in FileName)
            {
                if (item >= 33 && item <= 47)
                    nonLetters.Add(item);
            }
            return nonLetters;
        }
    }
}
