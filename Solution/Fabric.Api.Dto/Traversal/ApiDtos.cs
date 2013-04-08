// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 2:54:24 PM

using System.Collections.Generic;
using System.Linq;
using Fabric.Domain;

namespace Fabric.Api.Dto.Traversal {
	
	/*================================================================================================*/
	public abstract class FabNodeForAction : FabNode {
		
		[DtoProp(IsOptional=false)]
		public long Performed { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Note { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"Performed", "Note"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabNodeForAction() {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;
			bool found;

			val = pData["Performed"];
			Performed = long.Parse(val);

			found = pData.TryGetValue("Note", out val);
			if ( found ) { Note = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(NodeForAction pNode) {
			base.FillWithNode(pNode);
			Performed = pNode.Performed;
			Note = pNode.Note;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabArtifact : FabNode {
		
		[DtoProp(IsOptional=false)]
		public long ArtifactId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public long Created { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"ArtifactId", "Created"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifact() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifact(Artifact pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return ArtifactId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;

			val = pData["ArtifactId"];
			ArtifactId = long.Parse(val);

			val = pData["Created"];
			Created = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Artifact pNode) {
			base.FillWithNode(pNode);
			ArtifactId = pNode.ArtifactId;
			Created = pNode.Created;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabApp : FabArtifact {
		
		[DtoProp(IsOptional=false)]
		public long AppId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string Name { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"AppId", "Name"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabApp() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabApp(App pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return AppId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["AppId"];
			AppId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(App pNode) {
			base.FillWithNode(pNode);
			AppId = pNode.AppId;
			Name = pNode.Name;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabClass : FabArtifact {
		
		[DtoProp(IsOptional=false)]
		public long ClassId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string Name { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Disamb { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Note { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"ClassId", "Name", "Disamb", "Note"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabClass() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabClass(Class pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return ClassId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["ClassId"];
			ClassId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("Disamb", out val);
			if ( found ) { Disamb = val; }

			found = pData.TryGetValue("Note", out val);
			if ( found ) { Note = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Class pNode) {
			base.FillWithNode(pNode);
			ClassId = pNode.ClassId;
			Name = pNode.Name;
			Disamb = pNode.Disamb;
			Note = pNode.Note;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabInstance : FabArtifact {
		
		[DtoProp(IsOptional=false)]
		public long InstanceId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Name { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Disamb { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Note { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"InstanceId", "Name", "Disamb", "Note"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabInstance() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabInstance(Instance pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return InstanceId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["InstanceId"];
			InstanceId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("Disamb", out val);
			if ( found ) { Disamb = val; }

			found = pData.TryGetValue("Note", out val);
			if ( found ) { Note = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Instance pNode) {
			base.FillWithNode(pNode);
			InstanceId = pNode.InstanceId;
			Name = pNode.Name;
			Disamb = pNode.Disamb;
			Note = pNode.Note;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabMember : FabNode {
		
		[DtoProp(IsOptional=false)]
		public long MemberId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"MemberId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMember() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabMember(Member pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;

			val = pData["MemberId"];
			MemberId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Member pNode) {
			base.FillWithNode(pNode);
			MemberId = pNode.MemberId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabMemberTypeAssign : FabNodeForAction {
		
		[DtoProp(IsOptional=false)]
		public long MemberTypeAssignId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte MemberTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"MemberTypeAssignId", "MemberTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMemberTypeAssign() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabMemberTypeAssign(MemberTypeAssign pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberTypeAssignId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["MemberTypeAssignId"];
			MemberTypeAssignId = long.Parse(val);

			val = pData["MemberTypeId"];
			MemberTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(MemberTypeAssign pNode) {
			base.FillWithNode(pNode);
			MemberTypeAssignId = pNode.MemberTypeAssignId;
			MemberTypeId = pNode.MemberTypeId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabUrl : FabArtifact {
		
		[DtoProp(IsOptional=false)]
		public long UrlId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string Name { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string AbsoluteUrl { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"UrlId", "Name", "AbsoluteUrl"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUrl() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabUrl(Url pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return UrlId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["UrlId"];
			UrlId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("AbsoluteUrl", out val);
			if ( found ) { AbsoluteUrl = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Url pNode) {
			base.FillWithNode(pNode);
			UrlId = pNode.UrlId;
			Name = pNode.Name;
			AbsoluteUrl = pNode.AbsoluteUrl;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabUser : FabArtifact {
		
		[DtoProp(IsOptional=false)]
		public long UserId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string Name { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"UserId", "Name"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabUser() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabUser(User pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return UserId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["UserId"];
			UserId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(User pNode) {
			base.FillWithNode(pNode);
			UserId = pNode.UserId;
			Name = pNode.Name;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabFactor : FabNode {
		
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
		
		[DtoProp(IsOptional=true)]
		public byte? Descriptor_TypeId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Director_TypeId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Director_PrimaryActionId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Director_RelatedActionId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Eventor_TypeId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Eventor_PrecisionId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public long? Eventor_DateTime { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Identor_TypeId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Identor_Value { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Locator_TypeId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public double? Locator_ValueX { get; set; }
		
		[DtoProp(IsOptional=true)]
		public double? Locator_ValueY { get; set; }
		
		[DtoProp(IsOptional=true)]
		public double? Locator_ValueZ { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Vector_TypeId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Vector_UnitId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public byte? Vector_UnitPrefixId { get; set; }
		
		[DtoProp(IsOptional=true)]
		public long? Vector_Value { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"FactorId", "FactorAssertionId", "IsDefining", "Created", "Completed", "Note", "Descriptor_TypeId", "Director_TypeId", "Director_PrimaryActionId", "Director_RelatedActionId", "Eventor_TypeId", "Eventor_PrecisionId", "Eventor_DateTime", "Identor_TypeId", "Identor_Value", "Locator_TypeId", "Locator_ValueX", "Locator_ValueY", "Locator_ValueZ", "Vector_TypeId", "Vector_UnitId", "Vector_UnitPrefixId", "Vector_Value"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabFactor() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabFactor(Factor pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return FactorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;
			bool found;

			val = pData["FactorId"];
			FactorId = long.Parse(val);

			val = pData["FactorAssertionId"];
			FactorAssertionId = byte.Parse(val);

			val = pData["IsDefining"];
			IsDefining = bool.Parse(val);

			val = pData["Created"];
			Created = long.Parse(val);

			found = pData.TryGetValue("Completed", out val);
			if ( found ) { Completed = long.Parse(val); }

			found = pData.TryGetValue("Note", out val);
			if ( found ) { Note = val; }

			found = pData.TryGetValue("Descriptor_TypeId", out val);
			if ( found ) { Descriptor_TypeId = byte.Parse(val); }

			found = pData.TryGetValue("Director_TypeId", out val);
			if ( found ) { Director_TypeId = byte.Parse(val); }

			found = pData.TryGetValue("Director_PrimaryActionId", out val);
			if ( found ) { Director_PrimaryActionId = byte.Parse(val); }

			found = pData.TryGetValue("Director_RelatedActionId", out val);
			if ( found ) { Director_RelatedActionId = byte.Parse(val); }

			found = pData.TryGetValue("Eventor_TypeId", out val);
			if ( found ) { Eventor_TypeId = byte.Parse(val); }

			found = pData.TryGetValue("Eventor_PrecisionId", out val);
			if ( found ) { Eventor_PrecisionId = byte.Parse(val); }

			found = pData.TryGetValue("Eventor_DateTime", out val);
			if ( found ) { Eventor_DateTime = long.Parse(val); }

			found = pData.TryGetValue("Identor_TypeId", out val);
			if ( found ) { Identor_TypeId = byte.Parse(val); }

			found = pData.TryGetValue("Identor_Value", out val);
			if ( found ) { Identor_Value = val; }

			found = pData.TryGetValue("Locator_TypeId", out val);
			if ( found ) { Locator_TypeId = byte.Parse(val); }

			found = pData.TryGetValue("Locator_ValueX", out val);
			if ( found ) { Locator_ValueX = double.Parse(val); }

			found = pData.TryGetValue("Locator_ValueY", out val);
			if ( found ) { Locator_ValueY = double.Parse(val); }

			found = pData.TryGetValue("Locator_ValueZ", out val);
			if ( found ) { Locator_ValueZ = double.Parse(val); }

			found = pData.TryGetValue("Vector_TypeId", out val);
			if ( found ) { Vector_TypeId = byte.Parse(val); }

			found = pData.TryGetValue("Vector_UnitId", out val);
			if ( found ) { Vector_UnitId = byte.Parse(val); }

			found = pData.TryGetValue("Vector_UnitPrefixId", out val);
			if ( found ) { Vector_UnitPrefixId = byte.Parse(val); }

			found = pData.TryGetValue("Vector_Value", out val);
			if ( found ) { Vector_Value = long.Parse(val); }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Factor pNode) {
			base.FillWithNode(pNode);
			FactorId = pNode.FactorId;
			FactorAssertionId = pNode.FactorAssertionId;
			IsDefining = pNode.IsDefining;
			Created = pNode.Created;
			Completed = pNode.Completed;
			Note = pNode.Note;
			Descriptor_TypeId = pNode.Descriptor_TypeId;
			Director_TypeId = pNode.Director_TypeId;
			Director_PrimaryActionId = pNode.Director_PrimaryActionId;
			Director_RelatedActionId = pNode.Director_RelatedActionId;
			Eventor_TypeId = pNode.Eventor_TypeId;
			Eventor_PrecisionId = pNode.Eventor_PrecisionId;
			Eventor_DateTime = pNode.Eventor_DateTime;
			Identor_TypeId = pNode.Identor_TypeId;
			Identor_Value = pNode.Identor_Value;
			Locator_TypeId = pNode.Locator_TypeId;
			Locator_ValueX = pNode.Locator_ValueX;
			Locator_ValueY = pNode.Locator_ValueY;
			Locator_ValueZ = pNode.Locator_ValueZ;
			Vector_TypeId = pNode.Vector_TypeId;
			Vector_UnitId = pNode.Vector_UnitId;
			Vector_UnitPrefixId = pNode.Vector_UnitPrefixId;
			Vector_Value = pNode.Vector_Value;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

}