using System.Collections.Generic;
using System.Linq;
using NullAlternatives.Common;
using NullAlternatives.Model;

namespace NullAlternatives.Service
{
    public class CarCategoryWithOptionService : CarCategoryServiceBase
    {
        public override Result<CarCategory> Get(string code)
        {
            return Cache.GetAsOption(code)
                        .DefaultIfEmpty(() =>
                        {
                            var value = Repository.Get(code);
                            Cache.Store(code, value);
                            return value;
                        })
                        .Select(value => value == null
                                            ? Result.Fail<CarCategory>(Unknown)
                                            : Result.Ok(value))
                        .Single();
        }
    }
}
