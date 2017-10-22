using System.Reflection;
using HomeKookd.Repositories;

namespace HomeKookd.API
{
    public class AutoMapperConfig
    {
        public static void RegisterProfiles()
        {
            AutoAutoMapper.AutoProfiler.RegisterProfiles(
                Assembly.GetAssembly(typeof(IUserRepository))
            );
        }
    }
}