
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Weaver.Core.Elements;
using Weaver.Titan.Elements;

namespace Fabric.Domain {


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class App : Artifact {

		[WeaverTitanProperty("p_na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("p_nk", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string NameKey { get; set; }
		
		[WeaverTitanProperty("p_se", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Secret { get; set; }
		
		[WeaverTitanProperty("p_od", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string OauthDomains { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public App() {
			VertexType = (byte)Enums.VertexType.Id.App;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual AppDefinesMember DefinesMembers {
			get { return NewEdge<AppDefinesMember>(WeaverEdgeConn.OutZeroOrMore); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Name = TryGetString(pData, "p_na");
			NameKey = TryGetString(pData, "p_nk");
			Secret = TryGetString(pData, "p_se");
			OauthDomains = TryGetString(pData, "p_od");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Artifact : Vertex {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Artifact() {
			VertexType = (byte)Enums.VertexType.Id.Artifact;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ArtifactCreatedByMember CreatedByMember {
			get { return NewEdge<ArtifactCreatedByMember>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ArtifactUsedAsPrimaryByFactor UsedAsPrimaryByFactors {
			get { return NewEdge<ArtifactUsedAsPrimaryByFactor>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ArtifactUsedAsRelatedByFactor UsedAsRelatedByFactors {
			get { return NewEdge<ArtifactUsedAsRelatedByFactor>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual ArtifactUsesEmail UsesEmails {
			get { return NewEdge<ArtifactUsesEmail>(WeaverEdgeConn.OutZeroOrMore); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Class : Artifact {

		[WeaverTitanProperty("c_na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("c_nk", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string NameKey { get; set; }
		
		[WeaverTitanProperty("c_di", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Disamb { get; set; }
		
		[WeaverTitanProperty("c_no", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Note { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Class() {
			VertexType = (byte)Enums.VertexType.Id.Class;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Name = TryGetString(pData, "c_na");
			NameKey = TryGetString(pData, "c_nk");
			Disamb = TryGetString(pData, "c_di");
			Note = TryGetString(pData, "c_no");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Email : Vertex {

		[WeaverTitanProperty("e_ad", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string Address { get; set; }
		
		[WeaverTitanProperty("e_co", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Code { get; set; }
		
		[WeaverTitanProperty("e_ve", TitanIndex=false, TitanElasticIndex=false)]
		public virtual bool Verified { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Email() {
			VertexType = (byte)Enums.VertexType.Id.Email;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual EmailUsedByArtifact UsedByArtifact {
			get { return NewEdge<EmailUsedByArtifact>(WeaverEdgeConn.OutOne); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Address = TryGetString(pData, "e_ad");
			Code = TryGetString(pData, "e_co");
			Verified = TryGetBool(pData, "e_ve");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Factor : Vertex {

		[WeaverTitanProperty("f_at", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte AssertionType { get; set; }
		
		[WeaverTitanProperty("f_de", TitanIndex=false, TitanElasticIndex=false)]
		public virtual bool IsDefining { get; set; }
		
		[WeaverTitanProperty("f_no", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Note { get; set; }
		
		[WeaverTitanProperty("f_det", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte DescriptorType { get; set; }
		
		[WeaverTitanProperty("f_dit", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? DirectorType { get; set; }
		
		[WeaverTitanProperty("f_dip", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? DirectorPrimaryAction { get; set; }
		
		[WeaverTitanProperty("f_dir", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? DirectorRelatedAction { get; set; }
		
		[WeaverTitanProperty("f_evt", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? EventorType { get; set; }
		
		[WeaverTitanProperty("f_evd", TitanIndex=false, TitanElasticIndex=false)]
		public virtual long? EventorDateTime { get; set; }
		
		[WeaverTitanProperty("f_idt", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? IdentorType { get; set; }
		
		[WeaverTitanProperty("f_idv", TitanIndex=true, TitanElasticIndex=true)]
		public virtual string IdentorValue { get; set; }
		
		[WeaverTitanProperty("f_lot", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? LocatorType { get; set; }
		
		[WeaverTitanProperty("f_lox", TitanIndex=false, TitanElasticIndex=false)]
		public virtual double? LocatorValueX { get; set; }
		
		[WeaverTitanProperty("f_loy", TitanIndex=false, TitanElasticIndex=false)]
		public virtual double? LocatorValueY { get; set; }
		
		[WeaverTitanProperty("f_loz", TitanIndex=false, TitanElasticIndex=false)]
		public virtual double? LocatorValueZ { get; set; }
		
		[WeaverTitanProperty("f_vet", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? VectorType { get; set; }
		
		[WeaverTitanProperty("f_veu", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? VectorUnit { get; set; }
		
		[WeaverTitanProperty("f_vep", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? VectorUnitPrefix { get; set; }
		
		[WeaverTitanProperty("f_vev", TitanIndex=false, TitanElasticIndex=false)]
		public virtual long? VectorValue { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Factor() {
			VertexType = (byte)Enums.VertexType.Id.Factor;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorCreatedByMember CreatedByMember {
			get { return NewEdge<FactorCreatedByMember>(WeaverEdgeConn.OutOne); }
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
		public virtual FactorUsesPrimaryArtifact UsesPrimaryArtifact {
			get { return NewEdge<FactorUsesPrimaryArtifact>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorUsesRelatedArtifact UsesRelatedArtifact {
			get { return NewEdge<FactorUsesRelatedArtifact>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorVectorUsesAxisArtifact VectorUsesAxisArtifact {
			get { return NewEdge<FactorVectorUsesAxisArtifact>(WeaverEdgeConn.OutZeroOrOne); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			AssertionType = TryGetByte(pData, "f_at");
			IsDefining = TryGetBool(pData, "f_de");
			Note = TryGetString(pData, "f_no");
			DescriptorType = TryGetByte(pData, "f_det");
			DirectorType = TryGetNullableByte(pData, "f_dit");
			DirectorPrimaryAction = TryGetNullableByte(pData, "f_dip");
			DirectorRelatedAction = TryGetNullableByte(pData, "f_dir");
			EventorType = TryGetNullableByte(pData, "f_evt");
			EventorDateTime = TryGetNullableLong(pData, "f_evd");
			IdentorType = TryGetNullableByte(pData, "f_idt");
			IdentorValue = TryGetString(pData, "f_idv");
			LocatorType = TryGetNullableByte(pData, "f_lot");
			LocatorValueX = TryGetNullableDouble(pData, "f_lox");
			LocatorValueY = TryGetNullableDouble(pData, "f_loy");
			LocatorValueZ = TryGetNullableDouble(pData, "f_loz");
			VectorType = TryGetNullableByte(pData, "f_vet");
			VectorUnit = TryGetNullableByte(pData, "f_veu");
			VectorUnitPrefix = TryGetNullableByte(pData, "f_vep");
			VectorValue = TryGetNullableLong(pData, "f_vev");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Instance : Artifact {

		[WeaverTitanProperty("i_na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("i_di", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Disamb { get; set; }
		
		[WeaverTitanProperty("i_no", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Note { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Instance() {
			VertexType = (byte)Enums.VertexType.Id.Instance;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Name = TryGetString(pData, "i_na");
			Disamb = TryGetString(pData, "i_di");
			Note = TryGetString(pData, "i_no");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Member : Vertex {

		[WeaverTitanProperty("m_mt", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte MemberType { get; set; }
		
		[WeaverTitanProperty("m_osa", TitanIndex=false, TitanElasticIndex=false)]
		public virtual bool? OauthScopeAllow { get; set; }
		
		[WeaverTitanProperty("m_ogr", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string OauthGrantRedirectUri { get; set; }
		
		[WeaverTitanProperty("m_ogc", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string OauthGrantCode { get; set; }
		
		[WeaverTitanProperty("m_oge", TitanIndex=false, TitanElasticIndex=false)]
		public virtual long? OauthGrantExpires { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Member() {
			VertexType = (byte)Enums.VertexType.Id.Member;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberAuthenticatedByOauthAccess AuthenticatedByOauthAccesses {
			get { return NewEdge<MemberAuthenticatedByOauthAccess>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesArtifact CreatesArtifacts {
			get { return NewEdge<MemberCreatesArtifact>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesFactor CreatesFactors {
			get { return NewEdge<MemberCreatesFactor>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberDefinedByApp DefinedByApp {
			get { return NewEdge<MemberDefinedByApp>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberDefinedByUser DefinedByUser {
			get { return NewEdge<MemberDefinedByUser>(WeaverEdgeConn.OutOne); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			MemberType = TryGetByte(pData, "m_mt");
			OauthScopeAllow = TryGetNullableBool(pData, "m_osa");
			OauthGrantRedirectUri = TryGetString(pData, "m_ogr");
			OauthGrantCode = TryGetString(pData, "m_ogc");
			OauthGrantExpires = TryGetNullableLong(pData, "m_oge");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class OauthAccess : Vertex {

		[WeaverTitanProperty("oa_to", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string Token { get; set; }
		
		[WeaverTitanProperty("oa_re", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string Refresh { get; set; }
		
		[WeaverTitanProperty("oa_ex", TitanIndex=false, TitanElasticIndex=false)]
		public virtual long Expires { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccess() {
			VertexType = (byte)Enums.VertexType.Id.OauthAccess;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual OauthAccessAuthenticatesMember AuthenticatesMember {
			get { return NewEdge<OauthAccessAuthenticatesMember>(WeaverEdgeConn.OutOne); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Token = TryGetString(pData, "oa_to");
			Refresh = TryGetString(pData, "oa_re");
			Expires = TryGetLong(pData, "oa_ex");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Url : Artifact {

		[WeaverTitanProperty("r_na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("r_fp", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string FullPath { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Url() {
			VertexType = (byte)Enums.VertexType.Id.Url;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Name = TryGetString(pData, "r_na");
			FullPath = TryGetString(pData, "r_fp");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class User : Artifact {

		[WeaverTitanProperty("u_na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("u_nk", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string NameKey { get; set; }
		
		[WeaverTitanProperty("u_pa", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Password { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public User() {
			VertexType = (byte)Enums.VertexType.Id.User;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual UserDefinesMember DefinesMembers {
			get { return NewEdge<UserDefinesMember>(WeaverEdgeConn.OutZeroOrMore); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Name = TryGetString(pData, "u_na");
			NameKey = TryGetString(pData, "u_nk");
			Password = TryGetString(pData, "u_pa");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Vertex : VertexBase, IVertex {

		[WeaverTitanProperty("v_id", TitanIndex=true, TitanElasticIndex=false)]
		public virtual long VertexId { get; set; }
		
		[WeaverTitanProperty("v_ts", TitanIndex=false, TitanElasticIndex=true)]
		public virtual long Timestamp { get; set; }
		
		[WeaverTitanProperty("v_t", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte VertexType { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Vertex() {
			VertexType = (byte)Enums.VertexType.Id.Vertex;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			VertexId = TryGetLong(pData, "v_id");
			Timestamp = TryGetLong(pData, "v_ts");
			VertexType = TryGetByte(pData, "v_t");
		}

	}

}