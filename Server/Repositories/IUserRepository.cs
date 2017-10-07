﻿using System;
using HomeKookd.DataAccess.HomeKookdMainContext.Entities;
using HomeKookd.Domain;

namespace HomeKookd.Repositories
{
    public interface IUserRepository
    {
        UserDo FindBy(string email);
        UserDo FindBy(PhoneDo phone);
        UserDo FindByMatchingGiven(string firstName, string lastName, string city, DateTime? birthday);
    }

    public interface KookRepository
    {
        KookdDo FindBy(string FirstName);

    }
}