using System;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Interfaces
{
    public interface IAuditable
    {
        DateTime CreatedDateTime { get; set; }
        DateTime LastUpdatedDateTime { get; set; }
        bool IsActive { get; set; }
    }
}