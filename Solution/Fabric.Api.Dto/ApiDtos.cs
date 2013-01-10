// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/10/2013 1:59:43 PM

using System.Collections.Generic;
using System.Linq;

namespace Fabric.Api.Dto {
	
	/*================================================================================================*/
	public abstract class FabNodeForType : FabNode {
	
		public string Name { get; set; }
		public string Description { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"Name", "Description"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public abstract class FabNodeForAction : FabNode {
	
		public long Performed { get; set; }
		public string Note { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"Performed", "Note"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override void FillResultData(IDictionary<string,string> pData) {
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabRoot : FabNode {
	
		public byte RootId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"RootId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return RootId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;

			val = pData["RootId"];
			RootId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabApp : FabArtifactOwnerNode {
	
		public long AppId { get; set; }
		public string Name { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"AppId", "Name"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabArtifact : FabNode {
	
		public long ArtifactId { get; set; }
		public bool IsPrivate { get; set; }
		public long Created { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"ArtifactId", "IsPrivate", "Created"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabArtifactType : FabNodeForType {
	
		public byte ArtifactTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"ArtifactTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return ArtifactTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["ArtifactTypeId"];
			ArtifactTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabCrowd : FabArtifactOwnerNode {
	
		public long CrowdId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsPrivate { get; set; }
		public bool IsInviteOnly { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"CrowdId", "Name", "Description", "IsPrivate", "IsInviteOnly"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return CrowdId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["CrowdId"];
			CrowdId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("Description", out val);
			if ( found ) { Description = val; }

			val = pData["IsPrivate"];
			IsPrivate = bool.Parse(val);

			val = pData["IsInviteOnly"];
			IsInviteOnly = bool.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabCrowdian : FabNode {
	
		public long CrowdianId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"CrowdianId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return CrowdianId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;

			val = pData["CrowdianId"];
			CrowdianId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabCrowdianType : FabNodeForType {
	
		public byte CrowdianTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"CrowdianTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return CrowdianTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["CrowdianTypeId"];
			CrowdianTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabCrowdianTypeAssign : FabNodeForAction {
	
		public long CrowdianTypeAssignId { get; set; }
		public float Weight { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"CrowdianTypeAssignId", "Weight"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return CrowdianTypeAssignId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["CrowdianTypeAssignId"];
			CrowdianTypeAssignId = long.Parse(val);

			val = pData["Weight"];
			Weight = float.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabLabel : FabArtifactOwnerNode {
	
		public long LabelId { get; set; }
		public string Name { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"LabelId", "Name"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return LabelId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["LabelId"];
			LabelId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabMember : FabNode {
	
		public long MemberId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"MemberId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;

			val = pData["MemberId"];
			MemberId = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabMemberType : FabNodeForType {
	
		public byte MemberTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"MemberTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["MemberTypeId"];
			MemberTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabMemberTypeAssign : FabNodeForAction {
	
		public long MemberTypeAssignId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"MemberTypeAssignId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabThing : FabArtifactOwnerNode {
	
		public long ThingId { get; set; }
		public bool IsClass { get; set; }
		public string Name { get; set; }
		public string Disamb { get; set; }
		public string Note { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"ThingId", "IsClass", "Name", "Disamb", "Note"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return ThingId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["ThingId"];
			ThingId = long.Parse(val);

			val = pData["IsClass"];
			IsClass = bool.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("Disamb", out val);
			if ( found ) { Disamb = val; }

			found = pData.TryGetValue("Note", out val);
			if ( found ) { Note = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabUrl : FabArtifactOwnerNode {
	
		public long UrlId { get; set; }
		public string Name { get; set; }
		public string AbsoluteUrl { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"UrlId", "Name", "AbsoluteUrl"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabUser : FabArtifactOwnerNode {
	
		public long UserId { get; set; }
		public string Name { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"UserId", "Name"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabFactor : FabNode {
	
		public long FactorId { get; set; }
		public bool IsPublic { get; set; }
		public bool IsDefining { get; set; }
		public long Created { get; set; }
		public long? Completed { get; set; }
		public string Note { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"FactorId", "IsPublic", "IsDefining", "Created", "Completed", "Note"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return FactorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			string val;
			bool found;

			val = pData["FactorId"];
			FactorId = long.Parse(val);

			val = pData["IsPublic"];
			IsPublic = bool.Parse(val);

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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabFactorAssertion : FabNodeForType {
	
		public byte FactorAssertionId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"FactorAssertionId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return FactorAssertionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["FactorAssertionId"];
			FactorAssertionId = byte.Parse(val);
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
		protected override void FillResultData(IDictionary<string,string> pData) {
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDescriptor : FabFactorElementNode {
	
		public long DescriptorId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DescriptorId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDescriptorType : FabNodeForType {
	
		public byte DescriptorTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DescriptorTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DescriptorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DescriptorTypeId"];
			DescriptorTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDirector : FabFactorElementNode {
	
		public long DirectorId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DirectorId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDirectorType : FabNodeForType {
	
		public byte DirectorTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DirectorTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DirectorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DirectorTypeId"];
			DirectorTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabDirectorAction : FabNodeForType {
	
		public byte DirectorActionId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"DirectorActionId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DirectorActionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DirectorActionId"];
			DirectorActionId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabEventor : FabFactorElementNode {
	
		public long EventorId { get; set; }
		public long DateTime { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"EventorId", "DateTime"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabEventorType : FabNodeForType {
	
		public byte EventorTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"EventorTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return EventorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["EventorTypeId"];
			EventorTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabEventorPrecision : FabNodeForType {
	
		public byte EventorPrecisionId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"EventorPrecisionId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return EventorPrecisionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["EventorPrecisionId"];
			EventorPrecisionId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabIdentor : FabFactorElementNode {
	
		public long IdentorId { get; set; }
		public string Value { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"IdentorId", "Value"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabIdentorType : FabNodeForType {
	
		public byte IdentorTypeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"IdentorTypeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return IdentorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["IdentorTypeId"];
			IdentorTypeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabLocator : FabFactorElementNode {
	
		public long LocatorId { get; set; }
		public double ValueX { get; set; }
		public double ValueY { get; set; }
		public double ValueZ { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"LocatorId", "ValueX", "ValueY", "ValueZ"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabLocatorType : FabNodeForType {
	
		public byte LocatorTypeId { get; set; }
		public double MinX { get; set; }
		public double MaxX { get; set; }
		public double MinY { get; set; }
		public double MaxY { get; set; }
		public double MinZ { get; set; }
		public double MaxZ { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"LocatorTypeId", "MinX", "MaxX", "MinY", "MaxY", "MinZ", "MaxZ"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return LocatorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["LocatorTypeId"];
			LocatorTypeId = byte.Parse(val);

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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVector : FabFactorElementNode {
	
		public long VectorId { get; set; }
		public long Value { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorId", "Value"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorType : FabNodeForType {
	
		public byte VectorTypeId { get; set; }
		public long Min { get; set; }
		public long Max { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorTypeId", "Min", "Max"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorTypeId"];
			VectorTypeId = byte.Parse(val);

			val = pData["Min"];
			Min = long.Parse(val);

			val = pData["Max"];
			Max = long.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorRange : FabNodeForType {
	
		public byte VectorRangeId { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorRangeId"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorRangeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorRangeId"];
			VectorRangeId = byte.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorRangeLevel : FabNodeForType {
	
		public byte VectorRangeLevelId { get; set; }
		public float Position { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorRangeLevelId", "Position"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorRangeLevelId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorRangeLevelId"];
			VectorRangeLevelId = byte.Parse(val);

			val = pData["Position"];
			Position = float.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorUnit : FabNodeForType {
	
		public byte VectorUnitId { get; set; }
		public string Symbol { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorUnitId", "Symbol"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorUnitId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["VectorUnitId"];
			VectorUnitId = byte.Parse(val);

			found = pData.TryGetValue("Symbol", out val);
			if ( found ) { Symbol = val; }
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorUnitPrefix : FabNodeForType {
	
		public byte VectorUnitPrefixId { get; set; }
		public string Symbol { get; set; }
		public double Amount { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorUnitPrefixId", "Symbol", "Amount"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorUnitPrefixId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["VectorUnitPrefixId"];
			VectorUnitPrefixId = byte.Parse(val);

			found = pData.TryGetValue("Symbol", out val);
			if ( found ) { Symbol = val; }

			val = pData["Amount"];
			Amount = double.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

	/*================================================================================================*/
	public class FabVectorUnitDerived : FabNodeForType {
	
		public byte VectorUnitDerivedId { get; set; }
		public int Exponent { get; set; }
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"VectorUnitDerivedId", "Exponent"
		};


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorUnitDerivedId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorUnitDerivedId"];
			VectorUnitDerivedId = byte.Parse(val);

			val = pData["Exponent"];
			Exponent = int.Parse(val);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

}