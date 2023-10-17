using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts
{
    public interface IBreakfastService
    {
        void CreateBreakfast(Breakfast breakfast);
        void DeleteBreakfast(Guid id);
        Breakfast GetBreakfast(Guid id);
        void UpsetBreakfast(Breakfast breakfast);
    }
}
