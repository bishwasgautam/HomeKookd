using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using HomeKookd.Domain;
using HomeKookd.Domain.Interfaces;
using HomeKookd.Repositories.Interfaces;

namespace HomeKookd.Repositories.Converters
{
    public class UserConverter : IConverter<UserDo, User>
    {
        private readonly IMapper _mapper;

        public UserConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User ConvertToDatabaseType(UserDo domainType, int? modifiedBy, DateTime? modifiedDate)
        {
            var user = _mapper.Map<UserDo, User>(domainType);
            
            //addditional property mappings

            return user;
        }

        public UserDo ConvertToDomainType(User databaseType)
        {
            var userDo = _mapper.Map<User, UserDo>(databaseType);

            //addditional property mappings


            return userDo;
        }
    }
}
