using System;
using System.Collections.Generic;
using System.Text;

namespace Asynchron
{
    class Person
    {
        public string Name { get; }
        public string Surname { get; }
        public int Age { get; }
        public string Profession{ get; }
        public Person(string name,string surname,int age,string profession)
        {
            if (name == string.Empty || name == null)
            {
                throw new ArgumentNullException("Name is empty!");
            }
            if (surname == string.Empty || surname == null)
            {
                throw new ArgumentNullException("Surname is empty!");
            }
            if (profession == string.Empty || profession == null)
            {
                throw new ArgumentNullException("Profession is empty!");
            }
            if (age <= 0)
            {
                throw new ArgumentNullException("Age is equal or less than zero!");
            }
            Name = name;
            Surname = surname;
            Age = age;
            Profession = profession;
        }
    }
}
