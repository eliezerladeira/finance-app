using FinanceApp.UI.Forms;
using System.Globalization;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace FinanceApp.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
           System.Windows.Forms.Application.Run(new MainForm());
        }
    }
}