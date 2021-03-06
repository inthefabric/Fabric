﻿using Fabric.Domain.Schemas.Utils;

namespace Fabric.Domain.Schemas.Vertices {
	
	/*================================================================================================*/
	public class ClassSchema : ArtifactSchema {

		public DomainProperty<string> Name { get; private set; }
		public DomainProperty<string> NameKey { get; private set; }
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
		public ClassSchema() {
			Names = new NameProvider("Class", "Classes", "c");
			GetAccess = Access.All;
			CreateAccess = Access.All;
			DeleteAccess = Access.CreatorUserAndApp;
			IsAbstract = false;
			CustomCreate = true;

			////

			Name = new DomainProperty<string>("Name", "c_na");
			Name.IsElastic = true;

			NameKey = new DomainProperty<string>("NameKey", "c_nk");
			NameKey.ToLowerCase = true;
			NameKey.IsIndexed = true;
			Name.ExactIndexVia = NameKey;

			Disamb = new DomainProperty<string>("Disamb", "c_di");
			Disamb.IsNullable = true;
			Disamb.IsElastic = true;

			Note = new DomainProperty<string>("Note", "c_no");
			Note.IsNullable = true;

			////

			FabName = new ApiProperty<string>("Name");
			FabName.SetOpenAccess();
			FabName.LenMin = 1;
			FabName.LenMax = 128;
			FabName.ValidRegex = ApiProperty.ValidTitleRegex;
			FabName.TraversalHas = Matching.None;

			FabDisamb = new ApiProperty<string>("Disamb");
			FabDisamb.SetOpenAccess();
			FabDisamb.IsNullable = true;
			FabDisamb.LenMin = 1;
			FabDisamb.LenMax = 128;
			FabDisamb.ValidRegex = ApiProperty.ValidTitleRegex;
			FabDisamb.TraversalHas = Matching.None;

			FabNote = new ApiProperty<string>("Note");
			FabNote.SetOpenAccess();
			FabNote.IsNullable = true;
			FabNote.LenMin = 1;
			FabNote.LenMax = 256;
			FabNote.TraversalHas = Matching.None;

			////

			FabNameMap = new PropertyMapping<string, string>(Name, FabName, CustomDir.ApiToDomain);
			FabNameMap.ApiToDomainNote = "Set Domain.NameKey = Api.Name.ToLower()";

			FabDisambMap = new PropertyMapping<string, string>(Disamb, FabDisamb);
			FabNoteMap = new PropertyMapping<string, string>(Note, FabNote);
		}

	}

}