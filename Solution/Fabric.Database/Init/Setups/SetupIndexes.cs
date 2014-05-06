
// GENERATED CODE
// Changes made to this source file will be overwritten

namespace Fabric.Database.Init.Setups {


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
			AddProp(Elem.Vertex, "p_na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "p_nk", "String", Index.Standard, true);
			AddProp(Elem.Vertex, "p_se", "String", Index.None, false);
			AddProp(Elem.Vertex, "p_od", "String", Index.None, false);

			//Artifact

			//Class
			AddProp(Elem.Vertex, "c_na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "c_nk", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "c_di", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "c_no", "String", Index.None, false);

			//Email
			AddProp(Elem.Vertex, "e_ad", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "e_co", "String", Index.None, false);
			AddProp(Elem.Vertex, "e_ve", "Boolean", Index.None, false);

			//Factor
			AddProp(Elem.Vertex, "f_at", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_de", "Boolean", Index.None, false);
			AddProp(Elem.Vertex, "f_no", "String", Index.None, false);
			AddProp(Elem.Vertex, "f_det", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_dit", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_dip", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_dir", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_evt", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_evd", "Long", Index.None, false);
			AddProp(Elem.Vertex, "f_idt", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_idv", "String", Index.Both, false);
			AddProp(Elem.Vertex, "f_lot", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_lox", "Double", Index.None, false);
			AddProp(Elem.Vertex, "f_loy", "Double", Index.None, false);
			AddProp(Elem.Vertex, "f_loz", "Double", Index.None, false);
			AddProp(Elem.Vertex, "f_vet", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_veu", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_vep", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "f_vev", "Long", Index.None, false);

			//Instance
			AddProp(Elem.Vertex, "i_na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "i_di", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "i_no", "String", Index.None, false);

			//Member
			AddProp(Elem.Vertex, "m_mt", "Byte", Index.None, false);
			AddProp(Elem.Vertex, "m_osa", "Boolean", Index.None, false);
			AddProp(Elem.Vertex, "m_ogr", "String", Index.None, false);
			AddProp(Elem.Vertex, "m_ogc", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "m_oge", "Long", Index.None, false);

			//OauthAccess
			AddProp(Elem.Vertex, "oa_to", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "oa_re", "String", Index.Standard, false);
			AddProp(Elem.Vertex, "oa_ex", "Long", Index.None, false);

			//Url
			AddProp(Elem.Vertex, "r_na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "r_fp", "String", Index.Standard, true);

			//User
			AddProp(Elem.Vertex, "u_na", "String", Index.Elastic, false);
			AddProp(Elem.Vertex, "u_nk", "String", Index.Standard, true);
			AddProp(Elem.Vertex, "u_pa", "String", Index.None, false);

			//Vertex
			AddProp(Elem.Vertex, "v_id", "Long", Index.Standard, false);
			AddProp(Elem.Vertex, "v_ts", "Long", Index.Elastic, false);
			AddProp(Elem.Vertex, "v_t", "Byte", Index.None, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private void CreateEdges() {

			//AppDefinesMember
			AddProp(Elem.Edge, "pdm_ts", "Long", Index.None, false);
			AddProp(Elem.Edge, "pdm_mt", "Byte", Index.None, false);
			AddProp(Elem.Edge, "pdm_ui", "Long", Index.None, false);
			AddEdge("pdm", Cardin.OneToMany, Sort.Desc,
				new[] {"pdm_ts", "pdm_mt", "pdm_ui"},
				new[] {"p_na","p_nk","p_se","p_od"}
			);

			//ArtifactCreatedByMember
			AddEdge("acbm", Cardin.OneToOne, Sort.None,
				new string[0],
				new string[0]
			);

			//ArtifactUsedAsPrimaryByFactor
			AddProp(Elem.Edge, "apbf_ts", "Long", Index.None, false);
			AddProp(Elem.Edge, "apbf_dt", "Byte", Index.None, false);
			AddProp(Elem.Edge, "apbf_ra", "Long", Index.None, false);
			AddEdge("apbf", Cardin.OneToMany, Sort.Desc,
				new[] {"apbf_ts", "apbf_dt", "apbf_ra"},
				new string[0]
			);

			//ArtifactUsedAsRelatedByFactor
			AddProp(Elem.Edge, "arbf_ts", "Long", Index.None, false);
			AddProp(Elem.Edge, "arbf_dt", "Byte", Index.None, false);
			AddProp(Elem.Edge, "arbf_pa", "Long", Index.None, false);
			AddEdge("arbf", Cardin.OneToMany, Sort.Desc,
				new[] {"arbf_ts", "arbf_dt", "arbf_pa"},
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
				new[] {"e_ad","e_co","e_ve"}
			);

			//FactorCreatedByMember
			AddEdge("fcbm", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f_at","f_de","f_no","f_det","f_dit","f_dip","f_dir","f_evt","f_evd","f_idt","f_idv","f_lot","f_lox","f_loy","f_loz","f_vet","f_veu","f_vep","f_vev"}
			);

			//FactorDescriptorRefinesPrimaryWithArtifact
			AddEdge("frpa", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f_at","f_de","f_no","f_det","f_dit","f_dip","f_dir","f_evt","f_evd","f_idt","f_idv","f_lot","f_lox","f_loy","f_loz","f_vet","f_veu","f_vep","f_vev"}
			);

			//FactorDescriptorRefinesRelatedWithArtifact
			AddEdge("frra", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f_at","f_de","f_no","f_det","f_dit","f_dip","f_dir","f_evt","f_evd","f_idt","f_idv","f_lot","f_lox","f_loy","f_loz","f_vet","f_veu","f_vep","f_vev"}
			);

			//FactorDescriptorRefinesTypeWithArtifact
			AddEdge("frta", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f_at","f_de","f_no","f_det","f_dit","f_dip","f_dir","f_evt","f_evd","f_idt","f_idv","f_lot","f_lox","f_loy","f_loz","f_vet","f_veu","f_vep","f_vev"}
			);

			//FactorUsesPrimaryArtifact
			AddEdge("fpa", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f_at","f_de","f_no","f_det","f_dit","f_dip","f_dir","f_evt","f_evd","f_idt","f_idv","f_lot","f_lox","f_loy","f_loz","f_vet","f_veu","f_vep","f_vev"}
			);

			//FactorUsesRelatedArtifact
			AddEdge("fra", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f_at","f_de","f_no","f_det","f_dit","f_dip","f_dir","f_evt","f_evd","f_idt","f_idv","f_lot","f_lox","f_loy","f_loz","f_vet","f_veu","f_vep","f_vev"}
			);

			//FactorVectorUsesAxisArtifact
			AddEdge("faa", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"f_at","f_de","f_no","f_det","f_dit","f_dip","f_dir","f_evt","f_evd","f_idt","f_idv","f_lot","f_lox","f_loy","f_loz","f_vet","f_veu","f_vep","f_vev"}
			);

			//MemberAuthenticatedByOauthAccess
			AddProp(Elem.Edge, "maboa_ts", "Long", Index.None, false);
			AddEdge("maboa", Cardin.OneToMany, Sort.Desc,
				new[] {"maboa_ts"},
				new[] {"m_mt","m_osa","m_ogr","m_ogc","m_oge"}
			);

			//MemberCreatesArtifact
			AddProp(Elem.Edge, "mca_ts", "Long", Index.None, false);
			AddProp(Elem.Edge, "mca_vt", "Byte", Index.None, false);
			AddEdge("mca", Cardin.OneToMany, Sort.Desc,
				new[] {"mca_ts", "mca_vt"},
				new[] {"m_mt","m_osa","m_ogr","m_ogc","m_oge"}
			);

			//MemberCreatesFactor
			AddProp(Elem.Edge, "mcf_ts", "Long", Index.None, false);
			AddProp(Elem.Edge, "mcf_dt", "Byte", Index.None, false);
			AddProp(Elem.Edge, "mcf_pa", "Long", Index.None, false);
			AddProp(Elem.Edge, "mcf_ra", "Long", Index.None, false);
			AddEdge("mcf", Cardin.OneToMany, Sort.Desc,
				new[] {"mcf_ts", "mcf_dt", "mcf_pa", "mcf_ra"},
				new[] {"m_mt","m_osa","m_ogr","m_ogc","m_oge"}
			);

			//MemberDefinedByApp
			AddEdge("mdbp", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"m_mt","m_osa","m_ogr","m_ogc","m_oge"}
			);

			//MemberDefinedByUser
			AddEdge("mdbu", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"m_mt","m_osa","m_ogr","m_ogc","m_oge"}
			);

			//OauthAccessAuthenticatesMember
			AddEdge("oaam", Cardin.OneToOne, Sort.None,
				new string[0],
				new[] {"oa_to","oa_re","oa_ex"}
			);

			//UserDefinesMember
			AddProp(Elem.Edge, "udm_ts", "Long", Index.None, false);
			AddProp(Elem.Edge, "udm_mt", "Byte", Index.None, false);
			AddProp(Elem.Edge, "udm_pi", "Long", Index.None, false);
			AddEdge("udm", Cardin.OneToMany, Sort.Desc,
				new[] {"udm_ts", "udm_mt", "udm_pi"},
				new[] {"u_na","u_nk","u_pa"}
			);
		}

	}

}