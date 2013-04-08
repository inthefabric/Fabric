// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/8/2013 1:22:16 PM

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
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"FactorId", "FactorAssertionId", "IsDefining", "Created", "Completed", "Note"
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
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public abstract class FabFactorElementNode : FabNode {
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabFactorElementNode() {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(FactorElementNode pNode) {
			base.FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDescriptor : FabFactorElementNode {
		
		[DtoProp(IsOptional=false)]
		public long DescriptorId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte DescriptorTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DescriptorId", "DescriptorTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabDescriptor() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabDescriptor(Descriptor pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DescriptorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DescriptorId"];
			DescriptorId = long.Parse(val);

			val = pData["DescriptorTypeId"];
			DescriptorTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Descriptor pNode) {
			base.FillWithNode(pNode);
			DescriptorId = pNode.DescriptorId;
			DescriptorTypeId = pNode.DescriptorTypeId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDirector : FabFactorElementNode {
		
		[DtoProp(IsOptional=false)]
		public long DirectorId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte DirectorTypeId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte PrimaryDirectorActionId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte RelatedDirectorActionId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DirectorId", "DirectorTypeId", "PrimaryDirectorActionId", "RelatedDirectorActionId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabDirector() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabDirector(Director pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DirectorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DirectorId"];
			DirectorId = long.Parse(val);

			val = pData["DirectorTypeId"];
			DirectorTypeId = byte.Parse(val);

			val = pData["PrimaryDirectorActionId"];
			PrimaryDirectorActionId = byte.Parse(val);

			val = pData["RelatedDirectorActionId"];
			RelatedDirectorActionId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Director pNode) {
			base.FillWithNode(pNode);
			DirectorId = pNode.DirectorId;
			DirectorTypeId = pNode.DirectorTypeId;
			PrimaryDirectorActionId = pNode.PrimaryDirectorActionId;
			RelatedDirectorActionId = pNode.RelatedDirectorActionId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabEventor : FabFactorElementNode {
		
		[DtoProp(IsOptional=false)]
		public long EventorId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte EventorTypeId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte EventorPrecisionId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public long DateTime { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"EventorId", "EventorTypeId", "EventorPrecisionId", "DateTime"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabEventor() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabEventor(Eventor pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return EventorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["EventorId"];
			EventorId = long.Parse(val);

			val = pData["EventorTypeId"];
			EventorTypeId = byte.Parse(val);

			val = pData["EventorPrecisionId"];
			EventorPrecisionId = byte.Parse(val);

			val = pData["DateTime"];
			DateTime = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Eventor pNode) {
			base.FillWithNode(pNode);
			EventorId = pNode.EventorId;
			EventorTypeId = pNode.EventorTypeId;
			EventorPrecisionId = pNode.EventorPrecisionId;
			DateTime = pNode.DateTime;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabIdentor : FabFactorElementNode {
		
		[DtoProp(IsOptional=false)]
		public long IdentorId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte IdentorTypeId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string Value { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"IdentorId", "IdentorTypeId", "Value"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabIdentor() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabIdentor(Identor pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return IdentorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["IdentorId"];
			IdentorId = long.Parse(val);

			val = pData["IdentorTypeId"];
			IdentorTypeId = byte.Parse(val);

			found = pData.TryGetValue("Value", out val);
			if ( found ) { Value = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Identor pNode) {
			base.FillWithNode(pNode);
			IdentorId = pNode.IdentorId;
			IdentorTypeId = pNode.IdentorTypeId;
			Value = pNode.Value;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabLocator : FabFactorElementNode {
		
		[DtoProp(IsOptional=false)]
		public long LocatorId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte LocatorTypeId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double ValueX { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double ValueY { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double ValueZ { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"LocatorId", "LocatorTypeId", "ValueX", "ValueY", "ValueZ"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabLocator() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabLocator(Locator pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return LocatorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["LocatorId"];
			LocatorId = long.Parse(val);

			val = pData["LocatorTypeId"];
			LocatorTypeId = byte.Parse(val);

			val = pData["ValueX"];
			ValueX = double.Parse(val);

			val = pData["ValueY"];
			ValueY = double.Parse(val);

			val = pData["ValueZ"];
			ValueZ = double.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Locator pNode) {
			base.FillWithNode(pNode);
			LocatorId = pNode.LocatorId;
			LocatorTypeId = pNode.LocatorTypeId;
			ValueX = pNode.ValueX;
			ValueY = pNode.ValueY;
			ValueZ = pNode.ValueZ;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVector : FabFactorElementNode {
		
		[DtoProp(IsOptional=false)]
		public long VectorId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte VectorTypeId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte VectorUnitId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public byte VectorUnitPrefixId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public long Value { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorId", "VectorTypeId", "VectorUnitId", "VectorUnitPrefixId", "Value"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabVector() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabVector(Vector pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorId"];
			VectorId = long.Parse(val);

			val = pData["VectorTypeId"];
			VectorTypeId = byte.Parse(val);

			val = pData["VectorUnitId"];
			VectorUnitId = byte.Parse(val);

			val = pData["VectorUnitPrefixId"];
			VectorUnitPrefixId = byte.Parse(val);

			val = pData["Value"];
			Value = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Vector pNode) {
			base.FillWithNode(pNode);
			VectorId = pNode.VectorId;
			VectorTypeId = pNode.VectorTypeId;
			VectorUnitId = pNode.VectorUnitId;
			VectorUnitPrefixId = pNode.VectorUnitPrefixId;
			Value = pNode.Value;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

}