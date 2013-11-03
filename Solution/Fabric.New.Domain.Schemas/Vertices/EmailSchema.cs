﻿using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class EmailSchema : VertexSchema {

		public DomainProperty<string> Address { get; private set; }
		public DomainProperty<string> Code { get; private set; }
		public DomainProperty<bool> Verified { get; private set; }

		public ApiProperty<string> FabAddress { get; private set; }
		public ApiProperty<string> FabCode { get; private set; }
		public ApiProperty<bool> FabVerified { get; private set; }

		public PropertyMapping<string, string> FabAddressMap { get; private set; }
		public PropertyMapping<string, string> FabCodeMap { get; private set; }
		public PropertyMapping<bool, bool> FabVerifiedMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailSchema() {
			Names = new NameProvider("Email", "Emails", "e");

			////

			Address = new DomainProperty<string>("Address", "e.ad");
			Address.ToLowerCase = true;
			Address.IsIndexed = true;

			Code = new DomainProperty<string>("Code", "e.co");

			Verified = new DomainProperty<bool>("Verified", "e.ve");

			////

			FabAddress = new ApiProperty<string>("Secret");
			FabAddress.LenMin = 1;
			FabAddress.LenMax = 256;
			FabAddress.ToLowerCase = true;
			FabAddress.ValidRegex = ApiProperty.ValidEmailRegex;

			FabCode = new ApiProperty<string>("Code");
			FabCode.LenMin = 32;
			FabCode.LenMax = 32;
			FabCode.ValidRegex = ApiProperty.ValidCodeRegex;

			FabVerified = new ApiProperty<bool>("Verified");

			////

			FabAddressMap = new PropertyMapping<string, string>(Address, FabAddress);
			FabCodeMap = new PropertyMapping<string, string>(Code, FabCode);
			FabVerifiedMap = new PropertyMapping<bool, bool>(Verified, FabVerified);
		}

	}

}