namespace HomeWork3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var patient = new Patient("Carl", "Jhonson", 25, Diseases.gastritis);
            Console.WriteLine(patient.Age);

            var doctor = new Doctor("Solid", "Snake", 35, Specialties.gastroenterologist);
            doctor.IntroduceYourself();

            doctor.Treat(patient);
            patient.IntroduceYourself();

            patient.Disease = Diseases.pneumonia;
            patient.IntroduceYourself();

            doctor.Treat(patient);

            var person = new Person("Spongebob", "Squarepants", 14);
            person.IntroduceYourself();
            //doctor.Treat(person); <-- не удается преобразовать Person в ITreat
        }
    }
}