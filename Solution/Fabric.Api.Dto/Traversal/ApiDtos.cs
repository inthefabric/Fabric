// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 2/11/2013 3:18:01 PM

using System.Collections.Generic;
using System.Linq;

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
		
		[DtoProp(IsOptional=false)]
		public long Performed { get; set; }
		
		[DtoProp(IsOptional=true)]
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
		
		[DtoProp(IsOptional=false)]
		public int RootId { get; set; }
		
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
			RootId = int.Parse(val);
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
		
		[DtoProp(IsOptional=false)]
		public long ArtifactTypeId { get; set; }
		
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
			ArtifactTypeId = long.Parse(val);
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
		
		[DtoProp(IsOptional=false)]
		public long MemberTypeId { get; set; }
		
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
			MemberTypeId = long.Parse(val);
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
		
		[DtoProp(IsOptional=false)]
		public long UserId { get; set; }
		
		[DtoProp(IsOptional=false)]
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
		protected override long TypeId { get { return FactorAssertionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["FactorAssertionId"];
			FactorAssertionId = long.Parse(val);
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
		
		[DtoProp(IsOptional=false)]
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
		
		[DtoProp(IsOptional=false)]
		public long DescriptorTypeId { get; set; }
		
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
			DescriptorTypeId = long.Parse(val);
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
		
		[DtoProp(IsOptional=false)]
		public long DirectorTypeId { get; set; }
		
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
			DirectorTypeId = long.Parse(val);
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
		protected override long TypeId { get { return DirectorActionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DirectorActionId"];
			DirectorActionId = long.Parse(val);
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
		
		[DtoProp(IsOptional=false)]
		public long EventorTypeId { get; set; }
		
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
			EventorTypeId = long.Parse(val);
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
		protected override long TypeId { get { return EventorPrecisionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["EventorPrecisionId"];
			EventorPrecisionId = long.Parse(val);
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
		
		[DtoProp(IsOptional=false)]
		public long IdentorTypeId { get; set; }
		
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
			IdentorTypeId = long.Parse(val);
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
		protected override long TypeId { get { return VectorRangeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(IDictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorRangeId"];
			VectorRangeId = long.Parse(val);
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
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
		}

	}

}