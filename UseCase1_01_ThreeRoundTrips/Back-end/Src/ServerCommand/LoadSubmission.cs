using System.Linq;
using AcmeCorp.Common;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using UseCase1.App.Common.Helpers;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class LoadSubmission : BaseServerCommand<string, (Submission submission, byte[] inputsTableBytes)>
    {
        public LoadSubmission(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
        }

        public override (Submission submission, byte[] inputsTableBytes) Execute(string submissionURI)
        {
            var submission = context.Find<Submission>(submissionURI);
            var columns = submission.Form.Inputs.Select(i => i.ColumnName.ToDoubleQuotedString()).ToCSV();
            var table = databaseQuery.Fill($@"SELECT ""ID"",""SubmissionID"", {columns} FROM ""{submission.Form.Schema}"".""Input"" WHERE ""SubmissionID"" = '{submissionURI}'");
            table.TableName = "Input";
            return (submission, table.ToByteArray());
        }
    }
}