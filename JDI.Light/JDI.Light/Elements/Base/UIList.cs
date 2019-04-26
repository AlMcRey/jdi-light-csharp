using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JDI.Light.Factories;
using JDI.Light.Interfaces.Base;
using OpenQA.Selenium;

namespace JDI.Light.Elements.Base
{
    public class UIList<T> : UIElement, IList<T> where T : IBaseUIElement
    {
        protected UIList(By byLocator) : base(byLocator)
        {
            _uiElements = new List<T>();
        }

        private List<T> _uiElements;

        public new List<IWebElement> WebElements => _uiElements.Select(e => e.WebElement).ToList();
        public List<T> UIElements
        {
            get
            {
                _uiElements = new List<T>();
                var els = GetWebElements();
                foreach (var el in els)
                {
                    _uiElements.Add(UIElementFactory.CreateInstance<T>(Locator, this, el));
                }
                return _uiElements;
            }
        }

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