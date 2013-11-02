
// GENERATED CODE
// Changes made to this source file will be overwritten

namespace Fabric.Domain.NewSchema {


	/*================================================================================================*/
	public class FabApp : FabArtifact {

		//[DtoProp(IsNullable=false)]
		public string Name { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromApp(this, (App)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabApp FromApp(App pVertex) {
			var v = new FabApp();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabArtifact : FabVertex {

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromArtifact(this, (Artifact)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabArtifact FromArtifact(Artifact pVertex) {
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
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromClass(this, (Class)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabClass FromClass(Class pVertex) {
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
		public FabDescriptor Descriptor { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public FabDirector Director { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public FabEventor Eventor { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public FabIdentor Identor { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public FabLocator Locator { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public FabVector Vector { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromFactor(this, (Factor)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabFactor FromFactor(Factor pVertex) {
			var v = new FabFactor();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabDescriptor : FabObject {

		//[DtoProp(IsNullable=false)]
		public byte DescriptorType { get; set; }
		
	}


	/*================================================================================================*/
	public class FabDirector : FabObject {

		//[DtoProp(IsNullable=false)]
		public byte DirectorType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte PrimaryAction { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte RelatedAction { get; set; }
		
	}


	/*================================================================================================*/
	public class FabEventor : FabObject {

		//[DtoProp(IsNullable=false)]
		public byte EventorType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public long Year { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public byte? Month { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public byte? Day { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public byte? Hour { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public byte? Minute { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public byte? Second { get; set; }
		
	}


	/*================================================================================================*/
	public class FabIdentor : FabObject {

		//[DtoProp(IsNullable=false)]
		public byte IdentorType { get; set; }
		
		//[DtoProp(IsNullable=true)]
		public string Value { get; set; }
		
	}


	/*================================================================================================*/
	public class FabLocator : FabObject {

		//[DtoProp(IsNullable=false)]
		public byte LocatorType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public double ValueX { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public double ValueY { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public double ValueZ { get; set; }
		
	}


	/*================================================================================================*/
	public class FabVector : FabObject {

		//[DtoProp(IsNullable=false)]
		public byte VectorType { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte Unit { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public byte UnitPrefix { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public long Value { get; set; }
		
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
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromInstance(this, (Instance)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabInstance FromInstance(Instance pVertex) {
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
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromMember(this, (Member)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabMember FromMember(Member pVertex) {
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
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromUrl(this, (Url)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabUrl FromUrl(Url pVertex) {
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
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromUser(this, (User)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabUser FromUser(User pVertex) {
			var v = new FabUser();
			v.Fill(pVertex);
			return v;
		}

	}


	/*================================================================================================*/
	public class FabVertex : FabObject {

		//[DtoProp(IsNullable=false)]
		public long Id { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public string IdStr { get; set; }
		
		//[DtoProp(IsNullable=false)]
		public float Timestamp { get; set; }
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(Vertex pVertex) {
			DomainToApi.FromVertex(this, (Vertex)pVertex);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static FabVertex FromVertex(Vertex pVertex) {
			var v = new FabVertex();
			v.Fill(pVertex);
			return v;
		}

	}

}