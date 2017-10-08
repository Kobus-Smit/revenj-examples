using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using AutoMapper;
using UseCase1.App.Common.Helpers;

namespace UseCase1.App.Common.Classes
{
    [DataContract]
    public class SelectedSubmissionExtra
    {
        [DataMember] public string URI { get; set; }
        [DataMember] public string Customer { get; set; }
        [DataMember] public string Form { get; set; }
        [DataMember] public string Schema { get; set; }
        [DataMember] public List<Entry> FormInputs { get; set; }
        [DataMember] public string Group { get; set; }
        [DataMember] public string Comments { get; set; }
        [DataMember] public DateTime Date { get; set; }
        [DataMember] public byte[] InputsTableBytes;

        public SelectedSubmissionExtra()
        {
            
        }

        public static SelectedSubmissionExtra Create(SelectedSubmission selectedSubmission, byte[] inputsTableBytes)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<SelectedSubmission, SelectedSubmissionExtra>(); });

            var result = Mapper.Map<SelectedSubmission, SelectedSubmissionExtra>(selectedSubmission);
            result.InputsTableBytes = inputsTableBytes;
            return result;
        }

        public DataTable InputsTable
        {
            get => InputsTableBytes?.ToDataTable();
            set => InputsTableBytes = value?.ToByteArray();
        }


    }
}