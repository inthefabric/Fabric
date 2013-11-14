
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.New.Domain.Enums;
using Weaver.Core.Elements;
using Weaver.Titan.Elements;

namespace Fabric.New.Domain {


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class App : Artifact {

		[WeaverTitanProperty("p.na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("p.nk", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string NameKey { get; set; }
		
		[WeaverTitanProperty("p.se", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Secret { get; set; }
		
		[WeaverTitanProperty("p.od", TitanIndex=false, TitanElasticIndex=false)]
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
			Name = TryGetString(pData, "p.na");
			NameKey = TryGetString(pData, "p.nk");
			Secret = TryGetString(pData, "p.se");
			OauthDomains = TryGetString(pData, "p.od");
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

		[WeaverTitanProperty("c.na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("c.nk", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string NameKey { get; set; }
		
		[WeaverTitanProperty("c.di", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Disamb { get; set; }
		
		[WeaverTitanProperty("c.no", TitanIndex=false, TitanElasticIndex=false)]
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
			Name = TryGetString(pData, "c.na");
			NameKey = TryGetString(pData, "c.nk");
			Disamb = TryGetString(pData, "c.di");
			Note = TryGetString(pData, "c.no");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Email : Vertex {

		[WeaverTitanProperty("e.ad", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string Address { get; set; }
		
		[WeaverTitanProperty("e.co", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Code { get; set; }
		
		[WeaverTitanProperty("e.ve", TitanIndex=false, TitanElasticIndex=false)]
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
			Address = TryGetString(pData, "e.ad");
			Code = TryGetString(pData, "e.co");
			Verified = TryGetBool(pData, "e.ve");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Factor : Vertex {

		[WeaverTitanProperty("f.at", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte AssertionType { get; set; }
		
		[WeaverTitanProperty("f.de", TitanIndex=false, TitanElasticIndex=false)]
		public virtual bool IsDefining { get; set; }
		
		[WeaverTitanProperty("f.no", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Note { get; set; }
		
		[WeaverTitanProperty("f.det", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte DescriptorType { get; set; }
		
		[WeaverTitanProperty("f.dit", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? DirectorType { get; set; }
		
		[WeaverTitanProperty("f.dip", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? DirectorPrimaryAction { get; set; }
		
		[WeaverTitanProperty("f.dir", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? DirectorRelatedAction { get; set; }
		
		[WeaverTitanProperty("f.evt", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? EventorType { get; set; }
		
		[WeaverTitanProperty("f.evd", TitanIndex=false, TitanElasticIndex=false)]
		public virtual long? EventorDateTime { get; set; }
		
		[WeaverTitanProperty("f.idt", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? IdentorType { get; set; }
		
		[WeaverTitanProperty("f.idv", TitanIndex=true, TitanElasticIndex=true)]
		public virtual string IdentorValue { get; set; }
		
		[WeaverTitanProperty("f.lot", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? LocatorType { get; set; }
		
		[WeaverTitanProperty("f.lox", TitanIndex=false, TitanElasticIndex=false)]
		public virtual double? LocatorValueX { get; set; }
		
		[WeaverTitanProperty("f.loy", TitanIndex=false, TitanElasticIndex=false)]
		public virtual double? LocatorValueY { get; set; }
		
		[WeaverTitanProperty("f.loz", TitanIndex=false, TitanElasticIndex=false)]
		public virtual double? LocatorValueZ { get; set; }
		
		[WeaverTitanProperty("f.vet", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? VectorType { get; set; }
		
		[WeaverTitanProperty("f.veu", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? VectorUnit { get; set; }
		
		[WeaverTitanProperty("f.vep", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte? VectorUnitPrefix { get; set; }
		
		[WeaverTitanProperty("f.vev", TitanIndex=false, TitanElasticIndex=false)]
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
			AssertionType = TryGetByte(pData, "f.at");
			IsDefining = TryGetBool(pData, "f.de");
			Note = TryGetString(pData, "f.no");
			DescriptorType = TryGetByte(pData, "f.det");
			DirectorType = TryGetNullableByte(pData, "f.dit");
			DirectorPrimaryAction = TryGetNullableByte(pData, "f.dip");
			DirectorRelatedAction = TryGetNullableByte(pData, "f.dir");
			EventorType = TryGetNullableByte(pData, "f.evt");
			EventorDateTime = TryGetNullableLong(pData, "f.evd");
			IdentorType = TryGetNullableByte(pData, "f.idt");
			IdentorValue = TryGetString(pData, "f.idv");
			LocatorType = TryGetNullableByte(pData, "f.lot");
			LocatorValueX = TryGetNullableDouble(pData, "f.lox");
			LocatorValueY = TryGetNullableDouble(pData, "f.loy");
			LocatorValueZ = TryGetNullableDouble(pData, "f.loz");
			VectorType = TryGetNullableByte(pData, "f.vet");
			VectorUnit = TryGetNullableByte(pData, "f.veu");
			VectorUnitPrefix = TryGetNullableByte(pData, "f.vep");
			VectorValue = TryGetNullableLong(pData, "f.vev");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Instance : Artifact {

		[WeaverTitanProperty("i.na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("i.di", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Disamb { get; set; }
		
		[WeaverTitanProperty("i.no", TitanIndex=false, TitanElasticIndex=false)]
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
			Name = TryGetString(pData, "i.na");
			Disamb = TryGetString(pData, "i.di");
			Note = TryGetString(pData, "i.no");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Member : Vertex {

		[WeaverTitanProperty("m.at", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte MemberType { get; set; }
		
		[WeaverTitanProperty("m.osa", TitanIndex=false, TitanElasticIndex=false)]
		public virtual bool? OauthScopeAllow { get; set; }
		
		[WeaverTitanProperty("m.ogr", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string OauthGrantRedirectUri { get; set; }
		
		[WeaverTitanProperty("m.ogc", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string OauthGrantCode { get; set; }
		
		[WeaverTitanProperty("m.oge", TitanIndex=false, TitanElasticIndex=false)]
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
			MemberType = TryGetByte(pData, "m.at");
			OauthScopeAllow = TryGetNullableBool(pData, "m.osa");
			OauthGrantRedirectUri = TryGetString(pData, "m.ogr");
			OauthGrantCode = TryGetString(pData, "m.ogc");
			OauthGrantExpires = TryGetNullableLong(pData, "m.oge");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class OauthAccess : Vertex {

		[WeaverTitanProperty("oa.to", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string Token { get; set; }
		
		[WeaverTitanProperty("oa.re", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string Refresh { get; set; }
		
		[WeaverTitanProperty("oa.ex", TitanIndex=false, TitanElasticIndex=false)]
		public virtual long Expires { get; set; }
		
		[WeaverTitanProperty("oa.co", TitanIndex=false, TitanElasticIndex=false)]
		public virtual bool IsClientOnly { get; set; }
		
		
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
			Token = TryGetString(pData, "oa.to");
			Refresh = TryGetString(pData, "oa.re");
			Expires = TryGetLong(pData, "oa.ex");
			IsClientOnly = TryGetBool(pData, "oa.co");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Url : Artifact {

		[WeaverTitanProperty("r.na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("r.fp", TitanIndex=true, TitanElasticIndex=false)]
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
			Name = TryGetString(pData, "r.na");
			FullPath = TryGetString(pData, "r.fp");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class User : Artifact {

		[WeaverTitanProperty("u.na", TitanIndex=false, TitanElasticIndex=true)]
		public virtual string Name { get; set; }
		
		[WeaverTitanProperty("u.nk", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string NameKey { get; set; }
		
		[WeaverTitanProperty("u.pa", TitanIndex=false, TitanElasticIndex=false)]
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
			Name = TryGetString(pData, "u.na");
			NameKey = TryGetString(pData, "u.nk");
			Password = TryGetString(pData, "u.pa");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Vertex : VertexBase {

		[WeaverTitanProperty("v.id", TitanIndex=true, TitanElasticIndex=false)]
		public override long VertexId { get; set; }
		
		[WeaverTitanProperty("v.ts", TitanIndex=false, TitanElasticIndex=true)]
		public override long Timestamp { get; set; }
		
		[WeaverTitanProperty("v.t", TitanIndex=false, TitanElasticIndex=false)]
		public override byte VertexType { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Vertex() {
			VertexType = (byte)Enums.VertexType.Id.Vertex;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			VertexId = TryGetLong(pData, "v.id");
			Timestamp = TryGetLong(pData, "v.ts");
			VertexType = TryGetByte(pData, "v.t");
		}

	}

}