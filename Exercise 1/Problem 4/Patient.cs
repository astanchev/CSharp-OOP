namespace P04_Hospital
{
    public class Patient
    {
        public string Name { get; private set; }

        public Patient(string name)
        {
            this.Name = name;
        }
    }
}