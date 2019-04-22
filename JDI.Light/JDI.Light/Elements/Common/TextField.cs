﻿using System;
using JDI.Light.Elements.Base;
using JDI.Light.Exceptions;
using JDI.Light.Interfaces.Common;
using OpenQA.Selenium;

namespace JDI.Light.Elements.Common
{
    public class TextField : TextElement, ITextField
    {
        protected Func<UIElement, string> GetTextFunc =
            el => el.FindImmediately(() => el.WebElement.GetAttribute("value"), "");
        
        public TextField(By byLocator = null)
            : base(byLocator)
        {
        }

        public void Input(string text)
        {
            CheckEnabled();
            Clear();
            SendKeys(text);
        }

        public new string Value
        {
            get => base.Value;
            set => Invoker.DoActionWithWait("Set value", () =>
            {
                var e = WebElement;
                e.Clear();
                e.SendKeys(value);
            });
        }

        public new void SendKeys(string text)
        {
            CheckEnabled();
            Invoker.DoActionWithWait($"Input text '{text}' in text field", () => WebElement.SendKeys(text));
        }

        public new void Clear()
        {
            Invoker.DoActionWithWait("Clear text field", () => WebElement.Clear());
        }

        public void Focus()
        {
            Invoker.DoActionWithWait("Focus on text field", () => WebElement.Click());
        }

        public void SetText(string text)
        {
            Input(text);
        }

        public string Placeholder => GetAttribute("placeholder");

        protected void CheckEnabled()
        {
            if (!Enabled)
            {
                throw new ElementDisabledException("TextField is disabled");
            }
        }
    }
}