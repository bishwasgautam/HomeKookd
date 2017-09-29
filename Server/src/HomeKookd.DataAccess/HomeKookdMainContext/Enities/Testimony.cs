namespace HomeKookd.DataAccess.HomeKookdMainContext.Enities
{
    public class Testimony
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public User User { get; set; }
    }
}