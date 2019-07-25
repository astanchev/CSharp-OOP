namespace _07.CustomException
{
    using System.Linq;

    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (value.Any(char.IsNumber) || value.Any(char.IsPunctuation) || value.Any(char.IsSymbol))
                {
                    throw new InvalidPersonNameException();
                }

                this.name = value;
            }
        }

        public string Email
        {
            get => this.email;
            set => this.email = value;
        }
    }
}