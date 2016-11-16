using NullAlternatives.Common;
using NullAlternatives.Model;

namespace NullAlternatives.Service
{
    public class CarCategoryWithMaybeService : CarCategoryServiceBase
    {
        public override Result<CarCategory> Get(string code)
        {
            CarCategory value;
            var result = Cache.GetAsMaybe(code);

            // Get from the repo
            // => Variable "result" cannot be null here!
            if (result.HasNoValue)
            {
                value = Repository.Get(code);
                Cache.Store(code, value);
            }
            else
            {
                value = result.Value;
            }

            // Encapsulate in a Result
            return value == null
                ? Result.Fail<CarCategory>(Unknown)
                : Result.Ok(value);
        }
    }
}
