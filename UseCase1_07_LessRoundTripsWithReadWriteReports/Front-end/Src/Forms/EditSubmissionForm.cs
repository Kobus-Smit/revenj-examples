using System;
using System.Data;
using System.Windows.Forms;
using AcmeCorp.Common.WinForms;
using UseCase1.App.Common.Helpers;
using UseCase1.App.WinForms.Classes;

namespace UseCase1.App.WinForms.Forms
{
    public partial class EditSubmissionForm : System.Windows.Forms.Form
    {
        private SelectedSubmission.Result ssr;

        public EditSubmissionForm() => InitializeComponent();

        public static void Edit(string submissionURI) => new EditSubmissionForm().DoEdit(submissionURI);

        private void DoEdit(string submissionURI)
        {
            ssr = ServerCommand.LoadSubmission(submissionURI);
            submissionBindingSource.DataSource = ssr.Submission;
            inputsGrid.AutoGenerateColumns = true;
            inputsBindingSource.DataSource = ssr.Submission.InputsBytes.ToDataTable();

            //TODO The next lines DOES NOT causes round trips to the server...
            customerTextBox.BindTextTo(submissionBindingSource, "Customer.Name");
            formTextBox.BindTextTo(submissionBindingSource, "Form.Name");
            groupTextBox.BindTextTo(submissionBindingSource, "Form.Group.Name");
            emailTextBox.BindTextTo(submissionBindingSource, "Customer.Email");
            dateTextBox.BindTextTo(submissionBindingSource, "Date");

            ShowDialog(Program.MainForm);
        }

        private void EditSubmissionForm_Shown(object sender, EventArgs e)
        {
            inputsGrid.Columns[0].Visible = false;
            inputsGrid.Columns[1].Visible = false;
        }

        private void inputsGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["SubmissionID"].Value = ssr.Submission.URI;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ssr.Submission.InputsBytes = ((DataTable)inputsBindingSource.DataSource).ToByteArray();
            ServerCommand.SaveSubmission(ssr);
            MessageBoxInfo.Show("Saved.");
        }
    }
}
