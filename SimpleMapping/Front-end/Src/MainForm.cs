using System;
using System.Windows.Forms;
using Revenj;

namespace SimpleMapping.App.WinForms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider provider;
        private readonly IStandardProxy standardProxy;

        public MainForm()
        {
            InitializeComponent();
            provider = Client.Start("http://localhost:8999/", null);
            standardProxy = provider.Resolve<IStandardProxy>();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            var cp = new CommonParam { Person = new PersonVM { Name = "Aaaa" }, Other1 = true };
            var result = standardProxy.Execute<CommonParam, string>("SimpleMapping.App.Service.Plugin.TestCommonParameter", cp).Result;

            var person = new Person { Name = "Bbbb" }.Create();
            
            //How do I get this working?
            Common.Test.Abc(person);
        }
    }
}
