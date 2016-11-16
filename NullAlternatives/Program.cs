using System;
using System.Linq;
using NullAlternatives.Repository;
using NullAlternatives.Service;

namespace NullAlternatives
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Services available:");
            Console.WriteLine("1. Can return null");
            Console.WriteLine("2. Returns Maybe (Nullable like)");
            Console.WriteLine("3. Returns Option (IEnumerable)");
            Console.Write("Choose your service: ");
            var service = CarCategoryServiceFactory.CreateService(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine($"Codes of available car categories: {string.Join(", ", CarCategoryRepository.Data.Keys)}");

            var key = CarCategoryRepository.Data.Keys.First();
            GetResult(key, service, "Choosing existing code = {0} - 1st time");
            GetResult(key, service, "Choosing existing code = {0} - 2nd time");
            GetResult("z", service, "Choosing unknown code = {0}");

            Console.WriteLine("");
            Console.Write("Press ENTER to exit... ");
            Console.ReadLine();
            Console.WriteLine("Bye, bye!");
        }

        private static void GetResult(string key, CarCategoryServiceBase service, string format)
        {
            Console.WriteLine("");
            Console.WriteLine(format, key);
            Console.WriteLine($" => In cache before: {service.Cache.Contains(key)}");
            var result = service.Get(key);
            Console.WriteLine(result.IsSuccess
                                ? $" => Result: Success{Environment.NewLine} => Value: {result.Value.Name}"
                                : $" => Result: Error: {result.Error}");
            Console.WriteLine($" => In cache after: {service.Cache.Contains(key)}");
        }
    }
}
