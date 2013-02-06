using Fabric.Api.Dto;
using Fabric.Api.Dto.Traversal;
using Fabric.Api.Modify.Tasks;
using Fabric.Db.Data;
using Fabric.Domain;
using Fabric.Infrastructure.Api;
using Fabric.Infrastructure.Api.Faults;
using Fabric.Infrastructure.Weaver;
using Weaver.Interfaces;

namespace Fabric.Api.Modify {
	
	/*================================================================================================*/
	[ServiceOp(FabHome.ModUri, FabHome.Post, FabHome.ModInstancesUri, typeof(FabInstance),
		Auth=ServiceAuthType.Member)]
	public class CreateInstance : BaseModifyFunc<Instance> {

		public const string NameParam = "Name";
		public const string DisambParam = "Disamb";
		public const string NoteParam = "Note";

		[ServiceOpParam(ServiceOpParamType.Form, NameParam, typeof(Instance), IsRequired=false)]
		private readonly string vName;

		[ServiceOpParam(ServiceOpParamType.Form, DisambParam, typeof(Instance), IsRequired=false)]
		private readonly string vDisamb;

		[ServiceOpParam(ServiceOpParamType.Form, NoteParam, typeof(Instance), IsRequired=false)]
		private readonly string vNote;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CreateInstance(IModifyTasks pTasks, string pName, string pDisamb, string pNote) : 
																						base(pTasks) {
			vName = pName;
			vDisamb = pDisamb;
			vNote = pNote;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override void ValidateParams() {
			Tasks.Validator.InstanceName(vName, NameParam);
			Tasks.Validator.InstanceDisamb(vDisamb, DisambParam);
			Tasks.Validator.InstanceNote(vNote, NoteParam);

			if ( vName == null && vDisamb != null ) {
				throw new FabArgumentFault("Use of "+DisambParam+" requires a non-null "+NameParam);
			}
		}

		/*--------------------------------------------------------------------------------------------*/
		protected override Instance Execute() {
			Member m = GetContextMember();

			////

			IWeaverVarAlias<Root> rootVar;
			IWeaverVarAlias<Instance> classVar;
			IWeaverVarAlias<Member> memVar;
			IWeaverVarAlias<Artifact> artVar;

			var txb = new TxBuilder();

			txb.GetRoot(out rootVar);
			txb.GetNode(m, out memVar);
			Tasks.TxAddInstance(ApiCtx, txb, vName, vDisamb, vNote, rootVar, out classVar);
			Tasks.TxAddArtifact<Instance, InstanceHasArtifact>(
				ApiCtx, txb, ArtifactTypeId.Instance, rootVar, classVar, memVar, out artVar);

			txb.RegisterVarWithTxBuilder(classVar);
			return ApiCtx.DbSingle<Instance>("CreateInstanceTx", txb.Finish(classVar));
		}

	}

}