namespace _04.Telephony.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using SmartphoneExceptions;

    public class Engine
    {
        private List<string> phoneNumbers; 
        private List<string> urls;
        private Smartphone smartphone;
        public Engine()
        {
            this.phoneNumbers = new List<string>();
            this.urls = new List<string>();
            this.smartphone = new Smartphone();
        }

        public void Run()
        {
            phoneNumbers = ReadInput();
            urls = ReadInput();

            CallPhones();

            BrowseURLs();
        }

        private void BrowseURLs()
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidURLException iue)
                {
                    Console.WriteLine(iue.Message);
                }
            }
        }

        private void CallPhones()
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(smartphone.Call(phoneNumber));
                }
                catch (InvalidPhoneException ipe)
                {
                    Console.WriteLine(ipe.Message);
                }
            }
        }

        private static List<string> ReadInput()
        {
            return Console.ReadLine().Split().ToList();
        }
    }
}