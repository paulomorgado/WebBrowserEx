using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Pajocomo.Windows.Forms
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class ResourcesDescriptionAttribute : DescriptionAttribute
    {
        public ResourcesDescriptionAttribute(string description)
            : base(description)
        {
        }

        public override string Description
        {
            get
            {
                if (!this.replaced)
                {
                    this.replaced = true;
                    base.DescriptionValue = ResourcesHelper.GetString(base.Description);
                }
                return base.Description;
            }
        }

        private bool replaced;
    }
}
