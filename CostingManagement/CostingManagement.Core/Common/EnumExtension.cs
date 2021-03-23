﻿using System;
using System.Reflection;
using System.Resources;

namespace CostingManagement.Core.Common
{
    public static class EnumExtension
    {
        /// <summary>
        /// Get display name for each enumeration value
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetText(this Enum enumValue)
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            DisplayNameAttribute[] attributes =
                (DisplayNameAttribute[])fi.GetCustomAttributes(
                typeof(DisplayNameAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return GetDisplayName(attributes[0].ResourceType, attributes[0].ResourceName);
            else
                return enumValue.ToString();
        }

        /// <summary>
        /// Internal method that gets enumeration display name from the resurce file using Resource Type and Resource Key
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        public static string GetDisplayName(Type resourceType, string resourceKey)
        {

            var _resourceManager = new ResourceManager(resourceType);
            string displayName = _resourceManager.GetString(resourceKey);
            return string.IsNullOrWhiteSpace(displayName) ? string.Format("[[{0}]]", resourceKey) : displayName;
        }
    }
}
