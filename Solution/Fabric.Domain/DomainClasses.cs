// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 5/5/2013 9:20:44 PM

using System;
using System.Collections.Generic;
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
	public class DescriptorRefinesPrimaryWith : IWeaverRelType {
	
		public string Label { get { return "DescriptorRefinesPrimaryWith"; } }

	}

	/*================================================================================================*/
	public class DescriptorRefinesRelatedWith : IWeaverRelType {
	
		public string Label { get { return "DescriptorRefinesRelatedWith"; } }

	}

	/*================================================================================================*/
	public class DescriptorRefinesTypeWith : IWeaverRelType {
	
		public string Label { get { return "DescriptorRefinesTypeWith"; } }

	}

	/*================================================================================================*/
	public class VectorUsesAxis : IWeaverRelType {
	
		public string Label { get { return "VectorUsesAxis"; } }

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
	public class FactorDescriptorRefinesPrimaryWithArtifact : Rel<Factor, DescriptorRefinesPrimaryWith, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorDescriptorRefinesPrimaryWithArtifact"; } }

	}

	/*================================================================================================*/
	public class FactorDescriptorRefinesRelatedWithArtifact : Rel<Factor, DescriptorRefinesRelatedWith, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorDescriptorRefinesRelatedWithArtifact"; } }

	}

	/*================================================================================================*/
	public class FactorDescriptorRefinesTypeWithArtifact : Rel<Factor, DescriptorRefinesTypeWith, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorDescriptorRefinesTypeWithArtifact"; } }

	}

	/*================================================================================================*/
	public class FactorVectorUsesAxisArtifact : Rel<Factor, VectorUsesAxis, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return FromNode; } }
		public virtual Artifact ToArtifact { get { return ToNode; } }
		public override string Label { get { return "FactorVectorUsesAxisArtifact"; } }

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
	public abstract partial class Node {
	
		[WeaverItemProperty]
		//[PropIsInternal(True)]
		public virtual int FabType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			if ( pData.ContainsKey("N_FT") ) {
				FabType = int.Parse(pData["N_FT"]);
			}

		}

	}

	/*================================================================================================*/
	public abstract partial class NodeForAction : Node {
	
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("NA_Pe") ) {
				Performed = long.Parse(pData["NA_Pe"]);
			}
			
			if ( pData.ContainsKey("NA_No") ) {
				Note = pData["NA_No"];
			}

		}

	}

	/*================================================================================================*/
	public partial class Artifact : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
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
		public override void SetTypeId(long pTypeId) { ArtifactId = pTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Artifact).ArtifactId);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("A_AId") ) {
				ArtifactId = long.Parse(pData["A_AId"]);
			}
			
			if ( pData.ContainsKey("A_Cr") ) {
				Created = long.Parse(pData["A_Cr"]);
			}

		}

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
		public virtual FactorDescriptorRefinesPrimaryWithArtifact InFactorListDescriptorRefinesPrimaryWith {
			get { return NewRel<FactorDescriptorRefinesPrimaryWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesRelatedWithArtifact InFactorListDescriptorRefinesRelatedWith {
			get { return NewRel<FactorDescriptorRefinesRelatedWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesTypeWithArtifact InFactorListDescriptorRefinesTypeWith {
			get { return NewRel<FactorDescriptorRefinesTypeWithArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorVectorUsesAxisArtifact InFactorListVectorUsesAxis {
			get { return NewRel<FactorVectorUsesAxisArtifact>(WeaverRelConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class App : Artifact {
	
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
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("Ap_Na") ) {
				Name = pData["Ap_Na"];
			}
			
			if ( pData.ContainsKey("Ap_Se") ) {
				Secret = pData["Ap_Se"];
			}

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
	public partial class Class : Artifact {
	
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
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("Cl_Na") ) {
				Name = pData["Cl_Na"];
			}
			
			if ( pData.ContainsKey("Cl_Di") ) {
				Disamb = pData["Cl_Di"];
			}
			
			if ( pData.ContainsKey("Cl_No") ) {
				Note = pData["Cl_No"];
			}

		}

	}

	/*================================================================================================*/
	public partial class Email : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
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
		public override void SetTypeId(long pTypeId) { EmailId = pTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Email).EmailId);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("E_Id") ) {
				EmailId = long.Parse(pData["E_Id"]);
			}
			
			if ( pData.ContainsKey("E_Ad") ) {
				Address = pData["E_Ad"];
			}
			
			if ( pData.ContainsKey("E_Co") ) {
				Code = pData["E_Co"];
			}
			
			if ( pData.ContainsKey("E_Cr") ) {
				Created = long.Parse(pData["E_Cr"]);
			}
			
			if ( pData.ContainsKey("E_Ve") ) {
				Verified = long.Parse(pData["E_Ve"]);
			}

		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppUsesEmail InAppListUses {
			get { return NewRel<AppUsesEmail>(WeaverRelConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserUsesEmail InUserListUses {
			get { return NewRel<UserUsesEmail>(WeaverRelConn.InFromOneOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Instance : Artifact {
	
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
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("In_Na") ) {
				Name = pData["In_Na"];
			}
			
			if ( pData.ContainsKey("In_Di") ) {
				Disamb = pData["In_Di"];
			}
			
			if ( pData.ContainsKey("In_No") ) {
				Note = pData["In_No"];
			}

		}

	}

	/*================================================================================================*/
	public partial class Member : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		public virtual long MemberId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Member() : base(NodeFabType.Member) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return MemberId; }
		public override void SetTypeId(long pTypeId) { MemberId = pTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Member).MemberId);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			if ( pData.ContainsKey("M_Id") ) {
				MemberId = long.Parse(pData["M_Id"]);
			}

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
	public partial class MemberTypeAssign : NodeForAction {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		public virtual long MemberTypeAssignId { get; set; }

		[WeaverItemProperty]
		public virtual byte MemberTypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssign() : base(NodeFabType.MemberTypeAssign) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return MemberTypeAssignId; }
		public override void SetTypeId(long pTypeId) { MemberTypeAssignId = pTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as MemberTypeAssign).MemberTypeAssignId);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("MTA_Id") ) {
				MemberTypeAssignId = long.Parse(pData["MTA_Id"]);
			}
			
			if ( pData.ContainsKey("MTA_Mt") ) {
				MemberTypeId = byte.Parse(pData["MTA_Mt"]);
			}

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

	}

	/*================================================================================================*/
	public partial class Url : Artifact {
	
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
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("Ur_Na") ) {
				Name = pData["Ur_Na"];
			}
			
			if ( pData.ContainsKey("Ur_Ab") ) {
				AbsoluteUrl = pData["Ur_Ab"];
			}

		}

	}

	/*================================================================================================*/
	public partial class User : Artifact {
	
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
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("U_Na") ) {
				Name = pData["U_Na"];
			}
			
			if ( pData.ContainsKey("U_Pa") ) {
				Password = pData["U_Pa"];
			}

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
	public partial class Factor : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
		public virtual long FactorId { get; set; }

		[WeaverItemProperty]
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

		[WeaverItemProperty]
		//[PropIsSubProp("TypeId")]
		public virtual byte? Descriptor_TypeId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("TypeId")]
		public virtual byte? Director_TypeId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("PrimaryActionId")]
		public virtual byte? Director_PrimaryActionId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("RelatedActionId")]
		public virtual byte? Director_RelatedActionId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("TypeId")]
		public virtual byte? Eventor_TypeId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("PrecisionId")]
		public virtual byte? Eventor_PrecisionId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("DateTime")]
		public virtual long? Eventor_DateTime { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("TypeId")]
		public virtual byte? Identor_TypeId { get; set; }

		[WeaverItemProperty]
		//[PropLenMax(256)]
		//[PropLenMin(1)]
		//[PropIsSubProp("Value")]
		public virtual string Identor_Value { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("TypeId")]
		public virtual byte? Locator_TypeId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("ValueX")]
		public virtual double? Locator_ValueX { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("ValueY")]
		public virtual double? Locator_ValueY { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("ValueZ")]
		public virtual double? Locator_ValueZ { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("TypeId")]
		public virtual byte? Vector_TypeId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("UnitId")]
		public virtual byte? Vector_UnitId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("UnitPrefixId")]
		public virtual byte? Vector_UnitPrefixId { get; set; }

		[WeaverItemProperty]
		//[PropIsSubProp("Value")]
		public virtual long? Vector_Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Factor() : base(NodeFabType.Factor) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override long GetTypeId() { return FactorId; }
		public override void SetTypeId(long pTypeId) { FactorId = pTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as Factor).FactorId);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("F_Id") ) {
				FactorId = long.Parse(pData["F_Id"]);
			}
			
			if ( pData.ContainsKey("F_Fa") ) {
				FactorAssertionId = byte.Parse(pData["F_Fa"]);
			}
			
			if ( pData.ContainsKey("F_Df") ) {
				IsDefining = bool.Parse(pData["F_Df"]);
			}
			
			if ( pData.ContainsKey("F_Cr") ) {
				Created = long.Parse(pData["F_Cr"]);
			}
			
			if ( pData.ContainsKey("F_Dl") ) {
				Deleted = long.Parse(pData["F_Dl"]);
			}
			
			if ( pData.ContainsKey("F_Co") ) {
				Completed = long.Parse(pData["F_Co"]);
			}
			
			if ( pData.ContainsKey("F_No") ) {
				Note = pData["F_No"];
			}
			
			if ( pData.ContainsKey("F_DeT") ) {
				Descriptor_TypeId = byte.Parse(pData["F_DeT"]);
			}
			
			if ( pData.ContainsKey("F_DiT") ) {
				Director_TypeId = byte.Parse(pData["F_DiT"]);
			}
			
			if ( pData.ContainsKey("F_DiP") ) {
				Director_PrimaryActionId = byte.Parse(pData["F_DiP"]);
			}
			
			if ( pData.ContainsKey("F_DiR") ) {
				Director_RelatedActionId = byte.Parse(pData["F_DiR"]);
			}
			
			if ( pData.ContainsKey("F_EvT") ) {
				Eventor_TypeId = byte.Parse(pData["F_EvT"]);
			}
			
			if ( pData.ContainsKey("F_EvP") ) {
				Eventor_PrecisionId = byte.Parse(pData["F_EvP"]);
			}
			
			if ( pData.ContainsKey("F_EvD") ) {
				Eventor_DateTime = long.Parse(pData["F_EvD"]);
			}
			
			if ( pData.ContainsKey("F_IdT") ) {
				Identor_TypeId = byte.Parse(pData["F_IdT"]);
			}
			
			if ( pData.ContainsKey("F_IdV") ) {
				Identor_Value = pData["F_IdV"];
			}
			
			if ( pData.ContainsKey("F_LoT") ) {
				Locator_TypeId = byte.Parse(pData["F_LoT"]);
			}
			
			if ( pData.ContainsKey("F_LoX") ) {
				Locator_ValueX = double.Parse(pData["F_LoX"]);
			}
			
			if ( pData.ContainsKey("F_LoY") ) {
				Locator_ValueY = double.Parse(pData["F_LoY"]);
			}
			
			if ( pData.ContainsKey("F_LoZ") ) {
				Locator_ValueZ = double.Parse(pData["F_LoZ"]);
			}
			
			if ( pData.ContainsKey("F_VeT") ) {
				Vector_TypeId = byte.Parse(pData["F_VeT"]);
			}
			
			if ( pData.ContainsKey("F_VeU") ) {
				Vector_UnitId = byte.Parse(pData["F_VeU"]);
			}
			
			if ( pData.ContainsKey("F_VeP") ) {
				Vector_UnitPrefixId = byte.Parse(pData["F_VeP"]);
			}
			
			if ( pData.ContainsKey("F_VeV") ) {
				Vector_Value = long.Parse(pData["F_VeV"]);
			}

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
		public virtual FactorDescriptorRefinesPrimaryWithArtifact DescriptorRefinesPrimaryWithArtifact {
			get { return NewRel<FactorDescriptorRefinesPrimaryWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesRelatedWithArtifact DescriptorRefinesRelatedWithArtifact {
			get { return NewRel<FactorDescriptorRefinesRelatedWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesTypeWithArtifact DescriptorRefinesTypeWithArtifact {
			get { return NewRel<FactorDescriptorRefinesTypeWithArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorVectorUsesAxisArtifact VectorUsesAxisArtifact {
			get { return NewRel<FactorVectorUsesAxisArtifact>(WeaverRelConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public partial class OauthAccess : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
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
		public override void SetTypeId(long pTypeId) { OauthAccessId = pTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthAccess).OauthAccessId);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("OA_Id") ) {
				OauthAccessId = long.Parse(pData["OA_Id"]);
			}
			
			if ( pData.ContainsKey("OA_To") ) {
				Token = pData["OA_To"];
			}
			
			if ( pData.ContainsKey("OA_Re") ) {
				Refresh = pData["OA_Re"];
			}
			
			if ( pData.ContainsKey("OA_Ex") ) {
				Expires = long.Parse(pData["OA_Ex"]);
			}
			
			if ( pData.ContainsKey("OA_CO") ) {
				IsClientOnly = bool.Parse(pData["OA_CO"]);
			}

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
	public partial class OauthDomain : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
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
		public override void SetTypeId(long pTypeId) { OauthDomainId = pTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthDomain).OauthDomainId);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("OD_Id") ) {
				OauthDomainId = long.Parse(pData["OD_Id"]);
			}
			
			if ( pData.ContainsKey("OD_Do") ) {
				Domain = pData["OD_Do"];
			}

		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthDomainUsesApp UsesApp {
			get { return NewRel<OauthDomainUsesApp>(WeaverRelConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class OauthGrant : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
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
		public override void SetTypeId(long pTypeId) { OauthGrantId = pTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthGrant).OauthGrantId);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("OG_Id") ) {
				OauthGrantId = long.Parse(pData["OG_Id"]);
			}
			
			if ( pData.ContainsKey("OG_Re") ) {
				RedirectUri = pData["OG_Re"];
			}
			
			if ( pData.ContainsKey("OG_Co") ) {
				Code = pData["OG_Co"];
			}
			
			if ( pData.ContainsKey("OG_Ex") ) {
				Expires = long.Parse(pData["OG_Ex"]);
			}

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
	public partial class OauthScope : Node {
	
		[WeaverItemProperty]
		//[PropIsPrimaryKey(True)]
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
		public override void SetTypeId(long pTypeId) { OauthScopeId = pTypeId; }
		
		/*--------------------------------------------------------------------------------------------*/
		public override Expression<Func<T, object>> GetTypeIdProp<T>() {
			return (x => (x as OauthScope).OauthScopeId);
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("OS_Id") ) {
				OauthScopeId = long.Parse(pData["OS_Id"]);
			}
			
			if ( pData.ContainsKey("OS_Al") ) {
				Allow = bool.Parse(pData["OS_Al"]);
			}
			
			if ( pData.ContainsKey("OS_Cr") ) {
				Created = long.Parse(pData["OS_Cr"]);
			}

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
