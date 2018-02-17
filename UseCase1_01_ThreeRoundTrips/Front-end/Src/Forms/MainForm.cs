using System;
using AcmeCorp.Common.WinForms;
using CryptocoinTracking;
using UseCase1.App.WinForms.Classes;

namespace UseCase1.App.WinForms.Forms
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void createDemoDataButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxQuestion.PromptDefaultNo("Delete all data and insert demo data?"))
            {
                try
                {
                    ServerCommand.DeleteAllAndInsertDemoData();
                    MessageBoxInfo.Show("Done.");
                }
                catch (Exception ex)
                {
                    MessageBoxError.Show(ex.ToString());
                }                
            }
        }

        private void openFormButton_Click(object sender, EventArgs e)
        {
            if (OpenFormForm.Select(out var formID))
                EditFormForm.Edit(formID);
        }

        private void editSubmissionButton_Click(object sender, EventArgs e)
        {
            if (OpenSubmissionForm.Select(out var submissionID))
                EditSubmissionForm.Edit(submissionID);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.ConnectToService();
            var cur = new Currency { Code = "ETH", Name = "Ethereum", Type = CurrencyType.Crypto }.Create();
        }
    }
}
