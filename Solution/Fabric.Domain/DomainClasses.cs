﻿// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/23/2013 10:41:10 AM

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Weaver.Core.Elements;
using Weaver.Titan.Elements;

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
	[WeaverTitanEdge("Ap-U-E", WeaverEdgeConn.OutOne, typeof(App),
		WeaverEdgeConn.InZeroOrMore, typeof(Email))]
	public class AppUsesEmail : Edge<App, Uses, Email>, IItemWithId {
			
		public virtual App FromApp { get { return OutVertex; } }
		public virtual Email ToEmail { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("Ap-D-M", WeaverEdgeConn.OutOneOrMore, typeof(App),
		WeaverEdgeConn.InOne, typeof(Member))]
	public class AppDefinesMember : Edge<App, Defines, Member>, IItemWithId {
			
		public virtual App FromApp { get { return OutVertex; } }
		public virtual Member ToMember { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("M-H-MTA", WeaverEdgeConn.OutOne, typeof(Member),
		WeaverEdgeConn.InOne, typeof(MemberTypeAssign))]
	public class MemberHasMemberTypeAssign : Edge<Member, Has, MemberTypeAssign>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("M-HH-MTA", WeaverEdgeConn.OutZeroOrMore, typeof(Member),
		WeaverEdgeConn.InOne, typeof(MemberTypeAssign))]
	public class MemberHasHistoricMemberTypeAssign : Edge<Member, HasHistoric, MemberTypeAssign>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("M-C-A", WeaverEdgeConn.OutZeroOrMore, typeof(Member),
		WeaverEdgeConn.InOne, typeof(Artifact))]
	public class MemberCreatesArtifact : Edge<Member, Creates, Artifact>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("M-C-MTA", WeaverEdgeConn.OutZeroOrMore, typeof(Member),
		WeaverEdgeConn.InOne, typeof(MemberTypeAssign))]
	public class MemberCreatesMemberTypeAssign : Edge<Member, Creates, MemberTypeAssign>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual MemberTypeAssign ToMemberTypeAssign { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("M-C-F", WeaverEdgeConn.OutZeroOrMore, typeof(Member),
		WeaverEdgeConn.InOne, typeof(Factor))]
	public class MemberCreatesFactor : Edge<Member, Creates, Factor>, IItemWithId {
			
		public virtual Member FromMember { get { return OutVertex; } }
		public virtual Factor ToFactor { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("U-U-E", WeaverEdgeConn.OutOne, typeof(User),
		WeaverEdgeConn.InOneOrMore, typeof(Email))]
	public class UserUsesEmail : Edge<User, Uses, Email>, IItemWithId {
			
		public virtual User FromUser { get { return OutVertex; } }
		public virtual Email ToEmail { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("U-D-M", WeaverEdgeConn.OutOneOrMore, typeof(User),
		WeaverEdgeConn.InOne, typeof(Member))]
	public class UserDefinesMember : Edge<User, Defines, Member>, IItemWithId {
			
		public virtual User FromUser { get { return OutVertex; } }
		public virtual Member ToMember { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("F-UP-A", WeaverEdgeConn.OutOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorUsesPrimaryArtifact : Edge<Factor, UsesPrimary, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("F-UR-A", WeaverEdgeConn.OutOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorUsesRelatedArtifact : Edge<Factor, UsesRelated, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("F-DRP-A", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorDescriptorRefinesPrimaryWithArtifact : Edge<Factor, DescriptorRefinesPrimaryWith, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("F-DRR-A", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorDescriptorRefinesRelatedWithArtifact : Edge<Factor, DescriptorRefinesRelatedWith, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("F-DRT-A", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorDescriptorRefinesTypeWithArtifact : Edge<Factor, DescriptorRefinesTypeWith, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("F-VUA-A", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorVectorUsesAxisArtifact : Edge<Factor, VectorUsesAxis, Artifact>, IItemWithId {
			
		public virtual Factor FromFactor { get { return OutVertex; } }
		public virtual Artifact ToArtifact { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("OA-U-Ap", WeaverEdgeConn.OutOne, typeof(OauthAccess),
		WeaverEdgeConn.InZeroOrMore, typeof(App))]
	public class OauthAccessUsesApp : Edge<OauthAccess, Uses, App>, IItemWithId {
			
		public virtual OauthAccess FromOauthAccess { get { return OutVertex; } }
		public virtual App ToApp { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("OA-U-U", WeaverEdgeConn.OutZeroOrOne, typeof(OauthAccess),
		WeaverEdgeConn.InZeroOrMore, typeof(User))]
	public class OauthAccessUsesUser : Edge<OauthAccess, Uses, User>, IItemWithId {
			
		public virtual OauthAccess FromOauthAccess { get { return OutVertex; } }
		public virtual User ToUser { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("OD-U-Ap", WeaverEdgeConn.OutOne, typeof(OauthDomain),
		WeaverEdgeConn.InZeroOrMore, typeof(App))]
	public class OauthDomainUsesApp : Edge<OauthDomain, Uses, App>, IItemWithId {
			
		public virtual OauthDomain FromOauthDomain { get { return OutVertex; } }
		public virtual App ToApp { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("OG-U-Ap", WeaverEdgeConn.OutOne, typeof(OauthGrant),
		WeaverEdgeConn.InZeroOrMore, typeof(App))]
	public class OauthGrantUsesApp : Edge<OauthGrant, Uses, App>, IItemWithId {
			
		public virtual OauthGrant FromOauthGrant { get { return OutVertex; } }
		public virtual App ToApp { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("OG-U-U", WeaverEdgeConn.OutOne, typeof(OauthGrant),
		WeaverEdgeConn.InZeroOrMore, typeof(User))]
	public class OauthGrantUsesUser : Edge<OauthGrant, Uses, User>, IItemWithId {
			
		public virtual OauthGrant FromOauthGrant { get { return OutVertex; } }
		public virtual User ToUser { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("OS-U-Ap", WeaverEdgeConn.OutOne, typeof(OauthScope),
		WeaverEdgeConn.InZeroOrMore, typeof(App))]
	public class OauthScopeUsesApp : Edge<OauthScope, Uses, App>, IItemWithId {
			
		public virtual OauthScope FromOauthScope { get { return OutVertex; } }
		public virtual App ToApp { get { return InVertex; } }

	}
	
	/*================================================================================================*/
	[WeaverTitanEdge("OS-U-U", WeaverEdgeConn.OutOne, typeof(OauthScope),
		WeaverEdgeConn.InZeroOrMore, typeof(User))]
	public class OauthScopeUsesUser : Edge<OauthScope, Uses, User>, IItemWithId {
			
		public virtual OauthScope FromOauthScope { get { return OutVertex; } }
		public virtual User ToUser { get { return InVertex; } }

	}
	


	/* Vertices */


	/*================================================================================================*/
	public abstract partial class Vertex {
	
		[WeaverTitanProperty("N_FT")]
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
	
		[WeaverTitanProperty("NA_Pe")]
		public virtual long Performed { get; set; }

		[WeaverTitanProperty("NA_No")]
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
	
		[WeaverTitanProperty("A_AId")]
		public virtual long ArtifactId { get; set; }

		[WeaverTitanProperty("A_Cr")]
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
			get { return NewEdge<MemberCreatesArtifact>(WeaverEdgeConn.InOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesPrimaryArtifact InFactorListUsesPrimary {
			get { return NewEdge<FactorUsesPrimaryArtifact>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesRelatedArtifact InFactorListUsesRelated {
			get { return NewEdge<FactorUsesRelatedArtifact>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesPrimaryWithArtifact InFactorListDescriptorRefinesPrimaryWith {
			get { return NewEdge<FactorDescriptorRefinesPrimaryWithArtifact>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesRelatedWithArtifact InFactorListDescriptorRefinesRelatedWith {
			get { return NewEdge<FactorDescriptorRefinesRelatedWithArtifact>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesTypeWithArtifact InFactorListDescriptorRefinesTypeWith {
			get { return NewEdge<FactorDescriptorRefinesTypeWithArtifact>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorVectorUsesAxisArtifact InFactorListVectorUsesAxis {
			get { return NewEdge<FactorVectorUsesAxisArtifact>(WeaverEdgeConn.InZeroOrMore); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class App : Artifact {
	
		[WeaverTitanProperty("Ap_Na")]
		public virtual string Name { get; set; }

		[WeaverTitanProperty("Ap_NK")]
		public virtual string NameKey { get; set; }

		[WeaverTitanProperty("Ap_Se")]
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
			
			if ( pData.ContainsKey("Ap_NK") ) {
				NameKey = pData["Ap_NK"];
			}
			
			if ( pData.ContainsKey("Ap_Se") ) {
				Secret = pData["Ap_Se"];
			}

		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppUsesEmail UsesEmail {
			get { return NewEdge<AppUsesEmail>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppDefinesMember DefinesMemberList {
			get { return NewEdge<AppDefinesMember>(WeaverEdgeConn.OutOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesApp InOauthAccessListUses {
			get { return NewEdge<OauthAccessUsesApp>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthDomainUsesApp InOauthDomainListUses {
			get { return NewEdge<OauthDomainUsesApp>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesApp InOauthGrantListUses {
			get { return NewEdge<OauthGrantUsesApp>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesApp InOauthScopeListUses {
			get { return NewEdge<OauthScopeUsesApp>(WeaverEdgeConn.InZeroOrMore); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class Class : Artifact {
	
		[WeaverTitanProperty("Cl_Na")]
		public virtual string Name { get; set; }

		[WeaverTitanProperty("Cl_NK")]
		public virtual string NameKey { get; set; }

		[WeaverTitanProperty("Cl_Di")]
		public virtual string Disamb { get; set; }

		[WeaverTitanProperty("Cl_No")]
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
			
			if ( pData.ContainsKey("Cl_NK") ) {
				NameKey = pData["Cl_NK"];
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
	[WeaverTitanVertex]
	public partial class Email : Vertex {
	
		[WeaverTitanProperty("E_Id")]
		public virtual long EmailId { get; set; }

		[WeaverTitanProperty("E_Ad")]
		public virtual string Address { get; set; }

		[WeaverTitanProperty("E_Co")]
		public virtual string Code { get; set; }

		[WeaverTitanProperty("E_Cr")]
		public virtual long Created { get; set; }

		[WeaverTitanProperty("E_Ve")]
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
			get { return NewEdge<AppUsesEmail>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserUsesEmail InUserListUses {
			get { return NewEdge<UserUsesEmail>(WeaverEdgeConn.InOneOrMore); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class Instance : Artifact {
	
		[WeaverTitanProperty("In_Na")]
		public virtual string Name { get; set; }

		[WeaverTitanProperty("In_Di")]
		public virtual string Disamb { get; set; }

		[WeaverTitanProperty("In_No")]
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
	[WeaverTitanVertex]
	public partial class Member : Vertex {
	
		[WeaverTitanProperty("M_Id")]
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
			get { return NewEdge<AppDefinesMember>(WeaverEdgeConn.InOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasMemberTypeAssign HasMemberTypeAssign {
			get { return NewEdge<MemberHasMemberTypeAssign>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasHistoricMemberTypeAssign HasHistoricMemberTypeAssignList {
			get { return NewEdge<MemberHasHistoricMemberTypeAssign>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesArtifact CreatesArtifactList {
			get { return NewEdge<MemberCreatesArtifact>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesMemberTypeAssign CreatesMemberTypeAssignList {
			get { return NewEdge<MemberCreatesMemberTypeAssign>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesFactor CreatesFactorList {
			get { return NewEdge<MemberCreatesFactor>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserDefinesMember InUserDefines {
			get { return NewEdge<UserDefinesMember>(WeaverEdgeConn.InOne); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class MemberTypeAssign : VertexForAction {
	
		[WeaverTitanProperty("MTA_Id")]
		public virtual long MemberTypeAssignId { get; set; }

		[WeaverTitanProperty("MTA_Mt")]
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
			get { return NewEdge<MemberHasMemberTypeAssign>(WeaverEdgeConn.InOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberHasHistoricMemberTypeAssign InMemberHasHistoric {
			get { return NewEdge<MemberHasHistoricMemberTypeAssign>(WeaverEdgeConn.InOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesMemberTypeAssign InMemberCreates {
			get { return NewEdge<MemberCreatesMemberTypeAssign>(WeaverEdgeConn.InOne); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class Url : Artifact {
	
		[WeaverTitanProperty("Ur_Na")]
		public virtual string Name { get; set; }

		[WeaverTitanProperty("Ur_Ab")]
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
	[WeaverTitanVertex]
	public partial class User : Artifact {
	
		[WeaverTitanProperty("U_Na")]
		public virtual string Name { get; set; }

		[WeaverTitanProperty("U_NK")]
		public virtual string NameKey { get; set; }

		[WeaverTitanProperty("U_Pa")]
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
			
			if ( pData.ContainsKey("U_NK") ) {
				NameKey = pData["U_NK"];
			}
			
			if ( pData.ContainsKey("U_Pa") ) {
				Password = pData["U_Pa"];
			}

		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserUsesEmail UsesEmail {
			get { return NewEdge<UserUsesEmail>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserDefinesMember DefinesMemberList {
			get { return NewEdge<UserDefinesMember>(WeaverEdgeConn.OutOneOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesUser InOauthAccessListUses {
			get { return NewEdge<OauthAccessUsesUser>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesUser InOauthGrantListUses {
			get { return NewEdge<OauthGrantUsesUser>(WeaverEdgeConn.InZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesUser InOauthScopeListUses {
			get { return NewEdge<OauthScopeUsesUser>(WeaverEdgeConn.InZeroOrMore); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class Factor : Vertex {
	
		[WeaverTitanProperty("F_Id")]
		public virtual long FactorId { get; set; }

		[WeaverTitanProperty("F_Fa")]
		public virtual byte FactorAssertionId { get; set; }

		[WeaverTitanProperty("F_Df")]
		public virtual bool IsDefining { get; set; }

		[WeaverTitanProperty("F_Cr")]
		public virtual long Created { get; set; }

		[WeaverTitanProperty("F_Dl")]
		public virtual long? Deleted { get; set; }

		[WeaverTitanProperty("F_Co")]
		public virtual long? Completed { get; set; }

		[WeaverTitanProperty("F_No")]
		public virtual string Note { get; set; }

		[WeaverTitanProperty("F_DeT")]
		public virtual byte? Descriptor_TypeId { get; set; }

		[WeaverTitanProperty("F_DiT")]
		public virtual byte? Director_TypeId { get; set; }

		[WeaverTitanProperty("F_DiP")]
		public virtual byte? Director_PrimaryActionId { get; set; }

		[WeaverTitanProperty("F_DiR")]
		public virtual byte? Director_RelatedActionId { get; set; }

		[WeaverTitanProperty("F_EvT")]
		public virtual byte? Eventor_TypeId { get; set; }

		[WeaverTitanProperty("F_EvP")]
		public virtual byte? Eventor_PrecisionId { get; set; }

		[WeaverTitanProperty("F_EvD")]
		public virtual long? Eventor_DateTime { get; set; }

		[WeaverTitanProperty("F_IdT")]
		public virtual byte? Identor_TypeId { get; set; }

		[WeaverTitanProperty("F_IdV")]
		public virtual string Identor_Value { get; set; }

		[WeaverTitanProperty("F_LoT")]
		public virtual byte? Locator_TypeId { get; set; }

		[WeaverTitanProperty("F_LoX")]
		public virtual double? Locator_ValueX { get; set; }

		[WeaverTitanProperty("F_LoY")]
		public virtual double? Locator_ValueY { get; set; }

		[WeaverTitanProperty("F_LoZ")]
		public virtual double? Locator_ValueZ { get; set; }

		[WeaverTitanProperty("F_VeT")]
		public virtual byte? Vector_TypeId { get; set; }

		[WeaverTitanProperty("F_VeU")]
		public virtual byte? Vector_UnitId { get; set; }

		[WeaverTitanProperty("F_VeP")]
		public virtual byte? Vector_UnitPrefixId { get; set; }

		[WeaverTitanProperty("F_VeV")]
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
			get { return NewEdge<MemberCreatesFactor>(WeaverEdgeConn.InOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesPrimaryArtifact UsesPrimaryArtifact {
			get { return NewEdge<FactorUsesPrimaryArtifact>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesRelatedArtifact UsesRelatedArtifact {
			get { return NewEdge<FactorUsesRelatedArtifact>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesPrimaryWithArtifact DescriptorRefinesPrimaryWithArtifact {
			get { return NewEdge<FactorDescriptorRefinesPrimaryWithArtifact>(WeaverEdgeConn.OutZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesRelatedWithArtifact DescriptorRefinesRelatedWithArtifact {
			get { return NewEdge<FactorDescriptorRefinesRelatedWithArtifact>(WeaverEdgeConn.OutZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorRefinesTypeWithArtifact DescriptorRefinesTypeWithArtifact {
			get { return NewEdge<FactorDescriptorRefinesTypeWithArtifact>(WeaverEdgeConn.OutZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorVectorUsesAxisArtifact VectorUsesAxisArtifact {
			get { return NewEdge<FactorVectorUsesAxisArtifact>(WeaverEdgeConn.OutZeroOrOne); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class OauthAccess : Vertex {
	
		[WeaverTitanProperty("OA_Id")]
		public virtual long OauthAccessId { get; set; }

		[WeaverTitanProperty("OA_To")]
		public virtual string Token { get; set; }

		[WeaverTitanProperty("OA_Re")]
		public virtual string Refresh { get; set; }

		[WeaverTitanProperty("OA_Ex")]
		public virtual long Expires { get; set; }

		[WeaverTitanProperty("OA_CO")]
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
			get { return NewEdge<OauthAccessUsesApp>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessUsesUser UsesUser {
			get { return NewEdge<OauthAccessUsesUser>(WeaverEdgeConn.OutZeroOrOne); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class OauthDomain : Vertex {
	
		[WeaverTitanProperty("OD_Id")]
		public virtual long OauthDomainId { get; set; }

		[WeaverTitanProperty("OD_Do")]
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
			get { return NewEdge<OauthDomainUsesApp>(WeaverEdgeConn.OutOne); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class OauthGrant : Vertex {
	
		[WeaverTitanProperty("OG_Id")]
		public virtual long OauthGrantId { get; set; }

		[WeaverTitanProperty("OG_Re")]
		public virtual string RedirectUri { get; set; }

		[WeaverTitanProperty("OG_Co")]
		public virtual string Code { get; set; }

		[WeaverTitanProperty("OG_Ex")]
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
			get { return NewEdge<OauthGrantUsesApp>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthGrantUsesUser UsesUser {
			get { return NewEdge<OauthGrantUsesUser>(WeaverEdgeConn.OutOne); }
		}

	}

	/*================================================================================================*/
	[WeaverTitanVertex]
	public partial class OauthScope : Vertex {
	
		[WeaverTitanProperty("OS_Id")]
		public virtual long OauthScopeId { get; set; }

		[WeaverTitanProperty("OS_Al")]
		public virtual bool Allow { get; set; }

		[WeaverTitanProperty("OS_Cr")]
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
			get { return NewEdge<OauthScopeUsesApp>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthScopeUsesUser UsesUser {
			get { return NewEdge<OauthScopeUsesUser>(WeaverEdgeConn.OutOne); }
		}

	}

}
