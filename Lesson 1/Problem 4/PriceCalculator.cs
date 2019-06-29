namespace _4.HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal CalculatePrice(decimal pricePerDay,   
                                             int numberOfDays, 
                                             Season season, 
                                             Discount discount) 
        {
            int multiplier = (int)season;
            decimal discountMultiplier = (decimal)discount / 100;
            decimal priceBeforeDiscount = numberOfDays * pricePerDay * multiplier;
            decimal discountedAmount = priceBeforeDiscount * discountMultiplier;
            decimal finalPrice = priceBeforeDiscount - discountedAmount;

            return finalPrice;
        }

    }
}