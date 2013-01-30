// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/30/2013 4:50:16 PM

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
					l.Type = "RootContainsApp";
					l.Description = GetDtoLinkText("RootContainsApp");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsArtifactList";
					l.Type = "RootContainsArtifact";
					l.Description = GetDtoLinkText("RootContainsArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsArtifactTypeList";
					l.Type = "RootContainsArtifactType";
					l.Description = GetDtoLinkText("RootContainsArtifactType");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsClassList";
					l.Type = "RootContainsClass";
					l.Description = GetDtoLinkText("RootContainsClass");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabClass";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsInstanceList";
					l.Type = "RootContainsInstance";
					l.Description = GetDtoLinkText("RootContainsInstance");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabInstance";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsMemberList";
					l.Type = "RootContainsMember";
					l.Description = GetDtoLinkText("RootContainsMember");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsMemberTypeList";
					l.Type = "RootContainsMemberType";
					l.Description = GetDtoLinkText("RootContainsMemberType");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabMemberType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsMemberTypeAssignList";
					l.Type = "RootContainsMemberTypeAssign";
					l.Description = GetDtoLinkText("RootContainsMemberTypeAssign");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsUrlList";
					l.Type = "RootContainsUrl";
					l.Description = GetDtoLinkText("RootContainsUrl");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabUrl";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsUserList";
					l.Type = "RootContainsUser";
					l.Description = GetDtoLinkText("RootContainsUser");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsFactorList";
					l.Type = "RootContainsFactor";
					l.Description = GetDtoLinkText("RootContainsFactor");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsFactorAssertionList";
					l.Type = "RootContainsFactorAssertion";
					l.Description = GetDtoLinkText("RootContainsFactorAssertion");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDescriptorList";
					l.Type = "RootContainsDescriptor";
					l.Description = GetDtoLinkText("RootContainsDescriptor");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDescriptorTypeList";
					l.Type = "RootContainsDescriptorType";
					l.Description = GetDtoLinkText("RootContainsDescriptorType");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDirectorList";
					l.Type = "RootContainsDirector";
					l.Description = GetDtoLinkText("RootContainsDirector");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDirectorTypeList";
					l.Type = "RootContainsDirectorType";
					l.Description = GetDtoLinkText("RootContainsDirectorType");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsDirectorActionList";
					l.Type = "RootContainsDirectorAction";
					l.Description = GetDtoLinkText("RootContainsDirectorAction");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsEventorList";
					l.Type = "RootContainsEventor";
					l.Description = GetDtoLinkText("RootContainsEventor");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsEventorTypeList";
					l.Type = "RootContainsEventorType";
					l.Description = GetDtoLinkText("RootContainsEventorType");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsEventorPrecisionList";
					l.Type = "RootContainsEventorPrecision";
					l.Description = GetDtoLinkText("RootContainsEventorPrecision");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabEventorPrecision";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsIdentorList";
					l.Type = "RootContainsIdentor";
					l.Description = GetDtoLinkText("RootContainsIdentor");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsIdentorTypeList";
					l.Type = "RootContainsIdentorType";
					l.Description = GetDtoLinkText("RootContainsIdentorType");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabIdentorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsLocatorList";
					l.Type = "RootContainsLocator";
					l.Description = GetDtoLinkText("RootContainsLocator");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsLocatorTypeList";
					l.Type = "RootContainsLocatorType";
					l.Description = GetDtoLinkText("RootContainsLocatorType");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabLocatorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorList";
					l.Type = "RootContainsVector";
					l.Description = GetDtoLinkText("RootContainsVector");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorTypeList";
					l.Type = "RootContainsVectorType";
					l.Description = GetDtoLinkText("RootContainsVectorType");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorRangeList";
					l.Type = "RootContainsVectorRange";
					l.Description = GetDtoLinkText("RootContainsVectorRange");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorRangeLevelList";
					l.Type = "RootContainsVectorRangeLevel";
					l.Description = GetDtoLinkText("RootContainsVectorRangeLevel");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabVectorRangeLevel";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorUnitList";
					l.Type = "RootContainsVectorUnit";
					l.Description = GetDtoLinkText("RootContainsVectorUnit");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorUnitPrefixList";
					l.Type = "RootContainsVectorUnitPrefix";
					l.Description = GetDtoLinkText("RootContainsVectorUnitPrefix");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ContainsVectorUnitDerivedList";
					l.Type = "RootContainsVectorUnitDerived";
					l.Description = GetDtoLinkText("RootContainsVectorUnitDerived");
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Contains";
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
					l.Type = "AppHasArtifact";
					l.Description = GetDtoLinkText("AppHasArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "DefinesMemberList";
					l.Type = "AppDefinesMember";
					l.Description = GetDtoLinkText("AppDefinesMember");
					l.IsOutgoing = true;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOneOrMore";
					l.Relation = "Defines";
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
					l.Type = "AppHasArtifact";
					l.Description = GetDtoLinkText("AppHasArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesArtifactType";
					l.Type = "ArtifactUsesArtifactType";
					l.Description = GetDtoLinkText("ArtifactUsesArtifactType");
					l.IsOutgoing = true;
					l.FromDto = "FabArtifact";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InClassHas";
					l.Type = "ClassHasArtifact";
					l.Description = GetDtoLinkText("ClassHasArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabClass";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InInstanceHas";
					l.Type = "InstanceHasArtifact";
					l.Description = GetDtoLinkText("InstanceHasArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabInstance";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InMemberCreates";
					l.Type = "MemberCreatesArtifact";
					l.Description = GetDtoLinkText("MemberCreatesArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Creates";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InUrlHas";
					l.Type = "UrlHasArtifact";
					l.Description = GetDtoLinkText("UrlHasArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabUrl";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InUserHas";
					l.Type = "UserHasArtifact";
					l.Description = GetDtoLinkText("UserHasArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUsesPrimary";
					l.Type = "FactorUsesPrimaryArtifact";
					l.Description = GetDtoLinkText("FactorUsesPrimaryArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesPrimary";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InFactorListUsesRelated";
					l.Type = "FactorUsesRelatedArtifact";
					l.Description = GetDtoLinkText("FactorUsesRelatedArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesRelated";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InDescriptorListRefinesPrimaryWith";
					l.Type = "DescriptorRefinesPrimaryWithArtifact";
					l.Description = GetDtoLinkText("DescriptorRefinesPrimaryWithArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "RefinesPrimaryWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InDescriptorListRefinesRelatedWith";
					l.Type = "DescriptorRefinesRelatedWithArtifact";
					l.Description = GetDtoLinkText("DescriptorRefinesRelatedWithArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "RefinesRelatedWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InDescriptorListRefinesTypeWith";
					l.Type = "DescriptorRefinesTypeWithArtifact";
					l.Description = GetDtoLinkText("DescriptorRefinesTypeWithArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "RefinesTypeWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InVectorListUsesAxis";
					l.Type = "VectorUsesAxisArtifact";
					l.Description = GetDtoLinkText("VectorUsesAxisArtifact");
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesAxis";
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
					l.Type = "ArtifactUsesArtifactType";
					l.Description = GetDtoLinkText("ArtifactUsesArtifactType");
					l.IsOutgoing = false;
					l.FromDto = "FabArtifact";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
				p.IsNullable = true;
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
					l.Type = "ClassHasArtifact";
					l.Description = GetDtoLinkText("ClassHasArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabClass";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
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
				p.IsNullable = true;
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new FabSpecDtoProp();
				p.Name = "Disamb";
				p.Type = "string";
				p.Description = GetDtoPropText("Instance_Disamb");
				p.IsNullable = true;
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
					l.Type = "InstanceHasArtifact";
					l.Description = GetDtoLinkText("InstanceHasArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabInstance";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
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
					l.Type = "AppDefinesMember";
					l.Description = GetDtoLinkText("AppDefinesMember");
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOneOrMore";
					l.Relation = "Defines";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "HasMemberTypeAssign";
					l.Type = "MemberHasMemberTypeAssign";
					l.Description = GetDtoLinkText("MemberHasMemberTypeAssign");
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "HasHistoricMemberTypeAssignList";
					l.Type = "MemberHasHistoricMemberTypeAssign";
					l.Description = GetDtoLinkText("MemberHasHistoricMemberTypeAssign");
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "HasHistoric";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "CreatesArtifactList";
					l.Type = "MemberCreatesArtifact";
					l.Description = GetDtoLinkText("MemberCreatesArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Creates";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "CreatesMemberTypeAssignList";
					l.Type = "MemberCreatesMemberTypeAssign";
					l.Description = GetDtoLinkText("MemberCreatesMemberTypeAssign");
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Creates";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "CreatesFactorList";
					l.Type = "MemberCreatesFactor";
					l.Description = GetDtoLinkText("MemberCreatesFactor");
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Creates";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InUserDefines";
					l.Type = "UserDefinesMember";
					l.Description = GetDtoLinkText("UserDefinesMember");
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOneOrMore";
					l.Relation = "Defines";
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
					l.Type = "MemberTypeAssignUsesMemberType";
					l.Description = GetDtoLinkText("MemberTypeAssignUsesMemberType");
					l.IsOutgoing = false;
					l.FromDto = "FabMemberTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "MemberHasMemberTypeAssign";
					l.Description = GetDtoLinkText("MemberHasMemberTypeAssign");
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InMemberHasHistoric";
					l.Type = "MemberHasHistoricMemberTypeAssign";
					l.Description = GetDtoLinkText("MemberHasHistoricMemberTypeAssign");
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "HasHistoric";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InMemberCreates";
					l.Type = "MemberCreatesMemberTypeAssign";
					l.Description = GetDtoLinkText("MemberCreatesMemberTypeAssign");
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Creates";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesMemberType";
					l.Type = "MemberTypeAssignUsesMemberType";
					l.Description = GetDtoLinkText("MemberTypeAssignUsesMemberType");
					l.IsOutgoing = true;
					l.FromDto = "FabMemberTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "UrlHasArtifact";
					l.Description = GetDtoLinkText("UrlHasArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabUrl";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
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
				p.LenMin = 4;
				p.ValidRegex = @"^[a-zA-Z0-9_]*$";
				dto.PropertyList.Add(p);

					l = new FabSpecDtoLink();
					l.Name = "HasArtifact";
					l.Type = "UserHasArtifact";
					l.Description = GetDtoLinkText("UserHasArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "DefinesMemberList";
					l.Type = "UserDefinesMember";
					l.Description = GetDtoLinkText("UserDefinesMember");
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOneOrMore";
					l.Relation = "Defines";
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
					l.Type = "MemberCreatesFactor";
					l.Description = GetDtoLinkText("MemberCreatesFactor");
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Creates";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesPrimaryArtifact";
					l.Type = "FactorUsesPrimaryArtifact";
					l.Description = GetDtoLinkText("FactorUsesPrimaryArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesPrimary";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesRelatedArtifact";
					l.Type = "FactorUsesRelatedArtifact";
					l.Description = GetDtoLinkText("FactorUsesRelatedArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesRelated";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesFactorAssertion";
					l.Type = "FactorUsesFactorAssertion";
					l.Description = GetDtoLinkText("FactorUsesFactorAssertion");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "ReplacesFactor";
					l.Type = "FactorReplacesFactor";
					l.Description = GetDtoLinkText("FactorReplacesFactor");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Replaces";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesDescriptor";
					l.Type = "FactorUsesDescriptor";
					l.Description = GetDtoLinkText("FactorUsesDescriptor");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesDirector";
					l.Type = "FactorUsesDirector";
					l.Description = GetDtoLinkText("FactorUsesDirector");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesEventor";
					l.Type = "FactorUsesEventor";
					l.Description = GetDtoLinkText("FactorUsesEventor");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesIdentor";
					l.Type = "FactorUsesIdentor";
					l.Description = GetDtoLinkText("FactorUsesIdentor");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesLocator";
					l.Type = "FactorUsesLocator";
					l.Description = GetDtoLinkText("FactorUsesLocator");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVector";
					l.Type = "FactorUsesVector";
					l.Description = GetDtoLinkText("FactorUsesVector");
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
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
					l.Type = "FactorUsesFactorAssertion";
					l.Description = GetDtoLinkText("FactorUsesFactorAssertion");
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "FactorUsesDescriptor";
					l.Description = GetDtoLinkText("FactorUsesDescriptor");
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesDescriptorType";
					l.Type = "DescriptorUsesDescriptorType";
					l.Description = GetDtoLinkText("DescriptorUsesDescriptorType");
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "RefinesPrimaryWithArtifact";
					l.Type = "DescriptorRefinesPrimaryWithArtifact";
					l.Description = GetDtoLinkText("DescriptorRefinesPrimaryWithArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "RefinesPrimaryWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "RefinesRelatedWithArtifact";
					l.Type = "DescriptorRefinesRelatedWithArtifact";
					l.Description = GetDtoLinkText("DescriptorRefinesRelatedWithArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "RefinesRelatedWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "RefinesTypeWithArtifact";
					l.Type = "DescriptorRefinesTypeWithArtifact";
					l.Description = GetDtoLinkText("DescriptorRefinesTypeWithArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "RefinesTypeWith";
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
					l.Type = "DescriptorUsesDescriptorType";
					l.Description = GetDtoLinkText("DescriptorUsesDescriptorType");
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "FactorUsesDirector";
					l.Description = GetDtoLinkText("FactorUsesDirector");
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesDirectorType";
					l.Type = "DirectorUsesDirectorType";
					l.Description = GetDtoLinkText("DirectorUsesDirectorType");
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesPrimaryDirectorAction";
					l.Type = "DirectorUsesPrimaryDirectorAction";
					l.Description = GetDtoLinkText("DirectorUsesPrimaryDirectorAction");
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesPrimary";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesRelatedDirectorAction";
					l.Type = "DirectorUsesRelatedDirectorAction";
					l.Description = GetDtoLinkText("DirectorUsesRelatedDirectorAction");
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesRelated";
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
					l.Type = "DirectorUsesDirectorType";
					l.Description = GetDtoLinkText("DirectorUsesDirectorType");
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "DirectorUsesPrimaryDirectorAction";
					l.Description = GetDtoLinkText("DirectorUsesPrimaryDirectorAction");
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesPrimary";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InDirectorListUsesRelated";
					l.Type = "DirectorUsesRelatedDirectorAction";
					l.Description = GetDtoLinkText("DirectorUsesRelatedDirectorAction");
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesRelated";
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
					l.Type = "FactorUsesEventor";
					l.Description = GetDtoLinkText("FactorUsesEventor");
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesEventorType";
					l.Type = "EventorUsesEventorType";
					l.Description = GetDtoLinkText("EventorUsesEventorType");
					l.IsOutgoing = true;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesEventorPrecision";
					l.Type = "EventorUsesEventorPrecision";
					l.Description = GetDtoLinkText("EventorUsesEventorPrecision");
					l.IsOutgoing = true;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "EventorUsesEventorType";
					l.Description = GetDtoLinkText("EventorUsesEventorType");
					l.IsOutgoing = false;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "EventorUsesEventorPrecision";
					l.Description = GetDtoLinkText("EventorUsesEventorPrecision");
					l.IsOutgoing = false;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "FactorUsesIdentor";
					l.Description = GetDtoLinkText("FactorUsesIdentor");
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesIdentorType";
					l.Type = "IdentorUsesIdentorType";
					l.Description = GetDtoLinkText("IdentorUsesIdentorType");
					l.IsOutgoing = true;
					l.FromDto = "FabIdentor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "IdentorUsesIdentorType";
					l.Description = GetDtoLinkText("IdentorUsesIdentorType");
					l.IsOutgoing = false;
					l.FromDto = "FabIdentor";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "FactorUsesLocator";
					l.Description = GetDtoLinkText("FactorUsesLocator");
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesLocatorType";
					l.Type = "LocatorUsesLocatorType";
					l.Description = GetDtoLinkText("LocatorUsesLocatorType");
					l.IsOutgoing = true;
					l.FromDto = "FabLocator";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "LocatorUsesLocatorType";
					l.Description = GetDtoLinkText("LocatorUsesLocatorType");
					l.IsOutgoing = false;
					l.FromDto = "FabLocator";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "FactorUsesVector";
					l.Description = GetDtoLinkText("FactorUsesVector");
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Relation = "Uses";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesAxisArtifact";
					l.Type = "VectorUsesAxisArtifact";
					l.Description = GetDtoLinkText("VectorUsesAxisArtifact");
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "UsesAxis";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorType";
					l.Type = "VectorUsesVectorType";
					l.Description = GetDtoLinkText("VectorUsesVectorType");
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorUnit";
					l.Type = "VectorUsesVectorUnit";
					l.Description = GetDtoLinkText("VectorUsesVectorUnit");
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorUnitPrefix";
					l.Type = "VectorUsesVectorUnitPrefix";
					l.Description = GetDtoLinkText("VectorUsesVectorUnitPrefix");
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "VectorUsesVectorType";
					l.Description = GetDtoLinkText("VectorUsesVectorType");
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorRange";
					l.Type = "VectorTypeUsesVectorRange";
					l.Description = GetDtoLinkText("VectorTypeUsesVectorRange");
					l.IsOutgoing = true;
					l.FromDto = "FabVectorType";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "VectorTypeUsesVectorRange";
					l.Description = GetDtoLinkText("VectorTypeUsesVectorRange");
					l.IsOutgoing = false;
					l.FromDto = "FabVectorType";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorRangeLevelList";
					l.Type = "VectorRangeUsesVectorRangeLevel";
					l.Description = GetDtoLinkText("VectorRangeUsesVectorRangeLevel");
					l.IsOutgoing = true;
					l.FromDto = "FabVectorRange";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Uses";
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
					l.Type = "VectorRangeUsesVectorRangeLevel";
					l.Description = GetDtoLinkText("VectorRangeUsesVectorRangeLevel");
					l.IsOutgoing = false;
					l.FromDto = "FabVectorRange";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Relation = "Uses";
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
					l.Type = "VectorUsesVectorUnit";
					l.Description = GetDtoLinkText("VectorUsesVectorUnit");
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InVectorUnitDerivedListDefines";
					l.Type = "VectorUnitDerivedDefinesVectorUnit";
					l.Description = GetDtoLinkText("VectorUnitDerivedDefinesVectorUnit");
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Defines";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InVectorUnitDerivedListRaisesToExp";
					l.Type = "VectorUnitDerivedRaisesToExpVectorUnit";
					l.Description = GetDtoLinkText("VectorUnitDerivedRaisesToExpVectorUnit");
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Relation = "RaisesToExp";
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
					l.Type = "VectorUsesVectorUnitPrefix";
					l.Description = GetDtoLinkText("VectorUsesVectorUnitPrefix");
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "InVectorUnitDerivedListUses";
					l.Type = "VectorUnitDerivedUsesVectorUnitPrefix";
					l.Description = GetDtoLinkText("VectorUnitDerivedUsesVectorUnitPrefix");
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
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
					l.Type = "VectorUnitDerivedDefinesVectorUnit";
					l.Description = GetDtoLinkText("VectorUnitDerivedDefinesVectorUnit");
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Defines";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "RaisesToExpVectorUnit";
					l.Type = "VectorUnitDerivedRaisesToExpVectorUnit";
					l.Description = GetDtoLinkText("VectorUnitDerivedRaisesToExpVectorUnit");
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Relation = "RaisesToExp";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new FabSpecDtoLink();
					l.Name = "UsesVectorUnitPrefix";
					l.Type = "VectorUnitDerivedUsesVectorUnitPrefix";
					l.Description = GetDtoLinkText("VectorUnitDerivedUsesVectorUnitPrefix");
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Relation = "Uses";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			return list;
		}

	}

}