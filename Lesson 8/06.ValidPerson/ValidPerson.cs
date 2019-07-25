namespace _06.ValidPerson
{
    using System;

    class ValidPerson
    {
        static void Main(string[] args)
        {
            try
            {
                //Person pesho = new Person("Pesho","Peshev", 24);

                Person noName = new Person(String.Empty, "Goshev", 31);

                //Person boLastName = new Person("Ivan", String.Empty, 63);

                //Person negativeAge = new Person("Stoyan","Kolev", -1);

                //Person tooOldForThisProgram = new Person("Iskren","Ivanov", 121);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Exception thrown: {ane.Message}");
                ;
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine($"Exception thrown: {aore.Message}");
            }
        }
    }
}
