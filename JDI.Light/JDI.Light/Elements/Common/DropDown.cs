﻿using System;
using JDI.Light.Interfaces.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JDI.Light.Elements.Common
{
    public class DropDown : Selector, IDropDown
    {
        public SelectElement SelectElement => new SelectElement(this); 

        public DropDown(By byLocator) : base(byLocator)
        {
        }

        public void Select(string value)
        {
            CheckEnabled(true);
            CheckEnabled(true, SelectElement, value);
            SelectElement.SelectByText(value);
            if (value != SelectElement.SelectedOption.Text)
            {
                throw new Exception($"{value} element not selected.");
            }
        }

        public void Select(Enum value)
        {
            CheckEnabled(true);
            CheckEnabled(true, SelectElement, value.ToString());
            SelectElement.SelectByText(value.ToString());
            if (value.ToString() != SelectElement.SelectedOption.Text)
            {
                throw new Exception($"{value} element not selected.");
            }
        }

        public void Select(int index)
        {
            CheckEnabled(true);
            index--;
            CheckEnabled(true, SelectElement, null, index);
            SelectElement.SelectByIndex(index);
            if (SelectElement.Options[index].Text != SelectElement.SelectedOption.Text)
            {
                throw new Exception($"{SelectElement.Options[index].Text} element not selected.");
            }
        }

        public string GetSelected()
        {
            return SelectElement.SelectedOption.Text;
        }
    }
}