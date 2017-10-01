using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("Kitchens")]
    public class Kitchen: IAuditable, IIdentifyable
    {

        public Kitchen()
        {
            Meals = new HashSet<Meal>();
        }
        public int Id { get; set; }
        public int Serves { get;set; }
        public string Description  { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int KookId { get; set; }
        public Kook Kook { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}