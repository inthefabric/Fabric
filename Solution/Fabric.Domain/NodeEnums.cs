using System;
using System.Collections.Generic;

namespace Fabric.Domain {

	/*================================================================================================*/
	public enum NodeFabType {
		BaseClass = -1,

		App = 1000,
		Class,
		Instance,
		Url,
		User,

		Member = 2000,
		MemberTypeAssign,
			
		Factor = 3000,
		Descriptor,
		Director,
		Eventor,
		Identor,
		Locator,
		Vector,
			
		Email = 4000,
		OauthAccess,
		OauthDomain,
		OauthGrant,
		OauthScope
	}

	/*================================================================================================*/
	public static class NodeFabTypeUtil {

		public static readonly IDictionary<Type, NodeFabType> TypeMap = Init();


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static IDictionary<Type, NodeFabType> Init() {
			var m = new Dictionary<Type, NodeFabType>();
			m.Add(typeof(App), NodeFabType.App);
			m.Add(typeof(Class), NodeFabType.Class);
			m.Add(typeof(Instance), NodeFabType.Instance);
			m.Add(typeof(Url), NodeFabType.Url);
			m.Add(typeof(User), NodeFabType.User);

			m.Add(typeof(Member), NodeFabType.Member);
			m.Add(typeof(MemberTypeAssign), NodeFabType.MemberTypeAssign);

			m.Add(typeof(Factor), NodeFabType.Factor);
			m.Add(typeof(Descriptor), NodeFabType.Descriptor);
			m.Add(typeof(Director), NodeFabType.Director);
			m.Add(typeof(Eventor), NodeFabType.Eventor);
			m.Add(typeof(Identor), NodeFabType.Identor);
			m.Add(typeof(Locator), NodeFabType.Locator);
			m.Add(typeof(Vector), NodeFabType.Vector);

			m.Add(typeof(Email), NodeFabType.Email);
			m.Add(typeof(OauthAccess), NodeFabType.OauthAccess);
			m.Add(typeof(OauthDomain), NodeFabType.OauthDomain);
			m.Add(typeof(OauthGrant), NodeFabType.OauthGrant);
			m.Add(typeof(OauthScope), NodeFabType.OauthScope);

			return m;
		}
		
	}
}