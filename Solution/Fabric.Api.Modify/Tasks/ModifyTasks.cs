using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Domain;
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
			string propName = WeaverUtil.GetPropertyName<Url>(Weave.Inst.Config, x => x.AbsoluteUrl);
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
				ApiFunc.NewPathFromIndex(new User { ArtifactId = pApiCtx.UserId })
				.DefinesMemberList.ToMember
					.As(out memAlias)
				.InAppDefines.FromApp
					.Has(x => x.ArtifactId, WeaverFuncHasOp.EqualTo, pApiCtx.AppId)
				.Back(memAlias)
				.HasMemberTypeAssign.ToMemberTypeAssign
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (byte)MemberTypeId.None)
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (byte)MemberTypeId.Invite)
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (byte)MemberTypeId.Request)
				.Back(memAlias)
				.End();

			mem = pApiCtx.DbSingle<Member>("GetValidMemberByContext", q);

			if ( mem != null ) {
				pApiCtx.Cache.Memory.AddMember(pApiCtx.AppId, pApiCtx.UserId, mem);
			}

			return mem;
		}

		/*--------------------------------------------------------------------------------------------*/
		public Class GetClassByNameDisamb(IApiContext pApiCtx, string pName, string pDisamb) {
			long? classId = pApiCtx.Cache.UniqueClasses.FindClassId(pName, pDisamb);
			
			if ( classId == null ) {
				return null;
			}

			var c = new Class();
			c.ArtifactId = (long)classId;
			c.Name = pName;
			c.Disamb = pDisamb;
			return c;
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
		public void UpdateFactorDescriptor(IApiContext pApiCtx, Factor pFactor, byte pDescTypeId,
										long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId) {
			var txb = new TxBuilder();
			pFactor.Descriptor_TypeId = pDescTypeId;

			var up = Weave.Inst.NewUpdates<Factor>();
			up.AddUpdate(pFactor, x => x.Descriptor_TypeId);

			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(pFactor)
					.UpdateEach(up)
					.Next()
				.End();

			IWeaverVarAlias<Factor> facVar;

			txb.Transaction.AddQuery(
				Weave.Inst.StoreQueryResultAsVar(txb.Transaction, q, out facVar)
			);

			////

			var facBuild = new FactorBuilder(txb, pFactor);
			facBuild.SetNodeVar(facVar);

			if ( pPrimArtRefId != null ) {
				facBuild.SetDescriptorRefinesPrimaryWithArtifact((long)pPrimArtRefId);
			}

			if ( pRelArtRefId != null ) {
				facBuild.SetDescriptorRefinesRelatedWithArtifact((long)pRelArtRefId);
			}

			if ( pDescTypeRefId != null ) {
				facBuild.SetDescriptorRefinesTypeWithArtifact((long)pDescTypeRefId);
			}

			pApiCtx.DbData("UpdateFactorDescriptor", txb.Finish());
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorDirector(IApiContext pApiCtx, Factor pFactor, byte pDirTypeId,
																	byte pPrimActId, byte pRelActId) {
			pFactor.Director_TypeId = pDirTypeId;
			pFactor.Director_PrimaryActionId = pPrimActId;
			pFactor.Director_RelatedActionId = pRelActId;

			var up = Weave.Inst.NewUpdates<Factor>();
			up.AddUpdate(pFactor, x => x.Director_TypeId);
			up.AddUpdate(pFactor, x => x.Director_PrimaryActionId);
			up.AddUpdate(pFactor, x => x.Director_RelatedActionId);

			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UpdateEach(up).End();
			pApiCtx.DbData("UpdateFactorDirector", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorEventor(IApiContext pApiCtx, Factor pFactor, byte pEveTypeId,
																	byte pEvePrecId, long pDateTime) {
			pFactor.Eventor_TypeId = pEveTypeId;
			pFactor.Eventor_PrecisionId = pEvePrecId;
			pFactor.Eventor_DateTime = pDateTime;

			var up = Weave.Inst.NewUpdates<Factor>();
			up.AddUpdate(pFactor, x => x.Eventor_TypeId);
			up.AddUpdate(pFactor, x => x.Eventor_PrecisionId);
			up.AddUpdate(pFactor, x => x.Eventor_DateTime);

			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UpdateEach(up).End();
			pApiCtx.DbData("UpdateFactorEventor", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorIdentor(IApiContext pApiCtx, Factor pFactor, byte pIdenTypeId,
																						string pValue) {
			pFactor.Identor_TypeId = pIdenTypeId;
			pFactor.Identor_Value = pValue;

			var up = Weave.Inst.NewUpdates<Factor>();
			up.AddUpdate(pFactor, x => x.Identor_TypeId);
			up.AddUpdate(pFactor, x => x.Identor_Value);

			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UpdateEach(up).End();
			pApiCtx.DbData("UpdateFactorIdentor", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorLocator(IApiContext pApiCtx, Factor pFactor, byte pLocTypeId, double pX,
																				double pY, double pZ) {
			pFactor.Locator_TypeId = pLocTypeId;
			pFactor.Locator_ValueX = pX;
			pFactor.Locator_ValueY = pY;
			pFactor.Locator_ValueZ = pZ;

			var up = Weave.Inst.NewUpdates<Factor>();
			up.AddUpdate(pFactor, x => x.Locator_TypeId);
			up.AddUpdate(pFactor, x => x.Locator_ValueX);
			up.AddUpdate(pFactor, x => x.Locator_ValueY);
			up.AddUpdate(pFactor, x => x.Locator_ValueZ);

			IWeaverQuery q = ApiFunc.NewPathFromIndex(pFactor).UpdateEach(up).End();
			pApiCtx.DbData("UpdateFactorLocator", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void UpdateFactorVector(IApiContext pApiCtx, Factor pFactor, byte pVecTypeId,
								long pValue, long pAxisArtId, byte pVecUnitId, byte pVecUnitPrefId) {
			var txb = new TxBuilder();
			pFactor.Vector_TypeId = pVecTypeId;
			pFactor.Vector_UnitId = pVecUnitId;
			pFactor.Vector_UnitPrefixId = pVecUnitPrefId;
			pFactor.Vector_Value = pValue;

			var up = Weave.Inst.NewUpdates<Factor>();
			up.AddUpdate(pFactor, x => x.Vector_TypeId);
			up.AddUpdate(pFactor, x => x.Vector_UnitId);
			up.AddUpdate(pFactor, x => x.Vector_UnitPrefixId);
			up.AddUpdate(pFactor, x => x.Vector_Value);

			IWeaverQuery q =
				ApiFunc.NewPathFromIndex(pFactor)
					.UpdateEach(up)
					.Next()
				.End();
			
			IWeaverVarAlias<Factor> facVar;

			txb.Transaction.AddQuery(
				Weave.Inst.StoreQueryResultAsVar(txb.Transaction, q, out facVar)
			);

			////

			var facBuild = new FactorBuilder(txb, pFactor);
			facBuild.SetNodeVar(facVar);
			facBuild.SetVectorUsesAxisArtifact(pAxisArtId);

			pApiCtx.DbData("UpdateFactorVector", txb.Finish());
		}

		/*--------------------------------------------------------------------------------------------*/
		public Factor UpdateFactor(IApiContext pApiCtx, Factor pFactor, bool pCompleted, bool pDeleted){
			var f = new Factor();
			var updates = Weave.Inst.NewUpdates<Factor>();

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
		
	}

}