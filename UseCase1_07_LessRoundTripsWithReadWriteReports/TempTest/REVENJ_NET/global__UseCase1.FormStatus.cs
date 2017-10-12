
namespace UseCase1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Text;
	using System.Threading;
	using System.Runtime.Serialization;
	

	
	
	
	[DataContract]
	public enum FormStatus
	{	
	[EnumMember] New,
	[EnumMember] PendingApproval,
	[EnumMember] Approved,
	[EnumMember] NotApproved,
	[EnumMember] Archived,
	}
}
