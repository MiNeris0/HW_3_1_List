using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_1_List
{
    public class CustomCollection<T>
        where T : IEnumerable<T>, IComparable<T>
    {
        private const int InitCapacity = 10;
        private const int ResizeStep = 3;

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
            }
        }
    }
}
