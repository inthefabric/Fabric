// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 11/20/2012 3:01:45 PM

using Weaver.Items;
using Weaver.Interfaces;

//NEXT: support validation and restrictions

namespace Fabric.Domain {


	/* Relationship Types */
	
	
	/*================================================================================================*/
	public partial class Contains : IWeaverRelType {
	
		public string Label { get { return "Contains"; } }

	}

	/*================================================================================================*/
	public partial class Has : IWeaverRelType {
	
		public string Label { get { return "Has"; } }

	}

	/*================================================================================================*/
	public partial class Uses : IWeaverRelType {
	
		public string Label { get { return "Uses"; } }

	}

	/*================================================================================================*/
	public partial class UsesHistoric : IWeaverRelType {
	
		public string Label { get { return "UsesHistoric"; } }

	}

	/*================================================================================================*/
	public partial class Creates : IWeaverRelType {
	
		public string Label { get { return "Creates"; } }

	}

	/*================================================================================================*/
	public partial class UsesPrimary : IWeaverRelType {
	
		public string Label { get { return "UsesPrimary"; } }

	}

	/*================================================================================================*/
	public partial class UsesRelated : IWeaverRelType {
	
		public string Label { get { return "UsesRelated"; } }

	}

	/*================================================================================================*/
	public partial class Replaces : IWeaverRelType {
	
		public string Label { get { return "Replaces"; } }

	}

	/*================================================================================================*/
	public partial class refinesPrimaryWith : IWeaverRelType {
	
		public string Label { get { return "refinesPrimaryWith"; } }

	}

	/*================================================================================================*/
	public partial class refinesRelatedWith : IWeaverRelType {
	
		public string Label { get { return "refinesRelatedWith"; } }

	}

	/*================================================================================================*/
	public partial class refinesTypeWith : IWeaverRelType {
	
		public string Label { get { return "refinesTypeWith"; } }

	}

	/*================================================================================================*/
	public partial class UsesAxis : IWeaverRelType {
	
		public string Label { get { return "UsesAxis"; } }

	}


	/* Relationships */


	/*================================================================================================*/
	public interface IRootContainsApp :
			IWeaverRel<IQueryRoot, IQueryApp>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryApp ToApp { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsApp :
			WeaverRel<IQueryRoot, Root, Contains, IQueryApp, App>,
			IRootContainsApp {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryApp ToApp { get { return ToNode; } }
		public override string Label { get { return "RootContainsApp"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsArtifact :
			IWeaverRel<IQueryRoot, IQueryArtifact>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsArtifact :
			WeaverRel<IQueryRoot, Root, Contains, IQueryArtifact, Artifact>,
			IRootContainsArtifact {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "RootContainsArtifact"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsArtifactType :
			IWeaverRel<IQueryRoot, IQueryArtifactType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryArtifactType ToArtifactType { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsArtifactType :
			WeaverRel<IQueryRoot, Root, Contains, IQueryArtifactType, ArtifactType>,
			IRootContainsArtifactType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryArtifactType ToArtifactType { get { return ToNode; } }
		public override string Label { get { return "RootContainsArtifactType"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsCrowd :
			IWeaverRel<IQueryRoot, IQueryCrowd>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryCrowd ToCrowd { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsCrowd :
			WeaverRel<IQueryRoot, Root, Contains, IQueryCrowd, Crowd>,
			IRootContainsCrowd {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryCrowd ToCrowd { get { return ToNode; } }
		public override string Label { get { return "RootContainsCrowd"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsCrowdian :
			IWeaverRel<IQueryRoot, IQueryCrowdian>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryCrowdian ToCrowdian { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsCrowdian :
			WeaverRel<IQueryRoot, Root, Contains, IQueryCrowdian, Crowdian>,
			IRootContainsCrowdian {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryCrowdian ToCrowdian { get { return ToNode; } }
		public override string Label { get { return "RootContainsCrowdian"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsCrowdianType :
			IWeaverRel<IQueryRoot, IQueryCrowdianType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryCrowdianType ToCrowdianType { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsCrowdianType :
			WeaverRel<IQueryRoot, Root, Contains, IQueryCrowdianType, CrowdianType>,
			IRootContainsCrowdianType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryCrowdianType ToCrowdianType { get { return ToNode; } }
		public override string Label { get { return "RootContainsCrowdianType"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsEmail :
			IWeaverRel<IQueryRoot, IQueryEmail>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryEmail ToEmail { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsEmail :
			WeaverRel<IQueryRoot, Root, Contains, IQueryEmail, Email>,
			IRootContainsEmail {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryEmail ToEmail { get { return ToNode; } }
		public override string Label { get { return "RootContainsEmail"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsLabel :
			IWeaverRel<IQueryRoot, IQueryLabel>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryLabel ToLabel { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsLabel :
			WeaverRel<IQueryRoot, Root, Contains, IQueryLabel, Label>,
			IRootContainsLabel {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryLabel ToLabel { get { return ToNode; } }
		public override string Label { get { return "RootContainsLabel"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsMember :
			IWeaverRel<IQueryRoot, IQueryMember>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryMember ToMember { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsMember :
			WeaverRel<IQueryRoot, Root, Contains, IQueryMember, Member>,
			IRootContainsMember {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryMember ToMember { get { return ToNode; } }
		public override string Label { get { return "RootContainsMember"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsMemberType :
			IWeaverRel<IQueryRoot, IQueryMemberType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryMemberType ToMemberType { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsMemberType :
			WeaverRel<IQueryRoot, Root, Contains, IQueryMemberType, MemberType>,
			IRootContainsMemberType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryMemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "RootContainsMemberType"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsThing :
			IWeaverRel<IQueryRoot, IQueryThing>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryThing ToThing { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsThing :
			WeaverRel<IQueryRoot, Root, Contains, IQueryThing, Thing>,
			IRootContainsThing {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryThing ToThing { get { return ToNode; } }
		public override string Label { get { return "RootContainsThing"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsUrl :
			IWeaverRel<IQueryRoot, IQueryUrl>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryUrl ToUrl { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsUrl :
			WeaverRel<IQueryRoot, Root, Contains, IQueryUrl, Url>,
			IRootContainsUrl {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryUrl ToUrl { get { return ToNode; } }
		public override string Label { get { return "RootContainsUrl"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsUser :
			IWeaverRel<IQueryRoot, IQueryUser>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryUser ToUser { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsUser :
			WeaverRel<IQueryRoot, Root, Contains, IQueryUser, User>,
			IRootContainsUser {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryUser ToUser { get { return ToNode; } }
		public override string Label { get { return "RootContainsUser"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsFactor :
			IWeaverRel<IQueryRoot, IQueryFactor>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryFactor ToFactor { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsFactor :
			WeaverRel<IQueryRoot, Root, Contains, IQueryFactor, Factor>,
			IRootContainsFactor {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryFactor ToFactor { get { return ToNode; } }
		public override string Label { get { return "RootContainsFactor"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsFactorAssertion :
			IWeaverRel<IQueryRoot, IQueryFactorAssertion>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryFactorAssertion ToFactorAssertion { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsFactorAssertion :
			WeaverRel<IQueryRoot, Root, Contains, IQueryFactorAssertion, FactorAssertion>,
			IRootContainsFactorAssertion {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryFactorAssertion ToFactorAssertion { get { return ToNode; } }
		public override string Label { get { return "RootContainsFactorAssertion"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsDescriptor :
			IWeaverRel<IQueryRoot, IQueryDescriptor>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryDescriptor ToDescriptor { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsDescriptor :
			WeaverRel<IQueryRoot, Root, Contains, IQueryDescriptor, Descriptor>,
			IRootContainsDescriptor {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryDescriptor ToDescriptor { get { return ToNode; } }
		public override string Label { get { return "RootContainsDescriptor"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsDescriptorType :
			IWeaverRel<IQueryRoot, IQueryDescriptorType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryDescriptorType ToDescriptorType { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsDescriptorType :
			WeaverRel<IQueryRoot, Root, Contains, IQueryDescriptorType, DescriptorType>,
			IRootContainsDescriptorType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryDescriptorType ToDescriptorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsDescriptorType"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsDirector :
			IWeaverRel<IQueryRoot, IQueryDirector>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryDirector ToDirector { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsDirector :
			WeaverRel<IQueryRoot, Root, Contains, IQueryDirector, Director>,
			IRootContainsDirector {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryDirector ToDirector { get { return ToNode; } }
		public override string Label { get { return "RootContainsDirector"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsDirectorType :
			IWeaverRel<IQueryRoot, IQueryDirectorType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryDirectorType ToDirectorType { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsDirectorType :
			WeaverRel<IQueryRoot, Root, Contains, IQueryDirectorType, DirectorType>,
			IRootContainsDirectorType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryDirectorType ToDirectorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsDirectorType"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsDirectorAction :
			IWeaverRel<IQueryRoot, IQueryDirectorAction>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryDirectorAction ToDirectorAction { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsDirectorAction :
			WeaverRel<IQueryRoot, Root, Contains, IQueryDirectorAction, DirectorAction>,
			IRootContainsDirectorAction {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryDirectorAction ToDirectorAction { get { return ToNode; } }
		public override string Label { get { return "RootContainsDirectorAction"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsEventor :
			IWeaverRel<IQueryRoot, IQueryEventor>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryEventor ToEventor { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsEventor :
			WeaverRel<IQueryRoot, Root, Contains, IQueryEventor, Eventor>,
			IRootContainsEventor {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryEventor ToEventor { get { return ToNode; } }
		public override string Label { get { return "RootContainsEventor"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsEventorType :
			IWeaverRel<IQueryRoot, IQueryEventorType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryEventorType ToEventorType { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsEventorType :
			WeaverRel<IQueryRoot, Root, Contains, IQueryEventorType, EventorType>,
			IRootContainsEventorType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryEventorType ToEventorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsEventorType"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsEventorPrecision :
			IWeaverRel<IQueryRoot, IQueryEventorPrecision>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryEventorPrecision ToEventorPrecision { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsEventorPrecision :
			WeaverRel<IQueryRoot, Root, Contains, IQueryEventorPrecision, EventorPrecision>,
			IRootContainsEventorPrecision {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryEventorPrecision ToEventorPrecision { get { return ToNode; } }
		public override string Label { get { return "RootContainsEventorPrecision"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsIdentor :
			IWeaverRel<IQueryRoot, IQueryIdentor>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryIdentor ToIdentor { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsIdentor :
			WeaverRel<IQueryRoot, Root, Contains, IQueryIdentor, Identor>,
			IRootContainsIdentor {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryIdentor ToIdentor { get { return ToNode; } }
		public override string Label { get { return "RootContainsIdentor"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsIdentorType :
			IWeaverRel<IQueryRoot, IQueryIdentorType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryIdentorType ToIdentorType { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsIdentorType :
			WeaverRel<IQueryRoot, Root, Contains, IQueryIdentorType, IdentorType>,
			IRootContainsIdentorType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryIdentorType ToIdentorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsIdentorType"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsLocator :
			IWeaverRel<IQueryRoot, IQueryLocator>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryLocator ToLocator { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsLocator :
			WeaverRel<IQueryRoot, Root, Contains, IQueryLocator, Locator>,
			IRootContainsLocator {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryLocator ToLocator { get { return ToNode; } }
		public override string Label { get { return "RootContainsLocator"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsLocatorType :
			IWeaverRel<IQueryRoot, IQueryLocatorType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryLocatorType ToLocatorType { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsLocatorType :
			WeaverRel<IQueryRoot, Root, Contains, IQueryLocatorType, LocatorType>,
			IRootContainsLocatorType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryLocatorType ToLocatorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsLocatorType"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsVector :
			IWeaverRel<IQueryRoot, IQueryVector>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryVector ToVector { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsVector :
			WeaverRel<IQueryRoot, Root, Contains, IQueryVector, Vector>,
			IRootContainsVector {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryVector ToVector { get { return ToNode; } }
		public override string Label { get { return "RootContainsVector"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsVectorType :
			IWeaverRel<IQueryRoot, IQueryVectorType>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryVectorType ToVectorType { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsVectorType :
			WeaverRel<IQueryRoot, Root, Contains, IQueryVectorType, VectorType>,
			IRootContainsVectorType {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryVectorType ToVectorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorType"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsVectorRange :
			IWeaverRel<IQueryRoot, IQueryVectorRange>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryVectorRange ToVectorRange { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsVectorRange :
			WeaverRel<IQueryRoot, Root, Contains, IQueryVectorRange, VectorRange>,
			IRootContainsVectorRange {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryVectorRange ToVectorRange { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorRange"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsVectorRangeLevel :
			IWeaverRel<IQueryRoot, IQueryVectorRangeLevel>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryVectorRangeLevel ToVectorRangeLevel { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsVectorRangeLevel :
			WeaverRel<IQueryRoot, Root, Contains, IQueryVectorRangeLevel, VectorRangeLevel>,
			IRootContainsVectorRangeLevel {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryVectorRangeLevel ToVectorRangeLevel { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorRangeLevel"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsVectorUnit :
			IWeaverRel<IQueryRoot, IQueryVectorUnit>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryVectorUnit ToVectorUnit { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsVectorUnit :
			WeaverRel<IQueryRoot, Root, Contains, IQueryVectorUnit, VectorUnit>,
			IRootContainsVectorUnit {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryVectorUnit ToVectorUnit { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorUnit"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsVectorUnitPrefix :
			IWeaverRel<IQueryRoot, IQueryVectorUnitPrefix>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryVectorUnitPrefix ToVectorUnitPrefix { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsVectorUnitPrefix :
			WeaverRel<IQueryRoot, Root, Contains, IQueryVectorUnitPrefix, VectorUnitPrefix>,
			IRootContainsVectorUnitPrefix {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryVectorUnitPrefix ToVectorUnitPrefix { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorUnitPrefix"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsOauthAccess :
			IWeaverRel<IQueryRoot, IQueryOauthAccess>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryOauthAccess ToOauthAccess { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsOauthAccess :
			WeaverRel<IQueryRoot, Root, Contains, IQueryOauthAccess, OauthAccess>,
			IRootContainsOauthAccess {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryOauthAccess ToOauthAccess { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthAccess"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsOauthDomain :
			IWeaverRel<IQueryRoot, IQueryOauthDomain>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryOauthDomain ToOauthDomain { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsOauthDomain :
			WeaverRel<IQueryRoot, Root, Contains, IQueryOauthDomain, OauthDomain>,
			IRootContainsOauthDomain {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryOauthDomain ToOauthDomain { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthDomain"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsOauthGrant :
			IWeaverRel<IQueryRoot, IQueryOauthGrant>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryOauthGrant ToOauthGrant { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsOauthGrant :
			WeaverRel<IQueryRoot, Root, Contains, IQueryOauthGrant, OauthGrant>,
			IRootContainsOauthGrant {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryOauthGrant ToOauthGrant { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthGrant"; } }

	}

	/*================================================================================================*/
	public interface IRootContainsOauthScope :
			IWeaverRel<IQueryRoot, IQueryOauthScope>, IWeaverQueryRel {

		IQueryRoot FromRoot { get; }
		IQueryOauthScope ToOauthScope { get; }

	}

	/*================================================================================================*/
	public partial class RootContainsOauthScope :
			WeaverRel<IQueryRoot, Root, Contains, IQueryOauthScope, OauthScope>,
			IRootContainsOauthScope {
			
		public virtual IQueryRoot FromRoot { get { return FromNode; } }
		public virtual IQueryOauthScope ToOauthScope { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthScope"; } }

	}

	/*================================================================================================*/
	public interface IAppHasArtifact :
			IWeaverRel<IQueryApp, IQueryArtifact>, IWeaverQueryRel {

		IQueryApp FromApp { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public partial class AppHasArtifact :
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
	public partial class AppUsesEmail :
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
	public partial class ArtifactUsesArtifactType :
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
	public partial class CrowdHasArtifact :
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
	public partial class CrowdianUsesCrowd :
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
	public partial class CrowdianUsesUser :
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
	public partial class CrowdianHasCrowdianTypeAssign :
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
	public partial class CrowdianUsesHistoricCrowdianTypeAssign :
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
	public partial class CrowdianTypeAssignUsesCrowdianType :
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
	public partial class LabelHasArtifact :
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
	public partial class MemberUsesApp :
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
	public partial class MemberUsesUser :
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
	public partial class MemberHasMemberTypeAssign :
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
	public partial class MemberUsesHistoricMemberTypeAssign :
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
	public partial class MemberCreatesArtifact :
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
	public partial class MemberCreatesMemberTypeAssign :
			WeaverRel<IQueryMember, Member, Creates, IQueryMemberTypeAssign, MemberTypeAssign>,
			IMemberCreatesMemberTypeAssign {
			
		public virtual IQueryMember FromMember { get { return FromNode; } }
		public virtual IQueryMemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IMemberCreatesFactor :
			IWeaverRel<IQueryMember, IQueryFactor>, IWeaverQueryRel {

		IQueryMember FromMember { get; }
		IQueryFactor ToFactor { get; }

	}

	/*================================================================================================*/
	public partial class MemberCreatesFactor :
			WeaverRel<IQueryMember, Member, Creates, IQueryFactor, Factor>,
			IMemberCreatesFactor {
			
		public virtual IQueryMember FromMember { get { return FromNode; } }
		public virtual IQueryFactor ToFactor { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesFactor"; } }

	}

	/*================================================================================================*/
	public interface IMemberTypeAssignUsesMemberType :
			IWeaverRel<IQueryMemberTypeAssign, IQueryMemberType>, IWeaverQueryRel {

		IQueryMemberTypeAssign FromMemberTypeAssign { get; }
		IQueryMemberType ToMemberType { get; }

	}

	/*================================================================================================*/
	public partial class MemberTypeAssignUsesMemberType :
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
	public partial class ThingHasArtifact :
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
	public partial class UrlHasArtifact :
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
	public partial class UserHasArtifact :
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
	public partial class UserUsesEmail :
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
	public partial class UserCreatesCrowdianTypeAssign :
			WeaverRel<IQueryUser, User, Creates, IQueryCrowdianTypeAssign, CrowdianTypeAssign>,
			IUserCreatesCrowdianTypeAssign {
			
		public virtual IQueryUser FromUser { get { return FromNode; } }
		public virtual IQueryCrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "UserCreatesCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public interface IFactorUsesPrimaryArtifact :
			IWeaverRel<IQueryFactor, IQueryArtifact>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public partial class FactorUsesPrimaryArtifact :
			WeaverRel<IQueryFactor, Factor, UsesPrimary, IQueryArtifact, Artifact>,
			IFactorUsesPrimaryArtifact {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorUsesPrimaryArtifact"; } }

	}

	/*================================================================================================*/
	public interface IFactorUsesRelatedArtifact :
			IWeaverRel<IQueryFactor, IQueryArtifact>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public partial class FactorUsesRelatedArtifact :
			WeaverRel<IQueryFactor, Factor, UsesRelated, IQueryArtifact, Artifact>,
			IFactorUsesRelatedArtifact {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorUsesRelatedArtifact"; } }

	}

	/*================================================================================================*/
	public interface IFactorUsesFactorAssertion :
			IWeaverRel<IQueryFactor, IQueryFactorAssertion>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryFactorAssertion ToFactorAssertion { get; }

	}

	/*================================================================================================*/
	public partial class FactorUsesFactorAssertion :
			WeaverRel<IQueryFactor, Factor, Uses, IQueryFactorAssertion, FactorAssertion>,
			IFactorUsesFactorAssertion {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryFactorAssertion ToFactorAssertion { get { return ToNode; } }
		public override string Label { get { return "FactorUsesFactorAssertion"; } }

	}

	/*================================================================================================*/
	public interface IFactorReplacesFactor :
			IWeaverRel<IQueryFactor, IQueryFactor>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryFactor ToFactor { get; }

	}

	/*================================================================================================*/
	public partial class FactorReplacesFactor :
			WeaverRel<IQueryFactor, Factor, Replaces, IQueryFactor, Factor>,
			IFactorReplacesFactor {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryFactor ToFactor { get { return ToNode; } }
		public override string Label { get { return "FactorReplacesFactor"; } }

	}

	/*================================================================================================*/
	public interface IFactorUsesDescriptor :
			IWeaverRel<IQueryFactor, IQueryDescriptor>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryDescriptor ToDescriptor { get; }

	}

	/*================================================================================================*/
	public partial class FactorUsesDescriptor :
			WeaverRel<IQueryFactor, Factor, Uses, IQueryDescriptor, Descriptor>,
			IFactorUsesDescriptor {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryDescriptor ToDescriptor { get { return ToNode; } }
		public override string Label { get { return "FactorUsesDescriptor"; } }

	}

	/*================================================================================================*/
	public interface IFactorUsesDirector :
			IWeaverRel<IQueryFactor, IQueryDirector>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryDirector ToDirector { get; }

	}

	/*================================================================================================*/
	public partial class FactorUsesDirector :
			WeaverRel<IQueryFactor, Factor, Uses, IQueryDirector, Director>,
			IFactorUsesDirector {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryDirector ToDirector { get { return ToNode; } }
		public override string Label { get { return "FactorUsesDirector"; } }

	}

	/*================================================================================================*/
	public interface IFactorUsesEventor :
			IWeaverRel<IQueryFactor, IQueryEventor>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryEventor ToEventor { get; }

	}

	/*================================================================================================*/
	public partial class FactorUsesEventor :
			WeaverRel<IQueryFactor, Factor, Uses, IQueryEventor, Eventor>,
			IFactorUsesEventor {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryEventor ToEventor { get { return ToNode; } }
		public override string Label { get { return "FactorUsesEventor"; } }

	}

	/*================================================================================================*/
	public interface IFactorUsesIdentor :
			IWeaverRel<IQueryFactor, IQueryIdentor>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryIdentor ToIdentor { get; }

	}

	/*================================================================================================*/
	public partial class FactorUsesIdentor :
			WeaverRel<IQueryFactor, Factor, Uses, IQueryIdentor, Identor>,
			IFactorUsesIdentor {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryIdentor ToIdentor { get { return ToNode; } }
		public override string Label { get { return "FactorUsesIdentor"; } }

	}

	/*================================================================================================*/
	public interface IFactorUsesLocator :
			IWeaverRel<IQueryFactor, IQueryLocator>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryLocator ToLocator { get; }

	}

	/*================================================================================================*/
	public partial class FactorUsesLocator :
			WeaverRel<IQueryFactor, Factor, Uses, IQueryLocator, Locator>,
			IFactorUsesLocator {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryLocator ToLocator { get { return ToNode; } }
		public override string Label { get { return "FactorUsesLocator"; } }

	}

	/*================================================================================================*/
	public interface IFactorUsesVector :
			IWeaverRel<IQueryFactor, IQueryVector>, IWeaverQueryRel {

		IQueryFactor FromFactor { get; }
		IQueryVector ToVector { get; }

	}

	/*================================================================================================*/
	public partial class FactorUsesVector :
			WeaverRel<IQueryFactor, Factor, Uses, IQueryVector, Vector>,
			IFactorUsesVector {
			
		public virtual IQueryFactor FromFactor { get { return FromNode; } }
		public virtual IQueryVector ToVector { get { return ToNode; } }
		public override string Label { get { return "FactorUsesVector"; } }

	}

	/*================================================================================================*/
	public interface IDescriptorUsesDescriptorType :
			IWeaverRel<IQueryDescriptor, IQueryDescriptorType>, IWeaverQueryRel {

		IQueryDescriptor FromDescriptor { get; }
		IQueryDescriptorType ToDescriptorType { get; }

	}

	/*================================================================================================*/
	public partial class DescriptorUsesDescriptorType :
			WeaverRel<IQueryDescriptor, Descriptor, Uses, IQueryDescriptorType, DescriptorType>,
			IDescriptorUsesDescriptorType {
			
		public virtual IQueryDescriptor FromDescriptor { get { return FromNode; } }
		public virtual IQueryDescriptorType ToDescriptorType { get { return ToNode; } }
		public override string Label { get { return "DescriptorUsesDescriptorType"; } }

	}

	/*================================================================================================*/
	public interface IDescriptorrefinesPrimaryWithArtifact :
			IWeaverRel<IQueryDescriptor, IQueryArtifact>, IWeaverQueryRel {

		IQueryDescriptor FromDescriptor { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public partial class DescriptorrefinesPrimaryWithArtifact :
			WeaverRel<IQueryDescriptor, Descriptor, refinesPrimaryWith, IQueryArtifact, Artifact>,
			IDescriptorrefinesPrimaryWithArtifact {
			
		public virtual IQueryDescriptor FromDescriptor { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "DescriptorrefinesPrimaryWithArtifact"; } }

	}

	/*================================================================================================*/
	public interface IDescriptorrefinesRelatedWithArtifact :
			IWeaverRel<IQueryDescriptor, IQueryArtifact>, IWeaverQueryRel {

		IQueryDescriptor FromDescriptor { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public partial class DescriptorrefinesRelatedWithArtifact :
			WeaverRel<IQueryDescriptor, Descriptor, refinesRelatedWith, IQueryArtifact, Artifact>,
			IDescriptorrefinesRelatedWithArtifact {
			
		public virtual IQueryDescriptor FromDescriptor { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "DescriptorrefinesRelatedWithArtifact"; } }

	}

	/*================================================================================================*/
	public interface IDescriptorrefinesTypeWithArtifact :
			IWeaverRel<IQueryDescriptor, IQueryArtifact>, IWeaverQueryRel {

		IQueryDescriptor FromDescriptor { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public partial class DescriptorrefinesTypeWithArtifact :
			WeaverRel<IQueryDescriptor, Descriptor, refinesTypeWith, IQueryArtifact, Artifact>,
			IDescriptorrefinesTypeWithArtifact {
			
		public virtual IQueryDescriptor FromDescriptor { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "DescriptorrefinesTypeWithArtifact"; } }

	}

	/*================================================================================================*/
	public interface IDirectorUsesDirectorType :
			IWeaverRel<IQueryDirector, IQueryDirectorType>, IWeaverQueryRel {

		IQueryDirector FromDirector { get; }
		IQueryDirectorType ToDirectorType { get; }

	}

	/*================================================================================================*/
	public partial class DirectorUsesDirectorType :
			WeaverRel<IQueryDirector, Director, Uses, IQueryDirectorType, DirectorType>,
			IDirectorUsesDirectorType {
			
		public virtual IQueryDirector FromDirector { get { return FromNode; } }
		public virtual IQueryDirectorType ToDirectorType { get { return ToNode; } }
		public override string Label { get { return "DirectorUsesDirectorType"; } }

	}

	/*================================================================================================*/
	public interface IDirectorUsesPrimaryDirectorAction :
			IWeaverRel<IQueryDirector, IQueryDirectorAction>, IWeaverQueryRel {

		IQueryDirector FromDirector { get; }
		IQueryDirectorAction ToDirectorAction { get; }

	}

	/*================================================================================================*/
	public partial class DirectorUsesPrimaryDirectorAction :
			WeaverRel<IQueryDirector, Director, UsesPrimary, IQueryDirectorAction, DirectorAction>,
			IDirectorUsesPrimaryDirectorAction {
			
		public virtual IQueryDirector FromDirector { get { return FromNode; } }
		public virtual IQueryDirectorAction ToDirectorAction { get { return ToNode; } }
		public override string Label { get { return "DirectorUsesPrimaryDirectorAction"; } }

	}

	/*================================================================================================*/
	public interface IDirectorUsesRelatedDirectorAction :
			IWeaverRel<IQueryDirector, IQueryDirectorAction>, IWeaverQueryRel {

		IQueryDirector FromDirector { get; }
		IQueryDirectorAction ToDirectorAction { get; }

	}

	/*================================================================================================*/
	public partial class DirectorUsesRelatedDirectorAction :
			WeaverRel<IQueryDirector, Director, UsesRelated, IQueryDirectorAction, DirectorAction>,
			IDirectorUsesRelatedDirectorAction {
			
		public virtual IQueryDirector FromDirector { get { return FromNode; } }
		public virtual IQueryDirectorAction ToDirectorAction { get { return ToNode; } }
		public override string Label { get { return "DirectorUsesRelatedDirectorAction"; } }

	}

	/*================================================================================================*/
	public interface IEventorUsesEventorType :
			IWeaverRel<IQueryEventor, IQueryEventorType>, IWeaverQueryRel {

		IQueryEventor FromEventor { get; }
		IQueryEventorType ToEventorType { get; }

	}

	/*================================================================================================*/
	public partial class EventorUsesEventorType :
			WeaverRel<IQueryEventor, Eventor, Uses, IQueryEventorType, EventorType>,
			IEventorUsesEventorType {
			
		public virtual IQueryEventor FromEventor { get { return FromNode; } }
		public virtual IQueryEventorType ToEventorType { get { return ToNode; } }
		public override string Label { get { return "EventorUsesEventorType"; } }

	}

	/*================================================================================================*/
	public interface IEventorUsesEventorPrecision :
			IWeaverRel<IQueryEventor, IQueryEventorPrecision>, IWeaverQueryRel {

		IQueryEventor FromEventor { get; }
		IQueryEventorPrecision ToEventorPrecision { get; }

	}

	/*================================================================================================*/
	public partial class EventorUsesEventorPrecision :
			WeaverRel<IQueryEventor, Eventor, Uses, IQueryEventorPrecision, EventorPrecision>,
			IEventorUsesEventorPrecision {
			
		public virtual IQueryEventor FromEventor { get { return FromNode; } }
		public virtual IQueryEventorPrecision ToEventorPrecision { get { return ToNode; } }
		public override string Label { get { return "EventorUsesEventorPrecision"; } }

	}

	/*================================================================================================*/
	public interface IIdentorUsesIdentorType :
			IWeaverRel<IQueryIdentor, IQueryIdentorType>, IWeaverQueryRel {

		IQueryIdentor FromIdentor { get; }
		IQueryIdentorType ToIdentorType { get; }

	}

	/*================================================================================================*/
	public partial class IdentorUsesIdentorType :
			WeaverRel<IQueryIdentor, Identor, Uses, IQueryIdentorType, IdentorType>,
			IIdentorUsesIdentorType {
			
		public virtual IQueryIdentor FromIdentor { get { return FromNode; } }
		public virtual IQueryIdentorType ToIdentorType { get { return ToNode; } }
		public override string Label { get { return "IdentorUsesIdentorType"; } }

	}

	/*================================================================================================*/
	public interface ILocatorUsesLocatorType :
			IWeaverRel<IQueryLocator, IQueryLocatorType>, IWeaverQueryRel {

		IQueryLocator FromLocator { get; }
		IQueryLocatorType ToLocatorType { get; }

	}

	/*================================================================================================*/
	public partial class LocatorUsesLocatorType :
			WeaverRel<IQueryLocator, Locator, Uses, IQueryLocatorType, LocatorType>,
			ILocatorUsesLocatorType {
			
		public virtual IQueryLocator FromLocator { get { return FromNode; } }
		public virtual IQueryLocatorType ToLocatorType { get { return ToNode; } }
		public override string Label { get { return "LocatorUsesLocatorType"; } }

	}

	/*================================================================================================*/
	public interface IVectorUsesAxisArtifact :
			IWeaverRel<IQueryVector, IQueryArtifact>, IWeaverQueryRel {

		IQueryVector FromVector { get; }
		IQueryArtifact ToArtifact { get; }

	}

	/*================================================================================================*/
	public partial class VectorUsesAxisArtifact :
			WeaverRel<IQueryVector, Vector, UsesAxis, IQueryArtifact, Artifact>,
			IVectorUsesAxisArtifact {
			
		public virtual IQueryVector FromVector { get { return FromNode; } }
		public virtual IQueryArtifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "VectorUsesAxisArtifact"; } }

	}

	/*================================================================================================*/
	public interface IVectorUsesVectorType :
			IWeaverRel<IQueryVector, IQueryVectorType>, IWeaverQueryRel {

		IQueryVector FromVector { get; }
		IQueryVectorType ToVectorType { get; }

	}

	/*================================================================================================*/
	public partial class VectorUsesVectorType :
			WeaverRel<IQueryVector, Vector, Uses, IQueryVectorType, VectorType>,
			IVectorUsesVectorType {
			
		public virtual IQueryVector FromVector { get { return FromNode; } }
		public virtual IQueryVectorType ToVectorType { get { return ToNode; } }
		public override string Label { get { return "VectorUsesVectorType"; } }

	}

	/*================================================================================================*/
	public interface IVectorUsesVectorUnit :
			IWeaverRel<IQueryVector, IQueryVectorUnit>, IWeaverQueryRel {

		IQueryVector FromVector { get; }
		IQueryVectorUnit ToVectorUnit { get; }

	}

	/*================================================================================================*/
	public partial class VectorUsesVectorUnit :
			WeaverRel<IQueryVector, Vector, Uses, IQueryVectorUnit, VectorUnit>,
			IVectorUsesVectorUnit {
			
		public virtual IQueryVector FromVector { get { return FromNode; } }
		public virtual IQueryVectorUnit ToVectorUnit { get { return ToNode; } }
		public override string Label { get { return "VectorUsesVectorUnit"; } }

	}

	/*================================================================================================*/
	public interface IVectorUsesVectorUnitPrefix :
			IWeaverRel<IQueryVector, IQueryVectorUnitPrefix>, IWeaverQueryRel {

		IQueryVector FromVector { get; }
		IQueryVectorUnitPrefix ToVectorUnitPrefix { get; }

	}

	/*================================================================================================*/
	public partial class VectorUsesVectorUnitPrefix :
			WeaverRel<IQueryVector, Vector, Uses, IQueryVectorUnitPrefix, VectorUnitPrefix>,
			IVectorUsesVectorUnitPrefix {
			
		public virtual IQueryVector FromVector { get { return FromNode; } }
		public virtual IQueryVectorUnitPrefix ToVectorUnitPrefix { get { return ToNode; } }
		public override string Label { get { return "VectorUsesVectorUnitPrefix"; } }

	}

	/*================================================================================================*/
	public interface IVectorTypeUsesVectorRange :
			IWeaverRel<IQueryVectorType, IQueryVectorRange>, IWeaverQueryRel {

		IQueryVectorType FromVectorType { get; }
		IQueryVectorRange ToVectorRange { get; }

	}

	/*================================================================================================*/
	public partial class VectorTypeUsesVectorRange :
			WeaverRel<IQueryVectorType, VectorType, Uses, IQueryVectorRange, VectorRange>,
			IVectorTypeUsesVectorRange {
			
		public virtual IQueryVectorType FromVectorType { get { return FromNode; } }
		public virtual IQueryVectorRange ToVectorRange { get { return ToNode; } }
		public override string Label { get { return "VectorTypeUsesVectorRange"; } }

	}

	/*================================================================================================*/
	public interface IVectorRangeUsesVectorRangeLevel :
			IWeaverRel<IQueryVectorRange, IQueryVectorRangeLevel>, IWeaverQueryRel {

		IQueryVectorRange FromVectorRange { get; }
		IQueryVectorRangeLevel ToVectorRangeLevel { get; }

	}

	/*================================================================================================*/
	public partial class VectorRangeUsesVectorRangeLevel :
			WeaverRel<IQueryVectorRange, VectorRange, Uses, IQueryVectorRangeLevel, VectorRangeLevel>,
			IVectorRangeUsesVectorRangeLevel {
			
		public virtual IQueryVectorRange FromVectorRange { get { return FromNode; } }
		public virtual IQueryVectorRangeLevel ToVectorRangeLevel { get { return ToNode; } }
		public override string Label { get { return "VectorRangeUsesVectorRangeLevel"; } }

	}

	/*================================================================================================*/
	public interface IOauthAccessUsesApp :
			IWeaverRel<IQueryOauthAccess, IQueryApp>, IWeaverQueryRel {

		IQueryOauthAccess FromOauthAccess { get; }
		IQueryApp ToApp { get; }

	}

	/*================================================================================================*/
	public partial class OauthAccessUsesApp :
			WeaverRel<IQueryOauthAccess, OauthAccess, Uses, IQueryApp, App>,
			IOauthAccessUsesApp {
			
		public virtual IQueryOauthAccess FromOauthAccess { get { return FromNode; } }
		public virtual IQueryApp ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthAccessUsesApp"; } }

	}

	/*================================================================================================*/
	public interface IOauthAccessUsesUser :
			IWeaverRel<IQueryOauthAccess, IQueryUser>, IWeaverQueryRel {

		IQueryOauthAccess FromOauthAccess { get; }
		IQueryUser ToUser { get; }

	}

	/*================================================================================================*/
	public partial class OauthAccessUsesUser :
			WeaverRel<IQueryOauthAccess, OauthAccess, Uses, IQueryUser, User>,
			IOauthAccessUsesUser {
			
		public virtual IQueryOauthAccess FromOauthAccess { get { return FromNode; } }
		public virtual IQueryUser ToUser { get { return ToNode; } }
		public override string Label { get { return "OauthAccessUsesUser"; } }

	}

	/*================================================================================================*/
	public interface IOauthDomainUsesApp :
			IWeaverRel<IQueryOauthDomain, IQueryApp>, IWeaverQueryRel {

		IQueryOauthDomain FromOauthDomain { get; }
		IQueryApp ToApp { get; }

	}

	/*================================================================================================*/
	public partial class OauthDomainUsesApp :
			WeaverRel<IQueryOauthDomain, OauthDomain, Uses, IQueryApp, App>,
			IOauthDomainUsesApp {
			
		public virtual IQueryOauthDomain FromOauthDomain { get { return FromNode; } }
		public virtual IQueryApp ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthDomainUsesApp"; } }

	}

	/*================================================================================================*/
	public interface IOauthGrantUsesApp :
			IWeaverRel<IQueryOauthGrant, IQueryApp>, IWeaverQueryRel {

		IQueryOauthGrant FromOauthGrant { get; }
		IQueryApp ToApp { get; }

	}

	/*================================================================================================*/
	public partial class OauthGrantUsesApp :
			WeaverRel<IQueryOauthGrant, OauthGrant, Uses, IQueryApp, App>,
			IOauthGrantUsesApp {
			
		public virtual IQueryOauthGrant FromOauthGrant { get { return FromNode; } }
		public virtual IQueryApp ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthGrantUsesApp"; } }

	}

	/*================================================================================================*/
	public interface IOauthGrantUsesUser :
			IWeaverRel<IQueryOauthGrant, IQueryUser>, IWeaverQueryRel {

		IQueryOauthGrant FromOauthGrant { get; }
		IQueryUser ToUser { get; }

	}

	/*================================================================================================*/
	public partial class OauthGrantUsesUser :
			WeaverRel<IQueryOauthGrant, OauthGrant, Uses, IQueryUser, User>,
			IOauthGrantUsesUser {
			
		public virtual IQueryOauthGrant FromOauthGrant { get { return FromNode; } }
		public virtual IQueryUser ToUser { get { return ToNode; } }
		public override string Label { get { return "OauthGrantUsesUser"; } }

	}

	/*================================================================================================*/
	public interface IOauthScopeUsesApp :
			IWeaverRel<IQueryOauthScope, IQueryApp>, IWeaverQueryRel {

		IQueryOauthScope FromOauthScope { get; }
		IQueryApp ToApp { get; }

	}

	/*================================================================================================*/
	public partial class OauthScopeUsesApp :
			WeaverRel<IQueryOauthScope, OauthScope, Uses, IQueryApp, App>,
			IOauthScopeUsesApp {
			
		public virtual IQueryOauthScope FromOauthScope { get { return FromNode; } }
		public virtual IQueryApp ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthScopeUsesApp"; } }

	}

	/*================================================================================================*/
	public interface IOauthScopeUsesUser :
			IWeaverRel<IQueryOauthScope, IQueryUser>, IWeaverQueryRel {

		IQueryOauthScope FromOauthScope { get; }
		IQueryUser ToUser { get; }

	}

	/*================================================================================================*/
	public partial class OauthScopeUsesUser :
			WeaverRel<IQueryOauthScope, OauthScope, Uses, IQueryUser, User>,
			IOauthScopeUsesUser {
			
		public virtual IQueryOauthScope FromOauthScope { get { return FromNode; } }
		public virtual IQueryUser ToUser { get { return ToNode; } }
		public override string Label { get { return "OauthScopeUsesUser"; } }

	}



	/* Query Nodes interfaces */


	/*================================================================================================*/
	//[Shortcut()]
	public interface IQueryNodeForType : IWeaverQueryNode {


	}

	/*================================================================================================*/
	//[Shortcut()]
	public interface IQueryNodeForAction : IWeaverQueryNode {


	}

	/*================================================================================================*/
	//[Shortcut(R)]
	public interface IQueryRoot : IWeaverQueryNode {

		IRootContainsApp OutContainsApps { get; } //OutToZeroOrMore
		IRootContainsArtifact OutContainsArtifacts { get; } //OutToZeroOrMore
		IRootContainsArtifactType OutContainsArtifactTypes { get; } //OutToZeroOrMore
		IRootContainsCrowd OutContainsCrowds { get; } //OutToZeroOrMore
		IRootContainsCrowdian OutContainsCrowdians { get; } //OutToZeroOrMore
		IRootContainsCrowdianType OutContainsCrowdianTypes { get; } //OutToZeroOrMore
		IRootContainsEmail OutContainsEmails { get; } //OutToZeroOrMore
		IRootContainsLabel OutContainsLabels { get; } //OutToZeroOrMore
		IRootContainsMember OutContainsMembers { get; } //OutToZeroOrMore
		IRootContainsMemberType OutContainsMemberTypes { get; } //OutToZeroOrMore
		IRootContainsThing OutContainsThings { get; } //OutToZeroOrMore
		IRootContainsUrl OutContainsUrls { get; } //OutToZeroOrMore
		IRootContainsUser OutContainsUsers { get; } //OutToZeroOrMore
		IRootContainsFactor OutContainsFactors { get; } //OutToZeroOrMore
		IRootContainsFactorAssertion OutContainsFactorAssertions { get; } //OutToZeroOrMore
		IRootContainsDescriptor OutContainsDescriptors { get; } //OutToZeroOrMore
		IRootContainsDescriptorType OutContainsDescriptorTypes { get; } //OutToZeroOrMore
		IRootContainsDirector OutContainsDirectors { get; } //OutToZeroOrMore
		IRootContainsDirectorType OutContainsDirectorTypes { get; } //OutToZeroOrMore
		IRootContainsDirectorAction OutContainsDirectorActions { get; } //OutToZeroOrMore
		IRootContainsEventor OutContainsEventors { get; } //OutToZeroOrMore
		IRootContainsEventorType OutContainsEventorTypes { get; } //OutToZeroOrMore
		IRootContainsEventorPrecision OutContainsEventorPrecisions { get; } //OutToZeroOrMore
		IRootContainsIdentor OutContainsIdentors { get; } //OutToZeroOrMore
		IRootContainsIdentorType OutContainsIdentorTypes { get; } //OutToZeroOrMore
		IRootContainsLocator OutContainsLocators { get; } //OutToZeroOrMore
		IRootContainsLocatorType OutContainsLocatorTypes { get; } //OutToZeroOrMore
		IRootContainsVector OutContainsVectors { get; } //OutToZeroOrMore
		IRootContainsVectorType OutContainsVectorTypes { get; } //OutToZeroOrMore
		IRootContainsVectorRange OutContainsVectorRanges { get; } //OutToZeroOrMore
		IRootContainsVectorRangeLevel OutContainsVectorRangeLevels { get; } //OutToZeroOrMore
		IRootContainsVectorUnit OutContainsVectorUnits { get; } //OutToZeroOrMore
		IRootContainsVectorUnitPrefix OutContainsVectorUnitPrefixs { get; } //OutToZeroOrMore
		IRootContainsOauthAccess OutContainsOauthAccesss { get; } //OutToZeroOrMore
		IRootContainsOauthDomain OutContainsOauthDomains { get; } //OutToZeroOrMore
		IRootContainsOauthGrant OutContainsOauthGrants { get; } //OutToZeroOrMore
		IRootContainsOauthScope OutContainsOauthScopes { get; } //OutToZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(Ap)]
	public interface IQueryApp : IWeaverQueryNode {

		IRootContainsApp InRootContains { get; } //InFromOne
		IAppHasArtifact OutHasArtifact { get; } //OutToOne
		IAppUsesEmail OutUsesEmail { get; } //OutToOne
		IMemberUsesApp InMembersUses { get; } //InFromOneOrMore
		IOauthAccessUsesApp InOauthAccesssUses { get; } //InFromZeroOrMore
		IOauthDomainUsesApp InOauthDomainsUses { get; } //InFromZeroOrMore
		IOauthGrantUsesApp InOauthGrantsUses { get; } //InFromZeroOrMore
		IOauthScopeUsesApp InOauthScopesUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(A)]
	public interface IQueryArtifact : IWeaverQueryNode {

		IRootContainsArtifact InRootContains { get; } //InFromOne
		IAppHasArtifact InAppHas { get; } //InFromZeroOrOne
		IArtifactUsesArtifactType OutUsesArtifactType { get; } //OutToOne
		ICrowdHasArtifact InCrowdHas { get; } //InFromZeroOrOne
		ILabelHasArtifact InLabelHas { get; } //InFromZeroOrOne
		IMemberCreatesArtifact InMemberCreates { get; } //InFromOne
		IThingHasArtifact InThingHas { get; } //InFromZeroOrOne
		IUrlHasArtifact InUrlHas { get; } //InFromZeroOrOne
		IUserHasArtifact InUserHas { get; } //InFromZeroOrOne
		IFactorUsesPrimaryArtifact InFactorsUsesPrimary { get; } //InFromZeroOrMore
		IFactorUsesRelatedArtifact InFactorsUsesRelated { get; } //InFromZeroOrMore
		IDescriptorrefinesPrimaryWithArtifact InDescriptorsrefinesPrimaryWith { get; } //InFromZeroOrMore
		IDescriptorrefinesRelatedWithArtifact InDescriptorsrefinesRelatedWith { get; } //InFromZeroOrMore
		IDescriptorrefinesTypeWithArtifact InDescriptorsrefinesTypeWith { get; } //InFromZeroOrMore
		IVectorUsesAxisArtifact InVectorsUsesAxis { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(AT)]
	public interface IQueryArtifactType : IWeaverQueryNode {

		IRootContainsArtifactType InRootContains { get; } //InFromOne
		IArtifactUsesArtifactType InArtifactsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(C)]
	public interface IQueryCrowd : IWeaverQueryNode {

		IRootContainsCrowd InRootContains { get; } //InFromOne
		ICrowdHasArtifact OutHasArtifact { get; } //OutToOne
		ICrowdianUsesCrowd InCrowdiansUses { get; } //InFromOneOrMore

	}

	/*================================================================================================*/
	//[Shortcut(Cn)]
	public interface IQueryCrowdian : IWeaverQueryNode {

		IRootContainsCrowdian InRootContains { get; } //InFromOne
		ICrowdianUsesCrowd OutUsesCrowd { get; } //OutToOne
		ICrowdianUsesUser OutUsesUser { get; } //OutToOne
		ICrowdianHasCrowdianTypeAssign OutHasCrowdianTypeAssign { get; } //OutToOne
		ICrowdianUsesHistoricCrowdianTypeAssign OutUsesHistoricCrowdianTypeAssigns { get; } //OutToZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(CT)]
	public interface IQueryCrowdianType : IWeaverQueryNode {

		IRootContainsCrowdianType InRootContains { get; } //InFromOne
		ICrowdianTypeAssignUsesCrowdianType InCrowdianTypeAssignsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(CTA)]
	public interface IQueryCrowdianTypeAssign : IWeaverQueryNode {

		ICrowdianHasCrowdianTypeAssign InCrowdianHas { get; } //InFromOne
		ICrowdianUsesHistoricCrowdianTypeAssign InCrowdianUsesHistoric { get; } //InFromOne
		ICrowdianTypeAssignUsesCrowdianType OutUsesCrowdianType { get; } //OutToOne
		IUserCreatesCrowdianTypeAssign InUserCreates { get; } //InFromOne

	}

	/*================================================================================================*/
	//[Shortcut(E)]
	public interface IQueryEmail : IWeaverQueryNode {

		IRootContainsEmail InRootContains { get; } //InFromOne
		IAppUsesEmail InAppUses { get; } //InFromOne
		IUserUsesEmail InUserUses { get; } //InFromOne

	}

	/*================================================================================================*/
	//[Shortcut(L)]
	public interface IQueryLabel : IWeaverQueryNode {

		IRootContainsLabel InRootContains { get; } //InFromOne
		ILabelHasArtifact OutHasArtifact { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(M)]
	public interface IQueryMember : IWeaverQueryNode {

		IRootContainsMember InRootContains { get; } //InFromOne
		IMemberUsesApp OutUsesApp { get; } //OutToOne
		IMemberUsesUser OutUsesUser { get; } //OutToOne
		IMemberHasMemberTypeAssign OutHasMemberTypeAssign { get; } //OutToOne
		IMemberUsesHistoricMemberTypeAssign OutUsesHistoricMemberTypeAssigns { get; } //OutToZeroOrMore
		IMemberCreatesArtifact OutCreatesArtifacts { get; } //OutToZeroOrMore
		IMemberCreatesMemberTypeAssign OutCreatesMemberTypeAssigns { get; } //OutToZeroOrMore
		IMemberCreatesFactor OutCreatesFactors { get; } //OutToZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(MT)]
	public interface IQueryMemberType : IWeaverQueryNode {

		IRootContainsMemberType InRootContains { get; } //InFromOne
		IMemberTypeAssignUsesMemberType InMemberTypeAssignsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(MTA)]
	public interface IQueryMemberTypeAssign : IWeaverQueryNode {

		IMemberHasMemberTypeAssign InMemberHas { get; } //InFromOne
		IMemberUsesHistoricMemberTypeAssign InMemberUsesHistoric { get; } //InFromOne
		IMemberCreatesMemberTypeAssign InMemberCreates { get; } //InFromOne
		IMemberTypeAssignUsesMemberType OutUsesMemberType { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(T)]
	public interface IQueryThing : IWeaverQueryNode {

		IRootContainsThing InRootContains { get; } //InFromOne
		IThingHasArtifact OutHasArtifact { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(Ur)]
	public interface IQueryUrl : IWeaverQueryNode {

		IRootContainsUrl InRootContains { get; } //InFromOne
		IUrlHasArtifact OutHasArtifact { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(U)]
	public interface IQueryUser : IWeaverQueryNode {

		IRootContainsUser InRootContains { get; } //InFromOne
		ICrowdianUsesUser InCrowdiansUses { get; } //InFromZeroOrMore
		IMemberUsesUser InMembersUses { get; } //InFromOneOrMore
		IUserHasArtifact OutHasArtifact { get; } //OutToOne
		IUserUsesEmail OutUsesEmail { get; } //OutToOne
		IUserCreatesCrowdianTypeAssign OutCreatesCrowdianTypeAssigns { get; } //OutToZeroOrMore
		IOauthAccessUsesUser InOauthAccesssUses { get; } //InFromZeroOrMore
		IOauthGrantUsesUser InOauthGrantsUses { get; } //InFromZeroOrMore
		IOauthScopeUsesUser InOauthScopesUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(F)]
	public interface IQueryFactor : IWeaverQueryNode {

		IRootContainsFactor InRootContains { get; } //InFromOne
		IMemberCreatesFactor InMemberCreates { get; } //InFromOne
		IFactorUsesPrimaryArtifact OutUsesPrimaryArtifact { get; } //OutToOne
		IFactorUsesRelatedArtifact OutUsesRelatedArtifact { get; } //OutToOne
		IFactorUsesFactorAssertion OutUsesFactorAssertion { get; } //OutToOne
		IFactorReplacesFactor OutReplacesFactor { get; } //OutToZeroOrOne
		IFactorUsesDescriptor OutUsesDescriptor { get; } //OutToOne
		IFactorUsesDirector OutUsesDirector { get; } //OutToZeroOrOne
		IFactorUsesEventor OutUsesEventor { get; } //OutToZeroOrOne
		IFactorUsesIdentor OutUsesIdentor { get; } //OutToZeroOrOne
		IFactorUsesLocator OutUsesLocator { get; } //OutToZeroOrOne
		IFactorUsesVector OutUsesVector { get; } //OutToZeroOrOne

	}

	/*================================================================================================*/
	//[Shortcut(FA)]
	public interface IQueryFactorAssertion : IWeaverQueryNode {

		IRootContainsFactorAssertion InRootContains { get; } //InFromOne
		IFactorUsesFactorAssertion InFactorsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut()]
	public interface IQueryFactorElementNode : IWeaverQueryNode {


	}

	/*================================================================================================*/
	//[Shortcut(De)]
	public interface IQueryDescriptor : IWeaverQueryNode {

		IRootContainsDescriptor InRootContains { get; } //InFromOne
		IFactorUsesDescriptor InFactorsUses { get; } //InFromOneOrMore
		IDescriptorUsesDescriptorType OutUsesDescriptorType { get; } //OutToOne
		IDescriptorrefinesPrimaryWithArtifact OutrefinesPrimaryWithArtifact { get; } //OutToZeroOrOne
		IDescriptorrefinesRelatedWithArtifact OutrefinesRelatedWithArtifact { get; } //OutToZeroOrOne
		IDescriptorrefinesTypeWithArtifact OutrefinesTypeWithArtifact { get; } //OutToZeroOrOne

	}

	/*================================================================================================*/
	//[Shortcut(DeT)]
	public interface IQueryDescriptorType : IWeaverQueryNode {

		IRootContainsDescriptorType InRootContains { get; } //InFromOne
		IDescriptorUsesDescriptorType InDescriptorsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(Di)]
	public interface IQueryDirector : IWeaverQueryNode {

		IRootContainsDirector InRootContains { get; } //InFromOne
		IFactorUsesDirector InFactorsUses { get; } //InFromOneOrMore
		IDirectorUsesDirectorType OutUsesDirectorType { get; } //OutToOne
		IDirectorUsesPrimaryDirectorAction OutUsesPrimaryDirectorAction { get; } //OutToOne
		IDirectorUsesRelatedDirectorAction OutUsesRelatedDirectorAction { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(DiT)]
	public interface IQueryDirectorType : IWeaverQueryNode {

		IRootContainsDirectorType InRootContains { get; } //InFromOne
		IDirectorUsesDirectorType InDirectorsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(DiA)]
	public interface IQueryDirectorAction : IWeaverQueryNode {

		IRootContainsDirectorAction InRootContains { get; } //InFromOne
		IDirectorUsesPrimaryDirectorAction InDirectorsUsesPrimary { get; } //InFromZeroOrMore
		IDirectorUsesRelatedDirectorAction InDirectorsUsesRelated { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(Ev)]
	public interface IQueryEventor : IWeaverQueryNode {

		IRootContainsEventor InRootContains { get; } //InFromOne
		IFactorUsesEventor InFactorsUses { get; } //InFromOneOrMore
		IEventorUsesEventorType OutUsesEventorType { get; } //OutToOne
		IEventorUsesEventorPrecision OutUsesEventorPrecision { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(EvT)]
	public interface IQueryEventorType : IWeaverQueryNode {

		IRootContainsEventorType InRootContains { get; } //InFromOne
		IEventorUsesEventorType InEventorsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(EvP)]
	public interface IQueryEventorPrecision : IWeaverQueryNode {

		IRootContainsEventorPrecision InRootContains { get; } //InFromOne
		IEventorUsesEventorPrecision InEventorsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(Id)]
	public interface IQueryIdentor : IWeaverQueryNode {

		IRootContainsIdentor InRootContains { get; } //InFromOne
		IFactorUsesIdentor InFactorsUses { get; } //InFromOneOrMore
		IIdentorUsesIdentorType OutUsesIdentorType { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(IdT)]
	public interface IQueryIdentorType : IWeaverQueryNode {

		IRootContainsIdentorType InRootContains { get; } //InFromOne
		IIdentorUsesIdentorType InIdentorsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(Lo)]
	public interface IQueryLocator : IWeaverQueryNode {

		IRootContainsLocator InRootContains { get; } //InFromOne
		IFactorUsesLocator InFactorsUses { get; } //InFromOneOrMore
		ILocatorUsesLocatorType OutUsesLocatorType { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(LoT)]
	public interface IQueryLocatorType : IWeaverQueryNode {

		IRootContainsLocatorType InRootContains { get; } //InFromOne
		ILocatorUsesLocatorType InLocatorsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(Ve)]
	public interface IQueryVector : IWeaverQueryNode {

		IRootContainsVector InRootContains { get; } //InFromOne
		IFactorUsesVector InFactorsUses { get; } //InFromOneOrMore
		IVectorUsesAxisArtifact OutUsesAxisArtifact { get; } //OutToOne
		IVectorUsesVectorType OutUsesVectorType { get; } //OutToOne
		IVectorUsesVectorUnit OutUsesVectorUnit { get; } //OutToOne
		IVectorUsesVectorUnitPrefix OutUsesVectorUnitPrefix { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(VeT)]
	public interface IQueryVectorType : IWeaverQueryNode {

		IRootContainsVectorType InRootContains { get; } //InFromOne
		IVectorUsesVectorType InVectorsUses { get; } //InFromZeroOrMore
		IVectorTypeUsesVectorRange OutUsesVectorRange { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(VeR)]
	public interface IQueryVectorRange : IWeaverQueryNode {

		IRootContainsVectorRange InRootContains { get; } //InFromOne
		IVectorTypeUsesVectorRange InVectorTypesUses { get; } //InFromZeroOrMore
		IVectorRangeUsesVectorRangeLevel OutUsesVectorRangeLevels { get; } //OutToZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(VeRL)]
	public interface IQueryVectorRangeLevel : IWeaverQueryNode {

		IRootContainsVectorRangeLevel InRootContains { get; } //InFromOne
		IVectorRangeUsesVectorRangeLevel InVectorRangesUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(VeU)]
	public interface IQueryVectorUnit : IWeaverQueryNode {

		IRootContainsVectorUnit InRootContains { get; } //InFromOne
		IVectorUsesVectorUnit InVectorsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(VeUP)]
	public interface IQueryVectorUnitPrefix : IWeaverQueryNode {

		IRootContainsVectorUnitPrefix InRootContains { get; } //InFromOne
		IVectorUsesVectorUnitPrefix InVectorsUses { get; } //InFromZeroOrMore

	}

	/*================================================================================================*/
	//[Shortcut(OA)]
	public interface IQueryOauthAccess : IWeaverQueryNode {

		IRootContainsOauthAccess InRootContains { get; } //InFromOne
		IOauthAccessUsesApp OutUsesApp { get; } //OutToOne
		IOauthAccessUsesUser OutUsesUser { get; } //OutToZeroOrOne

	}

	/*================================================================================================*/
	//[Shortcut(OD)]
	public interface IQueryOauthDomain : IWeaverQueryNode {

		IRootContainsOauthDomain InRootContains { get; } //InFromOne
		IOauthDomainUsesApp OutUsesApp { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(OG)]
	public interface IQueryOauthGrant : IWeaverQueryNode {

		IRootContainsOauthGrant InRootContains { get; } //InFromOne
		IOauthGrantUsesApp OutUsesApp { get; } //OutToOne
		IOauthGrantUsesUser OutUsesUser { get; } //OutToOne

	}

	/*================================================================================================*/
	//[Shortcut(OS)]
	public interface IQueryOauthScope : IWeaverQueryNode {

		IRootContainsOauthScope InRootContains { get; } //InFromOne
		IOauthScopeUsesApp OutUsesApp { get; } //OutToOne
		IOauthScopeUsesUser OutUsesUser { get; } //OutToOne

	}


	/* Nodes */


	/*================================================================================================*/
	public partial class NodeForType : WeaverNode, IQueryNodeForType {
	
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
	public partial class NodeForAction : WeaverNode, IQueryNodeForAction {
	
		//[PropIsTimestamp(True)]
		public virtual long PerformedTimestamp { get; set; }

		//[PropLenMax(256)]
		public virtual string Note { get; set; }


	}

	/*================================================================================================*/
	public partial class Root : WeaverNode, IQueryRoot {
	
		public override bool IsRoot { get { return true; } }

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsApp OutContainsApps {
			get { return NewRel<RootContainsApp>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsArtifact OutContainsArtifacts {
			get { return NewRel<RootContainsArtifact>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsArtifactType OutContainsArtifactTypes {
			get { return NewRel<RootContainsArtifactType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsCrowd OutContainsCrowds {
			get { return NewRel<RootContainsCrowd>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsCrowdian OutContainsCrowdians {
			get { return NewRel<RootContainsCrowdian>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsCrowdianType OutContainsCrowdianTypes {
			get { return NewRel<RootContainsCrowdianType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsEmail OutContainsEmails {
			get { return NewRel<RootContainsEmail>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsLabel OutContainsLabels {
			get { return NewRel<RootContainsLabel>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsMember OutContainsMembers {
			get { return NewRel<RootContainsMember>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsMemberType OutContainsMemberTypes {
			get { return NewRel<RootContainsMemberType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsThing OutContainsThings {
			get { return NewRel<RootContainsThing>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsUrl OutContainsUrls {
			get { return NewRel<RootContainsUrl>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsUser OutContainsUsers {
			get { return NewRel<RootContainsUser>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsFactor OutContainsFactors {
			get { return NewRel<RootContainsFactor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsFactorAssertion OutContainsFactorAssertions {
			get { return NewRel<RootContainsFactorAssertion>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDescriptor OutContainsDescriptors {
			get { return NewRel<RootContainsDescriptor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDescriptorType OutContainsDescriptorTypes {
			get { return NewRel<RootContainsDescriptorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDirector OutContainsDirectors {
			get { return NewRel<RootContainsDirector>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDirectorType OutContainsDirectorTypes {
			get { return NewRel<RootContainsDirectorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDirectorAction OutContainsDirectorActions {
			get { return NewRel<RootContainsDirectorAction>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsEventor OutContainsEventors {
			get { return NewRel<RootContainsEventor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsEventorType OutContainsEventorTypes {
			get { return NewRel<RootContainsEventorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsEventorPrecision OutContainsEventorPrecisions {
			get { return NewRel<RootContainsEventorPrecision>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsIdentor OutContainsIdentors {
			get { return NewRel<RootContainsIdentor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsIdentorType OutContainsIdentorTypes {
			get { return NewRel<RootContainsIdentorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsLocator OutContainsLocators {
			get { return NewRel<RootContainsLocator>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsLocatorType OutContainsLocatorTypes {
			get { return NewRel<RootContainsLocatorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVector OutContainsVectors {
			get { return NewRel<RootContainsVector>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorType OutContainsVectorTypes {
			get { return NewRel<RootContainsVectorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorRange OutContainsVectorRanges {
			get { return NewRel<RootContainsVectorRange>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorRangeLevel OutContainsVectorRangeLevels {
			get { return NewRel<RootContainsVectorRangeLevel>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorUnit OutContainsVectorUnits {
			get { return NewRel<RootContainsVectorUnit>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorUnitPrefix OutContainsVectorUnitPrefixs {
			get { return NewRel<RootContainsVectorUnitPrefix>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsOauthAccess OutContainsOauthAccesss {
			get { return NewRel<RootContainsOauthAccess>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsOauthDomain OutContainsOauthDomains {
			get { return NewRel<RootContainsOauthDomain>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsOauthGrant OutContainsOauthGrants {
			get { return NewRel<RootContainsOauthGrant>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsOauthScope OutContainsOauthScopes {
			get { return NewRel<RootContainsOauthScope>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class App : WeaverNode, IQueryApp {
	
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
		public virtual IRootContainsApp InRootContains {
			get { return NewRel<RootContainsApp>(WeaverRelConn.InFromOne); }
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

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthAccessUsesApp InOauthAccesssUses {
			get { return NewRel<OauthAccessUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthDomainUsesApp InOauthDomainsUses {
			get { return NewRel<OauthDomainUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthGrantUsesApp InOauthGrantsUses {
			get { return NewRel<OauthGrantUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthScopeUsesApp InOauthScopesUses {
			get { return NewRel<OauthScopeUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Artifact : WeaverNode, IQueryArtifact {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long ArtifactId { get; set; }

		public virtual bool IsPrivate { get; set; }

		//[PropIsTimestamp(True)]
		public virtual long CreatedTimestamp { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsArtifact InRootContains {
			get { return NewRel<RootContainsArtifact>(WeaverRelConn.InFromOne); }
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

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesPrimaryArtifact InFactorsUsesPrimary {
			get { return NewRel<FactorUsesPrimaryArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesRelatedArtifact InFactorsUsesRelated {
			get { return NewRel<FactorUsesRelatedArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDescriptorrefinesPrimaryWithArtifact InDescriptorsrefinesPrimaryWith {
			get { return NewRel<DescriptorrefinesPrimaryWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDescriptorrefinesRelatedWithArtifact InDescriptorsrefinesRelatedWith {
			get { return NewRel<DescriptorrefinesRelatedWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDescriptorrefinesTypeWithArtifact InDescriptorsrefinesTypeWith {
			get { return NewRel<DescriptorrefinesTypeWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorUsesAxisArtifact InVectorsUsesAxis {
			get { return NewRel<VectorUsesAxisArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class ArtifactType : WeaverNode, IQueryArtifactType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte ArtifactTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsArtifactType InRootContains {
			get { return NewRel<RootContainsArtifactType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IArtifactUsesArtifactType InArtifactsUses {
			get { return NewRel<ArtifactUsesArtifactType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Crowd : WeaverNode, IQueryCrowd {
	
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
		public virtual IRootContainsCrowd InRootContains {
			get { return NewRel<RootContainsCrowd>(WeaverRelConn.InFromOne); }
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
	public partial class Crowdian : WeaverNode, IQueryCrowdian {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long CrowdianId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsCrowdian InRootContains {
			get { return NewRel<RootContainsCrowdian>(WeaverRelConn.InFromOne); }
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
	public partial class CrowdianType : WeaverNode, IQueryCrowdianType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte CrowdianTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsCrowdianType InRootContains {
			get { return NewRel<RootContainsCrowdianType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ICrowdianTypeAssignUsesCrowdianType InCrowdianTypeAssignsUses {
			get { return NewRel<CrowdianTypeAssignUsesCrowdianType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class CrowdianTypeAssign : WeaverNode, IQueryCrowdianTypeAssign {
	
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
	public partial class Email : WeaverNode, IQueryEmail {
	
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
		public virtual IRootContainsEmail InRootContains {
			get { return NewRel<RootContainsEmail>(WeaverRelConn.InFromOne); }
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
	public partial class Label : WeaverNode, IQueryLabel {
	
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
		public virtual IRootContainsLabel InRootContains {
			get { return NewRel<RootContainsLabel>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ILabelHasArtifact OutHasArtifact {
			get { return NewRel<LabelHasArtifact>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class Member : WeaverNode, IQueryMember {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long MemberId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsMember InRootContains {
			get { return NewRel<RootContainsMember>(WeaverRelConn.InFromOne); }
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

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesFactor OutCreatesFactors {
			get { return NewRel<MemberCreatesFactor>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class MemberType : WeaverNode, IQueryMemberType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte MemberTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsMemberType InRootContains {
			get { return NewRel<RootContainsMemberType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberTypeAssignUsesMemberType InMemberTypeAssignsUses {
			get { return NewRel<MemberTypeAssignUsesMemberType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class MemberTypeAssign : WeaverNode, IQueryMemberTypeAssign {
	

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
	public partial class Thing : WeaverNode, IQueryThing {
	
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
		public virtual IRootContainsThing InRootContains {
			get { return NewRel<RootContainsThing>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IThingHasArtifact OutHasArtifact {
			get { return NewRel<ThingHasArtifact>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class Url : WeaverNode, IQueryUrl {
	
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
		public virtual IRootContainsUrl InRootContains {
			get { return NewRel<RootContainsUrl>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IUrlHasArtifact OutHasArtifact {
			get { return NewRel<UrlHasArtifact>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class User : WeaverNode, IQueryUser {
	
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
		public virtual IRootContainsUser InRootContains {
			get { return NewRel<RootContainsUser>(WeaverRelConn.InFromOne); }
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

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthAccessUsesUser InOauthAccesssUses {
			get { return NewRel<OauthAccessUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthGrantUsesUser InOauthGrantsUses {
			get { return NewRel<OauthGrantUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthScopeUsesUser InOauthScopesUses {
			get { return NewRel<OauthScopeUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Factor : WeaverNode, IQueryFactor {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long FactorId { get; set; }

		public virtual bool IsPublic { get; set; }

		public virtual bool IsDefining { get; set; }

		//[PropIsTimestamp(True)]
		public virtual long CreatedTimestamp { get; set; }

		//[PropIsNullable(True)]
		public virtual long DeletedTimestamp { get; set; }

		//[PropIsNullable(True)]
		public virtual long CompletedTimestamp { get; set; }

		//[PropLenMax(256)]
		public virtual string Note { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsFactor InRootContains {
			get { return NewRel<RootContainsFactor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IMemberCreatesFactor InMemberCreates {
			get { return NewRel<MemberCreatesFactor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesPrimaryArtifact OutUsesPrimaryArtifact {
			get { return NewRel<FactorUsesPrimaryArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesRelatedArtifact OutUsesRelatedArtifact {
			get { return NewRel<FactorUsesRelatedArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesFactorAssertion OutUsesFactorAssertion {
			get { return NewRel<FactorUsesFactorAssertion>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorReplacesFactor OutReplacesFactor {
			get { return NewRel<FactorReplacesFactor>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesDescriptor OutUsesDescriptor {
			get { return NewRel<FactorUsesDescriptor>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesDirector OutUsesDirector {
			get { return NewRel<FactorUsesDirector>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesEventor OutUsesEventor {
			get { return NewRel<FactorUsesEventor>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesIdentor OutUsesIdentor {
			get { return NewRel<FactorUsesIdentor>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesLocator OutUsesLocator {
			get { return NewRel<FactorUsesLocator>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesVector OutUsesVector {
			get { return NewRel<FactorUsesVector>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public partial class FactorAssertion : WeaverNode, IQueryFactorAssertion {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte FactorAssertionId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsFactorAssertion InRootContains {
			get { return NewRel<RootContainsFactorAssertion>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesFactorAssertion InFactorsUses {
			get { return NewRel<FactorUsesFactorAssertion>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class FactorElementNode : WeaverNode, IQueryFactorElementNode {
	

	}

	/*================================================================================================*/
	public partial class Descriptor : WeaverNode, IQueryDescriptor {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DescriptorId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDescriptor InRootContains {
			get { return NewRel<RootContainsDescriptor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesDescriptor InFactorsUses {
			get { return NewRel<FactorUsesDescriptor>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDescriptorUsesDescriptorType OutUsesDescriptorType {
			get { return NewRel<DescriptorUsesDescriptorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDescriptorrefinesPrimaryWithArtifact OutrefinesPrimaryWithArtifact {
			get { return NewRel<DescriptorrefinesPrimaryWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDescriptorrefinesRelatedWithArtifact OutrefinesRelatedWithArtifact {
			get { return NewRel<DescriptorrefinesRelatedWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDescriptorrefinesTypeWithArtifact OutrefinesTypeWithArtifact {
			get { return NewRel<DescriptorrefinesTypeWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public partial class DescriptorType : WeaverNode, IQueryDescriptorType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte DescriptorTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDescriptorType InRootContains {
			get { return NewRel<RootContainsDescriptorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDescriptorUsesDescriptorType InDescriptorsUses {
			get { return NewRel<DescriptorUsesDescriptorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Director : WeaverNode, IQueryDirector {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DirectorId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDirector InRootContains {
			get { return NewRel<RootContainsDirector>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesDirector InFactorsUses {
			get { return NewRel<FactorUsesDirector>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDirectorUsesDirectorType OutUsesDirectorType {
			get { return NewRel<DirectorUsesDirectorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDirectorUsesPrimaryDirectorAction OutUsesPrimaryDirectorAction {
			get { return NewRel<DirectorUsesPrimaryDirectorAction>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDirectorUsesRelatedDirectorAction OutUsesRelatedDirectorAction {
			get { return NewRel<DirectorUsesRelatedDirectorAction>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class DirectorType : WeaverNode, IQueryDirectorType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte DirectorTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDirectorType InRootContains {
			get { return NewRel<RootContainsDirectorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDirectorUsesDirectorType InDirectorsUses {
			get { return NewRel<DirectorUsesDirectorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class DirectorAction : WeaverNode, IQueryDirectorAction {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte DirectorActionId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsDirectorAction InRootContains {
			get { return NewRel<RootContainsDirectorAction>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDirectorUsesPrimaryDirectorAction InDirectorsUsesPrimary {
			get { return NewRel<DirectorUsesPrimaryDirectorAction>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IDirectorUsesRelatedDirectorAction InDirectorsUsesRelated {
			get { return NewRel<DirectorUsesRelatedDirectorAction>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Eventor : WeaverNode, IQueryEventor {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long EventorId { get; set; }

		public virtual long DateTimeTimestamp { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsEventor InRootContains {
			get { return NewRel<RootContainsEventor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesEventor InFactorsUses {
			get { return NewRel<FactorUsesEventor>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IEventorUsesEventorType OutUsesEventorType {
			get { return NewRel<EventorUsesEventorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IEventorUsesEventorPrecision OutUsesEventorPrecision {
			get { return NewRel<EventorUsesEventorPrecision>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class EventorType : WeaverNode, IQueryEventorType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte EventorTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsEventorType InRootContains {
			get { return NewRel<RootContainsEventorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IEventorUsesEventorType InEventorsUses {
			get { return NewRel<EventorUsesEventorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class EventorPrecision : WeaverNode, IQueryEventorPrecision {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte EventorPrecisionId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsEventorPrecision InRootContains {
			get { return NewRel<RootContainsEventorPrecision>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IEventorUsesEventorPrecision InEventorsUses {
			get { return NewRel<EventorUsesEventorPrecision>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Identor : WeaverNode, IQueryIdentor {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long IdentorId { get; set; }

		//[PropLenMax(128)]
		public virtual string Value { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsIdentor InRootContains {
			get { return NewRel<RootContainsIdentor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesIdentor InFactorsUses {
			get { return NewRel<FactorUsesIdentor>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IIdentorUsesIdentorType OutUsesIdentorType {
			get { return NewRel<IdentorUsesIdentorType>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class IdentorType : WeaverNode, IQueryIdentorType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte IdentorTypeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsIdentorType InRootContains {
			get { return NewRel<RootContainsIdentorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IIdentorUsesIdentorType InIdentorsUses {
			get { return NewRel<IdentorUsesIdentorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Locator : WeaverNode, IQueryLocator {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long LocatorId { get; set; }

		public virtual double ValueX { get; set; }

		public virtual double ValueY { get; set; }

		public virtual double ValueZ { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsLocator InRootContains {
			get { return NewRel<RootContainsLocator>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesLocator InFactorsUses {
			get { return NewRel<FactorUsesLocator>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ILocatorUsesLocatorType OutUsesLocatorType {
			get { return NewRel<LocatorUsesLocatorType>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class LocatorType : WeaverNode, IQueryLocatorType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte LocatorTypeId { get; set; }

		public virtual double MinX { get; set; }

		public virtual double MaxX { get; set; }

		public virtual double MinY { get; set; }

		public virtual double MaxY { get; set; }

		public virtual double MinZ { get; set; }

		public virtual double MaxZ { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsLocatorType InRootContains {
			get { return NewRel<RootContainsLocatorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ILocatorUsesLocatorType InLocatorsUses {
			get { return NewRel<LocatorUsesLocatorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Vector : WeaverNode, IQueryVector {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorId { get; set; }

		public virtual long Value { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVector InRootContains {
			get { return NewRel<RootContainsVector>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IFactorUsesVector InFactorsUses {
			get { return NewRel<FactorUsesVector>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorUsesAxisArtifact OutUsesAxisArtifact {
			get { return NewRel<VectorUsesAxisArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorUsesVectorType OutUsesVectorType {
			get { return NewRel<VectorUsesVectorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorUsesVectorUnit OutUsesVectorUnit {
			get { return NewRel<VectorUsesVectorUnit>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorUsesVectorUnitPrefix OutUsesVectorUnitPrefix {
			get { return NewRel<VectorUsesVectorUnitPrefix>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class VectorType : WeaverNode, IQueryVectorType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorTypeId { get; set; }

		public virtual long Min { get; set; }

		public virtual long Max { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorType InRootContains {
			get { return NewRel<RootContainsVectorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorUsesVectorType InVectorsUses {
			get { return NewRel<VectorUsesVectorType>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorTypeUsesVectorRange OutUsesVectorRange {
			get { return NewRel<VectorTypeUsesVectorRange>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class VectorRange : WeaverNode, IQueryVectorRange {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorRangeId { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorRange InRootContains {
			get { return NewRel<RootContainsVectorRange>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorTypeUsesVectorRange InVectorTypesUses {
			get { return NewRel<VectorTypeUsesVectorRange>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorRangeUsesVectorRangeLevel OutUsesVectorRangeLevels {
			get { return NewRel<VectorRangeUsesVectorRangeLevel>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class VectorRangeLevel : WeaverNode, IQueryVectorRangeLevel {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorRangeLevelId { get; set; }

		public virtual float Position { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorRangeLevel InRootContains {
			get { return NewRel<RootContainsVectorRangeLevel>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorRangeUsesVectorRangeLevel InVectorRangesUses {
			get { return NewRel<VectorRangeUsesVectorRangeLevel>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class VectorUnit : WeaverNode, IQueryVectorUnit {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorUnitId { get; set; }

		//[PropLenMax(8)]
		public virtual string Symbol { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorUnit InRootContains {
			get { return NewRel<RootContainsVectorUnit>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorUsesVectorUnit InVectorsUses {
			get { return NewRel<VectorUsesVectorUnit>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class VectorUnitPrefix : WeaverNode, IQueryVectorUnitPrefix {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorUnitPrefixId { get; set; }

		//[PropLenMax(8)]
		public virtual string Symbol { get; set; }

		public virtual double Amount { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsVectorUnitPrefix InRootContains {
			get { return NewRel<RootContainsVectorUnitPrefix>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IVectorUsesVectorUnitPrefix InVectorsUses {
			get { return NewRel<VectorUsesVectorUnitPrefix>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class OauthAccess : WeaverNode, IQueryOauthAccess {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthAccessId { get; set; }

		//[PropIsNullable(True)]
		//[PropIsUnique(True)]
		//[PropLen(32)]
		public virtual string Token { get; set; }

		//[PropIsNullable(True)]
		//[PropLen(32)]
		public virtual string Refresh { get; set; }

		public virtual long ExpiresTimestamp { get; set; }

		public virtual bool IsClientOnly { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsOauthAccess InRootContains {
			get { return NewRel<RootContainsOauthAccess>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthAccessUsesApp OutUsesApp {
			get { return NewRel<OauthAccessUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthAccessUsesUser OutUsesUser {
			get { return NewRel<OauthAccessUsesUser>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public partial class OauthDomain : WeaverNode, IQueryOauthDomain {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthDomainId { get; set; }

		//[PropLenMax(256)]
		public virtual string Domain { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsOauthDomain InRootContains {
			get { return NewRel<RootContainsOauthDomain>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthDomainUsesApp OutUsesApp {
			get { return NewRel<OauthDomainUsesApp>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class OauthGrant : WeaverNode, IQueryOauthGrant {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthGrantId { get; set; }

		//[PropLenMax(450)]
		public virtual string RedirectUri { get; set; }

		//[PropIsUnique(True)]
		//[PropLen(32)]
		public virtual string Code { get; set; }

		public virtual long ExpiresTimestamp { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsOauthGrant InRootContains {
			get { return NewRel<RootContainsOauthGrant>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthGrantUsesApp OutUsesApp {
			get { return NewRel<OauthGrantUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthGrantUsesUser OutUsesUser {
			get { return NewRel<OauthGrantUsesUser>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class OauthScope : WeaverNode, IQueryOauthScope {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthScopeId { get; set; }

		public virtual bool Allow { get; set; }

		//[PropIsTimestamp(True)]
		public virtual long CreatedTimestamp { get; set; }


		/*--------------------------------------------------------------------------------------------*/
		public virtual IRootContainsOauthScope InRootContains {
			get { return NewRel<RootContainsOauthScope>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthScopeUsesApp OutUsesApp {
			get { return NewRel<OauthScopeUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IOauthScopeUsesUser OutUsesUser {
			get { return NewRel<OauthScopeUsesUser>(WeaverRelConn.OutToOne); }
		}

	}

}
