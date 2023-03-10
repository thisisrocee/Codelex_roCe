using System;

namespace Hierarchy
{
    public class Student : Person
    {
        private double _gpa;

        public Student(string firstName, string lastName, string address, int id, double gpa) : base(firstName, lastName, address, id)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Id = id;
            _gpa = gpa;
        }

        public override void Display()
        {
            Console.WriteLine($"Person: {FirstName}, {LastName}, Address = {Address}, Id = {Id}");
            Console.WriteLine($"{FirstName}'s GPA score: {_gpa}");
        }
    }
}