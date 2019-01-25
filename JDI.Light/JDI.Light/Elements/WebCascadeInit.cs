using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JDI.Light.Attributes;
using JDI.Light.Elements.Base;
using JDI.Light.Elements.Common;
using JDI.Light.Elements.Composite;
using JDI.Light.Enums;
using JDI.Light.Extensions;
using JDI.Light.Factories;
using JDI.Light.Interfaces.Base;
using JDI.Light.Interfaces.Common;
using JDI.Light.Interfaces.Composite;
using JDI.Light.Settings;
using JDI.Light.Utils;
using OpenQA.Selenium;

namespace JDI.Light.Elements
{
    public class WebCascadeInit
    {
        protected Type[] Decorators = { typeof(IBaseElement), typeof(IList) };

        protected Type[] StopTypes => new[]
        {
            typeof(object),
            typeof(WebPage),
            typeof(Section),
            typeof(UIElement)
        };
        
        public void InitStaticPages(Type parentType, DriverType driverType)
        {
            SetFields(null, parentType.StaticFields().GetFields(Decorators), parentType, driverType);
        }

        private void SetFields(IBaseElement parent, List<FieldInfo> fields, Type parentType, DriverType driverType)
        {
            fields.Where(field => Decorators.ToList().Any(type => type.IsAssignableFrom(field.FieldType))).ToList()
                .ForEach(field =>
                {
                    var type = field.FieldType;
                    var instance = typeof(IPage).IsAssignableFrom(type)
                        ? GetInstancePage(parent, field, type, parentType)
                        : GetInstanceElement(parent, type, parentType, field, driverType);
                    instance.Name = field.GetElementName();
                    //instance.DriverType = driverType;
                    instance.Parent = parent;
                    field.SetValue(parent, instance);
                    SetFields(instance, instance.GetFields(Decorators, StopTypes), instance.GetType(), driverType);
                });
        }
        
        protected IPage GetInstancePage(object parent, FieldInfo field, Type type, Type parentType)
        {
            var instance = (IPage)(field.GetValue(parent)
                                           ?? Activator.CreateInstance(type));
            var pageAttribute = field.GetAttribute<PageAttribute>();
            var site = parentType.GetCustomAttribute<SiteAttribute>(false);
            if (!Jdi.HasDomain && site?.Domain != null)
            {
                Jdi.Domain = site.Domain;
            }
            else if (site?.DomainProviderMethodName != null && site.DomainProviderType != null)
            {
                Jdi.Domain = site.GetDomainFunc.Invoke();
            }
            instance.Url = pageAttribute.Url;
            instance.UrlTemplate = pageAttribute.UrlTemplate;
            instance.Title = pageAttribute.Title;
            instance.CheckUrlType = pageAttribute.UrlCheckType;
            instance.CheckTitleType = pageAttribute.TitleCheckType;
            return instance;
        }

        protected IBaseElement GetInstanceElement(IBaseElement parent, Type type, Type parentType, FieldInfo field,
            DriverType driverType)
        {
            var instance = (IBaseElement)field.GetValue(parent);
            type = type.IsInterface ? MapInterfaceToElement.ClassFromInterface(type) : type;
            var element = (UIElement) instance ?? UIElementFactory.CreateInstance(type, field.GetFindsBy());
            var checkedAttr = field.GetAttribute<IsCheckedAttribute>();
            if (checkedAttr != null && typeof(ICheckBox).IsAssignableFrom(field.FieldType))
            {
                var checkBox = (CheckBox)element;
                checkBox.SetIsCheckedFunc(checkedAttr.CheckedDelegate);
            }
            if (parent == null || type != null)
            {
                var frameBy = field.GetCustomAttribute<FrameAttribute>(false)?.FrameLocator;
                if (frameBy != null)
                    element.FrameLocator = frameBy;
                By template;
                if (element.Parent is Form<IConvertible> form && !element.HasLocator
                                                && (template = form.LocatorTemplate) != null)
                    element.Locator = template.FillByTemplate(field.Name);
            }
            return element;
        }
    }
}