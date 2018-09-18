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
            resultsTextBox.AppendText($"{commentTextBox.Text}, Size = {mbTextBox.Text}MB... ");
            var sw = Stopwatch.StartNew();
            var provider = Client.Start("http://localhost:8999/", null);
            var standardProxy = provider.Resolve<IStandardProxy>();
            var result = standardProxy.Execute<int, test_data>("SimpleMapping.App.Service.Plugin.GetTestData", Convert.ToInt32(mbTextBox.Text)).Result;
            sw.Stop();
            resultsTextBox.AppendText(sw.Elapsed + NewLine);
        }
    }
}
