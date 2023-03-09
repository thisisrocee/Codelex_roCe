using System;
using System.Collections.Generic;

namespace PhoneBook
{
    public class PhoneDirectory
    {
        private SortedDictionary<string, PhoneEntry> _data;

        public PhoneDirectory() {
            _data = new SortedDictionary<string, PhoneEntry>();
        }

        public string GetNumber(string name) 
        {
            if (_data.TryGetValue(name, out var entry))
            {
                return entry.number;
            }
            return null;
        }

        public void PutNumber(string name, string number) 
        {
            if (name == null || number == null)
            {
                throw new Exception("name or number cannot be null");
            }
            _data[name] = new PhoneEntry { name = name, number = number };
        }
    }
}