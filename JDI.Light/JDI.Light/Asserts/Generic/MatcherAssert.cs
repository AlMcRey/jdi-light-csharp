using JDI.Light.Matchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDI.Light.Asserts.Generic
{
    public class MatcherAssert
    {
        public MatcherAssert()
        { }

        public static void AssertThat<T>(T actual, Matcher<T> matcher)
        {
            AssertThat("", actual, matcher);
        }

        public static void AssertThat<T>(string reason, T actual, Matcher<T> matcher)
        {
            if(!matcher.IsMatch(actual))
            {
                throw new Exception($"{reason}. {matcher.FailedMessage()}");
            }
        }

        public static void AssertThat(string reason, bool assertion)
        {
            if(!assertion)
            {
                throw new Exception(reason);
            }
        }
    }
}
