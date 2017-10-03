using System;
using System.Collections.Generic;
using System.Text;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using HomeKookd.Domain;
using HomeKookd.Domain.Interfaces;
using HomeKookd.Repositories.Interfaces;

namespace HomeKookd.Repositories.Converters
{
    public class UserConverter : IConverter<UserDo, User>
    {
     

        public User ConvertToDatabaseType(UserDo domainType, int? modifiedBy, DateTime? modifiedDate)
        {
            var user =  AutoMapper.Mapper.Map<UserDo, User>(domainType);
            
            //addditional property mappings


            return user;
        }

        public UserDo ConvertToDomainType(User databaseType)
        {
            var userDo = AutoMapper.Mapper.Map<User, UserDo>(databaseType);

            //addditional property mappings


            return userDo;
        }
    }
}
