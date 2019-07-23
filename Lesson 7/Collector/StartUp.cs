namespace _04.Collector
{
    using System;

    //No namespace in Judge
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}
