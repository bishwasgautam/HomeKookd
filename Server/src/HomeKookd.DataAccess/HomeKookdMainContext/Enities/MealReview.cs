namespace HomeKookd.DataAccess.HomeKookdMainContext.Enities
{
    public class MealReview
    {
        public int Id { get; set; }
        public Testimony Testimony { get; set; }
        public int TasteIndex { get; set; } // 0 - 10
        public int TextureIndex { get; set; } // 0 - 10
        public int PriceWorthyIndex { get; set; } // 0 - 10
    }
}