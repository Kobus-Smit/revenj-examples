using System.Linq;
using AcmeCorp.Common;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using UseCase1.App.Common.Helpers;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class LoadSubmission : BaseServerCommand<string, (Submission submission, Customer customer, Form form, FormGroup group, byte[] inputsTableBytes)>
    {
        public LoadSubmission(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
        }

        public override (Submission submission, Customer customer, Form form, FormGroup group, byte[] inputsTableBytes) Execute(string submissionURI)
        {
            var submission = context.Find<Submission>(submissionURI);
            //TODO Would be nice if I could do something like: 
            //var submission = context.Find<Submission>(submissionURI).Preload(); //to preload all
			//or specify the preload/prefetch path 
			//similiar to LLBLGen Pro
			//https://www.llblgen.com/Documentation/5.2/LLBLGen%20Pro%20RTF/Using%20the%20generated%20code/Adapter/gencode_prefetchpaths_adapter.htm
			//https://github.com/SolutionsDesign/LLBLGen.Linq.Prefetch
            //...then I won't need the next three lines
            var customer = context.Find<Customer>(submission.CustomerURI);
            var form = context.Find<Form>(submission.FormURI);
            var group = context.Find<FormGroup>(form.GroupURI);

            //TODO This does not work because these properties are not marked as DataMembers: 
            //submission.Customer = customer;
            //submission.Form = form;



            //TODO If I do this then how do I pass the anonymous type back to the client? I would have to create a DTO and map it?
            //var data =
            //    (from s in context.Query<Submission>()
            //     from c in context.Query<Customer>()
            //     from f in context.Query<Form>()
            //     from g in context.Query<Form>()
            //     where s.URI == submissionURI
            //           && c.ID == s.CustomerID
            //           && f.ID == s.FormID
            //           && g.ID == f.GroupID
            //     select new {  s, c, f, g }).FirstOrDefault();


            var columns = submission.Form.Inputs.Select(i => i.ColumnName.ToDoubleQuotedString()).ToCSV();
            var table = databaseQuery.Fill($@"SELECT ""ID"",""SubmissionID"", {columns} FROM ""{submission.Form.Schema}"".""Input"" WHERE ""SubmissionID"" = '{submissionURI}'");
            table.TableName = "Input";




            return (submission, customer, form, group, table.ToByteArray());
        }
    }
}