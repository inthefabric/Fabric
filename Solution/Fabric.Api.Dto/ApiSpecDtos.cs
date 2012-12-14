// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 12/14/2012 5:22:04 PM

using System.Collections.Generic;

namespace Fabric.Api.Dto {

	/*================================================================================================*/
	public partial class ApiSpecDoc {
	
		/*--------------------------------------------------------------------------------------------*/
		public List<ApiSpecDto> BuildDtoList() {
			var list = new List<ApiSpecDto>();
			
			ApiSpecDto dto;
			ApiSpecProperty p;
			ApiSpecLink l;

			////

			dto = new ApiSpecDto();
			dto.Name = "FabNodeForType";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.IsUnique = true;
				p.LenMax = 32;
				p.LenMin = 1;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Description";
				p.Type = "string";
				p.LenMax = 256;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabNodeForAction";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "PerformedTimestamp";
				p.Type = "long";
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Note";
				p.Type = "string";
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabRoot";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
					l = new ApiSpecLink();
					l.Name = "ContainsAppList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsArtifactList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsArtifactTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsCrowdList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabCrowd";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsCrowdianList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabCrowdian";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsCrowdianTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabCrowdianType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsCrowdianTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsEmailList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabEmail";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsLabelList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabLabel";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsMemberList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabMember";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsMemberTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabMemberType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsThingList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabThing";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsUrlList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabUrl";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsUserList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsFactorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsFactorAssertionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsDescriptorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsDescriptorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsDirectorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsDirectorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsDirectorActionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsEventorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsEventorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsEventorPrecisionList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabEventorPrecision";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsIdentorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsIdentorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabIdentorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsLocatorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsLocatorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabLocatorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsVectorList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsVectorTypeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsVectorRangeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsVectorRangeLevelList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabVectorRangeLevel";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsVectorUnitList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsVectorUnitPrefixList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsVectorUnitDerivedList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabVectorUnitDerived";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsOauthAccessList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabOauthAccess";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsOauthDomainList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabOauthDomain";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsOauthGrantList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabOauthGrant";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ContainsOauthScopeList";
					l.IsOutgoing = true;
					l.FromDto = "FabRoot";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Contains";
					l.ToDto = "FabOauthScope";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabApp";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "AppId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 64;
				p.LenMin = 3;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Secret";
				p.Type = "string";
				p.Len = 32;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesEmail";
					l.IsOutgoing = true;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabEmail";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InMemberListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InOauthAccessListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabOauthAccess";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InOauthDomainListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabOauthDomain";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InOauthGrantListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabOauthGrant";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InOauthScopeListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabOauthScope";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabArtifact";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "ArtifactId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "IsPrivate";
				p.Type = "bool";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "CreatedTimestamp";
				p.Type = "long";
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InAppHas";
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesArtifactType";
					l.IsOutgoing = true;
					l.FromDto = "FabArtifact";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InCrowdHas";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowd";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InLabelHas";
					l.IsOutgoing = false;
					l.FromDto = "FabLabel";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Creates";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InThingHas";
					l.IsOutgoing = false;
					l.FromDto = "FabThing";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InUrlHas";
					l.IsOutgoing = false;
					l.FromDto = "FabUrl";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InUserHas";
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InFactorListUsesPrimary";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesPrimary";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InFactorListUsesRelated";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesRelated";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InDescriptorListRefinesPrimaryWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "RefinesPrimaryWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InDescriptorListRefinesRelatedWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "RefinesRelatedWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InDescriptorListRefinesTypeWith";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "RefinesTypeWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InVectorListUsesAxis";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesAxis";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabArtifactType";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "ArtifactTypeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InArtifactListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabArtifact";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabArtifactType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabCrowd";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "CrowdId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.LenMax = 64;
				p.LenMin = 3;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Description";
				p.Type = "string";
				p.LenMax = 256;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "IsPrivate";
				p.Type = "bool";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "IsInviteOnly";
				p.Type = "bool";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowd";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InCrowdianListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabCrowd";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabCrowdian";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "CrowdianId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "UsesCrowd";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabCrowd";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesUser";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "HasCrowdianTypeAssign";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "HasHistoricCrowdianTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "HasHistoric";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabCrowdianType";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "CrowdianTypeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InCrowdianTypeAssignListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdianTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabCrowdianType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabCrowdianTypeAssign";
			dto.Extends = "FabNodeForAction";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "CrowdianTypeAssignId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Weight";
				p.Type = "float";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InCrowdianHas";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InCrowdianHasHistoric";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "HasHistoric";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesCrowdianType";
					l.IsOutgoing = true;
					l.FromDto = "FabCrowdianTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabCrowdianType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InUserCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Creates";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabEmail";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "EmailId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Address";
				p.Type = "string";
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 256;
				p.ValidRegex = @"^(([^<>()[\]\\.,;:\s@\""]+(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Code";
				p.Type = "string";
				p.Len = 32;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "CreatedTimestamp";
				p.Type = "long";
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "VerifiedTimestamp";
				p.Type = "long";
				p.IsNullable = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InAppUses";
					l.IsOutgoing = false;
					l.FromDto = "FabApp";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabEmail";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InUserUses";
					l.IsOutgoing = false;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabEmail";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabLabel";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "LabelId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 128;
				p.LenMin = 1;
				p.ValidRegex = @"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\/!@#$%&=_,:;'""<>~]*$";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabLabel";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabMember";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "MemberId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "UsesApp";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesUser";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "HasMemberTypeAssign";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "HasHistoricMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "HasHistoric";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "CreatesArtifactList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Creates";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "CreatesMemberTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Creates";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "CreatesFactorList";
					l.IsOutgoing = true;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Creates";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabMemberType";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "MemberTypeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InMemberTypeAssignListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabMemberTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabMemberType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabMemberTypeAssign";
			dto.Extends = "FabNodeForAction";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "MemberTypeAssignId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InMemberHas";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InMemberHasHistoric";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "HasHistoric";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Creates";
					l.ToDto = "FabMemberTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesMemberType";
					l.IsOutgoing = true;
					l.FromDto = "FabMemberTypeAssign";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabMemberType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabThing";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "ThingId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "IsClass";
				p.Type = "bool";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Disamb";
				p.Type = "string";
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Note";
				p.Type = "string";
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabThing";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabUrl";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "UrlId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.LenMax = 128;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "AbsoluteUrl";
				p.Type = "string";
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 2048;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabUrl";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabUser";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "UserId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Name";
				p.Type = "string";
				p.IsCaseInsensitive = true;
				p.IsUnique = true;
				p.LenMax = 16;
				p.ValidRegex = @"^[a-zA-Z0-9_]*$";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Password";
				p.Type = "string";
				p.Len = 32;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InCrowdianListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabCrowdian";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InMemberListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "HasArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Has";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesEmail";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabEmail";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "CreatesCrowdianTypeAssignList";
					l.IsOutgoing = true;
					l.FromDto = "FabUser";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Creates";
					l.ToDto = "FabCrowdianTypeAssign";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InOauthAccessListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabOauthAccess";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InOauthGrantListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabOauthGrant";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InOauthScopeListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabOauthScope";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabFactor";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "FactorId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "IsPublic";
				p.Type = "bool";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "IsDefining";
				p.Type = "bool";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "CreatedTimestamp";
				p.Type = "long";
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "DeletedTimestamp";
				p.Type = "long";
				p.IsNullable = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "CompletedTimestamp";
				p.Type = "long";
				p.IsNullable = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Note";
				p.Type = "string";
				p.IsNullable = true;
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InMemberCreates";
					l.IsOutgoing = false;
					l.FromDto = "FabMember";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Creates";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesPrimaryArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesPrimary";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesRelatedArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesRelated";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesFactorAssertion";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "ReplacesFactor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Replaces";
					l.ToDto = "FabFactor";
					l.ToDtoConn = "InFromZeroOrOne";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesDescriptor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesDirector";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesEventor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesIdentor";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesLocator";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesVector";
					l.IsOutgoing = true;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabFactorAssertion";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "FactorAssertionId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabFactorAssertion";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabFactorElementNode";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
			////

			dto = new ApiSpecDto();
			dto.Name = "FabDescriptor";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "DescriptorId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabDescriptor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesDescriptorType";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "RefinesPrimaryWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "RefinesPrimaryWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "RefinesRelatedWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "RefinesRelatedWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "RefinesTypeWithArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "RefinesTypeWith";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabDescriptorType";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "DescriptorTypeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InDescriptorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabDescriptor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabDescriptorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabDirector";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "DirectorId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabDirector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesDirectorType";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesPrimaryDirectorAction";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesPrimary";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesRelatedDirectorAction";
					l.IsOutgoing = true;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesRelated";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabDirectorType";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "DirectorTypeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InDirectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabDirectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabDirectorAction";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "DirectorActionId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InDirectorListUsesPrimary";
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesPrimary";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InDirectorListUsesRelated";
					l.IsOutgoing = false;
					l.FromDto = "FabDirector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesRelated";
					l.ToDto = "FabDirectorAction";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabEventor";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "EventorId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "DateTimeTimestamp";
				p.Type = "long";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabEventor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesEventorType";
					l.IsOutgoing = true;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesEventorPrecision";
					l.IsOutgoing = true;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabEventorPrecision";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabEventorType";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "EventorTypeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InEventorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabEventorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabEventorPrecision";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "EventorPrecisionId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InEventorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabEventor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabEventorPrecision";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabIdentor";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "IdentorId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Value";
				p.Type = "string";
				p.LenMax = 128;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabIdentor";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesIdentorType";
					l.IsOutgoing = true;
					l.FromDto = "FabIdentor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabIdentorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabIdentorType";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "IdentorTypeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InIdentorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabIdentor";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabIdentorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabLocator";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "LocatorId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "ValueX";
				p.Type = "double";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "ValueY";
				p.Type = "double";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "ValueZ";
				p.Type = "double";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabLocator";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesLocatorType";
					l.IsOutgoing = true;
					l.FromDto = "FabLocator";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabLocatorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabLocatorType";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "LocatorTypeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "MinX";
				p.Type = "double";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "MaxX";
				p.Type = "double";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "MinY";
				p.Type = "double";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "MaxY";
				p.Type = "double";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "MinZ";
				p.Type = "double";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "MaxZ";
				p.Type = "double";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InLocatorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabLocator";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabLocatorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabVector";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "VectorId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Value";
				p.Type = "long";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InFactorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabFactor";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabVector";
					l.ToDtoConn = "InFromOneOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesAxisArtifact";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "UsesAxis";
					l.ToDto = "FabArtifact";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesVectorType";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesVectorUnitPrefix";
					l.IsOutgoing = true;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabVectorType";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "VectorTypeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Min";
				p.Type = "long";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Max";
				p.Type = "long";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorType";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesVectorRange";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorType";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabVectorRange";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "VectorRangeId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InVectorTypeListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorType";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorRange";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesVectorRangeLevelList";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorRange";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Uses";
					l.ToDto = "FabVectorRangeLevel";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabVectorRangeLevel";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "VectorRangeLevelId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Position";
				p.Type = "float";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InVectorRangeListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorRange";
					l.FromDtoConn = "OutToZeroOrMore";
					l.Verb = "Uses";
					l.ToDto = "FabVectorRangeLevel";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabVectorUnit";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "VectorUnitId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Symbol";
				p.Type = "string";
				p.LenMax = 8;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InVectorUnitDerivedListDefines";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Defines";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InVectorUnitDerivedListRaisesToExp";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "RaisesToExp";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabVectorUnitPrefix";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "VectorUnitPrefixId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Symbol";
				p.Type = "string";
				p.LenMax = 8;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Amount";
				p.Type = "double";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "InVectorListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVector";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "InVectorUnitDerivedListUses";
					l.IsOutgoing = false;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabVectorUnitDerived";
			dto.Extends = "FabNodeForType";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "VectorUnitDerivedId";
				p.Type = "byte";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Exponent";
				p.Type = "int";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "DefinesVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Defines";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "RaisesToExpVectorUnit";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "RaisesToExp";
					l.ToDto = "FabVectorUnit";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesVectorUnitPrefix";
					l.IsOutgoing = true;
					l.FromDto = "FabVectorUnitDerived";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabVectorUnitPrefix";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabOauthAccess";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "OauthAccessId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Token";
				p.Type = "string";
				p.IsNullable = true;
				p.IsUnique = true;
				p.Len = 32;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Refresh";
				p.Type = "string";
				p.IsNullable = true;
				p.Len = 32;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "ExpiresTimestamp";
				p.Type = "long";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "IsClientOnly";
				p.Type = "bool";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "UsesApp";
					l.IsOutgoing = true;
					l.FromDto = "FabOauthAccess";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesUser";
					l.IsOutgoing = true;
					l.FromDto = "FabOauthAccess";
					l.FromDtoConn = "OutToZeroOrOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabOauthDomain";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "OauthDomainId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Domain";
				p.Type = "string";
				p.LenMax = 256;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "UsesApp";
					l.IsOutgoing = true;
					l.FromDto = "FabOauthDomain";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabOauthGrant";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "OauthGrantId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "RedirectUri";
				p.Type = "string";
				p.LenMax = 450;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Code";
				p.Type = "string";
				p.IsUnique = true;
				p.Len = 32;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "ExpiresTimestamp";
				p.Type = "long";
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "UsesApp";
					l.IsOutgoing = true;
					l.FromDto = "FabOauthGrant";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesUser";
					l.IsOutgoing = true;
					l.FromDto = "FabOauthGrant";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			////

			dto = new ApiSpecDto();
			dto.Name = "FabOauthScope";
			dto.Extends = "FabNode";
			dto.Abstract = "TODO";
			dto.Description = "TODO";
			list.Add(dto);
	
				p = new ApiSpecProperty();
				p.Name = "OauthScopeId";
				p.Type = "long";
				p.IsPrimaryKey = true;
				p.IsUnique = true;
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "Allow";
				p.Type = "bool";
				dto.PropertyList.Add(p);

				p = new ApiSpecProperty();
				p.Name = "CreatedTimestamp";
				p.Type = "long";
				p.IsTimestamp = true;
				dto.PropertyList.Add(p);

					l = new ApiSpecLink();
					l.Name = "UsesApp";
					l.IsOutgoing = true;
					l.FromDto = "FabOauthScope";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabApp";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

					l = new ApiSpecLink();
					l.Name = "UsesUser";
					l.IsOutgoing = true;
					l.FromDto = "FabOauthScope";
					l.FromDtoConn = "OutToOne";
					l.Verb = "Uses";
					l.ToDto = "FabUser";
					l.ToDtoConn = "InFromZeroOrMore";
					dto.LinkList.Add(l);

			return list;
		}

	}

}