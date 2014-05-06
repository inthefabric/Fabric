
// GENERATED CODE
// Changes made to this source file will be overwritten

namespace Fabric.Domain.Names {

	/*================================================================================================*/
	public static partial class DbName {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static class Edge {
		
			public const string AppDefinesMemberName = "pdm";
			public const string ArtifactCreatedByMemberName = "acbm";
			public const string ArtifactUsedAsPrimaryByFactorName = "apbf";
			public const string ArtifactUsedAsRelatedByFactorName = "arbf";
			public const string ArtifactUsesEmailName = "aue";
			public const string EmailUsedByArtifactName = "eba";
			public const string FactorCreatedByMemberName = "fcbm";
			public const string FactorDescriptorRefinesPrimaryWithArtifactName = "frpa";
			public const string FactorDescriptorRefinesRelatedWithArtifactName = "frra";
			public const string FactorDescriptorRefinesTypeWithArtifactName = "frta";
			public const string FactorUsesPrimaryArtifactName = "fpa";
			public const string FactorUsesRelatedArtifactName = "fra";
			public const string FactorVectorUsesAxisArtifactName = "faa";
			public const string MemberAuthenticatedByOauthAccessName = "maboa";
			public const string MemberCreatesArtifactName = "mca";
			public const string MemberCreatesFactorName = "mcf";
			public const string MemberDefinedByAppName = "mdbp";
			public const string MemberDefinedByUserName = "mdbu";
			public const string OauthAccessAuthenticatesMemberName = "oaam";
			public const string UserDefinesMemberName = "udm";

			/*----------------------------------------------------------------------------------------*/
			public static class AppDefinesMember {

				public const string Timestamp = "pdm_ts";
				public const string MemberType = "pdm_mt";
				public const string UserId = "pdm_ui";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class ArtifactUsedAsPrimaryByFactor {

				public const string Timestamp = "apbf_ts";
				public const string DescriptorType = "apbf_dt";
				public const string RelatedArtifactId = "apbf_ra";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class ArtifactUsedAsRelatedByFactor {

				public const string Timestamp = "arbf_ts";
				public const string DescriptorType = "arbf_dt";
				public const string PrimaryArtifactId = "arbf_pa";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class MemberAuthenticatedByOauthAccess {

				public const string Timestamp = "maboa_ts";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class MemberCreatesArtifact {

				public const string Timestamp = "mca_ts";
				public const string VertexType = "mca_vt";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class MemberCreatesFactor {

				public const string Timestamp = "mcf_ts";
				public const string DescriptorType = "mcf_dt";
				public const string PrimaryArtifactId = "mcf_pa";
				public const string RelatedArtifactId = "mcf_ra";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class UserDefinesMember {

				public const string Timestamp = "udm_ts";
				public const string MemberType = "udm_mt";
				public const string AppId = "udm_pi";

			}

		}

	}

}