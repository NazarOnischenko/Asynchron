using System;
using System.Collections.Generic;
using System.Text;

namespace Asynchron
{
    class Passport
    {
        public string Name { get; }
        public string Surname { get; }
        public int Age { get; }
        public string Profession { get; }
        public Passport(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Age = person.Age;
            Profession = person.Profession;
        }
    }
}
