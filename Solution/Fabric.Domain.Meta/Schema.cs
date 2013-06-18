using System;
using System.Collections.Generic;
using Weaver.Core.Elements;
using Weaver.Core.Schema;

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

		public List<WeaverVertexSchema> Vertices { get; private set; }
		public List<WeaverEdgeSchema> Edges { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Schema() {
			Vertices = new List<WeaverVertexSchema>();
			Edges = new List<WeaverEdgeSchema>();
			FabricPropSchema p;

			////

			WeaverVertexSchema vertex = AddVertex("Vertex", "N");
			vertex.IsAbstract = true;
			vertex.IsBaseClass = true;
			vertex.IsInternal = true;
			p = AddProp(vertex, "FabType", "FT", typeof(byte));
				p.IsInternal = true;

			////
			
			WeaverVertexSchema vertexForAction = AddVertex("VertexForAction", "NA");
			vertexForAction.BaseVertex = vertex;
			vertexForAction.IsAbstract = true;
			vertexForAction.IsBaseClass = true;
			p = AddProp(vertexForAction, "Performed", "Pe", typeof(DateTime));
				p.IsTimestamp = true;
				p.IsVertexCentricIndex = true;
			p = AddProp(vertexForAction, "Note", "No", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsNullable = true;

			////

			WeaverVertexSchema artifact = AddVertex("Artifact", "A");
			artifact.BaseVertex = vertex;
			artifact.IsBaseClass = true;
			p = AddProp(artifact, "ArtifactId", "AId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(artifact, "Created", "Cr", typeof(DateTime));
				p.IsTimestamp = true;
				p.IndexWithElasticSearch = true;
				p.IsVertexCentricIndex = true;

			WeaverVertexSchema app = AddVertex("App", "Ap");
			app.BaseVertex = artifact;
			p = AddProp(app, "Name", "Na", typeof(string));
				p.LenMin = 3;
				p.LenMax = 64;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidTitleRegex;
				p.IndexWithElasticSearch = true;
			p = AddProp(app, "Secret", "Se", typeof(string));
				p.Len = 32;
				p.IsInternal = true;
				p.ValidRegex = ValidCodeRegex;

			WeaverVertexSchema clas = AddVertex("Class", "Cl");
			clas.BaseVertex = artifact;
			p = AddProp(clas, "Name", "Na", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.ValidRegex = ValidTitleRegex;
				p.IndexWithElasticSearch = true;
			p = AddProp(clas, "Disamb", "Di", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
				p.IndexWithElasticSearch = true;
			p = AddProp(clas, "Note", "No", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsNullable = true;

			/*WeaverVertexSchema crowd = AddVertex("Crowd", "C");
			crowd.BaseVertex = artifact;
			crowd.IsInternal = true;
			p = AddProp(crowd, "Name", typeof(string));
				p.LenMin = 3;
				p.LenMax = 64;
			p = AddProp(crowd, "Description", typeof(string));
				p.LenMax = 256;
			p = AddProp(crowd, "IsPrivate", typeof(bool));
			p = AddProp(crowd, "IsInviteOnly", typeof(bool));

			WeaverVertexSchema crowdian = AddVertex("Crowdian", "Cn");
			crowdian.IsInternal = true;
			p = AddProp(crowdian, "CrowdianId", typeof(long));
				p.IsPrimaryKey = true;

			WeaverVertexSchema crowdianTypeAssign = AddVertex("CrowdianTypeAssign", "CTA");
			crowdianTypeAssign.IsInternal = true;
			crowdianTypeAssign.BaseVertex = vertexForAction;
			p = AddProp(crowdianTypeAssign, "CrowdianTypeAssignId", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(crowdianTypeAssign, "Weight", typeof(float));*/

			WeaverVertexSchema email = AddVertex("Email", "E");
			email.BaseVertex = vertex;
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
			
			WeaverVertexSchema instance = AddVertex("Instance", "In");
			instance.BaseVertex = artifact;
			p = AddProp(instance, "Name", "Na", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
				p.IndexWithElasticSearch = true;
			p = AddProp(instance, "Disamb", "Di", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsNullable = true;
				p.ValidRegex = ValidTitleRegex;
				p.IndexWithElasticSearch = true;
			p = AddProp(instance, "Note", "No", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsNullable = true;

			/*WeaverVertexSchema label = AddVertex("Label", "L");
			label.IsInternal = true;
			label.BaseVertex = artifact;
			p = AddProp(label, "Name", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidTitleRegex;*/

			WeaverVertexSchema member = AddVertex("Member", "M");
			member.BaseVertex = vertex;
			p = AddProp(member, "MemberId", "Id", typeof(long));
				p.IsPrimaryKey = true;

			WeaverVertexSchema memberTypeAssign = AddVertex("MemberTypeAssign", "MTA");
			memberTypeAssign.BaseVertex = vertexForAction;
			p = AddProp(memberTypeAssign, "MemberTypeAssignId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(memberTypeAssign, "MemberTypeId", "Mt", typeof(byte));
				p.EnumName = "MemberTypeId";
				p.IsVertexCentricIndex = true;

			WeaverVertexSchema url = AddVertex("Url", "Ur");
			url.BaseVertex = artifact;
			p = AddProp(url, "Name", "Na", typeof(string));
				p.LenMin = 1;
				p.LenMax = 128;
				p.IndexWithElasticSearch = true;
			p = AddProp(url, "AbsoluteUrl", "Ab", typeof(string));
				p.LenMin = 1;
				p.LenMax = 2048;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.IndexWithElasticSearch = true;

			WeaverVertexSchema user = AddVertex("User", "U");
			user.BaseVertex = artifact;
			p = AddProp(user, "Name", "Na", typeof(string));
				p.LenMin = 4;
				p.LenMax = 16;
				p.IsUnique = true;
				p.IsCaseInsensitive = true;
				p.ValidRegex = ValidUserRegex;
				p.IndexWithElasticSearch = true;
			p = AddProp(user, "Password", "Pa", typeof(string));
				p.LenMin = 8;
				p.LenMax = 32;
				p.IsInternal = true;
				p.IsPassword = true;

			////

			WeaverVertexSchema factor = AddVertex("Factor", "F");
			factor.BaseVertex = vertex;
			p = AddProp(factor, "FactorId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(factor, "FactorAssertionId", "Fa", typeof(byte));
				p.EnumName = "FactorAssertionId";
				p.IsVertexCentricIndex = true;
			//p = AddProp(factor, "IsPublic", typeof(bool));
			p = AddProp(factor, "IsDefining", "Df", typeof(bool));
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Created", "Cr", typeof(DateTime));
				p.IsTimestamp = true;
				p.IsVertexCentricIndex = true;
				p.IndexWithElasticSearch = true;
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
				p.IsVertexCentricIndex = true;

			p = AddProp(factor, "Director_TypeId", "DiT", typeof(byte));
				p.EnumName = "DirectorTypeId";
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Director_PrimaryActionId", "DiP", typeof(byte));
				p.EnumName = "DirectorActionId";
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Director_RelatedActionId", "DiR", typeof(byte));
				p.EnumName = "DirectorActionId";
				p.IsVertexCentricIndex = true;

			p = AddProp(factor, "Eventor_TypeId", "EvT", typeof(byte));
				p.EnumName = "EventorTypeId";
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Eventor_PrecisionId", "EvP", typeof(byte));
				p.EnumName = "EventorPrecisionId";
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Eventor_DateTime", "EvD", typeof(DateTime));
				p.Min = 1;
				p.IsVertexCentricIndex = true;

			p = AddProp(factor, "Identor_TypeId", "IdT", typeof(byte));
				p.EnumName = "IdentorTypeId";
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Identor_Value", "IdV", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IndexWithTitan = true;
				p.IndexWithElasticSearch = true;
				p.IsVertexCentricIndex = true;

			p = AddProp(factor, "Locator_TypeId", "LoT", typeof(byte));
				p.EnumName = "LocatorTypeId";
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Locator_ValueX", "LoX", typeof(double));
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Locator_ValueY", "LoY", typeof(double));
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Locator_ValueZ", "LoZ", typeof(double));
				p.IsVertexCentricIndex = true;

			p = AddProp(factor, "Vector_TypeId", "VeT", typeof(byte));
				p.EnumName = "VectorTypeId";
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Vector_UnitId", "VeU", typeof(byte));
				p.EnumName = "VectorUnitId";
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Vector_UnitPrefixId", "VeP", typeof(byte));
				p.EnumName = "VectorUnitPrefixId";
				p.IsVertexCentricIndex = true;
			p = AddProp(factor, "Vector_Value", "VeV", typeof(long));
				p.IsVertexCentricIndex = true;
			
			////

			WeaverVertexSchema oauthAccess = AddVertex("OauthAccess", "OA");
			oauthAccess.BaseVertex = vertex;
			oauthAccess.IsInternal = true;
			p = AddProp(oauthAccess, "OauthAccessId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthAccess, "Token", "To", typeof(string));
				p.Len = 32;
				p.IsNullable = true;
				p.IsUnique = true;
				p.ValidRegex = ValidCodeRegex;
				p.IndexWithTitan = true;
			p = AddProp(oauthAccess, "Refresh", "Re", typeof(string));
				p.Len = 32;
				p.IsNullable = true;
				p.ValidRegex = ValidCodeRegex;
				p.IndexWithTitan = true;
			p = AddProp(oauthAccess, "Expires", "Ex", typeof(DateTime));
			p = AddProp(oauthAccess, "IsClientOnly", "CO", typeof(bool));

			WeaverVertexSchema oauthDomain = AddVertex("OauthDomain", "OD");
			oauthDomain.BaseVertex = vertex;
			oauthDomain.IsInternal = true;
			p = AddProp(oauthDomain, "OauthDomainId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthDomain, "Domain", "Do", typeof(string));
				p.LenMin = 1;
				p.LenMax = 256;
				p.IsCaseInsensitive = true; //TODO: ensure that domains are stored with ToLower()
				p.ValidRegex = ValidOauthDomainRegexp;
			
			WeaverVertexSchema oauthGrant = AddVertex("OauthGrant", "OG");
			oauthGrant.BaseVertex = vertex;
			oauthGrant.IsInternal = true;
			p = AddProp(oauthGrant, "OauthGrantId", "Id", typeof(long));
				p.IsPrimaryKey = true;
			p = AddProp(oauthGrant, "RedirectUri", "Re", typeof(string));
				p.LenMin = 1;
				p.LenMax = 450;
				p.IsCaseInsensitive = true; //TODO: ensure that redirect URL is stored with ToLower()
			p = AddProp(oauthGrant, "Code", "Co", typeof(string));
				p.Len = 32;
				p.IsUnique = true;
				p.ValidRegex = ValidCodeRegex;
				p.IndexWithTitan = true;
			p = AddProp(oauthGrant, "Expires", "Ex", typeof(DateTime));

			WeaverVertexSchema oauthScope = AddVertex("OauthScope", "OS");
			oauthScope.BaseVertex = vertex;
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

			const WeaverEdgeConn ifo = WeaverEdgeConn.InFromOne;
			const WeaverEdgeConn ifoom = WeaverEdgeConn.InFromOneOrMore;
			const WeaverEdgeConn ifzom = WeaverEdgeConn.InFromZeroOrMore;
			//const WeaverEdgeConn ifzoo = WeaverEdgeConn.InFromZeroOrOne;
			const WeaverEdgeConn oto = WeaverEdgeConn.OutToOne;
			const WeaverEdgeConn otoom = WeaverEdgeConn.OutToOneOrMore;
			const WeaverEdgeConn otzom = WeaverEdgeConn.OutToZeroOrMore;
			const WeaverEdgeConn otzoo = WeaverEdgeConn.OutToZeroOrOne;

			AddEdge(app, uses, email, oto, ifzom);
			AddEdge(app, defines, member, otoom, ifo);

			//AddEdge(crowd, defines, crowdian, otoom, ifo);

			//AddEdge(crowdian, has, crowdianTypeAssign, oto, ifo);
			//AddEdge(crowdian, hasHistoric, crowdianTypeAssign, otzom, ifo);

			//AddEdge(crowdianTypeAssign, uses, crowdianType, oto, ifzom);

			AddEdge(member, has, memberTypeAssign, oto, ifo);
			AddEdge(member, hasHistoric, memberTypeAssign, otzom, ifo);
			AddEdge(member, creates, artifact, otzom, ifo);
			AddEdge(member, creates, memberTypeAssign, otzom, ifo);
			AddEdge(member, creates, factor, otzom, ifo);

			//AddEdge(user, creates, crowdianTypeAssign, otzom, ifo);
			//AddEdge(user, defines, crowdian, otzom, ifo);
			AddEdge(user, uses, email, oto, ifoom);
			AddEdge(user, defines, member, otoom, ifo);

			////

			AddEdge(factor, usesPrimary, artifact, oto, ifzom);
			AddEdge(factor, usesRelated, artifact, oto, ifzom);
			//AddEdge(factor, replaces, factor, otzoo, ifzoo);
			AddEdge(factor, refinesPrimaryWith, artifact, otzoo, ifzom); //Descriptor
			AddEdge(factor, refinesRelatedWith, artifact, otzoo, ifzom); //Descriptor
			AddEdge(factor, refinesTypeWith, artifact, otzoo, ifzom); //Descriptor
			AddEdge(factor, usesAxis, artifact, otzoo, ifzom); //Vector

			////

			AddEdge(oauthAccess, uses, app, oto, ifzom);
			AddEdge(oauthAccess, uses, user, otzoo, ifzom);

			AddEdge(oauthDomain, uses, app, oto, ifzom);

			AddEdge(oauthGrant, uses, app, oto, ifzom);
			AddEdge(oauthGrant, uses, user, oto, ifzom);

			AddEdge(oauthScope, uses, app, oto, ifzom);
			AddEdge(oauthScope, uses, user, oto, ifzom);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private WeaverVertexSchema AddVertex(string pName, string pDbName) {
			var n = new WeaverVertexSchema(pName, pDbName);
			Vertices.Add(n);
			//Console.WriteLine("NODE: "+n.DbName+" ("+n.Name+")");
			return n;
		}

		/*--------------------------------------------------------------------------------------------*/
		private WeaverEdgeSchema AddEdge(WeaverVertexSchema pFrom, KeyValuePair<string, string> pEdgeType,
								WeaverVertexSchema pTo, WeaverEdgeConn pFromConn, WeaverEdgeConn pToConn) {
			string name = pFrom.Name+pEdgeType.Key+pTo.Name;
			string db = pFrom.DbName+"-"+pEdgeType.Value+"-"+pTo.DbName;

			var r = new WeaverEdgeSchema(pFrom, name, db, pEdgeType.Key, pTo);
			r.OutVertexConn = pFromConn;
			r.InVertexConn = pToConn;
			Edges.Add(r);
			//Console.WriteLine("REL: "+db+" ("+r.Name+")");
			return r;
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabricPropSchema AddProp(WeaverVertexSchema pVertex, string pName, string pDbName,
																						Type pType) {
			var p = new FabricPropSchema(pName, pVertex.DbName+'_'+pDbName, pType);
			pVertex.Props.Add(p);
			//Console.WriteLine(" - "+p.DbName+" ("+pVertex.Name+"."+p.Name+")");
			return p;
		}

	}

}