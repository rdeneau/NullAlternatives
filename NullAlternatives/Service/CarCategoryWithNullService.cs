using NullAlternatives.Common;
using NullAlternatives.Model;

namespace NullAlternatives.Service
{
    public class CarCategoryWithNullService : CarCategoryServiceBase
    {
        public override Result<CarCategory> Get(string code)
        {
            var result = Cache.Get(code);

            // Get from the repo
            if (result == null)
            {
                result = Repository.Get(code);
                Cache.Store(code, result);
            }

            // Encapsulate in a Result
            return result == null
                ? Result.Fail<CarCategory>(Unknown)
                : Result.Ok(result);
        }
    }
}
