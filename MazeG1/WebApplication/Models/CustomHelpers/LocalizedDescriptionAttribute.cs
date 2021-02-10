using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using WebApplication.Localization;

namespace WebApplication.Models.CustomHelpers
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private readonly string _resourceKey;
        private readonly ResourceManager _resource;
        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resource = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string displayName = _resource.GetString(_resourceKey, Home.Culture);
                return string.IsNullOrEmpty(displayName)
                    ? string.Format("{0}", _resourceKey)
                    : displayName;
            }
        }
    }
}