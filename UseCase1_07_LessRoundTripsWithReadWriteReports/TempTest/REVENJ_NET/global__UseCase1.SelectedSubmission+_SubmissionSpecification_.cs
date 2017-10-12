
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	
	
using global::Revenj;
using global::Revenj.DomainPatterns;
using global::Revenj.Extensibility;


	
	
	partial class SelectedSubmission
	{

	
	private class _SubmissionSpecification_ : global::Revenj.DomainPatterns.ISpecification<global::UseCase1.Submission>
	{
		
		
		private readonly global::UseCase1.SelectedSubmission Data;
		public _SubmissionSpecification_(global::UseCase1.SelectedSubmission data) { this.Data = data; }
		public Expression<Func<global::UseCase1.Submission, bool>> IsSatisfied { get { return Data._filterSubmission; } }
	}

	}

}
