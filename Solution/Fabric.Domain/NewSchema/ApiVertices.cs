
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;

namespace Fabric.Domain.NewSchema {


	/*================================================================================================*/
	public class FabApp : FabArtifact {

		//[DtoProp(IsNullable=false)]
		public string Name { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabApp() {}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			base.Fill(pVertex);

			App v = (App)pVertex;
			//Name = v.???;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabApp FromDomain(App pVertex) {
			var v = new FabApp();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabArtifact : FabVertex {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifact() {}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			base.Fill(pVertex);

			Artifact v = (Artifact)pVertex;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabArtifact FromDomain(Artifact pVertex) {
			var v = new FabArtifact();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabClass : FabArtifact {

		//[DtoProp(IsNullable=false)]
		public string Name { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public string Disamb { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public string Note { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabClass() {}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			base.Fill(pVertex);

			Class v = (Class)pVertex;
			//Name = v.???;
			//Disamb = v.???;
			//Note = v.???;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabClass FromDomain(Class pVertex) {
			var v = new FabClass();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabFactor : FabArtifact {

		//[DtoProp(IsNullable=false)]
		public byte AssertionType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public bool IsDefining { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public string Note { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte DescriptorType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte DirectorType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte DirectorPrimaryAction { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte DirectorRelatedAction { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte EventorType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public long EventorYear { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte EventorMonth { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte EventorDay { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte EventorHour { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte EventorMinute { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte EventorSecond { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte IdentorType { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public string IdentorValue { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte LocatorType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public double LocatorValueX { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public double LocatorValueY { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public double LocatorValueZ { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte VectorType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte VectorUnit { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte VectorUnitPrefix { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public long VectorValue { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabFactor() {}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			base.Fill(pVertex);

			Factor v = (Factor)pVertex;
			//AssertionType = v.???;
			//IsDefining = v.???;
			//Note = v.???;
			//DescriptorType = v.???;
			//DirectorType = v.???;
			//DirectorPrimaryAction = v.???;
			//DirectorRelatedAction = v.???;
			//EventorType = v.???;
			//EventorYear = v.???;
			//EventorMonth = v.???;
			//EventorDay = v.???;
			//EventorHour = v.???;
			//EventorMinute = v.???;
			//EventorSecond = v.???;
			//IdentorType = v.???;
			//IdentorValue = v.???;
			//LocatorType = v.???;
			//LocatorValueX = v.???;
			//LocatorValueY = v.???;
			//LocatorValueZ = v.???;
			//VectorType = v.???;
			//VectorUnit = v.???;
			//VectorUnitPrefix = v.???;
			//VectorValue = v.???;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabFactor FromDomain(Factor pVertex) {
			var v = new FabFactor();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabInstance : FabArtifact {

		//[DtoProp(IsNullable=true)]
		public string Name { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public string Disamb { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public string Note { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabInstance() {}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			base.Fill(pVertex);

			Instance v = (Instance)pVertex;
			//Name = v.???;
			//Disamb = v.???;
			//Note = v.???;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabInstance FromDomain(Instance pVertex) {
			var v = new FabInstance();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabMember : FabVertex {

		//[DtoProp(IsNullable=false)]
		public byte AccessType { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMember() {}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			base.Fill(pVertex);

			Member v = (Member)pVertex;
			//AccessType = v.???;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabMember FromDomain(Member pVertex) {
			var v = new FabMember();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabUrl : FabArtifact {

		//[DtoProp(IsNullable=true)]
		public string Name { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public string FullPath { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUrl() {}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			base.Fill(pVertex);

			Url v = (Url)pVertex;
			//Name = v.???;
			//FullPath = v.???;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabUrl FromDomain(Url pVertex) {
			var v = new FabUrl();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabUser : FabArtifact {

		//[DtoProp(IsNullable=false)]
		public string Name { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUser() {}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			base.Fill(pVertex);

			User v = (User)pVertex;
			//Name = v.???;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabUser FromDomain(User pVertex) {
			var v = new FabUser();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabVertex : FabVertexBase {

		//[DtoProp(IsNullable=false)]
		public long Id { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public string IdStr { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public float Timestamp { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabVertex() {}

		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			base.Fill(pVertex);

			Vertex v = (Vertex)pVertex;
			//Id = v.???;
			//IdStr = v.???;
			//Timestamp = v.???;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static FabVertex FromDomain(Vertex pVertex) {
			var v = new FabVertex();
			v.Fill(pVertex);
			return v;
		}

	}

}