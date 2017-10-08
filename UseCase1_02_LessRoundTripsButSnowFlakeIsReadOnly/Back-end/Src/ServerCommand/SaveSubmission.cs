using AcmeCorp.Common;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using UseCase1.App.Common.Helpers;
using static UseCase1.App.Service.Plugin.Helpers.DatabaseHelper;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class SaveSubmission : BaseServerCommand<(SelectedSubmission selectedSubmission, byte[] inputsTableBytes), string>
    {
        public SaveSubmission(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
        }

        public override string Execute((SelectedSubmission selectedSubmission, byte[] inputsTableBytes) value)
        {
            var subm = value.selectedSubmission;
            var dataTable = value.inputsTableBytes.ToDataTable();
            var tableName = subm.Schema.ToDoubleQuotedString() + @".""Input""";
            dataTable.TableName = tableName;

            var submission = context.Find<Submission>(subm.URI);
            //TODO selectedSubmission.Comments does not contain changes made at Client side because SelectedSubmission does not have setters.
            submission.Comments = subm.Comments;
            //TODO Chore: Map/Automap all other relevant properties
            context.Update(submission);

            //TODO How do I get the NpgsqlConnection? databaseQuery.Connection is internal
            using (var conn = OpenDatabaseConnection())
            {
                conn.ExecuteNonQuery($"DELETE FROM {dataTable.TableName} WHERE \"SubmissionID\" = {subm.URI.ToSingleQuotedString()}");
                dataTable.BulkInsert(conn); //TODO This is overkill for this demo :) In my real life project I use BulkInsert for large tables with many rows
            }
            return "";
        }
    }
}