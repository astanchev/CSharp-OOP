namespace _03.Fixing
{
    using System;

    class Fixing
    {
        static void Main(string[] args)
        {
            string[] weekDays = new string[5];
            weekDays[0] = "Sunday";
            weekDays[1] = "Monday";
            weekDays[2] = "Tuesday";
            weekDays[3] = "Wednesday";
            weekDays[4] = "Thursday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(weekDays[i].ToString());
                }
            }
            catch (IndexOutOfRangeException iore)
            {
                Console.WriteLine("Correct the values range!");
                
            }

            Console.ReadLine();
        }
    }
}
