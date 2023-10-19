using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using ErrorOr;
using System.Runtime.CompilerServices;

namespace BuberBreakfast.Services.Breakfasts
{
    public class BreakfastService : IBreakfastService
    {
        private static Dictionary<Guid, Breakfast> _breakfasts = new();
        public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
        {
            _breakfasts.Add(breakfast.Id, breakfast);

            return Result.Created;
        }

        public ErrorOr<Deleted> DeleteBreakfast(Guid id)
        {
            if(_breakfasts.TryGetValue(id, out var breakfast))
            {
                _breakfasts.Remove(id);
                return Result.Deleted;
            }
            

            return Errors.Breakfast.NotFound;
        }

        public ErrorOr<Breakfast> GetBreakfast(Guid id)
        {
            if (_breakfasts.TryGetValue(id, out var breakfast))
            {

                return _breakfasts[id];
            }

            return Errors.Breakfast.NotFound;
        }

        public ErrorOr<UpsertedBreakfastResult> UpsetBreakfast(Breakfast breakfast)
        {
            var isNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);

            _breakfasts[breakfast.Id] = breakfast;

            return new UpsertedBreakfastResult(isNewlyCreated);
        }
    }
}
