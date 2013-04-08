// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 1:22:15 PM

using System;
using System.Linq.Expressions;
using Weaver.Items;
using Weaver.Interfaces;

namespace Fabric.Domain {


	/* Relationship Types */
	
	
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


	/* Relationships */


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
	public class VectorUsesAxisArtifact : Rel<Vector, UsesAxis, Artifact>, IItemWithId {
			
		public virtual Vector FromVector { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "VectorUsesAxisArtifact"; } }

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
	public abstract class NodeForAction : Node {
	
		[WeaverItemProperty]
		//[PropIsTimestamp(True)]
		public virtual long Performed { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		//[PropLenMin(1)]
		public virtual string Note { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public NodeForAction(NodeFabType pFabType) : base(pFabType) {}

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
		public Artifact() : base(NodeFabType.BaseClass) {}

		/*--------------------------------------------------------------------------------------------*/
		public Artifact(NodeFabType pFabType) : base(pFabType) {}


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
		public App() : base(NodeFabType.App) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return AppId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as App).AppId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(128)]
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Disamb { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		//[PropLenMin(1)]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Class() : base(NodeFabType.Class) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return ClassId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Class).ClassId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
		//[PropLenMin(1)]
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
		public Email() : base(NodeFabType.Email) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return EmailId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Email).EmailId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(128)]
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public virtual string Disamb { get; set; }

		[WeaverItemProperty]
		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		//[PropLenMin(1)]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Instance() : base(NodeFabType.Instance) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return InstanceId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Instance).InstanceId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
	}

	/*================================================================================================*/
	public class Member : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long MemberId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Member() : base(NodeFabType.Member) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return MemberId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Member).MemberId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
	public class MemberTypeAssign : NodeForAction {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long MemberTypeAssignId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte MemberTypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssign() : base(NodeFabType.MemberTypeAssign) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return MemberTypeAssignId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as MemberTypeAssign).MemberTypeAssignId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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

	}

	/*================================================================================================*/
	public class Url : Artifact {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long UrlId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(128)]
		//[PropLenMin(1)]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(2048)]
		//[PropLenMin(1)]
		public virtual string AbsoluteUrl { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Url() : base(NodeFabType.Url) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return UrlId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Url).UrlId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
		public User() : base(NodeFabType.User) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return UserId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as User).UserId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte FactorAssertionId { get; set; }

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
		//[PropLenMin(1)]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Factor() : base(NodeFabType.Factor) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return FactorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Factor).FactorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
	public abstract class FactorElementNode : Node {
	
		/*--------------------------------------------------------------------------------------------*/
		public FactorElementNode(NodeFabType pFabType) : base(pFabType) {}

	}

	/*================================================================================================*/
	public class Descriptor : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DescriptorId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte DescriptorTypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Descriptor() : base(NodeFabType.Descriptor) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return DescriptorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Descriptor).DescriptorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDescriptor InFactorListUses {
			get { return NewRel<FactorUsesDescriptor>(WeaverRelConn.InFromOneOrMore); }
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
	public class Director : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long DirectorId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte DirectorTypeId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte PrimaryDirectorActionId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte RelatedDirectorActionId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Director() : base(NodeFabType.Director) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return DirectorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Director).DirectorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesDirector InFactorListUses {
			get { return NewRel<FactorUsesDirector>(WeaverRelConn.InFromOneOrMore); }
		}

	}

	/*================================================================================================*/
	public class Eventor : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long EventorId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte EventorTypeId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte EventorPrecisionId { get; set; }

		[WeaverItemProperty]
		public virtual long DateTime { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Eventor() : base(NodeFabType.Eventor) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return EventorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Eventor).EventorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesEventor InFactorListUses {
			get { return NewRel<FactorUsesEventor>(WeaverRelConn.InFromOneOrMore); }
		}

	}

	/*================================================================================================*/
	public class Identor : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long IdentorId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte IdentorTypeId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		//[PropLenMin(1)]
		public virtual string Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Identor() : base(NodeFabType.Identor) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return IdentorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Identor).IdentorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesIdentor InFactorListUses {
			get { return NewRel<FactorUsesIdentor>(WeaverRelConn.InFromOneOrMore); }
		}

	}

	/*================================================================================================*/
	public class Locator : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long LocatorId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte LocatorTypeId { get; set; }

		[WeaverItemProperty]
		public virtual double ValueX { get; set; }

		[WeaverItemProperty]
		public virtual double ValueY { get; set; }

		[WeaverItemProperty]
		public virtual double ValueZ { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Locator() : base(NodeFabType.Locator) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return LocatorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Locator).LocatorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesLocator InFactorListUses {
			get { return NewRel<FactorUsesLocator>(WeaverRelConn.InFromOneOrMore); }
		}

	}

	/*================================================================================================*/
	public class Vector : FactorElementNode {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual long VectorId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorTypeId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorUnitId { get; set; }

		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public virtual byte VectorUnitPrefixId { get; set; }

		[WeaverItemProperty]
		public virtual long Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Vector() : base(NodeFabType.Vector) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return VectorId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Vector).VectorId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesVector InFactorListUses {
			get { return NewRel<FactorUsesVector>(WeaverRelConn.InFromOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual VectorUsesAxisArtifact UsesAxisArtifact {
			get { return NewRel<VectorUsesAxisArtifact>(WeaverRelConn.OutToOne); }
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
		public OauthAccess() : base(NodeFabType.OauthAccess) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return OauthAccessId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthAccess).OauthAccessId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9]+(:[0-9]+|([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,6})$")]
		public virtual string Domain { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomain() : base(NodeFabType.OauthDomain) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return OauthDomainId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthDomain).OauthDomainId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
		//[PropLenMin(1)]
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
		public OauthGrant() : base(NodeFabType.OauthGrant) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return OauthGrantId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthGrant).OauthGrantId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
		public OauthScope() : base(NodeFabType.OauthScope) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return OauthScopeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthScope).OauthScopeId);
		}

		
		////////////////////////////////////////////////////////////////////////////////////////////////
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
