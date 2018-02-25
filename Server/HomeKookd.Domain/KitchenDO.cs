namespace HomeKookd.Domain
{
    public class KitchenDO : DomainBase
    {
        public KitchenDO(int id) : base(id)
        {
        }

     
        public int Serves { get; set; }

        public string Description { get; set; }

        public int KookId { get; set; }
        public int AddressId { get; set; }
    
    }
}