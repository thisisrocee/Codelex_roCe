using PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new PhoneDirectory();
            phonebook.PutNumber("Alice", "24634578");
            phonebook.PutNumber("Bob", "22453673");
            phonebook.PutNumber("Charlie", "27967456");

            Console.WriteLine(phonebook.GetNumber("Bob"));
            Console.WriteLine(phonebook.GetNumber("Charlie"));
            Console.WriteLine(phonebook.GetNumber("David"));
        }
    }
}
