
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Weaver.Titan.Elements;

namespace Fabric.New.Domain {


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class App : Artifact {

		[WeaverTitanProperty("p.na", TitanIndex=false, TitanElasticIndex=true)]
		public string Name { get; set; }
		
		[WeaverTitanProperty("p.nk", TitanIndex=true, TitanElasticIndex=false)]
		public string NameKey { get; set; }
		
		[WeaverTitanProperty("p.se", TitanIndex=false, TitanElasticIndex=false)]
		public string Secret { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public App() {
			DomainType = (byte)VertexType.App;
		}

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
			DomainType = (byte)VertexType.Artifact;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
		}

	}


	/*================================================================================================*/
	[WeaverTitanVertex]
	public class Class : Artifact {

		[WeaverTitanProperty("c.na", TitanIndex=false, TitanElasticIndex=true)]
		public string Name { get; set; }
		
		[WeaverTitanProperty("c.nk", TitanIndex=true, TitanElasticIndex=false)]
		public string NameKey { get; set; }
		
		[WeaverTitanProperty("c.di", TitanIndex=false, TitanElasticIndex=true)]
		public string Disamb { get; set; }
		
		[WeaverTitanProperty("c.no", TitanIndex=false, TitanElasticIndex=false)]
		public string Note { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Class() {
			DomainType = (byte)VertexType.Class;
		}

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
		public string Address { get; set; }
		
		[WeaverTitanProperty("e.co", TitanIndex=false, TitanElasticIndex=false)]
		public string Code { get; set; }
		
		[WeaverTitanProperty("e.ve", TitanIndex=false, TitanElasticIndex=false)]
		public bool Verified { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Email() {
			DomainType = (byte)VertexType.Email;
		}

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
	public class Factor : Artifact {

		[WeaverTitanProperty("f.at", TitanIndex=false, TitanElasticIndex=false)]
		public byte AssertionType { get; set; }
		
		[WeaverTitanProperty("f.de", TitanIndex=false, TitanElasticIndex=false)]
		public bool IsDefining { get; set; }
		
		[WeaverTitanProperty("f.no", TitanIndex=false, TitanElasticIndex=false)]
		public string Note { get; set; }
		
		[WeaverTitanProperty("f.det", TitanIndex=false, TitanElasticIndex=false)]
		public byte? DescriptorType { get; set; }
		
		[WeaverTitanProperty("f.dit", TitanIndex=false, TitanElasticIndex=false)]
		public byte? DirectorType { get; set; }
		
		[WeaverTitanProperty("f.dip", TitanIndex=false, TitanElasticIndex=false)]
		public byte? DirectorPrimaryAction { get; set; }
		
		[WeaverTitanProperty("f.dir", TitanIndex=false, TitanElasticIndex=false)]
		public byte? DirectorRelatedAction { get; set; }
		
		[WeaverTitanProperty("f.evt", TitanIndex=false, TitanElasticIndex=false)]
		public byte? EventorType { get; set; }
		
		[WeaverTitanProperty("f.evd", TitanIndex=false, TitanElasticIndex=false)]
		public long? EventorDateTime { get; set; }
		
		[WeaverTitanProperty("f.idt", TitanIndex=false, TitanElasticIndex=false)]
		public byte? IdentorType { get; set; }
		
		[WeaverTitanProperty("f.idv", TitanIndex=true, TitanElasticIndex=true)]
		public string IdentorValue { get; set; }
		
		[WeaverTitanProperty("f.lot", TitanIndex=false, TitanElasticIndex=false)]
		public byte? LocatorType { get; set; }
		
		[WeaverTitanProperty("f.lox", TitanIndex=false, TitanElasticIndex=false)]
		public double? LocatorValueX { get; set; }
		
		[WeaverTitanProperty("f.loy", TitanIndex=false, TitanElasticIndex=false)]
		public double? LocatorValueY { get; set; }
		
		[WeaverTitanProperty("f.loz", TitanIndex=false, TitanElasticIndex=false)]
		public double? LocatorValueZ { get; set; }
		
		[WeaverTitanProperty("f.vet", TitanIndex=false, TitanElasticIndex=false)]
		public byte? VectorType { get; set; }
		
		[WeaverTitanProperty("f.veu", TitanIndex=false, TitanElasticIndex=false)]
		public byte? VectorUnit { get; set; }
		
		[WeaverTitanProperty("f.vep", TitanIndex=false, TitanElasticIndex=false)]
		public byte? VectorUnitPrefix { get; set; }
		
		[WeaverTitanProperty("f.vev", TitanIndex=false, TitanElasticIndex=false)]
		public long? VectorValue { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Factor() {
			DomainType = (byte)VertexType.Factor;
		}

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
		public string Name { get; set; }
		
		[WeaverTitanProperty("i.di", TitanIndex=false, TitanElasticIndex=true)]
		public string Disamb { get; set; }
		
		[WeaverTitanProperty("i.no", TitanIndex=false, TitanElasticIndex=false)]
		public string Note { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Instance() {
			DomainType = (byte)VertexType.Instance;
		}

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
		public byte MemberType { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Member() {
			DomainType = (byte)VertexType.Member;
		}

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
		public string Token { get; set; }
		
		[WeaverTitanProperty("oa.re", TitanIndex=true, TitanElasticIndex=false)]
		public string Refresh { get; set; }
		
		[WeaverTitanProperty("oa.ex", TitanIndex=false, TitanElasticIndex=false)]
		public long Expires { get; set; }
		
		[WeaverTitanProperty("oa.co", TitanIndex=false, TitanElasticIndex=false)]
		public bool IsClientOnly { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccess() {
			DomainType = (byte)VertexType.OauthAccess;
		}

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
		public string Domain { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthDomain() {
			DomainType = (byte)VertexType.OauthDomain;
		}

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
		public string RedirectUri { get; set; }
		
		[WeaverTitanProperty("og.co", TitanIndex=true, TitanElasticIndex=false)]
		public string Code { get; set; }
		
		[WeaverTitanProperty("og.ex", TitanIndex=false, TitanElasticIndex=false)]
		public long Expires { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthGrant() {
			DomainType = (byte)VertexType.OauthGrant;
		}

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
		public bool Allow { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthScope() {
			DomainType = (byte)VertexType.OauthScope;
		}

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
		public string Name { get; set; }
		
		[WeaverTitanProperty("r.fp", TitanIndex=true, TitanElasticIndex=false)]
		public string FullPath { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Url() {
			DomainType = (byte)VertexType.Url;
		}

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
		public string Name { get; set; }
		
		[WeaverTitanProperty("u.nk", TitanIndex=true, TitanElasticIndex=false)]
		public string NameKey { get; set; }
		
		[WeaverTitanProperty("u.pa", TitanIndex=false, TitanElasticIndex=false)]
		public string Password { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public User() {
			DomainType = (byte)VertexType.User;
		}

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
		public long Id { get; set; }
		
		[WeaverTitanProperty("v.ti", TitanIndex=false, TitanElasticIndex=true)]
		public long Timestamp { get; set; }
		
		[WeaverTitanProperty("v.dt", TitanIndex=false, TitanElasticIndex=false)]
		public byte DomainType { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Vertex() {
			DomainType = (byte)VertexType.Vertex;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Id = TryGetLong(pData, "v.id");
			Timestamp = TryGetLong(pData, "v.ti");
			DomainType = TryGetByte(pData, "v.dt");
		}

	}

}