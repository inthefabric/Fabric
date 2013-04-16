﻿// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 4/16/2013 11:30:02 AM

using System;
using System.Collections.Generic;
using System.Linq;
using Fabric.Domain;
using Fabric.Infrastructure.Db;

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
		
		private static readonly List<string> AvailNodeProps = new List<string> {
			"FactorId", "FactorAssertionId", "IsDefining", "Created", "Completed", "Note", "Descriptor.TypeId", "Director.TypeId", "Director.PrimaryActionId", "Director.RelatedActionId", "Eventor.TypeId", "Eventor.PrecisionId", "Eventor.DateTime", "Identor.TypeId", "Identor.Value", "Locator.TypeId", "Locator.ValueX", "Locator.ValueY", "Locator.ValueZ", "Vector.TypeId", "Vector.UnitId", "Vector.UnitPrefixId", "Vector.Value"
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
			if ( found ) {
				if ( Descriptor == null ) { Descriptor = new FabDescriptor(); }
				Descriptor.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("Director_TypeId", out val);
			if ( found ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("Director_PrimaryActionId", out val);
			if ( found ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.PrimaryActionId = byte.Parse(val);
			}

			found = pData.TryGetValue("Director_RelatedActionId", out val);
			if ( found ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.RelatedActionId = byte.Parse(val);
			}

			found = pData.TryGetValue("Eventor_TypeId", out val);
			if ( found ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("Eventor_PrecisionId", out val);
			if ( found ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.PrecisionId = byte.Parse(val);
			}

			found = pData.TryGetValue("Eventor_DateTime", out val);
			if ( found ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.DateTime = long.Parse(val);
			}

			found = pData.TryGetValue("Identor_TypeId", out val);
			if ( found ) {
				if ( Identor == null ) { Identor = new FabIdentor(); }
				Identor.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("Identor_Value", out val);
			if ( found ) { Identor.Value = val; }

			found = pData.TryGetValue("Locator_TypeId", out val);
			if ( found ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("Locator_ValueX", out val);
			if ( found ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueX = double.Parse(val);
			}

			found = pData.TryGetValue("Locator_ValueY", out val);
			if ( found ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueY = double.Parse(val);
			}

			found = pData.TryGetValue("Locator_ValueZ", out val);
			if ( found ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueZ = double.Parse(val);
			}

			found = pData.TryGetValue("Vector_TypeId", out val);
			if ( found ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.TypeId = byte.Parse(val);
			}

			found = pData.TryGetValue("Vector_UnitId", out val);
			if ( found ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.UnitId = byte.Parse(val);
			}

			found = pData.TryGetValue("Vector_UnitPrefixId", out val);
			if ( found ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.UnitPrefixId = byte.Parse(val);
			}

			found = pData.TryGetValue("Vector_Value", out val);
			if ( found ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.Value = long.Parse(val);
			}
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

			if ( pNode.Descriptor_TypeId != null ) {
				if ( Descriptor == null ) { Descriptor = new FabDescriptor(); }
				Descriptor.TypeId = (byte)pNode.Descriptor_TypeId;
			}

			if ( pNode.Director_TypeId != null ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.TypeId = (byte)pNode.Director_TypeId;
			}

			if ( pNode.Director_PrimaryActionId != null ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.PrimaryActionId = (byte)pNode.Director_PrimaryActionId;
			}

			if ( pNode.Director_RelatedActionId != null ) {
				if ( Director == null ) { Director = new FabDirector(); }
				Director.RelatedActionId = (byte)pNode.Director_RelatedActionId;
			}

			if ( pNode.Eventor_TypeId != null ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.TypeId = (byte)pNode.Eventor_TypeId;
			}

			if ( pNode.Eventor_PrecisionId != null ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.PrecisionId = (byte)pNode.Eventor_PrecisionId;
			}

			if ( pNode.Eventor_DateTime != null ) {
				if ( Eventor == null ) { Eventor = new FabEventor(); }
				Eventor.DateTime = (long)pNode.Eventor_DateTime;
			}

			if ( pNode.Identor_TypeId != null ) {
				if ( Identor == null ) { Identor = new FabIdentor(); }
				Identor.TypeId = (byte)pNode.Identor_TypeId;
			}

			if ( pNode.Identor_Value != null ) {
				if ( Identor == null ) { Identor = new FabIdentor(); }
				Identor.Value = (string)pNode.Identor_Value;
			}

			if ( pNode.Locator_TypeId != null ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.TypeId = (byte)pNode.Locator_TypeId;
			}

			if ( pNode.Locator_ValueX != null ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueX = (double)pNode.Locator_ValueX;
			}

			if ( pNode.Locator_ValueY != null ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueY = (double)pNode.Locator_ValueY;
			}

			if ( pNode.Locator_ValueZ != null ) {
				if ( Locator == null ) { Locator = new FabLocator(); }
				Locator.ValueZ = (double)pNode.Locator_ValueZ;
			}

			if ( pNode.Vector_TypeId != null ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.TypeId = (byte)pNode.Vector_TypeId;
			}

			if ( pNode.Vector_UnitId != null ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.UnitId = (byte)pNode.Vector_UnitId;
			}

			if ( pNode.Vector_UnitPrefixId != null ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.UnitPrefixId = (byte)pNode.Vector_UnitPrefixId;
			}

			if ( pNode.Vector_Value != null ) {
				if ( Vector == null ) { Vector = new FabVector(); }
				Vector.Value = (long)pNode.Vector_Value;
			}
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected override List<string> AvailableProps {
			get { return base.AvailableProps.Concat(AvailNodeProps).ToList(); }
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