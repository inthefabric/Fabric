// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 2:54:23 PM

using Fabric.Domain;
using Weaver;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			const WeaverTasks.ItemType n = WeaverTasks.ItemType.Node;

			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Node>(x => x.FabType, n));

			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Artifact>(x => x.ArtifactId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<App>(x => x.AppId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Class>(x => x.ClassId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Email>(x => x.EmailId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Instance>(x => x.InstanceId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Member>(x => x.MemberId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<MemberTypeAssign>(x => x.MemberTypeAssignId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Url>(x => x.UrlId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<User>(x => x.UserId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Factor>(x => x.FactorId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<OauthAccess>(x => x.OauthAccessId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<OauthDomain>(x => x.OauthDomainId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<OauthGrant>(x => x.OauthGrantId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<OauthScope>(x => x.OauthScopeId, n));
		}

	}

}