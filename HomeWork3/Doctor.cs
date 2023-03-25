using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    enum Specialties
    {
        therapist,
        cardiologist,
        pulmonologist,
        gastroenterologist
    }
    internal class Doctor: Person
    {
        public Specialties Speciality { get; set; }
        private Dictionary<Specialties, List<Diseases>> competencies = new Dictionary<Specialties, List<Diseases>>()
        {
            { Specialties.therapist, new List<Diseases> { Diseases.arrhythmia, Diseases.gastritis, Diseases.pneumonia } },
            { Specialties.cardiologist, new List<Diseases> { Diseases.arrhythmia } },
            { Specialties.pulmonologist, new List<Diseases> { Diseases.pneumonia } },
            { Specialties.gastroenterologist, new List<Diseases> { Diseases.gastritis } }
        };
        public void Treat(ITreat target)
        {
            if (target.Disease == Diseases.none)
            {
                return;
            };
            var diseases = competencies[Speciality];
            if (diseases.Contains(target.Disease))
            {
                Random random = new Random();
                if (random.NextDouble() > 0.5)
                {
                    target.Disease = Diseases.none;
                    Console.WriteLine("Successfull treatment!");
                }
                else
                {
                    Console.WriteLine("Failed treatment!");
                }
            }
            else
            {
                Console.WriteLine("Not enough competencies!");
            }
        }
        public override void IntroduceYourself()
        {
            Console.WriteLine($"Hi, my name is Dr {FirstName} {SecondName}! I am a {Speciality}.");
        }
        public Doctor ( string firstName, string secondName, uint age, Specialties speciality)
            :base ( firstName, secondName, age)
        {
            Speciality = speciality;
        }
    }
}
