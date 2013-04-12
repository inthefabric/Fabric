using System;
using System.Collections.Generic;
using Fabric.Api.Dto.Batch;
using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Test.Util;
using NUnit.Framework;
using ServiceStack.Text;

namespace Fabric.Test.Integration.FabApiModify {

	/*================================================================================================*/
	[TestFixture]
	public class XBatchCreateFactor : XBaseModifyFunc {
		
		private IList<FabBatchNewFactor> vFactors;
		private string vFactorsJson;

		private int vNewRels;
		private IList<FabBatchResult> vResults;
		
	
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected override void TestSetUp() {
			base.TestSetUp();
			int batchId = 100;
			DataSet ds = Setup.SetupAll(true);

			vFactors = new List<FabBatchNewFactor>();
			vNewRels = 0;

			foreach ( IDataNode dn in ds.Nodes ) {
				if ( dn.NodeType != typeof(Factor) ) {
					continue;
				}

				Factor f = (Factor)dn.Node;

				var bnf = new FabBatchNewFactor();
				bnf.BatchId = batchId++;
				bnf.FactorAssertionId = f.FactorAssertionId;
				bnf.IsDefining = true;
				bnf.Note = f.Note;
				bnf.Descriptor = new FabBatchNewFactorDescriptor();
				vFactors.Add(bnf);

				foreach ( IDataRel dr in ds.Rels ) {
					if ( dr.FromNode != f ) {
						continue;
					}

					Artifact a = (Artifact)dr.ToNode;

					if ( dr.Rel.RelType is UsesPrimary ) {
						bnf.PrimaryArtifactId = a.ArtifactId;
						vNewRels++;
					}
					else if ( dr.Rel.RelType is UsesRelated ) {
						bnf.RelatedArtifactId = a.ArtifactId;
						vNewRels++;
					}
					else if ( dr.Rel.RelType is DescriptorRefinesPrimaryWith ) {
						bnf.Descriptor.PrimaryArtifactRefineId = a.ArtifactId;
						vNewRels++;
					}
					else if ( dr.Rel.RelType is DescriptorRefinesRelatedWith ) {
						bnf.Descriptor.RelatedArtifactRefineId = a.ArtifactId;
						vNewRels++;
					}
					else if ( dr.Rel.RelType is DescriptorRefinesTypeWith ) {
						bnf.Descriptor.TypeRefineId = a.ArtifactId;
						vNewRels++;
					}
					else if ( dr.Rel.RelType is VectorUsesAxis ) {
						bnf.Vector = new FabBatchNewFactorVector();
						bnf.Vector.AxisArtifactId = a.ArtifactId;
						vNewRels++;
					}
					else {
						throw new Exception("Missed edge: "+dr.Rel.RelType);
					}
				}
			}

			/*vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Art,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.App_FabSys,
				FactorAssertionId = (byte)FactorAssertionId.Guess,
				IsDefining = false,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.IsInterestedIn
				}
			});
			vNewRels += 0;

			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Aei,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Caldonia,
				FactorAssertionId = (byte)FactorAssertionId.Fact,
				IsDefining = false,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.IsFoundIn
				},
				Eventor = new FabBatchNewFactorEventor {
					TypeId = (byte)EventorTypeId.Continue,
					PrecisionId = (byte)EventorPrecisionId.Year,
					DateTime = new DateTime(2013, 1, 1).Ticks
				}
			});
			vNewRels += 0;

			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Evolution,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Excitement,
				FactorAssertionId = (byte)FactorAssertionId.Opinion,
				IsDefining = true,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.EmotesLike
				},
				Vector = new FabBatchNewFactorVector {
					TypeId = (byte)VectorTypeId.StdPerc,
					Value = 90,
					UnitId = (byte)VectorUnitId.Percent,
					UnitPrefixId = (byte)VectorUnitPrefixId.Base,
					AxisArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Quality
				}
			});
			vNewRels += 1;

			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Evolution,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Excitement,
				FactorAssertionId = (byte)FactorAssertionId.Opinion,
				IsDefining = true,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.EmotesLike,
					PrimaryArtifactRefineId = (long)SetupArtifacts.ArtifactId.Thi_DetroitTigers,
					TypeRefineId = (long)SetupArtifacts.ArtifactId.Thi_Art
				},
				Vector = new FabBatchNewFactorVector {
					TypeId = (byte)VectorTypeId.StdPerc,
					Value = 90,
					UnitId = (byte)VectorUnitId.Percent,
					UnitPrefixId = (byte)VectorUnitPrefixId.Base,
					AxisArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Quality
				}
			});
			vNewRels += 3;

			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Aei,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Caldonia,
				FactorAssertionId = (byte)FactorAssertionId.Fact,
				IsDefining = false,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.IsFoundIn
				},
				Identor = new FabBatchNewFactorIdentor {
					TypeId = (byte)IdentorTypeId.Key,
					Value = "abcd"
				}
			});
			vNewRels += 0;

			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Aei,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Caldonia,
				FactorAssertionId = (byte)FactorAssertionId.Fact,
				IsDefining = false,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.IsFoundIn
				},
				Director = new FabBatchNewFactorDirector {
					TypeId = (byte)DirectorTypeId.,
					Value = "abcd"
				}
			});
			vNewRels += 0;*/

			vFactorsJson = vFactors.ToJson();
			ApiCtx.SetAppUserId((long)AppGal, (long)UserZach);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		private void TestGo() {
			var func = new BatchCreateFactor(Tasks, vFactorsJson);
			vResults = func.Go(ApiCtx);
		}
		
		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void Success() {
			IsReadOnlyTest = false;
			
			TestGo();

			Assert.NotNull(vResults, "Results should not be null.");
			
			////

			foreach ( FabBatchResult res in vResults ) {
				if ( res.Error != null ) {
					Log.Debug(res.BatchId+": "+res.Error.Name+" ("+res.Error.Code+"): "+
						res.Error.Message);
					continue;
				}

				Log.Debug(res.BatchId+": "+res.ResultId);
			}

			NewNodeCount = vFactors.Count;
			NewRelCount += NewNodeCount*3+vNewRels;
		}
		

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void ErrFactorsNull() {
			vFactorsJson = null;
			TestUtil.CheckThrows<FabArgumentNullFault>(true, TestGo);
		}

	}

}