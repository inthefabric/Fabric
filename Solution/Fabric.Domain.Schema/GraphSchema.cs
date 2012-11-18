using System;
using System.Collections.Generic;
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

			////

			var nodeForType = new WeaverNodeSchema("NodeForType", null) { IsAbstract=true };
			nodeForType.Props.Add(new WeaverPropSchema("Name", typeof(string)) { LenMin=1, LenMax=32, IsUnique=true, ValidRegex=ValidTitleRegex });
			nodeForType.Props.Add(new WeaverPropSchema("Description", typeof(string)) { LenMax=256, ValidRegex=ValidTitleRegex });
			Nodes.Add(nodeForType);

			var nodeForAction = new WeaverNodeSchema("NodeForAction", null) { IsAbstract=true };
			nodeForAction.Props.Add(new WeaverPropSchema("Performed", typeof(DateTime)) { IsTimestamp=true });
			nodeForAction.Props.Add(new WeaverPropSchema("Note", typeof(string)) { LenMax=256 });
			Nodes.Add(nodeForAction);

			////

			var root = new WeaverNodeSchema("Root", "R");
			root.IsRoot = true;
			Nodes.Add(root);

			////

			var app = new WeaverNodeSchema("App", "Ap");
			app.Props.Add(new WeaverPropSchema("AppId", typeof(long)));
			app.Props.Add(new WeaverPropSchema("Name", typeof(string)) {
				LenMin=3,
				LenMax=64,
				IsUnique=true,
				IsCaseInsensitive=true,
				ValidRegex=ValidTitleRegex
			});
			app.Props.Add(new WeaverPropSchema("Secret", typeof(string)) { Len=32 });
			Nodes.Add(app);

			var artifact = new WeaverNodeSchema("Artifact", "A");
			artifact.Props.Add(new WeaverPropSchema("ArtifactId", typeof(long)));
			artifact.Props.Add(new WeaverPropSchema("IsPrivate", typeof(bool)));
			artifact.Props.Add(new WeaverPropSchema("Created", typeof(DateTime)) { IsTimestamp=true });
			Nodes.Add(artifact);

			var artifactType = new WeaverNodeSchema("ArtifactType", "AT") { BaseNode=nodeForType };
			artifactType.Props.Add(new WeaverPropSchema("ArtifactTypeId", typeof(byte)));
			Nodes.Add(artifactType);

			var crowd = new WeaverNodeSchema("Crowd", "C");
			crowd.Props.Add(new WeaverPropSchema("CrowdId", typeof(long)));
			crowd.Props.Add(new WeaverPropSchema("Name", typeof(string)) { LenMin=3, LenMax=64 });
			crowd.Props.Add(new WeaverPropSchema("Description", typeof(string)) { LenMax=256 });
			crowd.Props.Add(new WeaverPropSchema("IsPrivate", typeof(bool)));
			crowd.Props.Add(new WeaverPropSchema("IsInviteOnly", typeof(bool)));
			Nodes.Add(crowd);

			var crowdian = new WeaverNodeSchema("Crowdian", "Cn");
			crowdian.Props.Add(new WeaverPropSchema("CrowdianId", typeof(long)));
			Nodes.Add(crowdian);

			var crowdianType = new WeaverNodeSchema("CrowdianType", "CT") { BaseNode=nodeForType };
			crowdianType.Props.Add(new WeaverPropSchema("CrowdianTypeId", typeof(byte)));
			Nodes.Add(crowdianType);

			var crowdianTypeAssign = new WeaverNodeSchema("CrowdianTypeAssign", "CTA") { BaseNode=nodeForAction };
			crowdianTypeAssign.Props.Add(new WeaverPropSchema("Weight", typeof(float)));
			Nodes.Add(crowdianTypeAssign);

			var email = new WeaverNodeSchema("Email", "E");
			email.Props.Add(new WeaverPropSchema("EmailId", typeof(long)));
			email.Props.Add(new WeaverPropSchema("Address", typeof(string)) { LenMax=256, IsUnique=true, IsCaseInsensitive=true, ValidRegex=ValidEmailRegex });
			email.Props.Add(new WeaverPropSchema("Code", typeof(string)) { Len=32 });
			email.Props.Add(new WeaverPropSchema("Created", typeof(DateTime)) { IsTimestamp=true });
			email.Props.Add(new WeaverPropSchema("Verified", typeof(DateTime)) { IsNullable=true });
			Nodes.Add(email);

			var label = new WeaverNodeSchema("Label", "L");
			label.Props.Add(new WeaverPropSchema("LabelId", typeof(long)));
			label.Props.Add(new WeaverPropSchema("Name", typeof(string)) {
				LenMin=1,
				LenMax=128,
				IsUnique=true,
				IsCaseInsensitive=true,
				ValidRegex=ValidTitleRegex
			});
			Nodes.Add(label);

			var member = new WeaverNodeSchema("Member", "M");
			member.Props.Add(new WeaverPropSchema("MemberId", typeof(long)));
			Nodes.Add(member);

			var memberType = new WeaverNodeSchema("MemberType", "MT") { BaseNode=nodeForType };
			memberType.Props.Add(new WeaverPropSchema("MemberTypeId", typeof(byte)));
			Nodes.Add(memberType);

			var memberTypeAssign = new WeaverNodeSchema("MemberTypeAssign", "MTA") { BaseNode=nodeForAction };
			Nodes.Add(memberTypeAssign);

			var thing = new WeaverNodeSchema("Thing", "T");
			thing.Props.Add(new WeaverPropSchema("ThingId", typeof(long)));
			thing.Props.Add(new WeaverPropSchema("IsClass", typeof(bool)));
			thing.Props.Add(new WeaverPropSchema("Name", typeof(string)) { LenMax=128 });
			thing.Props.Add(new WeaverPropSchema("Disamb", typeof(string)) { LenMax=128 });
			thing.Props.Add(new WeaverPropSchema("Note", typeof(string)) { LenMax=256 });
			Nodes.Add(thing);

			var url = new WeaverNodeSchema("Url", "Ur");
			url.Props.Add(new WeaverPropSchema("UrlId", typeof(long)));
			url.Props.Add(new WeaverPropSchema("Name", typeof(string)) { LenMax=128 });
			url.Props.Add(new WeaverPropSchema("AbsoluteUrl", typeof(string)) { LenMax=2048, IsUnique=true, IsCaseInsensitive=true });
			Nodes.Add(url);

			var user = new WeaverNodeSchema("User", "U");
			user.Props.Add(new WeaverPropSchema("UserId", typeof(long)));
			user.Props.Add(new WeaverPropSchema("Name", typeof(string)) { LenMax=16, IsUnique=true, IsCaseInsensitive=true, ValidRegex=ValidUserRegex });
			//store password hashes in Redis
			Nodes.Add(user);

			////

			const string has = "Has";
			const string hasHistoric = "UsesHistoric";
			const string uses = "Uses";
			const string creates = "Creates";

			Rels.Add(new WeaverRelSchema(root, has, app) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, artifact) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, artifactType) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, crowd) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, crowdian) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, crowdianType) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, email) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, label) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, member) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, memberType) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, thing) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, url) { Many=true });
			Rels.Add(new WeaverRelSchema(root, has, user) { Many=true });

			Rels.Add(new WeaverRelSchema(app, has, artifact));
			Rels.Add(new WeaverRelSchema(app, uses, email) { Many=true });

			Rels.Add(new WeaverRelSchema(artifact, uses, artifactType) { RevMany=true });

			Rels.Add(new WeaverRelSchema(crowd, has, artifact));

			Rels.Add(new WeaverRelSchema(crowdian, uses, crowd) { RevMany=true });
			Rels.Add(new WeaverRelSchema(crowdian, uses, user) { RevMany=true });
			Rels.Add(new WeaverRelSchema(crowdian, has, crowdianTypeAssign));
			Rels.Add(new WeaverRelSchema(crowdian, hasHistoric, crowdianTypeAssign) { Many=true });

			Rels.Add(new WeaverRelSchema(crowdianTypeAssign, uses, crowdianType) { RevMany=true });

			Rels.Add(new WeaverRelSchema(label, has, artifact));

			Rels.Add(new WeaverRelSchema(member, uses, app) { RevMany=true });
			Rels.Add(new WeaverRelSchema(member, uses, user) { RevMany=true });
			Rels.Add(new WeaverRelSchema(member, has, memberTypeAssign));
			Rels.Add(new WeaverRelSchema(member, hasHistoric, memberTypeAssign) { Many=true });
			Rels.Add(new WeaverRelSchema(member, creates, artifact) { Many=true });
			Rels.Add(new WeaverRelSchema(member, creates, memberTypeAssign) { Many=true });

			Rels.Add(new WeaverRelSchema(memberTypeAssign, uses, memberType) { RevMany=true });

			Rels.Add(new WeaverRelSchema(thing, has, artifact));

			Rels.Add(new WeaverRelSchema(url, has, artifact));

			Rels.Add(new WeaverRelSchema(user, has, artifact));
			Rels.Add(new WeaverRelSchema(user, uses, email) { Many=true });
			Rels.Add(new WeaverRelSchema(user, creates, crowdianTypeAssign) { Many=true });
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