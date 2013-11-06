﻿using Fabric.New.Domain.Schemas.Utils;
using Fabric.New.Domain.Schemas.Vertices;

namespace Fabric.New.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class MemberAuthenticatedByOauthAccess : EdgeSchema<MemberSchema, OauthAccessSchema> {

		public EdgeProperty<OauthAccessSchema, long> Timestamp { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberAuthenticatedByOauthAccess() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("AuthenticatedBy", "ab");
			CreateFromOtherDirection = true;

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp));
		}

	}

}