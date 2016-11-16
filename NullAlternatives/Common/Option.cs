using System;
using System.Collections;
using System.Collections.Generic;

namespace NullAlternatives.Common
{
    /// <summary>
    /// Permet de gérer un objet sans valeur de manière fonctionnelle avec les méthodes LINQ,
    /// pour réduire la complexité cyclomatique de 1.
    /// </summary>
    /// <remarks>
    /// Source : http://www.codinghelmet.com/?path=howto/avoid-returning-null
    /// </remarks>
    public class Option<TValue> : IEnumerable<TValue>
    {
        private readonly IEnumerable<TValue> _values;

        public Option()
        {
            _values = new TValue[0];
        }

        public Option(TValue value)
        {
            _values = new[] { value };
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
