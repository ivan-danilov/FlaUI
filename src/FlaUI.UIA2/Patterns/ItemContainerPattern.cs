﻿using FlaUI.Core;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.UIA2.Tools;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2.Patterns
{
    public class ItemContainerPattern : PatternBase<UIA.ItemContainerPattern>, IItemContainerPattern
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.ItemContainerPattern.Pattern.Id, "ItemContainer");

        public ItemContainerPattern(BasicAutomationElementBase basicAutomationElement, UIA.ItemContainerPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public AutomationElement FindItemByProperty(AutomationElement startAfter, PropertyId property, object value)
        {
            var foundNativeElement = NativePattern.FindItemByProperty(
                    startAfter == null ? null : NativeValueConverter.ToNative(startAfter),
                    property == null ? null : UIA.AutomationProperty.LookupById(property.Id), NativeValueConverter.ToNative(value));
            return NativeValueConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, foundNativeElement);
        }
    }
}