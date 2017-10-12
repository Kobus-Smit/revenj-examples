using System.Windows.Forms;

namespace UseCase1.App.WinForms.Forms
{
    public partial class OpenSubmissionForm : System.Windows.Forms.Form
    {
        public OpenSubmissionForm()
        {
            InitializeComponent();
        }

        public static bool Select(out string formID) => new OpenSubmissionForm().DoSelect(out formID);

        private bool DoSelect(out string formID)
        {
            Program.ConnectToService();
            submissionListBindingSource.DataSource = SubmissionList.FindAll();
            var hasSelected = ShowDialog(Program.MainForm) == DialogResult.OK;
            formID = hasSelected ? ((SubmissionList)submissionListBindingSource.Current).URI : null;
            return hasSelected; 
        }

        private void grid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            openButton.PerformClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (grid.Focused) 
                {
                    openButton.PerformClick();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}