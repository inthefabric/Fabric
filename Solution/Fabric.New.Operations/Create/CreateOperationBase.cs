using System;
using Fabric.New.Api.Objects;
using Fabric.New.Domain;
using Fabric.New.Infrastructure.Data;
using ServiceStack.Text;
using Weaver.Core.Query;

namespace Fabric.New.Operations.Create {

	/*================================================================================================*/
	public abstract class CreateOperationBase<TDom, TApi, TCre> : ICreateOperation<TDom, TApi>
						where TDom : Vertex, new() where TApi : FabVertex where TCre : CreateFabVertex {
		
		protected CreateOperationTasks Tasks { get; private set; }
		protected TDom NewDom { get; private set; }
		protected TCre NewCre { get; private set; }
		protected IWeaverVarAlias<TDom> NewDomAlias { get; private set; }
		protected ICreateOperationBuilder Build { get; private set; }

		private IOperationContext vOpCtx { get; set; }
		private string vCmdAddVertex { get; set; }
		private IDataAccess vDataAcc { get; set; }
		private IDataResult vDataRes { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual TDom Execute(IOperationContext pOpCtx, ICreateOperationBuilder pBuild,
															CreateOperationTasks pTasks, string pJson) {
			return Execute(pOpCtx, pBuild, pTasks, JsonSerializer.DeserializeFromString<TCre>(pJson));
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual TDom Execute(IOperationContext pOpCtx, ICreateOperationBuilder pBuild,
															CreateOperationTasks pTasks, TCre pNewCre) {
			vOpCtx = pOpCtx;
			Build = pBuild;
			Tasks = pTasks;

			NewCre = pNewCre;
			BeforeValidation();
			NewCre.Validate();

			NewDom = ToDomain(NewCre);
			NewDom.VertexId = vOpCtx.GetSharpflakeId<Vertex>();
			NewDom.Timestamp = vOpCtx.UtcNow.Ticks;

			vDataAcc = vOpCtx.Data.Build(null, true);
			Build.SetDataAccess(vDataAcc);

			////

			Build.StartSession();
			AfterSessionStart();
			CheckForDuplicates();
			AddVertexBase();
			AddEdges();
			Build.CommitAndCloseSession();

			////
			
			vDataRes = vDataAcc.Execute(GetType().Name);
			Build.PerformChecks(vDataRes);

			int addVertId = vDataRes.GetCommandIndexByCmdId(vCmdAddVertex);
			return vDataRes.ToElementAt<TDom>(addVertId, 0);
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
		private void BeforeValidation() {
			CreateFabArtifact art = (NewCre as CreateFabArtifact);
			CreateFabFactor fac = (NewCre as CreateFabFactor);

			if ( art != null ) {
				art.CreatedByMemberId = (vOpCtx.Auth.ActiveMemberId ?? 0);
			}

			if ( fac != null ) {
				fac.CreatedByMemberId = (vOpCtx.Auth.ActiveMemberId ?? 0);
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
			vCmdAddVertex = vDataAcc.GetLatestCommandId();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void AddVertex(out IWeaverVarAlias<TDom> pAlias);

		/*--------------------------------------------------------------------------------------------*/
		protected abstract void AddEdges();

	}

}