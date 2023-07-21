using AsbtCore.UtilsV2;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CashBackApi.ControlPanel
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            if (FrmLogin.Execute() == DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ee = e.ExceptionObject as Exception;
            var li = new LogItem
            {
                App = "ControlPanel",
                Stacktrace = ee.GetStackTrace(5),
                Message = ee.GetAllMessages(),
                Method = "Program.CurrentDomain_UnhandledException"
            };
            CLogJson.Write(li);
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ee = e.Exception;
            var li = new LogItem
            {
                App = "ControlPanel",
                Stacktrace = ee.GetStackTrace(5),
                Message = ee.GetAllMessages(),
                Method = "Program.Application_ThreadException"
            };
            CLogJson.Write(li);
        }
    }
}
