﻿using Fabric.Infrastructure.Data;

namespace Fabric.Api.Dto.Batch {

	/*================================================================================================*/
	public class FabBatchNewFactor : FabBatchNewObject {

		[DtoProp(IsOptional=false)]
		public long PrimaryArtifactId { get; set; }

		[DtoProp(IsOptional=false)]
		public long RelatedArtifactId { get; set; }

		[DtoProp(IsOptional=false)]
		public byte FactorAssertionId { get; set; }

		[DtoProp(IsOptional=false)]
		public bool IsDefining { get; set; }

		[DtoProp(IsOptional=true)]
		public string Note { get; set; }

		////

		[DtoProp(IsOptional=false)]
		public FabBatchNewFactorDescriptor Descriptor { get; set; }

		[DtoProp(IsOptional=true)]
		public FabBatchNewFactorDirector Director { get; set; }

		[DtoProp(IsOptional=true)]
		public FabBatchNewFactorEventor Eventor { get; set; }

		[DtoProp(IsOptional=true)]
		public FabBatchNewFactorIdentor Identor { get; set; }

		[DtoProp(IsOptional=true)]
		public FabBatchNewFactorLocator Locator { get; set; }

		[DtoProp(IsOptional=true)]
		public FabBatchNewFactorVector Vector { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) {}

	}


	/*================================================================================================*/
	public class FabBatchNewFactorDescriptor : FabObject {

		[DtoProp(IsOptional=false)]
		public byte TypeId { get; set; }

		[DtoProp(IsOptional=true)]
		public long? PrimaryArtifactRefineId { get; set; }

		[DtoProp(IsOptional=true)]
		public long? RelatedArtifactRefineId { get; set; }

		[DtoProp(IsOptional=true)]
		public long? TypeRefineId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) { }

	}


	/*================================================================================================*/
	public class FabBatchNewFactorDirector : FabObject {

		[DtoProp(IsOptional=false)]
		public byte TypeId { get; set; }

		[DtoProp(IsOptional=false)]
		public byte PrimaryActionId { get; set; }

		[DtoProp(IsOptional=false)]
		public byte RelatedActionId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) { }

	}


	/*================================================================================================*/
	public class FabBatchNewFactorEventor : FabObject {

		[DtoProp(IsOptional=false)]
		public byte TypeId { get; set; }

		[DtoProp(IsOptional=false)]
		public long Year { get; set; }

		[DtoProp(IsOptional=true)]
		public byte? Month { get; set; }

		[DtoProp(IsOptional=true)]
		public byte? Day { get; set; }

		[DtoProp(IsOptional=true)]
		public byte? Hour { get; set; }

		[DtoProp(IsOptional=true)]
		public byte? Minute { get; set; }

		[DtoProp(IsOptional=true)]
		public byte? Second { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) { }

	}


	/*================================================================================================*/
	public class FabBatchNewFactorIdentor : FabObject {

		[DtoProp(IsOptional=false)]
		public byte TypeId { get; set; }

		[DtoProp(IsOptional=false)]
		public string Value { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) { }

	}


	/*================================================================================================*/
	public class FabBatchNewFactorLocator : FabObject {

		[DtoProp(IsOptional=false)]
		public byte TypeId { get; set; }

		[DtoProp(IsOptional=false)]
		public double ValueX { get; set; }

		[DtoProp(IsOptional=false)]
		public double ValueY { get; set; }

		[DtoProp(IsOptional=false)]
		public double ValueZ { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) { }

	}


	/*================================================================================================*/
	public class FabBatchNewFactorVector : FabObject {

		[DtoProp(IsOptional=false)]
		public byte TypeId { get; set; }

		[DtoProp(IsOptional=false)]
		public byte UnitId { get; set; }

		[DtoProp(IsOptional=false)]
		public byte UnitPrefixId { get; set; }

		[DtoProp(IsOptional=false)]
		public long Value { get; set; }

		[DtoProp(IsOptional=false)]
		public long AxisArtifactId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override void Fill(IDataDto pDto) { }

	}

}