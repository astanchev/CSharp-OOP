using _09.CollectionHierarchy.Contracts;

namespace _09.CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IAddRemovable
    {
        public int Add(string item)
        {
            base.repository.Insert(0, item);

            int index = base.repository.IndexOf(item);

            return index;
        }

        public string Remove()
        {
            string item = base.repository[base.repository.Count - 1];
            base.repository.RemoveAt(base.repository.Count - 1);

            return item;
        }
    }
}