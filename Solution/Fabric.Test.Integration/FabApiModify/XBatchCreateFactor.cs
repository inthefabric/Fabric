using System;
using System.Collections.Generic;
using Fabric.Api.Dto.Batch;
using Fabric.Api.Modify;
using Fabric.Db.Data;
using Fabric.Db.Data.Setups;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Domain;
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

				if ( f.Descriptor_TypeId == null ) {
					continue;
				}

				var bnf = new FabBatchNewFactor();
				bnf.BatchId = batchId++;
				bnf.FactorAssertionId = f.FactorAssertionId;
				bnf.IsDefining = true;
				bnf.Note = f.Note;
				vFactors.Add(bnf);

				bnf.Descriptor = new FabBatchNewFactorDescriptor();
				bnf.Descriptor.TypeId = (byte)f.Descriptor_TypeId;

				if ( f.Director_TypeId != null ) {
					bnf.Director = new FabBatchNewFactorDirector();
					bnf.Director.TypeId = (byte)f.Director_TypeId;
					bnf.Director.PrimaryActionId = (byte)f.Director_PrimaryActionId;
					bnf.Director.RelatedActionId = (byte)f.Director_RelatedActionId;
				}

				if ( f.Eventor_TypeId != null ) {
					bnf.Eventor = new FabBatchNewFactorEventor();
					bnf.Eventor.TypeId = (byte)f.Eventor_TypeId;
					bnf.Eventor.PrecisionId = (byte)f.Eventor_PrecisionId;
					bnf.Eventor.DateTime = (long)f.Eventor_DateTime;
				}

				if ( f.Identor_TypeId != null ) {
					bnf.Identor = new FabBatchNewFactorIdentor();
					bnf.Identor.TypeId = (byte)f.Identor_TypeId;
					bnf.Identor.Value = f.Identor_Value;
				}

				if ( f.Locator_TypeId != null ) {
					bnf.Locator = new FabBatchNewFactorLocator();
					bnf.Locator.TypeId = (byte)f.Locator_TypeId;
					bnf.Locator.ValueX = (double)f.Locator_ValueX;
					bnf.Locator.ValueY = (double)f.Locator_ValueY;
					bnf.Locator.ValueZ = (double)f.Locator_ValueZ;
				}

				if ( f.Vector_TypeId != null ) {
					bnf.Vector = new FabBatchNewFactorVector();
					bnf.Vector.TypeId = (byte)f.Vector_TypeId;
					bnf.Vector.Value = (long)f.Vector_Value;
					bnf.Vector.UnitId = (byte)f.Vector_UnitId;
					bnf.Vector.UnitPrefixId = (byte)f.Vector_UnitPrefixId;
				}
				
				foreach ( IDataRel dr in ds.Rels ) {
					if ( dr.FromNode != f ) {
						continue;
					}

					Artifact a = (Artifact)dr.ToNode;

					if ( dr.Rel.RelType is UsesPrimary ) {
						bnf.PrimaryArtifactId = a.ArtifactId;
					}
					else if ( dr.Rel.RelType is UsesRelated ) {
						bnf.RelatedArtifactId = a.ArtifactId;
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
						bnf.Vector.AxisArtifactId = a.ArtifactId;
						vNewRels++;
					}
					else {
						throw new Exception("Missed edge: "+dr.Rel.RelType);
					}
				}
			}

			//Missing Descriptor
			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Art,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.App_FabSys,
				FactorAssertionId = (byte)FactorAssertionId.Guess,
				IsDefining = false
			});

			//Missing RelatedArtifactId
			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Art,
				FactorAssertionId = (byte)FactorAssertionId.Guess,
				IsDefining = false,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.IsInterestedIn
				}
			});

			//PrimaryArtifactId does not exist
			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = 9999999,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Art,
				FactorAssertionId = (byte)FactorAssertionId.Guess,
				IsDefining = false,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.IsInterestedIn
				}
			});

			//Descriptor.TypeRefineId does not exist
			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Aei,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Art,
				FactorAssertionId = (byte)FactorAssertionId.Guess,
				IsDefining = false,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.IsInterestedIn,
					TypeRefineId = 88888888
				}
			});

			//Vector.AxisArtifactId does not exist
			vFactors.Add(new FabBatchNewFactor {
				BatchId = batchId++,
				PrimaryArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Aei,
				RelatedArtifactId = (long)SetupArtifacts.ArtifactId.Thi_Caldonia,
				FactorAssertionId = (byte)FactorAssertionId.Fact,
				IsDefining = false,
				Descriptor = new FabBatchNewFactorDescriptor {
					TypeId = (byte)DescriptorTypeId.IsFoundIn
				},
				Vector = new FabBatchNewFactorVector {
					TypeId = (byte)VectorTypeId.FullLong,
					UnitId = (byte)VectorUnitId.Acceleration,
					UnitPrefixId = (byte)VectorUnitPrefixId.Giga,
					Value = 123,
					AxisArtifactId = 777777777
				}
			});

			//Missing Eventor.PrecisionId
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
					DateTime = new DateTime(2013, 1, 1).Ticks
				}
			});

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
			
			const int expectFails = 6;
			int fails = 0;

			foreach ( FabBatchResult res in vResults ) {
				if ( res.Error != null ) {
					fails++;
					Log.Debug(res.BatchId+": "+res.Error.Name+" ("+res.Error.Code+"): "+
						res.Error.Message);
				}
			}

			NewNodeCount = vFactors.Count-expectFails;
			NewRelCount += NewNodeCount*3+vNewRels;

			Assert.AreEqual(expectFails, fails, "Incorrect Resuls.Error count.");
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