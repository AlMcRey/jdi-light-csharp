using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDI.Light.Matchers
{
    public class IsNot<T> : Matcher<T>
    {
        private Matcher<T> _matcher;

        protected IsNot(T rightValue) : base(rightValue)
        {
        }

        public IsNot(Matcher<T> matcher)
        {
            _matcher = matcher;
        }

        public new static Matcher<T> Not(Matcher<T> matcher)
        {
            return new IsNot<T>(matcher);
        }

        public override string ActionName { get; }

        protected override Func<T, T, bool> Condition { get;}

        public new bool IsMatch(T leftValue)
        {            
            return !Condition(leftValue, _matcher.RightValue);
        }
    }
}
