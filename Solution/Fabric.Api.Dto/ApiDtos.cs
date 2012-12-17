// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 12/17/2012 2:55:53 PM

using System.Collections.Generic;

namespace Fabric.Api.Dto {
	
	/*================================================================================================*/
	public abstract class FabNodeForType : FabNode {
	
		//[PropIsUnique(True)]
		//[PropLenMax(32)]
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public string Name { get; set; } //[]

		//[PropLenMax(256)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public string Description { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			string val;
			bool found;

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }

			found = pData.TryGetValue("Description", out val);
			if ( found ) { Description = val; }
		}

	}

	/*================================================================================================*/
	public abstract class FabNodeForAction : FabNode {
	
		//[PropIsTimestamp(True)]
		public long Performed { get; set; } //[]

		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		public string Note { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			string val;
			bool found;

			val = pData["Performed"];
			Performed = long.Parse(val);

			found = pData.TryGetValue("Note", out val);
			if ( found ) { Note = val; }
		}

	}

	/*================================================================================================*/
	public abstract class FabArtifactOwnerNode : FabNode {
	
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
		}

	}

	/*================================================================================================*/
	public class FabRoot : FabNode {
	
		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return 0; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
		}

	}

	/*================================================================================================*/
	public class FabApp : FabArtifactOwnerNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long AppId { get; set; } //[]

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(64)]
		//[PropLenMin(3)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public string Name { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return AppId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["AppId"];
			AppId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }
		}

	}

	/*================================================================================================*/
	public class FabArtifact : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long ArtifactId { get; set; } //[]

		public bool IsPrivate { get; set; } //[]

		//[PropIsTimestamp(True)]
		public long Created { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return ArtifactId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			string val;

			val = pData["ArtifactId"];
			ArtifactId = long.Parse(val);

			val = pData["IsPrivate"];
			IsPrivate = bool.Parse(val);

			val = pData["Created"];
			Created = long.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabArtifactType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte ArtifactTypeId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return ArtifactTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["ArtifactTypeId"];
			ArtifactTypeId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabCrowd : FabArtifactOwnerNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long CrowdId { get; set; } //[]

		//[PropLenMax(64)]
		//[PropLenMin(3)]
		public string Name { get; set; } //[]

		//[PropLenMax(256)]
		public string Description { get; set; } //[]

		public bool IsPrivate { get; set; } //[]

		public bool IsInviteOnly { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return CrowdId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
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

	}

	/*================================================================================================*/
	public class FabCrowdian : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long CrowdianId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return CrowdianId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			string val;

			val = pData["CrowdianId"];
			CrowdianId = long.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabCrowdianType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte CrowdianTypeId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return CrowdianTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["CrowdianTypeId"];
			CrowdianTypeId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabCrowdianTypeAssign : FabNodeForAction {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long CrowdianTypeAssignId { get; set; } //[]

		public float Weight { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return CrowdianTypeAssignId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["CrowdianTypeAssignId"];
			CrowdianTypeAssignId = long.Parse(val);

			val = pData["Weight"];
			Weight = float.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabLabel : FabArtifactOwnerNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long LabelId { get; set; } //[]

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(128)]
		//[PropLenMin(1)]
		//[PropValidRegex(@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'"<>~]*$")]
		public string Name { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return LabelId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["LabelId"];
			LabelId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }
		}

	}

	/*================================================================================================*/
	public class FabMember : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long MemberId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			string val;

			val = pData["MemberId"];
			MemberId = long.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabMemberType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte MemberTypeId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["MemberTypeId"];
			MemberTypeId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabMemberTypeAssign : FabNodeForAction {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long MemberTypeAssignId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return MemberTypeAssignId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["MemberTypeAssignId"];
			MemberTypeAssignId = long.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabThing : FabArtifactOwnerNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long ThingId { get; set; } //[]

		public bool IsClass { get; set; } //[]

		//[PropLenMax(128)]
		public string Name { get; set; } //[]

		//[PropLenMax(128)]
		public string Disamb { get; set; } //[]

		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		public string Note { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return ThingId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
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

	}

	/*================================================================================================*/
	public class FabUrl : FabArtifactOwnerNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long UrlId { get; set; } //[]

		//[PropLenMax(128)]
		public string Name { get; set; } //[]

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(2048)]
		public string AbsoluteUrl { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return UrlId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
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

	}

	/*================================================================================================*/
	public class FabUser : FabArtifactOwnerNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long UserId { get; set; } //[]

		//[PropIsCaseInsensitive(True)]
		//[PropIsUnique(True)]
		//[PropLenMax(16)]
		//[PropValidRegex(@"^[a-zA-Z0-9_]*$")]
		public string Name { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return UserId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["UserId"];
			UserId = long.Parse(val);

			found = pData.TryGetValue("Name", out val);
			if ( found ) { Name = val; }
		}

	}

	/*================================================================================================*/
	public class FabFactor : FabNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long FactorId { get; set; } //[]

		public bool IsPublic { get; set; } //[]

		public bool IsDefining { get; set; } //[]

		//[PropIsTimestamp(True)]
		public long Created { get; set; } //[]

		//[PropIsNullable(True)]
		public long Completed { get; set; } //[]

		//[PropIsNullable(True)]
		//[PropLenMax(256)]
		public string Note { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return FactorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
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

	}

	/*================================================================================================*/
	public class FabFactorAssertion : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte FactorAssertionId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return FactorAssertionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["FactorAssertionId"];
			FactorAssertionId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public abstract class FabFactorElementNode : FabNode {
	
		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
		}

	}

	/*================================================================================================*/
	public class FabDescriptor : FabFactorElementNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long DescriptorId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DescriptorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DescriptorId"];
			DescriptorId = long.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabDescriptorType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte DescriptorTypeId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DescriptorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DescriptorTypeId"];
			DescriptorTypeId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabDirector : FabFactorElementNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long DirectorId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DirectorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DirectorId"];
			DirectorId = long.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabDirectorType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte DirectorTypeId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DirectorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DirectorTypeId"];
			DirectorTypeId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabDirectorAction : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte DirectorActionId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return DirectorActionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["DirectorActionId"];
			DirectorActionId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabEventor : FabFactorElementNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long EventorId { get; set; } //[]

		public long DateTime { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return EventorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["EventorId"];
			EventorId = long.Parse(val);

			val = pData["DateTime"];
			DateTime = long.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabEventorType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte EventorTypeId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return EventorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["EventorTypeId"];
			EventorTypeId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabEventorPrecision : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte EventorPrecisionId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return EventorPrecisionId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["EventorPrecisionId"];
			EventorPrecisionId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabIdentor : FabFactorElementNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long IdentorId { get; set; } //[]

		//[PropLenMax(128)]
		public string Value { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return IdentorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["IdentorId"];
			IdentorId = long.Parse(val);

			found = pData.TryGetValue("Value", out val);
			if ( found ) { Value = val; }
		}

	}

	/*================================================================================================*/
	public class FabIdentorType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte IdentorTypeId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return IdentorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["IdentorTypeId"];
			IdentorTypeId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabLocator : FabFactorElementNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long LocatorId { get; set; } //[]

		public double ValueX { get; set; } //[]

		public double ValueY { get; set; } //[]

		public double ValueZ { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return LocatorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
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

	}

	/*================================================================================================*/
	public class FabLocatorType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte LocatorTypeId { get; set; } //[]

		public double MinX { get; set; } //[]

		public double MaxX { get; set; } //[]

		public double MinY { get; set; } //[]

		public double MaxY { get; set; } //[]

		public double MinZ { get; set; } //[]

		public double MaxZ { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return LocatorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
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

	}

	/*================================================================================================*/
	public class FabVector : FabFactorElementNode {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public long VectorId { get; set; } //[]

		public long Value { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorId"];
			VectorId = long.Parse(val);

			val = pData["Value"];
			Value = long.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabVectorType : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorTypeId { get; set; } //[]

		public long Min { get; set; } //[]

		public long Max { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorTypeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorTypeId"];
			VectorTypeId = byte.Parse(val);

			val = pData["Min"];
			Min = long.Parse(val);

			val = pData["Max"];
			Max = long.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabVectorRange : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorRangeId { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorRangeId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorRangeId"];
			VectorRangeId = byte.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabVectorRangeLevel : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorRangeLevelId { get; set; } //[]

		public float Position { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorRangeLevelId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorRangeLevelId"];
			VectorRangeLevelId = byte.Parse(val);

			val = pData["Position"];
			Position = float.Parse(val);
		}

	}

	/*================================================================================================*/
	public class FabVectorUnit : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorUnitId { get; set; } //[]

		//[PropLenMax(8)]
		public string Symbol { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorUnitId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;
			bool found;

			val = pData["VectorUnitId"];
			VectorUnitId = byte.Parse(val);

			found = pData.TryGetValue("Symbol", out val);
			if ( found ) { Symbol = val; }
		}

	}

	/*================================================================================================*/
	public class FabVectorUnitPrefix : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorUnitPrefixId { get; set; } //[]

		//[PropLenMax(8)]
		public string Symbol { get; set; } //[]

		public double Amount { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorUnitPrefixId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
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

	}

	/*================================================================================================*/
	public class FabVectorUnitDerived : FabNodeForType {
	
		//[PropIsPrimaryKey(True)]
		//[PropIsUnique(True)]
		public byte VectorUnitDerivedId { get; set; } //[]

		public int Exponent { get; set; } //[]

		/*--------------------------------------------------------------------------------------------*/
		protected override long TypeId { get { return VectorUnitDerivedId; } }

		/*--------------------------------------------------------------------------------------------*/
		protected override void FillResultData(Dictionary<string,string> pData) {
			base.FillResultData(pData);

			string val;

			val = pData["VectorUnitDerivedId"];
			VectorUnitDerivedId = byte.Parse(val);

			val = pData["Exponent"];
			Exponent = int.Parse(val);
		}

	}

}