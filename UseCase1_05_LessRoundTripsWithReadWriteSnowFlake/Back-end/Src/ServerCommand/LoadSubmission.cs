using System.Linq;
using AcmeCorp.Common;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using UseCase1.App.Common.Helpers;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class LoadSubmission : BaseServerCommand<string, (SelectedSubmission selectedSubmission, byte[] inputsTableBytes)>
    {
        public LoadSubmission(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
        }

        public override (SelectedSubmission selectedSubmission, byte[] inputsTableBytes) Execute(string submissionURI)
        {
            var selectedSubmission = context.Search(new SelectedSubmission.Where(submissionURI)).Single();
            var columns = selectedSubmission.FormInputs.Select(i => i.ColumnName.ToDoubleQuotedString()).ToCSV();
            var table = databaseQuery.Fill($@"SELECT ""ID"",""SubmissionID"", {columns} FROM ""{selectedSubmission.Schema}"".""Input"" WHERE ""SubmissionID"" = '{submissionURI}'");
            table.TableName = "Input";
            return (selectedSubmission, table.ToByteArray());
        }
    }
}