﻿using JDI.Light.Attributes;
using JDI.Light.Elements.Common;
using JDI.Light.Elements.Composite;
using JDI.Light.Interfaces.Common;
using JDI.Light.Tests.Entities;

namespace JDI.Light.Tests.UIObjects.Forms
{
    public class ContactFormTwoButtons : Form<Contact>
    {
        [FindBy(Id = "description")]
        public TextArea Description;

        [FindBy(XPath = ".//a[@class='ui-slider-handle ui-state-default ui-corner-all' and position()=1]")]
        public Link FirstRoller;

        [FindBy(Id = "last-name")]
        public TextField LastName;

        [FindBy(Id = "name")]
        public new TextField Name;

        [FindBy(XPath = ".//a[@class='ui-slider-handle ui-state-default ui-corner-all' and position()=2]")]
        public Link SecondRoller;

        [FindBy(XPath = "//*[text()='Submit']")]
        public new IButton Submit;
    }
}