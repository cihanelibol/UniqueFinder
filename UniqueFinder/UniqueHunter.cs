using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace UniqueFinder
{
    public class UniqueHunter
    {

        public UniqueHunter()
        {
            string a = "";
            string b = "";

            while (true)
            {
                Console.Write("1 - Please paste as a path first .txt file location  : ");
                string firstText = Console.ReadLine().Replace("\"", "");

                if (CheckTextLocation(firstText))
                {
                    a = firstText;

                    break;
                }
                else
                {
                    Console.WriteLine("Please enter correct value...");
                    System.Threading.Thread.Sleep(1000);
                }
            }
            while (true)
            {
                Console.Write("2 - Please paste as a path second .txt file location  : ");
                string SecondText = Console.ReadLine().Replace("\"", "");

                if (CheckTextLocation(SecondText))
                {
                    b = SecondText;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter correct value...");
                    System.Threading.Thread.Sleep(1000);
                }
            }
            BeginProcess(a, b);
        }



        public void BeginProcess(string firstPath, string secondPath)
        {
            List<string> first = new List<string>();
            List<string> second = new List<string>();

            first = EditList(firstPath);
           
            second = EditList(secondPath);       

            Console.WriteLine("Comparison is currently in progress...!");
            ShowSimplePercentage();

            foreach (var item in CompareFirst(first, second))
            {
                Console.WriteLine("\t" + item);
            }
            Console.ReadLine();
        }

        public bool CheckTextLocation(string locationText)
        {
            if (File.Exists(locationText))
            {
                return true;
            }
            return false;
        }

        public List<string> CompareFirst(List<string> firstList, List<string> secondList)
        {
            List<string> returnValue = new List<string>();

            if (firstList.Count > secondList.Count)
            {
                Console.WriteLine("Entry 1 has more rows than entry 2");
                for (int i = 0; i < firstList.Count; i++)
                {
                    if (!secondList.Contains(firstList[i]))
                    {
                        returnValue.Add(firstList[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Entry 2 has more rows than entry 1");
                for (int i = 0; i < secondList.Count; i++)
                {
                    if (!firstList.Contains(secondList[i]))
                    {
                        returnValue.Add(secondList[i]);
                    }
                }
            }
            return returnValue;

        }
        public List<string> EditList(string textPath)
        {
            List<string> returnValue = new List<string>();
            string[] firstArray = System.IO.File.ReadAllLines(textPath);
            returnValue = TrimAddList(firstArray);
            return returnValue;
        }

        public List<string> TrimAddList(string[] a)
        {
            List<string> returnList = new List<string>();
            foreach (var item in a)
            {
                returnList.Add(item.Trim());
            }
            return returnList;
        }





        static void ShowSimplePercentage()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"\rProgress: {i}%   ");
                Thread.Sleep(25);
            }

            Console.WriteLine("\rDone!          ");
        }
    }


}
