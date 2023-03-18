using System;

namespace Hierarchy
{
    public class Employee : Person
    {
        private string _jobTitle;

        public Employee(string firstName, string lastName, string address, int id, string jobTitle) : base(firstName, lastName, address, id)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Id = id;
            _jobTitle = jobTitle;
        }

        public override void Display()
        {
            Console.WriteLine($"Person: {FirstName}, {LastName}, Address = {Address}, Id = {Id}");
            Console.WriteLine($"{FirstName}'s work: {_jobTitle}");
        }
    }
}