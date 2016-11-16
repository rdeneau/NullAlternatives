using System.Collections.Generic;
using NullAlternatives.Common;

namespace NullAlternatives.Service
{
    public class CacheService<T> where T : class
    {
        private readonly Dictionary<string, T> _data = new Dictionary<string, T>();

        public bool Contains(string key)
        {
            return _data.ContainsKey(key);
        }

        public void Store(string key, T value)
        {
            _data[key] = value;
        }

        public T Get(string key)
        {
            return _data.ContainsKey(key) ? _data[key] : null;
        }

        public Maybe<T> GetAsMaybe(string key)
        {
            return Get(key);
        }

        public Option<T> GetAsOption(string key)
        {
            return _data.ContainsKey(key) ? new Option<T>(_data[key]) : new Option<T>();
        }
    }
}
