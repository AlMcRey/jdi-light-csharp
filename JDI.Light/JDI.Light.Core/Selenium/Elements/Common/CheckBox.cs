﻿using System;
using JDI.Core.Interfaces.Common;
using JDI.Core.Selenium.Base;
using JDI.Core.Selenium.Elements.Base;
using JDI.Core.Settings;
using OpenQA.Selenium;

namespace JDI.Core.Selenium.Elements.Common
{
    public class CheckBox : Clickable, ICheckBox
    {
        public Action<CheckBox> CheckAction = el =>
        {
            if (!el.IsCheckedAction(el))
                el.ClickAction(el);
            if (!el.IsCheckedAction(el))
                throw JDISettings.Exception("Can't check element. Verify locator for click or isCheckedAction");
        };

        protected Func<UIElement, string> GetValueFunc = el => ((CheckBox) el).IsChecked() + "";

        public Func<CheckBox, bool> IsCheckedAction =
            el => el.IsSelected(el) || el.IsCheckedByAttribute(el);

        public Func<UIElement, bool> IsCheckedByAttribute =
            el => el.FindImmediately(() => el.WebElement.GetAttribute("checked") != null, false);

        public Func<UIElement, bool> IsSelected =
            el => el.FindImmediately(() => el.WebElement.Selected, false);

        protected Action<UIElement, string> SetValueAction = (el, value) =>
        {
            switch (value.ToLower())
            {
                case "true":
                case "1":
                case "check":
                    ((CheckBox) el).Check();
                    break;
                case "false":
                case "0":
                case "uncheck":
                    ((CheckBox) el).Uncheck();
                    break;
                default:
                    throw JDISettings.Exception(
                        $"SetValue not specified correctly {value}, expected: 'true','false','0','1','check','uncheck'");
            }
        };

        public CheckBox() : this(null)
        {
        }

        public CheckBox(By byLocator = null, IWebElement webElement = null, UIElement element = null)
            : base(byLocator, webElement, element)
        {
        }

        public void Check()
        {
            Actions.Check(el => CheckAction(this));
        }

        public void Uncheck()
        {
            Actions.Uncheck(UncheckAction);
        }

        public bool IsChecked()
        {
            return Actions.IsChecked(el => IsCheckedAction(this));
        }

        public string Value
        {
            get => Actions.GetValue(GetValueFunc);
            set => Actions.SetValue(value, SetValueAction);
        }

        public string GetValue()
        {
            return Value;
        }

        protected void UncheckAction(UIElement el)
        {
            if (IsCheckedAction((CheckBox) el))
                ClickAction(el);
            if (IsCheckedAction((CheckBox) el))
                throw JDISettings.Exception("Can't uncheck element. Verify locator for click or isCheckedAction");
        }
    }
}