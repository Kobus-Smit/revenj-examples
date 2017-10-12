using AcmeCorp.Common;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using UseCase1.App.Common.Helpers;
using static UseCase1.App.Service.Plugin.Helpers.DatabaseHelper;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class SaveSubmission : BaseServerCommand<SelectedSubmission.Result, string>
    {
        public SaveSubmission(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
        }

        public override string Execute(SelectedSubmission.Result value)
        {
            context.Update(value.Submission);
            context.Update(value.Submission.Customer);  
            //TODO Note:  internal global::UseCase1.Customer _Customer; must have [DataMember] attribute otherwise the above will not contain changes made at clientside
            

            var subm = value.Submission;
            var inputsTable = subm.InputsBytes.ToDataTable();
            var tableName = subm.Form.Schema.ToDoubleQuotedString() + @".""Input""";
            inputsTable.TableName = tableName;

            //TODO How do I get the NpgsqlConnection? databaseQuery.Connection is internal
            using (var conn = OpenDatabaseConnection())
            {
                conn.ExecuteNonQuery($"DELETE FROM {inputsTable.TableName} WHERE \"SubmissionID\" = {subm.URI.ToSingleQuotedString()}");
                inputsTable.BulkInsert(conn); //TODO This is overkill for this demo :) In my real life project I use BulkInsert for large tables with many rows
            }
            return "";
        }
    }
}