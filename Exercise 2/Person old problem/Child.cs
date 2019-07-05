namespace Person
{
    using System;
    public class Child : Person
    {
        private const int MaxAge = 15;
        public Child(string name, int age)
            :base(name, age)
        {
            this.Age = age;
        }

        public override int Age
        {
            get => base.Age; 
            protected set
            {
                if (value > MaxAge)
                {
                    throw new ArgumentException($"Child's age must be less than {MaxAge}!");
                }

                base.Age = value;
            }
        }
    }
}