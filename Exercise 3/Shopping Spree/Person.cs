namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    public class Person
    {
        private string personName;
        private decimal money;
        private List<Product> bagOfProducts;
        public Person(string personName, decimal money)
        {
            this.PersonName = personName;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string PersonName
        {
            get
            {
                return this.personName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException($"Name cannot be empty");
                }

                this.personName = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0.0M)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }

                this.money = value;
            }
        }
        public IReadOnlyList<Product> BagOfProducts
        {
            get { return this.bagOfProducts.AsReadOnly(); }
        }

        public string AddProduct(Product product)
        {
            if (this.Money >= product.ProductPrice)
            {
                this.bagOfProducts.Add(product);
                this.Money -= product.ProductPrice;
                return $"{this.PersonName} bought {product.ProductName}";
            }
            else
            {
                return $"{this.PersonName} can't afford {product.ProductName}";
            }
        }
    }
}