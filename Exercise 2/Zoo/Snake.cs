namespace Zoo
{
    public class Snake : Reptile
    {
        public Snake(string name)
            :base(name)
        {
            this.Name = name;
        }
        public string Name { get; protected set; }
    }
}