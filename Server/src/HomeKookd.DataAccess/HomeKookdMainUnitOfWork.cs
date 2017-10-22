using System;
using HomeKookd.DataAccess.HomeKookdMainContext;

namespace HomeKookd.DataAccess
{
    public class HomeKookdMainUnitOfWork : UnitOfWork<HomeKookdMainDataContext>
    {
        private readonly HomeKookdMainDataContext _dbContext;
        public HomeKookdMainUnitOfWork(HomeKookdMainDataContext dataContext): base(dataContext)
        {
            _dbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
    }
}
