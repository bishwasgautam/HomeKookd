namespace HomeKookd.DataAccess
{
    public class User
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public UserType Type { get; set; }
        public string Image { get; set; }

    }
}