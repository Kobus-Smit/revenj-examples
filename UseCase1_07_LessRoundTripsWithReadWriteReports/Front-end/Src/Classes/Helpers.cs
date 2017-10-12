using System.Windows.Forms;

namespace UseCase1.App.WinForms.Classes
{
    public static class Helpers
    {
        public static void BindTextTo(this TextBox textBox, BindingSource dataSource, string dataMember) => 
            textBox.DataBindings.Add(new Binding("Text", dataSource, dataMember, true, DataSourceUpdateMode.OnPropertyChanged));
    }
}