using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MyDictionary.Models
{
    public class OwnDictionary<T, K> : IDictionary<T, K> where T : IComparable<T>
    {
        public K this[T key]
        {
            get
            {
                for (int i = 0; i < Keys.Count; i++)
                {
                    if ((Keys as List<T>)[i].CompareTo(key) == 0)
                    {
                        return (Values as List<K>)[i];
                    }
                }
                throw new Exception("Entered index does not exist");
            }
            set
            {
                for (int i = 0; i < Keys.Count; i++)
                {
                    if ((Keys as List<T>)[i].CompareTo(key) == 0)
                    {
                        (Values as List<K>)[i] = value;
                        return;
                    }
                }
                Values.Add(value);
                Keys.Add(key);
            }
        }
        public ICollection<T> Keys { get; set; }

        public ICollection<K> Values { get; set; }

        public int Count
        {
            get
            {
                return Keys.Count;
            }
        }

        public bool IsReadOnly { get; private set; } = false;

        public OwnDictionary()
        {
            Keys = new List<T>();
            Values = new List<K>();
        }

        public void Add(T key, K value)
        {
            this[key] = value;
        }

        public void Add(KeyValuePair<T, K> item)
        {
            this[item.Key] = item.Value;
        }

        public void Clear()
        {
            Values.Clear();
            Keys.Clear();
        }

        public bool Contains(KeyValuePair<T, K> item)
        {
            try
            {
                var val = this[item.Key];
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ContainsKey(T key)
        {
            return Keys.Contains(key);
        }

        public void CopyTo(KeyValuePair<T, K>[] array, int arrayIndex)
        {
            for (int i = 0; i < Keys.Count; i++)
            {
                array[i] = new KeyValuePair<T, K>((Keys as List<T>)[i], (Values as List<K>)[i]);
            }
        }

        public IEnumerator<KeyValuePair<T, K>> GetEnumerator()
        {
            for (int i = 0; i < Keys.Count; i++)
            {
                yield return new KeyValuePair<T, K>((Keys as List<T>)[i], (Values as List<K>)[i]);
            }
        }

        public bool Remove(T key)
        {
            for (int i = 0; i < Keys.Count; i++)
            {
                if ((Keys as List<T>)[i].CompareTo(key) == 0)
                {
                    Keys.Remove((Keys as List<T>)[i]);
                    Values.Remove((Values as List<K>)[i]);
                    return true;
                }
            }
            return false;
        }

        public bool Remove(KeyValuePair<T, K> item)
        {
            for (int i = 0; i < Keys.Count; i++)
            {
                if ((Keys as List<T>)[i].CompareTo(item.Key) == 0)
                {
                    Keys.Remove((Keys as List<T>)[i]);
                    Values.Remove((Values as List<K>)[i]);
                    return true;
                }
            }
            return false;
        }

        public bool TryGetValue(T key, [MaybeNullWhen(false)] out K value)
        {
            try
            {
                value = this[key];
                return true;
            }
            catch
            {
                value = default(K);
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Keys.Count; i++)
            {
                yield return new KeyValuePair<T, K>((Keys as List<T>)[i], (Values as List<K>)[i]);
            }
        }
    }
}
