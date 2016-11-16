using NullAlternatives.Common;
using NullAlternatives.Model;
using NullAlternatives.Repository;

namespace NullAlternatives.Service
{
    public abstract class CarCategoryServiceBase
    {
        public const string Unknown = "Car category unknown !";

        public readonly CacheService<CarCategory> Cache = new CacheService<CarCategory>();
        protected readonly CarCategoryRepository Repository = new CarCategoryRepository();

        public abstract Result<CarCategory> Get(string code);
    }
}
