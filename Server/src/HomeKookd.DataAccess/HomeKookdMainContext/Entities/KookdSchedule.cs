using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeKookd.DataAccess.HomeKookdMainContext.Interfaces;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Entities
{
    [Table("KookdSchedules")]
    public class KookdSchedule : IIdentifyable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime ReadyAt { get; set; }
        public bool? IsRecurring { get; set; }
        public int?  RecurringFrequencyInDays { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime RecurStartDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        public DateTime RecurEndDateTime { get; set; } 

        [NotMapped]
        public bool IsLive
        {
            get
            {
                var now = DateTime.UtcNow;
                return now > RecurStartDateTime && now < RecurEndDateTime;
            }
        }

        //FKs
        public int HomeKookdMealSettingId { get; set; }
        public HomeKookdMealSetting HomeKookdMealSetting { get; set; }

    }
}