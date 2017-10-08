using System;
using System.Data;
using System.Windows.Forms;
using AcmeCorp.Common.WinForms;
using UseCase1.App.WinForms.Classes;

namespace UseCase1.App.WinForms.Forms
{
    public partial class EditSubmissionForm : System.Windows.Forms.Form
    {
        private Submission submission;

        public EditSubmissionForm() => InitializeComponent();

        public static void Edit(string submissionURI) => new EditSubmissionForm().DoEdit(submissionURI);

        private void DoEdit(string submissionURI)
        {
            var result = ServerCommand.LoadSubmission(submissionURI);
            submission = result.submission;
            //TODO This next 3 lines are important but feels like boilerplate to me and if the developer forget to do this it will lazyload.
            submission.Form = result.form;
            submission.Form.Group = result.group;
            submission.Customer = result.customer;

            submissionBindingSource.DataSource = submission;
            inputsGrid.AutoGenerateColumns = true;
            inputsBindingSource.DataSource = result.inputsTable;

            //TODO The next 3 lines DOES NOT causes 3 round trips to the server...
            customerTextBox.Text = submission.Customer.Name;
            formTextBox.Text = submission.Form.Name;
            groupTextBox.Text = submission.Form.Group.Name;

            dateTextBox.Text = submission.Date.ToLongDateString();

            ShowDialog(Program.MainForm);
        }

        private void EditSubmissionForm_Shown(object sender, EventArgs e)
        {
            inputsGrid.Columns[0].Visible = false;
            inputsGrid.Columns[1].Visible = false;
        }

        private void inputsGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["SubmissionID"].Value = submission.ID;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //TODO Don't need to send Form
            ServerCommand.SaveSubmission((submission, (DataTable)inputsBindingSource.DataSource));
            MessageBoxInfo.Show("Saved.");
        }
    }
}
