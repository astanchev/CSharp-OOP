namespace _09.CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;

    public class AddCollection : IAddable
    {
        protected List<string> repository;

        public AddCollection()
        {
            repository = new List<string>();
        }
        
        public int Add(string item)
        {
            int endIndex = repository.Count;

            this.repository.Add(item);

            return endIndex;
        }
    }
}