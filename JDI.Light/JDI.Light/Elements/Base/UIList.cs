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
        }
        
        public new List<IWebElement> WebElements => UIElements.Select(e => e.WebElement).ToList();
        public List<T> UIElements
        {
            get
            {
                var uiElements = new List<T>();
                var els = GetWebElements();
                foreach (var el in els)
                {
                    uiElements.Add(UIElementFactory.CreateInstance<T>(Locator, this, el));
                }
                return uiElements;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return UIElements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return UIElements.GetEnumerator();
        }

        public void Add(T item)
        {
            UIElements.Add(item);
        }

        public new void Clear()
        {
            UIElements.Clear();
        }

        public bool Contains(T item)
        {
            return UIElements.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            UIElements.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return UIElements.Remove(item);
        }

        public int Count => UIElements.Count;
        public bool IsReadOnly => false;
        public int IndexOf(T item)
        {
            return UIElements.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            UIElements.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            UIElements.RemoveAt(index);
        }

        public T this[int index]
        {
            get => UIElements[index];
            set => UIElements[index] = value;
        }
    }
}