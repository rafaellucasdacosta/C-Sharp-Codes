using System;
using System.Collections.Generic;

namespace CountStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> courseA = new HashSet<int>();
            HashSet<int> courseB = new HashSet<int>();
            HashSet<int> courseC = new HashSet<int>();

            Console.Write("How many students for course A? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                courseA.Add(int.Parse(Console.ReadLine()));
            }

            Console.Write("How many students for course B? ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                courseB.Add(int.Parse(Console.ReadLine()));
            }

            Console.Write("How many students for course C? ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                courseC.Add(int.Parse(Console.ReadLine()));
            }
            HashSet<int> all = new HashSet<int>(courseA);
            all.UnionWith(courseB);
            all.UnionWith(courseC);
            Console.WriteLine("Total students: " + all.Count);

        }
    }
}
