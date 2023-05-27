using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_1_List
{
    public class CustomCollection<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private const int InitCapacity = 10;
        private const int ResizeStep = 2;

        private T[] _list;
        private int _size;

        public int Size
        {
            get { return _size; }
        }

        public int Capacity
        {
            get { return _list.Length; }
        }

        public CustomCollection()
        {
            _list = new T[InitCapacity];
            _size = 0;
        }
        public void Add(T value)
        {
            if (_size >= _list.Length)
            {
                Array.Resize(ref _list, _list.Length * ResizeStep);
            }

            _list[_size] = value;
            _size++;
        }

        public void Remove(T value)
        {
            int index = -1;

            for (int i = 0; i < _size; i++)
            {
                if (_list[i].Equals(value))
                {
                    index = i;
                }
            }

            if (index < 0 && index >= _size)
            {
                return;
            }

            RemoveElement(index);

            _size--;
        }

        public void AddRange(IEnumerable<T> range)
        {
            foreach (var item in range)
            {
                this.Add(item);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 && index >= _size)
            {
                return;
            }

            RemoveElement(index);

            _size--;
        }

        public void Sort()
        {
            Array.Sort(_list, 0, _size);
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_list);
        }

        private void RemoveElement(int index)
        {
            for (int i = index; i < _size; i++)
            {
                if (i + 1 < _size)
                {
                    _list[i] = _list[i + 1];
                }
                else
                {
                    _list[i] = default(T);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomCollectionEnumerator(_list, _size);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private sealed class CustomCollectionEnumerator : IEnumerator<T>
        {
            private T[] _list;
            private int _size;
            private int _position = -1;

            public CustomCollectionEnumerator(T[] array, int size)
            {
                _list = array;
                _size = size;
            }
            public bool MoveNext()
            {
                if (_position < _size - 1)
                {
                    _position++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                _position = -1;
            }

            public T Current
            {
                get
                {
                    if (_position == -1 || _position >= _size)
                    {
                        throw new InvalidOperationException();
                    }

                    return _list[_position];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                // No unmanaged resources used.
            }
        }
    }
}
