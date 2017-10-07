using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int Id { get; set; }
        [Required]
        public int Serves { get;set; }
       
        public string Description  { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime CreatedDateTime { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedDateTime { get; set; }
        public bool IsActive { get; set; }

        //FKs
        public int KookId { get; set; }
        public Kook Kook { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}