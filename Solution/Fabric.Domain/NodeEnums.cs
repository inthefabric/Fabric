using System;
using System.Collections.Generic;
using System.Linq;

namespace Fabric.Domain {

	/*================================================================================================*/
	public enum NodeFabType {
		BaseClass = -1,
		Unspecified = 0,

		App = 1000,
		Class,
		Instance,
		Url,
		User,

		Member = 2000,
		MemberTypeAssign,
			
		Factor = 3000,
			
		Email = 4000,
		OauthAccess,
		OauthDomain,
		OauthGrant,
		OauthScope
	}

	/*================================================================================================*/
	public static class NodeFabTypeUtil {

		public static IDictionary<Type, NodeFabType> TypeMap;
		public static IDictionary<int, NodeFabType> ValueMap;

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

			ValueMap = new Dictionary<int, NodeFabType>();
			IEnumerable<NodeFabType> types = Enum.GetValues(typeof(NodeFabType)).Cast<NodeFabType>();

			foreach ( NodeFabType type in types ) {
				ValueMap.Add((int)type, type);
			}

			return true;
		}
		
	}
}