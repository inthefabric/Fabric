
// GENERATED CODE
// Changes made to this source file will be overwritten

namespace Fabric.Domain.Names {

	/*================================================================================================*/
	public static partial class DbName {
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static class Vert {
		
			public const string AppName = "p";
			public const string ArtifactName = "a";
			public const string ClassName = "c";
			public const string EmailName = "e";
			public const string FactorName = "f";
			public const string InstanceName = "i";
			public const string MemberName = "m";
			public const string OauthAccessName = "oa";
			public const string UrlName = "r";
			public const string UserName = "u";
			public const string VertexName = "v";

			/*----------------------------------------------------------------------------------------*/
			public static class App {

				public const string Name = "p_na";
				public const string NameKey = "p_nk";
				public const string Secret = "p_se";
				public const string OauthDomains = "p_od";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Class {

				public const string Name = "c_na";
				public const string NameKey = "c_nk";
				public const string Disamb = "c_di";
				public const string Note = "c_no";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Email {

				public const string Address = "e_ad";
				public const string Code = "e_co";
				public const string Verified = "e_ve";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Factor {

				public const string AssertionType = "f_at";
				public const string IsDefining = "f_de";
				public const string Note = "f_no";
				public const string DescriptorType = "f_det";
				public const string DirectorType = "f_dit";
				public const string DirectorPrimaryAction = "f_dip";
				public const string DirectorRelatedAction = "f_dir";
				public const string EventorType = "f_evt";
				public const string EventorDateTime = "f_evd";
				public const string IdentorType = "f_idt";
				public const string IdentorValue = "f_idv";
				public const string LocatorType = "f_lot";
				public const string LocatorValueX = "f_lox";
				public const string LocatorValueY = "f_loy";
				public const string LocatorValueZ = "f_loz";
				public const string VectorType = "f_vet";
				public const string VectorUnit = "f_veu";
				public const string VectorUnitPrefix = "f_vep";
				public const string VectorValue = "f_vev";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Instance {

				public const string Name = "i_na";
				public const string Disamb = "i_di";
				public const string Note = "i_no";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Member {

				public const string MemberType = "m_mt";
				public const string OauthScopeAllow = "m_osa";
				public const string OauthGrantRedirectUri = "m_ogr";
				public const string OauthGrantCode = "m_ogc";
				public const string OauthGrantExpires = "m_oge";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class OauthAccess {

				public const string Token = "oa_to";
				public const string Refresh = "oa_re";
				public const string Expires = "oa_ex";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Url {

				public const string Name = "r_na";
				public const string FullPath = "r_fp";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class User {

				public const string Name = "u_na";
				public const string NameKey = "u_nk";
				public const string Password = "u_pa";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Vertex {

				public const string VertexId = "v_id";
				public const string Timestamp = "v_ts";
				public const string VertexType = "v_t";

			}

		}

	}

}