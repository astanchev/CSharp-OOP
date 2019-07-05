namespace Zoo
{
    public class Reptile : Animal
    {
        public Reptile(string name)
         :base(name)
        {
            this.Name = name;
        }
        public string Name { get; protected set; }

    }
}