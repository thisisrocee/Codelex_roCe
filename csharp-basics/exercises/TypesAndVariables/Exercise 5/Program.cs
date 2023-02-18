using System;

namespace Exercise5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] subjects = { "English III", "Precalculus", "Music Theory", "Biotechnology", "Principles of Technology I", "Latin II", "AP US History", "Business Computer Information Systems" };
            string[] teachers = { "Ms. Lapan", "Mrs. Gideon", "Mr. Davis", "Ms. Palmer", "Ms. Garcia", "Mrs. Barnett", "Ms. Johannessen", "Mr. James" };

            Console.WriteLine("+------------------------------------------------------------+");
            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine($"| {i + 1} | {subjects[i],-37} | {teachers[i],-15} |");
            }
            Console.WriteLine("+------------------------------------------------------------+");
        }
    }
}