using Fabric.Api.Modify.Validators;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Api;
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
		public User GetUserByName(IApiContext pApiCtx, string pName) {
			string propName = WeaverUtil.GetPropertyName<User>(x => x.Name);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==NAME}";

			IWeaverQuery q = 
				ApiFunc.NewPathFromRoot()
				.ContainsUserList.ToUser
					.CustomStep(filterStep)
				.End();

			q.AddParam("NAME", new WeaverQueryVal(pName.ToLower(), false));
			return pApiCtx.DbSingle<User>("GetUserByName", q);

		}

		/*--------------------------------------------------------------------------------------------*/
		public User GetUser(IApiContext pApiCtx, long pUserId) {
			IWeaverQuery q = ApiFunc.NewPathFromIndex(new User { UserId = pUserId }).End();
			return pApiCtx.DbSingle<User>("GetUser", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public App GetAppByName(IApiContext pApiCtx, string pName) {
			string propName = WeaverUtil.GetPropertyName<App>(x => x.Name);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==NAME}";

			IWeaverQuery q = 
				ApiFunc.NewPathFromRoot()
				.ContainsAppList.ToApp
					.CustomStep(filterStep)
				.End();

			q.AddParam("NAME", new WeaverQueryVal(pName.ToLower(), false));
			return pApiCtx.DbSingle<App>("GetAppByName", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Url GetUrlByAbsoluteUrl(IApiContext pApiCtx, string pAbsoluteUrl) {
			string propName = WeaverUtil.GetPropertyName<Url>(x => x.AbsoluteUrl);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==AU}";

			IWeaverQuery q = 
				ApiFunc.NewPathFromRoot()
				.ContainsUrlList.ToUrl
					.CustomStep(filterStep)
				.End();

			q.AddParam("AU", new WeaverQueryVal(pAbsoluteUrl.ToLower(), false));
			return pApiCtx.DbSingle<Url>("GetUrlByAbsoluteUrl", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Member GetValidMemberByContext(IApiContext pApiCtx) {
			IWeaverFuncAs<Member> memAlias;

			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(new User { UserId = pApiCtx.UserId })
				.DefinesMemberList.ToMember
					.As(out memAlias)
				.InAppDefines.FromApp
					.Has(x => x.AppId, WeaverFuncHasOp.EqualTo, pApiCtx.AppId)
				.Back(memAlias)
				.HasMemberTypeAssign.ToMemberTypeAssign
				.UsesMemberType.ToMemberType
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (long)MemberTypeId.None)
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (long)MemberTypeId.Invite)
					.Has(x => x.MemberTypeId, WeaverFuncHasOp.NotEqualTo, (long)MemberTypeId.Request)
				.Back(memAlias)
				.End();

			return pApiCtx.DbSingle<Member>("GetValidMemberByContext", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Class GetClassByNameDisamb(IApiContext pApiCtx, string pName, string pDisamb) {
			string propName = WeaverUtil.GetPropertyName<Class>(x => x.Name);
			string filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==NAME}";

			Class path = 
				ApiFunc.NewPathFromRoot()
				.ContainsClassList.ToClass
					.CustomStep(filterStep);

			if ( pDisamb != null ) {
				propName = WeaverUtil.GetPropertyName<Class>(x => x.Disamb);
				filterStep = "filter{it.getProperty('"+propName+"').toLowerCase()==DISAMB}";
				path.CustomStep(filterStep);
			}

			IWeaverQuery q = path.End();
			q.AddParam("NAME", new WeaverQueryVal(pName.ToLower(), false));

			if ( pDisamb != null ) {
				q.AddParam("DISAMB", new WeaverQueryVal(pDisamb.ToLower(), false));
			}

			return pApiCtx.DbSingle<Class>("GetClassByNameDisamb", q);
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
		public LocatorType GetLocatorType(IApiContext pApiCtx, long pLocTypeId) {
			var lt = new LocatorType { LocatorTypeId = pLocTypeId };
			IWeaverQuery q = ApiFunc.NewPathFromIndex(lt).End();
			return pApiCtx.DbSingle<LocatorType>("GetLocatorType", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public VectorType GetVectorType(IApiContext pApiCtx, long pVecTypeId) {
			var vt = new VectorType { VectorTypeId = pVecTypeId };
			IWeaverQuery q = ApiFunc.NewPathFromIndex(vt).End();
			return pApiCtx.DbSingle<VectorType>("GetVectorType", q);
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
		public Descriptor GetDescriptorMatch(IApiContext pApiCtx, long pDescTypeId,
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
				ApiFunc.NewPathFromRoot()
				.ContainsDescriptorList.ToDescriptor
					.As(out descMatchAlias)
				.UsesDescriptorType.ToDescriptorType
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
				q = ApiFunc.NewPathFromRoot()
					.ContainsDescriptorList.ToDescriptor
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
				q = ApiFunc.NewPathFromRoot()
					.ContainsDescriptorList.ToDescriptor
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
				q = ApiFunc.NewPathFromRoot()
					.ContainsDescriptorList.ToDescriptor
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
				ApiFunc.NewPathFromRoot()
				.ContainsDescriptorList.ToDescriptor
					.Retain(matches)
					.Except(nulls)
				.End()
			);

			tx.FinishWithoutStartStop();
			return pApiCtx.DbSingle<Descriptor>("GetDescriptorMatch", tx);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Director GetDirectorMatch(IApiContext pApiCtx, long pDirTypeId, long pPrimActId,
																					long pRelActId) {
			IWeaverFuncAs<Director> dirAlias;

			IWeaverQuery q = ApiFunc.NewPathFromRoot()
				.ContainsDirectorList.ToDirector
					.As(out dirAlias)
				.UsesDirectorType.ToDirectorType
					.Has(x => x.DirectorTypeId, WeaverFuncHasOp.EqualTo, pDirTypeId)
				.Back(dirAlias)
				.UsesPrimaryDirectorAction.ToDirectorAction
					.Has(x => x.DirectorActionId, WeaverFuncHasOp.EqualTo, pPrimActId)
				.Back(dirAlias)
				.UsesRelatedDirectorAction.ToDirectorAction
					.Has(x => x.DirectorActionId, WeaverFuncHasOp.EqualTo, pRelActId)
				.Back(dirAlias)
				.End();

			return pApiCtx.DbSingle<Director>("GetDirectorMatch", q);
		}

		/*--------------------------------------------------------------------------------------------*/
		public Eventor GetEventorMatch(IApiContext pApiCtx, long pEveTypeId, long pEvePrecId,
																					long pDateTime) {
			IWeaverFuncAs<Eventor> eveAlias;
			
			IWeaverQuery q = ApiFunc.NewPathFromRoot()
				.ContainsEventorList.ToEventor
						.Has(x => x.DateTime, WeaverFuncHasOp.EqualTo, pDateTime)
						.As(out eveAlias)
					.UsesEventorType.ToEventorType
						.Has(x => x.EventorTypeId, WeaverFuncHasOp.EqualTo, pEveTypeId)
					.Back(eveAlias)
					.UsesEventorPrecision.ToEventorPrecision
						.Has(x => x.EventorPrecisionId, WeaverFuncHasOp.EqualTo, pEvePrecId)
					.Back(eveAlias)
					.End();
			
			return pApiCtx.DbSingle<Eventor>("GetEventorMatch", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public Identor GetIdentorMatch(IApiContext pApiCtx, long pIdenTypeId, string pValue) {
			IWeaverFuncAs<Identor> idenAlias;
			
			IWeaverQuery q = ApiFunc.NewPathFromRoot()
				.ContainsIdentorList.ToIdentor
					.Has(x => x.Value, WeaverFuncHasOp.EqualTo, pValue)
					.As(out idenAlias)
					.UsesIdentorType.ToIdentorType
					.Has(x => x.IdentorTypeId, WeaverFuncHasOp.EqualTo, pIdenTypeId)
					.Back(idenAlias)
					.End();
			
			return pApiCtx.DbSingle<Identor>("GetIdentorMatch", q);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public Locator GetLocatorMatch(IApiContext pApiCtx, long pLocTypeId, double pX, double pY,
																						double pZ) {
			IWeaverFuncAs<Locator> locAlias;
			
			IWeaverQuery q = ApiFunc.NewPathFromRoot()
				.ContainsLocatorList.ToLocator
						.Has(x => x.ValueX, WeaverFuncHasOp.EqualTo, pX)
						.Has(x => x.ValueY, WeaverFuncHasOp.EqualTo, pY)
						.Has(x => x.ValueZ, WeaverFuncHasOp.EqualTo, pZ)
						.As(out locAlias)
					.UsesLocatorType.ToLocatorType
						.Has(x => x.LocatorTypeId, WeaverFuncHasOp.EqualTo, pLocTypeId)
					.Back(locAlias)
					.End();
			
			return pApiCtx.DbSingle<Locator>("GetLocatorMatch", q);
		}
		
		
		/*--------------------------------------------------------------------------------------------*/
		public Vector GetVectorMatch(IApiContext pApiCtx, long pVecTypeId, long pValue, long pAxisArtId, 
		                      									long pVecUnitId, long pVecUnitPrefId) {
			IWeaverFuncAs<Vector> locAlias;
			
			IWeaverQuery q = ApiFunc.NewPathFromRoot()
				.ContainsVectorList.ToVector
						.Has(x => x.Value, WeaverFuncHasOp.EqualTo, pValue)
						.As(out locAlias)
					.UsesVectorType.ToVectorType
						.Has(x => x.VectorTypeId, WeaverFuncHasOp.EqualTo, pVecTypeId)
					.Back(locAlias)
					.UsesAxisArtifact.ToArtifact
						.Has(x => x.ArtifactId, WeaverFuncHasOp.EqualTo, pAxisArtId)
					.Back(locAlias)
					.UsesVectorUnit.ToVectorUnit
						.Has(x => x.VectorUnitId, WeaverFuncHasOp.EqualTo, pVecUnitId)
					.Back(locAlias)
					.UsesVectorUnitPrefix.ToVectorUnitPrefix
						.Has(x => x.VectorUnitPrefixId, WeaverFuncHasOp.EqualTo, pVecUnitPrefId)
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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddEmail(IApiContext pApiCtx, TxBuilder pTxBuild, string pAddress, 
								IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Email> pEmailVar) {
			var email = new Email();
			email.EmailId = pApiCtx.GetSharpflakeId<Email>();
			email.Address = pAddress;
			email.Code = pApiCtx.Code32;
			email.Created = pApiCtx.UtcNow.Ticks;
			email.Verified = null;

			var emailBuild = new EmailBuilder(pTxBuild, email);
			emailBuild.AddNode(pRootVar);
			pEmailVar = emailBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddUser(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pPassword,
									IWeaverVarAlias<Root> pRootVar, IWeaverVarAlias<Email> pEmailVar, 
									out IWeaverVarAlias<User> pUserVar) {
			var user = new User();
			user.UserId = pApiCtx.GetSharpflakeId<User>();
			user.Name = pName;
			user.Password = FabricUtil.HashPassword(pPassword);

			var userBuild = new UserBuilder(pTxBuild, user);
			userBuild.AddNode(pRootVar);
			userBuild.SetUsesEmail(pEmailVar);
			pUserVar = userBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddMember(IApiContext pApiCtx, TxBuilder pTxBuild, IWeaverVarAlias<Root> pRootVar,
							IWeaverVarAlias<User> pUserVar, out IWeaverVarAlias<Member> pMemVar) {
			var mem = new Member();
			mem.MemberId = pApiCtx.GetSharpflakeId<Member>();

			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = pApiCtx.GetSharpflakeId<MemberTypeAssign>();

			var memBuild = new MemberBuilder(pTxBuild, mem);
			memBuild.AddNode(pRootVar);
			memBuild.SetInUserDefines(pUserVar);
			memBuild.SetInAppDefines((long)AppId.FabricSystem);
			pMemVar = memBuild.NodeVar;

			var mtaBuild = new MemberTypeAssignBuilder(pTxBuild, mta);
			mtaBuild.AddNode(pRootVar);
			mtaBuild.SetInMemberCreates((long)MemberId.FabFabData);
			mtaBuild.SetInMemberHas(memBuild.NodeVar);
			mtaBuild.SetUsesMemberType((long)MemberTypeId.Member);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddArtifact<TNode, TNodeHasArt>(IApiContext pApiCtx, TxBuilder pTxBuild, 
							ArtifactTypeId pArtTypeId, IWeaverVarAlias<Root> pRootVar,
							IWeaverVarAlias<TNode> pNodeVar, IWeaverVarAlias<Member> pMemVar, 
							out IWeaverVarAlias<Artifact> pArtVar)
							where TNode : INode where TNodeHasArt : IWeaverRel<TNode, Artifact>, new() {
			var art = new Artifact();
			art.ArtifactId = pApiCtx.GetSharpflakeId<Artifact>();
			art.Created = pApiCtx.UtcNow.Ticks;
			art.IsPrivate = false;

			var artBuild = new ArtifactBuilder(pTxBuild, art);
			artBuild.AddNode(pRootVar);
			artBuild.SetUsesArtifactType((long)pArtTypeId);
			artBuild.SetInMemberCreates(pMemVar);
			pArtVar = artBuild.NodeVar;

			pTxBuild.AddRel<TNodeHasArt>(pNodeVar, pArtVar);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddApp(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, 
					IWeaverVarAlias<Root> pRootVar, long pUserId, out IWeaverVarAlias<App> pAppVar) {
			var emailVar = new WeaverVarAlias<Email>(pTxBuild.Transaction);

			IWeaverQuery q = 
				ApiFunc.NewPathFromIndex(new User { UserId = pUserId })
				.UsesEmail.ToEmail
					.ToNodeVar(emailVar)
				.End();

			pTxBuild.Transaction.AddQuery(q);
			pTxBuild.RegisterVarWithTxBuilder(emailVar);

			var app = new App();
			app.AppId = pApiCtx.GetSharpflakeId<App>();
			app.Name = pName;
			app.Secret = pApiCtx.Code32;

			var appBuild = new AppBuilder(pTxBuild, app);
			appBuild.AddNode(pRootVar);
			appBuild.SetUsesEmail(emailVar);
			pAppVar = appBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddDataProvMember(IApiContext pApiCtx, TxBuilder pTxBuild,
							IWeaverVarAlias<Root> pRootVar, IWeaverVarAlias<App> pAppVar, long pUserId,
							out IWeaverVarAlias<Member> pMemVar) {
			var mem = new Member();
			mem.MemberId = pApiCtx.GetSharpflakeId<Member>();

			var mta = new MemberTypeAssign();
			mta.MemberTypeAssignId = pApiCtx.GetSharpflakeId<MemberTypeAssign>();

			var memBuild = new MemberBuilder(pTxBuild, mem);
			memBuild.AddNode(pRootVar);
			memBuild.SetInUserDefines(pUserId);
			memBuild.SetInAppDefines(pAppVar);
			pMemVar = memBuild.NodeVar;

			var mtaBuild = new MemberTypeAssignBuilder(pTxBuild, mta);
			mtaBuild.AddNode(pRootVar);
			mtaBuild.SetInMemberCreates((long)MemberId.FabFabData);
			mtaBuild.SetInMemberHas(memBuild.NodeVar);
			mtaBuild.SetUsesMemberType((long)MemberTypeId.DataProvider);
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddUrl(IApiContext pApiCtx, TxBuilder pTxBuild, string pAbsoluteUrl, string pName,
									IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Url> pUrlVar) {
			var url = new Url();
			url.UrlId = pApiCtx.GetSharpflakeId<Url>();
			url.AbsoluteUrl = pAbsoluteUrl;
			url.Name = pName;

			var urlBuild = new UrlBuilder(pTxBuild, url);
			urlBuild.AddNode(pRootVar);
			pUrlVar = urlBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddClass(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb, 
				string pNote, IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Class> pClassVar) {
			var c = new Class();
			c.ClassId = pApiCtx.GetSharpflakeId<Class>();
			c.Name = pName;
			c.Disamb = pDisamb;
			c.Note = pNote;

			var classBuild = new ClassBuilder(pTxBuild, c);
			classBuild.AddNode(pRootVar);
			pClassVar = classBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddInstance(IApiContext pApiCtx, TxBuilder pTxBuild, string pName, string pDisamb, 
				string pNote, IWeaverVarAlias<Root> pRootVar, out IWeaverVarAlias<Instance> pInstVar) {
			var c = new Instance();
			c.InstanceId = pApiCtx.GetSharpflakeId<Instance>();
			c.Name = pName;
			c.Disamb = pDisamb;
			c.Note = pNote;

			var classBuild = new InstanceBuilder(pTxBuild, c);
			classBuild.AddNode(pRootVar);
			pInstVar = classBuild.NodeVar;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddFactor(IApiContext pApiCtx, TxBuilder pTxBuild, long pPrimArtId,long pRelArtId,
										long pAssertId, bool pIsDefining, string pNote, Member pCreator,
										out IWeaverVarAlias<Factor> pFactorVar) {
			var fac = new Factor();
			fac.FactorId = pApiCtx.GetSharpflakeId<Factor>();
			fac.IsDefining = pIsDefining;
			fac.Note = pNote;
			fac.Created = pApiCtx.UtcNow.Ticks;

			var facBuild = new FactorBuilder(pTxBuild, fac);
			facBuild.AddNode();
			facBuild.SetUsesPrimaryArtifact(pPrimArtId);
			facBuild.SetUsesRelatedArtifact(pRelArtId);
			facBuild.SetUsesFactorAssertion(pAssertId);
			facBuild.SetInMemberCreates(pCreator);
			pFactorVar = facBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddDescriptor(IApiContext pApiCtx, TxBuilder pTxBuild, long pDescTypeId,
						long? pPrimArtRefId, long? pRelArtRefId, long? pDescTypeRefId, Factor pFactor, 
						out IWeaverVarAlias<Descriptor> pDescVar) {
			var desc = new Descriptor();
			desc.DescriptorId = pApiCtx.GetSharpflakeId<Descriptor>();

			var descBuild = new DescriptorBuilder(pTxBuild, desc);
			descBuild.AddNode();
			descBuild.AddToInFactorListUses(pFactor);
			descBuild.SetUsesDescriptorType(pDescTypeId);

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
		public void TxAddDirector(IApiContext pApiCtx, TxBuilder pTxBuild, long pDirTypeId,
														long pPrimActId, long pRelActId, Factor pFactor,
														out IWeaverVarAlias<Director> pDirVar) {
			var dir = new Director();
			dir.DirectorId = pApiCtx.GetSharpflakeId<Director>();

			var dirBuild = new DirectorBuilder(pTxBuild, dir);
			dirBuild.AddNode();
			dirBuild.AddToInFactorListUses(pFactor);
			dirBuild.SetUsesDirectorType(pDirTypeId);
			dirBuild.SetUsesPrimaryDirectorAction(pPrimActId);
			dirBuild.SetUsesRelatedDirectorAction(pRelActId);
			pDirVar = dirBuild.NodeVar;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void TxAddEventor(IApiContext pApiCtx, TxBuilder pTxBuild, long pEveTypeId,
														long pEvePrecId, long pDateTime, Factor pFactor,
														out IWeaverVarAlias<Eventor> pEveVar) {
			var eve = new Eventor();
			eve.EventorId = pApiCtx.GetSharpflakeId<Eventor>();
			eve.DateTime = pDateTime;
			
			var eveBuild = new EventorBuilder(pTxBuild, eve);
			eveBuild.AddNode();
			eveBuild.AddToInFactorListUses(pFactor);
			eveBuild.SetUsesEventorType(pEveTypeId);
			eveBuild.SetUsesEventorPrecision(pEvePrecId);
			pEveVar = eveBuild.NodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddIdentor(IApiContext pApiCtx, TxBuilder pTxBuild, long pIdenTypeId,
								string pValue, Factor pFactor, out IWeaverVarAlias<Identor> pIdenVar) {
			var iden = new Identor();
			iden.IdentorId = pApiCtx.GetSharpflakeId<Identor>();
			iden.Value = pValue;
			
			var idenBuild = new IdentorBuilder(pTxBuild, iden);
			idenBuild.AddNode();
			idenBuild.AddToInFactorListUses(pFactor);
			idenBuild.SetUsesIdentorType(pIdenTypeId);
			pIdenVar = idenBuild.NodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddLocator(IApiContext pApiCtx, TxBuilder pTxBuild, long pLocTypeId, double pX,
		                  double pY, double pZ, Factor pFactor, out IWeaverVarAlias<Locator> pLocVar) {
			var loc = new Locator();
			loc.LocatorId = pApiCtx.GetSharpflakeId<Locator>();
			loc.ValueX = pX;
			loc.ValueY = pY;
			loc.ValueZ = pZ;
			
			var locBuild = new LocatorBuilder(pTxBuild, loc);
			locBuild.AddNode();
			locBuild.AddToInFactorListUses(pFactor);
			locBuild.SetUsesLocatorType(pLocTypeId);
			pLocVar = locBuild.NodeVar;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void TxAddVector(IApiContext pApiCtx, TxBuilder pTxBuild, long pVecTypeId, long pValue, 
								                 long pAxisArtId, long pVecUnitId, long pVecUnitPrefId, 
								                 Factor pFactor, out IWeaverVarAlias<Vector> pVecVar) {
			var vec = new Vector();
			vec.VectorId = pApiCtx.GetSharpflakeId<Vector>();
			vec.Value = pValue;
			
			var vecBuild = new VectorBuilder(pTxBuild, vec);
			vecBuild.AddNode();
			vecBuild.AddToInFactorListUses(pFactor);
			vecBuild.SetUsesVectorType(pVecTypeId);
			vecBuild.SetUsesAxisArtifact(pAxisArtId);
			vecBuild.SetUsesVectorUnit(pVecUnitId);
			vecBuild.SetUsesVectorUnitPrefix(pVecUnitPrefId);
			pVecVar = vecBuild.NodeVar;
		}
		
	}

}