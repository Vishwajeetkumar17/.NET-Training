using System.Collections;

namespace GenericCustomization
{

    public class MyCollection : IList
    {
        private ArrayList _items;

        public MyCollection()
        {
            _items = new ArrayList();
        }

        public object? this[int index] { get => _items[index]; set => throw new NotImplementedException(); }

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public int Count => _items.Count;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public int Add(object? value)
        {
            return _items.Add(value);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(object? value)
        {
            return _items.Contains(value);
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object? value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object? value)
        {
            _items.Insert(index, value);
        }

        public void Remove(object? value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MyCollection collection = new MyCollection();
            Console.WriteLine(collection.Add(1));
            Console.WriteLine(collection.Add(2));
            Console.WriteLine(collection.Add(3));
            Console.WriteLine("Count: " + collection.Count);

            Console.WriteLine(collection[0]);
            Console.WriteLine(collection[1]);
            Console.WriteLine(collection[2]);

        }
    }
}
