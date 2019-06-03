using JDI.Light.Elements.Composite;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDI.Light.Elements.Complex.Table
{
    public class DataTable<L, D> : Table where L: Section
    {
        public DataTable(By locator) : base(locator)
        {            
        }

        private L lineClass;
        private D dataClass;

        protected Dictionary<int, L> lines = new Dictionary<int, L>();
        protected Dictionary<int, D> datas = new Dictionary<int, D>();

        public D Data(int rownum)
        {
            if (!datas.ContainsKey(rownum))
                datas.Add(rownum, getLineData(Row(rownum)));
            return datas[rownum];
        }

        public L Line(int rownum)
        {
            if(!lines.ContainsKey(rownum))
                lines.Add(rownum)
        }
            
        private D getLineData(Line row)
        {
            L line = row.
            return row.asData(dataClass, map);
        }



    }
}
