namespace _03.MissionPrivateImpossible
{
    using System;

    //No namespace in Judge
    public class Startup
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}
