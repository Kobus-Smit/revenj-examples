using System.Windows.Forms;

namespace UseCase1.App.WinForms.Forms
{
    public partial class OpenFormForm : System.Windows.Forms.Form
    {
        public OpenFormForm()
        {
            InitializeComponent();
        }

        public static bool Select(out string formID) => new OpenFormForm().DoSelect(out formID);

        private bool DoSelect(out string formID)
        {
            Program.ConnectToService();
            formListBindingSource.DataSource = FormList.FindAll();
            var hasSelected = ShowDialog(Program.MainForm) == DialogResult.OK;
            formID = hasSelected ? ((FormList)formListBindingSource.Current).URI : null;
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