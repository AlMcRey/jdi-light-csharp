using System;
using System.Collections.Generic;
using System.Linq;
using JDI.Light.Elements.Base;
using JDI.Light.Matchers;
using static JDI.Light.Jdi;

namespace JDI.Light.Asserts
{
    public class ListAssert<T> where T : UIElement
    {
        List<T> elements;

        public ListAssert(List<T> elements)
        {
            this.elements = elements;
        }

        public ListAssert<T> Is()
        {
            return this;
        }

        public ListAssert<T> Texts(Matcher<IEnumerable<string>> condition)
        {
            var texts = elements.Select(el => el.Text).ToArray();
            Assert.IsTrue(condition.IsMatch(texts), $"Texts {string.Join(",", texts)} are not {condition.ActionName} {string.Join(",", condition.RightValue)}");
            return this;
        }

        public ListAssert<T> Attrs(string attrName, Matcher<IEnumerable<string>> condition)
        {
            var attrs = elements.Select(el => el.GetAttribute(attrName)).ToArray();
            Assert.IsTrue(condition.IsMatch(attrs), $"Attributes {string.Join(",", attrs)} are not {condition.ActionName} {string.Join(",", condition.RightValue)}");
            return this;
        }

        public ListAssert<T> AllCss(string css, Matcher<IEnumerable<string>> condition)
        {
            var cssValues = elements.Select(el => el.GetCssValue(css)).ToArray();
            Assert.IsTrue(condition.IsMatch(cssValues), $"Css values {string.Join(",", cssValues)} are not {condition.ActionName} {string.Join(",", condition.RightValue)}");
            return this;
        }

        public ListAssert<T> AllTags(Matcher<IEnumerable<string>> condition)
        {
            var tags = elements.Select(el => el.TagName).ToArray();
            Assert.IsTrue(condition.IsMatch(tags), $"All tags {string.Join(",", tags)} are not {condition.ActionName} {string.Join(",", condition.RightValue)}");
            return this;
        }

        public ListAssert<T> HasCssClasses(params string[] classNames)
        {
            throw new NotImplementedException("implement after Mathers hasItems creation");
        }

        public ListAssert<T> CssClasses(Matcher<IEnumerable<string>> condition)
        {
            var classes = elements.Select(el => el.GetAttribute("class")).ToArray();
            Assert.IsTrue(condition.IsMatch(classes), $"Css classes {string.Join(",", classes)} are not {condition.ActionName} {string.Join(",", condition.RightValue)}");
            return this;
        }

        public ListAssert<T> AllDisplayed()
        {
            Assert.IsTrue(elements.All(element => element.Displayed), "Not all elements are displayed");
            return this;
        }

        public ListAssert<T> Displayed()
        {
            Assert.IsTrue(elements.Any(element => element.Displayed), "Not all elements are displayed");
            return this;
        }

        public ListAssert<T> AllHidden()
        {
            Assert.IsFalse(elements.All(element => element.Displayed), "Not all elements are hidden");
            return this;
        }

        public ListAssert<T> AllSelected()
        {
            Assert.IsTrue(elements.All(element => element.Selected), "Not all elements are selected");
            return this;
        }

        public ListAssert<T> AllEnabled()
        {
            Assert.IsTrue(elements.All(element => element.Enabled), "Not all elements are enabled");
            return this;
        }
    }
}