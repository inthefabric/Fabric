
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.Domain.Meta.Vertices;

namespace Fabric.Domain.Meta.Builders {


	/*================================================================================================*/
	public class App : Artifact {

		public string Name { get; set; }
		public string NameKey { get; set; }
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
	public class Member : Vertex {

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
	public class User : Artifact {

		public string Name { get; set; }
		public string NameKey { get; set; }
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
	public class Vertex : VertexBase {

		public long Id { get; set; }
		public long Ticks { get; set; }
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