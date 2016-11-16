using System.Collections.Generic;
using System.Linq;
using NullAlternatives.Model;

namespace NullAlternatives.Repository
{
    public class CarCategoryRepository
    {
        public static readonly Dictionary<string, CarCategory> Data = new[]
        {
            new CarCategory("a", "citadine"),
            new CarCategory("b", "familiale"),
            new CarCategory("c", "sportive")
        }
        .ToDictionary(v => v.Code);

        /// <remarks>
        /// Renvoie les données de la base telles quelles. Elles peuvent donc être NULL.
        /// </remarks>
        public CarCategory Get(string code)
        {
            return Data.ContainsKey(code) ? Data[code] : null;
        }
    }
}
