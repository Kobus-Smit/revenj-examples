using AcmeCorp.Common;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using UseCase1.App.Common.Classes;
using static UseCase1.App.Service.Plugin.Helpers.DatabaseHelper;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class SaveSubmission : BaseServerCommand<SelectedSubmissionExtra, string>
    {
        public SaveSubmission(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
        }

        public override string Execute(SelectedSubmissionExtra subm)
        {
            var dataTable = subm.InputsTable.Copy();
            dataTable.TableName = subm.Schema.ToDoubleQuotedString() + @".""Input""";

            var submission = context.Find<Submission>(subm.URI);
            //TODO selectedSubmission.Comments DOES contain changes made at Client side because SelectedSubmissionExtra have setters.
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