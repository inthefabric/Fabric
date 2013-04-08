using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Db;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Domain.Types;
using Fabric.Infrastructure.Weaver;
using Weaver;
using Weaver.Functions;
using Weaver.Interfaces;

namespace Fabric.Api.Modify.Tasks {

	/*================================================================================================*/
	public class ModifyTasks : IModifyTasks {

		public IDomainValidator Validator { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ModifyTasks() {
			Validator = new DomainValidator();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Url GetUrlByAbsoluteUrl(IApiContext pApiCtx, string pAbsoluteUrl) {
			string propName = WeaverUtil.GetPropertyName<Url>(x => x.AbsoluteUrl);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==_P1}";

			IWeaverQuery q = 
				ApiFunc.NewPathFromType<Url>()
					.CustomStep(filterStep)
				.End();

			q.AddStringParam(pAbsoluteUrl.ToLower());
			return pApiCtx.DbSingle<Url>("GetUrlByAbsoluteUrl", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member GetValidMemberByContext(IApiContext pApiCtx) {
			Member mem = pApiCtx.Cache.Memory.FindMember(pApiCtx.AppId, pApiCtx.UserId);

			if ( mem != null ) {
				return mem;
			}

			IWeaverFuncAs<Member> memAlias;

			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(new User { UserId = pApiCtx.UserId })
				.DefinesMemberList.ToMember
					.As(out memAlias)
				.InAppDefines.FromApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, pApiCtx.AppId)
				.Back(memAlias)
				.HasMemberTypeAssign.ToMemberTypeAssign
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (long)MemberTypeId.None)
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (long)MemberTypeId.Invite)
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (long)MemberTypeId.Request)
				.Back(memAlias)
				.End();

			mem = pApiCtx.DbSingle<Member>("GetValidMemberByContext", q);

			if ( mem == null ) {
				pApiCtx.Cache.Memory.RemoveMember(pApiCtx.AppId, pApiCtx.UserId); //TEST: RemoveMember
			}
			else {
				pApiCtx.Cache.Memory.AddMember(pApiCtx.AppId, pApiCtx.UserId, mem);
			}

			return mem;
		}

		/*--------------------------------------------------------------------------------------------*/
		//TEST: ModifyTasks.GetClassByNameDisamb cache usage
		public Class GetClassByNameDisamb(IApiContext pApiCtx, string pName, string pDisamb) {
			long? classId = pApiCtx.Cache.UniqueClasses.FindClassId(pName, pDisamb);
			
			if ( classId == null ) {
				return null;
			}

			var c = new Class();
			c.ClassId = (long)classId;
			c.Name = pName;
			c.Disamb = pDisamb;
			return c;
		}

		/*--------------------------------------------------------------------------------------------*/
		public Artifact GetArtifact(IApiContext pApiCtx, long pArtifactId) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(new Artifact { ArtifactId = pArtifactId }).End();
			return pApiCtx.DbSingle<Artifact>("GetArtifact", q);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Factor GetActiveFactorFromMember(IApiContext pApiCtx, long pFactorId, long pMemberId) {
			IWeaverFuncAs<Factor> factorAlias;

			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(new Factor { FactorId = pFactorId })
					.Has(x => x.Deleted, WeaverFuncHasOp.EqualTo, null) //Factor is not deleted
					.As(out factorAlias)
				.InMemberCreates.FromMember
					.Has(x => x.MemberId, WeaverFuncHasOp.EqualTo, pMemberId)
				.Back(factorAlias)
				.End();

			return pApiCtx.DbSingle<Factor>("GetActiveFactorFromMember", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public bool FactorHasDescriptor(IApiContext pApiCtx, Factor pFactor) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UsesDescriptor.End();
			return (pApiCtx.DbData("FactorHasDescriptor", q).GetResultCount() > 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool FactorHasDirector(IApiContext pApiCtx, Factor pFactor) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UsesDirector.End();
			return (pApiCtx.DbData("FactorHasDirector", q).GetResultCount() > 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool FactorHasEventor(IApiContext pApiCtx, Factor pFactor) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UsesEventor.End();
			return (pApiCtx.DbData("FactorHasEventor", q).GetResultCount() > 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool FactorHasIdentor(IApiContext pApiCtx, Factor pFactor) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UsesIdentor.End();
			return (pApiCtx.DbData("FactorHasIdentor", q).GetResultCount() > 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool FactorHasLocator(IApiContext pApiCtx, Factor pFactor) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UsesLocator.End();
			return (pApiCtx.DbData("FactorHasLocator", q).GetResultCount() > 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public bool FactorHasVector(IApiContext pApiCtx, Factor pFactor) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UsesVector.End();
			return (pApiCtx.DbData("FactorHasVector", q).GetResultCount() > 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Descriptor GetDescriptorMatch(IApiContext pApiCtx, byte pDescTypeId,
										long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId) {
			IWeaverVarAlias matches;
			IWeaverVarAlias nulls;
			IWeaverFuncAs<Descriptor> descMatchAlias;
			IWeaverFuncAs<Descriptor> descNullAlias;

			IWeaverTransaction tx = new WeaverTransaction();
			IWeaverQuery q;

			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out matches)
			);

			tx.AddQuery(
				WeaverTasks.InitListVar(tx, out nulls)
			);

			////

			Descriptor descPath =
				ApiFunc.NewPathFromType<Descriptor>()
					.As(out descMatchAlias)
					.Has(x => x.DescriptorTypeId, WeaverFuncHasOp.EqualTo, pDescTypeId)
				.Back(descMatchAlias);

			if ( pPrimArtRefId != null ) {
				descPath = descPath
					.RefinesPrimaryWithArtifact.ToArtifact
						.Has(x => x.ArtifactId, WeaverFuncHasOp.EqualTo, (long)pPrimArtRefId)
					.Back(descMatchAlias);
			}

			if ( pRelArtRefId != null ) {
				descPath = descPath
					.RefinesRelatedWithArtifact.ToArtifact
						.Has(x => x.ArtifactId, WeaverFuncHasOp.EqualTo, (long)pRelArtRefId)
					.Back(descMatchAlias);
			}

			if ( pDescTypeRefId != null ) {
				descPath = descPath
					.RefinesTypeWithArtifact.ToArtifact
						.Has(x => x.ArtifactId, WeaverFuncHasOp.EqualTo, (long)pDescTypeRefId)
					.Back(descMatchAlias);
			}

			tx.AddQuery(
				descPath
					.Dedup()
					.Aggregate(matches)
					.Iterate()
				.End()
			);

			////

			if ( pPrimArtRefId == null ) {
				q = ApiFunc.NewPathFromType<Descriptor>()
						.Retain(matches)
						.As(out descNullAlias)
					.RefinesPrimaryWithArtifact
					.Back(descNullAlias)
						.Aggregate(nulls)
						.Iterate()
					.End();

				tx.AddQuery(q);
			}

			if ( pRelArtRefId == null ) {
				q = ApiFunc.NewPathFromType<Descriptor>()
						.Retain(matches)
						.As(out descNullAlias)
					.RefinesRelatedWithArtifact
					.Back(descNullAlias)
						.Aggregate(nulls)
						.Iterate()
					.End();

				tx.AddQuery(q);
			}

			if ( pDescTypeRefId == null ) {
				q = ApiFunc.NewPathFromType<Descriptor>()
						.Retain(matches)
						.As(out descNullAlias)
					.RefinesTypeWithArtifact
					.Back(descNullAlias)
						.Aggregate(nulls)
						.Iterate()
					.End();

				tx.AddQuery(q);
			}

			////

			tx.AddQuery(
				ApiFunc.NewPathFromType<Descriptor>()
					.Retain(matches)
					.Except(nulls)
				.End()
			);

			tx.Finish();
			return pApiCtx.DbSingle<Descriptor>("GetDescriptorMatch", tx);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Director GetDirectorMatch(IApiContext pApiCtx, byte pDirTypeId, byte pPrimActId,
																					byte pRelActId) {
			IWeaverQuery q = 
				ApiFunc.NewPathFromType<Director>()
					.Has(x => x.DirectorTypeId, WeaverFuncHasOp.EqualTo, pDirTypeId)
					.Has(x => x.PrimaryDirectorActionId, WeaverFuncHasOp.EqualTo, pPrimActId)
					.Has(x => x.RelatedDirectorActionId, WeaverFuncHasOp.EqualTo, pRelActId)
				.End();

			return pApiCtx.DbSingle<Director>("GetDirectorMatch", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Eventor GetEventorMatch(IApiContext pApiCtx, byte pEveTypeId, byte pEvePrecId,
																					long pDateTime) {
			IWeaverQuery q = 
				ApiFunc.NewPathFromType<Eventor>()
					.Has(x => x.DateTime, WeaverFuncHasOp.EqualTo, pDateTime)
					.Has(x => x.EventorTypeId, WeaverFuncHasOp.EqualTo, pEveTypeId)
					.Has(x => x.EventorPrecisionId, WeaverFuncHasOp.EqualTo, pEvePrecId)
				.End();
			
			return pApiCtx.DbSingle<Eventor>("GetEventorMatch", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public Identor GetIdentorMatch(IApiContext pApiCtx, byte pIdenTypeId, string pValue) {
			IWeaverQuery q = 
				ApiFunc.NewPathFromType<Identor>()
					.Has(x => x.Value, WeaverFuncHasOp.EqualTo, pValue)
					.Has(x => x.IdentorTypeId, WeaverFuncHasOp.EqualTo, pIdenTypeId)
				.End();
			
			return pApiCtx.DbSingle<Identor>("GetIdentorMatch", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public Locator GetLocatorMatch(IApiContext pApiCtx, byte pLocTypeId, double pX, double pY,
																						double pZ) {
			IWeaverQuery q = 
				ApiFunc.NewPathFromType<Locator>()
						.Has(x => x.ValueX, WeaverFuncHasOp.EqualTo, pX)
						.Has(x => x.ValueY, WeaverFuncHasOp.EqualTo, pY)
						.Has(x => x.ValueZ, WeaverFuncHasOp.EqualTo, pZ)
						.Has(x => x.LocatorTypeId, WeaverFuncHasOp.EqualTo, pLocTypeId)
					.End();
			
			return pApiCtx.DbSingle<Locator>("GetLocatorMatch", q);
		}
		
		
		/*--------------------------------------------------------------------------------------------*/
		public Vector GetVectorMatch(IApiContext pApiCtx, byte pVecTypeId, long pValue, long pAxisArtId,
																byte pVecUnitId, byte pVecUnitPrefId) {
			IWeaverFuncAs<Vector> locAlias;
			
			IWeaverQuery q = 
				ApiFunc.NewPathFromType<Vector>()
						.Has(x => x.VectorTypeId, WeaverFuncHasOp.EqualTo, pVecTypeId)
						.Has(x => x.VectorUnitId, WeaverFuncHasOp.EqualTo, pVecUnitId)
						.Has(x => x.VectorUnitPrefixId, WeaverFuncHasOp.EqualTo, pVecUnitPrefId)
						.Has(x => x.Value, WeaverFuncHasOp.EqualTo, pValue)
						.As(out locAlias)
					.UsesAxisArtifact.ToArtifact
						.Has(x => x.ArtifactId, WeaverFuncHasOp.EqualTo, pAxisArtId)
					.Back(locAlias)
					.End();
			
			return pApiCtx.DbSingle<Vector>("GetVectorMatch", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void AttachExistingElement<T, TRel>(IApiContext pApiCtx, Factor pFactor, T pElement)
							where T : class, INode, new() where TRel : IWeaverRel<Factor, T>, new() {
			IWeaverVarAlias<Factor> factorVar;
			IWeaverVarAlias<T> elemVar;

			var txb = new TxBuilder();
			txb.GetNode(pFactor, out factorVar);
			txb.GetNode(pElement, out elemVar);
			txb.AddRel<TRel>(factorVar, elemVar);
			
			pApiCtx.DbData("AttachExisting"+typeof(T).Name, txb.Finish());
		}

		/*--------------------------------------------------------------------------------------------*/
		public Factor UpdateFactor(IApiContext pApiCtx, Factor pFactor, bool pCompleted, bool pDeleted){
			var f = new Factor();
			var updates = new WeaverUpdates<Factor>();

			if ( pCompleted ) {
				f.Completed = pApiCtx.UtcNow.Ticks;
				updates.AddUpdate(f, x => x.Completed);
			}
			else if ( pDeleted ) {
				f.Deleted = pApiCtx.UtcNow.Ticks;
				updates.AddUpdate(f, x => x.Deleted);
			}

			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor)
				.UpdateEach(updates)
				.End();

			return pApiCtx.DbSingle<Factor>("UpdateFactor", q);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddUrl(IApiContext pApiCtx, TxBuilder pTxBuild, string pAbsoluteUrl, string pName,
									IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Url> pUrlVar) {
			var url = new Url();
			url.UrlId = pApiCtx.GetSharpflakeId<Url>();
			url.AbsoluteUrl = pAbsoluteUrl;
			url.Name = pName;
			url.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			url.Created = pApiCtx.UtcNow.Ticks;

			var urlBuild = new UrlBuilder(pTxBuild, url);
			urlBuild.AddNode();
			urlBuild.SetInMemberCreates(pMemVar);
			pUrlVar = urlBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public long TxAddClass(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
				string pNote, IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Class> pClassVar) {
			var c = new Class();
			c.ClassId = pApiCtx.GetSharpflakeId<Class>();
			c.Name = pName;
			c.Disamb = pDisamb;
			c.Note = pNote;
			c.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			c.Created = pApiCtx.UtcNow.Ticks;

			var classBuild = new ClassBuilder(pTxBuild, c);
			classBuild.AddNode();
			classBuild.SetInMemberCreates(pMemVar);
			pClassVar = classBuild.NodeVar;
			return c.ClassId;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddInstance(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
				string pNote, IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Instance> pInstVar) {
			var c = new Instance();
			c.InstanceId = pApiCtx.GetSharpflakeId<Instance>();
			c.Name = pName;
			c.Disamb = pDisamb;
			c.Note = pNote;
			c.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			c.Created = pApiCtx.UtcNow.Ticks;

			var instBuild = new InstanceBuilder(pTxBuild, c);
			instBuild.AddNode();
			instBuild.SetInMemberCreates(pMemVar);
			pInstVar = instBuild.NodeVar;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddFactor(IApiContext pApiCtx, TxBuilder pTxBuild, long pPrimArtId,long pRelArtId,
										byte pAssertId, bool pIsDefining, string pNote, Member pCreator,
										out IWeaverVarAlias<Factor> pFactorVar) {
			var fac = new Factor();
			fac.FactorId = pApiCtx.GetSharpflakeId<Factor>();
			fac.FactorAssertionId = pAssertId;
			fac.IsDefining = pIsDefining;
			fac.Note = pNote;
			fac.Created = pApiCtx.UtcNow.Ticks;

			var facBuild = new FactorBuilder(pTxBuild, fac);
			facBuild.AddNode();
			facBuild.SetUsesPrimaryArtifact(pPrimArtId);
			facBuild.SetUsesRelatedArtifact(pRelArtId);
			facBuild.SetInMemberCreates(pCreator);
			pFactorVar = facBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddDescriptor(IApiContext pApiCtx, TxBuilder pTxBuild, byte pDescTypeId,
						long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId, Factor pFactor, 
						out IWeaverVarAlias<Descriptor> pDescVar) {
			var desc = new Descriptor();
			desc.DescriptorId = pApiCtx.GetSharpflakeId<Descriptor>();
			desc.DescriptorTypeId = pDescTypeId;

			var descBuild = new DescriptorBuilder(pTxBuild, desc);
			descBuild.AddNode();
			descBuild.AddToInFactorListUses(pFactor);

			if ( pPrimArtRefId != null ) {
				descBuild.SetRefinesPrimaryWithArtifact((long)pPrimArtRefId);
			}

			if ( pRelArtRefId != null ) {
				descBuild.SetRefinesRelatedWithArtifact((long)pRelArtRefId);
			}

			if ( pDescTypeRefId != null ) {
				descBuild.SetRefinesTypeWithArtifact((long)pDescTypeRefId);
			}

			pDescVar = descBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddDirector(IApiContext pApiCtx, TxBuilder pTxBuild, byte pDirTypeId,
														byte pPrimActId, byte pRelActId, Factor pFactor,
														out IWeaverVarAlias<Director> pDirVar) {
			var dir = new Director();
			dir.DirectorId = pApiCtx.GetSharpflakeId<Director>();
			dir.DirectorTypeId = pDirTypeId;
			dir.PrimaryDirectorActionId = pPrimActId;
			dir.RelatedDirectorActionId = pRelActId;

			var dirBuild = new DirectorBuilder(pTxBuild, dir);
			dirBuild.AddNode();
			dirBuild.AddToInFactorListUses(pFactor);
			pDirVar = dirBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddEventor(IApiContext pApiCtx, TxBuilder pTxBuild, byte pEveTypeId,
														byte pEvePrecId, long pDateTime, Factor pFactor,
														out IWeaverVarAlias<Eventor> pEveVar) {
			var eve = new Eventor();
			eve.EventorId = pApiCtx.GetSharpflakeId<Eventor>();
			eve.EventorTypeId = pEveTypeId;
			eve.EventorPrecisionId = pEvePrecId;
			eve.DateTime = pDateTime;
			
			var eveBuild = new EventorBuilder(pTxBuild, eve);
			eveBuild.AddNode();
			eveBuild.AddToInFactorListUses(pFactor);
			pEveVar = eveBuild.NodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddIdentor(IApiContext pApiCtx, TxBuilder pTxBuild, byte pIdenTypeId,
								string pValue, Factor pFactor, out IWeaverVarAlias<Identor> pIdenVar) {
			var iden = new Identor();
			iden.IdentorId = pApiCtx.GetSharpflakeId<Identor>();
			iden.IdentorTypeId = pIdenTypeId;
			iden.Value = pValue;
			
			var idenBuild = new IdentorBuilder(pTxBuild, iden);
			idenBuild.AddNode();
			idenBuild.AddToInFactorListUses(pFactor);
			pIdenVar = idenBuild.NodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddLocator(IApiContext pApiCtx, TxBuilder pTxBuild, byte pLocTypeId, double pX,
		                  double pY, double pZ, Factor pFactor, out IWeaverVarAlias<Locator> pLocVar) {
			var loc = new Locator();
			loc.LocatorId = pApiCtx.GetSharpflakeId<Locator>();
			loc.LocatorTypeId = pLocTypeId;
			loc.ValueX = pX;
			loc.ValueY = pY;
			loc.ValueZ = pZ;
			
			var locBuild = new LocatorBuilder(pTxBuild, loc);
			locBuild.AddNode();
			locBuild.AddToInFactorListUses(pFactor);
			pLocVar = locBuild.NodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddVector(IApiContext pApiCtx, TxBuilder pTxBuild, byte pVecTypeId, long pValue,
												 long pAxisArtId, byte pVecUnitId, byte pVecUnitPrefId, 
								                 Factor pFactor, out IWeaverVarAlias<Vector> pVecVar) {
			var vec = new Vector();
			vec.VectorId = pApiCtx.GetSharpflakeId<Vector>();
			vec.VectorTypeId = pVecTypeId;
			vec.VectorUnitId = pVecUnitId;
			vec.VectorUnitPrefixId = pVecUnitPrefId;
			vec.Value = pValue;
			
			var vecBuild = new VectorBuilder(pTxBuild, vec);
			vecBuild.AddNode();
			vecBuild.AddToInFactorListUses(pFactor);
			vecBuild.SetUsesAxisArtifact(pAxisArtId);
			pVecVar = vecBuild.NodeVar;
		}
		
	}

}