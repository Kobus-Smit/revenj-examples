using System.Linq;
using AcmeCorp.Common;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using UseCase1.App.Common.Helpers;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class LoadSubmission : BaseServerCommand<string, SelectedSubmission.Result>
    {
        public LoadSubmission(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
        }

        public override SelectedSubmission.Result Execute(string submissionURI)
        {
            var ss = context.Populate(new SelectedSubmission { uri = submissionURI });
            var columns = ss.Submission.Form.Inputs.Select(i => i.ColumnName.ToDoubleQuotedString()).ToCSV();
            var inputTable = databaseQuery.Fill($@"SELECT ""ID"",""SubmissionID"", {columns} FROM ""{ss.Submission.Form.Schema}"".""Input"" WHERE ""SubmissionID"" = '{submissionURI}'");
            inputTable.TableName = "Input";
            ss.Submission.InputsBytes = inputTable.ToByteArray();
            return ss;
        }
    }
}