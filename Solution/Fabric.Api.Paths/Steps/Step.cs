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


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		//protected PathBase() {}

		/*--------------------------------------------------------------------------------------------*/
		public abstract void SetParams(string pParams);

		/*--------------------------------------------------------------------------------------------*/
		public T NewFabDto(DbDto pDbDto) {
			T dto = new T();
			dto.Fill(pDbDto);
			return dto;
		}

		/*--------------------------------------------------------------------------------------------*/
		public T NewFabDto() {
			return new T();
		}

		/*--------------------------------------------------------------------------------------------*/
		public Type DtoType { get { return typeof(T); } }
		public virtual string[] AvailableSteps { get { return Step.AvailSteps; } }

		/*--------------------------------------------------------------------------------------------*/
		public IStep ExecuteUriPart(string pUriPart) {
			string part = pUriPart.ToLower();
			int parenI = part.IndexOf('(');

			if ( parenI > 0 ) {
				part = part.Substring(0, parenI);
			}

			IStep result = GetStepByString(part);

			if ( result == null ) {
				throw new Exception(pUriPart+" is not a valid path option for "+GetType().Name+".");
			}

			if ( parenI > 0 ) {
				string param = part.Substring(parenI+1);

				if ( param.Length == 0 || param[param.Length-1] != ')' ) {
					throw new Exception("Invalid parameter syntax for "+pUriPart+".");
				}

				result.SetParams(param.Substring(0, param.Length-1));
			}

			return result;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected virtual IStep GetStepByString(string pName) {
			switch ( pName ) {
				case "back":
					return null; //new RootStep(false, Path);
				case "where": return null; //new RootStep(false, Path);
			}

			return null;
		}

	}

}