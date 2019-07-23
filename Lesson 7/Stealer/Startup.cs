namespace _01.Stealer
{
    using System;

    //No namespace in Judge
    public class Startup
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
