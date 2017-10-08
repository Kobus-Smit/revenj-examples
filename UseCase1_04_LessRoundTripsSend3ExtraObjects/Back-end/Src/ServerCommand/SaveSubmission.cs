using AcmeCorp.Common;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using UseCase1.App.Common.Helpers;
using static UseCase1.App.Service.Plugin.Helpers.DatabaseHelper;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class SaveSubmission : BaseServerCommand<(Submission submission, byte[] inputsTableBytes), string>
    {
        public SaveSubmission(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
        }

        public override string Execute((Submission submission, byte[] inputsTableBytes) value)
        {
            var subm = value.submission;
            var tableName = subm.Form.Schema.ToDoubleQuotedString() + @".""Input""";
            var dataTable = value.inputsTableBytes.ToDataTable();
            dataTable.TableName = tableName;
            context.Update(subm);

            //TODO How do I get the NpgsqlConnection? databaseQuery.Connection is internal
            using (var conn = OpenDatabaseConnection())
            {
                conn.ExecuteNonQuery($"DELETE FROM {tableName} WHERE \"SubmissionID\" = {subm.URI.ToSingleQuotedString()}");
                dataTable.BulkInsert(conn); //TODO This is overkill for this demo :) In my real life project I use BulkInsert for large tables with many rows
            }
            return "";
        }
    }
}