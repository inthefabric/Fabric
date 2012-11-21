﻿// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 11/20/2012 11:27:15 PM

using Weaver.Items;
using Weaver.Interfaces;

//NEXT: support validation and restrictions

namespace Fabric.Domain {


	/* Relationship Types */
	
	
	/*================================================================================================*/
	public class Contains : IWeaverRelType {
	
		public string Label { get { return "Contains"; } }

	}

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

	/*================================================================================================*/
	public class UsesPrimary : IWeaverRelType {
	
		public string Label { get { return "UsesPrimary"; } }

	}

	/*================================================================================================*/
	public class UsesRelated : IWeaverRelType {
	
		public string Label { get { return "UsesRelated"; } }

	}

	/*================================================================================================*/
	public class Replaces : IWeaverRelType {
	
		public string Label { get { return "Replaces"; } }

	}

	/*================================================================================================*/
	public class refinesPrimaryWith : IWeaverRelType {
	
		public string Label { get { return "refinesPrimaryWith"; } }

	}

	/*================================================================================================*/
	public class refinesRelatedWith : IWeaverRelType {
	
		public string Label { get { return "refinesRelatedWith"; } }

	}

	/*================================================================================================*/
	public class refinesTypeWith : IWeaverRelType {
	
		public string Label { get { return "refinesTypeWith"; } }

	}

	/*================================================================================================*/
	public class UsesAxis : IWeaverRelType {
	
		public string Label { get { return "UsesAxis"; } }

	}


	/* Relationships */


	/*================================================================================================*/
	public class RootContainsApp : WeaverRel<Root, Contains, App> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "RootContainsApp"; } }

	}

	/*================================================================================================*/
	public class RootContainsArtifact : WeaverRel<Root, Contains, Artifact> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "RootContainsArtifact"; } }

	}

	/*================================================================================================*/
	public class RootContainsArtifactType : WeaverRel<Root, Contains, ArtifactType> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual ArtifactType ToArtifactType { get { return ToNode; } }
		public override string Label { get { return "RootContainsArtifactType"; } }

	}

	/*================================================================================================*/
	public class RootContainsCrowd : WeaverRel<Root, Contains, Crowd> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Crowd ToCrowd { get { return ToNode; } }
		public override string Label { get { return "RootContainsCrowd"; } }

	}

	/*================================================================================================*/
	public class RootContainsCrowdian : WeaverRel<Root, Contains, Crowdian> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Crowdian ToCrowdian { get { return ToNode; } }
		public override string Label { get { return "RootContainsCrowdian"; } }

	}

	/*================================================================================================*/
	public class RootContainsCrowdianType : WeaverRel<Root, Contains, CrowdianType> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual CrowdianType ToCrowdianType { get { return ToNode; } }
		public override string Label { get { return "RootContainsCrowdianType"; } }

	}

	/*================================================================================================*/
	public class RootContainsEmail : WeaverRel<Root, Contains, Email> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Email ToEmail { get { return ToNode; } }
		public override string Label { get { return "RootContainsEmail"; } }

	}

	/*================================================================================================*/
	public class RootContainsLabel : WeaverRel<Root, Contains, Label> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Label ToLabel { get { return ToNode; } }
		public override string Label { get { return "RootContainsLabel"; } }

	}

	/*================================================================================================*/
	public class RootContainsMember : WeaverRel<Root, Contains, Member> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Member ToMember { get { return ToNode; } }
		public override string Label { get { return "RootContainsMember"; } }

	}

	/*================================================================================================*/
	public class RootContainsMemberType : WeaverRel<Root, Contains, MemberType> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual MemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "RootContainsMemberType"; } }

	}

	/*================================================================================================*/
	public class RootContainsThing : WeaverRel<Root, Contains, Thing> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Thing ToThing { get { return ToNode; } }
		public override string Label { get { return "RootContainsThing"; } }

	}

	/*================================================================================================*/
	public class RootContainsUrl : WeaverRel<Root, Contains, Url> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Url ToUrl { get { return ToNode; } }
		public override string Label { get { return "RootContainsUrl"; } }

	}

	/*================================================================================================*/
	public class RootContainsUser : WeaverRel<Root, Contains, User> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "RootContainsUser"; } }

	}

	/*================================================================================================*/
	public class RootContainsFactor : WeaverRel<Root, Contains, Factor> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Factor ToFactor { get { return ToNode; } }
		public override string Label { get { return "RootContainsFactor"; } }

	}

	/*================================================================================================*/
	public class RootContainsFactorAssertion : WeaverRel<Root, Contains, FactorAssertion> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual FactorAssertion ToFactorAssertion { get { return ToNode; } }
		public override string Label { get { return "RootContainsFactorAssertion"; } }

	}

	/*================================================================================================*/
	public class RootContainsDescriptor : WeaverRel<Root, Contains, Descriptor> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Descriptor ToDescriptor { get { return ToNode; } }
		public override string Label { get { return "RootContainsDescriptor"; } }

	}

	/*================================================================================================*/
	public class RootContainsDescriptorType : WeaverRel<Root, Contains, DescriptorType> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual DescriptorType ToDescriptorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsDescriptorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsDirector : WeaverRel<Root, Contains, Director> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Director ToDirector { get { return ToNode; } }
		public override string Label { get { return "RootContainsDirector"; } }

	}

	/*================================================================================================*/
	public class RootContainsDirectorType : WeaverRel<Root, Contains, DirectorType> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual DirectorType ToDirectorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsDirectorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsDirectorAction : WeaverRel<Root, Contains, DirectorAction> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual DirectorAction ToDirectorAction { get { return ToNode; } }
		public override string Label { get { return "RootContainsDirectorAction"; } }

	}

	/*================================================================================================*/
	public class RootContainsEventor : WeaverRel<Root, Contains, Eventor> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Eventor ToEventor { get { return ToNode; } }
		public override string Label { get { return "RootContainsEventor"; } }

	}

	/*================================================================================================*/
	public class RootContainsEventorType : WeaverRel<Root, Contains, EventorType> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual EventorType ToEventorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsEventorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsEventorPrecision : WeaverRel<Root, Contains, EventorPrecision> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual EventorPrecision ToEventorPrecision { get { return ToNode; } }
		public override string Label { get { return "RootContainsEventorPrecision"; } }

	}

	/*================================================================================================*/
	public class RootContainsIdentor : WeaverRel<Root, Contains, Identor> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Identor ToIdentor { get { return ToNode; } }
		public override string Label { get { return "RootContainsIdentor"; } }

	}

	/*================================================================================================*/
	public class RootContainsIdentorType : WeaverRel<Root, Contains, IdentorType> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual IdentorType ToIdentorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsIdentorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsLocator : WeaverRel<Root, Contains, Locator> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Locator ToLocator { get { return ToNode; } }
		public override string Label { get { return "RootContainsLocator"; } }

	}

	/*================================================================================================*/
	public class RootContainsLocatorType : WeaverRel<Root, Contains, LocatorType> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual LocatorType ToLocatorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsLocatorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsVector : WeaverRel<Root, Contains, Vector> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Vector ToVector { get { return ToNode; } }
		public override string Label { get { return "RootContainsVector"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorType : WeaverRel<Root, Contains, VectorType> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorType ToVectorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorRange : WeaverRel<Root, Contains, VectorRange> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorRange ToVectorRange { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorRange"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorRangeLevel : WeaverRel<Root, Contains, VectorRangeLevel> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorRangeLevel ToVectorRangeLevel { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorRangeLevel"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorUnit : WeaverRel<Root, Contains, VectorUnit> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorUnit ToVectorUnit { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorUnit"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorUnitPrefix : WeaverRel<Root, Contains, VectorUnitPrefix> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorUnitPrefix ToVectorUnitPrefix { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorUnitPrefix"; } }

	}

	/*================================================================================================*/
	public class RootContainsOauthAccess : WeaverRel<Root, Contains, OauthAccess> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual OauthAccess ToOauthAccess { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthAccess"; } }

	}

	/*================================================================================================*/
	public class RootContainsOauthDomain : WeaverRel<Root, Contains, OauthDomain> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual OauthDomain ToOauthDomain { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthDomain"; } }

	}

	/*================================================================================================*/
	public class RootContainsOauthGrant : WeaverRel<Root, Contains, OauthGrant> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual OauthGrant ToOauthGrant { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthGrant"; } }

	}

	/*================================================================================================*/
	public class RootContainsOauthScope : WeaverRel<Root, Contains, OauthScope> {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual OauthScope ToOauthScope { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthScope"; } }

	}

	/*================================================================================================*/
	public class AppHasArtifact : WeaverRel<App, Has, Artifact> {
			
		public virtual App FromApp { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "AppHasArtifact"; } }

	}

	/*================================================================================================*/
	public class AppUsesEmail : WeaverRel<App, Uses, Email> {
			
		public virtual App FromApp { get { return FromNode; } }
		public virtual Email ToEmail { get { return ToNode; } }
		public override string Label { get { return "AppUsesEmail"; } }

	}

	/*================================================================================================*/
	public class ArtifactUsesArtifactType : WeaverRel<Artifact, Uses, ArtifactType> {
			
		public virtual Artifact FromArtifact { get { return FromNode; } }
		public virtual ArtifactType ToArtifactType { get { return ToNode; } }
		public override string Label { get { return "ArtifactUsesArtifactType"; } }

	}

	/*================================================================================================*/
	public class CrowdHasArtifact : WeaverRel<Crowd, Has, Artifact> {
			
		public virtual Crowd FromCrowd { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "CrowdHasArtifact"; } }

	}

	/*================================================================================================*/
	public class CrowdianUsesCrowd : WeaverRel<Crowdian, Uses, Crowd> {
			
		public virtual Crowdian FromCrowdian { get { return FromNode; } }
		public virtual Crowd ToCrowd { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesCrowd"; } }

	}

	/*================================================================================================*/
	public class CrowdianUsesUser : WeaverRel<Crowdian, Uses, User> {
			
		public virtual Crowdian FromCrowdian { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesUser"; } }

	}

	/*================================================================================================*/
	public class CrowdianHasCrowdianTypeAssign : WeaverRel<Crowdian, Has, CrowdianTypeAssign> {
			
		public virtual Crowdian FromCrowdian { get { return FromNode; } }
		public virtual CrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "CrowdianHasCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public class CrowdianUsesHistoricCrowdianTypeAssign : WeaverRel<Crowdian, UsesHistoric, CrowdianTypeAssign> {
			
		public virtual Crowdian FromCrowdian { get { return FromNode; } }
		public virtual CrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "CrowdianUsesHistoricCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public class CrowdianTypeAssignUsesCrowdianType : WeaverRel<CrowdianTypeAssign, Uses, CrowdianType> {
			
		public virtual CrowdianTypeAssign FromCrowdianTypeAssign { get { return FromNode; } }
		public virtual CrowdianType ToCrowdianType { get { return ToNode; } }
		public override string Label { get { return "CrowdianTypeAssignUsesCrowdianType"; } }

	}

	/*================================================================================================*/
	public class LabelHasArtifact : WeaverRel<Label, Has, Artifact> {
			
		public virtual Label FromLabel { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "LabelHasArtifact"; } }

	}

	/*================================================================================================*/
	public class MemberUsesApp : WeaverRel<Member, Uses, App> {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "MemberUsesApp"; } }

	}

	/*================================================================================================*/
	public class MemberUsesUser : WeaverRel<Member, Uses, User> {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "MemberUsesUser"; } }

	}

	/*================================================================================================*/
	public class MemberHasMemberTypeAssign : WeaverRel<Member, Has, MemberTypeAssign> {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberHasMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public class MemberUsesHistoricMemberTypeAssign : WeaverRel<Member, UsesHistoric, MemberTypeAssign> {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberUsesHistoricMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public class MemberCreatesArtifact : WeaverRel<Member, Creates, Artifact> {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesArtifact"; } }

	}

	/*================================================================================================*/
	public class MemberCreatesMemberTypeAssign : WeaverRel<Member, Creates, MemberTypeAssign> {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public class MemberCreatesFactor : WeaverRel<Member, Creates, Factor> {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual Factor ToFactor { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesFactor"; } }

	}

	/*================================================================================================*/
	public class MemberTypeAssignUsesMemberType : WeaverRel<MemberTypeAssign, Uses, MemberType> {
			
		public virtual MemberTypeAssign FromMemberTypeAssign { get { return FromNode; } }
		public virtual MemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "MemberTypeAssignUsesMemberType"; } }

	}

	/*================================================================================================*/
	public class ThingHasArtifact : WeaverRel<Thing, Has, Artifact> {
			
		public virtual Thing FromThing { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "ThingHasArtifact"; } }

	}

	/*================================================================================================*/
	public class UrlHasArtifact : WeaverRel<Url, Has, Artifact> {
			
		public virtual Url FromUrl { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "UrlHasArtifact"; } }

	}

	/*================================================================================================*/
	public class UserHasArtifact : WeaverRel<User, Has, Artifact> {
			
		public virtual User FromUser { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "UserHasArtifact"; } }

	}

	/*================================================================================================*/
	public class UserUsesEmail : WeaverRel<User, Uses, Email> {
			
		public virtual User FromUser { get { return FromNode; } }
		public virtual Email ToEmail { get { return ToNode; } }
		public override string Label { get { return "UserUsesEmail"; } }

	}

	/*================================================================================================*/
	public class UserCreatesCrowdianTypeAssign : WeaverRel<User, Creates, CrowdianTypeAssign> {
			
		public virtual User FromUser { get { return FromNode; } }
		public virtual CrowdianTypeAssign ToCrowdianTypeAssign { get { return ToNode; } }
		public override string Label { get { return "UserCreatesCrowdianTypeAssign"; } }

	}

	/*================================================================================================*/
	public class FactorUsesPrimaryArtifact : WeaverRel<Factor, UsesPrimary, Artifact> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorUsesPrimaryArtifact"; } }

	}

	/*================================================================================================*/
	public class FactorUsesRelatedArtifact : WeaverRel<Factor, UsesRelated, Artifact> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorUsesRelatedArtifact"; } }

	}

	/*================================================================================================*/
	public class FactorUsesFactorAssertion : WeaverRel<Factor, Uses, FactorAssertion> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual FactorAssertion ToFactorAssertion { get { return ToNode; } }
		public override string Label { get { return "FactorUsesFactorAssertion"; } }

	}

	/*================================================================================================*/
	public class FactorReplacesFactor : WeaverRel<Factor, Replaces, Factor> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Factor ToFactor { get { return ToNode; } }
		public override string Label { get { return "FactorReplacesFactor"; } }

	}

	/*================================================================================================*/
	public class FactorUsesDescriptor : WeaverRel<Factor, Uses, Descriptor> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Descriptor ToDescriptor { get { return ToNode; } }
		public override string Label { get { return "FactorUsesDescriptor"; } }

	}

	/*================================================================================================*/
	public class FactorUsesDirector : WeaverRel<Factor, Uses, Director> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Director ToDirector { get { return ToNode; } }
		public override string Label { get { return "FactorUsesDirector"; } }

	}

	/*================================================================================================*/
	public class FactorUsesEventor : WeaverRel<Factor, Uses, Eventor> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Eventor ToEventor { get { return ToNode; } }
		public override string Label { get { return "FactorUsesEventor"; } }

	}

	/*================================================================================================*/
	public class FactorUsesIdentor : WeaverRel<Factor, Uses, Identor> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Identor ToIdentor { get { return ToNode; } }
		public override string Label { get { return "FactorUsesIdentor"; } }

	}

	/*================================================================================================*/
	public class FactorUsesLocator : WeaverRel<Factor, Uses, Locator> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Locator ToLocator { get { return ToNode; } }
		public override string Label { get { return "FactorUsesLocator"; } }

	}

	/*================================================================================================*/
	public class FactorUsesVector : WeaverRel<Factor, Uses, Vector> {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Vector ToVector { get { return ToNode; } }
		public override string Label { get { return "FactorUsesVector"; } }

	}

	/*================================================================================================*/
	public class DescriptorUsesDescriptorType : WeaverRel<Descriptor, Uses, DescriptorType> {
			
		public virtual Descriptor FromDescriptor { get { return FromNode; } }
		public virtual DescriptorType ToDescriptorType { get { return ToNode; } }
		public override string Label { get { return "DescriptorUsesDescriptorType"; } }

	}

	/*================================================================================================*/
	public class DescriptorrefinesPrimaryWithArtifact : WeaverRel<Descriptor, refinesPrimaryWith, Artifact> {
			
		public virtual Descriptor FromDescriptor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "DescriptorrefinesPrimaryWithArtifact"; } }

	}

	/*================================================================================================*/
	public class DescriptorrefinesRelatedWithArtifact : WeaverRel<Descriptor, refinesRelatedWith, Artifact> {
			
		public virtual Descriptor FromDescriptor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "DescriptorrefinesRelatedWithArtifact"; } }

	}

	/*================================================================================================*/
	public class DescriptorrefinesTypeWithArtifact : WeaverRel<Descriptor, refinesTypeWith, Artifact> {
			
		public virtual Descriptor FromDescriptor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "DescriptorrefinesTypeWithArtifact"; } }

	}

	/*================================================================================================*/
	public class DirectorUsesDirectorType : WeaverRel<Director, Uses, DirectorType> {
			
		public virtual Director FromDirector { get { return FromNode; } }
		public virtual DirectorType ToDirectorType { get { return ToNode; } }
		public override string Label { get { return "DirectorUsesDirectorType"; } }

	}

	/*================================================================================================*/
	public class DirectorUsesPrimaryDirectorAction : WeaverRel<Director, UsesPrimary, DirectorAction> {
			
		public virtual Director FromDirector { get { return FromNode; } }
		public virtual DirectorAction ToDirectorAction { get { return ToNode; } }
		public override string Label { get { return "DirectorUsesPrimaryDirectorAction"; } }

	}

	/*================================================================================================*/
	public class DirectorUsesRelatedDirectorAction : WeaverRel<Director, UsesRelated, DirectorAction> {
			
		public virtual Director FromDirector { get { return FromNode; } }
		public virtual DirectorAction ToDirectorAction { get { return ToNode; } }
		public override string Label { get { return "DirectorUsesRelatedDirectorAction"; } }

	}

	/*================================================================================================*/
	public class EventorUsesEventorType : WeaverRel<Eventor, Uses, EventorType> {
			
		public virtual Eventor FromEventor { get { return FromNode; } }
		public virtual EventorType ToEventorType { get { return ToNode; } }
		public override string Label { get { return "EventorUsesEventorType"; } }

	}

	/*================================================================================================*/
	public class EventorUsesEventorPrecision : WeaverRel<Eventor, Uses, EventorPrecision> {
			
		public virtual Eventor FromEventor { get { return FromNode; } }
		public virtual EventorPrecision ToEventorPrecision { get { return ToNode; } }
		public override string Label { get { return "EventorUsesEventorPrecision"; } }

	}

	/*================================================================================================*/
	public class IdentorUsesIdentorType : WeaverRel<Identor, Uses, IdentorType> {
			
		public virtual Identor FromIdentor { get { return FromNode; } }
		public virtual IdentorType ToIdentorType { get { return ToNode; } }
		public override string Label { get { return "IdentorUsesIdentorType"; } }

	}

	/*================================================================================================*/
	public class LocatorUsesLocatorType : WeaverRel<Locator, Uses, LocatorType> {
			
		public virtual Locator FromLocator { get { return FromNode; } }
		public virtual LocatorType ToLocatorType { get { return ToNode; } }
		public override string Label { get { return "LocatorUsesLocatorType"; } }

	}

	/*================================================================================================*/
	public class VectorUsesAxisArtifact : WeaverRel<Vector, UsesAxis, Artifact> {
			
		public virtual Vector FromVector { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "VectorUsesAxisArtifact"; } }

	}

	/*================================================================================================*/
	public class VectorUsesVectorType : WeaverRel<Vector, Uses, VectorType> {
			
		public virtual Vector FromVector { get { return FromNode; } }
		public virtual VectorType ToVectorType { get { return ToNode; } }
		public override string Label { get { return "VectorUsesVectorType"; } }

	}

	/*================================================================================================*/
	public class VectorUsesVectorUnit : WeaverRel<Vector, Uses, VectorUnit> {
			
		public virtual Vector FromVector { get { return FromNode; } }
		public virtual VectorUnit ToVectorUnit { get { return ToNode; } }
		public override string Label { get { return "VectorUsesVectorUnit"; } }

	}

	/*================================================================================================*/
	public class VectorUsesVectorUnitPrefix : WeaverRel<Vector, Uses, VectorUnitPrefix> {
			
		public virtual Vector FromVector { get { return FromNode; } }
		public virtual VectorUnitPrefix ToVectorUnitPrefix { get { return ToNode; } }
		public override string Label { get { return "VectorUsesVectorUnitPrefix"; } }

	}

	/*================================================================================================*/
	public class VectorTypeUsesVectorRange : WeaverRel<VectorType, Uses, VectorRange> {
			
		public virtual VectorType FromVectorType { get { return FromNode; } }
		public virtual VectorRange ToVectorRange { get { return ToNode; } }
		public override string Label { get { return "VectorTypeUsesVectorRange"; } }

	}

	/*================================================================================================*/
	public class VectorRangeUsesVectorRangeLevel : WeaverRel<VectorRange, Uses, VectorRangeLevel> {
			
		public virtual VectorRange FromVectorRange { get { return FromNode; } }
		public virtual VectorRangeLevel ToVectorRangeLevel { get { return ToNode; } }
		public override string Label { get { return "VectorRangeUsesVectorRangeLevel"; } }

	}

	/*================================================================================================*/
	public class OauthAccessUsesApp : WeaverRel<OauthAccess, Uses, App> {
			
		public virtual OauthAccess FromOauthAccess { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthAccessUsesApp"; } }

	}

	/*================================================================================================*/
	public class OauthAccessUsesUser : WeaverRel<OauthAccess, Uses, User> {
			
		public virtual OauthAccess FromOauthAccess { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "OauthAccessUsesUser"; } }

	}

	/*================================================================================================*/
	public class OauthDomainUsesApp : WeaverRel<OauthDomain, Uses, App> {
			
		public virtual OauthDomain FromOauthDomain { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthDomainUsesApp"; } }

	}

	/*================================================================================================*/
	public class OauthGrantUsesApp : WeaverRel<OauthGrant, Uses, App> {
			
		public virtual OauthGrant FromOauthGrant { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthGrantUsesApp"; } }

	}

	/*================================================================================================*/
	public class OauthGrantUsesUser : WeaverRel<OauthGrant, Uses, User> {
			
		public virtual OauthGrant FromOauthGrant { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "OauthGrantUsesUser"; } }

	}

	/*================================================================================================*/
	public class OauthScopeUsesApp : WeaverRel<OauthScope, Uses, App> {
			
		public virtual OauthScope FromOauthScope { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthScopeUsesApp"; } }

	}

	/*================================================================================================*/
	public class OauthScopeUsesUser : WeaverRel<OauthScope, Uses, User> {
			
		public virtual OauthScope FromOauthScope { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "OauthScopeUsesUser"; } }

	}


	/* Nodes */


	/*================================================================================================*/
	public class NodeForType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsUnique(True)]
		//[PropLenMax(32)]
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Description { get; set; }

	}

	/*================================================================================================*/
	public class NodeForAction : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long PerformedTimestamp { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		public virtual string Note { get; set; }

	}

	/*================================================================================================*/
	public class Root : WeaverNode {
	
		public override bool IsRoot { get { return (Path == null || PathIndex == 0); } }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsApp OutContainsApps {
			get { return NewRel<RootContainsApp>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsArtifact OutContainsArtifacts {
			get { return NewRel<RootContainsArtifact>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsArtifactType OutContainsArtifactTypes {
			get { return NewRel<RootContainsArtifactType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsCrowd OutContainsCrowds {
			get { return NewRel<RootContainsCrowd>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsCrowdian OutContainsCrowdians {
			get { return NewRel<RootContainsCrowdian>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsCrowdianType OutContainsCrowdianTypes {
			get { return NewRel<RootContainsCrowdianType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEmail OutContainsEmails {
			get { return NewRel<RootContainsEmail>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLabel OutContainsLabels {
			get { return NewRel<RootContainsLabel>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMember OutContainsMembers {
			get { return NewRel<RootContainsMember>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMemberType OutContainsMemberTypes {
			get { return NewRel<RootContainsMemberType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsThing OutContainsThings {
			get { return NewRel<RootContainsThing>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsUrl OutContainsUrls {
			get { return NewRel<RootContainsUrl>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsUser OutContainsUsers {
			get { return NewRel<RootContainsUser>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsFactor OutContainsFactors {
			get { return NewRel<RootContainsFactor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsFactorAssertion OutContainsFactorAssertions {
			get { return NewRel<RootContainsFactorAssertion>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDescriptor OutContainsDescriptors {
			get { return NewRel<RootContainsDescriptor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDescriptorType OutContainsDescriptorTypes {
			get { return NewRel<RootContainsDescriptorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirector OutContainsDirectors {
			get { return NewRel<RootContainsDirector>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirectorType OutContainsDirectorTypes {
			get { return NewRel<RootContainsDirectorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirectorAction OutContainsDirectorActions {
			get { return NewRel<RootContainsDirectorAction>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventor OutContainsEventors {
			get { return NewRel<RootContainsEventor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventorType OutContainsEventorTypes {
			get { return NewRel<RootContainsEventorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventorPrecision OutContainsEventorPrecisions {
			get { return NewRel<RootContainsEventorPrecision>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsIdentor OutContainsIdentors {
			get { return NewRel<RootContainsIdentor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsIdentorType OutContainsIdentorTypes {
			get { return NewRel<RootContainsIdentorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLocator OutContainsLocators {
			get { return NewRel<RootContainsLocator>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLocatorType OutContainsLocatorTypes {
			get { return NewRel<RootContainsLocatorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVector OutContainsVectors {
			get { return NewRel<RootContainsVector>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorType OutContainsVectorTypes {
			get { return NewRel<RootContainsVectorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorRange OutContainsVectorRanges {
			get { return NewRel<RootContainsVectorRange>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorRangeLevel OutContainsVectorRangeLevels {
			get { return NewRel<RootContainsVectorRangeLevel>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnit OutContainsVectorUnits {
			get { return NewRel<RootContainsVectorUnit>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnitPrefix OutContainsVectorUnitPrefixs {
			get { return NewRel<RootContainsVectorUnitPrefix>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthAccess OutContainsOauthAccesss {
			get { return NewRel<RootContainsOauthAccess>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthDomain OutContainsOauthDomains {
			get { return NewRel<RootContainsOauthDomain>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthGrant OutContainsOauthGrants {
			get { return NewRel<RootContainsOauthGrant>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthScope OutContainsOauthScopes {
			get { return NewRel<RootContainsOauthScope>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class App : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long AppId { get; set; }

		[WeaverItemProperty]
		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(64)]
		//[PropLenMin(3)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropLen(32)]
		public virtual string Secret { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsApp InRootContains {
			get { return NewRel<RootContainsApp>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppHasArtifact OutHasArtifact {
			get { return NewRel<AppHasArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppUsesEmail OutUsesEmail {
			get { return NewRel<AppUsesEmail>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberUsesApp InMembersUses {
			get { return NewRel<MemberUsesApp>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesApp InOauthAccesssUses {
			get { return NewRel<OauthAccessUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthDomainUsesApp InOauthDomainsUses {
			get { return NewRel<OauthDomainUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesApp InOauthGrantsUses {
			get { return NewRel<OauthGrantUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesApp InOauthScopesUses {
			get { return NewRel<OauthScopeUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Artifact : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long ArtifactId { get; set; }

		[WeaverItemProperty]
		public virtual bool IsPrivate { get; set; }

		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long CreatedTimestamp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsArtifact InRootContains {
			get { return NewRel<RootContainsArtifact>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppHasArtifact InAppHas {
			get { return NewRel<AppHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ArtifactUsesArtifactType OutUsesArtifactType {
			get { return NewRel<ArtifactUsesArtifactType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdHasArtifact InCrowdHas {
			get { return NewRel<CrowdHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual LabelHasArtifact InLabelHas {
			get { return NewRel<LabelHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesArtifact InMemberCreates {
			get { return NewRel<MemberCreatesArtifact>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ThingHasArtifact InThingHas {
			get { return NewRel<ThingHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UrlHasArtifact InUrlHas {
			get { return NewRel<UrlHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserHasArtifact InUserHas {
			get { return NewRel<UserHasArtifact>(WeaverRelConn.InFromZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesPrimaryArtifact InFactorsUsesPrimary {
			get { return NewRel<FactorUsesPrimaryArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesRelatedArtifact InFactorsUsesRelated {
			get { return NewRel<FactorUsesRelatedArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorrefinesPrimaryWithArtifact InDescriptorsrefinesPrimaryWith {
			get { return NewRel<DescriptorrefinesPrimaryWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorrefinesRelatedWithArtifact InDescriptorsrefinesRelatedWith {
			get { return NewRel<DescriptorrefinesRelatedWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorrefinesTypeWithArtifact InDescriptorsrefinesTypeWith {
			get { return NewRel<DescriptorrefinesTypeWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesAxisArtifact InVectorsUsesAxis {
			get { return NewRel<VectorUsesAxisArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class ArtifactType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte ArtifactTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsArtifactType InRootContains {
			get { return NewRel<RootContainsArtifactType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ArtifactUsesArtifactType InArtifactsUses {
			get { return NewRel<ArtifactUsesArtifactType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Crowd : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long CrowdId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(64)]
		//[PropLenMin(3)]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		public virtual string Description { get; set; }

		[WeaverItemProperty]
		public virtual bool IsPrivate { get; set; }

		[WeaverItemProperty]
		public virtual bool IsInviteOnly { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsCrowd InRootContains {
			get { return NewRel<RootContainsCrowd>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdHasArtifact OutHasArtifact {
			get { return NewRel<CrowdHasArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianUsesCrowd InCrowdiansUses {
			get { return NewRel<CrowdianUsesCrowd>(WeaverRelConn.InFromOneOrMore); }
		}

	}

	/*================================================================================================*/
	public class Crowdian : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long CrowdianId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsCrowdian InRootContains {
			get { return NewRel<RootContainsCrowdian>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianUsesCrowd OutUsesCrowd {
			get { return NewRel<CrowdianUsesCrowd>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianUsesUser OutUsesUser {
			get { return NewRel<CrowdianUsesUser>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianHasCrowdianTypeAssign OutHasCrowdianTypeAssign {
			get { return NewRel<CrowdianHasCrowdianTypeAssign>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianUsesHistoricCrowdianTypeAssign OutUsesHistoricCrowdianTypeAssigns {
			get { return NewRel<CrowdianUsesHistoricCrowdianTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class CrowdianType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte CrowdianTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsCrowdianType InRootContains {
			get { return NewRel<RootContainsCrowdianType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianTypeAssignUsesCrowdianType InCrowdianTypeAssignsUses {
			get { return NewRel<CrowdianTypeAssignUsesCrowdianType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class CrowdianTypeAssign : WeaverNode {
	
		[WeaverItemProperty]
		public virtual float Weight { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianHasCrowdianTypeAssign InCrowdianHas {
			get { return NewRel<CrowdianHasCrowdianTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianUsesHistoricCrowdianTypeAssign InCrowdianUsesHistoric {
			get { return NewRel<CrowdianUsesHistoricCrowdianTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianTypeAssignUsesCrowdianType OutUsesCrowdianType {
			get { return NewRel<CrowdianTypeAssignUsesCrowdianType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserCreatesCrowdianTypeAssign InUserCreates {
			get { return NewRel<UserCreatesCrowdianTypeAssign>(WeaverRelConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public class Email : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long EmailId { get; set; }

		[WeaverItemProperty]
		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(256)]
		//[PropValidRegex(@"^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$")]
		public virtual string Address { get; set; }

		[WeaverItemProperty]
		//[PropLen(32)]
		public virtual string Code { get; set; }

		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long CreatedTimestamp { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		public virtual long VerifiedTimestamp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEmail InRootContains {
			get { return NewRel<RootContainsEmail>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppUsesEmail InAppUses {
			get { return NewRel<AppUsesEmail>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserUsesEmail InUserUses {
			get { return NewRel<UserUsesEmail>(WeaverRelConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public class Label : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long LabelId { get; set; }

		[WeaverItemProperty]
		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(128)]
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLabel InRootContains {
			get { return NewRel<RootContainsLabel>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual LabelHasArtifact OutHasArtifact {
			get { return NewRel<LabelHasArtifact>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class Member : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long MemberId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMember InRootContains {
			get { return NewRel<RootContainsMember>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberUsesApp OutUsesApp {
			get { return NewRel<MemberUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberUsesUser OutUsesUser {
			get { return NewRel<MemberUsesUser>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasMemberTypeAssign OutHasMemberTypeAssign {
			get { return NewRel<MemberHasMemberTypeAssign>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberUsesHistoricMemberTypeAssign OutUsesHistoricMemberTypeAssigns {
			get { return NewRel<MemberUsesHistoricMemberTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesArtifact OutCreatesArtifacts {
			get { return NewRel<MemberCreatesArtifact>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesMemberTypeAssign OutCreatesMemberTypeAssigns {
			get { return NewRel<MemberCreatesMemberTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesFactor OutCreatesFactors {
			get { return NewRel<MemberCreatesFactor>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class MemberType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte MemberTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMemberType InRootContains {
			get { return NewRel<RootContainsMemberType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberTypeAssignUsesMemberType InMemberTypeAssignsUses {
			get { return NewRel<MemberTypeAssignUsesMemberType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class MemberTypeAssign : WeaverNode {
	
		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasMemberTypeAssign InMemberHas {
			get { return NewRel<MemberHasMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberUsesHistoricMemberTypeAssign InMemberUsesHistoric {
			get { return NewRel<MemberUsesHistoricMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesMemberTypeAssign InMemberCreates {
			get { return NewRel<MemberCreatesMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberTypeAssignUsesMemberType OutUsesMemberType {
			get { return NewRel<MemberTypeAssignUsesMemberType>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class Thing : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long ThingId { get; set; }

		[WeaverItemProperty]
		public virtual bool IsClass { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(128)]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(128)]
		public virtual string Disamb { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		public virtual string Note { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsThing InRootContains {
			get { return NewRel<RootContainsThing>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ThingHasArtifact OutHasArtifact {
			get { return NewRel<ThingHasArtifact>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class Url : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long UrlId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(128)]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(2048)]
		public virtual string AbsoluteUrl { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsUrl InRootContains {
			get { return NewRel<RootContainsUrl>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UrlHasArtifact OutHasArtifact {
			get { return NewRel<UrlHasArtifact>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class User : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long UserId { get; set; }

		[WeaverItemProperty]
		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(16)]
		//[PropValidRegex(@"^[a-zA-Z0-9_]*$")]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropLen(32)]
		public virtual string Password { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsUser InRootContains {
			get { return NewRel<RootContainsUser>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual CrowdianUsesUser InCrowdiansUses {
			get { return NewRel<CrowdianUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberUsesUser InMembersUses {
			get { return NewRel<MemberUsesUser>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserHasArtifact OutHasArtifact {
			get { return NewRel<UserHasArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserUsesEmail OutUsesEmail {
			get { return NewRel<UserUsesEmail>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserCreatesCrowdianTypeAssign OutCreatesCrowdianTypeAssigns {
			get { return NewRel<UserCreatesCrowdianTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesUser InOauthAccesssUses {
			get { return NewRel<OauthAccessUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesUser InOauthGrantsUses {
			get { return NewRel<OauthGrantUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesUser InOauthScopesUses {
			get { return NewRel<OauthScopeUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Factor : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long FactorId { get; set; }

		[WeaverItemProperty]
		public virtual bool IsPublic { get; set; }

		[WeaverItemProperty]
		public virtual bool IsDefining { get; set; }

		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long CreatedTimestamp { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		public virtual long DeletedTimestamp { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		public virtual long CompletedTimestamp { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		public virtual string Note { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsFactor InRootContains {
			get { return NewRel<RootContainsFactor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesFactor InMemberCreates {
			get { return NewRel<MemberCreatesFactor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesPrimaryArtifact OutUsesPrimaryArtifact {
			get { return NewRel<FactorUsesPrimaryArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesRelatedArtifact OutUsesRelatedArtifact {
			get { return NewRel<FactorUsesRelatedArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesFactorAssertion OutUsesFactorAssertion {
			get { return NewRel<FactorUsesFactorAssertion>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorReplacesFactor OutReplacesFactor {
			get { return NewRel<FactorReplacesFactor>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDescriptor OutUsesDescriptor {
			get { return NewRel<FactorUsesDescriptor>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDirector OutUsesDirector {
			get { return NewRel<FactorUsesDirector>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesEventor OutUsesEventor {
			get { return NewRel<FactorUsesEventor>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesIdentor OutUsesIdentor {
			get { return NewRel<FactorUsesIdentor>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesLocator OutUsesLocator {
			get { return NewRel<FactorUsesLocator>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesVector OutUsesVector {
			get { return NewRel<FactorUsesVector>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public class FactorAssertion : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte FactorAssertionId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsFactorAssertion InRootContains {
			get { return NewRel<RootContainsFactorAssertion>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesFactorAssertion InFactorsUses {
			get { return NewRel<FactorUsesFactorAssertion>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class FactorElementNode : WeaverNode {
	
	}

	/*================================================================================================*/
	public class Descriptor : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DescriptorId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDescriptor InRootContains {
			get { return NewRel<RootContainsDescriptor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDescriptor InFactorsUses {
			get { return NewRel<FactorUsesDescriptor>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorUsesDescriptorType OutUsesDescriptorType {
			get { return NewRel<DescriptorUsesDescriptorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorrefinesPrimaryWithArtifact OutrefinesPrimaryWithArtifact {
			get { return NewRel<DescriptorrefinesPrimaryWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorrefinesRelatedWithArtifact OutrefinesRelatedWithArtifact {
			get { return NewRel<DescriptorrefinesRelatedWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorrefinesTypeWithArtifact OutrefinesTypeWithArtifact {
			get { return NewRel<DescriptorrefinesTypeWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public class DescriptorType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte DescriptorTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDescriptorType InRootContains {
			get { return NewRel<RootContainsDescriptorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorUsesDescriptorType InDescriptorsUses {
			get { return NewRel<DescriptorUsesDescriptorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Director : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DirectorId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirector InRootContains {
			get { return NewRel<RootContainsDirector>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDirector InFactorsUses {
			get { return NewRel<FactorUsesDirector>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesDirectorType OutUsesDirectorType {
			get { return NewRel<DirectorUsesDirectorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesPrimaryDirectorAction OutUsesPrimaryDirectorAction {
			get { return NewRel<DirectorUsesPrimaryDirectorAction>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesRelatedDirectorAction OutUsesRelatedDirectorAction {
			get { return NewRel<DirectorUsesRelatedDirectorAction>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class DirectorType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte DirectorTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirectorType InRootContains {
			get { return NewRel<RootContainsDirectorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesDirectorType InDirectorsUses {
			get { return NewRel<DirectorUsesDirectorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class DirectorAction : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte DirectorActionId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirectorAction InRootContains {
			get { return NewRel<RootContainsDirectorAction>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesPrimaryDirectorAction InDirectorsUsesPrimary {
			get { return NewRel<DirectorUsesPrimaryDirectorAction>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesRelatedDirectorAction InDirectorsUsesRelated {
			get { return NewRel<DirectorUsesRelatedDirectorAction>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Eventor : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long EventorId { get; set; }

		[WeaverItemProperty]
		public virtual long DateTimeTimestamp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventor InRootContains {
			get { return NewRel<RootContainsEventor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesEventor InFactorsUses {
			get { return NewRel<FactorUsesEventor>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual EventorUsesEventorType OutUsesEventorType {
			get { return NewRel<EventorUsesEventorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual EventorUsesEventorPrecision OutUsesEventorPrecision {
			get { return NewRel<EventorUsesEventorPrecision>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class EventorType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte EventorTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventorType InRootContains {
			get { return NewRel<RootContainsEventorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual EventorUsesEventorType InEventorsUses {
			get { return NewRel<EventorUsesEventorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class EventorPrecision : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte EventorPrecisionId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventorPrecision InRootContains {
			get { return NewRel<RootContainsEventorPrecision>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual EventorUsesEventorPrecision InEventorsUses {
			get { return NewRel<EventorUsesEventorPrecision>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Identor : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long IdentorId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(128)]
		public virtual string Value { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsIdentor InRootContains {
			get { return NewRel<RootContainsIdentor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesIdentor InFactorsUses {
			get { return NewRel<FactorUsesIdentor>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IdentorUsesIdentorType OutUsesIdentorType {
			get { return NewRel<IdentorUsesIdentorType>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class IdentorType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte IdentorTypeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsIdentorType InRootContains {
			get { return NewRel<RootContainsIdentorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IdentorUsesIdentorType InIdentorsUses {
			get { return NewRel<IdentorUsesIdentorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Locator : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long LocatorId { get; set; }

		[WeaverItemProperty]
		public virtual double ValueX { get; set; }

		[WeaverItemProperty]
		public virtual double ValueY { get; set; }

		[WeaverItemProperty]
		public virtual double ValueZ { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLocator InRootContains {
			get { return NewRel<RootContainsLocator>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesLocator InFactorsUses {
			get { return NewRel<FactorUsesLocator>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual LocatorUsesLocatorType OutUsesLocatorType {
			get { return NewRel<LocatorUsesLocatorType>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class LocatorType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte LocatorTypeId { get; set; }

		[WeaverItemProperty]
		public virtual double MinX { get; set; }

		[WeaverItemProperty]
		public virtual double MaxX { get; set; }

		[WeaverItemProperty]
		public virtual double MinY { get; set; }

		[WeaverItemProperty]
		public virtual double MaxY { get; set; }

		[WeaverItemProperty]
		public virtual double MinZ { get; set; }

		[WeaverItemProperty]
		public virtual double MaxZ { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLocatorType InRootContains {
			get { return NewRel<RootContainsLocatorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual LocatorUsesLocatorType InLocatorsUses {
			get { return NewRel<LocatorUsesLocatorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Vector : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorId { get; set; }

		[WeaverItemProperty]
		public virtual long Value { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVector InRootContains {
			get { return NewRel<RootContainsVector>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesVector InFactorsUses {
			get { return NewRel<FactorUsesVector>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesAxisArtifact OutUsesAxisArtifact {
			get { return NewRel<VectorUsesAxisArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorType OutUsesVectorType {
			get { return NewRel<VectorUsesVectorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorUnit OutUsesVectorUnit {
			get { return NewRel<VectorUsesVectorUnit>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorUnitPrefix OutUsesVectorUnitPrefix {
			get { return NewRel<VectorUsesVectorUnitPrefix>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class VectorType : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorTypeId { get; set; }

		[WeaverItemProperty]
		public virtual long Min { get; set; }

		[WeaverItemProperty]
		public virtual long Max { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorType InRootContains {
			get { return NewRel<RootContainsVectorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorType InVectorsUses {
			get { return NewRel<VectorUsesVectorType>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorTypeUsesVectorRange OutUsesVectorRange {
			get { return NewRel<VectorTypeUsesVectorRange>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class VectorRange : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorRangeId { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorRange InRootContains {
			get { return NewRel<RootContainsVectorRange>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorTypeUsesVectorRange InVectorTypesUses {
			get { return NewRel<VectorTypeUsesVectorRange>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorRangeUsesVectorRangeLevel OutUsesVectorRangeLevels {
			get { return NewRel<VectorRangeUsesVectorRangeLevel>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class VectorRangeLevel : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorRangeLevelId { get; set; }

		[WeaverItemProperty]
		public virtual float Position { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorRangeLevel InRootContains {
			get { return NewRel<RootContainsVectorRangeLevel>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorRangeUsesVectorRangeLevel InVectorRangesUses {
			get { return NewRel<VectorRangeUsesVectorRangeLevel>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class VectorUnit : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorUnitId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(8)]
		public virtual string Symbol { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnit InRootContains {
			get { return NewRel<RootContainsVectorUnit>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorUnit InVectorsUses {
			get { return NewRel<VectorUsesVectorUnit>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class VectorUnitPrefix : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorUnitPrefixId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(8)]
		public virtual string Symbol { get; set; }

		[WeaverItemProperty]
		public virtual double Amount { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnitPrefix InRootContains {
			get { return NewRel<RootContainsVectorUnitPrefix>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorUnitPrefix InVectorsUses {
			get { return NewRel<VectorUsesVectorUnitPrefix>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class OauthAccess : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthAccessId { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropIsUnique(True)]
		//[PropLen(32)]
		public virtual string Token { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLen(32)]
		public virtual string Refresh { get; set; }

		[WeaverItemProperty]
		public virtual long ExpiresTimestamp { get; set; }

		[WeaverItemProperty]
		public virtual bool IsClientOnly { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthAccess InRootContains {
			get { return NewRel<RootContainsOauthAccess>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesApp OutUsesApp {
			get { return NewRel<OauthAccessUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesUser OutUsesUser {
			get { return NewRel<OauthAccessUsesUser>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public class OauthDomain : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthDomainId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		public virtual string Domain { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthDomain InRootContains {
			get { return NewRel<RootContainsOauthDomain>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthDomainUsesApp OutUsesApp {
			get { return NewRel<OauthDomainUsesApp>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class OauthGrant : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthGrantId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(450)]
		public virtual string RedirectUri { get; set; }

		[WeaverItemProperty]
		//[PropIsUnique(True)]
		//[PropLen(32)]
		public virtual string Code { get; set; }

		[WeaverItemProperty]
		public virtual long ExpiresTimestamp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthGrant InRootContains {
			get { return NewRel<RootContainsOauthGrant>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesApp OutUsesApp {
			get { return NewRel<OauthGrantUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesUser OutUsesUser {
			get { return NewRel<OauthGrantUsesUser>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class OauthScope : WeaverNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthScopeId { get; set; }

		[WeaverItemProperty]
		public virtual bool Allow { get; set; }

		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long CreatedTimestamp { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthScope InRootContains {
			get { return NewRel<RootContainsOauthScope>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesApp OutUsesApp {
			get { return NewRel<OauthScopeUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesUser OutUsesUser {
			get { return NewRel<OauthScopeUsesUser>(WeaverRelConn.OutToOne); }
		}

	}

}
