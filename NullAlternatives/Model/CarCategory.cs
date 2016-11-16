namespace NullAlternatives.Model
{
    public class CarCategory
    {
        public string Code { get; }
        public string Name { get; }

        public CarCategory(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
