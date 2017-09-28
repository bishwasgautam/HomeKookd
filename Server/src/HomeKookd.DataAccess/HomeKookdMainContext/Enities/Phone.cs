namespace HomeKookd.DataAccess
{
    public class Phone
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public PhoneType Type { get; set; }

        public string GetFullNumber()
        {
            return $"{CountryCode}{AreaCode}-{PhoneNumber}";
        }

    }
}