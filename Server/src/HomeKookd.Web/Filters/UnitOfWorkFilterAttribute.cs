using System.Collections.Generic;
using HomeKookd.DataAccess;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeKookd.API.Filters
{
    public class UnitOfWorkFilterAttribute: ActionFilterAttribute
    {
        private readonly IEnumerable<IUnitOfWork> _unitsOfWork;

        public UnitOfWorkFilterAttribute(IEnumerable<IUnitOfWork> unitsOfWork)
        {
            _unitsOfWork = unitsOfWork;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            foreach (var unitOfWork in _unitsOfWork)
            {
                unitOfWork.BeginTransaction();
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            foreach (var unitOfWork in _unitsOfWork)
            {

                using (unitOfWork)
                {
                    if (filterContext.Exception != null)
                    {
                        unitOfWork.RollBackTransaction();
                        return;
                    }
                    try
                    {
                        unitOfWork.CommitTransaction();
                    }
                    catch
                    {
                        unitOfWork.RollBackTransaction();
                        throw;
                    }

                }
                
            }

        }

    }

}
