using System.Collections.Generic;
using System.Linq;
using Weaver.Schema;

namespace Fabric.Domain {

	/*================================================================================================*/
	public class SchemaHelperNode {

		public WeaverNodeSchema NodeSchema { get; private set; }

		public bool HasParentClass { get; private set; }

		private readonly IList<SchemaHelperProp> vProps;
		private readonly IList<SchemaHelperNodeRel> vRels;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public SchemaHelperNode(WeaverNodeSchema pNode) {
			NodeSchema = pNode;

			HasParentClass = (NodeSchema.BaseNode != null);

			vProps = new List<SchemaHelperProp>();
			vRels = new List<SchemaHelperNodeRel>();

			foreach ( WeaverPropSchema ps in NodeSchema.Props ) {
				vProps.Add(new SchemaHelperProp(ps));
			}

			foreach ( WeaverRelSchema pr in SchemaHelper.SchemaInstance.Rels ) {
				if ( pr.FromNode != NodeSchema && pr.ToNode != NodeSchema ) { continue; }
				vRels.Add(new SchemaHelperNodeRel(this, pr));
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<SchemaHelperProp> GetProps(bool pSkipInternal=false) {
			return vProps
				.Where(p => (!pSkipInternal || p.PropSchema.IsInternal != true))
				.ToList();
		}

		/*--------------------------------------------------------------------------------------------*/
		public IList<SchemaHelperNodeRel> GetRels(bool pSkipInternal=false) {
			return vRels
				//.Where(p => (!pSkipInternal || p.RelSchema.IsInternal != true))
				.ToList();
		}

	}

}