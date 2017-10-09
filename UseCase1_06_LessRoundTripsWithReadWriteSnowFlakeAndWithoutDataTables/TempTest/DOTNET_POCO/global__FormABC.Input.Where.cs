
namespace FormABC
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	partial class Input
	{

	
	[DataContract(Namespace="")] public class Where 
	{
		
		
		public Where(string submissionURI = default(string))
			
		{
			
			this.submissionURI = submissionURI;
			
		}

		
		public Where()
			
		{
			
			
		}

		
		public Expression<Func<global::FormABC.Input, bool>> IsSatisfied 
		{ 
			get 
			{
				return it =>  it.SubmissionURI == submissionURI;
			}
		}

		internal Func<global::FormABC.Input, bool> _HelperFunctionIsSatisfiedBy
		{ 
			get 
			{
				return it =>  it.SubmissionURI == submissionURI;
			}
		}

		
		
		[DataMember(Name="submissionURI")]
		internal string _submissionURI = string.Empty;

		public string submissionURI
		{
			
			get 
			{
				
				return this._submissionURI; 
			}
			
			set 
			{
				
				this._submissionURI = value; 
				
			}
		}

	}

	}

}
