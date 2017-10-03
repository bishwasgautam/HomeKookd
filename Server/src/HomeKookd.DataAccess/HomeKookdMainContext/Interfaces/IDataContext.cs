using Microsoft.EntityFrameworkCore;

namespace HomeKookd.DataAccess.HomeKookdMainContext.Interfaces
{
    public interface IDataContext 
    {
        void SetEntityState(IIdentifyable entity, EntityState state);
        DbSet<T> GetSet<T>() where T : class, IIdentifyable, new();
        EntityState GetEntityState(IIdentifyable entity);
    }
}