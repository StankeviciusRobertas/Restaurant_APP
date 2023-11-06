namespace Restaurant_APP
{
    public class MenuItem
    {
        public string MealId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{MealId}.{Name} - {Price}";
        }
    }
}