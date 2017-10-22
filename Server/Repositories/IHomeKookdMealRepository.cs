using System;
using System.Collections.Generic;
using System.Device.Location;
using HomeKookd.Domain;

namespace HomeKookd.Repositories
{
    public interface IHomeKookdMealRepository
    {
        //HomeKookdMealDo FindBy(int id);
        HomeKookdMealDo FindBy(DateTime kookdTime);

        List<HomeKookdMealDo> KookdMealsNearMe(GeoCoordinate coordinate);
        List<HomeKookdMealDo> KookdMealsNearAddress(AddressDO address);
    }
}