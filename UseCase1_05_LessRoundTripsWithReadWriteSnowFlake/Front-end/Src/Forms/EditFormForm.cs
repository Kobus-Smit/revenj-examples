using System;
using System.Linq;
using AcmeCorp.Common.WinForms;

namespace UseCase1.App.WinForms.Forms
{
    public partial class EditFormForm : System.Windows.Forms.Form
    {
        private Form form;

        public EditFormForm() => InitializeComponent();

        public static void Edit(string formURI) => new EditFormForm().DoEdit(formURI);

        private void DoEdit(string formURI)
        {
            form = Form.Find(formURI);
            formBindingSource.DataSource = form;
            groupBindingSource.DataSource = FormGroup.FindAll();
            Text = form.Name;
            statusComboBox.Items.AddRange(Enum.GetValues(typeof(FormStatus)).Cast<object>().ToArray());
            statusComboBox.SelectedItem = form.Status;

            ShowDialog(Program.MainForm);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            form.Group = (FormGroup)groupBindingSource.Current;
            form.Status = (FormStatus)statusComboBox.SelectedItem;
            form.Update();

            //TODO Call Server Command to create dsl files according to Form Inputs/Outputs and apply a migration to create the database structures

            MessageBoxInfo.Show("Saved.");
        }
    }
}
