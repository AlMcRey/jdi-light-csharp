﻿using System;
using JDI.Light.Elements.Base;
using JDI.Light.Extensions;

namespace JDI.Light.Elements.WebActions
{
    public class ElementsActions
    {
        public ElementsActions(ActionInvoker<UIElement> invoker)
        {
            Invoker = invoker;
        }

        public ActionInvoker<UIElement> Invoker { get; set; }

        // Text Actions
        public string WaitText(string text, Func<UIElement, string> getTextAction)
        {
            Func<UIElement, Func<string>> textAction = el => () => getTextAction(el);
            return Invoker.DoActionWithResult($"Wait text contains '{text}'",
                el => textAction(el).GetByCondition(t => t.Contains(text)));
        }

        public string WaitMatchText(string regEx, Func<UIElement, string> getTextAction)
        {
            Func<UIElement, Func<string>> textAction = el => () => getTextAction(el);
            return Invoker.DoActionWithResult($"Wait text match regex '{regEx}'",
                el => textAction(el).GetByCondition(t => t.Matches(regEx)));
        }
    }
}