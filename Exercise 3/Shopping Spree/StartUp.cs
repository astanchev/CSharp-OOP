using System.Linq;

namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static List<Person> listOfPersons;
        private static List<Product> productList;
        public static void Main(string[] args)
        {
            listOfPersons = new List<Person>();
            productList = new List<Product>();

            try
            {
                AddPersonsToList();

                AddProductsToList();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            BuyingProducts();

            PrintBuyings();
        }

        private static void PrintBuyings()
        {
            foreach (var person in listOfPersons)
            {
                Person currentPerson = person;

                if (currentPerson.BagOfProducts.Count > 0)
                {
                    Console.Write($"{currentPerson.PersonName} - ");
                    Console.WriteLine(string.Join(", ", currentPerson.BagOfProducts.Select(p => p.ProductName).ToList()));
                }
                else
                {
                    Console.WriteLine($"{currentPerson.PersonName} - Nothing bought");
                }
            }
        }

        private static void BuyingProducts()
        {
            while (true)
            {
                string inputLine = Console.ReadLine().Trim();
                if (inputLine == "END")
                {
                    return;
                }

                string[] purchase = inputLine.Split(' ');
                string buyer = purchase[0];
                string purchasedProduct = purchase[1];

                Person currentPerson = listOfPersons
                                            .FirstOrDefault(p => p.PersonName == buyer);

                decimal price = productList
                                        .FirstOrDefault(p => p.ProductName == purchasedProduct)
                                        .ProductPrice;

                Product newProduct = new Product(purchasedProduct, price);

                Console.WriteLine(currentPerson.AddProduct(newProduct));
            }
        }

        private static void AddProductsToList()
        {
            string[] groceries = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var element in groceries)
            {
                string[] product = element.Split('=');
                string productName = product[0];
                decimal productPrice = decimal.Parse(product[1]);

                Product newProduct = new Product(productName, productPrice);

                productList.Add(newProduct);
            }
        }

        private static void AddPersonsToList()
        {
            string[] individuals = Console.ReadLine()
                .Split(';');

            foreach (var individual in individuals)
            {
                string[] person = individual.Split('=');
                string personName = person[0];
                decimal personMoney = decimal.Parse(person[1]);

                Person newPerson = new Person(personName, personMoney);

                listOfPersons.Add(newPerson);
            }
        }
    }
}
