namespace UseCase1.App.WinForms.Classes
{
    public static class ServerCommand
    {
        public static SelectedSubmission.Result LoadSubmission(string submissionURI) => nameof(LoadSubmission).Execute<string, SelectedSubmission.Result>(submissionURI);
        public static string SaveSubmission(SelectedSubmission.Result value) => nameof(SaveSubmission).Execute<SelectedSubmission.Result, string>(value);
                
        //public static string DeleteAllAndInsertDemoData() => "DeleteAllAndInsertDemoData".Execute<string, string>(null); //TODO A null argument throws a WebException: Length Required
        public static string DeleteAllAndInsertDemoData() => "DeleteAllAndInsertDemoData".Execute<string, string>(string.Empty);

        private const string ServerNamespace = "UseCase1.App.Service.Plugin.ServerCommand.";
       
        public static bool Execute(this string serverCommand) => Program.GetStandardProxy().Execute<string, bool>(ServerNamespace + serverCommand, "").Result;
        public static T Execute<T>(this string serverCommand, string argument) => Program.GetStandardProxy().Execute<string, T>(ServerNamespace + serverCommand, argument).Result;
        public static T Execute<T>(this string serverCommand, decimal argument) => Program.GetStandardProxy().Execute<decimal, T>(ServerNamespace + serverCommand, argument).Result;
        public static TResult Execute<TArgument, TResult>(this string serverCommand, TArgument argument) => Program.GetStandardProxy().Execute<TArgument, TResult>(ServerNamespace + serverCommand, argument).Result;
    }
}