using JDI.Light.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static JDI.Light.Asserts.Generic.MatcherAssert;

namespace JDI.Light.Asserts
{
    public class SoftAssert
    {
        private static List<Exception> listOfErrors = new List<Exception>();
        private static bool isSoftAssert = false;

        public static void SetAssertType(string type)
        {
            isSoftAssert = type.Equals("soft", StringComparison.InvariantCultureIgnoreCase);
            ClearResults();
        }

        public static void AssertSoft()
        {
            SetAssertType("soft");
        }

        public static void AssertStrict()
        {
            SetAssertType("strict");
        }

        public static void ClearResults()
        {
            listOfErrors.Clear();
        }

        public static void JdiAssert<T>(T actual, Matcher<T> matcher)
        {
            try
            {
                AssertThat(actual, matcher);
            }
            catch(Exception e)
            {
                if(isSoftAssert)
                {
                    listOfErrors.Add(e);
                }
                else
                {
                    throw e;
                }
            }
        }
    }
}
