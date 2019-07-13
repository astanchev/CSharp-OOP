using _09.CollectionHierarchy.Contracts;

namespace _09.CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IUsed
    {
        public string Remove()
        {
            string item = base.repository[0];
            base.repository.RemoveAt(0);

            return item;
        }

        public int Used => base.repository.Count;
    }
}