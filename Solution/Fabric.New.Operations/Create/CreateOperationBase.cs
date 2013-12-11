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

		protected IOperationContext OpCtx { get; private set; }
		protected CreateOperationTasks Tasks { get; private set; }
		protected TDom NewDom { get; private set; }
		protected TApi NewApi { get; private set; }
		protected TCre NewCre { get; private set; }
		protected IWeaverVarAlias<TDom> NewDomAlias { get; private set; }
		protected string CmdAddVertex { get; private set; }

		protected IDataAccess DataAcc { get; private set; }
		protected IDataResult DataRes { get; private set; }
		protected ICreateOperationContext CreCtx { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public void Create(IOperationContext pOpCtx, /*CreateOperationTasks pTasks,*/ string pJson) {
			OpCtx = pOpCtx;
			Tasks = null; //pTasks;

			NewCre = JsonSerializer.DeserializeFromString<TCre>(pJson);
			BeforeValidation();
			NewCre.Validate();

			NewDom = ToDomain(NewCre);
			NewDom.VertexId = OpCtx.GetSharpflakeId<Vertex>();
			NewDom.Timestamp = OpCtx.UtcNow.Ticks;

			DataAcc = OpCtx.Data.Build(null, true);
			CreCtx = new CreateOperationContext(DataAcc);

			////

			DataAcc.AddSessionStart();
			CreCtx.SetupLatestCommand();
			AfterSessionStart();

			VerifyCustom();
			CheckForDuplicates();

			Tasks.AddVertex(CreCtx, NewDom);
			CmdAddVertex = DataAcc.GetLatestCommandId();
			
			AddEdges();
			
			CreCtx.CommitAndCloseSession();
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void VerifyCustom() {}

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
		protected virtual void CheckForDuplicates() {}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void AddEdges() {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public TDom Execute() {
			DataRes = DataAcc.Execute(GetType().Name);

			foreach ( DataResultCheck check in CreCtx.GetChecks() ) {
				check.PerformCheck(DataRes);
			}

			int addVertId = DataRes.GetCommandIndexByCmdId(CmdAddVertex);
			NewDom = DataRes.ToElementAt<TDom>(addVertId, 0);
			NewApi = ToApi(NewDom);
			return NewDom;
		}

		/*--------------------------------------------------------------------------------------------*/
		public TApi GetResult() {
			if ( NewApi == null ) {
				throw new NotSupportedException("Internal: no DomainToApi conversion for "+
					typeof(TDom).Name+".");
			}

			return NewApi;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void BeforeValidation() {
			CreateFabArtifact art = (NewCre as CreateFabArtifact);
			CreateFabFactor fac = (NewCre as CreateFabFactor);

			if ( art != null ) {
				art.CreatedByMemberId = (OpCtx.Auth.ActiveMemberId ?? 0);
			}

			if ( fac != null ) {
				fac.CreatedByMemberId = (OpCtx.Auth.ActiveMemberId ?? 0);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual void AfterSessionStart() {}

	}

}