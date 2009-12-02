namespace WinFormsWebBrowserTester
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    static class Program
    {
        public static object Name {get; private set;}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Name = Assembly.GetExecutingAssembly().GetName().Name;

            try
            {
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                Trace(ex);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            object exceptionObject = e.ExceptionObject;
            Trace(exceptionObject);
        }

        private static void Trace(object exceptionObject)
        {
            global::System.Diagnostics.Trace.WriteLine(
                            exceptionObject,
                            string.Format("{0}-AppDomain::UnhandledException", Name));
        }
    }
}
