using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
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
		public void AssertRelCount(bool pIsOutgoing, int pCount) {
			IList<NodeConnectionRel> rels = (pIsOutgoing ? OutRels : InRels);
			Assert.AreEqual(pCount, rels.Count, "Incorrect "+(pIsOutgoing ? "Out" : "In")+"Rel count.");
		}

		/*--------------------------------------------------------------------------------------------*/
		public void AssertRel<TRel, TNode>(bool pIsOutgoing)
													where TRel : IWeaverRel where TNode : INodeWithId {
			IList<NodeConnectionRel> rels = (pIsOutgoing ? OutRels : InRels);

			foreach ( NodeConnectionRel rel in rels ) {
				if ( rel.Rel.Class != typeof(TRel).Name ) {
					continue;
				}

				if ( rel.TargetNode.Class != typeof(TNode).Name ) {
					continue;
				}

				return;
			}

			Assert.Fail((pIsOutgoing ? "Out" : "In")+"Rel ["+typeof(TRel).Name+"+"+typeof(TNode).Name+
				"] was not found.");
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
		private IDbDto GetTargetNode(long? pNodeId) {
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
			string s = Node.GetType().Name+"["+Node.Id+"]";

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