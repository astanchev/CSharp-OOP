namespace _4.HotelReservation
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2];

            Season currentSeason = (Season) Enum.Parse(typeof(Season), season);

            Discount currentDiscount = Discount.None;

            if (input.Length == 4)
            {
                currentDiscount = (Discount) Enum.Parse(typeof(Discount), input[3]);
            }

            decimal totalPrice = PriceCalculator.CalculatePrice(pricePerDay,
                numberOfDays,
                currentSeason,
                currentDiscount);

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
