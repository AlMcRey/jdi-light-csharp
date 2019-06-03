using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDI.Light.Utils
{
    public class DataClass<T>
    {
        public DataClass<T> set(Func<T> someAction)
        {
            someAction.Invoke();
            return this;
        }


    }
}
