namespace HomeKookd.DataAccess.HomeKookdMainContext.Enities
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Kitchen Kitchen { get; set; }
        public Kook Kook { get; set; }

        public double Price { get; set; }
        public MealType Type { get; set; }
        public MealDetails Details { get; set; }
    }
}