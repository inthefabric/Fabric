// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/25/2013 2:43:16 PM

using System.Collections.Generic;
using Fabric.Api.Dto.Spec;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public partial class SpecDoc {
	
		/*--------------------------------------------------------------------------------------------*/
		public List<FabSpecDto> BuildDtoList() {
			var list = new List<FabSpecDto>();
			
			FabSpecDto dto;
			FabSpecDtoProp p;
			FabSpecDtoLink l;

			////

			dto = new FabSpecDto();
			dto.Name = "FabNodeForType";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("NodeForType");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("NodeForType_Name");
				p.IsUnique = true;
				p.LenMax = 32;
				p.LenMin = 1;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Description";
				p.Type = "string";
				p.Description = GetDtoPropText("NodeForType_Description");
				p.LenMax = 256;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

			////

			dto = new FabSpecDto();
			dto.Name = "FabNodeForAction";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("NodeForAction");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "Performed";
				p.Type = "long";
				p.Description = GetDtoPropText("NodeForAction_Performed");
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Note";
				p.Type = "string";
				p.Description = GetDtoPropText("NodeForAction_Note");
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

			////

			dto = new FabSpecDto();
			dto.Name = "FabArtifactOwnerNode";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("ArtifactOwnerNode");
			list.Add(dto);
	
			////

			dto = new FabSpecDto();
			dto.Name = "FabRoot";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("Root");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "RootId";
				p.Type = "int";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "ContainsAppList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsApp";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsArtifactList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsArtifactTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsArtifactType";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsClassList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsClass";
					l.ToDto = "FabClass";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsInstanceList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsInstance";
					l.ToDto = "FabInstance";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsMemberList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsMember";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsMemberTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsMemberType";
					l.ToDto = "FabMemberType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsUrlList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsUrl";
					l.ToDto = "FabUrl";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsUserList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsUser";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsFactorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsFactorAssertionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsFactorAssertion";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDescriptorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDescriptor";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDescriptorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDescriptorType";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDirectorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDirector";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDirectorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDirectorType";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDirectorActionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsEventorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsEventor";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsEventorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsEventorType";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsEventorPrecisionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsEventorPrecision";
					l.ToDto = "FabEventorPrecision";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsIdentorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsIdentor";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsIdentorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsIdentorType";
					l.ToDto = "FabIdentorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsLocatorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsLocator";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsLocatorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsLocatorType";
					l.ToDto = "FabLocatorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVector";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorType";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorRangeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorRange";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorRangeLevelList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorRangeLevel";
					l.ToDto = "FabVectorRangeLevel";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorUnitList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorUnitPrefixList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorUnitPrefix";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorUnitDerivedList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorUnitDerived";
					l.ToDto = "FabVectorUnitDerived";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

			////

			dto = new FabSpecDto();
			dto.Name = "FabApp";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("App");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "AppId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("App_Name");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 64;
				p.LenMin = 3;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "AppHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "DefinesMemberList";
					l.IsOutgoing = true;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOneOrMore";
					l.Verb = "AppDefinesMember";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabArtifact";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("Artifact");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "ArtifactId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "IsPrivate";
				p.Type = "bool";
				p.Description = GetDtoPropText("Artifact_IsPrivate");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Created";
				p.Type = "long";
				p.Description = GetDtoPropText("Artifact_Created");
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InAppHas";
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "AppHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesArtifactType";
					l.IsOutgoing = true;
					l.FromDto = "FabArtifact";
					l.FromDtoConn = "OutToOne";
					l.Verb = "ArtifactUsesArtifactType";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InClassHas";
					l.IsOutgoing = false;
					l.FromDto = "FabClass";
					l.FromDtoConn = "OutToOne";
					l.Verb = "ClassHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InInstanceHas";
					l.IsOutgoing = false;
					l.FromDto = "FabInstance";
					l.FromDtoConn = "OutToOne";
					l.Verb = "InstanceHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InUrlHas";
					l.IsOutgoing = false;
					l.FromDto = "FabUrl";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UrlHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InUserHas";
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UserHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUsesPrimary";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesPrimaryArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUsesRelated";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesRelatedArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InDescriptorListRefinesPrimaryWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesPrimaryWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InDescriptorListRefinesRelatedWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesRelatedWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InDescriptorListRefinesTypeWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesTypeWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InVectorListUsesAxis";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesAxisArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabArtifactType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("ArtifactType");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "ArtifactTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InArtifactListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabArtifact";
					l.FromDtoConn = "OutToOne";
					l.Verb = "ArtifactUsesArtifactType";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabClass";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("Class");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "ClassId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Class_Name");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Disamb";
				p.Type = "string";
				p.Description = GetDtoPropText("Class_Disamb");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Note";
				p.Type = "string";
				p.Description = GetDtoPropText("Class_Note");
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabClass";
					l.FromDtoConn = "OutToOne";
					l.Verb = "ClassHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabInstance";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("Instance");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "InstanceId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Instance_Name");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Disamb";
				p.Type = "string";
				p.Description = GetDtoPropText("Instance_Disamb");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Note";
				p.Type = "string";
				p.Description = GetDtoPropText("Instance_Note");
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabInstance";
					l.FromDtoConn = "OutToOne";
					l.Verb = "InstanceHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabMember";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("Member");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "MemberId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InAppDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOneOrMore";
					l.Verb = "AppDefinesMember";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "HasMemberTypeAssign";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "MemberHasMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "HasHistoricMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberHasHistoricMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "CreatesArtifactList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "CreatesMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "CreatesFactorList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InUserDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOneOrMore";
					l.Verb = "UserDefinesMember";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabMemberType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("MemberType");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "MemberTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InMemberTypeAssignListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabMemberTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Verb = "MemberTypeAssignUsesMemberType";
					l.ToDto = "FabMemberType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabMemberTypeAssign";
			dto.Extends = "FabNodeForAction";
			dto.Description = GetDtoText("MemberTypeAssign");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "MemberTypeAssignId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InMemberHas";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "MemberHasMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InMemberHasHistoric";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberHasHistoricMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesMemberType";
					l.IsOutgoing = true;
					l.FromDto = "FabMemberTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Verb = "MemberTypeAssignUsesMemberType";
					l.ToDto = "FabMemberType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabUrl";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("Url");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "UrlId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Url_Name");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "AbsoluteUrl";
				p.Type = "string";
				p.Description = GetDtoPropText("Url_AbsoluteUrl");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 2048;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabUrl";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UrlHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabUser";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("User");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "UserId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("User_Name");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 16;
				p.ValidRegex = @"^[a-zA-Z0-9_]*$";
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UserHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "DefinesMemberList";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOneOrMore";
					l.Verb = "UserDefinesMember";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabFactor";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("Factor");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "FactorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "IsDefining";
				p.Type = "bool";
				p.Description = GetDtoPropText("Factor_IsDefining");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Created";
				p.Type = "long";
				p.Description = GetDtoPropText("Factor_Created");
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Completed";
				p.Type = "long?";
				p.Description = GetDtoPropText("Factor_Completed");
				p.IsNullable = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Note";
				p.Type = "string";
				p.Description = GetDtoPropText("Factor_Note");
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesPrimaryArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesPrimaryArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesRelatedArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesRelatedArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesFactorAssertion";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesFactorAssertion";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ReplacesFactor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorReplacesFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesDescriptor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesDescriptor";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesDirector";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesDirector";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesEventor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesEventor";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesIdentor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesIdentor";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesLocator";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesLocator";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVector";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesVector";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabFactorAssertion";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("FactorAssertion");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "FactorAssertionId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesFactorAssertion";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabFactorElementNode";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("FactorElementNode");
			list.Add(dto);
	
			////

			dto = new FabSpecDto();
			dto.Name = "FabDescriptor";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Descriptor");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "DescriptorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesDescriptor";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesDescriptorType";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DescriptorUsesDescriptorType";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "RefinesPrimaryWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesPrimaryWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "RefinesRelatedWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesRelatedWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "RefinesTypeWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesTypeWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabDescriptorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("DescriptorType");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "DescriptorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InDescriptorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DescriptorUsesDescriptorType";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabDirector";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Director");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "DirectorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesDirector";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesDirectorType";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesDirectorType";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesPrimaryDirectorAction";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesPrimaryDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesRelatedDirectorAction";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesRelatedDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabDirectorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("DirectorType");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "DirectorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InDirectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesDirectorType";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabDirectorAction";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("DirectorAction");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "DirectorActionId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InDirectorListUsesPrimary";
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesPrimaryDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InDirectorListUsesRelated";
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesRelatedDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabEventor";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Eventor");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "EventorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "DateTime";
				p.Type = "long";
				p.Description = GetDtoPropText("Eventor_DateTime");
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesEventor";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesEventorType";
					l.IsOutgoing = true;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "EventorUsesEventorType";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesEventorPrecision";
					l.IsOutgoing = true;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "EventorUsesEventorPrecision";
					l.ToDto = "FabEventorPrecision";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabEventorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("EventorType");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "EventorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InEventorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "EventorUsesEventorType";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabEventorPrecision";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("EventorPrecision");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "EventorPrecisionId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InEventorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "EventorUsesEventorPrecision";
					l.ToDto = "FabEventorPrecision";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabIdentor";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Identor");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "IdentorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Value";
				p.Type = "string";
				p.Description = GetDtoPropText("Identor_Value");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesIdentor";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesIdentorType";
					l.IsOutgoing = true;
					l.FromDto = "FabIdentor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "IdentorUsesIdentorType";
					l.ToDto = "FabIdentorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabIdentorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("IdentorType");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "IdentorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InIdentorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabIdentor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "IdentorUsesIdentorType";
					l.ToDto = "FabIdentorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabLocator";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Locator");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "LocatorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "ValueX";
				p.Type = "double";
				p.Description = GetDtoPropText("Locator_ValueX");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "ValueY";
				p.Type = "double";
				p.Description = GetDtoPropText("Locator_ValueY");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "ValueZ";
				p.Type = "double";
				p.Description = GetDtoPropText("Locator_ValueZ");
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesLocator";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesLocatorType";
					l.IsOutgoing = true;
					l.FromDto = "FabLocator";
					l.FromDtoConn = "OutToOne";
					l.Verb = "LocatorUsesLocatorType";
					l.ToDto = "FabLocatorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabLocatorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("LocatorType");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "LocatorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "MinX";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MinX");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "MaxX";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MaxX");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "MinY";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MinY");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "MaxY";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MaxY");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "MinZ";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MinZ");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "MaxZ";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MaxZ");
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InLocatorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabLocator";
					l.FromDtoConn = "OutToOne";
					l.Verb = "LocatorUsesLocatorType";
					l.ToDto = "FabLocatorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabVector";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Vector");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "VectorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Value";
				p.Type = "long";
				p.Description = GetDtoPropText("Vector_Value");
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesVector";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesAxisArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesAxisArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorType";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorType";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorUnitPrefix";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnitPrefix";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabVectorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorType");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "VectorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Min";
				p.Type = "long";
				p.Description = GetDtoPropText("VectorType_Min");
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Max";
				p.Type = "long";
				p.Description = GetDtoPropText("VectorType_Max");
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorType";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorRange";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorType";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorTypeUsesVectorRange";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabVectorRange";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorRange");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "VectorRangeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InVectorTypeListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorType";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorTypeUsesVectorRange";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorRangeLevelList";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorRange";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "VectorRangeUsesVectorRangeLevel";
					l.ToDto = "FabVectorRangeLevel";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabVectorRangeLevel";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorRangeLevel");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "VectorRangeLevelId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Position";
				p.Type = "float";
				p.Description = GetDtoPropText("VectorRangeLevel_Position");
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InVectorRangeListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorRange";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "VectorRangeUsesVectorRangeLevel";
					l.ToDto = "FabVectorRangeLevel";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabVectorUnit";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorUnit");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "VectorUnitId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Symbol";
				p.Type = "string";
				p.Description = GetDtoPropText("VectorUnit_Symbol");
				p.LenMax = 8;
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InVectorUnitDerivedListDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedDefinesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InVectorUnitDerivedListRaisesToExp";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedRaisesToExpVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabVectorUnitPrefix";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorUnitPrefix");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "VectorUnitPrefixId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Symbol";
				p.Type = "string";
				p.Description = GetDtoPropText("VectorUnitPrefix_Symbol");
				p.LenMax = 8;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Amount";
				p.Type = "double";
				p.Description = GetDtoPropText("VectorUnitPrefix_Amount");
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnitPrefix";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InVectorUnitDerivedListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedUsesVectorUnitPrefix";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new FabSpecDto();
			dto.Name = "FabVectorUnitDerived";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorUnitDerived");
			list.Add(dto);
	
				p = new FabSpecDtoProp();
				p.Name = "VectorUnitDerivedId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Exponent";
				p.Type = "int";
				p.Description = GetDtoPropText("VectorUnitDerived_Exponent");
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "DefinesVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedDefinesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "RaisesToExpVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedRaisesToExpVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorUnitPrefix";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedUsesVectorUnitPrefix";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			return list;
		}

	}

}