using System.Collections.Generic;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;

namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class DeleteAllAndInsertDemoData : BaseServerCommand<string, string>
    {
        public DeleteAllAndInsertDemoData(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
        }

        //TODO Is it possible to have a IServerService that does not have any Input and Output? for example: public override void Execute()
        public override string Execute(string dummy)
        {
            //TODO Is there a better way to bulk delete?
            context.Delete(context.Query<Submission>());
            context.Delete(context.Query<Customer>());
            context.Delete(context.Query<Form>());
            context.Delete(context.Query<FormGroup>());

            var group1 = new FormGroup { Name = "Group 1" };
            context.Create(group1);
            var group2 = new FormGroup { Name = "Group 2" };
            context.Create(group2);

            var FormA = new Form
            {
                Name = "Form ABC",
                Schema = "FormABC",
                Group = group1,
                Status = FormStatus.New,
                Inputs = new List<Entry>
                {
                    new Entry { Description = "Year you were born?", ColumnName = "BirthYear", DataType = DataType.Int },
                    new Entry { Description = "How many cars?", ColumnName = "NumberOfCars", DataType = DataType.Int }
                },
                Outputs = new List<Entry>
                {
                    new Entry { Description = "ABC", ColumnName = "ABC", DataType = DataType.Decimal },
                    new Entry { Description = "XYZ", ColumnName = "XYZ", DataType = DataType.Decimal },
                    new Entry { Description = "HasQQQ", ColumnName = "HasQQQ", DataType = DataType.Bool }
                }
            };
            context.Create(FormA);

            var FormB = new Form
            {
                Name = "Form XYZ",
                Schema = "FormXYZ",
                Group = group1,
                Status = FormStatus.PendingApproval,
                Inputs = new List<Entry>
                {
                    new Entry { Description = "When was your last purchase?", ColumnName = "LastPurchase", DataType = DataType.DateTime },
                    new Entry { Description = "JKhdk?", ColumnName = "JKhdk", DataType = DataType.String },
                    new Entry { Description = "Qjfs?", ColumnName = "Qjfs", DataType = DataType.Int }
                },
                Outputs = new List<Entry>
                {
                    new Entry { Description = "Rgflkj", ColumnName = "Rgflkj", DataType = DataType.Int },
                    new Entry { Description = "XYZ", ColumnName = "XYZ", DataType = DataType.Decimal },
                }
            };
            context.Create(FormB);


            var cust1 = new Customer { Name = "John Doe", RegistrationNumber = 194324323 };
            context.Create(cust1);

            var cust2 = new Customer { Name = "Jane Doe", RegistrationNumber = 473824234 };
            context.Create(cust2);

            var cust3 = new Customer { Name = "GI Joe", RegistrationNumber = 771777177 };
            context.Create(cust3);

            context.Create(new Submission { Customer = cust1, Form = FormA, Comments = "Comment 1"});
            context.Create(new Submission { Customer = cust1, Form = FormB });
            context.Create(new Submission { Customer = cust2, Form = FormA });
            context.Create(new Submission { Customer = cust3, Form = FormA });

            return "";
        }

    }
}