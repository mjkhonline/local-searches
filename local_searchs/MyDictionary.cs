using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace local_searchs
{
    class MyDictionary<TKey, TValue>  where TValue : IComparable
    {
        private List<KeyValuePair<TKey, TValue>> list;

        public MyDictionary()
        {
            list = new List<KeyValuePair<TKey, TValue>>();
        }

        public MyDictionary(int capacity)
        {
            list = new List<KeyValuePair<TKey, TValue>>(capacity);
        }

        public void Add(TKey key, TValue value)
        {
            list.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        /*public KeyValuePair<TKey, TValue> remove(TKey key)
        {
            foreach (KeyValuePair<TKey, TValue> element in list)
            {
                if (element.Key.CompareTo(key) == 0)
                {
                    list.Remove(element);
                    return element;
                }
            }
            throw new ArgumentException("null pointer exception", "key");
        }*/

        public KeyValuePair<TKey, TValue> remove(KeyValuePair<TKey, TValue> element)
        {
            list.Remove(element);
            return element;
            throw new ArgumentException("null pointer exception", "element");
        }

        public KeyValuePair<TKey,TValue> First()
        {
            return list.First();
            throw new ArgumentException("out of band exception", "disctionary is empty");
        }

        public KeyValuePair<TKey, TValue> ElementAt(int index)
        {
            return list.ElementAt(index);
            throw new ArgumentException("out of band exception", "index");
        }

        public KeyValuePair<TKey, TValue> Pop()
        {
            return (remove(First()));
            throw new ArgumentException("out of band exception", "disctionary is empty");
        }

        public void SortByValue()
        {
            int size = list.Count;
            List<KeyValuePair<TKey, TValue>> sorted_list = new List<KeyValuePair<TKey, TValue>>(list.Capacity);
            for (int i = 0; i < size; i++)
            {
                KeyValuePair<TKey, TValue> best_element = list.First();
                TValue max_value = best_element.Value;
                for (int j = 0; j < size - i; j++)
                {
                    if (list.ElementAt(j).Value.CompareTo(max_value) > 0)
                    {
                        best_element = list.ElementAt(j);
                        max_value = best_element.Value;
                    }
                }
                sorted_list.Add(best_element);
                list.Remove(best_element);
            }

            list = sorted_list;
        }

        public bool IsEmpty()
        {
            return (list.Count == 0);
        }

        public int Count()
        {
            return list.Count;
        }
    }
}
