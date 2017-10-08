using System;
using System.Data;
using System.Windows.Forms;
using AcmeCorp.Common.WinForms;
using UseCase1.App.Common.Classes;
using UseCase1.App.WinForms.Classes;

namespace UseCase1.App.WinForms.Forms
{
    public partial class EditSubmissionForm : System.Windows.Forms.Form
    {
        private SelectedSubmissionExtra selectedSubmission;

        public EditSubmissionForm() => InitializeComponent();

        public static void Edit(string submissionURI) => new EditSubmissionForm().DoEdit(submissionURI);

        private void DoEdit(string submissionURI)
        {
            selectedSubmission = ServerCommand.LoadSubmission(submissionURI);
            submissionBindingSource.DataSource = selectedSubmission;
            inputsGrid.AutoGenerateColumns = true;
            inputsBindingSource.DataSource = selectedSubmission.InputsTable;

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
            selectedSubmission.InputsTable = (DataTable)inputsBindingSource.DataSource;
            ServerCommand.SaveSubmission(selectedSubmission);
            MessageBoxInfo.Show("Saved.");
        }
    }
}
