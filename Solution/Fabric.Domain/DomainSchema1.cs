// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 11/18/2012 2:39:15 PM

//NEXT: support validation and restrictions

namespace Fabric.Domain.Graph {


	/* Relationship Types */


	/*================================================================================================*/
	public interface IHas : IGraphQueryRelType {}

	/*================================================================================================*/
	public class Has : IHas {}

	/*================================================================================================*/
	public interface IUses : IGraphQueryRelType {}

	/*================================================================================================*/
	public class Uses : IUses {}

	/*================================================================================================*/
	public interface IUsesHistoric : IGraphQueryRelType {}

	/*================================================================================================*/
	public class UsesHistoric : IUsesHistoric {}

	/*================================================================================================*/
	public interface ICreates : IGraphQueryRelType {}

	/*================================================================================================*/
	public class Creates : ICreates {}


	/* Relationships */


	/*================================================================================================*/
	public interface IInRootHasApp :
			IIn<IQueryableRoot, Root, IHas, IQueryableApp, App> {

		IQueryableRoot FromRoot { get; }
		IQueryableApp ToApp { get; }

	}

	/*================================================================================================*/
	public class InRootHasApp :
			In<IQueryableRoot, Root, IHas, IQueryableApp, App>, IInRootHasApp {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableApp ToApp { get { return ToNode; } }
		public override string Label { get { return "RootHasApp"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasArtifact :
			IIn<IQueryableRoot, Root, IHas, IQueryableArtifact, Artifact> {

		IQueryableRoot FromRoot { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class InRootHasArtifact :
			In<IQueryableRoot, Root, IHas, IQueryableArtifact, Artifact>, IInRootHasArtifact {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "RootHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasArtifactType :
			IIn<IQueryableRoot, Root, IHas, IQueryableArtifactType, ArtifactType> {

		IQueryableRoot FromRoot { get; }
		IQueryableArtifactType ToArtifactType { get; }

	}

	/*================================================================================================*/
	public class InRootHasArtifactType :
			In<IQueryableRoot, Root, IHas, IQueryableArtifactType, ArtifactType>, IInRootHasArtifactType {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableArtifactType ToArtifactType { get { return ToNode; } }
		public override string Label { get { return "RootHasArtifactType"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasCrowd :
			IIn<IQueryableRoot, Root, IHas, IQueryableCrowd, Crowd> {

		IQueryableRoot FromRoot { get; }
		IQueryableCrowd ToCrowd { get; }

	}

	/*================================================================================================*/
	public class InRootHasCrowd :
			In<IQueryableRoot, Root, IHas, IQueryableCrowd, Crowd>, IInRootHasCrowd {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableCrowd ToCrowd { get { return ToNode; } }
		public override string Label { get { return "RootHasCrowd"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasCrowdian :
			IIn<IQueryableRoot, Root, IHas, IQueryableCrowdian, Crowdian> {

		IQueryableRoot FromRoot { get; }
		IQueryableCrowdian ToCrowdian { get; }

	}

	/*================================================================================================*/
	public class InRootHasCrowdian :
			In<IQueryableRoot, Root, IHas, IQueryableCrowdian, Crowdian>, IInRootHasCrowdian {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableCrowdian ToCrowdian { get { return ToNode; } }
		public override string Label { get { return "RootHasCrowdian"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasCrowdianType :
			IIn<IQueryableRoot, Root, IHas, IQueryableCrowdianType, CrowdianType> {

		IQueryableRoot FromRoot { get; }
		IQueryableCrowdianType ToCrowdianType { get; }

	}

	/*================================================================================================*/
	public class InRootHasCrowdianType :
			In<IQueryableRoot, Root, IHas, IQueryableCrowdianType, CrowdianType>, IInRootHasCrowdianType {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableCrowdianType ToCrowdianType { get { return ToNode; } }
		public override string Label { get { return "RootHasCrowdianType"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasEmail :
			IIn<IQueryableRoot, Root, IHas, IQueryableEmail, Email> {

		IQueryableRoot FromRoot { get; }
		IQueryableEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public class InRootHasEmail :
			In<IQueryableRoot, Root, IHas, IQueryableEmail, Email>, IInRootHasEmail {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "RootHasEmail"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasLabel :
			IIn<IQueryableRoot, Root, IHas, IQueryableLabel, Label> {

		IQueryableRoot FromRoot { get; }
		IQueryableLabel ToLabel { get; }

	}

	/*================================================================================================*/
	public class InRootHasLabel :
			In<IQueryableRoot, Root, IHas, IQueryableLabel, Label>, IInRootHasLabel {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableLabel ToLabel { get { return ToNode; } }
		public override string Label { get { return "RootHasLabel"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasMember :
			IIn<IQueryableRoot, Root, IHas, IQueryableMember, Member> {

		IQueryableRoot FromRoot { get; }
		IQueryableMember ToMember { get; }

	}

	/*================================================================================================*/
	public class InRootHasMember :
			In<IQueryableRoot, Root, IHas, IQueryableMember, Member>, IInRootHasMember {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableMember ToMember { get { return ToNode; } }
		public override string Label { get { return "RootHasMember"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasMemberType :
			IIn<IQueryableRoot, Root, IHas, IQueryableMemberType, MemberType> {

		IQueryableRoot FromRoot { get; }
		IQueryableMemberType ToMemberType { get; }

	}

	/*================================================================================================*/
	public class InRootHasMemberType :
			In<IQueryableRoot, Root, IHas, IQueryableMemberType, MemberType>, IInRootHasMemberType {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableMemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "RootHasMemberType"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasThing :
			IIn<IQueryableRoot, Root, IHas, IQueryableThing, Thing> {

		IQueryableRoot FromRoot { get; }
		IQueryableThing ToThing { get; }

	}

	/*================================================================================================*/
	public class InRootHasThing :
			In<IQueryableRoot, Root, IHas, IQueryableThing, Thing>, IInRootHasThing {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableThing ToThing { get { return ToNode; } }
		public override string Label { get { return "RootHasThing"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasUrl :
			IIn<IQueryableRoot, Root, IHas, IQueryableUrl, Url> {

		IQueryableRoot FromRoot { get; }
		IQueryableUrl ToUrl { get; }

	}

	/*================================================================================================*/
	public class InRootHasUrl :
			In<IQueryableRoot, Root, IHas, IQueryableUrl, Url>, IInRootHasUrl {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableUrl ToUrl { get { return ToNode; } }
		public override string Label { get { return "RootHasUrl"; } }

	}

	/*================================================================================================*/
	public interface IInRootHasUser :
			IIn<IQueryableRoot, Root, IHas, IQueryableUser, User> {

		IQueryableRoot FromRoot { get; }
		IQueryableUser ToUser { get; }

	}

	/*================================================================================================*/
	public class InRootHasUser :
			In<IQueryableRoot, Root, IHas, IQueryableUser, User>, IInRootHasUser {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableUser ToUser { get { return ToNode; } }
		public override string Label { get { return "RootHasUser"; } }

	}

	/*================================================================================================*/
	public interface IInAppHasArtifact :
			IIn<IQueryableApp, App, IHas, IQueryableArtifact, Artifact> {

		IQueryableApp FromApp { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class InAppHasArtifact :
			In<IQueryableApp, App, IHas, IQueryableArtifact, Artifact>, IInAppHasArtifact {
			
		public virtual IQueryableApp FromApp { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "AppHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IInAppUsesEmail :
			IIn<IQueryableApp, App, IUses, IQueryableEmail, Email> {

		IQueryableApp FromApp { get; }
		IQueryableEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public class InAppUsesEmail :
			In<IQueryableApp, App, IUses, IQueryableEmail, Email>, IInAppUsesEmail {
			
		public virtual IQueryableApp FromApp { get { return FromNode; } }
		public virtual IQueryableEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "AppUsesEmail"; } }

	}

	/*================================================================================================*/
	public interface IInListArtifactUsesArtifactType :
			IInList<IQueryableArtifact, Artifact, IUses, IQueryableArtifactType, ArtifactType> {

		IQueryableArtifact FromArtifact { get; }
		IQueryableArtifactType ToArtifactType { get; }

	}

	/*================================================================================================*/
	public class InListArtifactUsesArtifactType :
			InList<IQueryableArtifact, Artifact, IUses, IQueryableArtifactType, ArtifactType>, IInListArtifactUsesArtifactType {
			
		public virtual IQueryableArtifact FromArtifact { get { return FromNode; } }
		public virtual IQueryableArtifactType ToArtifactType { get { return ToNode; } }
		public override string Label { get { return "ArtifactUsesArtifactType"; } }

	}

	/*================================================================================================*/
	public interface IInCrowdHasArtifact :
			IIn<IQueryableCrowd, Crowd, IHas, IQueryableArtifact, Artifact> {

		IQueryableCrowd FromCrowd { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class InCrowdHasArtifact :
			In<IQueryableCrowd, Crowd, IHas, IQueryableArtifact, Artifact>, IInCrowdHasArtifact {
			
		public virtual IQueryableCrowd FromCrowd { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "CrowdHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IInListCrowdianUsesCrowd :
			IInList<IQueryableCrowdian, Crowdian, IUses, IQueryableCrowd, Crowd> {

		IQueryableCrowdian FromCrowdian { get; }
		IQueryableCrowd ToCrowd { get; }

	}

	/*================================================================================================*/
	public class InListCrowdianUsesCrowd :
			InList<IQueryableCrowdian, Crowdian, IUses, IQueryableCrowd, Crowd>, IInListCrowdianUsesCrowd {
			
		public virtual IQueryableCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryableCrowd ToCrowd { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesCrowd"; } }

	}

	/*================================================================================================*/
	public interface IInListCrowdianUsesUser :
			IInList<IQueryableCrowdian, Crowdian, IUses, IQueryableUser, User> {

		IQueryableCrowdian FromCrowdian { get; }
		IQueryableUser ToUser { get; }

	}

	/*================================================================================================*/
	public class InListCrowdianUsesUser :
			InList<IQueryableCrowdian, Crowdian, IUses, IQueryableUser, User>, IInListCrowdianUsesUser {
			
		public virtual IQueryableCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryableUser ToUser { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesUser"; } }

	}

	/*================================================================================================*/
	public interface IInCrowdianHasCrowdianTypeAssign :
			IIn<IQueryableCrowdian, Crowdian, IHas, IQueryableCrowdianTypeAssign, CrowdianTypeAssign> {

		IQueryableCrowdian FromCrowdian { get; }
		IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public class InCrowdianHasCrowdianTypeAssign :
			In<IQueryableCrowdian, Crowdian, IHas, IQueryableCrowdianTypeAssign, CrowdianTypeAssign>, IInCrowdianHasCrowdianTypeAssign {
			
		public virtual IQueryableCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "CrowdianHasCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IInCrowdianUsesHistoricCrowdianTypeAssign :
			IIn<IQueryableCrowdian, Crowdian, IUsesHistoric, IQueryableCrowdianTypeAssign, CrowdianTypeAssign> {

		IQueryableCrowdian FromCrowdian { get; }
		IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public class InCrowdianUsesHistoricCrowdianTypeAssign :
			In<IQueryableCrowdian, Crowdian, IUsesHistoric, IQueryableCrowdianTypeAssign, CrowdianTypeAssign>, IInCrowdianUsesHistoricCrowdianTypeAssign {
			
		public virtual IQueryableCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesHistoricCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IInListCrowdianTypeAssignUsesCrowdianType :
			IInList<IQueryableCrowdianTypeAssign, CrowdianTypeAssign, IUses, IQueryableCrowdianType, CrowdianType> {

		IQueryableCrowdianTypeAssign FromCrowdianTypeAssign { get; }
		IQueryableCrowdianType ToCrowdianType { get; }

	}

	/*================================================================================================*/
	public class InListCrowdianTypeAssignUsesCrowdianType :
			InList<IQueryableCrowdianTypeAssign, CrowdianTypeAssign, IUses, IQueryableCrowdianType, CrowdianType>, IInListCrowdianTypeAssignUsesCrowdianType {
			
		public virtual IQueryableCrowdianTypeAssign FromCrowdianTypeAssign { get { return FromNode; } }
		public virtual IQueryableCrowdianType ToCrowdianType { get { return ToNode; } }
		public override string Label { get { return "CrowdianTypeAssignUsesCrowdianType"; } }

	}

	/*================================================================================================*/
	public interface IInLabelHasArtifact :
			IIn<IQueryableLabel, Label, IHas, IQueryableArtifact, Artifact> {

		IQueryableLabel FromLabel { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class InLabelHasArtifact :
			In<IQueryableLabel, Label, IHas, IQueryableArtifact, Artifact>, IInLabelHasArtifact {
			
		public virtual IQueryableLabel FromLabel { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "LabelHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IInListMemberUsesApp :
			IInList<IQueryableMember, Member, IUses, IQueryableApp, App> {

		IQueryableMember FromMember { get; }
		IQueryableApp ToApp { get; }

	}

	/*================================================================================================*/
	public class InListMemberUsesApp :
			InList<IQueryableMember, Member, IUses, IQueryableApp, App>, IInListMemberUsesApp {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableApp ToApp { get { return ToNode; } }
		public override string Label { get { return "MemberUsesApp"; } }

	}

	/*================================================================================================*/
	public interface IInListMemberUsesUser :
			IInList<IQueryableMember, Member, IUses, IQueryableUser, User> {

		IQueryableMember FromMember { get; }
		IQueryableUser ToUser { get; }

	}

	/*================================================================================================*/
	public class InListMemberUsesUser :
			InList<IQueryableMember, Member, IUses, IQueryableUser, User>, IInListMemberUsesUser {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableUser ToUser { get { return ToNode; } }
		public override string Label { get { return "MemberUsesUser"; } }

	}

	/*================================================================================================*/
	public interface IInMemberHasMemberTypeAssign :
			IIn<IQueryableMember, Member, IHas, IQueryableMemberTypeAssign, MemberTypeAssign> {

		IQueryableMember FromMember { get; }
		IQueryableMemberTypeAssign ToMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public class InMemberHasMemberTypeAssign :
			In<IQueryableMember, Member, IHas, IQueryableMemberTypeAssign, MemberTypeAssign>, IInMemberHasMemberTypeAssign {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberHasMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IInMemberUsesHistoricMemberTypeAssign :
			IIn<IQueryableMember, Member, IUsesHistoric, IQueryableMemberTypeAssign, MemberTypeAssign> {

		IQueryableMember FromMember { get; }
		IQueryableMemberTypeAssign ToMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public class InMemberUsesHistoricMemberTypeAssign :
			In<IQueryableMember, Member, IUsesHistoric, IQueryableMemberTypeAssign, MemberTypeAssign>, IInMemberUsesHistoricMemberTypeAssign {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberUsesHistoricMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IInMemberCreatesArtifact :
			IIn<IQueryableMember, Member, ICreates, IQueryableArtifact, Artifact> {

		IQueryableMember FromMember { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class InMemberCreatesArtifact :
			In<IQueryableMember, Member, ICreates, IQueryableArtifact, Artifact>, IInMemberCreatesArtifact {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesArtifact"; } }

	}

	/*================================================================================================*/
	public interface IInMemberCreatesMemberTypeAssign :
			IIn<IQueryableMember, Member, ICreates, IQueryableMemberTypeAssign, MemberTypeAssign> {

		IQueryableMember FromMember { get; }
		IQueryableMemberTypeAssign ToMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public class InMemberCreatesMemberTypeAssign :
			In<IQueryableMember, Member, ICreates, IQueryableMemberTypeAssign, MemberTypeAssign>, IInMemberCreatesMemberTypeAssign {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IInListMemberTypeAssignUsesMemberType :
			IInList<IQueryableMemberTypeAssign, MemberTypeAssign, IUses, IQueryableMemberType, MemberType> {

		IQueryableMemberTypeAssign FromMemberTypeAssign { get; }
		IQueryableMemberType ToMemberType { get; }

	}

	/*================================================================================================*/
	public class InListMemberTypeAssignUsesMemberType :
			InList<IQueryableMemberTypeAssign, MemberTypeAssign, IUses, IQueryableMemberType, MemberType>, IInListMemberTypeAssignUsesMemberType {
			
		public virtual IQueryableMemberTypeAssign FromMemberTypeAssign { get { return FromNode; } }
		public virtual IQueryableMemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "MemberTypeAssignUsesMemberType"; } }

	}

	/*================================================================================================*/
	public interface IInThingHasArtifact :
			IIn<IQueryableThing, Thing, IHas, IQueryableArtifact, Artifact> {

		IQueryableThing FromThing { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class InThingHasArtifact :
			In<IQueryableThing, Thing, IHas, IQueryableArtifact, Artifact>, IInThingHasArtifact {
			
		public virtual IQueryableThing FromThing { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "ThingHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IInUrlHasArtifact :
			IIn<IQueryableUrl, Url, IHas, IQueryableArtifact, Artifact> {

		IQueryableUrl FromUrl { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class InUrlHasArtifact :
			In<IQueryableUrl, Url, IHas, IQueryableArtifact, Artifact>, IInUrlHasArtifact {
			
		public virtual IQueryableUrl FromUrl { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "UrlHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IInUserHasArtifact :
			IIn<IQueryableUser, User, IHas, IQueryableArtifact, Artifact> {

		IQueryableUser FromUser { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class InUserHasArtifact :
			In<IQueryableUser, User, IHas, IQueryableArtifact, Artifact>, IInUserHasArtifact {
			
		public virtual IQueryableUser FromUser { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "UserHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IInUserUsesEmail :
			IIn<IQueryableUser, User, IUses, IQueryableEmail, Email> {

		IQueryableUser FromUser { get; }
		IQueryableEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public class InUserUsesEmail :
			In<IQueryableUser, User, IUses, IQueryableEmail, Email>, IInUserUsesEmail {
			
		public virtual IQueryableUser FromUser { get { return FromNode; } }
		public virtual IQueryableEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "UserUsesEmail"; } }

	}

	/*================================================================================================*/
	public interface IInUserCreatesCrowdianTypeAssign :
			IIn<IQueryableUser, User, ICreates, IQueryableCrowdianTypeAssign, CrowdianTypeAssign> {

		IQueryableUser FromUser { get; }
		IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public class InUserCreatesCrowdianTypeAssign :
			In<IQueryableUser, User, ICreates, IQueryableCrowdianTypeAssign, CrowdianTypeAssign>, IInUserCreatesCrowdianTypeAssign {
			
		public virtual IQueryableUser FromUser { get { return FromNode; } }
		public virtual IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "UserCreatesCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasApp :
			IOutList<IQueryableRoot, Root, IHas, IQueryableApp, App> {

		IQueryableRoot FromRoot { get; }
		IQueryableApp ToApp { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasApp :
			OutList<IQueryableRoot, Root, IHas, IQueryableApp, App>, IOutListRootHasApp {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableApp ToApp { get { return ToNode; } }
		public override string Label { get { return "RootHasApp"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasArtifact :
			IOutList<IQueryableRoot, Root, IHas, IQueryableArtifact, Artifact> {

		IQueryableRoot FromRoot { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasArtifact :
			OutList<IQueryableRoot, Root, IHas, IQueryableArtifact, Artifact>, IOutListRootHasArtifact {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "RootHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasArtifactType :
			IOutList<IQueryableRoot, Root, IHas, IQueryableArtifactType, ArtifactType> {

		IQueryableRoot FromRoot { get; }
		IQueryableArtifactType ToArtifactType { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasArtifactType :
			OutList<IQueryableRoot, Root, IHas, IQueryableArtifactType, ArtifactType>, IOutListRootHasArtifactType {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableArtifactType ToArtifactType { get { return ToNode; } }
		public override string Label { get { return "RootHasArtifactType"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasCrowd :
			IOutList<IQueryableRoot, Root, IHas, IQueryableCrowd, Crowd> {

		IQueryableRoot FromRoot { get; }
		IQueryableCrowd ToCrowd { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasCrowd :
			OutList<IQueryableRoot, Root, IHas, IQueryableCrowd, Crowd>, IOutListRootHasCrowd {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableCrowd ToCrowd { get { return ToNode; } }
		public override string Label { get { return "RootHasCrowd"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasCrowdian :
			IOutList<IQueryableRoot, Root, IHas, IQueryableCrowdian, Crowdian> {

		IQueryableRoot FromRoot { get; }
		IQueryableCrowdian ToCrowdian { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasCrowdian :
			OutList<IQueryableRoot, Root, IHas, IQueryableCrowdian, Crowdian>, IOutListRootHasCrowdian {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableCrowdian ToCrowdian { get { return ToNode; } }
		public override string Label { get { return "RootHasCrowdian"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasCrowdianType :
			IOutList<IQueryableRoot, Root, IHas, IQueryableCrowdianType, CrowdianType> {

		IQueryableRoot FromRoot { get; }
		IQueryableCrowdianType ToCrowdianType { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasCrowdianType :
			OutList<IQueryableRoot, Root, IHas, IQueryableCrowdianType, CrowdianType>, IOutListRootHasCrowdianType {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableCrowdianType ToCrowdianType { get { return ToNode; } }
		public override string Label { get { return "RootHasCrowdianType"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasEmail :
			IOutList<IQueryableRoot, Root, IHas, IQueryableEmail, Email> {

		IQueryableRoot FromRoot { get; }
		IQueryableEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasEmail :
			OutList<IQueryableRoot, Root, IHas, IQueryableEmail, Email>, IOutListRootHasEmail {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "RootHasEmail"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasLabel :
			IOutList<IQueryableRoot, Root, IHas, IQueryableLabel, Label> {

		IQueryableRoot FromRoot { get; }
		IQueryableLabel ToLabel { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasLabel :
			OutList<IQueryableRoot, Root, IHas, IQueryableLabel, Label>, IOutListRootHasLabel {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableLabel ToLabel { get { return ToNode; } }
		public override string Label { get { return "RootHasLabel"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasMember :
			IOutList<IQueryableRoot, Root, IHas, IQueryableMember, Member> {

		IQueryableRoot FromRoot { get; }
		IQueryableMember ToMember { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasMember :
			OutList<IQueryableRoot, Root, IHas, IQueryableMember, Member>, IOutListRootHasMember {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableMember ToMember { get { return ToNode; } }
		public override string Label { get { return "RootHasMember"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasMemberType :
			IOutList<IQueryableRoot, Root, IHas, IQueryableMemberType, MemberType> {

		IQueryableRoot FromRoot { get; }
		IQueryableMemberType ToMemberType { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasMemberType :
			OutList<IQueryableRoot, Root, IHas, IQueryableMemberType, MemberType>, IOutListRootHasMemberType {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableMemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "RootHasMemberType"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasThing :
			IOutList<IQueryableRoot, Root, IHas, IQueryableThing, Thing> {

		IQueryableRoot FromRoot { get; }
		IQueryableThing ToThing { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasThing :
			OutList<IQueryableRoot, Root, IHas, IQueryableThing, Thing>, IOutListRootHasThing {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableThing ToThing { get { return ToNode; } }
		public override string Label { get { return "RootHasThing"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasUrl :
			IOutList<IQueryableRoot, Root, IHas, IQueryableUrl, Url> {

		IQueryableRoot FromRoot { get; }
		IQueryableUrl ToUrl { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasUrl :
			OutList<IQueryableRoot, Root, IHas, IQueryableUrl, Url>, IOutListRootHasUrl {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableUrl ToUrl { get { return ToNode; } }
		public override string Label { get { return "RootHasUrl"; } }

	}

	/*================================================================================================*/
	public interface IOutListRootHasUser :
			IOutList<IQueryableRoot, Root, IHas, IQueryableUser, User> {

		IQueryableRoot FromRoot { get; }
		IQueryableUser ToUser { get; }

	}

	/*================================================================================================*/
	public class OutListRootHasUser :
			OutList<IQueryableRoot, Root, IHas, IQueryableUser, User>, IOutListRootHasUser {
			
		public virtual IQueryableRoot FromRoot { get { return FromNode; } }
		public virtual IQueryableUser ToUser { get { return ToNode; } }
		public override string Label { get { return "RootHasUser"; } }

	}

	/*================================================================================================*/
	public interface IOutAppHasArtifact :
			IOut<IQueryableApp, App, IHas, IQueryableArtifact, Artifact> {

		IQueryableApp FromApp { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class OutAppHasArtifact :
			Out<IQueryableApp, App, IHas, IQueryableArtifact, Artifact>, IOutAppHasArtifact {
			
		public virtual IQueryableApp FromApp { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "AppHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IOutListAppUsesEmail :
			IOutList<IQueryableApp, App, IUses, IQueryableEmail, Email> {

		IQueryableApp FromApp { get; }
		IQueryableEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public class OutListAppUsesEmail :
			OutList<IQueryableApp, App, IUses, IQueryableEmail, Email>, IOutListAppUsesEmail {
			
		public virtual IQueryableApp FromApp { get { return FromNode; } }
		public virtual IQueryableEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "AppUsesEmail"; } }

	}

	/*================================================================================================*/
	public interface IOutArtifactUsesArtifactType :
			IOut<IQueryableArtifact, Artifact, IUses, IQueryableArtifactType, ArtifactType> {

		IQueryableArtifact FromArtifact { get; }
		IQueryableArtifactType ToArtifactType { get; }

	}

	/*================================================================================================*/
	public class OutArtifactUsesArtifactType :
			Out<IQueryableArtifact, Artifact, IUses, IQueryableArtifactType, ArtifactType>, IOutArtifactUsesArtifactType {
			
		public virtual IQueryableArtifact FromArtifact { get { return FromNode; } }
		public virtual IQueryableArtifactType ToArtifactType { get { return ToNode; } }
		public override string Label { get { return "ArtifactUsesArtifactType"; } }

	}

	/*================================================================================================*/
	public interface IOutCrowdHasArtifact :
			IOut<IQueryableCrowd, Crowd, IHas, IQueryableArtifact, Artifact> {

		IQueryableCrowd FromCrowd { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class OutCrowdHasArtifact :
			Out<IQueryableCrowd, Crowd, IHas, IQueryableArtifact, Artifact>, IOutCrowdHasArtifact {
			
		public virtual IQueryableCrowd FromCrowd { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "CrowdHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IOutCrowdianUsesCrowd :
			IOut<IQueryableCrowdian, Crowdian, IUses, IQueryableCrowd, Crowd> {

		IQueryableCrowdian FromCrowdian { get; }
		IQueryableCrowd ToCrowd { get; }

	}

	/*================================================================================================*/
	public class OutCrowdianUsesCrowd :
			Out<IQueryableCrowdian, Crowdian, IUses, IQueryableCrowd, Crowd>, IOutCrowdianUsesCrowd {
			
		public virtual IQueryableCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryableCrowd ToCrowd { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesCrowd"; } }

	}

	/*================================================================================================*/
	public interface IOutCrowdianUsesUser :
			IOut<IQueryableCrowdian, Crowdian, IUses, IQueryableUser, User> {

		IQueryableCrowdian FromCrowdian { get; }
		IQueryableUser ToUser { get; }

	}

	/*================================================================================================*/
	public class OutCrowdianUsesUser :
			Out<IQueryableCrowdian, Crowdian, IUses, IQueryableUser, User>, IOutCrowdianUsesUser {
			
		public virtual IQueryableCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryableUser ToUser { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesUser"; } }

	}

	/*================================================================================================*/
	public interface IOutCrowdianHasCrowdianTypeAssign :
			IOut<IQueryableCrowdian, Crowdian, IHas, IQueryableCrowdianTypeAssign, CrowdianTypeAssign> {

		IQueryableCrowdian FromCrowdian { get; }
		IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public class OutCrowdianHasCrowdianTypeAssign :
			Out<IQueryableCrowdian, Crowdian, IHas, IQueryableCrowdianTypeAssign, CrowdianTypeAssign>, IOutCrowdianHasCrowdianTypeAssign {
			
		public virtual IQueryableCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "CrowdianHasCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IOutListCrowdianUsesHistoricCrowdianTypeAssign :
			IOutList<IQueryableCrowdian, Crowdian, IUsesHistoric, IQueryableCrowdianTypeAssign, CrowdianTypeAssign> {

		IQueryableCrowdian FromCrowdian { get; }
		IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public class OutListCrowdianUsesHistoricCrowdianTypeAssign :
			OutList<IQueryableCrowdian, Crowdian, IUsesHistoric, IQueryableCrowdianTypeAssign, CrowdianTypeAssign>, IOutListCrowdianUsesHistoricCrowdianTypeAssign {
			
		public virtual IQueryableCrowdian FromCrowdian { get { return FromNode; } }
		public virtual IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesHistoricCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IOutCrowdianTypeAssignUsesCrowdianType :
			IOut<IQueryableCrowdianTypeAssign, CrowdianTypeAssign, IUses, IQueryableCrowdianType, CrowdianType> {

		IQueryableCrowdianTypeAssign FromCrowdianTypeAssign { get; }
		IQueryableCrowdianType ToCrowdianType { get; }

	}

	/*================================================================================================*/
	public class OutCrowdianTypeAssignUsesCrowdianType :
			Out<IQueryableCrowdianTypeAssign, CrowdianTypeAssign, IUses, IQueryableCrowdianType, CrowdianType>, IOutCrowdianTypeAssignUsesCrowdianType {
			
		public virtual IQueryableCrowdianTypeAssign FromCrowdianTypeAssign { get { return FromNode; } }
		public virtual IQueryableCrowdianType ToCrowdianType { get { return ToNode; } }
		public override string Label { get { return "CrowdianTypeAssignUsesCrowdianType"; } }

	}

	/*================================================================================================*/
	public interface IOutLabelHasArtifact :
			IOut<IQueryableLabel, Label, IHas, IQueryableArtifact, Artifact> {

		IQueryableLabel FromLabel { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class OutLabelHasArtifact :
			Out<IQueryableLabel, Label, IHas, IQueryableArtifact, Artifact>, IOutLabelHasArtifact {
			
		public virtual IQueryableLabel FromLabel { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "LabelHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IOutMemberUsesApp :
			IOut<IQueryableMember, Member, IUses, IQueryableApp, App> {

		IQueryableMember FromMember { get; }
		IQueryableApp ToApp { get; }

	}

	/*================================================================================================*/
	public class OutMemberUsesApp :
			Out<IQueryableMember, Member, IUses, IQueryableApp, App>, IOutMemberUsesApp {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableApp ToApp { get { return ToNode; } }
		public override string Label { get { return "MemberUsesApp"; } }

	}

	/*================================================================================================*/
	public interface IOutMemberUsesUser :
			IOut<IQueryableMember, Member, IUses, IQueryableUser, User> {

		IQueryableMember FromMember { get; }
		IQueryableUser ToUser { get; }

	}

	/*================================================================================================*/
	public class OutMemberUsesUser :
			Out<IQueryableMember, Member, IUses, IQueryableUser, User>, IOutMemberUsesUser {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableUser ToUser { get { return ToNode; } }
		public override string Label { get { return "MemberUsesUser"; } }

	}

	/*================================================================================================*/
	public interface IOutMemberHasMemberTypeAssign :
			IOut<IQueryableMember, Member, IHas, IQueryableMemberTypeAssign, MemberTypeAssign> {

		IQueryableMember FromMember { get; }
		IQueryableMemberTypeAssign ToMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public class OutMemberHasMemberTypeAssign :
			Out<IQueryableMember, Member, IHas, IQueryableMemberTypeAssign, MemberTypeAssign>, IOutMemberHasMemberTypeAssign {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberHasMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IOutListMemberUsesHistoricMemberTypeAssign :
			IOutList<IQueryableMember, Member, IUsesHistoric, IQueryableMemberTypeAssign, MemberTypeAssign> {

		IQueryableMember FromMember { get; }
		IQueryableMemberTypeAssign ToMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public class OutListMemberUsesHistoricMemberTypeAssign :
			OutList<IQueryableMember, Member, IUsesHistoric, IQueryableMemberTypeAssign, MemberTypeAssign>, IOutListMemberUsesHistoricMemberTypeAssign {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberUsesHistoricMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IOutListMemberCreatesArtifact :
			IOutList<IQueryableMember, Member, ICreates, IQueryableArtifact, Artifact> {

		IQueryableMember FromMember { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class OutListMemberCreatesArtifact :
			OutList<IQueryableMember, Member, ICreates, IQueryableArtifact, Artifact>, IOutListMemberCreatesArtifact {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesArtifact"; } }

	}

	/*================================================================================================*/
	public interface IOutListMemberCreatesMemberTypeAssign :
			IOutList<IQueryableMember, Member, ICreates, IQueryableMemberTypeAssign, MemberTypeAssign> {

		IQueryableMember FromMember { get; }
		IQueryableMemberTypeAssign ToMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public class OutListMemberCreatesMemberTypeAssign :
			OutList<IQueryableMember, Member, ICreates, IQueryableMemberTypeAssign, MemberTypeAssign>, IOutListMemberCreatesMemberTypeAssign {
			
		public virtual IQueryableMember FromMember { get { return FromNode; } }
		public virtual IQueryableMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IOutMemberTypeAssignUsesMemberType :
			IOut<IQueryableMemberTypeAssign, MemberTypeAssign, IUses, IQueryableMemberType, MemberType> {

		IQueryableMemberTypeAssign FromMemberTypeAssign { get; }
		IQueryableMemberType ToMemberType { get; }

	}

	/*================================================================================================*/
	public class OutMemberTypeAssignUsesMemberType :
			Out<IQueryableMemberTypeAssign, MemberTypeAssign, IUses, IQueryableMemberType, MemberType>, IOutMemberTypeAssignUsesMemberType {
			
		public virtual IQueryableMemberTypeAssign FromMemberTypeAssign { get { return FromNode; } }
		public virtual IQueryableMemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "MemberTypeAssignUsesMemberType"; } }

	}

	/*================================================================================================*/
	public interface IOutThingHasArtifact :
			IOut<IQueryableThing, Thing, IHas, IQueryableArtifact, Artifact> {

		IQueryableThing FromThing { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class OutThingHasArtifact :
			Out<IQueryableThing, Thing, IHas, IQueryableArtifact, Artifact>, IOutThingHasArtifact {
			
		public virtual IQueryableThing FromThing { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "ThingHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IOutUrlHasArtifact :
			IOut<IQueryableUrl, Url, IHas, IQueryableArtifact, Artifact> {

		IQueryableUrl FromUrl { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class OutUrlHasArtifact :
			Out<IQueryableUrl, Url, IHas, IQueryableArtifact, Artifact>, IOutUrlHasArtifact {
			
		public virtual IQueryableUrl FromUrl { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "UrlHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IOutUserHasArtifact :
			IOut<IQueryableUser, User, IHas, IQueryableArtifact, Artifact> {

		IQueryableUser FromUser { get; }
		IQueryableArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public class OutUserHasArtifact :
			Out<IQueryableUser, User, IHas, IQueryableArtifact, Artifact>, IOutUserHasArtifact {
			
		public virtual IQueryableUser FromUser { get { return FromNode; } }
		public virtual IQueryableArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "UserHasArtifact"; } }

	}

	/*================================================================================================*/
	public interface IOutListUserUsesEmail :
			IOutList<IQueryableUser, User, IUses, IQueryableEmail, Email> {

		IQueryableUser FromUser { get; }
		IQueryableEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public class OutListUserUsesEmail :
			OutList<IQueryableUser, User, IUses, IQueryableEmail, Email>, IOutListUserUsesEmail {
			
		public virtual IQueryableUser FromUser { get { return FromNode; } }
		public virtual IQueryableEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "UserUsesEmail"; } }

	}

	/*================================================================================================*/
	public interface IOutListUserCreatesCrowdianTypeAssign :
			IOutList<IQueryableUser, User, ICreates, IQueryableCrowdianTypeAssign, CrowdianTypeAssign> {

		IQueryableUser FromUser { get; }
		IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public class OutListUserCreatesCrowdianTypeAssign :
			OutList<IQueryableUser, User, ICreates, IQueryableCrowdianTypeAssign, CrowdianTypeAssign>, IOutListUserCreatesCrowdianTypeAssign {
			
		public virtual IQueryableUser FromUser { get { return FromNode; } }
		public virtual IQueryableCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "UserCreatesCrowdianTypeAssign"; } }

	}



	/* Query Nodes interfaces */


	/*================================================================================================*/
	public interface IQueryableNodeForType : IGraphQueryNode {


	}

	/*================================================================================================*/
	public interface IQueryableNodeForAction : IGraphQueryNode {


	}

	/*================================================================================================*/
	public interface IQueryableRoot : IGraphQueryNode {

		IOutListRootHasApp OutHasApp { get; }
		IOutListRootHasArtifact OutHasArtifact { get; }
		IOutListRootHasArtifactType OutHasArtifactType { get; }
		IOutListRootHasCrowd OutHasCrowd { get; }
		IOutListRootHasCrowdian OutHasCrowdian { get; }
		IOutListRootHasCrowdianType OutHasCrowdianType { get; }
		IOutListRootHasEmail OutHasEmail { get; }
		IOutListRootHasLabel OutHasLabel { get; }
		IOutListRootHasMember OutHasMember { get; }
		IOutListRootHasMemberType OutHasMemberType { get; }
		IOutListRootHasThing OutHasThing { get; }
		IOutListRootHasUrl OutHasUrl { get; }
		IOutListRootHasUser OutHasUser { get; }

	}

	/*================================================================================================*/
	public interface IQueryableApp : IGraphQueryNode {

		IInRootHasApp InRootHas { get; }
		IOutAppHasArtifact OutHasArtifact { get; }
		IOutListAppUsesEmail OutUsesEmail { get; }
		IInListMemberUsesApp InMemberUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryableArtifact : IGraphQueryNode {

		IInRootHasArtifact InRootHas { get; }
		IInAppHasArtifact InAppHas { get; }
		IOutArtifactUsesArtifactType OutUsesArtifactType { get; }
		IInCrowdHasArtifact InCrowdHas { get; }
		IInLabelHasArtifact InLabelHas { get; }
		IInMemberCreatesArtifact InMemberCreates { get; }
		IInThingHasArtifact InThingHas { get; }
		IInUrlHasArtifact InUrlHas { get; }
		IInUserHasArtifact InUserHas { get; }

	}

	/*================================================================================================*/
	public interface IQueryableArtifactType : IGraphQueryNode {

		IInRootHasArtifactType InRootHas { get; }
		IInListArtifactUsesArtifactType InArtifactUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryableCrowd : IGraphQueryNode {

		IInRootHasCrowd InRootHas { get; }
		IOutCrowdHasArtifact OutHasArtifact { get; }
		IInListCrowdianUsesCrowd InCrowdianUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryableCrowdian : IGraphQueryNode {

		IInRootHasCrowdian InRootHas { get; }
		IOutCrowdianUsesCrowd OutUsesCrowd { get; }
		IOutCrowdianUsesUser OutUsesUser { get; }
		IOutCrowdianHasCrowdianTypeAssign OutHasCrowdianTypeAssign { get; }
		IOutListCrowdianUsesHistoricCrowdianTypeAssign OutUsesHistoricCrowdianTypeAssign { get; }

	}

	/*================================================================================================*/
	public interface IQueryableCrowdianType : IGraphQueryNode {

		IInRootHasCrowdianType InRootHas { get; }
		IInListCrowdianTypeAssignUsesCrowdianType InCrowdianTypeAssignUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryableCrowdianTypeAssign : IGraphQueryNode {

		IInCrowdianHasCrowdianTypeAssign InCrowdianHas { get; }
		IInCrowdianUsesHistoricCrowdianTypeAssign InCrowdianUsesHistoric { get; }
		IOutCrowdianTypeAssignUsesCrowdianType OutUsesCrowdianType { get; }
		IInUserCreatesCrowdianTypeAssign InUserCreates { get; }

	}

	/*================================================================================================*/
	public interface IQueryableEmail : IGraphQueryNode {

		IInRootHasEmail InRootHas { get; }
		IInAppUsesEmail InAppUses { get; }
		IInUserUsesEmail InUserUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryableLabel : IGraphQueryNode {

		IInRootHasLabel InRootHas { get; }
		IOutLabelHasArtifact OutHasArtifact { get; }

	}

	/*================================================================================================*/
	public interface IQueryableMember : IGraphQueryNode {

		IInRootHasMember InRootHas { get; }
		IOutMemberUsesApp OutUsesApp { get; }
		IOutMemberUsesUser OutUsesUser { get; }
		IOutMemberHasMemberTypeAssign OutHasMemberTypeAssign { get; }
		IOutListMemberUsesHistoricMemberTypeAssign OutUsesHistoricMemberTypeAssign { get; }
		IOutListMemberCreatesArtifact OutCreatesArtifact { get; }
		IOutListMemberCreatesMemberTypeAssign OutCreatesMemberTypeAssign { get; }

	}

	/*================================================================================================*/
	public interface IQueryableMemberType : IGraphQueryNode {

		IInRootHasMemberType InRootHas { get; }
		IInListMemberTypeAssignUsesMemberType InMemberTypeAssignUses { get; }

	}

	/*================================================================================================*/
	public interface IQueryableMemberTypeAssign : IGraphQueryNode {

		IInMemberHasMemberTypeAssign InMemberHas { get; }
		IInMemberUsesHistoricMemberTypeAssign InMemberUsesHistoric { get; }
		IInMemberCreatesMemberTypeAssign InMemberCreates { get; }
		IOutMemberTypeAssignUsesMemberType OutUsesMemberType { get; }

	}

	/*================================================================================================*/
	public interface IQueryableThing : IGraphQueryNode {

		IInRootHasThing InRootHas { get; }
		IOutThingHasArtifact OutHasArtifact { get; }

	}

	/*================================================================================================*/
	public interface IQueryableUrl : IGraphQueryNode {

		IInRootHasUrl InRootHas { get; }
		IOutUrlHasArtifact OutHasArtifact { get; }

	}

	/*================================================================================================*/
	public interface IQueryableUser : IGraphQueryNode {

		IInRootHasUser InRootHas { get; }
		IInListCrowdianUsesUser InCrowdianUses { get; }
		IInListMemberUsesUser InMemberUses { get; }
		IOutUserHasArtifact OutHasArtifact { get; }
		IOutListUserUsesEmail OutUsesEmail { get; }
		IOutListUserCreatesCrowdianTypeAssign OutCreatesCrowdianTypeAssign { get; }

	}


	/* Nodes */


	/*================================================================================================*/
	public class NodeForType : GraphQueryNode, IQueryableNodeForType {

		public virtual string Name { get; set; }
		public virtual string Description { get; set; }

	}

	/*================================================================================================*/
	public class NodeForAction : GraphQueryNode, IQueryableNodeForAction {

		public virtual long PerformedTimestamp { get; set; }
		public virtual string Note { get; set; }

	}

	/*================================================================================================*/
	public class Root : GraphQueryNode, IQueryableRoot {

		public override bool IsRoot { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasApp OutHasApp {
			get { return new OutListRootHasApp { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasArtifact OutHasArtifact {
			get { return new OutListRootHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasArtifactType OutHasArtifactType {
			get { return new OutListRootHasArtifactType { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasCrowd OutHasCrowd {
			get { return new OutListRootHasCrowd { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasCrowdian OutHasCrowdian {
			get { return new OutListRootHasCrowdian { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasCrowdianType OutHasCrowdianType {
			get { return new OutListRootHasCrowdianType { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasEmail OutHasEmail {
			get { return new OutListRootHasEmail { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasLabel OutHasLabel {
			get { return new OutListRootHasLabel { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasMember OutHasMember {
			get { return new OutListRootHasMember { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasMemberType OutHasMemberType {
			get { return new OutListRootHasMemberType { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasThing OutHasThing {
			get { return new OutListRootHasThing { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasUrl OutHasUrl {
			get { return new OutListRootHasUrl { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListRootHasUser OutHasUser {
			get { return new OutListRootHasUser { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class App : GraphQueryNode, IQueryableApp {

		public virtual long AppId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Secret { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasApp InRootHas {
			get { return new InRootHasApp { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutAppHasArtifact OutHasArtifact {
			get { return new OutAppHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListAppUsesEmail OutUsesEmail {
			get { return new OutListAppUsesEmail { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInListMemberUsesApp InMemberUses {
			get { return new InListMemberUsesApp { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class Artifact : GraphQueryNode, IQueryableArtifact {

		public virtual long ArtifactId { get; set; }
		public virtual bool IsPrivate { get; set; }
		public virtual long CreatedTimestamp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasArtifact InRootHas {
			get { return new InRootHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInAppHasArtifact InAppHas {
			get { return new InAppHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutArtifactUsesArtifactType OutUsesArtifactType {
			get { return new OutArtifactUsesArtifactType { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInCrowdHasArtifact InCrowdHas {
			get { return new InCrowdHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInLabelHasArtifact InLabelHas {
			get { return new InLabelHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInMemberCreatesArtifact InMemberCreates {
			get { return new InMemberCreatesArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInThingHasArtifact InThingHas {
			get { return new InThingHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInUrlHasArtifact InUrlHas {
			get { return new InUrlHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInUserHasArtifact InUserHas {
			get { return new InUserHasArtifact { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class ArtifactType : GraphQueryNode, IQueryableArtifactType {

		public virtual byte ArtifactTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasArtifactType InRootHas {
			get { return new InRootHasArtifactType { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInListArtifactUsesArtifactType InArtifactUses {
			get { return new InListArtifactUsesArtifactType { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class Crowd : GraphQueryNode, IQueryableCrowd {

		public virtual long CrowdId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual bool IsPrivate { get; set; }
		public virtual bool IsInviteOnly { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasCrowd InRootHas {
			get { return new InRootHasCrowd { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutCrowdHasArtifact OutHasArtifact {
			get { return new OutCrowdHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInListCrowdianUsesCrowd InCrowdianUses {
			get { return new InListCrowdianUsesCrowd { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class Crowdian : GraphQueryNode, IQueryableCrowdian {

		public virtual long CrowdianId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasCrowdian InRootHas {
			get { return new InRootHasCrowdian { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutCrowdianUsesCrowd OutUsesCrowd {
			get { return new OutCrowdianUsesCrowd { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutCrowdianUsesUser OutUsesUser {
			get { return new OutCrowdianUsesUser { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutCrowdianHasCrowdianTypeAssign OutHasCrowdianTypeAssign {
			get { return new OutCrowdianHasCrowdianTypeAssign { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListCrowdianUsesHistoricCrowdianTypeAssign OutUsesHistoricCrowdianTypeAssign {
			get { return new OutListCrowdianUsesHistoricCrowdianTypeAssign { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class CrowdianType : GraphQueryNode, IQueryableCrowdianType {

		public virtual byte CrowdianTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasCrowdianType InRootHas {
			get { return new InRootHasCrowdianType { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInListCrowdianTypeAssignUsesCrowdianType InCrowdianTypeAssignUses {
			get { return new InListCrowdianTypeAssignUsesCrowdianType { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class CrowdianTypeAssign : GraphQueryNode, IQueryableCrowdianTypeAssign {

		public virtual float Weight { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInCrowdianHasCrowdianTypeAssign InCrowdianHas {
			get { return new InCrowdianHasCrowdianTypeAssign { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInCrowdianUsesHistoricCrowdianTypeAssign InCrowdianUsesHistoric {
			get { return new InCrowdianUsesHistoricCrowdianTypeAssign { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutCrowdianTypeAssignUsesCrowdianType OutUsesCrowdianType {
			get { return new OutCrowdianTypeAssignUsesCrowdianType { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInUserCreatesCrowdianTypeAssign InUserCreates {
			get { return new InUserCreatesCrowdianTypeAssign { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class Email : GraphQueryNode, IQueryableEmail {

		public virtual long EmailId { get; set; }
		public virtual string Address { get; set; }
		public virtual string Code { get; set; }
		public virtual long CreatedTimestamp { get; set; }
		public virtual long VerifiedTimestamp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasEmail InRootHas {
			get { return new InRootHasEmail { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInAppUsesEmail InAppUses {
			get { return new InAppUsesEmail { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInUserUsesEmail InUserUses {
			get { return new InUserUsesEmail { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class Label : GraphQueryNode, IQueryableLabel {

		public virtual long LabelId { get; set; }
		public virtual string Name { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasLabel InRootHas {
			get { return new InRootHasLabel { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutLabelHasArtifact OutHasArtifact {
			get { return new OutLabelHasArtifact { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class Member : GraphQueryNode, IQueryableMember {

		public virtual long MemberId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasMember InRootHas {
			get { return new InRootHasMember { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutMemberUsesApp OutUsesApp {
			get { return new OutMemberUsesApp { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutMemberUsesUser OutUsesUser {
			get { return new OutMemberUsesUser { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutMemberHasMemberTypeAssign OutHasMemberTypeAssign {
			get { return new OutMemberHasMemberTypeAssign { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListMemberUsesHistoricMemberTypeAssign OutUsesHistoricMemberTypeAssign {
			get { return new OutListMemberUsesHistoricMemberTypeAssign { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListMemberCreatesArtifact OutCreatesArtifact {
			get { return new OutListMemberCreatesArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListMemberCreatesMemberTypeAssign OutCreatesMemberTypeAssign {
			get { return new OutListMemberCreatesMemberTypeAssign { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class MemberType : GraphQueryNode, IQueryableMemberType {

		public virtual byte MemberTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasMemberType InRootHas {
			get { return new InRootHasMemberType { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInListMemberTypeAssignUsesMemberType InMemberTypeAssignUses {
			get { return new InListMemberTypeAssignUsesMemberType { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class MemberTypeAssign : GraphQueryNode, IQueryableMemberTypeAssign {


		/*--------------------------------------------------------------------------------------------*/
		public virtual IInMemberHasMemberTypeAssign InMemberHas {
			get { return new InMemberHasMemberTypeAssign { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInMemberUsesHistoricMemberTypeAssign InMemberUsesHistoric {
			get { return new InMemberUsesHistoricMemberTypeAssign { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInMemberCreatesMemberTypeAssign InMemberCreates {
			get { return new InMemberCreatesMemberTypeAssign { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutMemberTypeAssignUsesMemberType OutUsesMemberType {
			get { return new OutMemberTypeAssignUsesMemberType { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class Thing : GraphQueryNode, IQueryableThing {

		public virtual long ThingId { get; set; }
		public virtual bool IsClass { get; set; }
		public virtual string Name { get; set; }
		public virtual string Disamb { get; set; }
		public virtual string Note { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasThing InRootHas {
			get { return new InRootHasThing { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutThingHasArtifact OutHasArtifact {
			get { return new OutThingHasArtifact { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class Url : GraphQueryNode, IQueryableUrl {

		public virtual long UrlId { get; set; }
		public virtual string Name { get; set; }
		public virtual string AbsoluteUrl { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasUrl InRootHas {
			get { return new InRootHasUrl { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutUrlHasArtifact OutHasArtifact {
			get { return new OutUrlHasArtifact { Query = Query }; }
		}

	}

	/*================================================================================================*/
	public class User : GraphQueryNode, IQueryableUser {

		public virtual long UserId { get; set; }
		public virtual string Name { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInRootHasUser InRootHas {
			get { return new InRootHasUser { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInListCrowdianUsesUser InCrowdianUses {
			get { return new InListCrowdianUsesUser { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IInListMemberUsesUser InMemberUses {
			get { return new InListMemberUsesUser { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutUserHasArtifact OutHasArtifact {
			get { return new OutUserHasArtifact { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListUserUsesEmail OutUsesEmail {
			get { return new OutListUserUsesEmail { Query = Query }; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOutListUserCreatesCrowdianTypeAssign OutCreatesCrowdianTypeAssign {
			get { return new OutListUserCreatesCrowdianTypeAssign { Query = Query }; }
		}

	}


}