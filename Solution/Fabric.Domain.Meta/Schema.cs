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

			WeaverNodeSchema node = AddNode("Node", "N");
			node.IsAbstract = true;
			node.IsBaseClass = true;
			node.IsInternal = true;
			p = AddProp(node, "FabType", "FT", typeof(int));
				p.IsInternal = true;

			////
			
			WeaverNodeSchema nodeForAction = AddNode("NodeForAction", "NA");
			nodeForAction.BaseNode = node;
			nodeForAction.IsAbstract = true;
			nodeForAction.IsBaseClass = true;
			p = AddProp(nodeForAction, "Performed", "Pe", typeof(DateTime));
				p.IsTimestamp = true;
			p = AddProp(nodeForAction, "Note", "No", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsNullable = true;

			////

			WeaverNodeSchema artifact = AddNode("Artifact", "A");
			artifact.BaseNode = node;
			artifact.IsBaseClass = true;
			p = AddProp(artifact, "ArtifactId", "AId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(artifact, "Created", "Cr", typeof(DateTime));
				p.IsTimestamp = true;

			WeaverNodeSchema app = AddNode("App", "Ap");
			app.BaseNode = artifact;
			p = AddProp(app, "AppId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(app, "Name", "Na", typeof(string));
				p.LenMin = 3;
				p.LenMax = 64;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(app, "Secret", "Se", typeof(string));
				p.Len = 32;
				p.IsInternal = true;
				p.ValidRegex = ValidCodeRegex;

			WeaverNodeSchema clas = AddNode("Class", "Cl");
			clas.BaseNode = artifact;
			p = AddProp(clas, "ClassId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(clas, "Name", "Na", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(clas, "Disamb", "Di", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(clas, "Note", "No", typeof(string));
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
			email.BaseNode = node;
			email.IsInternal = true;
			p = AddProp(email, "EmailId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(email, "Address", "Ad", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidEmailRegex;
			p = AddProp(email, "Code", "Co", typeof(string));
				p.Len = 32;
				p.ValidRegex = ValidCodeRegex;
			p = AddProp(email, "Created", "Cr", typeof(DateTime));
				p.IsTimestamp = true;
			p = AddProp(email, "Verified", "Ve", typeof(DateTime));
				p.IsNullable = true;
			
			WeaverNodeSchema instance = AddNode("Instance", "In");
			instance.BaseNode = artifact;
			p = AddProp(instance, "InstanceId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(instance, "Name", "Na", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(instance, "Disamb", "Di", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
			p = AddProp(instance, "Note", "No", typeof(string));
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
			p = AddProp(member, "MemberId", "Id", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema memberTypeAssign = AddNode("MemberTypeAssign", "MTA");
			memberTypeAssign.BaseNode = nodeForAction;
			p = AddProp(memberTypeAssign, "MemberTypeAssignId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(memberTypeAssign, "MemberTypeId", "Mt", typeof(byte));
				p.EnumName = "MemberTypeId";

			WeaverNodeSchema url = AddNode("Url", "Ur");
			url.BaseNode = artifact;
			p = AddProp(url, "UrlId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(url, "Name", "Na", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
			p = AddProp(url, "AbsoluteUrl", "Ab", typeof(string));
				p.LenMin = 1;
				p.LenMax = 2048;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;

			WeaverNodeSchema user = AddNode("User", "U");
			user.BaseNode = artifact;
			p = AddProp(user, "UserId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(user, "Name", "Na", typeof(string));
				p.LenMin = 4;
				p.LenMax = 16;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidUserRegex;
			p = AddProp(user, "Password", "Pa", typeof(string));
				p.LenMin = 8;
				p.LenMax = 32;
				p.IsInternal = true;
				p.IsPassword = true;

			////

			WeaverNodeSchema factor = AddNode("Factor", "F");
			factor.BaseNode = node;
			p = AddProp(factor, "FactorId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(factor, "FactorAssertionId", "Fa", typeof(byte));
				p.EnumName = "FactorAssertionId";
			//p = AddProp(factor, "IsPublic", typeof(bool));
			p = AddProp(factor, "IsDefining", "Df", typeof(bool));
			p = AddProp(factor, "Created", "Cr", typeof(DateTime));
				p.IsTimestamp = true;
			p = AddProp(factor, "Deleted", "Dl", typeof(DateTime));
				p.IsNullable = true;
				p.IsInternal = true;
			p = AddProp(factor, "Completed", "Co", typeof(DateTime));
				p.IsNullable = true;
			p = AddProp(factor, "Note", "No", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsNullable = true;

			p = AddProp(factor, "Descriptor_TypeId", "DeT", typeof(byte));
				p.EnumName = "DescriptorTypeId";
				p.SubObjIsOptional = false;

			p = AddProp(factor, "Director_TypeId", "DiT", typeof(byte));
				p.EnumName = "DirectorTypeId";
			p = AddProp(factor, "Director_PrimaryActionId", "DiP", typeof(byte));
				p.EnumName = "DirectorActionId";
			p = AddProp(factor, "Director_RelatedActionId", "DiR", typeof(byte));
				p.EnumName = "DirectorActionId";

			p = AddProp(factor, "Eventor_TypeId", "EvT", typeof(byte));
				p.EnumName = "EventorTypeId";
			p = AddProp(factor, "Eventor_PrecisionId", "EvP", typeof(byte));
				p.EnumName = "EventorPrecisionId";
			p = AddProp(factor, "Eventor_DateTime", "EvD", typeof(DateTime));
				p.Min = 1;

			p = AddProp(factor, "Identor_TypeId", "IdT", typeof(byte));
				p.EnumName = "IdentorTypeId";
			p = AddProp(factor, "Identor_Value", "IdV", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;

			p = AddProp(factor, "Locator_TypeId", "LoT", typeof(byte));
				p.EnumName = "LocatorTypeId";
			p = AddProp(factor, "Locator_ValueX", "LoX", typeof(double));
			p = AddProp(factor, "Locator_ValueY", "LoY", typeof(double));
			p = AddProp(factor, "Locator_ValueZ", "LoZ", typeof(double));

			p = AddProp(factor, "Vector_TypeId", "VeT", typeof(byte));
				p.EnumName = "VectorTypeId";
			p = AddProp(factor, "Vector_UnitId", "VeU", typeof(byte));
				p.EnumName = "VectorUnitId";
			p = AddProp(factor, "Vector_UnitPrefixId", "VeP", typeof(byte));
				p.EnumName = "VectorUnitPrefixId";
			p = AddProp(factor, "Vector_Value", "VeV", typeof(long));
			
			////

			WeaverNodeSchema oauthAccess = AddNode("OauthAccess", "OA");
			oauthAccess.BaseNode = node;
			oauthAccess.IsInternal = true;
			p = AddProp(oauthAccess, "OauthAccessId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthAccess, "Token", "To", typeof(string));
				p.Len = 32;
				p.IsNullable = true;
				p.IsUnique = true;
				p.ValidRegex = ValidCodeRegex;
			p = AddProp(oauthAccess, "Refresh", "Re", typeof(string));
				p.Len = 32;
				p.IsNullable = true;
				p.ValidRegex = ValidCodeRegex;
			p = AddProp(oauthAccess, "Expires", "Ex", typeof(DateTime));
			p = AddProp(oauthAccess, "IsClientOnly", "CO", typeof(bool));

			WeaverNodeSchema oauthDomain = AddNode("OauthDomain", "OD");
			oauthDomain.BaseNode = node;
			oauthDomain.IsInternal = true;
			p = AddProp(oauthDomain, "OauthDomainId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthDomain, "Domain", "Do", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.ValidRegex = ValidOauthDomainRegexp;
			
			WeaverNodeSchema oauthGrant = AddNode("OauthGrant", "OG");
			oauthGrant.BaseNode = node;
			oauthGrant.IsInternal = true;
			p = AddProp(oauthGrant, "OauthGrantId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthGrant, "RedirectUri", "Re", typeof(string));
				p.LenMin = 1;
				p.LenMax = 450;
			p = AddProp(oauthGrant, "Code", "Co", typeof(string));
				p.Len = 32;
				p.IsUnique = true;
				p.ValidRegex = ValidCodeRegex;
			p = AddProp(oauthGrant, "Expires", "Ex", typeof(DateTime));

			WeaverNodeSchema oauthScope = AddNode("OauthScope", "OS");
			oauthScope.BaseNode = node;
			oauthScope.IsInternal = true;
			p = AddProp(oauthScope, "OauthScopeId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthScope, "Allow", "Al", typeof(bool));
			p = AddProp(oauthScope, "Created", "Cr", typeof(DateTime));
				p.IsTimestamp = true;

			////

			var has = new KeyValuePair<string, string>("Has", "H");
			var hasHistoric = new KeyValuePair<string, string>("HasHistoric", "HH");
			var uses = new KeyValuePair<string, string>("Uses", "U");
			var usesPrimary = new KeyValuePair<string, string>("UsesPrimary", "UP");
			var usesRelated = new KeyValuePair<string, string>("UsesRelated", "UR");
			var creates = new KeyValuePair<string, string>("Creates", "C");
			//var replaces = new KeyValuePair<string, string>("Replaces", "R");
			var refinesPrimaryWith = 
				new KeyValuePair<string, string>("DescriptorRefinesPrimaryWith", "DRP");
			var refinesRelatedWith = 
				new KeyValuePair<string, string>("DescriptorRefinesRelatedWith", "DRR");
			var refinesTypeWith = new KeyValuePair<string, string>("DescriptorRefinesTypeWith", "DRT");
			var usesAxis = new KeyValuePair<string, string>("VectorUsesAxis", "VUA");
			var defines = new KeyValuePair<string, string>("Defines", "D");

			const WeaverRelConn ifo = WeaverRelConn.InFromOne;
			const WeaverRelConn ifoom = WeaverRelConn.InFromOneOrMore;
			const WeaverRelConn ifzom = WeaverRelConn.InFromZeroOrMore;
			//const WeaverRelConn ifzoo = WeaverRelConn.InFromZeroOrOne;
			const WeaverRelConn oto = WeaverRelConn.OutToOne;
			const WeaverRelConn otoom = WeaverRelConn.OutToOneOrMore;
			const WeaverRelConn otzom = WeaverRelConn.OutToZeroOrMore;
			const WeaverRelConn otzoo = WeaverRelConn.OutToZeroOrOne;

			AddRel(app, uses, email, oto, ifzom);
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
			AddRel(user, uses, email, oto, ifoom);
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
		private WeaverNodeSchema AddNode(string pName, string pDbName) {
			var n = new WeaverNodeSchema(pName, pDbName);
			Nodes.Add(n);
			//Console.WriteLine("NODE: "+n.DbName+" ("+n.Name+")");
			return n;
		}

		/*--------------------------------------------------------------------------------------------*/
		private WeaverRelSchema AddRel(WeaverNodeSchema pFrom, KeyValuePair<string, string> pRelType,
								WeaverNodeSchema pTo, WeaverRelConn pFromConn, WeaverRelConn pToConn) {
			string name = pFrom.Name+pRelType.Key+pTo.Name;
			string db = pFrom.DbName+"-"+pRelType.Value+"-"+pTo.DbName;

			var r = new WeaverRelSchema(pFrom, name, db, pRelType.Key, pTo);
			r.FromNodeConn = pFromConn;
			r.ToNodeConn = pToConn;
			Rels.Add(r);
			//Console.WriteLine("REL: "+db+" ("+r.Name+")");
			return r;
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabricPropSchema AddProp(WeaverNodeSchema pNode, string pName, string pDbName,
																						Type pType) {
			var p = new FabricPropSchema(pName, pNode.DbName+'_'+pDbName, pType);
			pNode.Props.Add(p);
			//Console.WriteLine(" - "+p.DbName+" ("+pNode.Name+"."+p.Name+")");
			return p;
		}

	}

}