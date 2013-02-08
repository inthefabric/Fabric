﻿using System;
using System.Collections.Generic;
using Weaver.Items;
using Weaver.Schema;

namespace Fabric.Infrastructure.Domain {

	/*================================================================================================*/
	public class Schema {

		private const string ValidEmailRegex = @"^(([^<>()[\]\\.,;:\s@\""]+" 
			+ @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@" 
			+ @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}" 
			+ @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+" 
			+ @"[a-zA-Z]{2,}))$";

		private const string ValidCodeRegex = 
			@"^[a-zA-Z0-9]*$";

		private const string ValidUserRegex = 
			@"^[a-zA-Z0-9_]*$";

		private const string ValidTitleRegex = 
			@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\"+"/!@#$%&=_,:;'\"<>~]*$";

		public List<WeaverNodeSchema> Nodes { get; private set; }
		public List<WeaverRelSchema> Rels { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Schema() {
			Nodes = new List<WeaverNodeSchema>();
			Rels = new List<WeaverRelSchema>();
			WeaverPropSchema p;

			////

			WeaverNodeSchema nodeForType = AddNode("NodeForType", null);
			nodeForType.IsAbstract = true;
			p = AddProp(nodeForType, "Name", typeof(string));
				p.LenMin = 1;
				p.LenMax = 32;
				p.IsUnique = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(nodeForType, "Description", typeof(string));
				p.LenMax = 256;
				p.ValidRegex = ValidTitleRegex;

			WeaverNodeSchema nodeForAction = AddNode("NodeForAction", null);
			nodeForAction.IsAbstract = true;
			p = AddProp(nodeForAction, "Performed", typeof(DateTime));
				p.IsTimestamp = true;
			p = AddProp(nodeForAction, "Note", typeof(string));
				p.LenMax = 256;
				p.IsNullable = true;
			
			WeaverNodeSchema artOwnerNode = AddNode("ArtifactOwnerNode", null);
			artOwnerNode.IsAbstract = true;

			////

			WeaverNodeSchema root = AddNode("Root", "R");
			root.IsRoot = true;
			p = AddProp(root, "RootId", typeof(int));
				p.IsPrimaryKey = true;

			////

			WeaverNodeSchema app = AddNode("App", "Ap");
			app.BaseNode = artOwnerNode;
			p = AddProp(app, "AppId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(app, "Name", typeof(string));
				p.LenMin = 3;
				p.LenMax = 64;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(app, "Secret", typeof(string));
				p.Len = 32;
				p.IsInternal = true;
				p.ValidRegex = ValidCodeRegex;

			WeaverNodeSchema artifact = AddNode("Artifact", "A");
			p = AddProp(artifact, "ArtifactId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(artifact, "IsPrivate", typeof(bool));
			p = AddProp(artifact, "Created", typeof(DateTime));
				p.IsTimestamp = true;

			WeaverNodeSchema artifactType = AddNode("ArtifactType", "AT");
			artifactType.BaseNode = nodeForType;
			p = AddProp(artifactType, "ArtifactTypeId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema clas = AddNode("Class", "Cl");
			clas.BaseNode = artOwnerNode;
			p = AddProp(clas, "ClassId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(clas, "Name", typeof(string));
				p.LenMax = 128;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(clas, "Disamb", typeof(string));
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(clas, "Note", typeof(string));
				p.LenMax = 256;
				p.IsNullable = true;

			WeaverNodeSchema crowd = AddNode("Crowd", "C");
			crowd.BaseNode = artOwnerNode;
			crowd.IsInternal = true;
			p = AddProp(crowd, "CrowdId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(crowd, "Name", typeof(string));
				p.LenMin = 3;
				p.LenMax = 64;
			p = AddProp(crowd, "Description", typeof(string));
				p.LenMax = 256;
			p = AddProp(crowd, "IsPrivate", typeof(bool));
			p = AddProp(crowd, "IsInviteOnly", typeof(bool));

			WeaverNodeSchema crowdian = AddNode("Crowdian", "Cn");
			crowdian.IsInternal = true;
			p = AddProp(crowdian, "CrowdianId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema crowdianType = AddNode("CrowdianType", "CT");
			crowdianType.IsInternal = true;
			crowdianType.BaseNode = nodeForType;
			p = AddProp(crowdianType, "CrowdianTypeId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema crowdianTypeAssign = AddNode("CrowdianTypeAssign", "CTA");
			crowdianTypeAssign.IsInternal = true;
			crowdianTypeAssign.BaseNode = nodeForAction;
			p = AddProp(crowdianTypeAssign, "CrowdianTypeAssignId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(crowdianTypeAssign, "Weight", typeof(float));

			WeaverNodeSchema email = AddNode("Email", "E");
			email.IsInternal = true;
			p = AddProp(email, "EmailId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(email, "Address", typeof(string));
				p.LenMax = 256;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidEmailRegex;
			p = AddProp(email, "Code", typeof(string));
				p.Len = 32;
				p.ValidRegex = ValidCodeRegex;
			p = AddProp(email, "Created", typeof(DateTime));
				p.IsTimestamp = true;
			p = AddProp(email, "Verified", typeof(DateTime));
				p.IsNullable = true;
			
			WeaverNodeSchema instance = AddNode("Instance", "In");
			instance.BaseNode = artOwnerNode;
			p = AddProp(instance, "InstanceId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(instance, "Name", typeof(string));
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(instance, "Disamb", typeof(string));
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(instance, "Note", typeof(string));
				p.LenMax = 256;
				p.IsNullable = true;

			WeaverNodeSchema label = AddNode("Label", "L");
			label.IsInternal = true;
			label.BaseNode = artOwnerNode;
			p = AddProp(label, "LabelId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(label, "Name", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidTitleRegex;

			WeaverNodeSchema member = AddNode("Member", "M");
			p = AddProp(member, "MemberId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema memberType = AddNode("MemberType", "MT");
			memberType.BaseNode = nodeForType;
			p = AddProp(memberType, "MemberTypeId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema memberTypeAssign = AddNode("MemberTypeAssign", "MTA");
			memberTypeAssign.BaseNode = nodeForAction;
			p = AddProp(memberTypeAssign, "MemberTypeAssignId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema url = AddNode("Url", "Ur");
			url.BaseNode = artOwnerNode;
			p = AddProp(url, "UrlId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(url, "Name", typeof(string));
				p.LenMax = 128;
			p = AddProp(url, "AbsoluteUrl", typeof(string));
				p.LenMax = 2048;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;

			WeaverNodeSchema user = AddNode("User", "U");
			user.BaseNode = artOwnerNode;
			p = AddProp(user, "UserId", typeof(long));
			p = AddProp(user, "Name", typeof(string));
				p.LenMin = 4;
				p.LenMax = 16;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidUserRegex;
			p = AddProp(user, "Password", typeof(string));
				p.LenMin = 8;
				p.LenMax = 32;
				p.IsInternal = true;
				p.IsPassword = true;

			////

			WeaverNodeSchema factor = AddNode("Factor", "F");
			p = AddProp(factor, "FactorId", typeof(long));
				p.IsPrimaryKey = true;
			//p = AddProp(factor, "IsPublic", typeof(bool));
			p = AddProp(factor, "IsDefining", typeof(bool));
			p = AddProp(factor, "Created", typeof(DateTime));
				p.IsTimestamp = true;
			p = AddProp(factor, "Deleted", typeof(DateTime));
				p.IsNullable = true;
				p.IsInternal = true;
			p = AddProp(factor, "Completed", typeof(DateTime));
				p.IsNullable = true;
			p = AddProp(factor, "Note", typeof(string));
				p.LenMax = 256;
				p.IsNullable = true;

			WeaverNodeSchema factorAssertion = AddNode("FactorAssertion", "FA");
			factorAssertion.BaseNode = nodeForType;
			p = AddProp(factorAssertion, "FactorAssertionId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema factorElementNode = AddNode("FactorElementNode", null);
			factorElementNode.IsAbstract = true;

			WeaverNodeSchema descriptor = AddNode("Descriptor", "De");
			descriptor.BaseNode = factorElementNode;
			p = AddProp(descriptor, "DescriptorId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema descriptorType = AddNode("DescriptorType", "DeT");
			descriptorType.BaseNode = nodeForType;
			p = AddProp(descriptorType, "DescriptorTypeId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema director = AddNode("Director", "Di");
			director.BaseNode = factorElementNode;
			p = AddProp(director, "DirectorId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema directorType = AddNode("DirectorType", "DiT");
			directorType.BaseNode = nodeForType;
			p = AddProp(directorType, "DirectorTypeId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema directorAction = AddNode("DirectorAction", "DiA");
			directorAction.BaseNode = nodeForType;
			p = AddProp(directorAction, "DirectorActionId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema eventor = AddNode("Eventor", "Ev");
			eventor.BaseNode = factorElementNode;
			p = AddProp(eventor, "EventorId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(eventor, "DateTime", typeof(DateTime));

			WeaverNodeSchema eventorType = AddNode("EventorType", "EvT");
			eventorType.BaseNode = nodeForType;
			p = AddProp(eventorType, "EventorTypeId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema eventorPrecision = AddNode("EventorPrecision", "EvP");
			eventorPrecision.BaseNode = nodeForType;
			p = AddProp(eventorPrecision, "EventorPrecisionId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema identor = AddNode("Identor", "Id");
			identor.BaseNode = factorElementNode;
			p = AddProp(identor, "IdentorId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(identor, "Value", typeof(string));
				p.LenMax = 128;

			WeaverNodeSchema identorType = AddNode("IdentorType", "IdT");
			identorType.BaseNode = nodeForType;
			p = AddProp(identorType, "IdentorTypeId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema locator = AddNode("Locator", "Lo");
			locator.BaseNode = factorElementNode;
			p = AddProp(locator, "LocatorId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(locator, "ValueX", typeof(double));
			p = AddProp(locator, "ValueY", typeof(double));
			p = AddProp(locator, "ValueZ", typeof(double));

			WeaverNodeSchema locatorType = AddNode("LocatorType", "LoT");
			locatorType.BaseNode = nodeForType;
			p = AddProp(locatorType, "LocatorTypeId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(locatorType, "MinX", typeof(double));
			p = AddProp(locatorType, "MaxX", typeof(double));
			p = AddProp(locatorType, "MinY", typeof(double));
			p = AddProp(locatorType, "MaxY", typeof(double));
			p = AddProp(locatorType, "MinZ", typeof(double));
			p = AddProp(locatorType, "MaxZ", typeof(double));

			WeaverNodeSchema vector = AddNode("Vector", "Ve");
			vector.BaseNode = factorElementNode;
			p = AddProp(vector, "VectorId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(vector, "Value", typeof(long));

			WeaverNodeSchema vectorType = AddNode("VectorType", "VeT");
			vectorType.BaseNode = nodeForType;
			p = AddProp(vectorType, "VectorTypeId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(vectorType, "Min", typeof(long));
			p = AddProp(vectorType, "Max", typeof(long));

			WeaverNodeSchema vectorRange = AddNode("VectorRange", "VeR");
			vectorRange.BaseNode = nodeForType;
			p = AddProp(vectorRange, "VectorRangeId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema vectorRangeLevel = AddNode("VectorRangeLevel", "VeRL");
			vectorRangeLevel.BaseNode = nodeForType;
			p = AddProp(vectorRangeLevel, "VectorRangeLevelId", typeof(long));
				p.IsPrimaryKey = true;
				p = AddProp(vectorRangeLevel, "Position", typeof(float));
			
			WeaverNodeSchema vectorUnit = AddNode("VectorUnit", "VeU");
			vectorUnit.BaseNode = nodeForType;
			p = AddProp(vectorUnit, "VectorUnitId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(vectorUnit, "Symbol", typeof(string));
				p.LenMax = 8;
			
			WeaverNodeSchema vectorUnitPrefix = AddNode("VectorUnitPrefix", "VeUP");
			vectorUnitPrefix.BaseNode = nodeForType;
			p = AddProp(vectorUnitPrefix, "VectorUnitPrefixId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(vectorUnitPrefix, "Symbol", typeof(string));
				p.LenMax = 8;
			p = AddProp(vectorUnitPrefix, "Amount", typeof(double));
			
			WeaverNodeSchema vectorUnitDerived = AddNode("VectorUnitDerived", "VeUD");
			vectorUnitDerived.BaseNode = nodeForType;
			p = AddProp(vectorUnitDerived, "VectorUnitDerivedId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(vectorUnitDerived, "Exponent", typeof(int));
			
			////

			WeaverNodeSchema oauthAccess = AddNode("OauthAccess", "OA");
			oauthAccess.IsInternal = true;
			p = AddProp(oauthAccess, "OauthAccessId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthAccess, "Token", typeof(string));
				p.Len = 32;
				p.IsNullable = true;
				p.IsUnique = true;
				p.ValidRegex = ValidCodeRegex;
			p = AddProp(oauthAccess, "Refresh", typeof(string));
				p.Len = 32;
				p.IsNullable = true;
				p.ValidRegex = ValidCodeRegex;
			p = AddProp(oauthAccess, "Expires", typeof(DateTime));
			p = AddProp(oauthAccess, "IsClientOnly", typeof(bool));

			WeaverNodeSchema oauthDomain = AddNode("OauthDomain", "OD");
			oauthDomain.IsInternal = true;
			p = AddProp(oauthDomain, "OauthDomainId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthDomain, "Domain", typeof(string));
				p.LenMax = 256;
			
			WeaverNodeSchema oauthGrant = AddNode("OauthGrant", "OG");
			oauthGrant.IsInternal = true;
			p = AddProp(oauthGrant, "OauthGrantId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthGrant, "RedirectUri", typeof(string));
				p.LenMax = 450;
			p = AddProp(oauthGrant, "Code", typeof(string));
				p.Len = 32;
				p.IsUnique = true;
				p.ValidRegex = ValidCodeRegex;
			p = AddProp(oauthGrant, "Expires", typeof(DateTime));

			WeaverNodeSchema oauthScope = AddNode("OauthScope", "OS");
			oauthScope.IsInternal = true;
			p = AddProp(oauthScope, "OauthScopeId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthScope, "Allow", typeof(bool));
			p = AddProp(oauthScope, "Created", typeof(DateTime));
				p.IsTimestamp = true;

			////

			const string contains = "Contains";
			const string has = "Has";
			const string hasHistoric = "HasHistoric";
			const string uses = "Uses";
			const string usesPrimary = "UsesPrimary";
			const string usesRelated = "UsesRelated";
			const string usesAxis = "UsesAxis";
			const string creates = "Creates";
			const string replaces = "Replaces";
			const string refinesPrimaryWith = "RefinesPrimaryWith";
			const string refinesRelatedWith = "RefinesRelatedWith";
			const string refinesTypeWith = "RefinesTypeWith";
			const string defines = "Defines";
			const string raisesToExp = "RaisesToExp";

			const WeaverRelConn ifo = WeaverRelConn.InFromOne;
			const WeaverRelConn ifoom = WeaverRelConn.InFromOneOrMore;
			const WeaverRelConn ifzom = WeaverRelConn.InFromZeroOrMore;
			const WeaverRelConn ifzoo = WeaverRelConn.InFromZeroOrOne;
			const WeaverRelConn oto = WeaverRelConn.OutToOne;
			const WeaverRelConn otoom = WeaverRelConn.OutToOneOrMore;
			const WeaverRelConn otzom = WeaverRelConn.OutToZeroOrMore;
			const WeaverRelConn otzoo = WeaverRelConn.OutToZeroOrOne;

			AddRel(root, contains, app, otzom, ifo);
			AddRel(root, contains, artifact, otzom, ifo);
			AddRel(root, contains, artifactType, otzom, ifo);
			AddRel(root, contains, clas, otzom, ifo);
			AddRel(root, contains, crowd, otzom, ifo);
			AddRel(root, contains, crowdian, otzom, ifo);
			AddRel(root, contains, crowdianType, otzom, ifo);
			AddRel(root, contains, crowdianTypeAssign, otzom, ifo);
			AddRel(root, contains, email, otzom, ifo);
			AddRel(root, contains, label, otzom, ifo);
			AddRel(root, contains, instance, otzom, ifo);
			AddRel(root, contains, member, otzom, ifo);
			AddRel(root, contains, memberType, otzom, ifo);
			AddRel(root, contains, memberTypeAssign, otzom, ifo);
			AddRel(root, contains, url, otzom, ifo);
			AddRel(root, contains, user, otzom, ifo);
			
			AddRel(root, contains, factor, otzom, ifo);
			AddRel(root, contains, factorAssertion, otzom, ifo);
			AddRel(root, contains, descriptor, otzom, ifo);
			AddRel(root, contains, descriptorType, otzom, ifo);
			AddRel(root, contains, director, otzom, ifo);
			AddRel(root, contains, directorType, otzom, ifo);
			AddRel(root, contains, directorAction, otzom, ifo);
			AddRel(root, contains, eventor, otzom, ifo);
			AddRel(root, contains, eventorType, otzom, ifo);
			AddRel(root, contains, eventorPrecision, otzom, ifo);
			AddRel(root, contains, identor, otzom, ifo);
			AddRel(root, contains, identorType, otzom, ifo);
			AddRel(root, contains, locator, otzom, ifo);
			AddRel(root, contains, locatorType, otzom, ifo);
			AddRel(root, contains, vector, otzom, ifo);
			AddRel(root, contains, vectorType, otzom, ifo);
			AddRel(root, contains, vectorRange, otzom, ifo);
			AddRel(root, contains, vectorRangeLevel, otzom, ifo);
			AddRel(root, contains, vectorUnit, otzom, ifo);
			AddRel(root, contains, vectorUnitPrefix, otzom, ifo);
			AddRel(root, contains, vectorUnitDerived, otzom, ifo);

			AddRel(root, contains, oauthAccess, otzom, ifo);
			AddRel(root, contains, oauthDomain, otzom, ifo);
			AddRel(root, contains, oauthGrant, otzom, ifo);
			AddRel(root, contains, oauthScope, otzom, ifo);

			AddRel(app, has, artifact, oto, ifzoo);
			AddRel(app, uses, email, oto, ifo);
			AddRel(app, defines, member, otoom, ifo);

			AddRel(artifact, uses, artifactType, oto, ifzom);

			AddRel(clas, has, artifact, oto, ifzoo);

			AddRel(crowd, has, artifact, oto, ifzoo);
			AddRel(crowd, defines, crowdian, otoom, ifo);

			AddRel(crowdian, has, crowdianTypeAssign, oto, ifo);
			AddRel(crowdian, hasHistoric, crowdianTypeAssign, otzom, ifo);

			AddRel(crowdianTypeAssign, uses, crowdianType, oto, ifzom);

			AddRel(instance, has, artifact, oto, ifzoo);

			AddRel(label, has, artifact, oto, ifzoo);

			AddRel(member, has, memberTypeAssign, oto, ifo);
			AddRel(member, hasHistoric, memberTypeAssign, otzom, ifo);
			AddRel(member, creates, artifact, otzom, ifo);
			AddRel(member, creates, memberTypeAssign, otzom, ifo);
			AddRel(member, creates, factor, otzom, ifo);

			AddRel(memberTypeAssign, uses, memberType, oto, ifzom);

			AddRel(url, has, artifact, oto, ifzoo);

			AddRel(user, has, artifact, oto, ifzoo);
			AddRel(user, creates, crowdianTypeAssign, otzom, ifo);
			AddRel(user, defines, crowdian, otzom, ifo);
			AddRel(user, uses, email, oto, ifo);
			AddRel(user, defines, member, otoom, ifo);

			////

			AddRel(factor, usesPrimary, artifact, oto, ifzom);
			AddRel(factor, usesRelated, artifact, oto, ifzom);
			AddRel(factor, uses, factorAssertion, oto, ifzom);
			AddRel(factor, replaces, factor, otzoo, ifzoo);

			AddRel(factor, uses, descriptor, oto, ifoom);
			AddRel(factor, uses, director, otzoo, ifoom);
			AddRel(factor, uses, eventor, otzoo, ifoom);
			AddRel(factor, uses, identor, otzoo, ifoom);
			AddRel(factor, uses, locator, otzoo, ifoom);
			AddRel(factor, uses, vector, otzoo, ifoom);

			AddRel(descriptor, uses, descriptorType, oto, ifzom);
			AddRel(descriptor, refinesPrimaryWith, artifact, otzoo, ifzom);
			AddRel(descriptor, refinesRelatedWith, artifact, otzoo, ifzom);
			AddRel(descriptor, refinesTypeWith, artifact, otzoo, ifzom);

			AddRel(director, uses, directorType, oto, ifzom);
			AddRel(director, usesPrimary, directorAction, oto, ifzom);
			AddRel(director, usesRelated, directorAction, oto, ifzom);

			AddRel(eventor, uses, eventorType, oto, ifzom);
			AddRel(eventor, uses, eventorPrecision, oto, ifzom);

			AddRel(identor, uses, identorType, oto, ifzom);

			AddRel(locator, uses, locatorType, oto, ifzom);

			AddRel(vector, usesAxis, artifact, oto, ifzom);
			AddRel(vector, uses, vectorType, oto, ifzom);
			AddRel(vector, uses, vectorUnit, oto, ifzom);
			AddRel(vector, uses, vectorUnitPrefix, oto, ifzom);

			AddRel(vectorType, uses, vectorRange, oto, ifzom);

			AddRel(vectorRange, uses, vectorRangeLevel, otzom, ifzom);

			AddRel(vectorUnitDerived, defines, vectorUnit, oto, ifzom);
			AddRel(vectorUnitDerived, raisesToExp, vectorUnit, oto, ifzom);
			AddRel(vectorUnitDerived, uses, vectorUnitPrefix, oto, ifzom);

			////

			AddRel(oauthAccess, uses, app, oto, ifzom);
			AddRel(oauthAccess, uses, user, otzoo, ifzom);

			AddRel(oauthDomain, uses, app, oto, ifzom);

			AddRel(oauthGrant, uses, app, oto, ifzom);
			AddRel(oauthGrant, uses, user, oto, ifzom);

			AddRel(oauthScope, uses, app, oto, ifzom);
			AddRel(oauthScope, uses, user, oto, ifzom);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WeaverNodeSchema AddNode(string pName, string pShort) {
			var n = new WeaverNodeSchema(pName, pShort);
			Nodes.Add(n);
			return n;
		}

		/*--------------------------------------------------------------------------------------------*/
		public WeaverRelSchema AddRel(WeaverNodeSchema pFrom, string pRelType, WeaverNodeSchema pTo,
				WeaverRelConn pFromConn, WeaverRelConn pToConn) {
			var r = new WeaverRelSchema(pFrom, pRelType, pTo);
			r.FromNodeConn = pFromConn;
			r.ToNodeConn = pToConn;
			Rels.Add(r);
			return r;
		}

		/*--------------------------------------------------------------------------------------------*/
		public WeaverPropSchema AddProp(WeaverNodeSchema pNode, string pName, Type pType) {
			var p = new WeaverPropSchema(pName, pType);
			pNode.Props.Add(p);
			return p;
		}

	}

}