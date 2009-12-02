using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Pajocomo.Windows.Forms
{
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class ResourcesCategoryAttribute : CategoryAttribute
    {
        public ResourcesCategoryAttribute(string category)
            : base(category)
        {
        }

        protected override string GetLocalizedString(string value)
        {
            return ResourcesHelper.GetString(value);
        }
    }
}
