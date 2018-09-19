using System;
using System.Diagnostics;
using System.Windows.Forms;
using Revenj;
using test;
using static System.Environment;

namespace SimpleMapping.App.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            resultsTextBox.AppendText($"{commentTextBox.Text}, Size = {kbTextBox.Text}KB... ");
            var sw = Stopwatch.StartNew();
            var provider = Client.Start("http://localhost:8999/", null);
            var standardProxy = provider.Resolve<IStandardProxy>();
            var result = standardProxy.Execute<int, test_data>("SimpleMapping.App.Service.Plugin.GetTestData", Convert.ToInt32(kbTextBox.Text)).Result;
            sw.Stop();
            resultsTextBox.AppendText(sw.Elapsed + "  ");
            sw = Stopwatch.StartNew();
            var length = standardProxy.Execute<test_data, int>("SimpleMapping.App.Service.Plugin.SetTestData", result).Result;
            sw.Stop();
            resultsTextBox.AppendText(sw.Elapsed + NewLine);

        }
    }
}
