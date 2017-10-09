
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


	
	
	
	[Serializable]
	[DataContract(Namespace="")] public partial class Entry : global::System.ICloneable, global::System.IEquatable<Entry>
	{
		
		
		
		public override string ToString()
		{
			

			return base.ToString();
		}

		
		internal void __InternalPrepareInsert()
		{
			
		}
		internal void __InternalPrepareUpdate()
		{
			
		}
		internal void __InternalPrepareDelete()
		{
			
		}
		
		internal long _InternalGetSizeApproximation()
		{
			long size = 9; 
			return size;
		}
		object ICloneable.Clone() { return Clone(); }
		
		public Entry()
			
		{
			
			this._DataType = global::UseCase1.DataType.String;
			
		}

		
		public override int GetHashCode()
		{
			return "global::UseCase1.Entry".GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Entry);
		}

		public bool Equals(Entry other)
		{
			if(other == null)
				return false;
			return true	
				&& other.Description == this.Description
				&& other.ColumnName == this.ColumnName
				&& (this._DataType == null && other._DataType == null 
						|| this._DataType != null && this._DataType.Equals(other._DataType))	;
		}

		private Entry(Entry other)
		{
			
				this._Description = other._Description;
				this._ColumnName = other._ColumnName;
				this._DataType = other._DataType;
		}

		public Entry Clone()
		{
			return new Entry(this);
		}
		
		
		[DataMember(EmitDefaultValue=false,Name="Description")]
		internal string _Description = string.Empty;

		public string Description
		{
			
			get 
			{
				
				return this._Description; 
			}
			
			set 
			{
				
				this._Description = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="ColumnName")]
		internal string _ColumnName = string.Empty;

		public string ColumnName
		{
			
			get 
			{
				
				return this._ColumnName; 
			}
			
			set 
			{
				
				this._ColumnName = value; 
				
			}
		}

		
		
		[DataMember(EmitDefaultValue=false,Name="DataType")]
		internal global::UseCase1.DataType _DataType;

		public global::UseCase1.DataType DataType
		{
			
			get 
			{
				
				return this._DataType; 
			}
			
			set 
			{
				
				
				if(value == null) 
					throw new ArgumentNullException("Property DataType can't be null");
				this._DataType = value; 
				
			}
		}

		
		
		
		[System.Runtime.Serialization.OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			

			
			var locator = context.Context as global::System.IServiceProvider;
			if (locator == null) return;
			if(DataType == null) throw new ArgumentException("In value global::UseCase1.Entry, property DataType can't be null");
		}

		
		internal Entry(IServiceProvider locator)
			
		{
			
			
		}

	}

}
