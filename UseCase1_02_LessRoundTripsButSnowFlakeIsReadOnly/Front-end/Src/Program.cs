using System;
using System.Windows.Forms;
using Revenj;
using UseCase1.App.WinForms.Forms;

namespace UseCase1.App.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new MainForm();
            Application.Run(MainForm);
        }


        public static MainForm MainForm;

        public static IServiceProvider ConnectToService() => Client.Start("http://localhost:8999/", null);

        public static IStandardProxy GetStandardProxy() => ConnectToService().Resolve<IStandardProxy>();
    }
}
