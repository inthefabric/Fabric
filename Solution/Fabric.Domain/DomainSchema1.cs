// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 11/18/2012 3:31:31 PM

using Weaver.Items;
using Weaver.Interfaces;

//NEXT: support validation and restrictions

namespace Fabric.Domain {


	/* Relationship Types */


	/*================================================================================================*/
	public class Has : IWeaverRelType {

		public string Label { get { return "Has"; } }

	}

	/*================================================================================================*/
	public class Uses : IWeaverRelType {

		public string Label { get { return "Uses"; } }

	}

	/*================================================================================================*/
	public class UsesHistoric : IWeaverRelType {

		public string Label { get { return "UsesHistoric"; } }

	}

	/*================================================================================================*/
	public class Creates : IWeaverRelType {

		public string Label { get { return "Creates"; } }

	}


	/* Relationships */


	/*================================================================================================*/
	public interface IRootHasApp :
			IWeaverRel<IQueryRoot, IQueryApp>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryApp ToApp { get; }

	}

	/*================================================================================================*/
	public class RootHasApp :
			WeaverRel<IQueryRoot, Root, Has, IQueryApp, App>,
			IRootHasApp {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryApp ToApp { get { return ToNode; } }
		public override string Label { get { return "RootHasApp"; } }

	}

	/*================================================================================================*/
	public interface IRootHasArtifact :
			IWeaverRel<IQueryRoot, IQueryArtifact>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class RootHasArtifact :
			WeaverRel<IQueryRoot, Root, Has, IQueryArtifact, Artifact>,
			IRootHasArtifact {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "RootHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IRootHasArtifactType :
			IWeaverRel<IQueryRoot, IQueryArtifactType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryArtifactType ToArtifactType { get; }

	}

	/*================================================================================================*/
	public class RootHasArtifactType :
			WeaverRel<IQueryRoot, Root, Has, IQueryArtifactType, ArtifactType>,
			IRootHasArtifactType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryArtifactType ToArtifactType { get { return ToNode; } }
		public override string Label { get { return "RootHasArtifactType"; } }

	}

	/*================================================================================================*/
	public interface IRootHasCrowd :
			IWeaverRel<IQueryRoot, IQueryCrowd>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryCrowd ToCrowd { get; }

	}

	/*================================================================================================*/
	public class RootHasCrowd :
			WeaverRel<IQueryRoot, Root, Has, IQueryCrowd, Crowd>,
			IRootHasCrowd {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryCrowd ToCrowd { get { return ToNode; } }
		public override string Label { get { return "RootHasCrowd"; } }

	}

	/*================================================================================================*/
	public interface IRootHasCrowdian :
			IWeaverRel<IQueryRoot, IQueryCrowdian>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryCrowdian ToCrowdian { get; }

	}

	/*================================================================================================*/
	public class RootHasCrowdian :
			WeaverRel<IQueryRoot, Root, Has, IQueryCrowdian, Crowdian>,
			IRootHasCrowdian {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryCrowdian ToCrowdian { get { return ToNode; } }
		public override string Label { get { return "RootHasCrowdian"; } }

	}

	/*================================================================================================*/
	public interface IRootHasCrowdianType :
			IWeaverRel<IQueryRoot, IQueryCrowdianType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryCrowdianType ToCrowdianType { get; }

	}

	/*================================================================================================*/
	public class RootHasCrowdianType :
			WeaverRel<IQueryRoot, Root, Has, IQueryCrowdianType, CrowdianType>,
			IRootHasCrowdianType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryCrowdianType ToCrowdianType { get { return ToNode; } }
		public override string Label { get { return "RootHasCrowdianType"; } }

	}

	/*================================================================================================*/
	public interface IRootHasEmail :
			IWeaverRel<IQueryRoot, IQueryEmail>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public class RootHasEmail :
			WeaverRel<IQueryRoot, Root, Has, IQueryEmail, Email>,
			IRootHasEmail {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "RootHasEmail"; } }

	}

	/*================================================================================================*/
	public interface IRootHasLabel :
			IWeaverRel<IQueryRoot, IQueryLabel>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryLabel ToLabel { get; }

	}

	/*================================================================================================*/
	public class RootHasLabel :
			WeaverRel<IQueryRoot, Root, Has, IQueryLabel, Label>,
			IRootHasLabel {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryLabel ToLabel { get { return ToNode; } }
		public override string Label { get { return "RootHasLabel"; } }

	}

	/*================================================================================================*/
	public interface IRootHasMember :
			IWeaverRel<IQueryRoot, IQueryMember>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryMember ToMember { get; }

	}

	/*================================================================================================*/
	public class RootHasMember :
			WeaverRel<IQueryRoot, Root, Has, IQueryMember, Member>,
			IRootHasMember {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryMember ToMember { get { return ToNode; } }
		public override string Label { get { return "RootHasMember"; } }

	}

	/*================================================================================================*/
	public interface IRootHasMemberType :
			IWeaverRel<IQueryRoot, IQueryMemberType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryMemberType ToMemberType { get; }

	}

	/*================================================================================================*/
	public class RootHasMemberType :
			WeaverRel<IQueryRoot, Root, Has, IQueryMemberType, MemberType>,
			IRootHasMemberType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryMemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "RootHasMemberType"; } }

	}

	/*================================================================================================*/
	public interface IRootHasThing :
			IWeaverRel<IQueryRoot, IQueryThing>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryThing ToThing { get; }

	}

	/*================================================================================================*/
	public class RootHasThing :
			WeaverRel<IQueryRoot, Root, Has, IQueryThing, Thing>,
			IRootHasThing {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryThing ToThing { get { return ToNode; } }
		public override string Label { get { return "RootHasThing"; } }

	}

	/*================================================================================================*/
	public interface IRootHasUrl :
			IWeaverRel<IQueryRoot, IQueryUrl>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryUrl ToUrl { get; }

	}

	/*================================================================================================*/
	public class RootHasUrl :
			WeaverRel<IQueryRoot, Root, Has, IQueryUrl, Url>,
			IRootHasUrl {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryUrl ToUrl { get { return ToNode; } }
		public override string Label { get { return "RootHasUrl"; } }

	}

	/*================================================================================================*/
	public interface IRootHasUser :
			IWeaverRel<IQueryRoot, IQueryUser>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryUser ToUser { get; }

	}

	/*================================================================================================*/
	public class RootHasUser :
			WeaverRel<IQueryRoot, Root, Has, IQueryUser, User>,
			IRootHasUser {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryUser ToUser { get { return ToNode; } }
		public override string Label { get { return "RootHasUser"; } }

	}

	/*================================================================================================*/
	public interface IAppHasArtifact :
			IWeaverRel<IQueryApp, IQueryArtifact>, IWeaverQueryRel {

		IQueryApp FromApp { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class AppHasArtifact :
			WeaverRel<IQueryApp, App, Has, IQueryArtifact, Artifact>,
			IAppHasArtifact {
			
		public virtual IQueryApp FromApp { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "AppHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IAppUsesEmail :
			IWeaverRel<IQueryApp, IQueryEmail>, IWeaverQueryRel {

		IQueryApp FromApp { get; }
		IQueryEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public class AppUsesEmail :
			WeaverRel<IQueryApp, App, Uses, IQueryEmail, Email>,
			IAppUsesEmail {
			
		public virtual IQueryApp FromApp { get { return FromNode; } }
		public virtual IQueryEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "AppUsesEmail"; } }

	}

	/*================================================================================================*/
	public interface IArtifactUsesArtifactType :
			IWeaverRel<IQueryArtifact, IQueryArtifactType>, IWeaverQueryRel {

		IQueryArtifact FromArtifact { get; }
		IQueryArtifactType ToArtifactType { get; }

	}

	/*================================================================================================*/
	public class ArtifactUsesArtifactType :
			WeaverRel<IQueryArtifact, Artifact, Uses, IQueryArtifactType, ArtifactType>,
			IArtifactUsesArtifactType {
			
		public virtual IQueryArtifact FromArtifact { get { return FromNode; } }
		public virtual IQueryArtifactType ToArtifactType { get { return ToNode; } }
		public override string Label { get { return "ArtifactUsesArtifactType"; } }

	}

	/*================================================================================================*/
	public interface ICrowdHasArtifact :
			IWeaverRel<IQueryCrowd, IQueryArtifact>, IWeaverQueryRel {

		IQueryCrowd FromCrowd { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class CrowdHasArtifact :
			WeaverRel<IQueryCrowd, Crowd, Has, IQueryArtifact, Artifact>,
			ICrowdHasArtifact {
			
		public virtual IQueryCrowd FromCrowd { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "CrowdHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface ICrowdianUsesCrowd :
			IWeaverRel<IQueryCrowdian, IQueryCrowd>, IWeaverQueryRel {

		IQueryCrowdian FromCrowdian { get; }
		IQueryCrowd ToCrowd { get; }

	}

	/*================================================================================================*/
	public class CrowdianUsesCrowd :
			WeaverRel<IQueryCrowdian, Crowdian, Uses, IQueryCrowd, Crowd>,
			ICrowdianUsesCrowd {
			
		public virtual IQueryCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryCrowd ToCrowd { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesCrowd"; } }

	}

	/*================================================================================================*/
	public interface ICrowdianUsesUser :
			IWeaverRel<IQueryCrowdian, IQueryUser>, IWeaverQueryRel {

		IQueryCrowdian FromCrowdian { get; }
		IQueryUser ToUser { get; }

	}

	/*================================================================================================*/
	public class CrowdianUsesUser :
			WeaverRel<IQueryCrowdian, Crowdian, Uses, IQueryUser, User>,
			ICrowdianUsesUser {
			
		public virtual IQueryCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryUser ToUser { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesUser"; } }

	}

	/*================================================================================================*/
	public interface ICrowdianHasCrowdianTypeAssign :
			IWeaverRel<IQueryCrowdian, IQueryCrowdianTypeAssign>, IWeaverQueryRel {

		IQueryCrowdian FromCrowdian { get; }
		IQueryCrowdianTypeAssign ToCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public class CrowdianHasCrowdianTypeAssign :
			WeaverRel<IQueryCrowdian, Crowdian, Has, IQueryCrowdianTypeAssign, CrowdianTypeAssign>,
			ICrowdianHasCrowdianTypeAssign {
			
		public virtual IQueryCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "CrowdianHasCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface ICrowdianUsesHistoricCrowdianTypeAssign :
			IWeaverRel<IQueryCrowdian, IQueryCrowdianTypeAssign>, IWeaverQueryRel {

		IQueryCrowdian FromCrowdian { get; }
		IQueryCrowdianTypeAssign ToCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public class CrowdianUsesHistoricCrowdianTypeAssign :
			WeaverRel<IQueryCrowdian, Crowdian, UsesHistoric, IQueryCrowdianTypeAssign, CrowdianTypeAssign>,
			ICrowdianUsesHistoricCrowdianTypeAssign {
			
		public virtual IQueryCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesHistoricCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface ICrowdianTypeAssignUsesCrowdianType :
			IWeaverRel<IQueryCrowdianTypeAssign, IQueryCrowdianType>, IWeaverQueryRel {

		IQueryCrowdianTypeAssign FromCrowdianTypeAssign { get; }
		IQueryCrowdianType ToCrowdianType { get; }

	}

	/*================================================================================================*/
	public class CrowdianTypeAssignUsesCrowdianType :
			WeaverRel<IQueryCrowdianTypeAssign, CrowdianTypeAssign, Uses, IQueryCrowdianType, CrowdianType>,
			ICrowdianTypeAssignUsesCrowdianType {
			
		public virtual IQueryCrowdianTypeAssign FromCrowdianTypeAssign { get { return FromNode; } }
		public virtual IQueryCrowdianType ToCrowdianType { get { return ToNode; } }
		public override string Label { get { return "CrowdianTypeAssignUsesCrowdianType"; } }

	}

	/*================================================================================================*/
	public interface ILabelHasArtifact :
			IWeaverRel<IQueryLabel, IQueryArtifact>, IWeaverQueryRel {

		IQueryLabel FromLabel { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class LabelHasArtifact :
			WeaverRel<IQueryLabel, Label, Has, IQueryArtifact, Artifact>,
			ILabelHasArtifact {
			
		public virtual IQueryLabel FromLabel { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "LabelHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IMemberUsesApp :
			IWeaverRel<IQueryMember, IQueryApp>, IWeaverQueryRel {

		IQueryMember FromMember { get; }
		IQueryApp ToApp { get; }

	}

	/*================================================================================================*/
	public class MemberUsesApp :
			WeaverRel<IQueryMember, Member, Uses, IQueryApp, App>,
			IMemberUsesApp {
			
		public virtual IQueryMember FromMember { get { return FromNode; } }
		public virtual IQueryApp ToApp { get { return ToNode; } }
		public override string Label { get { return "MemberUsesApp"; } }

	}

	/*================================================================================================*/
	public interface IMemberUsesUser :
			IWeaverRel<IQueryMember, IQueryUser>, IWeaverQueryRel {

		IQueryMember FromMember { get; }
		IQueryUser ToUser { get; }

	}

	/*================================================================================================*/
	public class MemberUsesUser :
			WeaverRel<IQueryMember, Member, Uses, IQueryUser, User>,
			IMemberUsesUser {
			
		public virtual IQueryMember FromMember { get { return FromNode; } }
		public virtual IQueryUser ToUser { get { return ToNode; } }
		public override string Label { get { return "MemberUsesUser"; } }

	}

	/*================================================================================================*/
	public interface IMemberHasMemberTypeAssign :
			IWeaverRel<IQueryMember, IQueryMemberTypeAssign>, IWeaverQueryRel {

		IQueryMember FromMember { get; }
		IQueryMemberTypeAssign ToMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public class MemberHasMemberTypeAssign :
			WeaverRel<IQueryMember, Member, Has, IQueryMemberTypeAssign, MemberTypeAssign>,
			IMemberHasMemberTypeAssign {
			
		public virtual IQueryMember FromMember { get { return FromNode; } }
		public virtual IQueryMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberHasMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IMemberUsesHistoricMemberTypeAssign :
			IWeaverRel<IQueryMember, IQueryMemberTypeAssign>, IWeaverQueryRel {

		IQueryMember FromMember { get; }
		IQueryMemberTypeAssign ToMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public class MemberUsesHistoricMemberTypeAssign :
			WeaverRel<IQueryMember, Member, UsesHistoric, IQueryMemberTypeAssign, MemberTypeAssign>,
			IMemberUsesHistoricMemberTypeAssign {
			
		public virtual IQueryMember FromMember { get { return FromNode; } }
		public virtual IQueryMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberUsesHistoricMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IMemberCreatesArtifact :
			IWeaverRel<IQueryMember, IQueryArtifact>, IWeaverQueryRel {

		IQueryMember FromMember { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class MemberCreatesArtifact :
			WeaverRel<IQueryMember, Member, Creates, IQueryArtifact, Artifact>,
			IMemberCreatesArtifact {
			
		public virtual IQueryMember FromMember { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesArtifact"; } }

	}

	/*================================================================================================*/
	public interface IMemberCreatesMemberTypeAssign :
			IWeaverRel<IQueryMember, IQueryMemberTypeAssign>, IWeaverQueryRel {

		IQueryMember FromMember { get; }
		IQueryMemberTypeAssign ToMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public class MemberCreatesMemberTypeAssign :
			WeaverRel<IQueryMember, Member, Creates, IQueryMemberTypeAssign, MemberTypeAssign>,
			IMemberCreatesMemberTypeAssign {
			
		public virtual IQueryMember FromMember { get { return FromNode; } }
		public virtual IQueryMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IMemberTypeAssignUsesMemberType :
			IWeaverRel<IQueryMemberTypeAssign, IQueryMemberType>, IWeaverQueryRel {

		IQueryMemberTypeAssign FromMemberTypeAssign { get; }
		IQueryMemberType ToMemberType { get; }

	}

	/*================================================================================================*/
	public class MemberTypeAssignUsesMemberType :
			WeaverRel<IQueryMemberTypeAssign, MemberTypeAssign, Uses, IQueryMemberType, MemberType>,
			IMemberTypeAssignUsesMemberType {
			
		public virtual IQueryMemberTypeAssign FromMemberTypeAssign { get { return FromNode; } }
		public virtual IQueryMemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "MemberTypeAssignUsesMemberType"; } }

	}

	/*================================================================================================*/
	public interface IThingHasArtifact :
			IWeaverRel<IQueryThing, IQueryArtifact>, IWeaverQueryRel {

		IQueryThing FromThing { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class ThingHasArtifact :
			WeaverRel<IQueryThing, Thing, Has, IQueryArtifact, Artifact>,
			IThingHasArtifact {
			
		public virtual IQueryThing FromThing { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "ThingHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IUrlHasArtifact :
			IWeaverRel<IQueryUrl, IQueryArtifact>, IWeaverQueryRel {

		IQueryUrl FromUrl { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class UrlHasArtifact :
			WeaverRel<IQueryUrl, Url, Has, IQueryArtifact, Artifact>,
			IUrlHasArtifact {
			
		public virtual IQueryUrl FromUrl { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "UrlHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IUserHasArtifact :
			IWeaverRel<IQueryUser, IQueryArtifact>, IWeaverQueryRel {

		IQueryUser FromUser { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class UserHasArtifact :
			WeaverRel<IQueryUser, User, Has, IQueryArtifact, Artifact>,
			IUserHasArtifact {
			
		public virtual IQueryUser FromUser { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "UserHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IUserUsesEmail :
			IWeaverRel<IQueryUser, IQueryEmail>, IWeaverQueryRel {

		IQueryUser FromUser { get; }
		IQueryEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public class UserUsesEmail :
			WeaverRel<IQueryUser, User, Uses, IQueryEmail, Email>,
			IUserUsesEmail {
			
		public virtual IQueryUser FromUser { get { return FromNode; } }
		public virtual IQueryEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "UserUsesEmail"; } }

	}

	/*================================================================================================*/
	public interface IUserCreatesCrowdianTypeAssign :
			IWeaverRel<IQueryUser, IQueryCrowdianTypeAssign>, IWeaverQueryRel {

		IQueryUser FromUser { get; }
		IQueryCrowdianTypeAssign ToCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public class UserCreatesCrowdianTypeAssign :
			WeaverRel<IQueryUser, User, Creates, IQueryCrowdianTypeAssign, CrowdianTypeAssign>,
			IUserCreatesCrowdianTypeAssign {
			
		public virtual IQueryUser FromUser { get { return FromNode; } }
		public virtual IQueryCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "UserCreatesCrowdianTypeAssign"; } }

	}



	/* Query Nodes interfaces */


	/*================================================================================================*/
	public interface IQueryNodeForType : IWeaverQueryNode {


	}

	/*================================================================================================*/
	public interface IQueryNodeForAction : IWeaverQueryNode {


	}

	/*================================================================================================*/
	public interface IQueryRoot : IWeaverQueryNode {

		IRootHasApp OutHasOneApp { get; }
		IRootHasArtifact OutHasOneArtifact { get; }
		IRootHasArtifactType OutHasOneArtifactType { get; }
		IRootHasCrowd OutHasOneCrowd { get; }
		IRootHasCrowdian OutHasOneCrowdian { get; }
		IRootHasCrowdianType OutHasOneCrowdianType { get; }
		IRootHasEmail OutHasOneEmail { get; }
		IRootHasLabel OutHasOneLabel { get; }
		IRootHasMember OutHasOneMember { get; }
		IRootHasMemberType OutHasOneMemberType { get; }
		IRootHasThing OutHasOneThing { get; }
		IRootHasUrl OutHasOneUrl { get; }
		IRootHasUser OutHasOneUser { get; }

	}

	/*================================================================================================*/
	public interface IQueryApp : IWeaverQueryNode {

		IRootHasApp InManyRootHas { get; }
		IAppHasArtifact OutHasOneArtifact { get; }
		IAppUsesEmail OutUsesOneEmail { get; }
		IMemberUsesApp InOneMemberUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryArtifact : IWeaverQueryNode {

		IRootHasArtifact InManyRootHas { get; }
		IAppHasArtifact InOneAppHas { get; }
		IArtifactUsesArtifactType OutUsesManyArtifactType { get; }
		ICrowdHasArtifact InOneCrowdHas { get; }
		ILabelHasArtifact InOneLabelHas { get; }
		IMemberCreatesArtifact InManyMemberCreates { get; }
		IThingHasArtifact InOneThingHas { get; }
		IUrlHasArtifact InOneUrlHas { get; }
		IUserHasArtifact InOneUserHas { get; }

	}

	/*================================================================================================*/
	public interface IQueryArtifactType : IWeaverQueryNode {

		IRootHasArtifactType InManyRootHas { get; }
		IArtifactUsesArtifactType InOneArtifactUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryCrowd : IWeaverQueryNode {

		IRootHasCrowd InManyRootHas { get; }
		ICrowdHasArtifact OutHasOneArtifact { get; }
		ICrowdianUsesCrowd InOneCrowdianUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryCrowdian : IWeaverQueryNode {

		IRootHasCrowdian InManyRootHas { get; }
		ICrowdianUsesCrowd OutUsesManyCrowd { get; }
		ICrowdianUsesUser OutUsesManyUser { get; }
		ICrowdianHasCrowdianTypeAssign OutHasOneCrowdianTypeAssign { get; }
		ICrowdianUsesHistoricCrowdianTypeAssign OutUsesHistoricOneCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public interface IQueryCrowdianType : IWeaverQueryNode {

		IRootHasCrowdianType InManyRootHas { get; }
		ICrowdianTypeAssignUsesCrowdianType InOneCrowdianTypeAssignUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryCrowdianTypeAssign : IWeaverQueryNode {

		ICrowdianHasCrowdianTypeAssign InOneCrowdianHas { get; }
		ICrowdianUsesHistoricCrowdianTypeAssign InManyCrowdianUsesHistoric { get; }
		ICrowdianTypeAssignUsesCrowdianType OutUsesManyCrowdianType { get; }
		IUserCreatesCrowdianTypeAssign InManyUserCreates { get; }

	}

	/*================================================================================================*/
	public interface IQueryEmail : IWeaverQueryNode {

		IRootHasEmail InManyRootHas { get; }
		IAppUsesEmail InManyAppUses { get; }
		IUserUsesEmail InManyUserUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryLabel : IWeaverQueryNode {

		IRootHasLabel InManyRootHas { get; }
		ILabelHasArtifact OutHasOneArtifact { get; }

	}

	/*================================================================================================*/
	public interface IQueryMember : IWeaverQueryNode {

		IRootHasMember InManyRootHas { get; }
		IMemberUsesApp OutUsesManyApp { get; }
		IMemberUsesUser OutUsesManyUser { get; }
		IMemberHasMemberTypeAssign OutHasOneMemberTypeAssign { get; }
		IMemberUsesHistoricMemberTypeAssign OutUsesHistoricOneMemberTypeAssign { get; }
		IMemberCreatesArtifact OutCreatesOneArtifact { get; }
		IMemberCreatesMemberTypeAssign OutCreatesOneMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public interface IQueryMemberType : IWeaverQueryNode {

		IRootHasMemberType InManyRootHas { get; }
		IMemberTypeAssignUsesMemberType InOneMemberTypeAssignUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryMemberTypeAssign : IWeaverQueryNode {

		IMemberHasMemberTypeAssign InOneMemberHas { get; }
		IMemberUsesHistoricMemberTypeAssign InManyMemberUsesHistoric { get; }
		IMemberCreatesMemberTypeAssign InManyMemberCreates { get; }
		IMemberTypeAssignUsesMemberType OutUsesManyMemberType { get; }

	}

	/*================================================================================================*/
	public interface IQueryThing : IWeaverQueryNode {

		IRootHasThing InManyRootHas { get; }
		IThingHasArtifact OutHasOneArtifact { get; }

	}

	/*================================================================================================*/
	public interface IQueryUrl : IWeaverQueryNode {

		IRootHasUrl InManyRootHas { get; }
		IUrlHasArtifact OutHasOneArtifact { get; }

	}

	/*================================================================================================*/
	public interface IQueryUser : IWeaverQueryNode {

		IRootHasUser InManyRootHas { get; }
		ICrowdianUsesUser InOneCrowdianUses { get; }
		IMemberUsesUser InOneMemberUses { get; }
		IUserHasArtifact OutHasOneArtifact { get; }
		IUserUsesEmail OutUsesOneEmail { get; }
		IUserCreatesCrowdianTypeAssign OutCreatesOneCrowdianTypeAssign { get; }

	}


	/* Nodes */


	/*================================================================================================*/
	public class NodeForType : WeaverNode, IQueryNodeForType {

		public virtual string Name { get; set; }
		public virtual string Description { get; set; }

	}

	/*================================================================================================*/
	public class NodeForAction : WeaverNode, IQueryNodeForAction {

		public virtual long PerformedTimestamp { get; set; }
		public virtual string Note { get; set; }

	}

	/*================================================================================================*/
	public class Root : WeaverNode, IQueryRoot {

		public override bool IsRoot { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasApp OutHasOneApp {
			get { return NewRel<RootHasApp>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasArtifact OutHasOneArtifact {
			get { return NewRel<RootHasArtifact>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasArtifactType OutHasOneArtifactType {
			get { return NewRel<RootHasArtifactType>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowd OutHasOneCrowd {
			get { return NewRel<RootHasCrowd>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowdian OutHasOneCrowdian {
			get { return NewRel<RootHasCrowdian>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowdianType OutHasOneCrowdianType {
			get { return NewRel<RootHasCrowdianType>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasEmail OutHasOneEmail {
			get { return NewRel<RootHasEmail>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasLabel OutHasOneLabel {
			get { return NewRel<RootHasLabel>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasMember OutHasOneMember {
			get { return NewRel<RootHasMember>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasMemberType OutHasOneMemberType {
			get { return NewRel<RootHasMemberType>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasThing OutHasOneThing {
			get { return NewRel<RootHasThing>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasUrl OutHasOneUrl {
			get { return NewRel<RootHasUrl>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasUser OutHasOneUser {
			get { return NewRel<RootHasUser>(WeaverRelConn.OutToManyNodes); }
		}

	}

	/*================================================================================================*/
	public class App : WeaverNode, IQueryApp {

		public virtual long AppId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Secret { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasApp InManyRootHas {
			get { return NewRel<RootHasApp>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IAppHasArtifact OutHasOneArtifact {
			get { return NewRel<AppHasArtifact>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IAppUsesEmail OutUsesOneEmail {
			get { return NewRel<AppUsesEmail>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesApp InOneMemberUses {
			get { return NewRel<MemberUsesApp>(WeaverRelConn.InFromManyNodes); }
		}

	}

	/*================================================================================================*/
	public class Artifact : WeaverNode, IQueryArtifact {

		public virtual long ArtifactId { get; set; }
		public virtual bool IsPrivate { get; set; }
		public virtual long CreatedTimestamp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasArtifact InManyRootHas {
			get { return NewRel<RootHasArtifact>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IAppHasArtifact InOneAppHas {
			get { return NewRel<AppHasArtifact>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IArtifactUsesArtifactType OutUsesManyArtifactType {
			get { return NewRel<ArtifactUsesArtifactType>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdHasArtifact InOneCrowdHas {
			get { return NewRel<CrowdHasArtifact>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ILabelHasArtifact InOneLabelHas {
			get { return NewRel<LabelHasArtifact>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesArtifact InManyMemberCreates {
			get { return NewRel<MemberCreatesArtifact>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IThingHasArtifact InOneThingHas {
			get { return NewRel<ThingHasArtifact>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUrlHasArtifact InOneUrlHas {
			get { return NewRel<UrlHasArtifact>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserHasArtifact InOneUserHas {
			get { return NewRel<UserHasArtifact>(WeaverRelConn.InFromOneNode); }
		}

	}

	/*================================================================================================*/
	public class ArtifactType : WeaverNode, IQueryArtifactType {

		public virtual byte ArtifactTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasArtifactType InManyRootHas {
			get { return NewRel<RootHasArtifactType>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IArtifactUsesArtifactType InOneArtifactUses {
			get { return NewRel<ArtifactUsesArtifactType>(WeaverRelConn.InFromManyNodes); }
		}

	}

	/*================================================================================================*/
	public class Crowd : WeaverNode, IQueryCrowd {

		public virtual long CrowdId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual bool IsPrivate { get; set; }
		public virtual bool IsInviteOnly { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowd InManyRootHas {
			get { return NewRel<RootHasCrowd>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdHasArtifact OutHasOneArtifact {
			get { return NewRel<CrowdHasArtifact>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesCrowd InOneCrowdianUses {
			get { return NewRel<CrowdianUsesCrowd>(WeaverRelConn.InFromManyNodes); }
		}

	}

	/*================================================================================================*/
	public class Crowdian : WeaverNode, IQueryCrowdian {

		public virtual long CrowdianId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowdian InManyRootHas {
			get { return NewRel<RootHasCrowdian>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesCrowd OutUsesManyCrowd {
			get { return NewRel<CrowdianUsesCrowd>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesUser OutUsesManyUser {
			get { return NewRel<CrowdianUsesUser>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianHasCrowdianTypeAssign OutHasOneCrowdianTypeAssign {
			get { return NewRel<CrowdianHasCrowdianTypeAssign>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesHistoricCrowdianTypeAssign OutUsesHistoricOneCrowdianTypeAssign {
			get { return NewRel<CrowdianUsesHistoricCrowdianTypeAssign>(WeaverRelConn.OutToManyNodes); }
		}

	}

	/*================================================================================================*/
	public class CrowdianType : WeaverNode, IQueryCrowdianType {

		public virtual byte CrowdianTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowdianType InManyRootHas {
			get { return NewRel<RootHasCrowdianType>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianTypeAssignUsesCrowdianType InOneCrowdianTypeAssignUses {
			get { return NewRel<CrowdianTypeAssignUsesCrowdianType>(WeaverRelConn.InFromManyNodes); }
		}

	}

	/*================================================================================================*/
	public class CrowdianTypeAssign : WeaverNode, IQueryCrowdianTypeAssign {

		public virtual float Weight { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianHasCrowdianTypeAssign InOneCrowdianHas {
			get { return NewRel<CrowdianHasCrowdianTypeAssign>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesHistoricCrowdianTypeAssign InManyCrowdianUsesHistoric {
			get { return NewRel<CrowdianUsesHistoricCrowdianTypeAssign>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianTypeAssignUsesCrowdianType OutUsesManyCrowdianType {
			get { return NewRel<CrowdianTypeAssignUsesCrowdianType>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserCreatesCrowdianTypeAssign InManyUserCreates {
			get { return NewRel<UserCreatesCrowdianTypeAssign>(WeaverRelConn.InFromOneNode); }
		}

	}

	/*================================================================================================*/
	public class Email : WeaverNode, IQueryEmail {

		public virtual long EmailId { get; set; }
		public virtual string Address { get; set; }
		public virtual string Code { get; set; }
		public virtual long CreatedTimestamp { get; set; }
		public virtual long VerifiedTimestamp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasEmail InManyRootHas {
			get { return NewRel<RootHasEmail>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IAppUsesEmail InManyAppUses {
			get { return NewRel<AppUsesEmail>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserUsesEmail InManyUserUses {
			get { return NewRel<UserUsesEmail>(WeaverRelConn.InFromOneNode); }
		}

	}

	/*================================================================================================*/
	public class Label : WeaverNode, IQueryLabel {

		public virtual long LabelId { get; set; }
		public virtual string Name { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasLabel InManyRootHas {
			get { return NewRel<RootHasLabel>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ILabelHasArtifact OutHasOneArtifact {
			get { return NewRel<LabelHasArtifact>(WeaverRelConn.OutToOneNode); }
		}

	}

	/*================================================================================================*/
	public class Member : WeaverNode, IQueryMember {

		public virtual long MemberId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasMember InManyRootHas {
			get { return NewRel<RootHasMember>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesApp OutUsesManyApp {
			get { return NewRel<MemberUsesApp>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesUser OutUsesManyUser {
			get { return NewRel<MemberUsesUser>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberHasMemberTypeAssign OutHasOneMemberTypeAssign {
			get { return NewRel<MemberHasMemberTypeAssign>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesHistoricMemberTypeAssign OutUsesHistoricOneMemberTypeAssign {
			get { return NewRel<MemberUsesHistoricMemberTypeAssign>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesArtifact OutCreatesOneArtifact {
			get { return NewRel<MemberCreatesArtifact>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesMemberTypeAssign OutCreatesOneMemberTypeAssign {
			get { return NewRel<MemberCreatesMemberTypeAssign>(WeaverRelConn.OutToManyNodes); }
		}

	}

	/*================================================================================================*/
	public class MemberType : WeaverNode, IQueryMemberType {

		public virtual byte MemberTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasMemberType InManyRootHas {
			get { return NewRel<RootHasMemberType>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberTypeAssignUsesMemberType InOneMemberTypeAssignUses {
			get { return NewRel<MemberTypeAssignUsesMemberType>(WeaverRelConn.InFromManyNodes); }
		}

	}

	/*================================================================================================*/
	public class MemberTypeAssign : WeaverNode, IQueryMemberTypeAssign {


		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberHasMemberTypeAssign InOneMemberHas {
			get { return NewRel<MemberHasMemberTypeAssign>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesHistoricMemberTypeAssign InManyMemberUsesHistoric {
			get { return NewRel<MemberUsesHistoricMemberTypeAssign>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesMemberTypeAssign InManyMemberCreates {
			get { return NewRel<MemberCreatesMemberTypeAssign>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberTypeAssignUsesMemberType OutUsesManyMemberType {
			get { return NewRel<MemberTypeAssignUsesMemberType>(WeaverRelConn.OutToOneNode); }
		}

	}

	/*================================================================================================*/
	public class Thing : WeaverNode, IQueryThing {

		public virtual long ThingId { get; set; }
		public virtual bool IsClass { get; set; }
		public virtual string Name { get; set; }
		public virtual string Disamb { get; set; }
		public virtual string Note { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasThing InManyRootHas {
			get { return NewRel<RootHasThing>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IThingHasArtifact OutHasOneArtifact {
			get { return NewRel<ThingHasArtifact>(WeaverRelConn.OutToOneNode); }
		}

	}

	/*================================================================================================*/
	public class Url : WeaverNode, IQueryUrl {

		public virtual long UrlId { get; set; }
		public virtual string Name { get; set; }
		public virtual string AbsoluteUrl { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasUrl InManyRootHas {
			get { return NewRel<RootHasUrl>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUrlHasArtifact OutHasOneArtifact {
			get { return NewRel<UrlHasArtifact>(WeaverRelConn.OutToOneNode); }
		}

	}

	/*================================================================================================*/
	public class User : WeaverNode, IQueryUser {

		public virtual long UserId { get; set; }
		public virtual string Name { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasUser InManyRootHas {
			get { return NewRel<RootHasUser>(WeaverRelConn.InFromOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesUser InOneCrowdianUses {
			get { return NewRel<CrowdianUsesUser>(WeaverRelConn.InFromManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesUser InOneMemberUses {
			get { return NewRel<MemberUsesUser>(WeaverRelConn.InFromManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserHasArtifact OutHasOneArtifact {
			get { return NewRel<UserHasArtifact>(WeaverRelConn.OutToOneNode); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserUsesEmail OutUsesOneEmail {
			get { return NewRel<UserUsesEmail>(WeaverRelConn.OutToManyNodes); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserCreatesCrowdianTypeAssign OutCreatesOneCrowdianTypeAssign {
			get { return NewRel<UserCreatesCrowdianTypeAssign>(WeaverRelConn.OutToManyNodes); }
		}

	}


}
