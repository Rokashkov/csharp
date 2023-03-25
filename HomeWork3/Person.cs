using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    enum Genders { Male, Female }
    internal class Person
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Genders Gender { get; set; }
        private uint age;
        public uint Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 100)
                {
                    Console.WriteLine("To old");
                }
                else
                {
                    age = value;
                }
            }
        }
        public virtual void IntroduceYourself()
        {
            Console.WriteLine($"Hi, my name is {FirstName} {SecondName}!");
        }
        public Person(string firstName, string secondName, uint age)
        {
            FirstName = firstName;
            SecondName = secondName;
            Age = age;
        }
    }
}
