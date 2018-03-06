
namespace Test
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

	
	using global::Revenj;
	using global::Revenj.DomainPatterns;
	using global::Revenj.Extensibility;


	
	
	partial class XYZ
	{

	
	[DataContract(Namespace="")] public class FindBy : global::Revenj.DomainPatterns.ISpecification<global::Test.XYZ>
	{
		
		
		public FindBy(string from = default(string))
			
		{
			
			this.from = from;
			
		}

		
		public FindBy()
			
		{
			
			
		}

		
		public Expression<Func<global::Test.XYZ, bool>> IsSatisfied 
		{ 
			get 
			{
				return it => it.From == from;
			}
		}

		internal Func<global::Test.XYZ, bool> _HelperFunctionIsSatisfiedBy
		{ 
			get 
			{
				return it => it.From == from;
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="from")]
		internal string _from = string.Empty;

		public string from
		{
			
			
			get 
			{
				
				return this._from; 
			}
			
			set 
			{
				
				this._from = value; 
				
			}
		}

		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
		}

		
		internal FindBy(IServiceProvider locator)
			
		{
			
			
		}

	}

	}

}
