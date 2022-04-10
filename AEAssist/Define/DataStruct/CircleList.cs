using System.Collections.Generic;

namespace AEAssist
{
    public class CircleList<T> where T : class
    {
        private readonly List<T> _list = new List<T>();

        public int Count => _list.Count;

        public void Add(T t)
        {
            _list.Add(t);
        }

        public void Clear()
        {
            _list.Clear();
        }


        public int GetIndex(T t)
        {
            return _list.FindIndex(v => v == t);
        }

        public T GetNext(T t)
        {
            if (t == null)
            {
                if (_list.Count > 0)
                    return _list[0];
                return null;
            }

            var currIndex = GetIndex(t);
            if (currIndex < 0)
                return null;
            var nextIndex = currIndex + 1;
            if (_list.Count <= nextIndex) nextIndex -= _list.Count;

            if (_list[nextIndex] == t) return null;

            return _list[nextIndex];
        }

        public T GetPre(T t)
        {
            if (t == null)
            {
                if (_list.Count > 0)
                    return _list[0];
                return null;
            }

            var currIndex = GetIndex(t);
            if (currIndex < 0)
                return null;
            var nextIndex = currIndex - 1;
            if (nextIndex < 0) nextIndex += _list.Count;

            if (_list[nextIndex] == t) return null;

            return _list[nextIndex];
        }
    }
}