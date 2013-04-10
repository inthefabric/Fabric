using System;
using System.Collections.Generic;
using Weaver.Items;
using Weaver.Schema;

namespace Fabric.Domain.Meta {

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

		public const string ValidOauthDomainRegexp =
			@"^[a-zA-Z0-9]+(:[0-9]+|([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,6})$";

		public List<WeaverNodeSchema> Nodes { get; private set; }
		public List<WeaverRelSchema> Rels { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Schema() {
			Nodes = new List<WeaverNodeSchema>();
			Rels = new List<WeaverRelSchema>();
			FabricPropSchema p;

			////
			
			WeaverNodeSchema nodeForAction = AddNode("NodeForAction", null);
			nodeForAction.IsAbstract = true;
			nodeForAction.IsBaseClass = true;
			p = AddProp(nodeForAction, "Performed", typeof(DateTime));
				p.IsTimestamp = true;
			p = AddProp(nodeForAction, "Note", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsNullable = true;

			////

			WeaverNodeSchema artifact = AddNode("Artifact", "A");
			artifact.IsBaseClass = true;
			p = AddProp(artifact, "ArtifactId", typeof(long));
			p.IsPrimaryKey = true;
			p = AddProp(artifact, "Created", typeof(DateTime));
			p.IsTimestamp = true;

			WeaverNodeSchema app = AddNode("App", "Ap");
			app.BaseNode = artifact;
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

			WeaverNodeSchema clas = AddNode("Class", "Cl");
			clas.BaseNode = artifact;
			p = AddProp(clas, "ClassId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(clas, "Name", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(clas, "Disamb", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(clas, "Note", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsNullable = true;

			/*WeaverNodeSchema crowd = AddNode("Crowd", "C");
			crowd.BaseNode = artifact;
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
			p = AddProp(crowdianTypeAssign, "Weight", typeof(float));*/

			WeaverNodeSchema email = AddNode("Email", "E");
			email.IsInternal = true;
			p = AddProp(email, "EmailId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(email, "Address", typeof(string));
				p.LenMin = 1;
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
			instance.BaseNode = artifact;
			p = AddProp(instance, "InstanceId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(instance, "Name", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(instance, "Disamb", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(instance, "Note", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsNullable = true;

			/*WeaverNodeSchema label = AddNode("Label", "L");
			label.IsInternal = true;
			label.BaseNode = artifact;
			p = AddProp(label, "LabelId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(label, "Name", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidTitleRegex;*/

			WeaverNodeSchema member = AddNode("Member", "M");
			p = AddProp(member, "MemberId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema memberTypeAssign = AddNode("MemberTypeAssign", "MTA");
			memberTypeAssign.BaseNode = nodeForAction;
			p = AddProp(memberTypeAssign, "MemberTypeAssignId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(memberTypeAssign, "MemberTypeId", typeof(byte));
				p.EnumName = "MemberTypeId";

			WeaverNodeSchema url = AddNode("Url", "Ur");
			url.BaseNode = artifact;
			p = AddProp(url, "UrlId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(url, "Name", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
			p = AddProp(url, "AbsoluteUrl", typeof(string));
				p.LenMin = 1;
				p.LenMax = 2048;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;

			WeaverNodeSchema user = AddNode("User", "U");
			user.BaseNode = artifact;
			p = AddProp(user, "UserId", typeof(long));
				p.IsPrimaryKey = true;
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
			p = AddProp(factor, "FactorAssertionId", typeof(byte));
				p.EnumName = "FactorAssertionId";
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
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsNullable = true;

			p = AddProp(factor, "Descriptor_TypeId", typeof(byte));
				p.EnumName = "DescriptorTypeId";

			p = AddProp(factor, "Director_TypeId", typeof(byte));
				p.EnumName = "DirectorTypeId";
			p = AddProp(factor, "Director_PrimaryActionId", typeof(byte));
				p.EnumName = "DirectorActionId";
			p = AddProp(factor, "Director_RelatedActionId", typeof(byte));
			p.EnumName = "DirectorActionId";

			p = AddProp(factor, "Eventor_TypeId", typeof(byte));
				p.EnumName = "EventorTypeId";
			p = AddProp(factor, "Eventor_PrecisionId", typeof(byte));
				p.EnumName = "EventorPrecisionId";
			p = AddProp(factor, "Eventor_DateTime", typeof(DateTime));
				p.Min = 1;

			p = AddProp(factor, "Identor_TypeId", typeof(byte));
				p.EnumName = "IdentorTypeId";
			p = AddProp(factor, "Identor_Value", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;

			p = AddProp(factor, "Locator_TypeId", typeof(byte));
				p.EnumName = "LocatorTypeId";
			p = AddProp(factor, "Locator_ValueX", typeof(double));
			p = AddProp(factor, "Locator_ValueY", typeof(double));
			p = AddProp(factor, "Locator_ValueZ", typeof(double));

			p = AddProp(factor, "Vector_TypeId", typeof(byte));
				p.EnumName = "VectorTypeId";
			p = AddProp(factor, "Vector_UnitId", typeof(byte));
				p.EnumName = "VectorUnitId";
			p = AddProp(factor, "Vector_UnitPrefixId", typeof(byte));
				p.EnumName = "VectorUnitPrefixId";
			p = AddProp(factor, "Vector_Value", typeof(long));
			
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
				p.LenMin = 1;
				p.LenMax = 256;
				p.ValidRegex = ValidOauthDomainRegexp;
			
			WeaverNodeSchema oauthGrant = AddNode("OauthGrant", "OG");
			oauthGrant.IsInternal = true;
			p = AddProp(oauthGrant, "OauthGrantId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthGrant, "RedirectUri", typeof(string));
				p.LenMin = 1;
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

			const string has = "Has";
			const string hasHistoric = "HasHistoric";
			const string uses = "Uses";
			const string usesPrimary = "UsesPrimary";
			const string usesRelated = "UsesRelated";
			const string creates = "Creates";
			//const string replaces = "Replaces";
			const string refinesPrimaryWith = "DescriptorRefinesPrimaryWith";
			const string refinesRelatedWith = "DescriptorRefinesRelatedWith";
			const string refinesTypeWith = "DescriptorRefinesTypeWith";
			const string usesAxis = "VectorUsesAxis";
			const string defines = "Defines";

			const WeaverRelConn ifo = WeaverRelConn.InFromOne;
			//const WeaverRelConn ifoom = WeaverRelConn.InFromOneOrMore;
			const WeaverRelConn ifzom = WeaverRelConn.InFromZeroOrMore;
			//const WeaverRelConn ifzoo = WeaverRelConn.InFromZeroOrOne;
			const WeaverRelConn oto = WeaverRelConn.OutToOne;
			const WeaverRelConn otoom = WeaverRelConn.OutToOneOrMore;
			const WeaverRelConn otzom = WeaverRelConn.OutToZeroOrMore;
			const WeaverRelConn otzoo = WeaverRelConn.OutToZeroOrOne;

			AddRel(app, uses, email, oto, ifo);
			AddRel(app, defines, member, otoom, ifo);

			//AddRel(crowd, defines, crowdian, otoom, ifo);

			//AddRel(crowdian, has, crowdianTypeAssign, oto, ifo);
			//AddRel(crowdian, hasHistoric, crowdianTypeAssign, otzom, ifo);

			//AddRel(crowdianTypeAssign, uses, crowdianType, oto, ifzom);

			AddRel(member, has, memberTypeAssign, oto, ifo);
			AddRel(member, hasHistoric, memberTypeAssign, otzom, ifo);
			AddRel(member, creates, artifact, otzom, ifo);
			AddRel(member, creates, memberTypeAssign, otzom, ifo);
			AddRel(member, creates, factor, otzom, ifo);

			//AddRel(user, creates, crowdianTypeAssign, otzom, ifo);
			//AddRel(user, defines, crowdian, otzom, ifo);
			AddRel(user, uses, email, oto, ifo);
			AddRel(user, defines, member, otoom, ifo);

			////

			AddRel(factor, usesPrimary, artifact, oto, ifzom);
			AddRel(factor, usesRelated, artifact, oto, ifzom);
			//AddRel(factor, replaces, factor, otzoo, ifzoo);
			AddRel(factor, refinesPrimaryWith, artifact, otzoo, ifzom); //Descriptor
			AddRel(factor, refinesRelatedWith, artifact, otzoo, ifzom); //Descriptor
			AddRel(factor, refinesTypeWith, artifact, otzoo, ifzom); //Descriptor
			AddRel(factor, usesAxis, artifact, otzoo, ifzom); //Vector

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
		public FabricPropSchema AddProp(WeaverNodeSchema pNode, string pName, Type pType) {
			var p = new FabricPropSchema(pName, pType);
			pNode.Props.Add(p);
			return p;
		}

	}

}