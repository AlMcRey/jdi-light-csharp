using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace JDI.Light.Elements.Base
{
    public class JList<T>
    {
        protected List<T> elements = new List<T>();

        public JList() {}

        public JList(IEnumerable<T> elements)
        {
            this.elements.AddRange(elements);
        }

        
    }
}
