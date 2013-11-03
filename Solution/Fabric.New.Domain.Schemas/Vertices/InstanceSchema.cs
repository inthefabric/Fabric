﻿using Fabric.New.Domain.Schemas.Utils;

namespace Fabric.New.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class InstanceSchema : ArtifactSchema {

		public DomainProperty<string> Name { get; private set; }
		public DomainProperty<string> Disamb { get; private set; }
		public DomainProperty<string> Note { get; private set; }

		public ApiProperty<string> FabName { get; private set; }
		public ApiProperty<string> FabDisamb { get; private set; }
		public ApiProperty<string> FabNote { get; private set; }

		public PropertyMapping<string, string> FabNameMap { get; private set; }
		public PropertyMapping<string, string> FabDisambMap { get; private set; }
		public PropertyMapping<string, string> FabNoteMap { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceSchema() {
			Names = new NameProvider("Instance", "Instances", "i");
			DeleteAccess = Access.CreatorUserAndApp;

			////

			Name = new DomainProperty<string>("Name", "i.na");
			Name.IsNullable = true;
			Name.IsElastic = true;

			Disamb = new DomainProperty<string>("Disamb", "i.di");
			Disamb.IsNullable = true;
			Disamb.IsElastic = true;

			Note = new DomainProperty<string>("Note", "i.no");
			Note.IsNullable = true;

			////

			FabName = new ApiProperty<string>("Name");
			FabName.SetOpenAccess();
			FabName.IsNullable = true;
			FabName.LenMin = 1;
			FabName.LenMax = 128;
			FabName.ValidRegex = ApiProperty.ValidTitleRegex;

			FabDisamb = new ApiProperty<string>("Disamb");
			FabDisamb.SetOpenAccess();
			FabDisamb.IsNullable = true;
			FabDisamb.LenMin = 1;
			FabDisamb.LenMax = 128;
			FabDisamb.ValidRegex = ApiProperty.ValidTitleRegex;

			FabNote = new ApiProperty<string>("Note");
			FabNote.SetOpenAccess();
			FabNote.IsNullable = true;
			FabNote.LenMin = 1;
			FabNote.LenMax = 256;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName);
			FabDisambMap = new PropertyMapping<string, string>(Disamb, FabDisamb);
			FabNoteMap = new PropertyMapping<string, string>(Note, FabNote);
		}

	}

}