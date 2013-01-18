﻿// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 1/17/2013 7:13:43 PM

using System.Collections.Generic;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public partial class SpecDoc {
	
		/*--------------------------------------------------------------------------------------------*/
		public List<SpecDto> BuildDtoList() {
			var list = new List<SpecDto>();
			
			SpecDto dto;
			SpecDtoProp p;
			SpecDtoLink l;

			////

			dto = new SpecDto();
			dto.Name = "FabNodeForType";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("NodeForType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("NodeForType_Name");
				p.IsUnique = true;
				p.LenMax = 32;
				p.LenMin = 1;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Description";
				p.Type = "string";
				p.Description = GetDtoPropText("NodeForType_Description");
				p.LenMax = 256;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

			////

			dto = new SpecDto();
			dto.Name = "FabNodeForAction";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("NodeForAction");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "Performed";
				p.Type = "long";
				p.Description = GetDtoPropText("NodeForAction_Performed");
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Note";
				p.Type = "string";
				p.Description = GetDtoPropText("NodeForAction_Note");
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

			////

			dto = new SpecDto();
			dto.Name = "FabArtifactOwnerNode";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("ArtifactOwnerNode");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
			////

			dto = new SpecDto();
			dto.Name = "FabRoot";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("Root");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "RootId";
				p.Type = "int";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "ContainsAppList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsApp";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsArtifactList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsArtifactTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsArtifactType";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsCrowdList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsCrowd";
					l.ToDto = "FabCrowd";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsCrowdianList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsCrowdian";
					l.ToDto = "FabCrowdian";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsCrowdianTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsCrowdianType";
					l.ToDto = "FabCrowdianType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsCrowdianTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsLabelList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsLabel";
					l.ToDto = "FabLabel";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsMemberList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsMember";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsMemberTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsMemberType";
					l.ToDto = "FabMemberType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsThingList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsThing";
					l.ToDto = "FabThing";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsUrlList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsUrl";
					l.ToDto = "FabUrl";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsUserList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsUser";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsFactorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsFactorAssertionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsFactorAssertion";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsDescriptorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDescriptor";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsDescriptorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDescriptorType";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsDirectorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDirector";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsDirectorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDirectorType";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsDirectorActionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsEventorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsEventor";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsEventorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsEventorType";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsEventorPrecisionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsEventorPrecision";
					l.ToDto = "FabEventorPrecision";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsIdentorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsIdentor";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsIdentorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsIdentorType";
					l.ToDto = "FabIdentorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsLocatorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsLocator";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsLocatorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsLocatorType";
					l.ToDto = "FabLocatorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsVectorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVector";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsVectorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorType";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsVectorRangeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorRange";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsVectorRangeLevelList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorRangeLevel";
					l.ToDto = "FabVectorRangeLevel";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsVectorUnitList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsVectorUnitPrefixList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorUnitPrefix";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ContainsVectorUnitDerivedList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorUnitDerived";
					l.ToDto = "FabVectorUnitDerived";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Oauth");

			////

			dto = new SpecDto();
			dto.Name = "FabApp";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("App");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "AppId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("App_Name");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 64;
				p.LenMin = 3;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "AppHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabArtifact";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("Artifact");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "ArtifactId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "IsPrivate";
				p.Type = "bool";
				p.Description = GetDtoPropText("Artifact_IsPrivate");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Created";
				p.Type = "long";
				p.Description = GetDtoPropText("Artifact_Created");
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InAppHas";
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "AppHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesArtifactType";
					l.IsOutgoing = true;
					l.FromDto = "FabArtifact";
					l.FromDtoConn = "OutToOne";
					l.Verb = "ArtifactUsesArtifactType";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InCrowdHas";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowd";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InLabelHas";
					l.IsOutgoing = false;
					l.FromDto = "FabLabel";
					l.FromDtoConn = "OutToOne";
					l.Verb = "LabelHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InThingHas";
					l.IsOutgoing = false;
					l.FromDto = "FabThing";
					l.FromDtoConn = "OutToOne";
					l.Verb = "ThingHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InUrlHas";
					l.IsOutgoing = false;
					l.FromDto = "FabUrl";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UrlHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InUserHas";
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UserHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InFactorListUsesPrimary";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesPrimaryArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InFactorListUsesRelated";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesRelatedArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InDescriptorListRefinesPrimaryWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesPrimaryWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InDescriptorListRefinesRelatedWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesRelatedWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InDescriptorListRefinesTypeWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesTypeWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabArtifactType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("ArtifactType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "ArtifactTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabCrowd";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("Crowd");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "CrowdId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Crowd_Name");
				p.LenMax = 64;
				p.LenMin = 3;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Description";
				p.Type = "string";
				p.Description = GetDtoPropText("Crowd_Description");
				p.LenMax = 256;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "IsPrivate";
				p.Type = "bool";
				p.Description = GetDtoPropText("Crowd_IsPrivate");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "IsInviteOnly";
				p.Type = "bool";
				p.Description = GetDtoPropText("Crowd_IsInviteOnly");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowd";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "DefinesCrowdianList";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowd";
					l.FromDtoConn = "OutToOneOrMore";
					l.Verb = "CrowdDefinesCrowdian";
					l.ToDto = "FabCrowdian";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new SpecDto();
			dto.Name = "FabCrowdian";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("Crowdian");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "CrowdianId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InCrowdDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowd";
					l.FromDtoConn = "OutToOneOrMore";
					l.Verb = "CrowdDefinesCrowdian";
					l.ToDto = "FabCrowdian";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "HasCrowdianTypeAssign";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdianHasCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "HasHistoricCrowdianTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "CrowdianHasHistoricCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InUserDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "UserDefinesCrowdian";
					l.ToDto = "FabCrowdian";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new SpecDto();
			dto.Name = "FabCrowdianType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("CrowdianType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "CrowdianTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InCrowdianTypeAssignListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdianTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdianTypeAssignUsesCrowdianType";
					l.ToDto = "FabCrowdianType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new SpecDto();
			dto.Name = "FabCrowdianTypeAssign";
			dto.Extends = "FabNodeForAction";
			dto.Description = GetDtoText("CrowdianTypeAssign");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "CrowdianTypeAssignId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Weight";
				p.Type = "float";
				p.Description = GetDtoPropText("CrowdianTypeAssign_Weight");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InCrowdianHas";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdianHasCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InCrowdianHasHistoric";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "CrowdianHasHistoricCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesCrowdianType";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdianTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdianTypeAssignUsesCrowdianType";
					l.ToDto = "FabCrowdianType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InUserCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "UserCreatesCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new SpecDto();
			dto.Name = "FabLabel";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("Label");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "LabelId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Label_Name");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 128;
				p.LenMin = 1;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabLabel";
					l.FromDtoConn = "OutToOne";
					l.Verb = "LabelHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new SpecDto();
			dto.Name = "FabMember";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("Member");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "MemberId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InAppDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOneOrMore";
					l.Verb = "AppDefinesMember";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "HasMemberTypeAssign";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "MemberHasMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "HasHistoricMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberHasHistoricMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "CreatesArtifactList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "CreatesMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "CreatesFactorList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabMemberType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("MemberType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "MemberTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabMemberTypeAssign";
			dto.Extends = "FabNodeForAction";
			dto.Description = GetDtoText("MemberTypeAssign");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "MemberTypeAssignId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InMemberHas";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "MemberHasMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InMemberHasHistoric";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberHasHistoricMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabThing";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("Thing");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "ThingId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "IsClass";
				p.Type = "bool";
				p.Description = GetDtoPropText("Thing_IsClass");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Thing_Name");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Disamb";
				p.Type = "string";
				p.Description = GetDtoPropText("Thing_Disamb");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Note";
				p.Type = "string";
				p.Description = GetDtoPropText("Thing_Note");
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabThing";
					l.FromDtoConn = "OutToOne";
					l.Verb = "ThingHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

						dto.FunctionList.Add("Back");

						dto.FunctionList.Add("Limit");

			////

			dto = new SpecDto();
			dto.Name = "FabUrl";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("Url");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "UrlId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Url_Name");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "AbsoluteUrl";
				p.Type = "string";
				p.Description = GetDtoPropText("Url_AbsoluteUrl");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 2048;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabUser";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("User");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "UserId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("User_Name");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 16;
				p.ValidRegex = @"^[a-zA-Z0-9_]*$";
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UserHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "CreatesCrowdianTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "UserCreatesCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "DefinesCrowdianList";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "UserDefinesCrowdian";
					l.ToDto = "FabCrowdian";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabFactor";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("Factor");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "FactorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "IsPublic";
				p.Type = "bool";
				p.Description = GetDtoPropText("Factor_IsPublic");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "IsDefining";
				p.Type = "bool";
				p.Description = GetDtoPropText("Factor_IsDefining");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Created";
				p.Type = "long";
				p.Description = GetDtoPropText("Factor_Created");
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Completed";
				p.Type = "long?";
				p.Description = GetDtoPropText("Factor_Completed");
				p.IsNullable = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Note";
				p.Type = "string";
				p.Description = GetDtoPropText("Factor_Note");
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesPrimaryArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesPrimaryArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesRelatedArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesRelatedArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesFactorAssertion";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesFactorAssertion";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "ReplacesFactor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorReplacesFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesDescriptor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesDescriptor";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesDirector";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesDirector";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesEventor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesEventor";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesIdentor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesIdentor";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesLocator";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesLocator";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabFactorAssertion";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("FactorAssertion");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "FactorAssertionId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabFactorElementNode";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("FactorElementNode");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
			////

			dto = new SpecDto();
			dto.Name = "FabDescriptor";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Descriptor");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "DescriptorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesDescriptor";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesDescriptorType";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DescriptorUsesDescriptorType";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "RefinesPrimaryWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesPrimaryWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "RefinesRelatedWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesRelatedWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabDescriptorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("DescriptorType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "DescriptorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabDirector";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Director");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "DirectorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesDirector";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesDirectorType";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesDirectorType";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesPrimaryDirectorAction";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesPrimaryDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabDirectorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("DirectorType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "DirectorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabDirectorAction";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("DirectorAction");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "DirectorActionId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InDirectorListUsesPrimary";
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesPrimaryDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabEventor";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Eventor");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "EventorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "DateTime";
				p.Type = "long";
				p.Description = GetDtoPropText("Eventor_DateTime");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesEventor";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesEventorType";
					l.IsOutgoing = true;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "EventorUsesEventorType";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabEventorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("EventorType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "EventorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabEventorPrecision";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("EventorPrecision");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "EventorPrecisionId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabIdentor";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Identor");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "IdentorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Value";
				p.Type = "string";
				p.Description = GetDtoPropText("Identor_Value");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesIdentor";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabIdentorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("IdentorType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "IdentorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabLocator";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Locator");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "LocatorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "ValueX";
				p.Type = "double";
				p.Description = GetDtoPropText("Locator_ValueX");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "ValueY";
				p.Type = "double";
				p.Description = GetDtoPropText("Locator_ValueY");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "ValueZ";
				p.Type = "double";
				p.Description = GetDtoPropText("Locator_ValueZ");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesLocator";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabLocatorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("LocatorType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "LocatorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "MinX";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MinX");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "MaxX";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MaxX");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "MinY";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MinY");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "MaxY";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MaxY");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "MinZ";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MinZ");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "MaxZ";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MaxZ");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabVector";
			dto.Extends = "FabFactorElementNode";
			dto.Description = GetDtoText("Vector");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "VectorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Value";
				p.Type = "long";
				p.Description = GetDtoPropText("Vector_Value");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesVector";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesAxisArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesAxisArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesVectorType";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorType";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "UsesVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabVectorType";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "VectorTypeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Min";
				p.Type = "long";
				p.Description = GetDtoPropText("VectorType_Min");
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Max";
				p.Type = "long";
				p.Description = GetDtoPropText("VectorType_Max");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorType";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabVectorRange";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorRange");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "VectorRangeId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InVectorTypeListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorType";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorTypeUsesVectorRange";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabVectorRangeLevel";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorRangeLevel");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "VectorRangeLevelId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Position";
				p.Type = "float";
				p.Description = GetDtoPropText("VectorRangeLevel_Position");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabVectorUnit";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorUnit");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "VectorUnitId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Symbol";
				p.Type = "string";
				p.Description = GetDtoPropText("VectorUnit_Symbol");
				p.LenMax = 8;
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "InVectorUnitDerivedListDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedDefinesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabVectorUnitPrefix";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorUnitPrefix");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "VectorUnitPrefixId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Symbol";
				p.Type = "string";
				p.Description = GetDtoPropText("VectorUnitPrefix_Symbol");
				p.LenMax = 8;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Amount";
				p.Type = "double";
				p.Description = GetDtoPropText("VectorUnitPrefix_Amount");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnitPrefix";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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

			dto = new SpecDto();
			dto.Name = "FabVectorUnitDerived";
			dto.Extends = "FabNodeForType";
			dto.Description = GetDtoText("VectorUnitDerived");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecDtoProp();
				p.Name = "VectorUnitDerivedId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecDtoProp();
				p.Name = "Exponent";
				p.Type = "int";
				p.Description = GetDtoPropText("VectorUnitDerived_Exponent");
				dto.PropertyList.Add(p);

					l = new SpecDtoLink();
					l.Name = "DefinesVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedDefinesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
					l.Name = "RaisesToExpVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedRaisesToExpVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecDtoLink();
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