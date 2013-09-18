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
		public List<FabricPropSchema> Props { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Schema() {
			Vertices = new List<WeaverVertexSchema>();
			Edges = new List<WeaverEdgeSchema>();
			Props = new List<FabricPropSchema>();
			FabricPropSchema p;

			////

			WeaverVertexSchema vertex = AddVertex("Vertex", "N");
			vertex.IsAbstract = true;
			vertex.IsBaseClass = true;
			vertex.IsInternal = true;

			////
			
			WeaverVertexSchema vertexForAction = AddVertex("VertexForAction", "NA");
			vertexForAction.BaseVertex = vertex;
			vertexForAction.IsAbstract = true;
			vertexForAction.IsBaseClass = true;

			////

			WeaverVertexSchema artifact = AddVertex("Artifact", "A");
			artifact.BaseVertex = vertex;
			artifact.IsBaseClass = true;

			WeaverVertexSchema app = AddVertex("App", "Ap");
			app.BaseVertex = artifact;

			WeaverVertexSchema clas = AddVertex("Class", "Cl");
			clas.BaseVertex = artifact;

			/*WeaverVertexSchema crowd = AddVertex("Crowd", "C");
			crowd.BaseVertex = artifact;
			crowd.IsInternal = true;

			WeaverVertexSchema crowdian = AddVertex("Crowdian", "Cn");
			crowdian.IsInternal = true;

			WeaverVertexSchema crowdianTypeAssign = AddVertex("CrowdianTypeAssign", "CTA");
			crowdianTypeAssign.IsInternal = true;
			crowdianTypeAssign.BaseVertex = vertexForAction;*/

			WeaverVertexSchema email = AddVertex("Email", "E");
			email.BaseVertex = vertex;
			email.IsInternal = true;
			
			WeaverVertexSchema instance = AddVertex("Instance", "In");
			instance.BaseVertex = artifact;

			/*WeaverVertexSchema label = AddVertex("Label", "L");
			label.IsInternal = true;
			label.BaseVertex = artifact;*/

			WeaverVertexSchema member = AddVertex("Member", "M");
			member.BaseVertex = vertex;

			WeaverVertexSchema memberTypeAssign = AddVertex("MemberTypeAssign", "MTA");
			memberTypeAssign.BaseVertex = vertexForAction;

			WeaverVertexSchema url = AddVertex("Url", "Ur");
			url.BaseVertex = artifact;

			WeaverVertexSchema user = AddVertex("User", "U");
			user.BaseVertex = artifact;

			////

			WeaverVertexSchema factor = AddVertex("Factor", "F");
			factor.BaseVertex = vertex;
			
			////

			WeaverVertexSchema oauthAccess = AddVertex("OauthAccess", "OA");
			oauthAccess.BaseVertex = vertex;
			oauthAccess.IsInternal = true;

			WeaverVertexSchema oauthDomain = AddVertex("OauthDomain", "OD");
			oauthDomain.BaseVertex = vertex;
			oauthDomain.IsInternal = true;
			
			WeaverVertexSchema oauthGrant = AddVertex("OauthGrant", "OG");
			oauthGrant.BaseVertex = vertex;
			oauthGrant.IsInternal = true;

			WeaverVertexSchema oauthScope = AddVertex("OauthScope", "OS");
			oauthScope.BaseVertex = vertex;
			oauthScope.IsInternal = true;

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

			const WeaverEdgeConn ifo = WeaverEdgeConn.InOne;
			const WeaverEdgeConn ifoom = WeaverEdgeConn.InOneOrMore;
			const WeaverEdgeConn ifzom = WeaverEdgeConn.InZeroOrMore;
			//const WeaverEdgeConn ifzoo = WeaverEdgeConn.InZeroOrOne;
			const WeaverEdgeConn oto = WeaverEdgeConn.OutOne;
			const WeaverEdgeConn otoom = WeaverEdgeConn.OutOneOrMore;
			const WeaverEdgeConn otzom = WeaverEdgeConn.OutZeroOrMore;
			const WeaverEdgeConn otzoo = WeaverEdgeConn.OutZeroOrOne;

			WeaverEdgeSchema appUsesEmail = AddEdge(app, uses, email, oto, ifzom);
			WeaverEdgeSchema appDefMem = AddEdge(app, defines, member, otoom, ifo);

			//AddEdge(crowd, defines, crowdian, otoom, ifo);

			//AddEdge(crowdian, has, crowdianTypeAssign, oto, ifo);
			//AddEdge(crowdian, hasHistoric, crowdianTypeAssign, otzom, ifo);

			//AddEdge(crowdianTypeAssign, uses, crowdianType, oto, ifzom);

			WeaverEdgeSchema memHasMta = AddEdge(member, has, memberTypeAssign, oto, ifo);
			WeaverEdgeSchema memHasHistMta = AddEdge(member, hasHistoric, memberTypeAssign, otzom, ifo);
			WeaverEdgeSchema memCreArt = AddEdge(member, creates, artifact, otzom, ifo);
			WeaverEdgeSchema memCreMta = AddEdge(member, creates, memberTypeAssign, otzom, ifo);
			WeaverEdgeSchema memCreFac = AddEdge(member, creates, factor, otzom, ifo);

			//AddEdge(user, creates, crowdianTypeAssign, otzom, ifo);
			//AddEdge(user, defines, crowdian, otzom, ifo);
			WeaverEdgeSchema userUsesEmail = AddEdge(user, uses, email, oto, ifoom);
			WeaverEdgeSchema userDefMem = AddEdge(user, defines, member, otoom, ifo);

			////

			WeaverEdgeSchema facUsePriArt = AddEdge(factor, usesPrimary, artifact, oto, ifzom);
			WeaverEdgeSchema facUseRelArt = AddEdge(factor, usesRelated, artifact, oto, ifzom);
			//AddEdge(factor, replaces, factor, otzoo, ifzoo);
			WeaverEdgeSchema facRefPrimArt = AddEdge(factor, refinesPrimaryWith, artifact, otzoo,ifzom); //Descriptor
			WeaverEdgeSchema facRefRelArt = AddEdge(factor, refinesRelatedWith, artifact, otzoo, ifzom); //Descriptor
			WeaverEdgeSchema facRefTypeArt = AddEdge(factor, refinesTypeWith, artifact, otzoo, ifzom); //Descriptor
			WeaverEdgeSchema facUseAxisArt = AddEdge(factor, usesAxis, artifact, otzoo, ifzom); //Vector

			////

			WeaverEdgeSchema accUsesApp = AddEdge(oauthAccess, uses, app, oto, ifzom);
			WeaverEdgeSchema accUsesUser = AddEdge(oauthAccess, uses, user, otzoo, ifzom);

			WeaverEdgeSchema domUsesApp = AddEdge(oauthDomain, uses, app, oto, ifzom);

			WeaverEdgeSchema graUsesApp = AddEdge(oauthGrant, uses, app, oto, ifzom);
			WeaverEdgeSchema graUsesUser = AddEdge(oauthGrant, uses, user, oto, ifzom);

			WeaverEdgeSchema scoUsesApp = AddEdge(oauthScope, uses, app, oto, ifzom);
			WeaverEdgeSchema scoUsesUser = AddEdge(oauthScope, uses, user, oto, ifzom);

			//// Properties

			//Vertex

			p = AddProp(vertex, "FabType", "FT", typeof(byte));
			p.IsInternal = true;

			//VertexForAction

			p = AddProp(vertexForAction, "Performed", "Pe", typeof(DateTime));
			p.IsTimestamp = true;

			p = AddProp(vertexForAction, "Note", "No", typeof(string));
			p.LenMin = 1;
			p.LenMax = 256;
			p.IsNullable = true;

			//Artifact

			p = AddProp(artifact, "ArtifactId", "AId", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;

			p = AddProp(artifact, "Created", "Cr", typeof(DateTime));
			p.IsTimestamp = true;
			p.TitanElasticIndex = true;
			FillVertexCentricIndexes(p);

			//App

			p = AddProp(app, "Name", "Na", typeof(string));
			p.LenMin = 3;
			p.LenMax = 64;
			p.IsUnique = true;
			p.IsCaseInsensitive = true;
			p.ValidRegex = ValidTitleRegex;
			p.TitanElasticIndex = true;

			p = AddProp(app, "NameKey", "NK", typeof(string));
			p.IsInternal = true;
			p.IsUnique = true;
			p.ToLowerCase = true;
			p.TitanIndex = true;
	
			p = AddProp(app, "Secret", "Se", typeof(string));
			p.Len = 32;
			p.IsInternal = true;
			p.ValidRegex = ValidCodeRegex;

			//Class

			p = AddProp(clas, "Name", "Na", typeof(string));
			p.LenMin = 1;
			p.LenMax = 128;
			p.ValidRegex = ValidTitleRegex;
			p.TitanElasticIndex = true;

			p = AddProp(clas, "NameKey", "NK", typeof(string));
			p.IsInternal = true;
			p.IsUnique = true;
			p.ToLowerCase = true;
			p.TitanIndex = true;
			
			p = AddProp(clas, "Disamb", "Di", typeof(string));
			p.LenMin = 1;
			p.LenMax = 128;
			p.IsNullable = true;
			p.ValidRegex = ValidTitleRegex;
			p.TitanElasticIndex = true;
			
			p = AddProp(clas, "Note", "No", typeof(string));
			p.LenMin = 1;
			p.LenMax = 256;
			p.IsNullable = true;

			/*//Crowd
			
			p = AddProp(crowd, "Name", typeof(string));
			p.LenMin = 3;
			p.LenMax = 64;
			
			p = AddProp(crowd, "Description", typeof(string));
			p.LenMax = 256;
			
			p = AddProp(crowd, "IsPrivate", typeof(bool));
			
			p = AddProp(crowd, "IsInviteOnly", typeof(bool));

			//Crowdian
			
			p = AddProp(crowdian, "CrowdianId", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;

			//CrowdianTypeAssign
			
			p = AddProp(crowdianTypeAssign, "CrowdianTypeAssignId", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;
			
			p = AddProp(crowdianTypeAssign, "Weight", typeof(float));			*/

			//Email

			p = AddProp(email, "EmailId", "Id", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;
			
			p = AddProp(email, "Address", "Ad", typeof(string));
			p.LenMin = 1;
			p.LenMax = 256;
			p.IsUnique = true;
			p.IsCaseInsensitive = true;
			p.ToLowerCase = true;
			p.ValidRegex = ValidEmailRegex;
			
			p = AddProp(email, "Code", "Co", typeof(string));
			p.Len = 32;
			p.ValidRegex = ValidCodeRegex;
			
			p = AddProp(email, "Created", "Cr", typeof(DateTime));
			p.IsTimestamp = true;
			
			p = AddProp(email, "Verified", "Ve", typeof(DateTime));
			p.IsNullable = true;

			//Instance
			
			p = AddProp(instance, "Name", "Na", typeof(string));
			p.LenMin = 1;
			p.LenMax = 128;
			p.IsNullable = true;
			p.ValidRegex = ValidTitleRegex;
			p.TitanElasticIndex = true;
			
			p = AddProp(instance, "Disamb", "Di", typeof(string));
			p.LenMin = 1;
			p.LenMax = 128;
			p.IsNullable = true;
			p.ValidRegex = ValidTitleRegex;
			p.TitanElasticIndex = true;
			
			p = AddProp(instance, "Note", "No", typeof(string));
			p.LenMin = 1;
			p.LenMax = 256;
			p.IsNullable = true;

			/*//Label
			
			p = AddProp(label, "Name", typeof(string));
			p.LenMin = 1;
			p.LenMax = 128;
			p.IsUnique = true;
			p.IsCaseInsensitive = true;
			p.ValidRegex = ValidTitleRegex;			*/

			//Member

			p = AddProp(member, "MemberId", "Id", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;

			//MemberTypeAssign

			p = AddProp(memberTypeAssign, "MemberTypeAssignId", "Id", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;
			
			p = AddProp(memberTypeAssign, "MemberTypeId", "Mt", typeof(byte));
			p.EnumName = "MemberTypeId";

			//Url

			p = AddProp(url, "Name", "Na", typeof(string));
			p.LenMin = 1;
			p.LenMax = 128;
			p.TitanElasticIndex = true;
			
			p = AddProp(url, "FullPath", "Pa", typeof(string));
			p.LenMin = 1;
			p.LenMax = 2048;
			p.IsUnique = true;
			p.IsCaseInsensitive = true;
			p.ToLowerCase = true;
			p.TitanIndex = true;

			//User

			p = AddProp(user, "Name", "Na", typeof(string));
			p.LenMin = 4;
			p.LenMax = 16;
			p.IsUnique = true;
			p.IsCaseInsensitive = true;
			p.ValidRegex = ValidUserRegex;
			
			p = AddProp(user, "NameKey", "NK", typeof(string));
			p.IsInternal = true;
			p.IsUnique = true;
			p.ToLowerCase = true;
			p.TitanIndex = true;
			
			p = AddProp(user, "Password", "Pa", typeof(string));
			p.LenMin = 8;
			p.LenMax = 32;
			p.IsInternal = true;
			p.IsPassword = true;

			//Factor

			p = AddProp(factor, "FactorId", "Id", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;
			
			p = AddProp(factor, "FactorAssertionId", "Fa", typeof(byte));
			p.EnumName = "FactorAssertionId";
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "IsDefining", "Df", typeof(bool));
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Created", "Cr", typeof(DateTime));
			p.IsTimestamp = true;
			FillVertexCentricIndexes(p);
			p.TitanElasticIndex = true;
			
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
			FillVertexCentricIndexes(p);

			p = AddProp(factor, "Director_TypeId", "DiT", typeof(byte));
			p.EnumName = "DirectorTypeId";
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Director_PrimaryActionId", "DiP", typeof(byte));
			p.EnumName = "DirectorActionId";
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Director_RelatedActionId", "DiR", typeof(byte));
			p.EnumName = "DirectorActionId";
			FillVertexCentricIndexes(p);

			p = AddProp(factor, "Eventor_TypeId", "EvT", typeof(byte));
			p.EnumName = "EventorTypeId";
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Eventor_DateTime", "EvD", typeof(DateTime));
			p.IsInternal = true;
			FillVertexCentricIndexes(p);

			p = AddProp(factor, "Identor_TypeId", "IdT", typeof(byte));
			p.EnumName = "IdentorTypeId";
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Identor_Value", "IdV", typeof(string));
			p.LenMin = 1;
			p.LenMax = 256;
			p.TitanIndex = true;
			p.TitanElasticIndex = true;
			FillVertexCentricIndexes(p);

			p = AddProp(factor, "Locator_TypeId", "LoT", typeof(byte));
			p.EnumName = "LocatorTypeId";
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Locator_ValueX", "LoX", typeof(double));
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Locator_ValueY", "LoY", typeof(double));
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Locator_ValueZ", "LoZ", typeof(double));
			FillVertexCentricIndexes(p);

			p = AddProp(factor, "Vector_TypeId", "VeT", typeof(byte));
			p.EnumName = "VectorTypeId";
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Vector_UnitId", "VeU", typeof(byte));
			p.EnumName = "VectorUnitId";
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Vector_UnitPrefixId", "VeP", typeof(byte));
			p.EnumName = "VectorUnitPrefixId";
			FillVertexCentricIndexes(p);
			
			p = AddProp(factor, "Vector_Value", "VeV", typeof(long));
			FillVertexCentricIndexes(p);

			//OauthAccess

			p = AddProp(oauthAccess, "OauthAccessId", "Id", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;
			
			p = AddProp(oauthAccess, "Token", "To", typeof(string));
			p.Len = 32;
			p.IsNullable = true;
			p.IsUnique = true;
			p.ValidRegex = ValidCodeRegex;
			p.TitanIndex = true;
			
			p = AddProp(oauthAccess, "Refresh", "Re", typeof(string));
			p.Len = 32;
			p.IsNullable = true;
			p.ValidRegex = ValidCodeRegex;
			p.TitanIndex = true;
			
			AddProp(oauthAccess, "Expires", "Ex", typeof(DateTime));
			
			AddProp(oauthAccess, "IsClientOnly", "CO", typeof(bool));

			//OauthDomain

			p = AddProp(oauthDomain, "OauthDomainId", "Id", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;
			
			p = AddProp(oauthDomain, "Domain", "Do", typeof(string));
			p.LenMin = 1;
			p.LenMax = 256;
			p.IsCaseInsensitive = true;
			p.ToLowerCase = true;
			p.ValidRegex = ValidOauthDomainRegexp;

			//OauthGrant

			p = AddProp(oauthGrant, "OauthGrantId", "Id", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;
			
			p = AddProp(oauthGrant, "RedirectUri", "Re", typeof(string));
			p.LenMin = 1;
			p.LenMax = 450;
			p.IsCaseInsensitive = true;
			p.ToLowerCase = true;
			
			p = AddProp(oauthGrant, "Code", "Co", typeof(string));
			p.Len = 32;
			p.IsUnique = true;
			p.ValidRegex = ValidCodeRegex;
			p.TitanIndex = true;
			
			AddProp(oauthGrant, "Expires", "Ex", typeof(DateTime));

			//OauthScope

			p = AddProp(oauthScope, "OauthScopeId", "Id", typeof(long));
			p.IsPrimaryKey = true;
			p.TitanIndex = true;
			
			AddProp(oauthScope, "Allow", "Al", typeof(bool));
			
			p = AddProp(oauthScope, "Created", "Cr", typeof(DateTime));
			p.IsTimestamp = true;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private WeaverVertexSchema AddVertex(string pName, string pDbName) {
			var n = new WeaverVertexSchema(pName, pDbName);
			Vertices.Add(n);
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
			return r;
		}

		/*--------------------------------------------------------------------------------------------*/
		private FabricPropSchema AddProp(WeaverVertexSchema pVertex, string pName, string pDbName,
																						Type pType) {
			var p = new FabricPropSchema(pName, pVertex.DbName+'_'+pDbName, pType);
			p.VertexSchema = pVertex;
			pVertex.Props.Add(p);
			Props.Add(p);
			return p;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void FillVertexCentricIndexes(FabricPropSchema pProp) {
			foreach ( WeaverEdgeSchema e in Edges ) {
				var props = new List<WeaverPropSchema>();
				props.AddRange(e.OutVertex.Props);
				props.AddRange(e.InVertex.Props);

				foreach ( WeaverPropSchema p in props ) {
					if ( p == pProp ) {
						pProp.AddTitanVertexCentricIndex(e);
					}
				}
			}
		}

	}

}