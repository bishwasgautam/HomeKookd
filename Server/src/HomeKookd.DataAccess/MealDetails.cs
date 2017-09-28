using System.Collections.Generic;

namespace HomeKookd.DataAccess
{
    public class MealDetails
    {
        public int Id { get; set; }

        //Ingredients (Comma separated - eg: Olive oil, Flour, Chicken)
        public string Ingredients { get; set; }
        public int TotalCalories { get; set; }
        public IEnumerable<MealAttribute> Attributes { get; set; } //has preservatives, cooked with alcohol, artificial coloring, fermented etc
        

    }
}