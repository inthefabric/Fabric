
// GENERATED CODE
// Changes made to this source file will be overwritten

using Weaver.Core.Elements;
using Weaver.Titan.Elements;

namespace Fabric.New.Domain {


	/*================================================================================================*/
	public class Defines : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class CreatedBy : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class UsedAsPrimaryBy : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class UsedAsRelatedBy : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class DescriptorTypeRefinedBy : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class PrimaryRefinedBy : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class RelatedRefinedBy : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class UsesPrimary : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class UsesRelated : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class VectorUsesAxis : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class Creates : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class DefinedBy : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	[WeaverTitanEdge("dm", WeaverEdgeConn.OutZeroOrMore, typeof(App),
		WeaverEdgeConn.InZeroOrMore, typeof(Member))]
	public class AppDefinesMember : EdgeBase<App, Defines, Member> {

		[WeaverTitanProperty("dm.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("dm.mt")]
		public virtual byte MemberType { get; set; }

		[WeaverTitanProperty("dm.ui")]
		public virtual long UserId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual App FromApp {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Member ToMember {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("cbm", WeaverEdgeConn.OutOne, typeof(Artifact),
		WeaverEdgeConn.InZeroOrMore, typeof(Member))]
	public class ArtifactCreatedByMember : EdgeBase<Artifact, CreatedBy, Member> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact FromArtifact {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Member ToMember {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("upbf", WeaverEdgeConn.OutZeroOrMore, typeof(Artifact),
		WeaverEdgeConn.InZeroOrMore, typeof(Factor))]
	public class ArtifactUsedAsPrimaryByFactor : EdgeBase<Artifact, UsedAsPrimaryBy, Factor> {

		[WeaverTitanProperty("upbf.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("upbf.dt")]
		public virtual byte DesdcriptorType { get; set; }

		[WeaverTitanProperty("upbf.ra")]
		public virtual long RelatedArtifactId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact FromArtifact {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor ToFactor {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("urbf", WeaverEdgeConn.OutZeroOrMore, typeof(Artifact),
		WeaverEdgeConn.InZeroOrMore, typeof(Factor))]
	public class ArtifactUsedAsRelatedByFactor : EdgeBase<Artifact, UsedAsRelatedBy, Factor> {

		[WeaverTitanProperty("urbf.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("urbf.dt")]
		public virtual byte DesdcriptorType { get; set; }

		[WeaverTitanProperty("urbf.pa")]
		public virtual long PrimaryArtifactId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact FromArtifact {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor ToFactor {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("cbm", WeaverEdgeConn.OutOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Member))]
	public class FactorCreatedByMember : EdgeBase<Factor, CreatedBy, Member> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor FromFactor {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Member ToMember {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("drba", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorDescriptorTypeRefinedByArtifact : EdgeBase<Factor, DescriptorTypeRefinedBy, Artifact> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor FromFactor {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact ToArtifact {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("prba", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorPrimaryRefinedByArtifact : EdgeBase<Factor, PrimaryRefinedBy, Artifact> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor FromFactor {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact ToArtifact {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("rrba", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorRelatedRefinedByArtifact : EdgeBase<Factor, RelatedRefinedBy, Artifact> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor FromFactor {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact ToArtifact {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("upa", WeaverEdgeConn.OutOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorUsesPrimaryArtifact : EdgeBase<Factor, UsesPrimary, Artifact> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor FromFactor {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact ToArtifact {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("ura", WeaverEdgeConn.OutOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorUsesRelatedArtifact : EdgeBase<Factor, UsesRelated, Artifact> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor FromFactor {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact ToArtifact {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("uaa", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorVectorUsesAxisArtifact : EdgeBase<Factor, VectorUsesAxis, Artifact> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor FromFactor {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact ToArtifact {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("ca", WeaverEdgeConn.OutZeroOrMore, typeof(Member),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class MemberCreatesArtifact : EdgeBase<Member, Creates, Artifact> {

		[WeaverTitanProperty("ca.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("ca.vt")]
		public virtual byte VertexType { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Member FromMember {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Artifact ToArtifact {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("cf", WeaverEdgeConn.OutZeroOrMore, typeof(Member),
		WeaverEdgeConn.InZeroOrMore, typeof(Factor))]
	public class MemberCreatesFactor : EdgeBase<Member, Creates, Factor> {

		[WeaverTitanProperty("cf.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("cf.dt")]
		public virtual byte DescriptorType { get; set; }

		[WeaverTitanProperty("cf.pa")]
		public virtual long PrimaryArtifactId { get; set; }

		[WeaverTitanProperty("cf.ra")]
		public virtual long RelatedArtifactId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Member FromMember {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Factor ToFactor {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("dba", WeaverEdgeConn.OutOne, typeof(Member),
		WeaverEdgeConn.InZeroOrMore, typeof(App))]
	public class MemberDefinedByApp : EdgeBase<Member, DefinedBy, App> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Member FromMember {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual App ToApp {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("dbu", WeaverEdgeConn.OutOne, typeof(Member),
		WeaverEdgeConn.InZeroOrMore, typeof(User))]
	public class MemberDefinedByUser : EdgeBase<Member, DefinedBy, User> {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual Member FromMember {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual User ToUser {
			get { return InVertex; }
		}

	}


	/*================================================================================================*/
	[WeaverTitanEdge("dm", WeaverEdgeConn.OutZeroOrMore, typeof(User),
		WeaverEdgeConn.InZeroOrMore, typeof(Member))]
	public class UserDefinesMember : EdgeBase<User, Defines, Member> {

		[WeaverTitanProperty("dm.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("dm.mt")]
		public virtual byte MemberType { get; set; }

		[WeaverTitanProperty("dm.ai")]
		public virtual long AppId { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual User FromUser {
			get { return OutVertex; }
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual Member ToMember {
			get { return InVertex; }
		}

	}

}