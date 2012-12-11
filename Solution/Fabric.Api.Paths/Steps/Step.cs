using System;
using Fabric.Api.Dto;
using Fabric.Infrastructure;

namespace Fabric.Api.Paths.Steps {
	
	/*================================================================================================*/
	public abstract class Step {

		internal static readonly string[] AvailSteps = new[] { "/Back", "/Where" };

	}

	/*================================================================================================*/
	public abstract class Step<T> : IStep where T : FabNode, new() {

		public long? TypeId { get; protected set; }
		public Path Path { get; protected set; }

		protected abstract string TypeIdName { get; }
		protected abstract bool TypeIdIsLong { get; }

		private StepData vData;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------* /
		public T NewFabDto(DbDto pDbDto) {
			T dto = new T();
			dto.Fill(pDbDto);
			return dto;
		}

		/*--------------------------------------------------------------------------------------------* /
		public T NewFabDto() {
			return new T();
		}

		/*--------------------------------------------------------------------------------------------*/
		public Type DtoType { get { return typeof(T); } }
		public virtual string[] AvailableSteps { get { return Step.AvailSteps; } }

		/*--------------------------------------------------------------------------------------------*/
		public virtual StepData Data {
			get {
				return vData;
			}
			set {
				if ( vData != null ) {
					throw new Exception("StepData is already set.");
				}

				vData = value;
			}
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public IStep GetNextStep(string pStepText) {
			var sd = new StepData(pStepText);
			IStep result = GetNextStep(sd);

			if ( result == null ) {
				throw new Exception("'"+pStepText+"' is not a valid step for "+GetType().Name+".");
			}

			result.Data = sd;
			return result;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IStep GetNextStep(StepData pData) {
			switch ( pData.Command ) {
				case "back": return null; //new RootStep(false, Path);
				case "where": return null; //new RootStep(false, Path);
			}

			return null;
		}

	}

}