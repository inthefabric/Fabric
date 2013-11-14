using Fabric.New.Domain;

namespace Fabric.New.Operations {

	/*================================================================================================*/
	public interface IOperationAccess {
		
		Member ActiveMember { get; }
		long? ActiveMemberId { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetOauthToken(string pToken);

	}

}