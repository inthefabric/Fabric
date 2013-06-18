// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/18/2013 3:43:35 PM

using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.Domain;
using Fabric.Infrastructure.Db;

namespace Fabric.Api.Dto.Traversal {
	
	/*================================================================================================*/
	public abstract class FabVertexForAction : FabVertex {
		
		[DtoProp(IsOptional=false)]
		public long Performed { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Note { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"Performed", "Note"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabVertexForAction() {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;
			bool found;

			val = pData["NA_Pe"];
			Performed = long.Parse(val);

			found = pData.TryGetValue("NA_No", out val);
			if ( found ) { Note = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex<T>(T pVertex) where T : VertexForAction {
			base.FillWithVertex(pVertex);
			Performed = pVertex.Performed;
			Note = pVertex.Note;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}
	/*================================================================================================*/
	public class FabArtifact : FabVertex {
		
		[DtoProp(IsOptional=false)]
		public long ArtifactId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public long Created { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"ArtifactId", "Created"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifact() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifact(Artifact pVertex) : this() {
			FillWithVertex(pVertex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return ArtifactId; } }
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;

			val = pData["A_AId"];
			ArtifactId = long.Parse(val);

			val = pData["A_Cr"];
			Created = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(Artifact pVertex) {
			base.FillWithVertex(pVertex);
			ArtifactId = pVertex.ArtifactId;
			Created = pVertex.Created;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}
	/*================================================================================================*/
	public class FabApp : FabArtifact {
		
		[DtoProp(IsOptional=false)]
		public string Name { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"Name"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabApp() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabApp(App pVertex) : this() {
			FillWithVertex(pVertex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			found = pData.TryGetValue("Ap_Na", out val);
			if ( found ) { Name = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(App pVertex) {
			base.FillWithVertex(pVertex);
			Name = pVertex.Name;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}
	/*================================================================================================*/
	public class FabClass : FabArtifact {
		
		[DtoProp(IsOptional=false)]
		public string Name { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Disamb { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Note { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"Name", "Disamb", "Note"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabClass() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabClass(Class pVertex) : this() {
			FillWithVertex(pVertex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			found = pData.TryGetValue("Cl_Na", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("Cl_Di", out val);
			if ( found ) { Disamb = val; }

			found = pData.TryGetValue("Cl_No", out val);
			if ( found ) { Note = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(Class pVertex) {
			base.FillWithVertex(pVertex);
			Name = pVertex.Name;
			Disamb = pVertex.Disamb;
			Note = pVertex.Note;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}
	/*================================================================================================*/
	public class FabInstance : FabArtifact {
		
		[DtoProp(IsOptional=true)]
		public string Name { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Disamb { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Note { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"Name", "Disamb", "Note"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabInstance() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabInstance(Instance pVertex) : this() {
			FillWithVertex(pVertex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			found = pData.TryGetValue("In_Na", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("In_Di", out val);
			if ( found ) { Disamb = val; }

			found = pData.TryGetValue("In_No", out val);
			if ( found ) { Note = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(Instance pVertex) {
			base.FillWithVertex(pVertex);
			Name = pVertex.Name;
			Disamb = pVertex.Disamb;
			Note = pVertex.Note;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}
	/*================================================================================================*/
	public class FabMember : FabVertex {
		
		[DtoProp(IsOptional=false)]
		public long MemberId { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"MemberId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMember() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabMember(Member pVertex) : this() {
			FillWithVertex(pVertex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberId; } }
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;

			val = pData["M_Id"];
			MemberId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(Member pVertex) {
			base.FillWithVertex(pVertex);
			MemberId = pVertex.MemberId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}
	/*================================================================================================*/
	public class FabMemberTypeAssign : FabVertexForAction {
		
		[DtoProp(IsOptional=false)]
		public long MemberTypeAssignId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte MemberTypeId { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"MemberTypeAssignId", "MemberTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMemberTypeAssign() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabMemberTypeAssign(MemberTypeAssign pVertex) : this() {
			FillWithVertex(pVertex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberTypeAssignId; } }
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["MTA_Id"];
			MemberTypeAssignId = long.Parse(val);

			val = pData["MTA_Mt"];
			MemberTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(MemberTypeAssign pVertex) {
			base.FillWithVertex(pVertex);
			MemberTypeAssignId = pVertex.MemberTypeAssignId;
			MemberTypeId = pVertex.MemberTypeId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}
	/*================================================================================================*/
	public class FabUrl : FabArtifact {
		
		[DtoProp(IsOptional=false)]
		public string Name { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string AbsoluteUrl { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"Name", "AbsoluteUrl"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUrl() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabUrl(Url pVertex) : this() {
			FillWithVertex(pVertex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			found = pData.TryGetValue("Ur_Na", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("Ur_Ab", out val);
			if ( found ) { AbsoluteUrl = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(Url pVertex) {
			base.FillWithVertex(pVertex);
			Name = pVertex.Name;
			AbsoluteUrl = pVertex.AbsoluteUrl;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}
	/*================================================================================================*/
	public class FabUser : FabArtifact {
		
		[DtoProp(IsOptional=false)]
		public string Name { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"Name"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUser() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabUser(User pVertex) : this() {
			FillWithVertex(pVertex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			found = pData.TryGetValue("U_Na", out val);
			if ( found ) { Name = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(User pVertex) {
			base.FillWithVertex(pVertex);
			Name = pVertex.Name;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}
	/*================================================================================================*/
	public class FabFactor : FabVertex {
		
		[DtoProp(IsOptional=false)]
		public long FactorId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte FactorAssertionId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public bool IsDefining { get; set; }
		
		[DtoProp(IsOptional=false)]
		public long Created { get; set; }
		
		[DtoProp(IsOptional=true)]
		public long? Completed { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Note { get; set; }
		
		[DtoProp(IsOptional=false)]
		public FabDescriptor Descriptor { get; set; }
		
		[DtoProp(IsOptional=true)]
		public FabDirector Director { get; set; }
		
		[DtoProp(IsOptional=true)]
		public FabEventor Eventor { get; set; }
		
		[DtoProp(IsOptional=true)]
		public FabIdentor Identor { get; set; }
		
		[DtoProp(IsOptional=true)]
		public FabLocator Locator { get; set; }
		
		[DtoProp(IsOptional=true)]
		public FabVector Vector { get; set; }
		
		private static readonly List<string> AvailVertexProps = new List<string> {
			"FactorId", "FactorAssertionId", "IsDefining", "Created", "Completed", "Note", "Descriptor.TypeId", "Director.TypeId", "Director.PrimaryActionId", "Director.RelatedActionId", "Eventor.TypeId", "Eventor.PrecisionId", "Eventor.DateTime", "Identor.TypeId", "Identor.Value", "Locator.TypeId", "Locator.ValueX", "Locator.ValueY", "Locator.ValueZ", "Vector.TypeId", "Vector.UnitId", "Vector.UnitPrefixId", "Vector.Value"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabFactor() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabFactor(Factor pVertex) : this() {
			FillWithVertex(pVertex);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return FactorId; } }
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;
			bool found;

			val = pData["F_Id"];
			FactorId = long.Parse(val);

			val = pData["F_Fa"];
			FactorAssertionId = byte.Parse(val);

			val = pData["F_Df"];
			IsDefining = bool.Parse(val);

			val = pData["F_Cr"];
			Created = long.Parse(val);

			found = pData.TryGetValue("F_Co", out val);
			if ( found ) { Completed = long.Parse(val); }

			found = pData.TryGetValue("F_No", out val);
			if ( found ) { Note = val; }

			found = pData.TryGetValue("F_DeT", out val);
			if ( found ) {
				if ( Descriptor == null ) { Descriptor = new FabDescriptor(); }
				Descriptor.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_DiT", out val);
			if ( found ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_DiP", out val);
			if ( found ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.PrimaryActionId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_DiR", out val);
			if ( found ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.RelatedActionId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_EvT", out val);
			if ( found ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_EvP", out val);
			if ( found ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.PrecisionId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_EvD", out val);
			if ( found ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.DateTime = long.Parse(val);
			}

			found = pData.TryGetValue("F_IdT", out val);
			if ( found ) {
				if ( Identor == null ) { Identor = new FabIdentor(); }
				Identor.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_IdV", out val);
			if ( found ) { Identor.Value = val; }

			found = pData.TryGetValue("F_LoT", out val);
			if ( found ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_LoX", out val);
			if ( found ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueX = double.Parse(val);
			}

			found = pData.TryGetValue("F_LoY", out val);
			if ( found ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueY = double.Parse(val);
			}

			found = pData.TryGetValue("F_LoZ", out val);
			if ( found ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueZ = double.Parse(val);
			}

			found = pData.TryGetValue("F_VeT", out val);
			if ( found ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_VeU", out val);
			if ( found ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.UnitId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_VeP", out val);
			if ( found ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.UnitPrefixId = byte.Parse(val);
			}

			found = pData.TryGetValue("F_VeV", out val);
			if ( found ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.Value = long.Parse(val);
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithVertex(Factor pVertex) {
			base.FillWithVertex(pVertex);
			FactorId = pVertex.FactorId;
			FactorAssertionId = pVertex.FactorAssertionId;
			IsDefining = pVertex.IsDefining;
			Created = pVertex.Created;
			Completed = pVertex.Completed;
			Note = pVertex.Note;

			if ( pVertex.Descriptor_TypeId != null ) {
				if ( Descriptor == null ) { Descriptor = new FabDescriptor(); }
				Descriptor.TypeId = (byte)pVertex.Descriptor_TypeId;
			}

			if ( pVertex.Director_TypeId != null ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.TypeId = (byte)pVertex.Director_TypeId;
			}

			if ( pVertex.Director_PrimaryActionId != null ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.PrimaryActionId = (byte)pVertex.Director_PrimaryActionId;
			}

			if ( pVertex.Director_RelatedActionId != null ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.RelatedActionId = (byte)pVertex.Director_RelatedActionId;
			}

			if ( pVertex.Eventor_TypeId != null ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.TypeId = (byte)pVertex.Eventor_TypeId;
			}

			if ( pVertex.Eventor_PrecisionId != null ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.PrecisionId = (byte)pVertex.Eventor_PrecisionId;
			}

			if ( pVertex.Eventor_DateTime != null ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.DateTime = (long)pVertex.Eventor_DateTime;
			}

			if ( pVertex.Identor_TypeId != null ) {
				if ( Identor == null ) { Identor = new FabIdentor(); }
				Identor.TypeId = (byte)pVertex.Identor_TypeId;
			}

			if ( pVertex.Identor_Value != null ) {
				if ( Identor == null ) { Identor = new FabIdentor(); }
				Identor.Value = (string)pVertex.Identor_Value;
			}

			if ( pVertex.Locator_TypeId != null ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.TypeId = (byte)pVertex.Locator_TypeId;
			}

			if ( pVertex.Locator_ValueX != null ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueX = (double)pVertex.Locator_ValueX;
			}

			if ( pVertex.Locator_ValueY != null ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueY = (double)pVertex.Locator_ValueY;
			}

			if ( pVertex.Locator_ValueZ != null ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueZ = (double)pVertex.Locator_ValueZ;
			}

			if ( pVertex.Vector_TypeId != null ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.TypeId = (byte)pVertex.Vector_TypeId;
			}

			if ( pVertex.Vector_UnitId != null ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.UnitId = (byte)pVertex.Vector_UnitId;
			}

			if ( pVertex.Vector_UnitPrefixId != null ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.UnitPrefixId = (byte)pVertex.Vector_UnitPrefixId;
			}

			if ( pVertex.Vector_Value != null ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.Value = (long)pVertex.Vector_Value;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailVertexProps).ToList(); }
		}

	}


	/*================================================================================================*/
	public class FabDescriptor : FabObject {
	
		public byte TypeId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {
			throw new NotImplementedException();
		}

	}


	/*================================================================================================*/
	public class FabDirector : FabObject {
	
		public byte TypeId { get; set; }
		public byte PrimaryActionId { get; set; }
		public byte RelatedActionId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {
			throw new NotImplementedException();
		}

	}


	/*================================================================================================*/
	public class FabEventor : FabObject {
	
		public byte TypeId { get; set; }
		public byte PrecisionId { get; set; }
		public long DateTime { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {
			throw new NotImplementedException();
		}

	}


	/*================================================================================================*/
	public class FabIdentor : FabObject {
	
		public byte TypeId { get; set; }
		public string Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {
			throw new NotImplementedException();
		}

	}


	/*================================================================================================*/
	public class FabLocator : FabObject {
	
		public byte TypeId { get; set; }
		public double ValueX { get; set; }
		public double ValueY { get; set; }
		public double ValueZ { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {
			throw new NotImplementedException();
		}

	}


	/*================================================================================================*/
	public class FabVector : FabObject {
	
		public byte TypeId { get; set; }
		public byte UnitId { get; set; }
		public byte UnitPrefixId { get; set; }
		public long Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDbDto pDbDto) {
			throw new NotImplementedException();
		}

	}
}