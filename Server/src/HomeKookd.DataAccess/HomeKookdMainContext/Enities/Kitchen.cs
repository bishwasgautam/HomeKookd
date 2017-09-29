namespace HomeKookd.DataAccess.HomeKookdMainContext.Enities
{
    public class Kitchen
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public Kook Kook { get; set; }
        public int Serves { get;set; }
        public string Description  { get; set; }
        
    }
}