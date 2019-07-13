namespace FoodShortage.Models
{
    using Interfaces;

    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}