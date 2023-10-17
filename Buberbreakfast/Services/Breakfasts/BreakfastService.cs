using BuberBreakfast.Models;
using System.Runtime.CompilerServices;

namespace BuberBreakfast.Services.Breakfasts
{
    public class BreakfastService : IBreakfastService
    {
        private static Dictionary<Guid, Breakfast> _breakfasts = new();
        public void CreateBreakfast(Breakfast breakfast)
        {
            _breakfasts.Add(breakfast.Id, breakfast);
        }

        public void DeleteBreakfast(Guid id)
        {
            _breakfasts.Remove(id);
        }

        public Breakfast GetBreakfast(Guid id)
        {
            return _breakfasts[id];
        }

        public void UpsetBreakfast(Breakfast breakfast)
        {
            _breakfasts[breakfast.Id] = breakfast;
        }
    }
}
