// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 12/20/2012 3:22:16 PM

using System.Collections.Generic;
using Fabric.Api.Paths.Steps.Functions;

namespace Fabric.Api.Spec {

	/*================================================================================================*/
	public partial class SpecDoc {
	
		/*--------------------------------------------------------------------------------------------*/
		public List<SpecDto> BuildDtoList() {
			var list = new List<SpecDto>();
			
			SpecDto dto;
			SpecProperty p;
			SpecLink l;

			////

			dto = new SpecDto();
			dto.Name = "FabNodeForType";
			dto.Extends = "FabNode";
			dto.Description = GetDtoText("NodeForType");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("NodeForType_Name");
				p.IsUnique = true;
				p.LenMax = 32;
				p.LenMin = 1;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

				p = new SpecProperty();
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
	
				p = new SpecProperty();
				p.Name = "Performed";
				p.Type = "long";
				p.Description = GetDtoPropText("NodeForAction_Performed");
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
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
	
					l = new SpecLink();
					l.Name = "ContainsAppList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsApp";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsArtifactList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsArtifactTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsArtifactType";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsCrowdList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsCrowd";
					l.ToDto = "FabCrowd";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsCrowdianList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsCrowdian";
					l.ToDto = "FabCrowdian";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsCrowdianTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsCrowdianType";
					l.ToDto = "FabCrowdianType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsCrowdianTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsLabelList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsLabel";
					l.ToDto = "FabLabel";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsMemberList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsMember";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsMemberTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsMemberType";
					l.ToDto = "FabMemberType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsThingList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsThing";
					l.ToDto = "FabThing";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsUrlList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsUrl";
					l.ToDto = "FabUrl";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsUserList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsUser";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsFactorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsFactorAssertionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsFactorAssertion";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsDescriptorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDescriptor";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsDescriptorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDescriptorType";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsDirectorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDirector";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsDirectorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDirectorType";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsDirectorActionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsEventorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsEventor";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsEventorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsEventorType";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsEventorPrecisionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsEventorPrecision";
					l.ToDto = "FabEventorPrecision";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsIdentorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsIdentor";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsIdentorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsIdentorType";
					l.ToDto = "FabIdentorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsLocatorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsLocator";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsLocatorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsLocatorType";
					l.ToDto = "FabLocatorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsVectorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVector";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsVectorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorType";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsVectorRangeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorRange";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsVectorRangeLevelList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorRangeLevel";
					l.ToDto = "FabVectorRangeLevel";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsVectorUnitList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsVectorUnitPrefixList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorUnitPrefix";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ContainsVectorUnitDerivedList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "RootContainsVectorUnitDerived";
					l.ToDto = "FabVectorUnitDerived";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

			////

			dto = new SpecDto();
			dto.Name = "FabApp";
			dto.Extends = "FabArtifactOwnerNode";
			dto.Description = GetDtoText("App");
			dto.Abstract = dto.Description.Substring(0, dto.Description.IndexOf('.')+1);
			list.Add(dto);
	
				p = new SpecProperty();
				p.Name = "AppId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("App_Name");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 64;
				p.LenMin = 3;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "AppHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "ArtifactId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "IsPrivate";
				p.Type = "bool";
				p.Description = GetDtoPropText("Artifact_IsPrivate");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Created";
				p.Type = "long";
				p.Description = GetDtoPropText("Artifact_Created");
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InAppHas";
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "AppHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesArtifactType";
					l.IsOutgoing = true;
					l.FromDto = "FabArtifact";
					l.FromDtoConn = "OutToOne";
					l.Verb = "ArtifactUsesArtifactType";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InCrowdHas";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowd";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InLabelHas";
					l.IsOutgoing = false;
					l.FromDto = "FabLabel";
					l.FromDtoConn = "OutToOne";
					l.Verb = "LabelHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InThingHas";
					l.IsOutgoing = false;
					l.FromDto = "FabThing";
					l.FromDtoConn = "OutToOne";
					l.Verb = "ThingHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InUrlHas";
					l.IsOutgoing = false;
					l.FromDto = "FabUrl";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UrlHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InUserHas";
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UserHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InFactorListUsesPrimary";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesPrimaryArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InFactorListUsesRelated";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesRelatedArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InDescriptorListRefinesPrimaryWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesPrimaryWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InDescriptorListRefinesRelatedWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesRelatedWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InDescriptorListRefinesTypeWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesTypeWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "ArtifactTypeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "CrowdId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Crowd_Name");
				p.LenMax = 64;
				p.LenMin = 3;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Description";
				p.Type = "string";
				p.Description = GetDtoPropText("Crowd_Description");
				p.LenMax = 256;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "IsPrivate";
				p.Type = "bool";
				p.Description = GetDtoPropText("Crowd_IsPrivate");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "IsInviteOnly";
				p.Type = "bool";
				p.Description = GetDtoPropText("Crowd_IsInviteOnly");
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowd";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "CrowdianId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InCrowdDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowd";
					l.FromDtoConn = "OutToOneOrMore";
					l.Verb = "CrowdDefinesCrowdian";
					l.ToDto = "FabCrowdian";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "HasCrowdianTypeAssign";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdianHasCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "HasHistoricCrowdianTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "CrowdianHasHistoricCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "CrowdianTypeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "CrowdianTypeAssignId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Weight";
				p.Type = "float";
				p.Description = GetDtoPropText("CrowdianTypeAssign_Weight");
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InCrowdianHas";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdianHasCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InCrowdianHasHistoric";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "CrowdianHasHistoricCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesCrowdianType";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdianTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Verb = "CrowdianTypeAssignUsesCrowdianType";
					l.ToDto = "FabCrowdianType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "LabelId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Label_Name");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 128;
				p.LenMin = 1;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "MemberId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InAppDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOneOrMore";
					l.Verb = "AppDefinesMember";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "HasMemberTypeAssign";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "MemberHasMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "HasHistoricMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberHasHistoricMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "CreatesArtifactList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "CreatesMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "CreatesFactorList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "MemberTypeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "MemberTypeAssignId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InMemberHas";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "MemberHasMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InMemberHasHistoric";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberHasHistoricMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesMemberTypeAssign";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "ThingId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "IsClass";
				p.Type = "bool";
				p.Description = GetDtoPropText("Thing_IsClass");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Thing_Name");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Disamb";
				p.Type = "string";
				p.Description = GetDtoPropText("Thing_Disamb");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Note";
				p.Type = "string";
				p.Description = GetDtoPropText("Thing_Note");
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "UrlId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("Url_Name");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "AbsoluteUrl";
				p.Type = "string";
				p.Description = GetDtoPropText("Url_AbsoluteUrl");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 2048;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "UserId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.Description = GetDtoPropText("User_Name");
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 16;
				p.ValidRegex = @"^[a-zA-Z0-9_]*$";
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UserHasArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "CreatesCrowdianTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "UserCreatesCrowdianTypeAssign";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "DefinesCrowdianList";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "UserDefinesCrowdian";
					l.ToDto = "FabCrowdian";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "FactorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "IsPublic";
				p.Type = "bool";
				p.Description = GetDtoPropText("Factor_IsPublic");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "IsDefining";
				p.Type = "bool";
				p.Description = GetDtoPropText("Factor_IsDefining");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Created";
				p.Type = "long";
				p.Description = GetDtoPropText("Factor_Created");
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Completed";
				p.Type = "long?";
				p.Description = GetDtoPropText("Factor_Completed");
				p.IsNullable = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Note";
				p.Type = "string";
				p.Description = GetDtoPropText("Factor_Note");
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "MemberCreatesFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesPrimaryArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesPrimaryArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesRelatedArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesRelatedArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesFactorAssertion";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesFactorAssertion";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "ReplacesFactor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorReplacesFactor";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesDescriptor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesDescriptor";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesDirector";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesDirector";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesEventor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesEventor";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesIdentor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesIdentor";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesLocator";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesLocator";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "FactorAssertionId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "DescriptorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "FactorUsesDescriptor";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesDescriptorType";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DescriptorUsesDescriptorType";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "RefinesPrimaryWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesPrimaryWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "RefinesRelatedWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "DescriptorRefinesRelatedWithArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "DescriptorTypeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "DirectorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesDirector";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesDirectorType";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesDirectorType";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesPrimaryDirectorAction";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesPrimaryDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "DirectorTypeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "DirectorActionId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InDirectorListUsesPrimary";
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "DirectorUsesPrimaryDirectorAction";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "EventorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "DateTime";
				p.Type = "long";
				p.Description = GetDtoPropText("Eventor_DateTime");
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesEventor";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesEventorType";
					l.IsOutgoing = true;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "EventorUsesEventorType";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "EventorTypeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "EventorPrecisionId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "IdentorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Value";
				p.Type = "string";
				p.Description = GetDtoPropText("Identor_Value");
				p.LenMax = 128;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesIdentor";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "IdentorTypeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "LocatorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "ValueX";
				p.Type = "double";
				p.Description = GetDtoPropText("Locator_ValueX");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "ValueY";
				p.Type = "double";
				p.Description = GetDtoPropText("Locator_ValueY");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "ValueZ";
				p.Type = "double";
				p.Description = GetDtoPropText("Locator_ValueZ");
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesLocator";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "LocatorTypeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "MinX";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MinX");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "MaxX";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MaxX");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "MinY";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MinY");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "MaxY";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MaxY");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "MinZ";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MinZ");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "MaxZ";
				p.Type = "double";
				p.Description = GetDtoPropText("LocatorType_MaxZ");
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "VectorId";
				p.Type = "long";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Value";
				p.Type = "long";
				p.Description = GetDtoPropText("Vector_Value");
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "FactorUsesVector";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesAxisArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesAxisArtifact";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesVectorType";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorType";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "UsesVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "VectorTypeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Min";
				p.Type = "long";
				p.Description = GetDtoPropText("VectorType_Min");
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Max";
				p.Type = "long";
				p.Description = GetDtoPropText("VectorType_Max");
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorType";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "VectorRangeId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InVectorTypeListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorType";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorTypeUsesVectorRange";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "VectorRangeLevelId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Position";
				p.Type = "float";
				p.Description = GetDtoPropText("VectorRangeLevel_Position");
				dto.PropertyList.Add(p);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "VectorUnitId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Symbol";
				p.Type = "string";
				p.Description = GetDtoPropText("VectorUnit_Symbol");
				p.LenMax = 8;
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "InVectorUnitDerivedListDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedDefinesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "VectorUnitPrefixId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Symbol";
				p.Type = "string";
				p.Description = GetDtoPropText("VectorUnitPrefix_Symbol");
				p.LenMax = 8;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Amount";
				p.Type = "double";
				p.Description = GetDtoPropText("VectorUnitPrefix_Amount");
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUsesVectorUnitPrefix";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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
	
				p = new SpecProperty();
				p.Name = "VectorUnitDerivedId";
				p.Type = "byte";
				p.Description = GetDtoPropText("Object_TypeId");
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new SpecProperty();
				p.Name = "Exponent";
				p.Type = "int";
				p.Description = GetDtoPropText("VectorUnitDerived_Exponent");
				dto.PropertyList.Add(p);

					l = new SpecLink();
					l.Name = "DefinesVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedDefinesVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
					l.Name = "RaisesToExpVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "VectorUnitDerivedRaisesToExpVectorUnit";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new SpecLink();
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