
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.Domain.Meta.Vertices;
using Weaver.Titan.Elements;

namespace Fabric.Domain.Meta.Builders {


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
			DomainType = (byte)VertexDomainType.App;
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
			DomainType = (byte)VertexDomainType.Artifact;
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
		
		[WeaverTitanProperty("c.di", TitanIndex=false, TitanElasticIndex=false)]
		public string Disamb { get; set; }
		
		[WeaverTitanProperty("c.no", TitanIndex=false, TitanElasticIndex=false)]
		public string Note { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Class() {
			DomainType = (byte)VertexDomainType.Class;
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
	public class Instance : Artifact {

		[WeaverTitanProperty("i.na", TitanIndex=false, TitanElasticIndex=true)]
		public string Name { get; set; }
		
		[WeaverTitanProperty("i.di", TitanIndex=false, TitanElasticIndex=false)]
		public string Disamb { get; set; }
		
		[WeaverTitanProperty("i.no", TitanIndex=false, TitanElasticIndex=false)]
		public string Note { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Instance() {
			DomainType = (byte)VertexDomainType.Instance;
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
		public byte AccessType { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Member() {
			DomainType = (byte)VertexDomainType.Member;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			AccessType = TryGetByte(pData, "m.at");
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
			DomainType = (byte)VertexDomainType.Url;
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
			DomainType = (byte)VertexDomainType.User;
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
		public long Ticks { get; set; }
		
		[WeaverTitanProperty("v.dt", TitanIndex=false, TitanElasticIndex=false)]
		public byte DomainType { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Vertex() {
			DomainType = (byte)VertexDomainType.Vertex;
		}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDictionary<string, string> pData) {
			base.Fill(pData);
			Id = TryGetLong(pData, "v.id");
			Ticks = TryGetLong(pData, "v.ti");
			DomainType = TryGetByte(pData, "v.dt");
		}

	}

}