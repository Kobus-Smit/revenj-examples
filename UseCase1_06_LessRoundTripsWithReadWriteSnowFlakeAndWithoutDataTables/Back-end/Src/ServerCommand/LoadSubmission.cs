using System;
using System.IO;
using System.Linq;
using Revenj.Api;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using Revenj.Serialization;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class LoadSubmission : BaseServerCommand<string, (SelectedSubmission selectedSubmission, Stream inputs)>
    {
        public LoadSubmission(IServiceProvider locator, IDataContext context, IDatabaseQuery databaseQuery, IDomainModel domainModel, IWireSerialization serialization, ICommandConverter converter) : base(locator, context, databaseQuery, domainModel, serialization, converter)
        {
        }

        public override (SelectedSubmission selectedSubmission, Stream inputs) Execute(string submissionURI)
        {
            var selectedSubmission = context.Search(new SelectedSubmission.Where(submissionURI)).Single();
            //var columns = selectedSubmission.FormInputs.Select(i => i.ColumnName.ToDoubleQuotedString()).ToCSV();

            var aggregateType = domainModel.Find(selectedSubmission.Schema + ".Input");
            var method = context.GetType().GetMethod("Search").MakeGenericMethod(aggregateType);
            var where = Activator.CreateInstance(aggregateType.GetNestedType("Where"), submissionURI);
            var inputsObj = method.Invoke(context, new []{ where, null, null });

            //TODO How do I serialize inputsObj?
            var inputs = new MemoryStream();
            serialization.Serialize(inputsObj, ThreadContext.Request.Accept, inputs);
                
           
            //var table = databaseQuery.Fill($@"SELECT ""ID"",""SubmissionID"", {columns} FROM ""{selectedSubmission.Schema}"".""Input"" WHERE ""SubmissionID"" = '{submissionURI}'");
            //table.TableName = "Input";
            //return (selectedSubmission, table.ToByteArray());

            return (selectedSubmission, inputs);
        }
    }
}