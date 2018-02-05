using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myNumbers = new int[5] {1, 2, 3, 4, 5};
            // myNumbers[5] = 6;
            // for (int i = 0; i < myNumbers.Length; i++)
            // {
            //     myNumbers[i] *= 2;
            // }
            // foreach (var item in myNumbers)
            // {
            //     // item *= 2;
            //     // item is read-only
            //     // System.Console.WriteLine(item * 2);
            //     System.Console.WriteLine(item);
            // }
            ArrayList myArrayList = new ArrayList(); // không sử dụng
            // System.Object
            myArrayList.Add(0);
            myArrayList.Add(1);
            myArrayList.Add("Hello");
            // foreach (var item in myArrayList)
            // {
            //     System.Console.WriteLine(item);
            // }
            // // System.Console.WriteLine(myArrayList.Count);
            // for (int i = 0; i < myArrayList.Count; i++)
            // {
            //     myArrayList[i] *= 2;
            // }
            // data type safety
            List<int> myList = new List<int>() {10, 8, 0, 7};
            myList.Add(0);
            myList.Add(1);
            myList.Remove(0);
            // foreach (var item in myList)
            // {
            //     System.Console.WriteLine(item);
            // }
            Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            myDictionary.Add(1, "Anna");
            myDictionary.Add(2, "James");
            // System.Console.WriteLine(myDictionary[2]);
            // foreach (var item in myDictionary.Keys)
            // {
            //     System.Console.WriteLine(item);
            // }
            // foreach (var item in myDictionary.Values)
            // {
            //     System.Console.WriteLine(item);
            // }
            // ===== STACK - last in first out =====
            Stack<int> myStack = new Stack<int>();
            myStack.Push(0);
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Pop();
            // System.Console.WriteLine(myStack.Peek());
            // ===== QUEUE - first in first out =====
            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(0);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Dequeue();
            // System.Console.WriteLine(myQueue.Peek());

            // ===== LINQ =====
            var grades = new List<double>() {10, 9.5, 10, 4.5, 7, 6.75, 5.25, 8.75};
            // using LINQ query
            var belowFive = (from num in grades where num < 5 select num).ToList();
            foreach (var item in belowFive)
            {
                System.Console.WriteLine(item);
            }
            var sortedGrades = from num in grades orderby num select num;
            foreach (var item in sortedGrades)
            {
                System.Console.WriteLine(item);
            }
            var belowPoint = from item in grades let point = 7 where item < 7 select item;
            System.Console.WriteLine("==========");
            foreach (var item in belowPoint)
            {
                System.Console.WriteLine(item);
            }
            // using LINQ Methods
            var belowSix = grades.Where(num => num < 6);
            var descGradges = grades.OrderByDescending(num => num);
            var get3Grades = grades.Take(3);
            var total = grades.Sum();
            var avge = grades.Average();
            var belowAvg = from item in grades let avg = grades.Average() where item < avg select item;
            System.Console.WriteLine("=======");
            System.Console.WriteLine(avge);
            foreach (var item in belowAvg)
            {
                System.Console.WriteLine(item);
            }
        }
    }


}
