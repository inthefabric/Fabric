﻿using Fabric.Domain.Schemas.Utils;
using Fabric.Domain.Schemas.Vertices;

namespace Fabric.Domain.Schemas.Edges {
	
	/*================================================================================================*/
	public class UserDefinesMemberSchema : EdgeSchema<UserSchema, MemberSchema> {

		public EdgeProperty<MemberSchema, long, long> Timestamp { get; private set; }
		public EdgeProperty<MemberSchema, byte, byte> MemberType { get; private set; }
		public EdgeProperty<MemberSchema, MemberDefinedByAppSchema, long, long>
			AppId { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserDefinesMemberSchema() : base(EdgeQuantity.ZeroOrMore) {
			SetNames("Defines", "d");
			CreateFromOtherDirection = typeof(MemberDefinedByUserSchema);
			Sort = SortType.Desc;

			////

			Timestamp = Prop("Timestamp", "ts", (x => x.Timestamp), (x => x.FabTimestamp));
			Timestamp.SortIndex = 0;

			MemberType = Prop("MemberType", "mt", (x => x.MemberType), (x => x.FabMemberType));
			MemberType.SortIndex = 1;

			AppId = PropFromEdge<MemberDefinedByAppSchema>("AppId", "pi");
			AppId.SortIndex = 2;
		}

	}

}