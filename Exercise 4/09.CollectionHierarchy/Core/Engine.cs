namespace _09.CollectionHierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    public class Engine
    {
        private AddCollection addCollection;
        private AddRemoveCollection addRemoveCollection;
        private MyList myList;
        public Engine()
        {
            addCollection = new AddCollection();
            addRemoveCollection = new AddRemoveCollection();
            myList = new MyList();
        }

        public void Run()
        {
            List<string> input = Console.ReadLine().Split().ToList();

            int numberRemoveOperations = int.Parse(Console.ReadLine());

            PrintAdd(input);

            PrintRemove(numberRemoveOperations);
        }

        private void PrintRemove(int numberRemoveOperations)
        {
            List<string> resultRemoveAddRemoveCollection = RemoveInAddRemoveCollection(numberRemoveOperations);
            Console.WriteLine(string.Join(" ", resultRemoveAddRemoveCollection));

            List<string> resultRemoveMyList = RemoveInMyList(numberRemoveOperations);
            Console.WriteLine(string.Join(" ", resultRemoveMyList));
        }

        private void PrintAdd(List<string> input)
        {
            List<int> resultAddCollection = AddInAddCollection(input);
            Console.WriteLine(string.Join(" ", resultAddCollection));

            List<int> resultAddAddRemoveCollection = AddInAddRemoveCollection(input);
            Console.WriteLine(string.Join(" ", resultAddAddRemoveCollection));

            List<int> resultAddMyList = AddInMyList(input);
            Console.WriteLine(string.Join(" ", resultAddMyList));
        }

        private List<string> RemoveInMyList(int numberRemoveOperations)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < numberRemoveOperations; i++)
            {
                result.Add(myList.Remove());
            }

            return result;
        }

        private List<int> AddInMyList(List<string> input)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                result.Add(myList.Add(input[i]));
            }

            return result;
        }


        private List<string> RemoveInAddRemoveCollection(int numberRemoveOperations)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < numberRemoveOperations; i++)
            {
                result.Add(addRemoveCollection.Remove());
            }

            return result;
        }

        private List<int> AddInAddRemoveCollection(List<string> input)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                result.Add(addRemoveCollection.Add(input[i]));
            }

            return result;
        }
        
        private List<int> AddInAddCollection(List<string> input)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                result.Add(addCollection.Add(input[i]));
            }

            return result;
        }

    }
}