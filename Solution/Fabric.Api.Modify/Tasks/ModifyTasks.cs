using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Pipe;
using Weaver.Core.Query;
using Weaver.Core.Steps;
using Weaver.Core.Steps.Statements;

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
		public Url GetUrlByPath(IApiContext pApiCtx, string pPath) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Url>(x => x.FullPath, pPath.ToLower())
				.ToQuery();

			return pApiCtx.Get<Url>(q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member GetValidMemberByContext(IApiContext pApiCtx) {
			Member mem = pApiCtx.Cache.Memory.FindMember(pApiCtx.AppId, pApiCtx.UserId);

			if ( mem != null ) {
				return mem;
			}

			IWeaverStepAs<Member> memAlias;

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<User>(x => x.ArtifactId, pApiCtx.UserId)
				.DefinesMemberList.ToMember
					.As(out memAlias)
				.InAppDefines.FromApp
					.Has(x => x.ArtifactId, WeaverStepHasOp.EqualTo, pApiCtx.AppId)
				.Back(memAlias)
				.HasMemberTypeAssign.ToMemberTypeAssign
					.Has(x => x.MemberTypeId, WeaverStepHasOp.NotEqualTo, (byte)MemberTypeId.None)
					.Has(x => x.MemberTypeId, WeaverStepHasOp.NotEqualTo, (byte)MemberTypeId.Invite)
					.Has(x => x.MemberTypeId, WeaverStepHasOp.NotEqualTo, (byte)MemberTypeId.Request)
				.Back(memAlias)
				.ToQuery();

			mem = pApiCtx.Get<Member>(q);

			if ( mem != null ) {
				pApiCtx.Cache.Memory.AddMember(pApiCtx.AppId, pApiCtx.UserId, mem);
			}

			return mem;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public Factor GetActiveFactorFromMember(IApiContext pApiCtx, long pFactorId, long pMemberId) {
			IWeaverStepAs<Factor> factorAlias;
			
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex<Factor>(x => x.FactorId, pFactorId)
					.CustomStep("scatter()") //TODO: resolve "scatter" workaround
					.HasNot(x => x.Deleted) //Factor is not deleted
					.As(out factorAlias)
				.InMemberCreates.FromMember
					.Has(x => x.MemberId, WeaverStepHasOp.EqualTo, pMemberId)
				.Back(factorAlias)
				.ToQuery();

			return pApiCtx.Get<Factor>(q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorDescriptor(IApiContext pApiCtx, Factor pFactor, byte pDescTypeId,
										long? pPrimArtRefId, long? pEdgeArtRefId, long? pDescTypeRefId) {
			var txb = new TxBuilder();

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex(pFactor)
					.SideEffect(
						new WeaverStatementSetProperty<Factor>(x => x.Descriptor_TypeId, pDescTypeId)
					)
					.Next()
				.ToQuery();

			IWeaverVarAlias<Factor> facVar;

			txb.Transaction.AddQuery(
				WeaverQuery.StoreResultAsVar("_F", q, out facVar)
			);

			////

			var facBuild = new FactorBuilder(txb, pFactor);
			facBuild.SetVertexVar(facVar);

			if ( pPrimArtRefId != null ) {
				facBuild.SetDescriptorRefinesPrimaryWithArtifact((long)pPrimArtRefId);
			}

			if ( pEdgeArtRefId != null ) {
				facBuild.SetDescriptorRefinesRelatedWithArtifact((long)pEdgeArtRefId);
			}

			if ( pDescTypeRefId != null ) {
				facBuild.SetDescriptorRefinesTypeWithArtifact((long)pDescTypeRefId);
			}

			pApiCtx.Execute(txb.Finish());
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorDirector(IApiContext pApiCtx, Factor pFactor, byte pDirTypeId,
																	byte pPrimActId, byte pEdgeActId) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex(pFactor)
				.SideEffect(
					new WeaverStatementSetProperty<Factor>(x => x.Director_TypeId, pDirTypeId),
					new WeaverStatementSetProperty<Factor>(x => x.Director_PrimaryActionId, pPrimActId),
					new WeaverStatementSetProperty<Factor>(x => x.Director_RelatedActionId, pEdgeActId)
				)
				.ToQuery();

			pApiCtx.Execute(q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorEventor(IApiContext pApiCtx, Factor pFactor, byte pEveTypeId,
																	byte pEvePrecId, long pDateTime) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex(pFactor)
				.SideEffect(
					new WeaverStatementSetProperty<Factor>(x => x.Eventor_TypeId, pEveTypeId),
					new WeaverStatementSetProperty<Factor>(x => x.Eventor_PrecisionId, pEvePrecId),
					new WeaverStatementSetProperty<Factor>(x => x.Eventor_DateTime, pDateTime)
				)
				.ToQuery();

			pApiCtx.Execute(q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorIdentor(IApiContext pApiCtx, Factor pFactor, byte pIdenTypeId,
																						string pValue) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex(pFactor)
				.SideEffect(
					new WeaverStatementSetProperty<Factor>(x => x.Identor_TypeId, pIdenTypeId),
					new WeaverStatementSetProperty<Factor>(x => x.Identor_Value, pValue)
				)
				.ToQuery();

			pApiCtx.Execute(q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorLocator(IApiContext pApiCtx, Factor pFactor, byte pLocTypeId, double pX,
																				double pY, double pZ) {
			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex(pFactor)
				.SideEffect(
					new WeaverStatementSetProperty<Factor>(x => x.Locator_TypeId, pLocTypeId),
					new WeaverStatementSetProperty<Factor>(x => x.Locator_ValueX, pX),
					new WeaverStatementSetProperty<Factor>(x => x.Locator_ValueY, pY),
					new WeaverStatementSetProperty<Factor>(x => x.Locator_ValueZ, pZ)
				)
				.ToQuery();

			pApiCtx.Execute(q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorVector(IApiContext pApiCtx, Factor pFactor, byte pVecTypeId,
								long pValue, long pAxisArtId, byte pVecUnitId, byte pVecUnitPrefId) {
			var txb = new TxBuilder();

			IWeaverQuery q = Weave.Inst.Graph
				.V.ExactIndex(pFactor)
				.SideEffect(
					new WeaverStatementSetProperty<Factor>(x => x.Vector_TypeId, pVecTypeId),
					new WeaverStatementSetProperty<Factor>(x => x.Vector_UnitId, pVecUnitId),
					new WeaverStatementSetProperty<Factor>(x => x.Vector_UnitPrefixId, pVecUnitPrefId),
					new WeaverStatementSetProperty<Factor>(x => x.Vector_Value, pValue)
				)
				.Next()
				.ToQuery();
			
			IWeaverVarAlias<Factor> facVar;

			txb.Transaction.AddQuery(
				WeaverQuery.StoreResultAsVar("_F", q, out facVar)
			);

			////

			var facBuild = new FactorBuilder(txb, pFactor);
			facBuild.SetVertexVar(facVar);
			facBuild.SetVectorUsesAxisArtifact(pAxisArtId);

			pApiCtx.Execute(txb.Finish());
		}

		/*--------------------------------------------------------------------------------------------*/
		public Factor UpdateFactor(IApiContext pApiCtx, Factor pFactor, bool pCompleted, bool pDeleted){
			Factor facPath = Weave.Inst.Graph.V.ExactIndex(pFactor);
			long now = pApiCtx.UtcNow.Ticks;

			if ( pCompleted ) {
				facPath.SideEffect(new WeaverStatementSetProperty<Factor>(x => x.Completed, now));
			}
			else if ( pDeleted ) {
				facPath.SideEffect(new WeaverStatementSetProperty<Factor>(x => x.Deleted, now));
			}

			return pApiCtx.Get<Factor>(facPath.ToQuery());
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddUrl(IApiContext pApiCtx, TxBuilder pTxBuild, string pPath, string pName,
									IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Url> pUrlVar) {
			var url = new Url();
			url.FullPath = pPath.ToLower();
			url.Name = pName;
			url.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			url.Created = pApiCtx.UtcNow.Ticks;

			var urlBuild = new UrlBuilder(pTxBuild, url);
			urlBuild.AddVertex();
			urlBuild.SetInMemberCreates(pMemVar);
			pUrlVar = urlBuild.VertexVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public long TxAddClass(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
				string pNote, IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Class> pClassVar) {
			Class c = Weave.Inst.Graph
				.V.ExactIndex<Class>(x => x.NameKey, pName.ToLower());
			IWeaverQuery q;
			
			if ( pDisamb == null ) {
				q = c.CustomStep("scatter()") //TODO: resolve "scatter" workaround
					.HasNot(x => x.Disamb)
					.ToQuery();
			}
			else {
				q = c.CustomStep(
					"filter{"+ //the "?." before "toLowerCase()" is the "safe-navigation" operator
						"it.getProperty('"+PropDbName.Class_Disamb+"')?.toLowerCase()==_P1;"+
					"}")
					.ToQuery();
				
				q.AddParam(new WeaverQueryVal(pDisamb.ToLower()));
			}
			
			IWeaverVarAlias<Class> dupVar;
			q = WeaverQuery.StoreResultAsVar("_DUP", q, out dupVar);
			pTxBuild.Transaction.AddQuery(q);
			
			IWeaverQuery idQuery = Weave.Inst.FromVar(dupVar).Property(x => x.ArtifactId).ToQuery();
			string idScript = idQuery.Script.TrimEnd(new [] {';'})+".next()";
			
			q = new WeaverQuery();
			q.FinalizeQuery("if("+dupVar.Name+"){return [-1,'Duplicate',"+idScript+"];}");
			pTxBuild.Transaction.AddQuery(q);
			
			////
			
			c = new Class();
			c.Name = pName;
			c.NameKey = pName.ToLower();
			c.Disamb = pDisamb;
			c.Note = pNote;
			c.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			c.Created = pApiCtx.UtcNow.Ticks;

			var classBuild = new ClassBuilder(pTxBuild, c);
			classBuild.AddVertex();
			classBuild.SetInMemberCreates(pMemVar);
			pClassVar = classBuild.VertexVar;
			return c.ArtifactId;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddInstance(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb,
				string pNote, IWeaverVarAlias<Member> pMemVar, out IWeaverVarAlias<Instance> pInstVar) {
			var c = new Instance();
			c.Name = pName;
			c.Disamb = pDisamb;
			c.Note = pNote;
			c.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			c.Created = pApiCtx.UtcNow.Ticks;

			var instBuild = new InstanceBuilder(pTxBuild, c);
			instBuild.AddVertex();
			instBuild.SetInMemberCreates(pMemVar);
			pInstVar = instBuild.VertexVar;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddFactor(IApiContext pApiCtx, TxBuilder pTxBuild, long pPrimArtId,long pEdgeArtId,
										byte pAssertId, bool pIsDefining, string pNote, Member pCreator,
										out IWeaverVarAlias<Factor> pFactorVar) {
			var fac = new Factor();
			fac.FactorId = pApiCtx.GetSharpflakeId<Factor>();
			fac.FactorAssertionId = pAssertId;
			fac.IsDefining = pIsDefining;
			fac.Note = pNote;
			fac.Created = pApiCtx.UtcNow.Ticks;

			var facBuild = new FactorBuilder(pTxBuild, fac);
			facBuild.AddVertex();
			facBuild.SetUsesPrimaryArtifact(pPrimArtId);
			facBuild.SetUsesRelatedArtifact(pEdgeArtId);
			facBuild.SetInMemberCreates(pCreator);
			pFactorVar = facBuild.VertexVar;
		}
		
	}

}