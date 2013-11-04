
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
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
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public App() {
			VertexType = (byte)VertexDomainType.App;
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
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Artifact : Vertex {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Artifact() {
			VertexType = (byte)VertexDomainType.Artifact;
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
			VertexType = (byte)VertexDomainType.Class;
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
			VertexType = (byte)VertexDomainType.Email;
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
		public virtual byte? DescriptorType { get; set; }
		
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
			VertexType = (byte)VertexDomainType.Factor;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorCreatedByMember CreatedByMember {
			get { return NewEdge<FactorCreatedByMember>(WeaverEdgeConn.OutOne); }
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
		public virtual FactorPrimaryRefinedByArtifact PrimaryRefinedByArtifact {
			get { return NewEdge<FactorPrimaryRefinedByArtifact>(WeaverEdgeConn.OutZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorRelatedRefinedByArtifact RelatedRefinedByArtifact {
			get { return NewEdge<FactorRelatedRefinedByArtifact>(WeaverEdgeConn.OutZeroOrOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual FactorDescriptorTypeRefinedByArtifact DescriptorTypeRefinedByArtifact {
			get { return NewEdge<FactorDescriptorTypeRefinedByArtifact>(WeaverEdgeConn.OutZeroOrOne); }
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
			DescriptorType = TryGetNullableByte(pData, "f.det");
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
			VertexType = (byte)VertexDomainType.Instance;
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
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Member() {
			VertexType = (byte)VertexDomainType.Member;
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberDefinedByApp DefinedByApp {
			get { return NewEdge<MemberDefinedByApp>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberDefinedByUser DefinedByUser {
			get { return NewEdge<MemberDefinedByUser>(WeaverEdgeConn.OutOne); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesArtifact CreatesArtifacts {
			get { return NewEdge<MemberCreatesArtifact>(WeaverEdgeConn.OutZeroOrMore); }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual MemberCreatesFactor CreatesFactors {
			get { return NewEdge<MemberCreatesFactor>(WeaverEdgeConn.OutZeroOrMore); }
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			MemberType = TryGetByte(pData, "m.at");
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
			VertexType = (byte)VertexDomainType.OauthAccess;
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
	public class OauthDomain : Vertex {

		[WeaverTitanProperty("od.do", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string Domain { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomain() {
			VertexType = (byte)VertexDomainType.OauthDomain;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Domain = TryGetString(pData, "od.do");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class OauthGrant : Vertex {

		[WeaverTitanProperty("og.ru", TitanIndex=false, TitanElasticIndex=false)]
		public virtual string RedirectUri { get; set; }
		
		[WeaverTitanProperty("og.co", TitanIndex=true, TitanElasticIndex=false)]
		public virtual string Code { get; set; }
		
		[WeaverTitanProperty("og.ex", TitanIndex=false, TitanElasticIndex=false)]
		public virtual long Expires { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrant() {
			VertexType = (byte)VertexDomainType.OauthGrant;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			RedirectUri = TryGetString(pData, "og.ru");
			Code = TryGetString(pData, "og.co");
			Expires = TryGetLong(pData, "og.ex");
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class OauthScope : Vertex {

		[WeaverTitanProperty("os.al", TitanIndex=false, TitanElasticIndex=false)]
		public virtual bool Allow { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthScope() {
			VertexType = (byte)VertexDomainType.OauthScope;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Allow = TryGetBool(pData, "os.al");
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
			VertexType = (byte)VertexDomainType.Url;
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
			VertexType = (byte)VertexDomainType.User;
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
		public virtual long VertexId { get; set; }
		
		[WeaverTitanProperty("v.ts", TitanIndex=false, TitanElasticIndex=true)]
		public virtual long Timestamp { get; set; }
		
		[WeaverTitanProperty("v.t", TitanIndex=false, TitanElasticIndex=false)]
		public virtual byte VertexType { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Vertex() {
			VertexType = (byte)VertexDomainType.Vertex;
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