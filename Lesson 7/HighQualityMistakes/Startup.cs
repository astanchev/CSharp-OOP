namespace _02.HighQualityMistakes
{
    using System;

    //No namespace in Judge
    public class Startup
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
