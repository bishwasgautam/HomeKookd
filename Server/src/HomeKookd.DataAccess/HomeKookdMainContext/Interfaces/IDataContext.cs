using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Interfaces
{
    public interface IDataContext 
    {
        void SetEntityState(IAuditable entity, EntityState state);
        DbSet<T> GetSet<T>() where T : class, IAuditable, IIdentifyable, new();
        EntityState GetEntityState(IAuditable entity);
    }
}