using System;
using System.Collections.Generic;
using System.Text;

namespace Pajocomo.Windows.Forms
{
    internal class ResourcesHelper
    {
		private ResourcesHelper() {}

		private static readonly System.Resources.ResourceManager localResourceManager;
		private static readonly System.Resources.ResourceManager baseResourceManager;

        public const string ActiveXBaseNoCastToInterface = "ActiveXBaseNoCastToInterface";
        public const string ActiveXWindowlessControl = "AXWindowlessControl";
        public const string ThreadMustBeSTA = "ThreadMustBeSTA";
        
        static ResourcesHelper()
		{
			try
			{
                localResourceManager = new System.Resources.ResourceManager(typeof(ResourcesHelper).Namespace, typeof(ResourcesHelper).Assembly);
                baseResourceManager = new System.Resources.ResourceManager(typeof(System.Windows.Forms.Control).Namespace, typeof(System.Windows.Forms.Control).Assembly);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Trace.WriteLine(ex.Message, "WebBrowserControl");
				localResourceManager = null;
			}
		}

		public static object GetObject(string name)
		{
			try
			{
                if (localResourceManager != null)
				{
                    object obj = localResourceManager.GetObject(name);
                    if (obj == null && baseResourceManager != null)
                    {
                        obj = baseResourceManager.GetObject(name);
                        if (obj != null)
                        {
                            return obj;
                        }
                    }
				}
			}
			catch  { }
            return null;
		}

		public static T Get<T>(string name)
		{
            return (T)GetObject(name);
		}

		public static string GetString(string name)
		{
			try
			{
                if (localResourceManager != null)
				{
                    string str = localResourceManager.GetString(name);
                    if (str == null && baseResourceManager != null)
                    {
                        str = baseResourceManager.GetString(name);
                        if (str != null)
                        {
                            return str;
                        }
                    }
				}
			}
            catch { }
            return name;
		}

		public static string GetString(string name, params object[] args)
		{
            return string.Format(GetString(name), args);
		}
    }
}
