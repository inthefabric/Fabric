using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Weaver;
using NUnit.Framework;
using Weaver.Interfaces;

namespace Fabric.Test.Integration.Common {

	/*================================================================================================*/
	public class NodeConnections {

		public INodeWithId Node { get; private set; }
		public IApiDataAccess DataAccess { get; private set; }

		public IList<IDbDto> TargetNodes { get; private set; }
		public IList<NodeConnectionRel> OutRels { get; private set; }
		public IList<NodeConnectionRel> InRels { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public NodeConnections(INodeWithId pNode, IApiDataAccess pData) {
			Node = pNode;
			DataAccess = pData;

			TargetNodes = new List<IDbDto>();
			OutRels = new List<NodeConnectionRel>();
			InRels = new List<NodeConnectionRel>();

			if ( DataAccess.ResultDtoList == null ) {
				return;
			}

			foreach ( IDbDto dbDto in DataAccess.ResultDtoList ) {
				if ( dbDto.Item == DbDto.ItemType.Node ) {
					TargetNodes.Add(dbDto);
				}
			}

			foreach ( IDbDto dbDto in DataAccess.ResultDtoList ) {
				if ( dbDto.Item == DbDto.ItemType.Rel ) {
					AddRel(dbDto);
				}
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void AssertRelCount(int pIncoming, int pOutgoing) {
			string end = " count for "+Node.GetType().Name+".";
			Assert.AreEqual(pIncoming, InRels.Count, "Incorrect InRels"+end);
			Assert.AreEqual(pOutgoing, OutRels.Count, "Incorrect OutRels"+end);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AssertRelCount<TRel>(bool pIsOutgoing, int pCount) where TRel : IWeaverRel {
			IList<NodeConnectionRel> rels = (pIsOutgoing ? OutRels : InRels);
			int count = 0;

			foreach ( NodeConnectionRel rel in rels ) {
				if ( rel.Rel.Class != RelDbName.TypeMap[typeof(TRel)] ) {
					continue;
				}

				count++;
			}

			Assert.AreEqual(pCount, count, "Incorrect "+(pIsOutgoing ? "Out" : "In")+"Rel ["+
				typeof(TRel).Name+"] count for "+Node.GetType().Name+".");

		}

		/*--------------------------------------------------------------------------------------------*/
		public void AssertRel<TRel, TNode>(bool pIsOutgoing, long pTargetId, string pIdProperty=null)
													where TRel : IWeaverRel where TNode : INodeWithId {
			IList<NodeConnectionRel> rels = (pIsOutgoing ? OutRels : InRels);

			foreach ( NodeConnectionRel rel in rels ) {
				if ( rel.Rel.Class != RelDbName.TypeMap[typeof(TRel)] ) {
					continue;
				}

				if ( pIdProperty == null && rel.TargetNode.Class != typeof(TNode).Name ) {
					continue;
				}

				string prop = (pIdProperty ?? PropDbName.StrTypeIdMap[rel.TargetNode.Class]);
				string targId = rel.TargetNode.Data[prop];

				if ( long.Parse(targId) != pTargetId ) {
					continue;
				}

				return;
			}

			Assert.Fail((pIsOutgoing ? "Out" : "In")+"Rel ["+typeof(TRel).Name+"+"+typeof(TNode).Name+
				"] was not found for "+Node.GetType().Name+".");
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private void AddRel(IDbDto pDbDto) {
			if ( pDbDto.FromNodeId == Node.Id ) {
				var rel = new NodeConnectionRel(pDbDto, true, GetTargetNode(pDbDto.ToNodeId));
				OutRels.Add(rel);
			}
			else {
				var rel = new NodeConnectionRel(pDbDto, false, GetTargetNode(pDbDto.FromNodeId));
				InRels.Add(rel);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		private IDbDto GetTargetNode(string pNodeId) {
			if ( pNodeId == null ) {
				throw new Exception("NodeId cannot be null.");
			}

			foreach ( IDbDto n in TargetNodes ) {
				if ( n.Id == pNodeId ) {
					return n;
				}
			}

			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public override string ToString() {
			string s = Node.GetType().Name+"["+Node.Id+", "+Node.GetTypeId()+"]";

			foreach ( NodeConnectionRel rel in OutRels ) {
				s += "\n\t* "+rel;
			}

			foreach ( NodeConnectionRel rel in InRels ) {
				s += "\n\t* "+rel;
			}

			return s;
		}

	}

}