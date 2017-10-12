using System.Windows.Forms;
using static System.Windows.Forms.MessageBoxIcon;
using static System.Windows.Forms.MessageBoxButtons;
using static System.Windows.Forms.MessageBoxDefaultButton;
using MBB = System.Windows.Forms.MessageBoxButtons;
using MB = System.Windows.Forms.MessageBox;
using MBI = System.Windows.Forms.MessageBoxIcon;
using DR = System.Windows.Forms.DialogResult;

namespace AcmeCorp.Common.WinForms
{

    internal static class Const
    {
        public const string Information = nameof(Information);
        public const string Warning = nameof(Warning);
        public const string Error = nameof(Error);
        public const string Confirm = "Confirm";
    }

    public static class MessageBoxInfo
    {
        public static DR Show(string text, string caption = Const.Information) => 
            Show(null, text, caption);

        public static DR Show(IWin32Window owner, string text, string caption = Const.Information) => 
            MB.Show(owner, text, caption, OK, Information);
    }

    public static class MessageBoxWarning
    {
        public static DR Show(string text, string caption = Const.Warning) => 
            Show(null, text, caption);

        public static DR Show(IWin32Window owner, string text, string caption = Const.Warning) => 
            MB.Show(owner, text, caption, OK, Warning);
    }

    public static class MessageBoxError
    {
        public static DR Show(string text, string caption = Const.Error) => 
            Show(null, text, caption);

        public static DR Show(IWin32Window owner, string text, string caption = Const.Error) => 
            MB.Show(owner, text, caption, OK, Error);
    }

    public static class MessageBoxQuestion
    {
        public static DR Show(string text, string caption = Const.Confirm, MBB buttons = YesNoCancel, MBI icon = Question, bool defaultTheNoButton = false) => 
            Show(null, text, caption, buttons, icon, defaultTheNoButton);

        public static DR Show(IWin32Window owner, string text, string caption = Const.Confirm, MBB buttons = YesNoCancel, MBI icon = Question, bool defaultTheNoButton = false) => 
            MB.Show(owner, text, caption, buttons, icon, defaultTheNoButton ? Button2 : Button1);

        public static bool Prompt(string text, string caption = Const.Confirm, MBI icon = Question, bool defaultTheNoButton = false) => 
            Show(null, text, caption, YesNoCancel, icon, defaultTheNoButton) == DR.Yes;

        public static bool Prompt(IWin32Window owner, string text, string caption = Const.Confirm, MBI icon = Question, bool defaultTheNoButton = false) => 
            Show(owner, text, caption, YesNoCancel, icon, defaultTheNoButton) == DR.Yes;

        public static bool PromptDefaultNo(string text, string caption = Const.Confirm, MBI icon = Warning) =>
            Prompt(text, caption, icon, true);

        public static bool PromptDefaultNo(IWin32Window owner, string text, string caption = Const.Confirm, MBI icon = Warning) =>
            Prompt(owner, text, caption, icon, true);
    }
}
