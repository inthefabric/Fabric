
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal.Funcs {


	/*================================================================================================*/
	public class AppFuncs : ArtifactFuncs {
		
		public new static readonly AppFuncs Instance = new AppFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabApp>("HasName"),
			new TravFunc<FabApp>("HasNameKey"),
			new TravFunc<FabApp>("HasSecret"),
			new TravFunc<FabApp>("HasOauthDomains"),
			new TravFunc<FabApp>("HasTimestamp", "DefinesMembers"),
			new TravFunc<FabApp>("HasMemberType", "DefinesMembers"),
			new TravFunc<FabApp>("HasUserId", "DefinesMembers"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class ArtifactFuncs : VertexFuncs {
		
		public new static readonly ArtifactFuncs Instance = new ArtifactFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabArtifact>("HasTimestamp", "UsedAsPrimaryByFactors"),
			new TravFunc<FabArtifact>("HasDescriptorType", "UsedAsPrimaryByFactors"),
			new TravFunc<FabArtifact>("HasRelatedArtifactId", "UsedAsPrimaryByFactors"),
			new TravFunc<FabArtifact>("HasTimestamp", "UsedAsRelatedByFactors"),
			new TravFunc<FabArtifact>("HasDescriptorType", "UsedAsRelatedByFactors"),
			new TravFunc<FabArtifact>("HasPrimaryArtifactId", "UsedAsRelatedByFactors"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class ClassFuncs : ArtifactFuncs {
		
		public new static readonly ClassFuncs Instance = new ClassFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabClass>("HasName"),
			new TravFunc<FabClass>("HasNameKey"),
			new TravFunc<FabClass>("HasDisamb"),
			new TravFunc<FabClass>("HasNote"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class EmailFuncs : VertexFuncs {
		
		public new static readonly EmailFuncs Instance = new EmailFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabEmail>("HasAddress"),
			new TravFunc<FabEmail>("HasCode"),
			new TravFunc<FabEmail>("HasVerified"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class FactorFuncs : VertexFuncs {
		
		public new static readonly FactorFuncs Instance = new FactorFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabFactor>("HasAssertionType"),
			new TravFunc<FabFactor>("HasIsDefining"),
			new TravFunc<FabFactor>("HasNote"),
			new TravFunc<FabFactor>("HasDescriptorType"),
			new TravFunc<FabFactor>("HasDirectorType"),
			new TravFunc<FabFactor>("HasDirectorPrimaryAction"),
			new TravFunc<FabFactor>("HasDirectorRelatedAction"),
			new TravFunc<FabFactor>("HasEventorType"),
			new TravFunc<FabFactor>("HasEventorDateTime"),
			new TravFunc<FabFactor>("HasIdentorType"),
			new TravFunc<FabFactor>("HasIdentorValue"),
			new TravFunc<FabFactor>("HasLocatorType"),
			new TravFunc<FabFactor>("HasLocatorValueX"),
			new TravFunc<FabFactor>("HasLocatorValueY"),
			new TravFunc<FabFactor>("HasLocatorValueZ"),
			new TravFunc<FabFactor>("HasVectorType"),
			new TravFunc<FabFactor>("HasVectorUnit"),
			new TravFunc<FabFactor>("HasVectorUnitPrefix"),
			new TravFunc<FabFactor>("HasVectorValue"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class InstanceFuncs : ArtifactFuncs {
		
		public new static readonly InstanceFuncs Instance = new InstanceFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabInstance>("HasName"),
			new TravFunc<FabInstance>("HasDisamb"),
			new TravFunc<FabInstance>("HasNote"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class MemberFuncs : VertexFuncs {
		
		public new static readonly MemberFuncs Instance = new MemberFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabMember>("HasMemberType"),
			new TravFunc<FabMember>("HasOauthScopeAllow"),
			new TravFunc<FabMember>("HasOauthGrantRedirectUri"),
			new TravFunc<FabMember>("HasOauthGrantCode"),
			new TravFunc<FabMember>("HasOauthGrantExpires"),
			new TravFunc<FabMember>("HasTimestamp", "AuthenticatedByOauthAccesses"),
			new TravFunc<FabMember>("HasTimestamp", "CreatesArtifacts"),
			new TravFunc<FabMember>("HasVertexType", "CreatesArtifacts"),
			new TravFunc<FabMember>("HasTimestamp", "CreatesFactors"),
			new TravFunc<FabMember>("HasDescriptorType", "CreatesFactors"),
			new TravFunc<FabMember>("HasPrimaryArtifactId", "CreatesFactors"),
			new TravFunc<FabMember>("HasRelatedArtifactId", "CreatesFactors"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class OauthAccessFuncs : VertexFuncs {
		
		public new static readonly OauthAccessFuncs Instance = new OauthAccessFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabOauthAccess>("HasToken"),
			new TravFunc<FabOauthAccess>("HasRefresh"),
			new TravFunc<FabOauthAccess>("HasExpires"),
			new TravFunc<FabOauthAccess>("HasIsClientOnly"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class UrlFuncs : ArtifactFuncs {
		
		public new static readonly UrlFuncs Instance = new UrlFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabUrl>("HasName"),
			new TravFunc<FabUrl>("HasFullPath"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class UserFuncs : ArtifactFuncs {
		
		public new static readonly UserFuncs Instance = new UserFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabUser>("HasName"),
			new TravFunc<FabUser>("HasNameKey"),
			new TravFunc<FabUser>("HasPassword"),
			new TravFunc<FabUser>("HasTimestamp", "DefinesMembers"),
			new TravFunc<FabUser>("HasMemberType", "DefinesMembers"),
			new TravFunc<FabUser>("HasAppId", "DefinesMembers"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}


	/*================================================================================================*/
	public class VertexFuncs : VertexBaseFuncs {
		
		public static readonly VertexFuncs Instance = new VertexFuncs();

		private readonly IList<ITravFunc> vFuncs = new List<ITravFunc> {
			new TravFunc<FabVertex>("HasVertexId"),
			new TravFunc<FabVertex>("HasTimestamp"),
			new TravFunc<FabVertex>("HasVertexType"),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexFuncs() {
			Funcs.AddRange(vFuncs);
		}
		
	}

}