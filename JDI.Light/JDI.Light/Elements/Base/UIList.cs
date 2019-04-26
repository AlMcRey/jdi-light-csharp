using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace JDI.Light.Elements.Base
{
    public class UIList<T> : UIElement, IList<T>
    {
        protected UIList(By byLocator) : base(byLocator)
        {
        }

        private List<T> _uiElements;

        public IEnumerator<T> GetEnumerator()
        {
            return _uiElements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _uiElements.GetEnumerator();
        }

        public void Add(T item)
        {
            _uiElements.Add(item);
        }

        public new void Clear()
        {
            _uiElements.Clear();
        }

        public bool Contains(T item)
        {
            return _uiElements.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _uiElements.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _uiElements.Remove(item);
        }

        public int Count => _uiElements.Count;
        public bool IsReadOnly => false;
        public int IndexOf(T item)
        {
            return _uiElements.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _uiElements.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _uiElements.RemoveAt(index);
        }

        public T this[int index]
        {
            get => _uiElements[index];
            set => _uiElements[index] = value;
        }
    }
}