﻿namespace Zoo
{
    public class Bear : Mammal
    {
        public Bear(string name)
            :base(name)
        {
            this.Name = name;
        }
        public string Name { get; protected set; }
    }
}