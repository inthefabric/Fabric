using System;
using System.Collections.Generic;
using Weaver.Items;
using Weaver.Schema;

namespace Fabric.Domain.Schema {

	/*================================================================================================*/
	public class GraphSchema {

		public static string ValidEmailRegex = @"^(([^<>()[\]\\.,;:\s@\""]+" 
			+ @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@" 
			+ @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}" 
			+ @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+" 
			+ @"[a-zA-Z]{2,}))$";

		public const string ValidUserRegex = 
			@"^[a-zA-Z0-9_]*$";

		public const string ValidTitleRegex = 
			@"^[a-zA-Z0-9 \[\]\+\?\|\(\)\{\}\^\*\-\.\\"+"/!@#$%&=_,:;'\"<>~]*$";

		public List<WeaverNodeSchema> Nodes { get; private set; }
		public List<WeaverRelSchema> Rels { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public GraphSchema() {
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

			////

			WeaverNodeSchema root = AddNode("Root", "R");
			root.IsRoot = true;

			////

			WeaverNodeSchema app = AddNode("App", "Ap");
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

			WeaverNodeSchema artifact = AddNode("Artifact", "A");
			p = AddProp(artifact, "ArtifactId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(artifact, "IsPrivate", typeof(bool));
			p = AddProp(artifact, "Created", typeof(DateTime));
				p.IsTimestamp = true;

			WeaverNodeSchema artifactType = AddNode("ArtifactType", "AT");
			artifactType.BaseNode = nodeForType;
			p = AddProp(artifactType, "ArtifactTypeId", typeof(byte));
				p.IsPrimaryKey = true;

			WeaverNodeSchema crowd = AddNode("Crowd", "C");
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
			p = AddProp(crowdian, "CrowdianId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverNodeSchema crowdianType = AddNode("CrowdianType", "CT");
			crowdianType.BaseNode = nodeForType;
			p = AddProp(crowdianType, "CrowdianTypeId", typeof(byte));
				p.IsPrimaryKey = true;

			WeaverNodeSchema crowdianTypeAssign = AddNode("CrowdianTypeAssign", "CTA");
			crowdianTypeAssign.BaseNode = nodeForAction;
			p = AddProp(crowdianTypeAssign, "Weight", typeof(float));

			WeaverNodeSchema email = AddNode("Email", "E");
			p = AddProp(email, "EmailId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(email, "Address", typeof(string));
				p.LenMax = 256;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidEmailRegex;
			p = AddProp(email, "Code", typeof(string));
				p.Len = 32;
			p = AddProp(email, "Created", typeof(DateTime));
				p.IsTimestamp = true;
			p = AddProp(email, "Verified", typeof(DateTime));
				p.IsNullable = true;

			WeaverNodeSchema label = AddNode("Label", "L");
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
			p = AddProp(memberType, "MemberTypeId", typeof(byte));
				p.IsPrimaryKey = true;

			WeaverNodeSchema memberTypeAssign = AddNode("MemberTypeAssign", "MTA");
			memberTypeAssign.BaseNode = nodeForAction;

			WeaverNodeSchema thing = AddNode("Thing", "T");
			p = AddProp(thing, "ThingId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(thing, "IsClass", typeof(bool));
			p = AddProp(thing, "Name", typeof(string));
				p.LenMax = 128;
			p = AddProp(thing, "Disamb", typeof(string));
				p.LenMax = 128;
			p = AddProp(thing, "Note", typeof(string));
				p.LenMax = 256;

			WeaverNodeSchema url = AddNode("Url", "Ur");
			p = AddProp(url, "UrlId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(url, "Name", typeof(string));
				p.LenMax = 128;
			p = AddProp(url, "AbsoluteUrl", typeof(string));
				p.LenMax = 2048;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;

			WeaverNodeSchema user = AddNode("User", "U");
			p = AddProp(user, "UserId", typeof(long));
			p = AddProp(user, "Name", typeof(string));
				p.LenMax = 16;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidUserRegex;
			p = AddProp(user, "Password", typeof(string));
				p.Len = 32; //MD5

			////

			const string has = "Has";
			const string hasHistoric = "UsesHistoric";
			const string uses = "Uses";
			const string creates = "Creates";

			const WeaverRelConn ifo = WeaverRelConn.InFromOne;
			const WeaverRelConn ifoom = WeaverRelConn.InFromOneOrMore;
			const WeaverRelConn ifzom = WeaverRelConn.InFromZeroOrMore;
			const WeaverRelConn ifzoo = WeaverRelConn.InFromZeroOrOne;
			const WeaverRelConn oto = WeaverRelConn.OutToOne;
			//const WeaverRelConn otoom = WeaverRelConn.OutToOneOrMore;
			const WeaverRelConn otzom = WeaverRelConn.OutToZeroOrMore;
			//const WeaverRelConn otzoo = WeaverRelConn.OutToZeroOrOne;

			AddRel(root, has, app, otzom, ifo);
			AddRel(root, has, artifact, otzom, ifo);
			AddRel(root, has, artifactType, otzom, ifo);
			AddRel(root, has, crowd, otzom, ifo);
			AddRel(root, has, crowdian, otzom, ifo);
			AddRel(root, has, crowdianType, otzom, ifo);
			AddRel(root, has, email, otzom, ifo);
			AddRel(root, has, label, otzom, ifo);
			AddRel(root, has, member, otzom, ifo);
			AddRel(root, has, memberType, otzom, ifo);
			AddRel(root, has, thing, otzom, ifo);
			AddRel(root, has, url, otzom, ifo);
			AddRel(root, has, user, otzom, ifo);

			AddRel(app, has, artifact, oto, ifzoo);
			AddRel(app, uses, email, oto, ifo);

			AddRel(artifact, uses, artifactType, oto, ifzom);

			AddRel(crowd, has, artifact, oto, ifzoo);

			AddRel(crowdian, uses, crowd, oto, ifoom);
			AddRel(crowdian, uses, user, oto, ifzom);
			AddRel(crowdian, has, crowdianTypeAssign, oto, ifo);
			AddRel(crowdian, hasHistoric, crowdianTypeAssign, otzom, ifo);

			AddRel(crowdianTypeAssign, uses, crowdianType, oto, ifzom);

			AddRel(label, has, artifact, oto, ifzoo);

			AddRel(member, uses, app, oto, ifoom);
			AddRel(member, uses, user, oto, ifoom);
			AddRel(member, has, memberTypeAssign, oto, ifo);
			AddRel(member, hasHistoric, memberTypeAssign, otzom, ifo);
			AddRel(member, creates, artifact, otzom, ifo);
			AddRel(member, creates, memberTypeAssign, otzom, ifo);

			AddRel(memberTypeAssign, uses, memberType, oto, ifzom);

			AddRel(thing, has, artifact, oto, ifzoo);

			AddRel(url, has, artifact, oto, ifzoo);

			AddRel(user, has, artifact, oto, ifzoo);
			AddRel(user, uses, email, oto, ifo);
			AddRel(user, creates, crowdianTypeAssign, otzom, ifo);
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public WeaverNodeSchema AddNode(string pName, string pShort) {
			var n = new WeaverNodeSchema(pName, pShort);
			Nodes.Add(n);
			return n;
		}

		/*--------------------------------------------------------------------------------------------*/
		public WeaverRelSchema AddRel(WeaverNodeSchema pFrom, string pName, WeaverNodeSchema pTo,
				WeaverRelConn pFromConn, WeaverRelConn pToConn) {
			var r = new WeaverRelSchema(pFrom, pName, pTo);
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


	/*================================================================================================*/
	public enum AppId {
		FabricSystem = 1
	}


	/*================================================================================================*/
	public enum ArtifactTypeId {
		App = 1,
		User,
		Thing,
		Url,
		Label,
		Crowd
	}


	/*================================================================================================*/
	public enum CrowdUserTypeId {
		None = 1,
		Request,
		Invite,
		Member,
		Admin
	}


	/*================================================================================================*/
	public enum MemberTypeId {
		None = 1,
		Request,
		Invite,
		Member,
		Staff,
		Admin,
		Owner,
		DataProvider
	}

}