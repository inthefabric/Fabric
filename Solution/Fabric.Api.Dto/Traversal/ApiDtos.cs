// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 3/15/2013 12:48:13 PM

using System.Collections.Generic;
using System.Linq;
using Fabric.Domain;

namespace Fabric.Api.Dto.Traversal {
	
	/*================================================================================================*/
	public abstract class FabNodeForType : FabNode {
		
		[DtoProp(IsOptional=false)]
		public string Name { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string Description { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"Name", "Description"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabNodeForType() {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;
			bool found;

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("Description", out val);
			if ( found ) { Description = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(NodeForType pNode) {
			base.FillWithNode(pNode);
			Name = pNode.Name;
			Description = pNode.Description;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

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
	public abstract class FabArtifactOwnerNode : FabNode {
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifactOwnerNode() {}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(ArtifactOwnerNode pNode) {
			base.FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabRoot : FabNode {
		
		[DtoProp(IsOptional=false)]
		public int RootId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"RootId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabRoot() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabRoot(Root pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return RootId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;

			val = pData["RootId"];
			RootId = int.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Root pNode) {
			base.FillWithNode(pNode);
			RootId = pNode.RootId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabApp : FabArtifactOwnerNode {
		
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
	public class FabArtifact : FabNode {
		
		[DtoProp(IsOptional=false)]
		public long ArtifactId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public bool IsPrivate { get; set; }
		
		[DtoProp(IsOptional=false)]
		public long Created { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"ArtifactId", "IsPrivate", "Created"
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

			val = pData["IsPrivate"];
			IsPrivate = bool.Parse(val);

			val = pData["Created"];
			Created = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Artifact pNode) {
			base.FillWithNode(pNode);
			ArtifactId = pNode.ArtifactId;
			IsPrivate = pNode.IsPrivate;
			Created = pNode.Created;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabArtifactType : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long ArtifactTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"ArtifactTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifactType() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabArtifactType(ArtifactType pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return ArtifactTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["ArtifactTypeId"];
			ArtifactTypeId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(ArtifactType pNode) {
			base.FillWithNode(pNode);
			ArtifactTypeId = pNode.ArtifactTypeId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabClass : FabArtifactOwnerNode {
		
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
	public class FabInstance : FabArtifactOwnerNode {
		
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
	public class FabMemberType : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long MemberTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"MemberTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabMemberType() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabMemberType(MemberType pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["MemberTypeId"];
			MemberTypeId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(MemberType pNode) {
			base.FillWithNode(pNode);
			MemberTypeId = pNode.MemberTypeId;
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
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"MemberTypeAssignId"
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
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(MemberTypeAssign pNode) {
			base.FillWithNode(pNode);
			MemberTypeAssignId = pNode.MemberTypeAssignId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabUrl : FabArtifactOwnerNode {
		
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
	public class FabUser : FabArtifactOwnerNode {
		
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
		public bool IsDefining { get; set; }
		
		[DtoProp(IsOptional=false)]
		public long Created { get; set; }
		
		[DtoProp(IsOptional=true)]
		public long? Completed { get; set; }
		
		[DtoProp(IsOptional=true)]
		public string Note { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"FactorId", "IsDefining", "Created", "Completed", "Note"
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
	public class FabFactorAssertion : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long FactorAssertionId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"FactorAssertionId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabFactorAssertion() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabFactorAssertion(FactorAssertion pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return FactorAssertionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["FactorAssertionId"];
			FactorAssertionId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(FactorAssertion pNode) {
			base.FillWithNode(pNode);
			FactorAssertionId = pNode.FactorAssertionId;
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
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DescriptorId"
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
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Descriptor pNode) {
			base.FillWithNode(pNode);
			DescriptorId = pNode.DescriptorId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDescriptorType : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long DescriptorTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DescriptorTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabDescriptorType() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabDescriptorType(DescriptorType pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DescriptorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DescriptorTypeId"];
			DescriptorTypeId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(DescriptorType pNode) {
			base.FillWithNode(pNode);
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
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DirectorId"
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
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Director pNode) {
			base.FillWithNode(pNode);
			DirectorId = pNode.DirectorId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDirectorType : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long DirectorTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DirectorTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabDirectorType() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabDirectorType(DirectorType pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DirectorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DirectorTypeId"];
			DirectorTypeId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(DirectorType pNode) {
			base.FillWithNode(pNode);
			DirectorTypeId = pNode.DirectorTypeId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDirectorAction : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long DirectorActionId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DirectorActionId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabDirectorAction() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabDirectorAction(DirectorAction pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DirectorActionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DirectorActionId"];
			DirectorActionId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(DirectorAction pNode) {
			base.FillWithNode(pNode);
			DirectorActionId = pNode.DirectorActionId;
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
		public long DateTime { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"EventorId", "DateTime"
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

			val = pData["DateTime"];
			DateTime = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Eventor pNode) {
			base.FillWithNode(pNode);
			EventorId = pNode.EventorId;
			DateTime = pNode.DateTime;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabEventorType : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long EventorTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"EventorTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabEventorType() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabEventorType(EventorType pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return EventorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["EventorTypeId"];
			EventorTypeId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(EventorType pNode) {
			base.FillWithNode(pNode);
			EventorTypeId = pNode.EventorTypeId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabEventorPrecision : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long EventorPrecisionId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"EventorPrecisionId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabEventorPrecision() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabEventorPrecision(EventorPrecision pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return EventorPrecisionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["EventorPrecisionId"];
			EventorPrecisionId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(EventorPrecision pNode) {
			base.FillWithNode(pNode);
			EventorPrecisionId = pNode.EventorPrecisionId;
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
		public string Value { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"IdentorId", "Value"
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

			found = pData.TryGetValue("Value", out val);
			if ( found ) { Value = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Identor pNode) {
			base.FillWithNode(pNode);
			IdentorId = pNode.IdentorId;
			Value = pNode.Value;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabIdentorType : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long IdentorTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"IdentorTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabIdentorType() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabIdentorType(IdentorType pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return IdentorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["IdentorTypeId"];
			IdentorTypeId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(IdentorType pNode) {
			base.FillWithNode(pNode);
			IdentorTypeId = pNode.IdentorTypeId;
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
		public double ValueX { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double ValueY { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double ValueZ { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"LocatorId", "ValueX", "ValueY", "ValueZ"
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
	public class FabLocatorType : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long LocatorTypeId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double MinX { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double MaxX { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double MinY { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double MaxY { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double MinZ { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double MaxZ { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"LocatorTypeId", "MinX", "MaxX", "MinY", "MaxY", "MinZ", "MaxZ"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabLocatorType() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabLocatorType(LocatorType pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return LocatorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["LocatorTypeId"];
			LocatorTypeId = long.Parse(val);

			val = pData["MinX"];
			MinX = double.Parse(val);

			val = pData["MaxX"];
			MaxX = double.Parse(val);

			val = pData["MinY"];
			MinY = double.Parse(val);

			val = pData["MaxY"];
			MaxY = double.Parse(val);

			val = pData["MinZ"];
			MinZ = double.Parse(val);

			val = pData["MaxZ"];
			MaxZ = double.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(LocatorType pNode) {
			base.FillWithNode(pNode);
			LocatorTypeId = pNode.LocatorTypeId;
			MinX = pNode.MinX;
			MaxX = pNode.MaxX;
			MinY = pNode.MinY;
			MaxY = pNode.MaxY;
			MinZ = pNode.MinZ;
			MaxZ = pNode.MaxZ;
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
		public long Value { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorId", "Value"
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

			val = pData["Value"];
			Value = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(Vector pNode) {
			base.FillWithNode(pNode);
			VectorId = pNode.VectorId;
			Value = pNode.Value;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorType : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long VectorTypeId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public long Min { get; set; }
		
		[DtoProp(IsOptional=false)]
		public long Max { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorTypeId", "Min", "Max"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorType() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorType(VectorType pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorTypeId"];
			VectorTypeId = long.Parse(val);

			val = pData["Min"];
			Min = long.Parse(val);

			val = pData["Max"];
			Max = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(VectorType pNode) {
			base.FillWithNode(pNode);
			VectorTypeId = pNode.VectorTypeId;
			Min = pNode.Min;
			Max = pNode.Max;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorRange : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long VectorRangeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorRangeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorRange() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorRange(VectorRange pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorRangeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorRangeId"];
			VectorRangeId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(VectorRange pNode) {
			base.FillWithNode(pNode);
			VectorRangeId = pNode.VectorRangeId;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorRangeLevel : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long VectorRangeLevelId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public float Position { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorRangeLevelId", "Position"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorRangeLevel() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorRangeLevel(VectorRangeLevel pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorRangeLevelId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorRangeLevelId"];
			VectorRangeLevelId = long.Parse(val);

			val = pData["Position"];
			Position = float.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(VectorRangeLevel pNode) {
			base.FillWithNode(pNode);
			VectorRangeLevelId = pNode.VectorRangeLevelId;
			Position = pNode.Position;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorUnit : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long VectorUnitId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string Symbol { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorUnitId", "Symbol"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorUnit() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorUnit(VectorUnit pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorUnitId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["VectorUnitId"];
			VectorUnitId = long.Parse(val);

			found = pData.TryGetValue("Symbol", out val);
			if ( found ) { Symbol = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(VectorUnit pNode) {
			base.FillWithNode(pNode);
			VectorUnitId = pNode.VectorUnitId;
			Symbol = pNode.Symbol;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorUnitPrefix : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long VectorUnitPrefixId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public string Symbol { get; set; }
		
		[DtoProp(IsOptional=false)]
		public double Amount { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorUnitPrefixId", "Symbol", "Amount"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorUnitPrefix() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorUnitPrefix(VectorUnitPrefix pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorUnitPrefixId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["VectorUnitPrefixId"];
			VectorUnitPrefixId = long.Parse(val);

			found = pData.TryGetValue("Symbol", out val);
			if ( found ) { Symbol = val; }

			val = pData["Amount"];
			Amount = double.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(VectorUnitPrefix pNode) {
			base.FillWithNode(pNode);
			VectorUnitPrefixId = pNode.VectorUnitPrefixId;
			Symbol = pNode.Symbol;
			Amount = pNode.Amount;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorUnitDerived : FabNodeForType {
		
		[DtoProp(IsOptional=false)]
		public long VectorUnitDerivedId { get; set; }
		
		[DtoProp(IsOptional=false)]
		public int Exponent { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorUnitDerivedId", "Exponent"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorUnitDerived() {}
		
		/*--------------------------------------------------------------------------------------------*/
		public FabVectorUnitDerived(VectorUnitDerived pNode) : this() {
			FillWithNode(pNode);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorUnitDerivedId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorUnitDerivedId"];
			VectorUnitDerivedId = long.Parse(val);

			val = pData["Exponent"];
			Exponent = int.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void FillWithNode(VectorUnitDerived pNode) {
			base.FillWithNode(pNode);
			VectorUnitDerivedId = pNode.VectorUnitDerivedId;
			Exponent = pNode.Exponent;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

}