using System;
using Fabric.Api.Objects;
using Fabric.Domain;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Faults;
using ServiceStack.Text;
using Weaver.Core.Query;

namespace Fabric.Operations.Create {

	/*================================================================================================*/
	public abstract class CreateOperationBase<TDom, TApi, TCre> : ICreateOperation<TDom, TApi>
						where TDom : Vertex, new() where TApi : FabVertex where TCre : CreateFabVertex {
		
		protected CreateOperationTasks Tasks { get; private set; }
		protected TDom NewDom { get; private set; }
		protected TCre NewCre { get; private set; }
		protected IWeaverVarAlias<TDom> NewDomAlias { get; private set; }
		protected ICreateOperationBuilder Build { get; private set; }
		internal string AddVertexCommandId { get; private set; }

		private long vVertexId;
		private IOperationContext vOpCtx;
		private IDataAccess vDataAcc;
		private IDataResult vDataRes;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual TDom Execute(IOperationContext pOpCtx, ICreateOperationBuilder pBuild,
															CreateOperationTasks pTasks, string pJson) {
			return Execute(pOpCtx, pBuild, pTasks, JsonSerializer.DeserializeFromString<TCre>(pJson));
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual TDom Execute(IOperationContext pOpCtx, ICreateOperationBuilder pBuild,
															CreateOperationTasks pTasks, TCre pNewCre) {
			SetExecuteData(pOpCtx, pBuild, pTasks, pNewCre,
				pOpCtx.GetSharpflakeId<Vertex>(), pOpCtx.Data.Build(null, true));

			Build.SetDataAccess(vDataAcc);

			Build.StartSession();
			CheckAndAssemble();
			Build.CommitAndCloseSession();
			
			vDataRes = vDataAcc.Execute(GetType().Name);
			Build.PerformChecks(vDataRes);

			int cmdI = vDataRes.GetCommandIndexByCmdId(AddVertexCommandId);
			return vDataRes.ToElementAt<TDom>(cmdI, 0);
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public void SetExecuteData(IOperationContext pOpCtx, ICreateOperationBuilder pBuild,
					CreateOperationTasks pTasks, TCre pNewCre, long pVertexId, IDataAccess pAccess) {
			vOpCtx = pOpCtx;
			Build = pBuild;
			Tasks = pTasks;
			vDataAcc = pAccess;
			vVertexId = pVertexId;

			NewCre = pNewCre;
			BeforeValidation();
			NewCre.Validate();

			NewDom = ToDomain(NewCre);
			NewDom.VertexId = vVertexId;
			NewDom.Timestamp = vOpCtx.UtcNow.Ticks;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void CheckAndAssemble() {
			AfterSessionStart();
			CheckForDuplicates();
			AddVertexBase();
			AddEdges();
		}

		/*--------------------------------------------------------------------------------------------*/
		public TApi ConvertResult(TDom pDom) {
			var newApi = ToApi(pDom);

			if ( newApi == null ) {
				throw new NotSupportedException("Internal: no DomainToApi conversion for "+
					typeof(TDom).Name+".");
			}

			return newApi;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected abstract TDom ToDomain(TCre pCreateObj);

		/*--------------------------------------------------------------------------------------------*/
		protected virtual TApi ToApi(TDom pDomainObj) {
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected void BeforeValidation() {
			if ( vOpCtx.Auth.ActiveMemberId == null ) {
				throw new FabPreventedFault(FabFault.Code.AuthorizationRequired,
					"Authorization is required to create new items.");
			}

			CreateFabArtifact art = (NewCre as CreateFabArtifact);
			CreateFabFactor fac = (NewCre as CreateFabFactor);

			if ( art != null ) {
				art.CreatedByMemberId = (long)vOpCtx.Auth.ActiveMemberId;
			}

			if ( fac != null ) {
				fac.CreatedByMemberId = (long)vOpCtx.Auth.ActiveMemberId;
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void AfterSessionStart() {}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void CheckForDuplicates() {}

		/*--------------------------------------------------------------------------------------------*/
		private void AddVertexBase() {
			IWeaverVarAlias<TDom> alias;
			AddVertex(out alias);
			NewDomAlias = alias;
			AddVertexCommandId = vDataAcc.GetLatestCommandId();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void AddVertex(out IWeaverVarAlias<TDom> pAlias);

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void AddEdges();

	}

}