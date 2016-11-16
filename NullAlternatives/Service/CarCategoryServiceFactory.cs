namespace NullAlternatives.Service
{
    public static class CarCategoryServiceFactory
    {
        public static CarCategoryServiceBase CreateService(string service)
        {
            switch (service)
            {
                case "1": return new CarCategoryWithNullService();
                case "2": return new CarCategoryWithMaybeService();
                case "3": return new CarCategoryWithOptionService();
            }
            return null;
        }
    }
}
