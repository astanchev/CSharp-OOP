﻿namespace P03_StudentSystem.Data
{
    using System;

    public class ConsoleDataReader : IDataReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}