// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/17/2013 10:59:22 PM

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Fabric.Domain;
using Weaver.Core.Elements;

namespace Fabric.Domain {


	/* Edge Types */
	
	
	/*================================================================================================*/
	public class Uses : IWeaverEdgeType {
	
		public string Label { get { return "Uses"; } }

	}

	/*================================================================================================*/
	public class Defines : IWeaverEdgeType {
	
		public string Label { get { return "Defines"; } }

	}

	/*================================================================================================*/
	public class Has : IWeaverEdgeType {
	
		public string Label { get { return "Has"; } }

	}

	/*================================================================================================*/
	public class HasHistoric : IWeaverEdgeType {
	
		public string Label { get { return "HasHistoric"; } }

	}

	/*================================================================================================*/
	public class Creates : IWeaverEdgeType {
	
		public string Label { get { return "Creates"; } }

	}

	/*================================================================================================*/
	public class UsesPrimary : IWeaverEdgeType {
	
		public string Label { get { return "UsesPrimary"; } }

	}

	/*================================================================================================*/
	public class UsesRelated : IWeaverEdgeType {
	
		public string Label { get { return "UsesRelated"; } }

	}

	/*================================================================================================*/
	public class DescriptorRefinesPrimaryWith : IWeaverEdgeType {
	
		public string Label { get { return "DescriptorRefinesPrimaryWith"; } }

	}

	/*================================================================================================*/
	public class DescriptorRefinesRelatedWith : IWeaverEdgeType {
	
		public string Label { get { return "DescriptorRefinesRelatedWith"; } }

	}

	/*================================================================================================*/
	public class DescriptorRefinesTypeWith : IWeaverEdgeType {
	
		public string Label { get { return "DescriptorRefinesTypeWith"; } }

	}

	/*================================================================================================*/
	public class VectorUsesAxis : IWeaverEdgeType {
	
		public string Label { get { return "VectorUsesAxis"; } }

	}


	/* Edges */


	/*================================================================================================*/
	public class AppUsesEmail : Rel<App, Uses, Email>, IItemWithId {
			
		public virtual App FromApp { get { return OutVertex; } }
		public virtual Email ToEmail { get { return InVertex; } }
		public override string Label { get { return "AppUsesEmail"; } }

	}
	
	/*================================================================================================*/
	public class AppDefinesMember : Rel<App, Defines, Member>, IItemWithId {
			
		public virtual App FromApp { get { return OutVertex; } }
		public virtual Member ToMember { get { return InVertex; } }
		public override string Label { get { return "AppDefinesMember"; } }

	}
	
	/*================================================================================================*/
	public class MemberHasMemberTypeAssign : Rel<Member, Has, MemberTypeAssign>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return InVertex; } }
		public override string Label { get { return "MemberHasMemberTypeAssign"; } }

	}
	
	/*================================================================================================*/
	public class MemberHasHistoricMemberTypeAssign : Rel<Member, HasHistoric, MemberTypeAssign>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return InVertex; } }
		public override string Label { get { return "MemberHasHistoricMemberTypeAssign"; } }

	}
	
	/*================================================================================================*/
	public class MemberCreatesArtifact : Rel<Member, Creates, Artifact>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }
		public override string Label { get { return "MemberCreatesArtifact"; } }

		/*--------------------------------------------------------------------------------------------* /
		public override bool IsValidInVertexType(Type pType) {
			if ( pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Artifact<>) ) {
				return true;
			}

			return (pType.BaseType != null && pType.BaseType.IsGenericType &&
				pType.BaseType.GetGenericTypeDefinition() == typeof(Artifact<>));
		}*/

	}
	
	/*================================================================================================*/
	public class MemberCreatesMemberTypeAssign : Rel<Member, Creates, MemberTypeAssign>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return InVertex; } }
		public override string Label { get { return "MemberCreatesMemberTypeAssign"; } }

	}
	
	/*================================================================================================*/
	public class MemberCreatesFactor : Rel<Member, Creates, Factor>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual Factor ToFactor { get { return InVertex; } }
		public override string Label { get { return "MemberCreatesFactor"; } }

	}
	
	/*================================================================================================*/
	public class UserUsesEmail : Rel<User, Uses, Email>, IItemWithId {
			
		public virtual User FromUser { get { return OutVertex; } }
		public virtual Email ToEmail { get { return InVertex; } }
		public override string Label { get { return "UserUsesEmail"; } }

	}
	
	/*================================================================================================*/
	public class UserDefinesMember : Rel<User, Defines, Member>, IItemWithId {
			
		public virtual User FromUser { get { return OutVertex; } }
		public virtual Member ToMember { get { return InVertex; } }
		public override string Label { get { return "UserDefinesMember"; } }

	}
	
	/*================================================================================================*/
	public class FactorUsesPrimaryArtifact : Rel<Factor, UsesPrimary, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }
		public override string Label { get { return "FactorUsesPrimaryArtifact"; } }

		/*--------------------------------------------------------------------------------------------* /
		public override bool IsValidInVertexType(Type pType) {
			if ( pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Artifact<>) ) {
				return true;
			}

			return (pType.BaseType != null && pType.BaseType.IsGenericType &&
				pType.BaseType.GetGenericTypeDefinition() == typeof(Artifact<>));
		}*/

	}
	
	/*================================================================================================*/
	public class FactorUsesRelatedArtifact : Rel<Factor, UsesRelated, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }
		public override string Label { get { return "FactorUsesRelatedArtifact"; } }

		/*--------------------------------------------------------------------------------------------* /
		public override bool IsValidInVertexType(Type pType) {
			if ( pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Artifact<>) ) {
				return true;
			}

			return (pType.BaseType != null && pType.BaseType.IsGenericType &&
				pType.BaseType.GetGenericTypeDefinition() == typeof(Artifact<>));
		}*/

	}
	
	/*================================================================================================*/
	public class FactorDescriptorRefinesPrimaryWithArtifact : Rel<Factor, DescriptorRefinesPrimaryWith, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }
		public override string Label { get { return "FactorDescriptorRefinesPrimaryWithArtifact"; } }

		/*--------------------------------------------------------------------------------------------* /
		public override bool IsValidInVertexType(Type pType) {
			if ( pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Artifact<>) ) {
				return true;
			}

			return (pType.BaseType != null && pType.BaseType.IsGenericType &&
				pType.BaseType.GetGenericTypeDefinition() == typeof(Artifact<>));
		}*/

	}
	
	/*================================================================================================*/
	public class FactorDescriptorRefinesRelatedWithArtifact : Rel<Factor, DescriptorRefinesRelatedWith, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }
		public override string Label { get { return "FactorDescriptorRefinesRelatedWithArtifact"; } }

		/*--------------------------------------------------------------------------------------------* /
		public override bool IsValidInVertexType(Type pType) {
			if ( pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Artifact<>) ) {
				return true;
			}

			return (pType.BaseType != null && pType.BaseType.IsGenericType &&
				pType.BaseType.GetGenericTypeDefinition() == typeof(Artifact<>));
		}*/

	}
	
	/*================================================================================================*/
	public class FactorDescriptorRefinesTypeWithArtifact : Rel<Factor, DescriptorRefinesTypeWith, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }
		public override string Label { get { return "FactorDescriptorRefinesTypeWithArtifact"; } }

		/*--------------------------------------------------------------------------------------------* /
		public override bool IsValidInVertexType(Type pType) {
			if ( pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Artifact<>) ) {
				return true;
			}

			return (pType.BaseType != null && pType.BaseType.IsGenericType &&
				pType.BaseType.GetGenericTypeDefinition() == typeof(Artifact<>));
		}*/

	}
	
	/*================================================================================================*/
	public class FactorVectorUsesAxisArtifact : Rel<Factor, VectorUsesAxis, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }
		public override string Label { get { return "FactorVectorUsesAxisArtifact"; } }

		/*--------------------------------------------------------------------------------------------* /
		public override bool IsValidInVertexType(Type pType) {
			if ( pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Artifact<>) ) {
				return true;
			}

			return (pType.BaseType != null && pType.BaseType.IsGenericType &&
				pType.BaseType.GetGenericTypeDefinition() == typeof(Artifact<>));
		}*/

	}
	
	/*================================================================================================*/
	public class OauthAccessUsesApp : Rel<OauthAccess, Uses, App>, IItemWithId {
			
		public virtual OauthAccess FromOauthAccess { get { return OutVertex; } }
		public virtual App ToApp { get { return InVertex; } }
		public override string Label { get { return "OauthAccessUsesApp"; } }

	}
	
	/*================================================================================================*/
	public class OauthAccessUsesUser : Rel<OauthAccess, Uses, User>, IItemWithId {
			
		public virtual OauthAccess FromOauthAccess { get { return OutVertex; } }
		public virtual User ToUser { get { return InVertex; } }
		public override string Label { get { return "OauthAccessUsesUser"; } }

	}
	
	/*================================================================================================*/
	public class OauthDomainUsesApp : Rel<OauthDomain, Uses, App>, IItemWithId {
			
		public virtual OauthDomain FromOauthDomain { get { return OutVertex; } }
		public virtual App ToApp { get { return InVertex; } }
		public override string Label { get { return "OauthDomainUsesApp"; } }

	}
	
	/*================================================================================================*/
	public class OauthGrantUsesApp : Rel<OauthGrant, Uses, App>, IItemWithId {
			
		public virtual OauthGrant FromOauthGrant { get { return OutVertex; } }
		public virtual App ToApp { get { return InVertex; } }
		public override string Label { get { return "OauthGrantUsesApp"; } }

	}
	
	/*================================================================================================*/
	public class OauthGrantUsesUser : Rel<OauthGrant, Uses, User>, IItemWithId {
			
		public virtual OauthGrant FromOauthGrant { get { return OutVertex; } }
		public virtual User ToUser { get { return InVertex; } }
		public override string Label { get { return "OauthGrantUsesUser"; } }

	}
	
	/*================================================================================================*/
	public class OauthScopeUsesApp : Rel<OauthScope, Uses, App>, IItemWithId {
			
		public virtual OauthScope FromOauthScope { get { return OutVertex; } }
		public virtual App ToApp { get { return InVertex; } }
		public override string Label { get { return "OauthScopeUsesApp"; } }

	}
	
	/*================================================================================================*/
	public class OauthScopeUsesUser : Rel<OauthScope, Uses, User>, IItemWithId {
			
		public virtual OauthScope FromOauthScope { get { return OutVertex; } }
		public virtual User ToUser { get { return InVertex; } }
		public override string Label { get { return "OauthScopeUsesUser"; } }

	}
	


	/* Vertices */


	/*================================================================================================*/
	public abstract partial class Vertex {
	
		[WeaverItemProperty]
		public virtual byte FabType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void FillWithData(IDictionary<string,string> pData) {
			if ( pData == null ) {
				return;
			}
			
			if ( pData.ContainsKey("N_FT") ) {
				FabType = byte.Parse(pData["N_FT"]);
			}

		}

	}

	/*================================================================================================*/
	public abstract partial class VertexForAction : Vertex {
	
		[WeaverItemProperty]
		public virtual long Performed { get; set; }

		[WeaverItemProperty]
		public virtual string Note { get; set; }

		/*--------------------------------------------------------------------------------------------*/
		public VertexForAction(VertexFabType pFabType) : base(pFabType) {}


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
	public partial class Artifact : Vertex {
	
		[WeaverItemProperty]
		public virtual long ArtifactId { get; set; }

		[WeaverItemProperty]
		public virtual long Created { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Artifact() : base(VertexFabType.BaseClass) {}

		/*--------------------------------------------------------------------------------------------*/
		public Artifact(VertexFabType pFabType) : base(pFabType) {}


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
			get { return NewEdge<MemberCreatesArtifact>(WeaverEdgeConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesPrimaryArtifact InFactorListUsesPrimary {
			get { return NewEdge<FactorUsesPrimaryArtifact>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesRelatedArtifact InFactorListUsesRelated {
			get { return NewEdge<FactorUsesRelatedArtifact>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesPrimaryWithArtifact InFactorListDescriptorRefinesPrimaryWith {
			get { return NewEdge<FactorDescriptorRefinesPrimaryWithArtifact>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesRelatedWithArtifact InFactorListDescriptorRefinesRelatedWith {
			get { return NewEdge<FactorDescriptorRefinesRelatedWithArtifact>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesTypeWithArtifact InFactorListDescriptorRefinesTypeWith {
			get { return NewEdge<FactorDescriptorRefinesTypeWithArtifact>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorVectorUsesAxisArtifact InFactorListVectorUsesAxis {
			get { return NewEdge<FactorVectorUsesAxisArtifact>(WeaverEdgeConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class App : Artifact {
	
		[WeaverItemProperty]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		public virtual string Secret { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public App() : base(VertexFabType.App) {}


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
			get { return NewEdge<AppUsesEmail>(WeaverEdgeConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppDefinesMember DefinesMemberList {
			get { return NewEdge<AppDefinesMember>(WeaverEdgeConn.OutToOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesApp InOauthAccessListUses {
			get { return NewEdge<OauthAccessUsesApp>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthDomainUsesApp InOauthDomainListUses {
			get { return NewEdge<OauthDomainUsesApp>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesApp InOauthGrantListUses {
			get { return NewEdge<OauthGrantUsesApp>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesApp InOauthScopeListUses {
			get { return NewEdge<OauthScopeUsesApp>(WeaverEdgeConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Class : Artifact {
	
		[WeaverItemProperty]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		public virtual string Disamb { get; set; }

		[WeaverItemProperty]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Class() : base(VertexFabType.Class) {}


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
	public partial class Email : Vertex {
	
		[WeaverItemProperty]
		public virtual long EmailId { get; set; }

		[WeaverItemProperty]
		public virtual string Address { get; set; }

		[WeaverItemProperty]
		public virtual string Code { get; set; }

		[WeaverItemProperty]
		public virtual long Created { get; set; }

		[WeaverItemProperty]
		public virtual long? Verified { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Email() : base(VertexFabType.Email) {}


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
			get { return NewEdge<AppUsesEmail>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserUsesEmail InUserListUses {
			get { return NewEdge<UserUsesEmail>(WeaverEdgeConn.InFromOneOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Instance : Artifact {
	
		[WeaverItemProperty]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		public virtual string Disamb { get; set; }

		[WeaverItemProperty]
		public virtual string Note { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Instance() : base(VertexFabType.Instance) {}


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
	public partial class Member : Vertex {
	
		[WeaverItemProperty]
		public virtual long MemberId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Member() : base(VertexFabType.Member) {}


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
			
			base.FillWithData(pData);
			
			if ( pData.ContainsKey("M_Id") ) {
				MemberId = long.Parse(pData["M_Id"]);
			}

		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppDefinesMember InAppDefines {
			get { return NewEdge<AppDefinesMember>(WeaverEdgeConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasMemberTypeAssign HasMemberTypeAssign {
			get { return NewEdge<MemberHasMemberTypeAssign>(WeaverEdgeConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasHistoricMemberTypeAssign HasHistoricMemberTypeAssignList {
			get { return NewEdge<MemberHasHistoricMemberTypeAssign>(WeaverEdgeConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesArtifact CreatesArtifactList {
			get { return NewEdge<MemberCreatesArtifact>(WeaverEdgeConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesMemberTypeAssign CreatesMemberTypeAssignList {
			get { return NewEdge<MemberCreatesMemberTypeAssign>(WeaverEdgeConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesFactor CreatesFactorList {
			get { return NewEdge<MemberCreatesFactor>(WeaverEdgeConn.OutToZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserDefinesMember InUserDefines {
			get { return NewEdge<UserDefinesMember>(WeaverEdgeConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public partial class MemberTypeAssign : VertexForAction {
	
		[WeaverItemProperty]
		public virtual long MemberTypeAssignId { get; set; }

		[WeaverItemProperty]
		public virtual byte MemberTypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberTypeAssign() : base(VertexFabType.MemberTypeAssign) {}


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
			get { return NewEdge<MemberHasMemberTypeAssign>(WeaverEdgeConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasHistoricMemberTypeAssign InMemberHasHistoric {
			get { return NewEdge<MemberHasHistoricMemberTypeAssign>(WeaverEdgeConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesMemberTypeAssign InMemberCreates {
			get { return NewEdge<MemberCreatesMemberTypeAssign>(WeaverEdgeConn.InFromOne); }
		}

	}

	/*================================================================================================*/
	public partial class Url : Artifact {
	
		[WeaverItemProperty]
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		public virtual string AbsoluteUrl { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Url() : base(VertexFabType.Url) {}


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
		public virtual string Name { get; set; }

		[WeaverItemProperty]
		public virtual string Password { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public User() : base(VertexFabType.User) {}


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
			get { return NewEdge<UserUsesEmail>(WeaverEdgeConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserDefinesMember DefinesMemberList {
			get { return NewEdge<UserDefinesMember>(WeaverEdgeConn.OutToOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesUser InOauthAccessListUses {
			get { return NewEdge<OauthAccessUsesUser>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesUser InOauthGrantListUses {
			get { return NewEdge<OauthGrantUsesUser>(WeaverEdgeConn.InFromZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesUser InOauthScopeListUses {
			get { return NewEdge<OauthScopeUsesUser>(WeaverEdgeConn.InFromZeroOrMore); }
		}

	}

	/*================================================================================================*/
	public partial class Factor : Vertex {
	
		[WeaverItemProperty]
		public virtual long FactorId { get; set; }

		[WeaverItemProperty]
		public virtual byte FactorAssertionId { get; set; }

		[WeaverItemProperty]
		public virtual bool IsDefining { get; set; }

		[WeaverItemProperty]
		public virtual long Created { get; set; }

		[WeaverItemProperty]
		public virtual long? Deleted { get; set; }

		[WeaverItemProperty]
		public virtual long? Completed { get; set; }

		[WeaverItemProperty]
		public virtual string Note { get; set; }

		[WeaverItemProperty]
		public virtual byte? Descriptor_TypeId { get; set; }

		[WeaverItemProperty]
		public virtual byte? Director_TypeId { get; set; }

		[WeaverItemProperty]
		public virtual byte? Director_PrimaryActionId { get; set; }

		[WeaverItemProperty]
		public virtual byte? Director_RelatedActionId { get; set; }

		[WeaverItemProperty]
		public virtual byte? Eventor_TypeId { get; set; }

		[WeaverItemProperty]
		public virtual byte? Eventor_PrecisionId { get; set; }

		[WeaverItemProperty]
		public virtual long? Eventor_DateTime { get; set; }

		[WeaverItemProperty]
		public virtual byte? Identor_TypeId { get; set; }

		[WeaverItemProperty]
		public virtual string Identor_Value { get; set; }

		[WeaverItemProperty]
		public virtual byte? Locator_TypeId { get; set; }

		[WeaverItemProperty]
		public virtual double? Locator_ValueX { get; set; }

		[WeaverItemProperty]
		public virtual double? Locator_ValueY { get; set; }

		[WeaverItemProperty]
		public virtual double? Locator_ValueZ { get; set; }

		[WeaverItemProperty]
		public virtual byte? Vector_TypeId { get; set; }

		[WeaverItemProperty]
		public virtual byte? Vector_UnitId { get; set; }

		[WeaverItemProperty]
		public virtual byte? Vector_UnitPrefixId { get; set; }

		[WeaverItemProperty]
		public virtual long? Vector_Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Factor() : base(VertexFabType.Factor) {}


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
			get { return NewEdge<MemberCreatesFactor>(WeaverEdgeConn.InFromOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesPrimaryArtifact UsesPrimaryArtifact {
			get { return NewEdge<FactorUsesPrimaryArtifact>(WeaverEdgeConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesRelatedArtifact UsesRelatedArtifact {
			get { return NewEdge<FactorUsesRelatedArtifact>(WeaverEdgeConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesPrimaryWithArtifact DescriptorRefinesPrimaryWithArtifact {
			get { return NewEdge<FactorDescriptorRefinesPrimaryWithArtifact>(WeaverEdgeConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesRelatedWithArtifact DescriptorRefinesRelatedWithArtifact {
			get { return NewEdge<FactorDescriptorRefinesRelatedWithArtifact>(WeaverEdgeConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesTypeWithArtifact DescriptorRefinesTypeWithArtifact {
			get { return NewEdge<FactorDescriptorRefinesTypeWithArtifact>(WeaverEdgeConn.OutToZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorVectorUsesAxisArtifact VectorUsesAxisArtifact {
			get { return NewEdge<FactorVectorUsesAxisArtifact>(WeaverEdgeConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public partial class OauthAccess : Vertex {
	
		[WeaverItemProperty]
		public virtual long OauthAccessId { get; set; }

		[WeaverItemProperty]
		public virtual string Token { get; set; }

		[WeaverItemProperty]
		public virtual string Refresh { get; set; }

		[WeaverItemProperty]
		public virtual long Expires { get; set; }

		[WeaverItemProperty]
		public virtual bool IsClientOnly { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccess() : base(VertexFabType.OauthAccess) {}


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
			get { return NewEdge<OauthAccessUsesApp>(WeaverEdgeConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesUser UsesUser {
			get { return NewEdge<OauthAccessUsesUser>(WeaverEdgeConn.OutToZeroOrOne); }
		}

	}

	/*================================================================================================*/
	public partial class OauthDomain : Vertex {
	
		[WeaverItemProperty]
		public virtual long OauthDomainId { get; set; }

		[WeaverItemProperty]
		public virtual string Domain { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomain() : base(VertexFabType.OauthDomain) {}


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
			get { return NewEdge<OauthDomainUsesApp>(WeaverEdgeConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class OauthGrant : Vertex {
	
		[WeaverItemProperty]
		public virtual long OauthGrantId { get; set; }

		[WeaverItemProperty]
		public virtual string RedirectUri { get; set; }

		[WeaverItemProperty]
		public virtual string Code { get; set; }

		[WeaverItemProperty]
		public virtual long Expires { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrant() : base(VertexFabType.OauthGrant) {}


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
			get { return NewEdge<OauthGrantUsesApp>(WeaverEdgeConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesUser UsesUser {
			get { return NewEdge<OauthGrantUsesUser>(WeaverEdgeConn.OutToOne); }
		}

	}

	/*================================================================================================*/
	public partial class OauthScope : Vertex {
	
		[WeaverItemProperty]
		public virtual long OauthScopeId { get; set; }

		[WeaverItemProperty]
		public virtual bool Allow { get; set; }

		[WeaverItemProperty]
		public virtual long Created { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthScope() : base(VertexFabType.OauthScope) {}


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
			get { return NewEdge<OauthScopeUsesApp>(WeaverEdgeConn.OutToOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesUser UsesUser {
			get { return NewEdge<OauthScopeUsesUser>(WeaverEdgeConn.OutToOne); }
		}

	}

}
