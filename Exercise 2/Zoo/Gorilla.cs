﻿namespace Zoo
{
    public class Gorilla : Mammal
    {
        public Gorilla(string name)
            :base(name)
        {
            this.Name = name;
        }
        public string Name { get; protected set; }
    }
}