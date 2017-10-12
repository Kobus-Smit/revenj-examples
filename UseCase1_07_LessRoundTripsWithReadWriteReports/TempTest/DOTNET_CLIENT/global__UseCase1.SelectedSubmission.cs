
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	
	
	using Revenj.DomainPatterns;
	using Revenj;


	
	
	
	[DataContract(Namespace="")] public partial class SelectedSubmission : global::Revenj.DomainPatterns.IReport<global::UseCase1.SelectedSubmission.Result>
	{
		
		
		public SelectedSubmission()
			
		{
			
			
		}

		
		
		[DataMember(Name="uri")]
		internal string _uri;

		public string uri
		{
			
			get 
			{
				
				return this._uri; 
			}
			
			set 
			{
				
				this._uri = value; 
				
			}
		}

		private global::UseCase1.Submission Submission;
		
		public Result Populate(IServiceProvider locator = null)
		{
			var proxy = (locator ?? Static.Locator).Resolve<IReportingProxy>();
			return proxy.Populate(this).Result; 
		}
	}

}
