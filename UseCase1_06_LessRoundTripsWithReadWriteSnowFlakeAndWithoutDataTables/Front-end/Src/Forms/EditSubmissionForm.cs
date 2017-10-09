using System;
using System.Data;
using System.Windows.Forms;
using AcmeCorp.Common.WinForms;
using UseCase1.App.WinForms.Classes;

namespace UseCase1.App.WinForms.Forms
{
    public partial class EditSubmissionForm : System.Windows.Forms.Form
    {
        private SelectedSubmission selectedSubmission;

        public EditSubmissionForm() => InitializeComponent();

        public static void Edit(string submissionURI) => new EditSubmissionForm().DoEdit(submissionURI);

        private void DoEdit(string submissionURI)
        {
            var result = ServerCommand.LoadSubmission(submissionURI);
            selectedSubmission = result.selectedSubmission;
            submissionBindingSource.DataSource = selectedSubmission;
            inputsGrid.AutoGenerateColumns = true;

            //TODO How to deserialize result.inputs again?
            //inputsBindingSource.DataSource = result.inputs;

            //TODO The next 3 lines DOES NOT causes 3 round trips to the server...
            customerTextBox.Text = selectedSubmission.Customer;
            formTextBox.Text = selectedSubmission.Form;
            groupTextBox.Text = selectedSubmission.Group;

            dateTextBox.Text = selectedSubmission.Date.ToLongDateString();

            ShowDialog(Program.MainForm);
        }

        private void EditSubmissionForm_Shown(object sender, EventArgs e)
        {
            inputsGrid.Columns[0].Visible = false;
            inputsGrid.Columns[1].Visible = false;
        }

        private void inputsGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["SubmissionID"].Value = selectedSubmission.URI;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ServerCommand.SaveSubmission((selectedSubmission, (DataTable)inputsBindingSource.DataSource));
            MessageBoxInfo.Show("Saved.");
        }
    }
}
