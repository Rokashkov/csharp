using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    enum Diseases
    {
        pneumonia,
        gastritis,
        arrhythmia,
        none
    }
    
    internal class Patient: Person, ITreat
    {
        public Diseases Disease { get; set; }
        public override void IntroduceYourself()
        {
            Console.WriteLine($"Hi, my name is {FirstName} {SecondName}! I { (Disease == Diseases.none ? "am well" : $"have a { Disease }") }.");
        }
        public Patient (string firstName, string secondName, uint age, Diseases disease)
            :base(firstName, secondName, age)
        {
            Disease = disease;
        }
    }
}
