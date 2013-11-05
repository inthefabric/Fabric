﻿
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
	public class DescriptorRefinesPrimaryWith : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class DescriptorRefinesRelatedWith : IWeaverEdgeType {

		public string Label { get { return null; } }

	}


	/*================================================================================================*/
	public class DescriptorRefinesTypeWith : IWeaverEdgeType {

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
	[WeaverTitanEdge("pdm", WeaverEdgeConn.OutZeroOrMore, typeof(App),
		WeaverEdgeConn.InZeroOrMore, typeof(Member))]
	public class AppDefinesMember : EdgeBase<App, Defines, Member> {

		[WeaverTitanProperty("pdm.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("pdm.mt")]
		public virtual byte MemberType { get; set; }

		[WeaverTitanProperty("pdm.ui")]
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
	[WeaverTitanEdge("acbm", WeaverEdgeConn.OutOne, typeof(Artifact),
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
	[WeaverTitanEdge("apbf", WeaverEdgeConn.OutZeroOrMore, typeof(Artifact),
		WeaverEdgeConn.InZeroOrMore, typeof(Factor))]
	public class ArtifactUsedAsPrimaryByFactor : EdgeBase<Artifact, UsedAsPrimaryBy, Factor> {

		[WeaverTitanProperty("apbf.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("apbf.dt")]
		public virtual byte DesdcriptorType { get; set; }

		[WeaverTitanProperty("apbf.ra")]
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
	[WeaverTitanEdge("arbf", WeaverEdgeConn.OutZeroOrMore, typeof(Artifact),
		WeaverEdgeConn.InZeroOrMore, typeof(Factor))]
	public class ArtifactUsedAsRelatedByFactor : EdgeBase<Artifact, UsedAsRelatedBy, Factor> {

		[WeaverTitanProperty("arbf.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("arbf.dt")]
		public virtual byte DesdcriptorType { get; set; }

		[WeaverTitanProperty("arbf.pa")]
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
	[WeaverTitanEdge("fcbm", WeaverEdgeConn.OutOne, typeof(Factor),
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
	[WeaverTitanEdge("frpa", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorDescriptorRefinesPrimaryWithArtifact : EdgeBase<Factor, DescriptorRefinesPrimaryWith, Artifact> {


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
	[WeaverTitanEdge("frra", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorDescriptorRefinesRelatedWithArtifact : EdgeBase<Factor, DescriptorRefinesRelatedWith, Artifact> {


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
	[WeaverTitanEdge("frta", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class FactorDescriptorRefinesTypeWithArtifact : EdgeBase<Factor, DescriptorRefinesTypeWith, Artifact> {


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
	[WeaverTitanEdge("fpa", WeaverEdgeConn.OutOne, typeof(Factor),
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
	[WeaverTitanEdge("fra", WeaverEdgeConn.OutOne, typeof(Factor),
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
	[WeaverTitanEdge("faa", WeaverEdgeConn.OutZeroOrOne, typeof(Factor),
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
	[WeaverTitanEdge("mca", WeaverEdgeConn.OutZeroOrMore, typeof(Member),
		WeaverEdgeConn.InZeroOrMore, typeof(Artifact))]
	public class MemberCreatesArtifact : EdgeBase<Member, Creates, Artifact> {

		[WeaverTitanProperty("mca.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("mca.vt")]
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
	[WeaverTitanEdge("mcf", WeaverEdgeConn.OutZeroOrMore, typeof(Member),
		WeaverEdgeConn.InZeroOrMore, typeof(Factor))]
	public class MemberCreatesFactor : EdgeBase<Member, Creates, Factor> {

		[WeaverTitanProperty("mcf.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("mcf.dt")]
		public virtual byte DescriptorType { get; set; }

		[WeaverTitanProperty("mcf.pa")]
		public virtual long PrimaryArtifactId { get; set; }

		[WeaverTitanProperty("mcf.ra")]
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
	[WeaverTitanEdge("mdbp", WeaverEdgeConn.OutOne, typeof(Member),
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
	[WeaverTitanEdge("mdbu", WeaverEdgeConn.OutOne, typeof(Member),
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
	[WeaverTitanEdge("udm", WeaverEdgeConn.OutZeroOrMore, typeof(User),
		WeaverEdgeConn.InZeroOrMore, typeof(Member))]
	public class UserDefinesMember : EdgeBase<User, Defines, Member> {

		[WeaverTitanProperty("udm.ts")]
		public virtual long Timestamp { get; set; }

		[WeaverTitanProperty("udm.mt")]
		public virtual byte MemberType { get; set; }

		[WeaverTitanProperty("udm.pi")]
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