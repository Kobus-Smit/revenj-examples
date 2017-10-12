
namespace _DatabaseConfiguration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	internal partial class DatabaseConverters 
	{
		
		
		
		internal static void Initialize(System.Data.DataTable columnsInfo)
		{
			

			System.Data.DataRow row = null;
			_DatabaseCommon.FactoryUseCase1_FormGroup.FormGroupConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryUseCase1_Form.FormConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryUseCase1_FormList.FormListConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryUseCase1_Entry.EntryConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryUseCase1_Customer.CustomerConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryUseCase1_Submission.SubmissionConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryUseCase1_SubmissionList.SubmissionListConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryFormABC_Input.InputConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryFormABC_Output.OutputConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryFormXYZ_Input.InputConverter.InitializeProperties(columnsInfo);
			_DatabaseCommon.FactoryFormXYZ_Output.OutputConverter.InitializeProperties(columnsInfo);
		}

	}

}
