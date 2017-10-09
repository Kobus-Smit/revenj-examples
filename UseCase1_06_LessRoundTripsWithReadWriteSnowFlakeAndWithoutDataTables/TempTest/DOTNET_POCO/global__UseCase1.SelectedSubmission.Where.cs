
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	partial class SelectedSubmission
	{

	
	[DataContract(Namespace="")] public class Where 
	{
		
		
		public Where(string uri = default(string))
			
		{
			
			this.uri = uri;
			
		}

		
		public Where()
			
		{
			
			
		}

		
		public Expression<Func<global::UseCase1.SelectedSubmission, bool>> IsSatisfied 
		{ 
			get 
			{
				return it =>  it.URI == uri;
			}
		}

		internal Func<global::UseCase1.SelectedSubmission, bool> _HelperFunctionIsSatisfiedBy
		{ 
			get 
			{
				return it =>  it.URI == uri;
			}
		}

		
		
		[DataMember(Name="uri")]
		internal string _uri = string.Empty;

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

	}

	}

}
