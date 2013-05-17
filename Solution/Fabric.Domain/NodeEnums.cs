using System;
using System.Collections.Generic;
using System.Linq;

namespace Fabric.Domain {

	/*================================================================================================*/
	public enum NodeFabType {
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
	public static class NodeFabTypeUtil {

		public static IDictionary<Type, NodeFabType> TypeMap;
		public static IDictionary<byte, NodeFabType> ValueMap;

		private static readonly bool IsInit = Init();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static bool Init() {
			TypeMap = new Dictionary<Type, NodeFabType>();
			TypeMap.Add(typeof(App), NodeFabType.App);
			TypeMap.Add(typeof(Class), NodeFabType.Class);
			TypeMap.Add(typeof(Instance), NodeFabType.Instance);
			TypeMap.Add(typeof(Url), NodeFabType.Url);
			TypeMap.Add(typeof(User), NodeFabType.User);

			TypeMap.Add(typeof(Member), NodeFabType.Member);
			TypeMap.Add(typeof(MemberTypeAssign), NodeFabType.MemberTypeAssign);

			TypeMap.Add(typeof(Factor), NodeFabType.Factor);

			TypeMap.Add(typeof(Email), NodeFabType.Email);
			TypeMap.Add(typeof(OauthAccess), NodeFabType.OauthAccess);
			TypeMap.Add(typeof(OauthDomain), NodeFabType.OauthDomain);
			TypeMap.Add(typeof(OauthGrant), NodeFabType.OauthGrant);
			TypeMap.Add(typeof(OauthScope), NodeFabType.OauthScope);
			
			////

			ValueMap = new Dictionary<byte, NodeFabType>();
			IEnumerable<NodeFabType> types = Enum.GetValues(typeof(NodeFabType)).Cast<NodeFabType>();

			foreach ( NodeFabType type in types ) {
				ValueMap.Add((byte)type, type);
			}

			return true;
		}
		
	}
}