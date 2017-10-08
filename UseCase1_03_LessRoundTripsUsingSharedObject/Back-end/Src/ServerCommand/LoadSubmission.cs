extern alias common;
using System;
using System.Linq;
using AcmeCorp.Common;
using AutoMapper;
using Revenj.DatabasePersistence;
using Revenj.DomainPatterns;
using UseCase1.App.Common.Classes;
using UseCase1.App.Common.Helpers;
using Cmn = common::UseCase1;
namespace UseCase1.App.Service.Plugin.ServerCommand
{
    public class LoadSubmission : BaseServerCommand<string, SelectedSubmissionExtra>
    {
        public LoadSubmission(IDataContext context, IDatabaseQuery databaseQuery) : base(context, databaseQuery)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SelectedSubmission, Cmn.SelectedSubmission>();
                cfg.CreateMap<Entry, Cmn.Entry>();
            });
        }

        public override SelectedSubmissionExtra Execute(string subm)
        {
            var selectedSubmission = context.Search(new SelectedSubmission.Where(subm)).Single();
            var columns = selectedSubmission.FormInputs.Select(i => i.ColumnName.ToDoubleQuotedString()).ToCSV();
            var table = databaseQuery.Fill($@"SELECT ""ID"",""SubmissionID"", {columns} FROM ""{selectedSubmission.Schema}"".""Input"" WHERE ""SubmissionID"" = '{subm}'");
            table.TableName = "Input";
            return SelectedSubmissionExtra.Create(Mapper.Map<SelectedSubmission, Cmn.SelectedSubmission>(selectedSubmission) , table.ToByteArray());
        }
    }
}