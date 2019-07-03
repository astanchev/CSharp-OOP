namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Bag
    {
        public Bag(long capacity)
        {
            this.Currencies = new List<Cash>();
            this.Gems = new List<Gem>();
            this.Capacity = capacity;
        }

        public List<Cash> Currencies { get; set; }

        public List<Gem> Gems { get; set; }

        public Gold Gold { get; set; }

        public long Capacity { get; private set; }

        public long CurrentCapacity
        {
            get
            {
                long cashAmount = this.Currencies.Sum(c => this.Currencies.Count > 0 ? c.Amount : 0);
                long gemAmount = this.Gems.Sum(g => this.Gems.Count > 0 ? g.Amount : 0);
                long goldAmount = this.Gold != null ? this.Gold.Amount : 0;

                return cashAmount + gemAmount + goldAmount;
            }
        }

        public void AddCurrency(string currencyName, long amount)
        {
            Cash currency = new Cash(currencyName);

            if (this.Currencies.Sum(c => c.Amount) + amount
                <= this.Gems.Sum(g => g.Amount))
            {
                if (this.Currencies.Any(c => c.Name == currencyName))
                {
                    this.Currencies.FirstOrDefault(c => c.Name == currencyName).Amount += amount;
                }
                else
                {
                    currency.Amount = amount;
                    this.Currencies.Add(currency);
                }
            }
        }

        public void AddGem(string gemName, long amount)
        {
            Gem gem = new Gem(gemName);

            if (this.Gems.Sum(g => g.Amount) + amount
                <= this.Gold.Amount)
            {
                if (this.Gems.Any(g => g.Name == gemName))
                {
                    this.Gems.FirstOrDefault(g => g.Name == gemName).Amount += amount;
                }
                else
                {
                    gem.Amount = amount;
                    this.Gems.Add(gem);
                }
            }
        }

        public void AddGold(long goldAmount)
        {
            if (this.Gold == null)
            {
                Gold gold = new Gold();
                this.Gold = gold;
            }
            
            this.Gold.Amount += goldAmount;
        }

        public void Print()
        {
            Dictionary<string, long> itemValue = new Dictionary<string, long>();

            if (this.Gold != null)
            {
                itemValue["Gold"] = this.Gold.Amount;
            }

            if (this.Gems.Count > 0)
            {
                itemValue["Gem"] = this.Gems.Sum(g => g.Amount);
            }

            if (this.Currencies.Count > 0)
            {
                itemValue["Cash"] = this.Currencies.Sum(c => c.Amount);
            }
            

            foreach (var item in itemValue.OrderByDescending(i => i.Value))
            {
                if (item.Key == "Gold")
                {
                    Console.WriteLine($"<{item.Key}> ${item.Value}");
                    Console.WriteLine($"##{this.Gold.Name} - {this.Gold.Amount}");
                }
                else if (item.Key == "Gem")
                {
                    Console.WriteLine($"<{item.Key}> ${item.Value}");
                    foreach (var gem in this.Gems
                                                .OrderByDescending(g => g.Name)
                                                .ThenBy(g => g.Amount))
                    {
                        Console.WriteLine($"##{gem.Name} - {gem.Amount}");
                    }
                }
                else if (item.Key == "Cash")
                {
                    Console.WriteLine($"<{item.Key}> ${item.Value}");
                    foreach (var currency in this.Currencies
                                                .OrderByDescending(c => c.Name)
                                                .ThenBy(c => c.Amount))
                    {
                        Console.WriteLine($"##{currency.Name} - {currency.Amount}");
                    }
                }

            }
        }
    }
}