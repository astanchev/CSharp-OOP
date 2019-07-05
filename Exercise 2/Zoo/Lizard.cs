namespace Zoo
{
    public class Lizard : Reptile
    {
        public Lizard(string name)
            :base(name)
        {
            this.Name = name;
        }
        public string Name { get; protected set; }
    }
}