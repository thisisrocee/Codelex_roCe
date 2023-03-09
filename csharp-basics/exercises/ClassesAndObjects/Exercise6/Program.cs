using System;
using System.Runtime.CompilerServices;

namespace Exercise6
{
    class Dog
    {
        private string _name;
        private string _sex;
        private string _mother;
        private string _father;

        public Dog(string name, string sex)
        {
            _name = name;
            _sex = sex;
        }

        public void SetMother(string mother)
        {
            _mother = mother;
        }

        public void SetFather(string father)
        {
            _father = father;
        }

        public string FathersName()
        {
            if (_father == null)
                return "Unknown";
            return _father;
        }

        public bool HasSameMotherAs(Dog otherDog)
        {
            if(otherDog._mother == _mother) 
                return true;
            return false;
        }
    }
}