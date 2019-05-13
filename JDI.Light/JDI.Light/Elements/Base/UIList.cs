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
        
        public new List<IWebElement> WebElements => List.Select(e => e.WebElement).ToList();
        public List<T> List
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
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public void Add(T item)
        {
            List.Add(item);
        }

        public new void Clear()
        {
            List.Clear();
        }

        public bool Contains(T item)
        {
            return List.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return List.Remove(item);
        }

        public int Count => List.Count;
        public bool IsReadOnly => false;
        public int IndexOf(T item)
        {
            return List.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            List.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }

        public T this[int index]
        {
            get => List[index];
            set => List[index] = value;
        }
    }
}