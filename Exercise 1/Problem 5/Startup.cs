namespace P05_GreedyTimes
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            Bag bag = new Bag(bagCapacity);


            string[] itemsInput = ItemsInput();

            for (int i = 0; i < itemsInput.Length; i += 2)
            {
                string currentItem = itemsInput[i];
                long currentItemValue = long.Parse(itemsInput[i + 1]);

                if (currentItem.Length < 3)
                {
                    continue;
                }

                if (bag.Capacity < bag.CurrentCapacity + currentItemValue)
                {
                    continue;
                }
                
                string itemType;

                if (currentItem.Length == 3)
                {
                    itemType = "Cash";
                }
                else if (currentItem.ToLower().EndsWith("gem"))
                {
                    itemType = "Gem";
                }
                else if (currentItem.ToLower() == "gold")
                {
                    itemType = "Gold";
                }
                else
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":
                        bag.AddGem(currentItem, currentItemValue);
                        break;
                    case "Cash":
                        bag.AddCurrency(currentItem, currentItemValue);
                        break;
                    case "Gold":
                        bag.AddGold(currentItemValue);
                        break;
                }
            }

            bag.Print();
        }


        private static string[] ItemsInput()
        {
            return Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
        }
    }
}