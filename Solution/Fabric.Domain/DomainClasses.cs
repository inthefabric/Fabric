﻿// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/2/2013 1:27:05 PM

using System;
using System.Linq.Expressions;
using Weaver.Items;
using Weaver.Interfaces;

namespace Fabric.Domain {


	/* Relationship Types */
	
	
	/*================================================================================================*/
	public class Contains : IWeaverRelType {
	
		public string Label { get { return "Contains"; } }

	}

	/*================================================================================================*/
	public class Uses : IWeaverRelType {
	
		public string Label { get { return "Uses"; } }

	}

	/*================================================================================================*/
	public class Defines : IWeaverRelType {
	
		public string Label { get { return "Defines"; } }

	}

	/*================================================================================================*/
	public class Has : IWeaverRelType {
	
		public string Label { get { return "Has"; } }

	}

	/*================================================================================================*/
	public class HasHistoric : IWeaverRelType {
	
		public string Label { get { return "HasHistoric"; } }

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
	public class RefinesPrimaryWith : IWeaverRelType {
	
		public string Label { get { return "RefinesPrimaryWith"; } }

	}

	/*================================================================================================*/
	public class RefinesRelatedWith : IWeaverRelType {
	
		public string Label { get { return "RefinesRelatedWith"; } }

	}

	/*================================================================================================*/
	public class RefinesTypeWith : IWeaverRelType {
	
		public string Label { get { return "RefinesTypeWith"; } }

	}

	/*================================================================================================*/
	public class UsesAxis : IWeaverRelType {
	
		public string Label { get { return "UsesAxis"; } }

	}

	/*================================================================================================*/
	public class RaisesToExp : IWeaverRelType {
	
		public string Label { get { return "RaisesToExp"; } }

	}


	/* Relationships */


	/*================================================================================================*/
	public class RootContainsApp : Rel<Root, Contains, App>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "RootContainsApp"; } }

	}

	/*================================================================================================*/
	public class RootContainsClass : Rel<Root, Contains, Class>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Class ToClass { get { return ToNode; } }
		public override string Label { get { return "RootContainsClass"; } }

	}

	/*================================================================================================*/
	public class RootContainsEmail : Rel<Root, Contains, Email>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Email ToEmail { get { return ToNode; } }
		public override string Label { get { return "RootContainsEmail"; } }

	}

	/*================================================================================================*/
	public class RootContainsInstance : Rel<Root, Contains, Instance>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Instance ToInstance { get { return ToNode; } }
		public override string Label { get { return "RootContainsInstance"; } }

	}

	/*================================================================================================*/
	public class RootContainsMember : Rel<Root, Contains, Member>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Member ToMember { get { return ToNode; } }
		public override string Label { get { return "RootContainsMember"; } }

	}

	/*================================================================================================*/
	public class RootContainsMemberType : Rel<Root, Contains, MemberType>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual MemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "RootContainsMemberType"; } }

	}

	/*================================================================================================*/
	public class RootContainsMemberTypeAssign : Rel<Root, Contains, MemberTypeAssign>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "RootContainsMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public class RootContainsUrl : Rel<Root, Contains, Url>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Url ToUrl { get { return ToNode; } }
		public override string Label { get { return "RootContainsUrl"; } }

	}

	/*================================================================================================*/
	public class RootContainsUser : Rel<Root, Contains, User>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "RootContainsUser"; } }

	}

	/*================================================================================================*/
	public class RootContainsFactor : Rel<Root, Contains, Factor>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Factor ToFactor { get { return ToNode; } }
		public override string Label { get { return "RootContainsFactor"; } }

	}

	/*================================================================================================*/
	public class RootContainsFactorAssertion : Rel<Root, Contains, FactorAssertion>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual FactorAssertion ToFactorAssertion { get { return ToNode; } }
		public override string Label { get { return "RootContainsFactorAssertion"; } }

	}

	/*================================================================================================*/
	public class RootContainsDescriptor : Rel<Root, Contains, Descriptor>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Descriptor ToDescriptor { get { return ToNode; } }
		public override string Label { get { return "RootContainsDescriptor"; } }

	}

	/*================================================================================================*/
	public class RootContainsDescriptorType : Rel<Root, Contains, DescriptorType>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual DescriptorType ToDescriptorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsDescriptorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsDirector : Rel<Root, Contains, Director>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Director ToDirector { get { return ToNode; } }
		public override string Label { get { return "RootContainsDirector"; } }

	}

	/*================================================================================================*/
	public class RootContainsDirectorType : Rel<Root, Contains, DirectorType>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual DirectorType ToDirectorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsDirectorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsDirectorAction : Rel<Root, Contains, DirectorAction>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual DirectorAction ToDirectorAction { get { return ToNode; } }
		public override string Label { get { return "RootContainsDirectorAction"; } }

	}

	/*================================================================================================*/
	public class RootContainsEventor : Rel<Root, Contains, Eventor>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Eventor ToEventor { get { return ToNode; } }
		public override string Label { get { return "RootContainsEventor"; } }

	}

	/*================================================================================================*/
	public class RootContainsEventorType : Rel<Root, Contains, EventorType>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual EventorType ToEventorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsEventorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsEventorPrecision : Rel<Root, Contains, EventorPrecision>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual EventorPrecision ToEventorPrecision { get { return ToNode; } }
		public override string Label { get { return "RootContainsEventorPrecision"; } }

	}

	/*================================================================================================*/
	public class RootContainsIdentor : Rel<Root, Contains, Identor>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Identor ToIdentor { get { return ToNode; } }
		public override string Label { get { return "RootContainsIdentor"; } }

	}

	/*================================================================================================*/
	public class RootContainsIdentorType : Rel<Root, Contains, IdentorType>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual IdentorType ToIdentorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsIdentorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsLocator : Rel<Root, Contains, Locator>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Locator ToLocator { get { return ToNode; } }
		public override string Label { get { return "RootContainsLocator"; } }

	}

	/*================================================================================================*/
	public class RootContainsLocatorType : Rel<Root, Contains, LocatorType>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual LocatorType ToLocatorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsLocatorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsVector : Rel<Root, Contains, Vector>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual Vector ToVector { get { return ToNode; } }
		public override string Label { get { return "RootContainsVector"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorType : Rel<Root, Contains, VectorType>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorType ToVectorType { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorType"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorRange : Rel<Root, Contains, VectorRange>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorRange ToVectorRange { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorRange"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorRangeLevel : Rel<Root, Contains, VectorRangeLevel>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorRangeLevel ToVectorRangeLevel { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorRangeLevel"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorUnit : Rel<Root, Contains, VectorUnit>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorUnit ToVectorUnit { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorUnit"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorUnitPrefix : Rel<Root, Contains, VectorUnitPrefix>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorUnitPrefix ToVectorUnitPrefix { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorUnitPrefix"; } }

	}

	/*================================================================================================*/
	public class RootContainsVectorUnitDerived : Rel<Root, Contains, VectorUnitDerived>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual VectorUnitDerived ToVectorUnitDerived { get { return ToNode; } }
		public override string Label { get { return "RootContainsVectorUnitDerived"; } }

	}

	/*================================================================================================*/
	public class RootContainsOauthAccess : Rel<Root, Contains, OauthAccess>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual OauthAccess ToOauthAccess { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthAccess"; } }

	}

	/*================================================================================================*/
	public class RootContainsOauthDomain : Rel<Root, Contains, OauthDomain>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual OauthDomain ToOauthDomain { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthDomain"; } }

	}

	/*================================================================================================*/
	public class RootContainsOauthGrant : Rel<Root, Contains, OauthGrant>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual OauthGrant ToOauthGrant { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthGrant"; } }

	}

	/*================================================================================================*/
	public class RootContainsOauthScope : Rel<Root, Contains, OauthScope>, IItemWithId {
			
		public virtual Root FromRoot { get { return FromNode; } }
		public virtual OauthScope ToOauthScope { get { return ToNode; } }
		public override string Label { get { return "RootContainsOauthScope"; } }

	}

	/*================================================================================================*/
	public class AppUsesEmail : Rel<App, Uses, Email>, IItemWithId {
			
		public virtual App FromApp { get { return FromNode; } }
		public virtual Email ToEmail { get { return ToNode; } }
		public override string Label { get { return "AppUsesEmail"; } }

	}

	/*================================================================================================*/
	public class AppDefinesMember : Rel<App, Defines, Member>, IItemWithId {
			
		public virtual App FromApp { get { return FromNode; } }
		public virtual Member ToMember { get { return ToNode; } }
		public override string Label { get { return "AppDefinesMember"; } }

	}

	/*================================================================================================*/
	public class MemberHasMemberTypeAssign : Rel<Member, Has, MemberTypeAssign>, IItemWithId {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberHasMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public class MemberHasHistoricMemberTypeAssign : Rel<Member, HasHistoric, MemberTypeAssign>, IItemWithId {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberHasHistoricMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public class MemberCreatesArtifact : Rel<Member, Creates, Artifact>, IItemWithId {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesArtifact"; } }

	}

	/*================================================================================================*/
	public class MemberCreatesMemberTypeAssign : Rel<Member, Creates, MemberTypeAssign>, IItemWithId {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesMemberTypeAssign"; } }

	}

	/*================================================================================================*/
	public class MemberCreatesFactor : Rel<Member, Creates, Factor>, IItemWithId {
			
		public virtual Member FromMember { get { return FromNode; } }
		public virtual Factor ToFactor { get { return ToNode; } }
		public override string Label { get { return "MemberCreatesFactor"; } }

	}

	/*================================================================================================*/
	public class MemberTypeAssignUsesMemberType : Rel<MemberTypeAssign, Uses, MemberType>, IItemWithId {
			
		public virtual MemberTypeAssign FromMemberTypeAssign { get { return FromNode; } }
		public virtual MemberType ToMemberType { get { return ToNode; } }
		public override string Label { get { return "MemberTypeAssignUsesMemberType"; } }

	}

	/*================================================================================================*/
	public class UserUsesEmail : Rel<User, Uses, Email>, IItemWithId {
			
		public virtual User FromUser { get { return FromNode; } }
		public virtual Email ToEmail { get { return ToNode; } }
		public override string Label { get { return "UserUsesEmail"; } }

	}

	/*================================================================================================*/
	public class UserDefinesMember : Rel<User, Defines, Member>, IItemWithId {
			
		public virtual User FromUser { get { return FromNode; } }
		public virtual Member ToMember { get { return ToNode; } }
		public override string Label { get { return "UserDefinesMember"; } }

	}

	/*================================================================================================*/
	public class FactorUsesPrimaryArtifact : Rel<Factor, UsesPrimary, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorUsesPrimaryArtifact"; } }

	}

	/*================================================================================================*/
	public class FactorUsesRelatedArtifact : Rel<Factor, UsesRelated, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorUsesRelatedArtifact"; } }

	}

	/*================================================================================================*/
	public class FactorUsesFactorAssertion : Rel<Factor, Uses, FactorAssertion>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual FactorAssertion ToFactorAssertion { get { return ToNode; } }
		public override string Label { get { return "FactorUsesFactorAssertion"; } }

	}

	/*================================================================================================*/
	public class FactorReplacesFactor : Rel<Factor, Replaces, Factor>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Factor ToFactor { get { return ToNode; } }
		public override string Label { get { return "FactorReplacesFactor"; } }

	}

	/*================================================================================================*/
	public class FactorUsesDescriptor : Rel<Factor, Uses, Descriptor>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Descriptor ToDescriptor { get { return ToNode; } }
		public override string Label { get { return "FactorUsesDescriptor"; } }

	}

	/*================================================================================================*/
	public class FactorUsesDirector : Rel<Factor, Uses, Director>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Director ToDirector { get { return ToNode; } }
		public override string Label { get { return "FactorUsesDirector"; } }

	}

	/*================================================================================================*/
	public class FactorUsesEventor : Rel<Factor, Uses, Eventor>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Eventor ToEventor { get { return ToNode; } }
		public override string Label { get { return "FactorUsesEventor"; } }

	}

	/*================================================================================================*/
	public class FactorUsesIdentor : Rel<Factor, Uses, Identor>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Identor ToIdentor { get { return ToNode; } }
		public override string Label { get { return "FactorUsesIdentor"; } }

	}

	/*================================================================================================*/
	public class FactorUsesLocator : Rel<Factor, Uses, Locator>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Locator ToLocator { get { return ToNode; } }
		public override string Label { get { return "FactorUsesLocator"; } }

	}

	/*================================================================================================*/
	public class FactorUsesVector : Rel<Factor, Uses, Vector>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Vector ToVector { get { return ToNode; } }
		public override string Label { get { return "FactorUsesVector"; } }

	}

	/*================================================================================================*/
	public class DescriptorUsesDescriptorType : Rel<Descriptor, Uses, DescriptorType>, IItemWithId {
			
		public virtual Descriptor FromDescriptor { get { return FromNode; } }
		public virtual DescriptorType ToDescriptorType { get { return ToNode; } }
		public override string Label { get { return "DescriptorUsesDescriptorType"; } }

	}

	/*================================================================================================*/
	public class DescriptorRefinesPrimaryWithArtifact : Rel<Descriptor, RefinesPrimaryWith, Artifact>, IItemWithId {
			
		public virtual Descriptor FromDescriptor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "DescriptorRefinesPrimaryWithArtifact"; } }

	}

	/*================================================================================================*/
	public class DescriptorRefinesRelatedWithArtifact : Rel<Descriptor, RefinesRelatedWith, Artifact>, IItemWithId {
			
		public virtual Descriptor FromDescriptor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "DescriptorRefinesRelatedWithArtifact"; } }

	}

	/*================================================================================================*/
	public class DescriptorRefinesTypeWithArtifact : Rel<Descriptor, RefinesTypeWith, Artifact>, IItemWithId {
			
		public virtual Descriptor FromDescriptor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "DescriptorRefinesTypeWithArtifact"; } }

	}

	/*================================================================================================*/
	public class DirectorUsesDirectorType : Rel<Director, Uses, DirectorType>, IItemWithId {
			
		public virtual Director FromDirector { get { return FromNode; } }
		public virtual DirectorType ToDirectorType { get { return ToNode; } }
		public override string Label { get { return "DirectorUsesDirectorType"; } }

	}

	/*================================================================================================*/
	public class DirectorUsesPrimaryDirectorAction : Rel<Director, UsesPrimary, DirectorAction>, IItemWithId {
			
		public virtual Director FromDirector { get { return FromNode; } }
		public virtual DirectorAction ToDirectorAction { get { return ToNode; } }
		public override string Label { get { return "DirectorUsesPrimaryDirectorAction"; } }

	}

	/*================================================================================================*/
	public class DirectorUsesRelatedDirectorAction : Rel<Director, UsesRelated, DirectorAction>, IItemWithId {
			
		public virtual Director FromDirector { get { return FromNode; } }
		public virtual DirectorAction ToDirectorAction { get { return ToNode; } }
		public override string Label { get { return "DirectorUsesRelatedDirectorAction"; } }

	}

	/*================================================================================================*/
	public class EventorUsesEventorType : Rel<Eventor, Uses, EventorType>, IItemWithId {
			
		public virtual Eventor FromEventor { get { return FromNode; } }
		public virtual EventorType ToEventorType { get { return ToNode; } }
		public override string Label { get { return "EventorUsesEventorType"; } }

	}

	/*================================================================================================*/
	public class EventorUsesEventorPrecision : Rel<Eventor, Uses, EventorPrecision>, IItemWithId {
			
		public virtual Eventor FromEventor { get { return FromNode; } }
		public virtual EventorPrecision ToEventorPrecision { get { return ToNode; } }
		public override string Label { get { return "EventorUsesEventorPrecision"; } }

	}

	/*================================================================================================*/
	public class IdentorUsesIdentorType : Rel<Identor, Uses, IdentorType>, IItemWithId {
			
		public virtual Identor FromIdentor { get { return FromNode; } }
		public virtual IdentorType ToIdentorType { get { return ToNode; } }
		public override string Label { get { return "IdentorUsesIdentorType"; } }

	}

	/*================================================================================================*/
	public class LocatorUsesLocatorType : Rel<Locator, Uses, LocatorType>, IItemWithId {
			
		public virtual Locator FromLocator { get { return FromNode; } }
		public virtual LocatorType ToLocatorType { get { return ToNode; } }
		public override string Label { get { return "LocatorUsesLocatorType"; } }

	}

	/*================================================================================================*/
	public class VectorUsesAxisArtifact : Rel<Vector, UsesAxis, Artifact>, IItemWithId {
			
		public virtual Vector FromVector { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "VectorUsesAxisArtifact"; } }

	}

	/*================================================================================================*/
	public class VectorUsesVectorType : Rel<Vector, Uses, VectorType>, IItemWithId {
			
		public virtual Vector FromVector { get { return FromNode; } }
		public virtual VectorType ToVectorType { get { return ToNode; } }
		public override string Label { get { return "VectorUsesVectorType"; } }

	}

	/*================================================================================================*/
	public class VectorUsesVectorUnit : Rel<Vector, Uses, VectorUnit>, IItemWithId {
			
		public virtual Vector FromVector { get { return FromNode; } }
		public virtual VectorUnit ToVectorUnit { get { return ToNode; } }
		public override string Label { get { return "VectorUsesVectorUnit"; } }

	}

	/*================================================================================================*/
	public class VectorUsesVectorUnitPrefix : Rel<Vector, Uses, VectorUnitPrefix>, IItemWithId {
			
		public virtual Vector FromVector { get { return FromNode; } }
		public virtual VectorUnitPrefix ToVectorUnitPrefix { get { return ToNode; } }
		public override string Label { get { return "VectorUsesVectorUnitPrefix"; } }

	}

	/*================================================================================================*/
	public class VectorTypeUsesVectorRange : Rel<VectorType, Uses, VectorRange>, IItemWithId {
			
		public virtual VectorType FromVectorType { get { return FromNode; } }
		public virtual VectorRange ToVectorRange { get { return ToNode; } }
		public override string Label { get { return "VectorTypeUsesVectorRange"; } }

	}

	/*================================================================================================*/
	public class VectorRangeUsesVectorRangeLevel : Rel<VectorRange, Uses, VectorRangeLevel>, IItemWithId {
			
		public virtual VectorRange FromVectorRange { get { return FromNode; } }
		public virtual VectorRangeLevel ToVectorRangeLevel { get { return ToNode; } }
		public override string Label { get { return "VectorRangeUsesVectorRangeLevel"; } }

	}

	/*================================================================================================*/
	public class VectorUnitDerivedDefinesVectorUnit : Rel<VectorUnitDerived, Defines, VectorUnit>, IItemWithId {
			
		public virtual VectorUnitDerived FromVectorUnitDerived { get { return FromNode; } }
		public virtual VectorUnit ToVectorUnit { get { return ToNode; } }
		public override string Label { get { return "VectorUnitDerivedDefinesVectorUnit"; } }

	}

	/*================================================================================================*/
	public class VectorUnitDerivedRaisesToExpVectorUnit : Rel<VectorUnitDerived, RaisesToExp, VectorUnit>, IItemWithId {
			
		public virtual VectorUnitDerived FromVectorUnitDerived { get { return FromNode; } }
		public virtual VectorUnit ToVectorUnit { get { return ToNode; } }
		public override string Label { get { return "VectorUnitDerivedRaisesToExpVectorUnit"; } }

	}

	/*================================================================================================*/
	public class VectorUnitDerivedUsesVectorUnitPrefix : Rel<VectorUnitDerived, Uses, VectorUnitPrefix>, IItemWithId {
			
		public virtual VectorUnitDerived FromVectorUnitDerived { get { return FromNode; } }
		public virtual VectorUnitPrefix ToVectorUnitPrefix { get { return ToNode; } }
		public override string Label { get { return "VectorUnitDerivedUsesVectorUnitPrefix"; } }

	}

	/*================================================================================================*/
	public class OauthAccessUsesApp : Rel<OauthAccess, Uses, App>, IItemWithId {
			
		public virtual OauthAccess FromOauthAccess { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthAccessUsesApp"; } }

	}

	/*================================================================================================*/
	public class OauthAccessUsesUser : Rel<OauthAccess, Uses, User>, IItemWithId {
			
		public virtual OauthAccess FromOauthAccess { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "OauthAccessUsesUser"; } }

	}

	/*================================================================================================*/
	public class OauthDomainUsesApp : Rel<OauthDomain, Uses, App>, IItemWithId {
			
		public virtual OauthDomain FromOauthDomain { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthDomainUsesApp"; } }

	}

	/*================================================================================================*/
	public class OauthGrantUsesApp : Rel<OauthGrant, Uses, App>, IItemWithId {
			
		public virtual OauthGrant FromOauthGrant { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthGrantUsesApp"; } }

	}

	/*================================================================================================*/
	public class OauthGrantUsesUser : Rel<OauthGrant, Uses, User>, IItemWithId {
			
		public virtual OauthGrant FromOauthGrant { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "OauthGrantUsesUser"; } }

	}

	/*================================================================================================*/
	public class OauthScopeUsesApp : Rel<OauthScope, Uses, App>, IItemWithId {
			
		public virtual OauthScope FromOauthScope { get { return FromNode; } }
		public virtual App ToApp { get { return ToNode; } }
		public override string Label { get { return "OauthScopeUsesApp"; } }

	}

	/*================================================================================================*/
	public class OauthScopeUsesUser : Rel<OauthScope, Uses, User>, IItemWithId {
			
		public virtual OauthScope FromOauthScope { get { return FromNode; } }
		public virtual User ToUser { get { return ToNode; } }
		public override string Label { get { return "OauthScopeUsesUser"; } }

	}


	/* Nodes */


	/*================================================================================================*/
	public abstract class NodeForType : Node {
	
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
	public abstract class NodeForAction : Node {
	
		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long Performed { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		public virtual string Note { get; set; }

	}

	/*================================================================================================*/
	public class Root : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual int RootId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override bool IsRoot { get { return (Path == null || PathIndex == 0); } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return RootId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Root).RootId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsApp ContainsAppList {
			get { return NewRel<RootContainsApp>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsClass ContainsClassList {
			get { return NewRel<RootContainsClass>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEmail ContainsEmailList {
			get { return NewRel<RootContainsEmail>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsInstance ContainsInstanceList {
			get { return NewRel<RootContainsInstance>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMember ContainsMemberList {
			get { return NewRel<RootContainsMember>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMemberType ContainsMemberTypeList {
			get { return NewRel<RootContainsMemberType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMemberTypeAssign ContainsMemberTypeAssignList {
			get { return NewRel<RootContainsMemberTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsUrl ContainsUrlList {
			get { return NewRel<RootContainsUrl>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsUser ContainsUserList {
			get { return NewRel<RootContainsUser>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsFactor ContainsFactorList {
			get { return NewRel<RootContainsFactor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsFactorAssertion ContainsFactorAssertionList {
			get { return NewRel<RootContainsFactorAssertion>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDescriptor ContainsDescriptorList {
			get { return NewRel<RootContainsDescriptor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDescriptorType ContainsDescriptorTypeList {
			get { return NewRel<RootContainsDescriptorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirector ContainsDirectorList {
			get { return NewRel<RootContainsDirector>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirectorType ContainsDirectorTypeList {
			get { return NewRel<RootContainsDirectorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirectorAction ContainsDirectorActionList {
			get { return NewRel<RootContainsDirectorAction>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventor ContainsEventorList {
			get { return NewRel<RootContainsEventor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventorType ContainsEventorTypeList {
			get { return NewRel<RootContainsEventorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventorPrecision ContainsEventorPrecisionList {
			get { return NewRel<RootContainsEventorPrecision>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsIdentor ContainsIdentorList {
			get { return NewRel<RootContainsIdentor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsIdentorType ContainsIdentorTypeList {
			get { return NewRel<RootContainsIdentorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLocator ContainsLocatorList {
			get { return NewRel<RootContainsLocator>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLocatorType ContainsLocatorTypeList {
			get { return NewRel<RootContainsLocatorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVector ContainsVectorList {
			get { return NewRel<RootContainsVector>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorType ContainsVectorTypeList {
			get { return NewRel<RootContainsVectorType>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorRange ContainsVectorRangeList {
			get { return NewRel<RootContainsVectorRange>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorRangeLevel ContainsVectorRangeLevelList {
			get { return NewRel<RootContainsVectorRangeLevel>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnit ContainsVectorUnitList {
			get { return NewRel<RootContainsVectorUnit>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnitPrefix ContainsVectorUnitPrefixList {
			get { return NewRel<RootContainsVectorUnitPrefix>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnitDerived ContainsVectorUnitDerivedList {
			get { return NewRel<RootContainsVectorUnitDerived>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthAccess ContainsOauthAccessList {
			get { return NewRel<RootContainsOauthAccess>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthDomain ContainsOauthDomainList {
			get { return NewRel<RootContainsOauthDomain>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthGrant ContainsOauthGrantList {
			get { return NewRel<RootContainsOauthGrant>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthScope ContainsOauthScopeList {
			get { return NewRel<RootContainsOauthScope>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Artifact : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long ArtifactId { get; set; }

		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long Created { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return ArtifactId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Artifact).ArtifactId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesArtifact InMemberCreates {
			get { return NewRel<MemberCreatesArtifact>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesPrimaryArtifact InFactorListUsesPrimary {
			get { return NewRel<FactorUsesPrimaryArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesRelatedArtifact InFactorListUsesRelated {
			get { return NewRel<FactorUsesRelatedArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorRefinesPrimaryWithArtifact InDescriptorListRefinesPrimaryWith {
			get { return NewRel<DescriptorRefinesPrimaryWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorRefinesRelatedWithArtifact InDescriptorListRefinesRelatedWith {
			get { return NewRel<DescriptorRefinesRelatedWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorRefinesTypeWithArtifact InDescriptorListRefinesTypeWith {
			get { return NewRel<DescriptorRefinesTypeWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesAxisArtifact InVectorListUsesAxis {
			get { return NewRel<VectorUsesAxisArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class App : Artifact {
	
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
		//[PropIsInternal(True)]
		//[PropLen(32)]
		//[PropValidRegex(@"^[a-zA-Z0-9]*$")]
		public virtual string Secret { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return AppId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as App).AppId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsApp InRootContains {
			get { return NewRel<RootContainsApp>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppUsesEmail UsesEmail {
			get { return NewRel<AppUsesEmail>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppDefinesMember DefinesMemberList {
			get { return NewRel<AppDefinesMember>(WeaverRelConn.OutToOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesApp InOauthAccessListUses {
			get { return NewRel<OauthAccessUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthDomainUsesApp InOauthDomainListUses {
			get { return NewRel<OauthDomainUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesApp InOauthGrantListUses {
			get { return NewRel<OauthGrantUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesApp InOauthScopeListUses {
			get { return NewRel<OauthScopeUsesApp>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Class : Artifact {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long ClassId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(128)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(128)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Disamb { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return ClassId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Class).ClassId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsClass InRootContains {
			get { return NewRel<RootContainsClass>(WeaverRelConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public class Email : Node {
	
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
		//[PropValidRegex(@"^[a-zA-Z0-9]*$")]
		public virtual string Code { get; set; }

		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long Created { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		public virtual long? Verified { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return EmailId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Email).EmailId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
	public class Instance : Artifact {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long InstanceId { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(128)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(128)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Disamb { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return InstanceId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Instance).InstanceId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsInstance InRootContains {
			get { return NewRel<RootContainsInstance>(WeaverRelConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public class Member : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long MemberId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return MemberId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Member).MemberId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMember InRootContains {
			get { return NewRel<RootContainsMember>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppDefinesMember InAppDefines {
			get { return NewRel<AppDefinesMember>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasMemberTypeAssign HasMemberTypeAssign {
			get { return NewRel<MemberHasMemberTypeAssign>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasHistoricMemberTypeAssign HasHistoricMemberTypeAssignList {
			get { return NewRel<MemberHasHistoricMemberTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesArtifact CreatesArtifactList {
			get { return NewRel<MemberCreatesArtifact>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesMemberTypeAssign CreatesMemberTypeAssignList {
			get { return NewRel<MemberCreatesMemberTypeAssign>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesFactor CreatesFactorList {
			get { return NewRel<MemberCreatesFactor>(WeaverRelConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserDefinesMember InUserDefines {
			get { return NewRel<UserDefinesMember>(WeaverRelConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public class MemberType : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long MemberTypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return MemberTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as MemberType).MemberTypeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMemberType InRootContains {
			get { return NewRel<RootContainsMemberType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberTypeAssignUsesMemberType InMemberTypeAssignListUses {
			get { return NewRel<MemberTypeAssignUsesMemberType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class MemberTypeAssign : NodeForAction {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long MemberTypeAssignId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return MemberTypeAssignId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as MemberTypeAssign).MemberTypeAssignId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsMemberTypeAssign InRootContains {
			get { return NewRel<RootContainsMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasMemberTypeAssign InMemberHas {
			get { return NewRel<MemberHasMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasHistoricMemberTypeAssign InMemberHasHistoric {
			get { return NewRel<MemberHasHistoricMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesMemberTypeAssign InMemberCreates {
			get { return NewRel<MemberCreatesMemberTypeAssign>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberTypeAssignUsesMemberType UsesMemberType {
			get { return NewRel<MemberTypeAssignUsesMemberType>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class Url : Artifact {
	
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return UrlId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Url).UrlId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsUrl InRootContains {
			get { return NewRel<RootContainsUrl>(WeaverRelConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public class User : Artifact {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long UserId { get; set; }

		[WeaverItemProperty]
		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(16)]
		//[PropLenMin(4)]
		//[PropValidRegex(@"^[a-zA-Z0-9_]*$")]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropIsInternal(True)]
		//[PropIsPassword(True)]
		//[PropLenMax(32)]
		//[PropLenMin(8)]
		public virtual string Password { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return UserId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as User).UserId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsUser InRootContains {
			get { return NewRel<RootContainsUser>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserUsesEmail UsesEmail {
			get { return NewRel<UserUsesEmail>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserDefinesMember DefinesMemberList {
			get { return NewRel<UserDefinesMember>(WeaverRelConn.OutToOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesUser InOauthAccessListUses {
			get { return NewRel<OauthAccessUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesUser InOauthGrantListUses {
			get { return NewRel<OauthGrantUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesUser InOauthScopeListUses {
			get { return NewRel<OauthScopeUsesUser>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Factor : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long FactorId { get; set; }

		[WeaverItemProperty]
		public virtual bool IsDefining { get; set; }

		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long Created { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropIsInternal(True)]
		public virtual long? Deleted { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		public virtual long? Completed { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return FactorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Factor).FactorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsFactor InRootContains {
			get { return NewRel<RootContainsFactor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesFactor InMemberCreates {
			get { return NewRel<MemberCreatesFactor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesPrimaryArtifact UsesPrimaryArtifact {
			get { return NewRel<FactorUsesPrimaryArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesRelatedArtifact UsesRelatedArtifact {
			get { return NewRel<FactorUsesRelatedArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesFactorAssertion UsesFactorAssertion {
			get { return NewRel<FactorUsesFactorAssertion>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorReplacesFactor ReplacesFactor {
			get { return NewRel<FactorReplacesFactor>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDescriptor UsesDescriptor {
			get { return NewRel<FactorUsesDescriptor>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDirector UsesDirector {
			get { return NewRel<FactorUsesDirector>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesEventor UsesEventor {
			get { return NewRel<FactorUsesEventor>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesIdentor UsesIdentor {
			get { return NewRel<FactorUsesIdentor>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesLocator UsesLocator {
			get { return NewRel<FactorUsesLocator>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesVector UsesVector {
			get { return NewRel<FactorUsesVector>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public class FactorAssertion : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long FactorAssertionId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return FactorAssertionId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as FactorAssertion).FactorAssertionId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsFactorAssertion InRootContains {
			get { return NewRel<RootContainsFactorAssertion>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesFactorAssertion InFactorListUses {
			get { return NewRel<FactorUsesFactorAssertion>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public abstract class FactorElementNode : Node {
	
	}

	/*================================================================================================*/
	public class Descriptor : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DescriptorId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return DescriptorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Descriptor).DescriptorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDescriptor InRootContains {
			get { return NewRel<RootContainsDescriptor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDescriptor InFactorListUses {
			get { return NewRel<FactorUsesDescriptor>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorUsesDescriptorType UsesDescriptorType {
			get { return NewRel<DescriptorUsesDescriptorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorRefinesPrimaryWithArtifact RefinesPrimaryWithArtifact {
			get { return NewRel<DescriptorRefinesPrimaryWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorRefinesRelatedWithArtifact RefinesRelatedWithArtifact {
			get { return NewRel<DescriptorRefinesRelatedWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorRefinesTypeWithArtifact RefinesTypeWithArtifact {
			get { return NewRel<DescriptorRefinesTypeWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public class DescriptorType : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DescriptorTypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return DescriptorTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as DescriptorType).DescriptorTypeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDescriptorType InRootContains {
			get { return NewRel<RootContainsDescriptorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DescriptorUsesDescriptorType InDescriptorListUses {
			get { return NewRel<DescriptorUsesDescriptorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Director : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DirectorId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return DirectorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Director).DirectorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirector InRootContains {
			get { return NewRel<RootContainsDirector>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDirector InFactorListUses {
			get { return NewRel<FactorUsesDirector>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesDirectorType UsesDirectorType {
			get { return NewRel<DirectorUsesDirectorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesPrimaryDirectorAction UsesPrimaryDirectorAction {
			get { return NewRel<DirectorUsesPrimaryDirectorAction>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesRelatedDirectorAction UsesRelatedDirectorAction {
			get { return NewRel<DirectorUsesRelatedDirectorAction>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class DirectorType : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DirectorTypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return DirectorTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as DirectorType).DirectorTypeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirectorType InRootContains {
			get { return NewRel<RootContainsDirectorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesDirectorType InDirectorListUses {
			get { return NewRel<DirectorUsesDirectorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class DirectorAction : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DirectorActionId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return DirectorActionId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as DirectorAction).DirectorActionId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsDirectorAction InRootContains {
			get { return NewRel<RootContainsDirectorAction>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesPrimaryDirectorAction InDirectorListUsesPrimary {
			get { return NewRel<DirectorUsesPrimaryDirectorAction>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual DirectorUsesRelatedDirectorAction InDirectorListUsesRelated {
			get { return NewRel<DirectorUsesRelatedDirectorAction>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Eventor : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long EventorId { get; set; }

		[WeaverItemProperty]
		public virtual long DateTime { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return EventorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Eventor).EventorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventor InRootContains {
			get { return NewRel<RootContainsEventor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesEventor InFactorListUses {
			get { return NewRel<FactorUsesEventor>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual EventorUsesEventorType UsesEventorType {
			get { return NewRel<EventorUsesEventorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual EventorUsesEventorPrecision UsesEventorPrecision {
			get { return NewRel<EventorUsesEventorPrecision>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class EventorType : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long EventorTypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return EventorTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as EventorType).EventorTypeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventorType InRootContains {
			get { return NewRel<RootContainsEventorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual EventorUsesEventorType InEventorListUses {
			get { return NewRel<EventorUsesEventorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class EventorPrecision : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long EventorPrecisionId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return EventorPrecisionId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as EventorPrecision).EventorPrecisionId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsEventorPrecision InRootContains {
			get { return NewRel<RootContainsEventorPrecision>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual EventorUsesEventorPrecision InEventorListUses {
			get { return NewRel<EventorUsesEventorPrecision>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Identor : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long IdentorId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		public virtual string Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return IdentorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Identor).IdentorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsIdentor InRootContains {
			get { return NewRel<RootContainsIdentor>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesIdentor InFactorListUses {
			get { return NewRel<FactorUsesIdentor>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IdentorUsesIdentorType UsesIdentorType {
			get { return NewRel<IdentorUsesIdentorType>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class IdentorType : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long IdentorTypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return IdentorTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as IdentorType).IdentorTypeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsIdentorType InRootContains {
			get { return NewRel<RootContainsIdentorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual IdentorUsesIdentorType InIdentorListUses {
			get { return NewRel<IdentorUsesIdentorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Locator : FactorElementNode {
	
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return LocatorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Locator).LocatorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLocator InRootContains {
			get { return NewRel<RootContainsLocator>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesLocator InFactorListUses {
			get { return NewRel<FactorUsesLocator>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual LocatorUsesLocatorType UsesLocatorType {
			get { return NewRel<LocatorUsesLocatorType>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class LocatorType : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long LocatorTypeId { get; set; }

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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return LocatorTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as LocatorType).LocatorTypeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsLocatorType InRootContains {
			get { return NewRel<RootContainsLocatorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual LocatorUsesLocatorType InLocatorListUses {
			get { return NewRel<LocatorUsesLocatorType>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class Vector : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorId { get; set; }

		[WeaverItemProperty]
		public virtual long Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return VectorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Vector).VectorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVector InRootContains {
			get { return NewRel<RootContainsVector>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesVector InFactorListUses {
			get { return NewRel<FactorUsesVector>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesAxisArtifact UsesAxisArtifact {
			get { return NewRel<VectorUsesAxisArtifact>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorType UsesVectorType {
			get { return NewRel<VectorUsesVectorType>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorUnit UsesVectorUnit {
			get { return NewRel<VectorUsesVectorUnit>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorUnitPrefix UsesVectorUnitPrefix {
			get { return NewRel<VectorUsesVectorUnitPrefix>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class VectorType : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorTypeId { get; set; }

		[WeaverItemProperty]
		public virtual long Min { get; set; }

		[WeaverItemProperty]
		public virtual long Max { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return VectorTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as VectorType).VectorTypeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorType InRootContains {
			get { return NewRel<RootContainsVectorType>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorType InVectorListUses {
			get { return NewRel<VectorUsesVectorType>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorTypeUsesVectorRange UsesVectorRange {
			get { return NewRel<VectorTypeUsesVectorRange>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class VectorRange : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorRangeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return VectorRangeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as VectorRange).VectorRangeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorRange InRootContains {
			get { return NewRel<RootContainsVectorRange>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorTypeUsesVectorRange InVectorTypeListUses {
			get { return NewRel<VectorTypeUsesVectorRange>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorRangeUsesVectorRangeLevel UsesVectorRangeLevelList {
			get { return NewRel<VectorRangeUsesVectorRangeLevel>(WeaverRelConn.OutToZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class VectorRangeLevel : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorRangeLevelId { get; set; }

		[WeaverItemProperty]
		public virtual float Position { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return VectorRangeLevelId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as VectorRangeLevel).VectorRangeLevelId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorRangeLevel InRootContains {
			get { return NewRel<RootContainsVectorRangeLevel>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorRangeUsesVectorRangeLevel InVectorRangeListUses {
			get { return NewRel<VectorRangeUsesVectorRangeLevel>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class VectorUnit : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorUnitId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(8)]
		public virtual string Symbol { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return VectorUnitId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as VectorUnit).VectorUnitId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnit InRootContains {
			get { return NewRel<RootContainsVectorUnit>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorUnit InVectorListUses {
			get { return NewRel<VectorUsesVectorUnit>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUnitDerivedDefinesVectorUnit InVectorUnitDerivedListDefines {
			get { return NewRel<VectorUnitDerivedDefinesVectorUnit>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUnitDerivedRaisesToExpVectorUnit InVectorUnitDerivedListRaisesToExp {
			get { return NewRel<VectorUnitDerivedRaisesToExpVectorUnit>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class VectorUnitPrefix : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorUnitPrefixId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(8)]
		public virtual string Symbol { get; set; }

		[WeaverItemProperty]
		public virtual double Amount { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return VectorUnitPrefixId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as VectorUnitPrefix).VectorUnitPrefixId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnitPrefix InRootContains {
			get { return NewRel<RootContainsVectorUnitPrefix>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesVectorUnitPrefix InVectorListUses {
			get { return NewRel<VectorUsesVectorUnitPrefix>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUnitDerivedUsesVectorUnitPrefix InVectorUnitDerivedListUses {
			get { return NewRel<VectorUnitDerivedUsesVectorUnitPrefix>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public class VectorUnitDerived : NodeForType {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorUnitDerivedId { get; set; }

		[WeaverItemProperty]
		public virtual int Exponent { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return VectorUnitDerivedId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as VectorUnitDerived).VectorUnitDerivedId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsVectorUnitDerived InRootContains {
			get { return NewRel<RootContainsVectorUnitDerived>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUnitDerivedDefinesVectorUnit DefinesVectorUnit {
			get { return NewRel<VectorUnitDerivedDefinesVectorUnit>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUnitDerivedRaisesToExpVectorUnit RaisesToExpVectorUnit {
			get { return NewRel<VectorUnitDerivedRaisesToExpVectorUnit>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUnitDerivedUsesVectorUnitPrefix UsesVectorUnitPrefix {
			get { return NewRel<VectorUnitDerivedUsesVectorUnitPrefix>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class OauthAccess : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthAccessId { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropIsUnique(True)]
		//[PropLen(32)]
		//[PropValidRegex(@"^[a-zA-Z0-9]*$")]
		public virtual string Token { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLen(32)]
		//[PropValidRegex(@"^[a-zA-Z0-9]*$")]
		public virtual string Refresh { get; set; }

		[WeaverItemProperty]
		public virtual long Expires { get; set; }

		[WeaverItemProperty]
		public virtual bool IsClientOnly { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return OauthAccessId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthAccess).OauthAccessId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthAccess InRootContains {
			get { return NewRel<RootContainsOauthAccess>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesApp UsesApp {
			get { return NewRel<OauthAccessUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesUser UsesUser {
			get { return NewRel<OauthAccessUsesUser>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public class OauthDomain : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthDomainId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		//[PropValidRegex(@"^[a-zA-Z0-9]+(:[0-9]+|([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,6})$")]
		public virtual string Domain { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return OauthDomainId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthDomain).OauthDomainId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthDomain InRootContains {
			get { return NewRel<RootContainsOauthDomain>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthDomainUsesApp UsesApp {
			get { return NewRel<OauthDomainUsesApp>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class OauthGrant : Node {
	
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
		//[PropValidRegex(@"^[a-zA-Z0-9]*$")]
		public virtual string Code { get; set; }

		[WeaverItemProperty]
		public virtual long Expires { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return OauthGrantId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthGrant).OauthGrantId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthGrant InRootContains {
			get { return NewRel<RootContainsOauthGrant>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesApp UsesApp {
			get { return NewRel<OauthGrantUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesUser UsesUser {
			get { return NewRel<OauthGrantUsesUser>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public class OauthScope : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long OauthScopeId { get; set; }

		[WeaverItemProperty]
		public virtual bool Allow { get; set; }

		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long Created { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return OauthScopeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthScope).OauthScopeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual RootContainsOauthScope InRootContains {
			get { return NewRel<RootContainsOauthScope>(WeaverRelConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesApp UsesApp {
			get { return NewRel<OauthScopeUsesApp>(WeaverRelConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesUser UsesUser {
			get { return NewRel<OauthScopeUsesUser>(WeaverRelConn.OutToOne); }
		}

	}

}
