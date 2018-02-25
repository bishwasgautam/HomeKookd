namespace HomeKookd.Domain
{
    public class TestimonyDo: DomainBase
    {
        public TestimonyDo(int id) : base(id)
        {
        }

   
        public int Rating { get; set; }

        public string Review { get; set; }

        public int Commentor { get; set; } //User Id
        public int For { get; set; } //Kook Id

    }
}