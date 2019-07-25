namespace _07.CustomException
{
    using System;

    class CustomException
    {
        static void Main(string[] args)
        {
            try
            {
                //Student student1 = new Student("Gin4o", "ar@gsbyte.com");

                //Student student2 = new Student("Gincho", "ar@gsbyte.com");
                
                Student student3 = new Student("G@ncho", "ar@gsbyte.com");

                Console.WriteLine(student3.Name);

            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine(ipne.Message);
            }

            Console.ReadLine();
        }
    }
}
