using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using HomeKookd.Domain;

namespace HomeKookd.Repositories.Mappings
{
    public class AutoMaps : AutoMapper.Profile
    {

        public AutoMaps()
        {
            AddUserProfile();
        }

        private void AddUserProfile()
        {
            CreateMap<User, UserDo>()
                .ReverseMap(); //all the common properties are mapped
        }
    }
}
