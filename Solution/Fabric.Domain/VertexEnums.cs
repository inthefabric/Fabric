using System;
using System.Collections.Generic;
using System.Linq;

namespace Fabric.Domain {

	/*================================================================================================*/
	public enum VertexFabType {
		BaseClass = 0,
		Unspecified,
		App,
		Class,
		Instance,
		Url,
		User,
		Member,
		MemberTypeAssign,
		Factor,
		Email,
		OauthAccess,
		OauthDomain,
		OauthGrant,
		OauthScope
	}

	/*================================================================================================*/
	public static class VertexFabTypeUtil {

		public static IDictionary<Type, VertexFabType> TypeMap;
		public static IDictionary<byte, VertexFabType> ValueMap;

		private static readonly bool IsInit = Init();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool Init() {
			TypeMap = new Dictionary<Type, VertexFabType>();
			TypeMap.Add(typeof(App), VertexFabType.App);
			TypeMap.Add(typeof(Class), VertexFabType.Class);
			TypeMap.Add(typeof(Instance), VertexFabType.Instance);
			TypeMap.Add(typeof(Url), VertexFabType.Url);
			TypeMap.Add(typeof(User), VertexFabType.User);

			TypeMap.Add(typeof(Member), VertexFabType.Member);
			TypeMap.Add(typeof(MemberTypeAssign), VertexFabType.MemberTypeAssign);

			TypeMap.Add(typeof(Factor), VertexFabType.Factor);

			TypeMap.Add(typeof(Email), VertexFabType.Email);
			TypeMap.Add(typeof(OauthAccess), VertexFabType.OauthAccess);
			TypeMap.Add(typeof(OauthDomain), VertexFabType.OauthDomain);
			TypeMap.Add(typeof(OauthGrant), VertexFabType.OauthGrant);
			TypeMap.Add(typeof(OauthScope), VertexFabType.OauthScope);
			
			////

			ValueMap = new Dictionary<byte, VertexFabType>();
			IEnumerable<VertexFabType> types = Enum.GetValues(typeof(VertexFabType)).Cast<VertexFabType>();

			foreach ( VertexFabType type in types ) {
				ValueMap.Add((byte)type, type);
			}

			return true;
		}
		
	}
}