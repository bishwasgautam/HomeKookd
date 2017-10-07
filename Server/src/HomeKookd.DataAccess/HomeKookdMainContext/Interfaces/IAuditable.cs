using System;
using System.ComponentModel.DataAnnotations;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Interfaces
{
    public interface IAuditable
    {
        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        DateTime CreatedDateTime { get; set; }

        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy", ApplyFormatInEditMode = true)]
        DateTime? LastUpdatedDateTime { get; set; }
        bool IsActive { get; set; }
    }
}