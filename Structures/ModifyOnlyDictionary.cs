using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace LetGetAPass.Structures
{
    public class ModifyOnlyDictionary<TKey, TValue>(Dictionary<TKey, TValue> values)
        : IReadOnlyDictionary<TKey, TValue>
        where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> values = values;

        public TValue this[TKey key]
        {
            get => values[key];
            set => values[key] = value;
        }

        #region Read-only
        public IEnumerable<TKey> Keys => values.Keys;
        public IEnumerable<TValue> Values => values.Values;
        public int Count => values.Count;
        public bool ContainsKey(TKey key) => values.ContainsKey(key);
        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) => values.TryGetValue(key, out value);
        #endregion

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}