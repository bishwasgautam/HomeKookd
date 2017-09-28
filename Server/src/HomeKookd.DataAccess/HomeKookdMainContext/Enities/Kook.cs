using System.Collections.Generic;

namespace HomeKookd.DataAccess
{
    public class Kook
    {
        public int Id { get; set; }
        public User User { get; set; }
        public IEnumerable<Kitchen> Kitchen { get; set; }

        public IEnumerable<Testimony> Testomonies { get; set; }

    }
}