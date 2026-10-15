using System.Collections.Generic;

namespace DZ.Shelter
{
    // Простий узагальнений притулок для зберігання тварин (або інших об'єктів)
    public class MyShelter<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item) => _items.Add(item);
        public bool Remove(T item) => _items.Remove(item);
        public int Count => _items.Count;
        public IEnumerable<T> Items => _items.AsReadOnly();
    }
}
