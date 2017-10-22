namespace HomeKookd.Domain
{
    public class HomeKookdMealDo : DomainBase
    {
        public HomeKookdMealDo(int id) : base(id)
        {
        }

        public int KookId { get; set; }
        public int MealId { get; set; }
        public int HomeKookdMealSettingsId { get; set; }
        public int KookdCalenderId { get; set; }
    }
}