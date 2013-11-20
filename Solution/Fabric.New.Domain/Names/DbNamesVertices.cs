
// GENERATED CODE
// Changes made to this source file will be overwritten

namespace Fabric.New.Domain.Names {

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

				public const string Name = "p.na";
				public const string NameKey = "p.nk";
				public const string Secret = "p.se";
				public const string OauthDomains = "p.od";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Class {

				public const string Name = "c.na";
				public const string NameKey = "c.nk";
				public const string Disamb = "c.di";
				public const string Note = "c.no";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Email {

				public const string Address = "e.ad";
				public const string Code = "e.co";
				public const string Verified = "e.ve";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Factor {

				public const string AssertionType = "f.at";
				public const string IsDefining = "f.de";
				public const string Note = "f.no";
				public const string DescriptorType = "f.det";
				public const string DirectorType = "f.dit";
				public const string DirectorPrimaryAction = "f.dip";
				public const string DirectorRelatedAction = "f.dir";
				public const string EventorType = "f.evt";
				public const string EventorDateTime = "f.evd";
				public const string IdentorType = "f.idt";
				public const string IdentorValue = "f.idv";
				public const string LocatorType = "f.lot";
				public const string LocatorValueX = "f.lox";
				public const string LocatorValueY = "f.loy";
				public const string LocatorValueZ = "f.loz";
				public const string VectorType = "f.vet";
				public const string VectorUnit = "f.veu";
				public const string VectorUnitPrefix = "f.vep";
				public const string VectorValue = "f.vev";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Instance {

				public const string Name = "i.na";
				public const string Disamb = "i.di";
				public const string Note = "i.no";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Member {

				public const string MemberType = "m.at";
				public const string OauthScopeAllow = "m.osa";
				public const string OauthGrantRedirectUri = "m.ogr";
				public const string OauthGrantCode = "m.ogc";
				public const string OauthGrantExpires = "m.oge";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class OauthAccess {

				public const string Token = "oa.to";
				public const string Refresh = "oa.re";
				public const string Expires = "oa.ex";
				public const string IsDataProv = "oa.dp";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Url {

				public const string Name = "r.na";
				public const string FullPath = "r.fp";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class User {

				public const string Name = "u.na";
				public const string NameKey = "u.nk";
				public const string Password = "u.pa";

			}

			/*----------------------------------------------------------------------------------------*/
			public static class Vertex {

				public const string VertexId = "v.id";
				public const string Timestamp = "v.ts";
				public const string VertexType = "v.t";

			}

		}

	}

}