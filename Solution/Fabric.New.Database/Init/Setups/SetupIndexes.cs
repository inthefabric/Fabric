
// GENERATED CODE
// Changes made to this source file will be overwritten

using Weaver.Core.Query;

namespace Fabric.New.Database.Init.Setups {


	/*================================================================================================*/
	public partial class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Create() {
			CreateVerts();
			CreateEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateVerts() {

			//App
			AddProp(Elem.Vertex, "p.na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "p.nk", "String", Index.Standard, true);
			AddProp(Elem.Vertex, "p.se", "String", Index.None, false);
			AddProp(Elem.Vertex, "p.od", "String", Index.None, false);

			//Artifact

			//Class
			AddProp(Elem.Vertex, "c.na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "c.nk", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "c.di", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "c.no", "String", Index.None, false);

			//Email
			AddProp(Elem.Vertex, "e.ad", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "e.co", "String", Index.None, false);
			AddProp(Elem.Vertex, "e.ve", "Boolean", Index.None, false);

			//Factor
			AddProp(Elem.Vertex, "f.at", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.de", "Boolean", Index.None, false);
			AddProp(Elem.Vertex, "f.no", "String", Index.None, false);
			AddProp(Elem.Vertex, "f.det", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.dit", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.dip", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.dir", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.evt", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.evd", "Long", Index.None, false);
			AddProp(Elem.Vertex, "f.idt", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.idv", "String", Index.Both, false);
			AddProp(Elem.Vertex, "f.lot", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.lox", "Double", Index.None, false);
			AddProp(Elem.Vertex, "f.loy", "Double", Index.None, false);
			AddProp(Elem.Vertex, "f.loz", "Double", Index.None, false);
			AddProp(Elem.Vertex, "f.vet", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.veu", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.vep", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f.vev", "Long", Index.None, false);

			//Instance
			AddProp(Elem.Vertex, "i.na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "i.di", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "i.no", "String", Index.None, false);

			//Member
			AddProp(Elem.Vertex, "m.at", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "m.osa", "Boolean", Index.None, false);
			AddProp(Elem.Vertex, "m.ogr", "String", Index.None, false);
			AddProp(Elem.Vertex, "m.ogc", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "m.oge", "Long", Index.None, false);

			//OauthAccess
			AddProp(Elem.Vertex, "oa.to", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "oa.re", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "oa.ex", "Long", Index.None, false);
			AddProp(Elem.Vertex, "oa.dp", "Boolean", Index.None, false);

			//Url
			AddProp(Elem.Vertex, "r.na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "r.fp", "String", Index.Standard, true);

			//User
			AddProp(Elem.Vertex, "u.na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "u.nk", "String", Index.Standard, true);
			AddProp(Elem.Vertex, "u.pa", "String", Index.None, false);

			//Vertex
			AddProp(Elem.Vertex, "v.id", "Long", Index.Standard, false);
			AddProp(Elem.Vertex, "v.ts", "Long", Index.Elastic, false);
			AddProp(Elem.Vertex, "v.t", "Byte", Index.None, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateEdges() {

			//AppDefinesMember
			AddProp(Elem.Edge, "pdm.ts", "long", Index.None, false);
			AddProp(Elem.Edge, "pdm.mt", "byte", Index.None, false);
			AddProp(Elem.Edge, "pdm.ui", "long", Index.None, false);
			AddEdge("pdm", Cardin.OneToMany, Sort.Desc,
				new[] {"pdm.ts", "pdm.mt", "pdm.ui"},
				new[] {"p.na","p.nk","p.se","p.od"}
			);

			//ArtifactCreatedByMember
			AddEdge("acbm", Cardin.OneToOne, Sort.None,
				new string[0],
				new string[0]
			);

			//ArtifactUsedAsPrimaryByFactor
			AddProp(Elem.Edge, "apbf.ts", "long", Index.None, false);
			AddProp(Elem.Edge, "apbf.dt", "byte", Index.None, false);
			AddProp(Elem.Edge, "apbf.ra", "long", Index.None, false);
			AddEdge("apbf", Cardin.OneToMany, Sort.Desc,
				new[] {"apbf.ts", "apbf.dt", "apbf.ra"},
				new string[0]
			);

			//ArtifactUsedAsRelatedByFactor
			AddProp(Elem.Edge, "arbf.ts", "long", Index.None, false);
			AddProp(Elem.Edge, "arbf.dt", "byte", Index.None, false);
			AddProp(Elem.Edge, "arbf.pa", "long", Index.None, false);
			AddEdge("arbf", Cardin.OneToMany, Sort.Desc,
				new[] {"arbf.ts", "arbf.dt", "arbf.pa"},
				new string[0]
			);

			//ArtifactUsesEmail
			AddEdge("aue", Cardin.OneToMany, Sort.None,
				new string[0],
				new string[0]
			);

			//EmailUsedByArtifact
			AddEdge("eba", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"e.ad","e.co","e.ve"}
			);

			//FactorCreatedByMember
			AddEdge("fcbm", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f.at","f.de","f.no","f.det","f.dit","f.dip","f.dir","f.evt","f.evd","f.idt","f.idv","f.lot","f.lox","f.loy","f.loz","f.vet","f.veu","f.vep","f.vev"}
			);

			//FactorDescriptorRefinesPrimaryWithArtifact
			AddEdge("frpa", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f.at","f.de","f.no","f.det","f.dit","f.dip","f.dir","f.evt","f.evd","f.idt","f.idv","f.lot","f.lox","f.loy","f.loz","f.vet","f.veu","f.vep","f.vev"}
			);

			//FactorDescriptorRefinesRelatedWithArtifact
			AddEdge("frra", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f.at","f.de","f.no","f.det","f.dit","f.dip","f.dir","f.evt","f.evd","f.idt","f.idv","f.lot","f.lox","f.loy","f.loz","f.vet","f.veu","f.vep","f.vev"}
			);

			//FactorDescriptorRefinesTypeWithArtifact
			AddEdge("frta", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f.at","f.de","f.no","f.det","f.dit","f.dip","f.dir","f.evt","f.evd","f.idt","f.idv","f.lot","f.lox","f.loy","f.loz","f.vet","f.veu","f.vep","f.vev"}
			);

			//FactorUsesPrimaryArtifact
			AddEdge("fpa", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f.at","f.de","f.no","f.det","f.dit","f.dip","f.dir","f.evt","f.evd","f.idt","f.idv","f.lot","f.lox","f.loy","f.loz","f.vet","f.veu","f.vep","f.vev"}
			);

			//FactorUsesRelatedArtifact
			AddEdge("fra", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f.at","f.de","f.no","f.det","f.dit","f.dip","f.dir","f.evt","f.evd","f.idt","f.idv","f.lot","f.lox","f.loy","f.loz","f.vet","f.veu","f.vep","f.vev"}
			);

			//FactorVectorUsesAxisArtifact
			AddEdge("faa", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f.at","f.de","f.no","f.det","f.dit","f.dip","f.dir","f.evt","f.evd","f.idt","f.idv","f.lot","f.lox","f.loy","f.loz","f.vet","f.veu","f.vep","f.vev"}
			);

			//MemberAuthenticatedByOauthAccess
			AddProp(Elem.Edge, "maboa.ts", "long", Index.None, false);
			AddEdge("maboa", Cardin.OneToMany, Sort.Desc,
				new[] {"maboa.ts"},
				new[] {"m.at","m.osa","m.ogr","m.ogc","m.oge"}
			);

			//MemberCreatesArtifact
			AddProp(Elem.Edge, "mca.ts", "long", Index.None, false);
			AddProp(Elem.Edge, "mca.vt", "byte", Index.None, false);
			AddEdge("mca", Cardin.OneToMany, Sort.Desc,
				new[] {"mca.ts", "mca.vt"},
				new[] {"m.at","m.osa","m.ogr","m.ogc","m.oge"}
			);

			//MemberCreatesFactor
			AddProp(Elem.Edge, "mcf.ts", "long", Index.None, false);
			AddProp(Elem.Edge, "mcf.dt", "byte", Index.None, false);
			AddProp(Elem.Edge, "mcf.pa", "long", Index.None, false);
			AddProp(Elem.Edge, "mcf.ra", "long", Index.None, false);
			AddEdge("mcf", Cardin.OneToMany, Sort.Desc,
				new[] {"mcf.ts", "mcf.dt", "mcf.pa", "mcf.ra"},
				new[] {"m.at","m.osa","m.ogr","m.ogc","m.oge"}
			);

			//MemberDefinedByApp
			AddEdge("mdbp", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"m.at","m.osa","m.ogr","m.ogc","m.oge"}
			);

			//MemberDefinedByUser
			AddEdge("mdbu", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"m.at","m.osa","m.ogr","m.ogc","m.oge"}
			);

			//OauthAccessAuthenticatesMember
			AddEdge("oaam", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"oa.to","oa.re","oa.ex","oa.dp"}
			);

			//UserDefinesMember
			AddProp(Elem.Edge, "udm.ts", "long", Index.None, false);
			AddProp(Elem.Edge, "udm.mt", "byte", Index.None, false);
			AddProp(Elem.Edge, "udm.pi", "long", Index.None, false);
			AddEdge("udm", Cardin.OneToMany, Sort.Desc,
				new[] {"udm.ts", "udm.mt", "udm.pi"},
				new[] {"u.na","u.nk","u.pa"}
			);
		}

	}

}