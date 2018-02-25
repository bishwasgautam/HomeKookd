using System.Collections.Generic;
using HomeKookd.Domain;

namespace HomeKookd.Repositories
{
    public interface IKookRepository
    {
        //KookDo FindBy(int id);
        KookDo FindBy(string email);
        List<MealDO> GetAllOfferedMeals(int kookId);
        List<HomeKookdMealDo> GetAllLiveMeals(int kookId);
        List<TestimonyDo> GetAllTestimonies(int kookId);
    }
}