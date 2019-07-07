namespace ShoppingSpree
{
    using System;
    public class Product
    {
        private string productName;
        private decimal productPrice;
        public Product(string productName, decimal productPrice)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException($"Name cannot be empty");
                }

                this.productName = value;
            }
        }

        public decimal ProductPrice
        {
            get
            {
                return this.productPrice;
            }
            set
            {
                if (value < 0.0M)
                {
                    throw new ArgumentException($"Money cannot be negative");
                }

                this.productPrice = value;
            }
        }
    }
}