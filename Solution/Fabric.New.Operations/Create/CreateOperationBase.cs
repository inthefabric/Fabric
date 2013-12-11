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
		protected ICreateOperationContext CreCtx { get; private set; }

		private IOperationContext vOpCtx { get; set; }
		private TApi vNewApi { get; set; }
		private string vCmdAddVertex { get; set; }
		private IDataAccess vDataAcc { get; set; }
		private IDataResult vDataRes { get; set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Create(IOperationContext pOpCtx, CreateOperationTasks pTasks, string pJson) {
			vOpCtx = pOpCtx;
			Tasks = pTasks;

			NewCre = JsonSerializer.DeserializeFromString<TCre>(pJson);
			BeforeValidation();
			NewCre.Validate();

			NewDom = ToDomain(NewCre);
			NewDom.VertexId = vOpCtx.GetSharpflakeId<Vertex>();
			NewDom.Timestamp = vOpCtx.UtcNow.Ticks;

			vDataAcc = vOpCtx.Data.Build(null, true);
			CreCtx = new CreateOperationContext(vDataAcc);

			////

			vDataAcc.AddSessionStart();
			CreCtx.SetupLatestCommand();
			AfterSessionStart();
			CheckForDuplicates();
			AddVertex();
			AddEdges();
			CreCtx.CommitAndCloseSession();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual TDom ToDomain(TCre pCreateObj) {
			return null;
		}

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
		private void AddVertex() {
			IWeaverVarAlias<TDom> alias;
			Tasks.AddVertex(CreCtx, NewDom, out alias);
			NewDomAlias = alias;
			vCmdAddVertex = vDataAcc.GetLatestCommandId();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void AddEdges() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TDom Execute() {
			vDataRes = vDataAcc.Execute(GetType().Name);
			CreCtx.PerformChecks(vDataRes);

			int addVertId = vDataRes.GetCommandIndexByCmdId(vCmdAddVertex);
			NewDom = vDataRes.ToElementAt<TDom>(addVertId, 0);
			vNewApi = ToApi(NewDom);
			return NewDom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public TApi GetResult() {
			if ( vNewApi == null ) {
				throw new NotSupportedException("Internal: no DomainToApi conversion for "+
					typeof(TDom).Name+".");
			}

			return vNewApi;
		}

	}

}