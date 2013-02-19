// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 2/19/2013 2:14:12 PM

using Fabric.Domain;
using Weaver;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			const WeaverTasks.ItemType n = WeaverTasks.ItemType.Node;

			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Root>(x => x.RootId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<App>(x => x.AppId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Artifact>(x => x.ArtifactId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<ArtifactType>(x => x.ArtifactTypeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Class>(x => x.ClassId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Crowd>(x => x.CrowdId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Crowdian>(x => x.CrowdianId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<CrowdianType>(x => x.CrowdianTypeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<CrowdianTypeAssign>(x => x.CrowdianTypeAssignId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Email>(x => x.EmailId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Instance>(x => x.InstanceId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Label>(x => x.LabelId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Member>(x => x.MemberId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<MemberType>(x => x.MemberTypeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<MemberTypeAssign>(x => x.MemberTypeAssignId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Url>(x => x.UrlId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<User>(x => x.UserId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Factor>(x => x.FactorId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<FactorAssertion>(x => x.FactorAssertionId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Descriptor>(x => x.DescriptorId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<DescriptorType>(x => x.DescriptorTypeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Director>(x => x.DirectorId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<DirectorType>(x => x.DirectorTypeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<DirectorAction>(x => x.DirectorActionId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Eventor>(x => x.EventorId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<EventorType>(x => x.EventorTypeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<EventorPrecision>(x => x.EventorPrecisionId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Identor>(x => x.IdentorId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<IdentorType>(x => x.IdentorTypeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Locator>(x => x.LocatorId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<LocatorType>(x => x.LocatorTypeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<Vector>(x => x.VectorId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<VectorType>(x => x.VectorTypeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<VectorRange>(x => x.VectorRangeId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<VectorRangeLevel>(x => x.VectorRangeLevelId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<VectorUnit>(x => x.VectorUnitId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<VectorUnitPrefix>(x => x.VectorUnitPrefixId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<VectorUnitDerived>(x => x.VectorUnitDerivedId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<OauthAccess>(x => x.OauthAccessId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<OauthDomain>(x => x.OauthDomainId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<OauthGrant>(x => x.OauthGrantId, n));
			pSet.AddIndex(WeaverTasks.CreateKeyIndex<OauthScope>(x => x.OauthScopeId, n));
		}

	}

}