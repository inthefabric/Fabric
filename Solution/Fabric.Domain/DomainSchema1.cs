// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 11/18/2012 10:36:57 PM

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

		IRootHasApp OutHasApps { get; } //OutToZeroOrMore
		IRootHasArtifact OutHasArtifacts { get; } //OutToZeroOrMore
		IRootHasArtifactType OutHasArtifactTypes { get; } //OutToZeroOrMore
		IRootHasCrowd OutHasCrowds { get; } //OutToZeroOrMore
		IRootHasCrowdian OutHasCrowdians { get; } //OutToZeroOrMore
		IRootHasCrowdianType OutHasCrowdianTypes { get; } //OutToZeroOrMore
		IRootHasEmail OutHasEmails { get; } //OutToZeroOrMore
		IRootHasLabel OutHasLabels { get; } //OutToZeroOrMore
		IRootHasMember OutHasMembers { get; } //OutToZeroOrMore
		IRootHasMemberType OutHasMemberTypes { get; } //OutToZeroOrMore
		IRootHasThing OutHasThings { get; } //OutToZeroOrMore
		IRootHasUrl OutHasUrls { get; } //OutToZeroOrMore
		IRootHasUser OutHasUsers { get; } //OutToZeroOrMore

	}

	/*================================================================================================*/
	public interface IQueryApp : IWeaverQueryNode {

		IRootHasApp InRootHas { get; } //InFromOne
		IAppHasArtifact OutHasArtifact { get; } //OutToOne
		IAppUsesEmail OutUsesEmail { get; } //OutToOne
		IMemberUsesApp InMembersUses { get; } //InFromOneOrMore

	}

	/*================================================================================================*/
	public interface IQueryArtifact : IWeaverQueryNode {

		IRootHasArtifact InRootHas { get; } //InFromOne
		IAppHasArtifact InAppHas { get; } //InFromZeroOrOne
		IArtifactUsesArtifactType OutUsesArtifactType { get; } //OutToOne
		ICrowdHasArtifact InCrowdHas { get; } //InFromZeroOrOne
		ILabelHasArtifact InLabelHas { get; } //InFromZeroOrOne
		IMemberCreatesArtifact InMemberCreates { get; } //InFromOne
		IThingHasArtifact InThingHas { get; } //InFromZeroOrOne
		IUrlHasArtifact InUrlHas { get; } //InFromZeroOrOne
		IUserHasArtifact InUserHas { get; } //InFromZeroOrOne

	}

	/*================================================================================================*/
	public interface IQueryArtifactType : IWeaverQueryNode {

		IRootHasArtifactType InRootHas { get; } //InFromOne
		IArtifactUsesArtifactType InArtifactsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	public interface IQueryCrowd : IWeaverQueryNode {

		IRootHasCrowd InRootHas { get; } //InFromOne
		ICrowdHasArtifact OutHasArtifact { get; } //OutToOne
		ICrowdianUsesCrowd InCrowdiansUses { get; } //InFromOneOrMore

	}

	/*================================================================================================*/
	public interface IQueryCrowdian : IWeaverQueryNode {

		IRootHasCrowdian InRootHas { get; } //InFromOne
		ICrowdianUsesCrowd OutUsesCrowd { get; } //OutToOne
		ICrowdianUsesUser OutUsesUser { get; } //OutToOne
		ICrowdianHasCrowdianTypeAssign OutHasCrowdianTypeAssign { get; } //OutToOne
		ICrowdianUsesHistoricCrowdianTypeAssign OutUsesHistoricCrowdianTypeAssigns { get; } //OutToZeroOrMore

	}

	/*================================================================================================*/
	public interface IQueryCrowdianType : IWeaverQueryNode {

		IRootHasCrowdianType InRootHas { get; } //InFromOne
		ICrowdianTypeAssignUsesCrowdianType InCrowdianTypeAssignsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	public interface IQueryCrowdianTypeAssign : IWeaverQueryNode {

		ICrowdianHasCrowdianTypeAssign InCrowdianHas { get; } //InFromOne
		ICrowdianUsesHistoricCrowdianTypeAssign InCrowdianUsesHistoric { get; } //InFromOne
		ICrowdianTypeAssignUsesCrowdianType OutUsesCrowdianType { get; } //OutToOne
		IUserCreatesCrowdianTypeAssign InUserCreates { get; } //InFromOne

	}

	/*================================================================================================*/
	public interface IQueryEmail : IWeaverQueryNode {

		IRootHasEmail InRootHas { get; } //InFromOne
		IAppUsesEmail InAppUses { get; } //InFromOne
		IUserUsesEmail InUserUses { get; } //InFromOne

	}

	/*================================================================================================*/
	public interface IQueryLabel : IWeaverQueryNode {

		IRootHasLabel InRootHas { get; } //InFromOne
		ILabelHasArtifact OutHasArtifact { get; } //OutToOne

	}

	/*================================================================================================*/
	public interface IQueryMember : IWeaverQueryNode {

		IRootHasMember InRootHas { get; } //InFromOne
		IMemberUsesApp OutUsesApp { get; } //OutToOne
		IMemberUsesUser OutUsesUser { get; } //OutToOne
		IMemberHasMemberTypeAssign OutHasMemberTypeAssign { get; } //OutToOne
		IMemberUsesHistoricMemberTypeAssign OutUsesHistoricMemberTypeAssigns { get; } //OutToZeroOrMore
		IMemberCreatesArtifact OutCreatesArtifacts { get; } //OutToZeroOrMore
		IMemberCreatesMemberTypeAssign OutCreatesMemberTypeAssigns { get; } //OutToZeroOrMore

	}

	/*================================================================================================*/
	public interface IQueryMemberType : IWeaverQueryNode {

		IRootHasMemberType InRootHas { get; } //InFromOne
		IMemberTypeAssignUsesMemberType InMemberTypeAssignsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	public interface IQueryMemberTypeAssign : IWeaverQueryNode {

		IMemberHasMemberTypeAssign InMemberHas { get; } //InFromOne
		IMemberUsesHistoricMemberTypeAssign InMemberUsesHistoric { get; } //InFromOne
		IMemberCreatesMemberTypeAssign InMemberCreates { get; } //InFromOne
		IMemberTypeAssignUsesMemberType OutUsesMemberType { get; } //OutToOne

	}

	/*================================================================================================*/
	public interface IQueryThing : IWeaverQueryNode {

		IRootHasThing InRootHas { get; } //InFromOne
		IThingHasArtifact OutHasArtifact { get; } //OutToOne

	}

	/*================================================================================================*/
	public interface IQueryUrl : IWeaverQueryNode {

		IRootHasUrl InRootHas { get; } //InFromOne
		IUrlHasArtifact OutHasArtifact { get; } //OutToOne

	}

	/*================================================================================================*/
	public interface IQueryUser : IWeaverQueryNode {

		IRootHasUser InRootHas { get; } //InFromOne
		ICrowdianUsesUser InCrowdiansUses { get; } //InFromZeroOrMore
		IMemberUsesUser InMembersUses { get; } //InFromOneOrMore
		IUserHasArtifact OutHasArtifact { get; } //OutToOne
		IUserUsesEmail OutUsesEmail { get; } //OutToOne
		IUserCreatesCrowdianTypeAssign OutCreatesCrowdianTypeAssigns { get; } //OutToZeroOrMore

	}


	/* Nodes */


	/*================================================================================================*/
	public class NodeForType : WeaverNode, IQueryNodeForType {

		//[PropIsUnique(True)]
		//[PropLenMax(32)]
		//[PropLenMin(1)]
		//[PropValidRegex("^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }

		//[PropLenMax(256)]
		//[PropValidRegex("^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Description { get; set; }


	}

	/*================================================================================================*/
	public class NodeForAction : WeaverNode, IQueryNodeForAction {

		//[PropIsTimestamp(True)]
		public virtual long PerformedTimestamp { get; set; }

		//[PropLenMax(256)]
		public virtual string Note { get; set; }


	}

	/*================================================================================================*/
	public class Root : WeaverNode, IQueryRoot {

		public override bool IsRoot { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasApp OutHasApps {
			get { return NewRel<RootHasApp>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasArtifact OutHasArtifacts {
			get { return NewRel<RootHasArtifact>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasArtifactType OutHasArtifactTypes {
			get { return NewRel<RootHasArtifactType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowd OutHasCrowds {
			get { return NewRel<RootHasCrowd>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowdian OutHasCrowdians {
			get { return NewRel<RootHasCrowdian>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowdianType OutHasCrowdianTypes {
			get { return NewRel<RootHasCrowdianType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasEmail OutHasEmails {
			get { return NewRel<RootHasEmail>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasLabel OutHasLabels {
			get { return NewRel<RootHasLabel>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasMember OutHasMembers {
			get { return NewRel<RootHasMember>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasMemberType OutHasMemberTypes {
			get { return NewRel<RootHasMemberType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasThing OutHasThings {
			get { return NewRel<RootHasThing>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasUrl OutHasUrls {
			get { return NewRel<RootHasUrl>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasUser OutHasUsers {
			get { return NewRel<RootHasUser>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class App : WeaverNode, IQueryApp {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long AppId { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(64)]
		//[PropLenMin(3)]
		//[PropValidRegex("^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }

		//[PropLen(32)]
		public virtual string Secret { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasApp InRootHas {
			get { return NewRel<RootHasApp>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IAppHasArtifact OutHasArtifact {
			get { return NewRel<AppHasArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IAppUsesEmail OutUsesEmail {
			get { return NewRel<AppUsesEmail>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesApp InMembersUses {
			get { return NewRel<MemberUsesApp>(WeaverRelConn.InFromOneOrMore); }
		}

	}

	/*================================================================================================*/
	public class Artifact : WeaverNode, IQueryArtifact {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long ArtifactId { get; set; }

		public virtual bool IsPrivate { get; set; }

		//[PropIsTimestamp(True)]
		public virtual long CreatedTimestamp { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasArtifact InRootHas {
			get { return NewRel<RootHasArtifact>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IAppHasArtifact InAppHas {
			get { return NewRel<AppHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IArtifactUsesArtifactType OutUsesArtifactType {
			get { return NewRel<ArtifactUsesArtifactType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdHasArtifact InCrowdHas {
			get { return NewRel<CrowdHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ILabelHasArtifact InLabelHas {
			get { return NewRel<LabelHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesArtifact InMemberCreates {
			get { return NewRel<MemberCreatesArtifact>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IThingHasArtifact InThingHas {
			get { return NewRel<ThingHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUrlHasArtifact InUrlHas {
			get { return NewRel<UrlHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserHasArtifact InUserHas {
			get { return NewRel<UserHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public class ArtifactType : WeaverNode, IQueryArtifactType {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte ArtifactTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasArtifactType InRootHas {
			get { return NewRel<RootHasArtifactType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IArtifactUsesArtifactType InArtifactsUses {
			get { return NewRel<ArtifactUsesArtifactType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Crowd : WeaverNode, IQueryCrowd {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long CrowdId { get; set; }

		//[PropLenMax(64)]
		//[PropLenMin(3)]
		public virtual string Name { get; set; }

		//[PropLenMax(256)]
		public virtual string Description { get; set; }

		public virtual bool IsPrivate { get; set; }

		public virtual bool IsInviteOnly { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowd InRootHas {
			get { return NewRel<RootHasCrowd>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdHasArtifact OutHasArtifact {
			get { return NewRel<CrowdHasArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesCrowd InCrowdiansUses {
			get { return NewRel<CrowdianUsesCrowd>(WeaverRelConn.InFromOneOrMore); }
		}

	}

	/*================================================================================================*/
	public class Crowdian : WeaverNode, IQueryCrowdian {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long CrowdianId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowdian InRootHas {
			get { return NewRel<RootHasCrowdian>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesCrowd OutUsesCrowd {
			get { return NewRel<CrowdianUsesCrowd>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesUser OutUsesUser {
			get { return NewRel<CrowdianUsesUser>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianHasCrowdianTypeAssign OutHasCrowdianTypeAssign {
			get { return NewRel<CrowdianHasCrowdianTypeAssign>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesHistoricCrowdianTypeAssign OutUsesHistoricCrowdianTypeAssigns {
			get { return NewRel<CrowdianUsesHistoricCrowdianTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class CrowdianType : WeaverNode, IQueryCrowdianType {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte CrowdianTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasCrowdianType InRootHas {
			get { return NewRel<RootHasCrowdianType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianTypeAssignUsesCrowdianType InCrowdianTypeAssignsUses {
			get { return NewRel<CrowdianTypeAssignUsesCrowdianType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class CrowdianTypeAssign : WeaverNode, IQueryCrowdianTypeAssign {

		public virtual float Weight { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianHasCrowdianTypeAssign InCrowdianHas {
			get { return NewRel<CrowdianHasCrowdianTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesHistoricCrowdianTypeAssign InCrowdianUsesHistoric {
			get { return NewRel<CrowdianUsesHistoricCrowdianTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianTypeAssignUsesCrowdianType OutUsesCrowdianType {
			get { return NewRel<CrowdianTypeAssignUsesCrowdianType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserCreatesCrowdianTypeAssign InUserCreates {
			get { return NewRel<UserCreatesCrowdianTypeAssign>(WeaverRelConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public class Email : WeaverNode, IQueryEmail {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long EmailId { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(256)]
		//[PropValidRegex("^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$")]
		public virtual string Address { get; set; }

		//[PropLen(32)]
		public virtual string Code { get; set; }

		//[PropIsTimestamp(True)]
		public virtual long CreatedTimestamp { get; set; }

		//[PropIsNullable(True)]
		public virtual long VerifiedTimestamp { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasEmail InRootHas {
			get { return NewRel<RootHasEmail>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IAppUsesEmail InAppUses {
			get { return NewRel<AppUsesEmail>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserUsesEmail InUserUses {
			get { return NewRel<UserUsesEmail>(WeaverRelConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public class Label : WeaverNode, IQueryLabel {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long LabelId { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(128)]
		//[PropLenMin(1)]
		//[PropValidRegex("^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasLabel InRootHas {
			get { return NewRel<RootHasLabel>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ILabelHasArtifact OutHasArtifact {
			get { return NewRel<LabelHasArtifact>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class Member : WeaverNode, IQueryMember {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long MemberId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasMember InRootHas {
			get { return NewRel<RootHasMember>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesApp OutUsesApp {
			get { return NewRel<MemberUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesUser OutUsesUser {
			get { return NewRel<MemberUsesUser>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberHasMemberTypeAssign OutHasMemberTypeAssign {
			get { return NewRel<MemberHasMemberTypeAssign>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesHistoricMemberTypeAssign OutUsesHistoricMemberTypeAssigns {
			get { return NewRel<MemberUsesHistoricMemberTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesArtifact OutCreatesArtifacts {
			get { return NewRel<MemberCreatesArtifact>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesMemberTypeAssign OutCreatesMemberTypeAssigns {
			get { return NewRel<MemberCreatesMemberTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class MemberType : WeaverNode, IQueryMemberType {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte MemberTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasMemberType InRootHas {
			get { return NewRel<RootHasMemberType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberTypeAssignUsesMemberType InMemberTypeAssignsUses {
			get { return NewRel<MemberTypeAssignUsesMemberType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class MemberTypeAssign : WeaverNode, IQueryMemberTypeAssign {


		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberHasMemberTypeAssign InMemberHas {
			get { return NewRel<MemberHasMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesHistoricMemberTypeAssign InMemberUsesHistoric {
			get { return NewRel<MemberUsesHistoricMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesMemberTypeAssign InMemberCreates {
			get { return NewRel<MemberCreatesMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberTypeAssignUsesMemberType OutUsesMemberType {
			get { return NewRel<MemberTypeAssignUsesMemberType>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class Thing : WeaverNode, IQueryThing {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long ThingId { get; set; }

		public virtual bool IsClass { get; set; }

		//[PropLenMax(128)]
		public virtual string Name { get; set; }

		//[PropLenMax(128)]
		public virtual string Disamb { get; set; }

		//[PropLenMax(256)]
		public virtual string Note { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasThing InRootHas {
			get { return NewRel<RootHasThing>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IThingHasArtifact OutHasArtifact {
			get { return NewRel<ThingHasArtifact>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class Url : WeaverNode, IQueryUrl {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long UrlId { get; set; }

		//[PropLenMax(128)]
		public virtual string Name { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(2048)]
		public virtual string AbsoluteUrl { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasUrl InRootHas {
			get { return NewRel<RootHasUrl>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUrlHasArtifact OutHasArtifact {
			get { return NewRel<UrlHasArtifact>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class User : WeaverNode, IQueryUser {

		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long UserId { get; set; }

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(16)]
		//[PropValidRegex("^[a-zA-Z0-9_]*$")]
		public virtual string Name { get; set; }

		//[PropLen(32)]
		public virtual string Password { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootHasUser InRootHas {
			get { return NewRel<RootHasUser>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianUsesUser InCrowdiansUses {
			get { return NewRel<CrowdianUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberUsesUser InMembersUses {
			get { return NewRel<MemberUsesUser>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserHasArtifact OutHasArtifact {
			get { return NewRel<UserHasArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserUsesEmail OutUsesEmail {
			get { return NewRel<UserUsesEmail>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUserCreatesCrowdianTypeAssign OutCreatesCrowdianTypeAssigns {
			get { return NewRel<UserCreatesCrowdianTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

}
