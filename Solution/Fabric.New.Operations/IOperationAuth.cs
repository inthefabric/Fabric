﻿using Fabric.New.Domain;

namespace Fabric.New.Operations {

	/*================================================================================================*/
	public interface IOperationAuth {
		
		Member ActiveMember { get; }
		long? ActiveMemberId { get; }
		long? CookieUserId { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		void SetOauthToken(string pToken);

		/*--------------------------------------------------------------------------------------------*/
		void SetCookieUserId(long pUserId);

	}

}