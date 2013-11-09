
// GENERATED CODE
// Changes made to this source file will be overwritten

using System.Collections.Generic;
using Fabric.New.Api.Objects;

namespace Fabric.New.Operations.Traversal.Links {


	/*================================================================================================*/
	public class AppLinks : ArtifactLinks {
		
		public new static readonly AppLinks Instance = new AppLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
			new TravLink<FabMember>("DefinesMembers", false),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public AppLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class ArtifactLinks : VertexLinks {
		
		public new static readonly ArtifactLinks Instance = new ArtifactLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
			new TravLink<FabMember>("CreatedByMember", true),
			new TravLink<FabFactor>("UsedAsPrimaryByFactors", false),
			new TravLink<FabFactor>("UsedAsRelatedByFactors", false),
			new TravLink<FabEmail>("UsesEmails", false),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ArtifactLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class ClassLinks : ArtifactLinks {
		
		public new static readonly ClassLinks Instance = new ClassLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ClassLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class EmailLinks : VertexLinks {
		
		public new static readonly EmailLinks Instance = new EmailLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
			new TravLink<FabArtifact>("UsedByArtifact", true),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class FactorLinks : VertexLinks {
		
		public new static readonly FactorLinks Instance = new FactorLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
			new TravLink<FabMember>("CreatedByMember", true),
			new TravLink<FabArtifact>("RefinesPrimaryWithArtifact", true),
			new TravLink<FabArtifact>("RefinesRelatedWithArtifact", true),
			new TravLink<FabArtifact>("RefinesTypeWithArtifact", true),
			new TravLink<FabArtifact>("UsesPrimaryArtifact", true),
			new TravLink<FabArtifact>("UsesRelatedArtifact", true),
			new TravLink<FabArtifact>("UsesAxisArtifact", true),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public FactorLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class InstanceLinks : ArtifactLinks {
		
		public new static readonly InstanceLinks Instance = new InstanceLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public InstanceLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class MemberLinks : VertexLinks {
		
		public new static readonly MemberLinks Instance = new MemberLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
			new TravLink<FabOauthAccess>("AuthenticatedByOauthAccesses", false),
			new TravLink<FabArtifact>("CreatesArtifacts", false),
			new TravLink<FabFactor>("CreatesFactors", false),
			new TravLink<FabApp>("DefinedByApp", true),
			new TravLink<FabUser>("DefinedByUser", true),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public MemberLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class OauthAccessLinks : VertexLinks {
		
		public new static readonly OauthAccessLinks Instance = new OauthAccessLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
			new TravLink<FabMember>("AuthenticatesMember", true),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public OauthAccessLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class UrlLinks : ArtifactLinks {
		
		public new static readonly UrlLinks Instance = new UrlLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UrlLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class UserLinks : ArtifactLinks {
		
		public new static readonly UserLinks Instance = new UserLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
			new TravLink<FabMember>("DefinesMembers", false),
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public UserLinks() {
			Links.AddRange(vLinks);
		}
		
	}


	/*================================================================================================*/
	public class VertexLinks : VertexBaseLinks {
		
		public static readonly VertexLinks Instance = new VertexLinks();

		private readonly IList<ITravLink> vLinks = new List<ITravLink> {
		};

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public VertexLinks() {
			Links.AddRange(vLinks);
		}
		
	}

}