using System;
using Fabric.Api.Dto;
using Fabric.Infrastructure;

namespace Fabric.Api.Paths {

	/*================================================================================================*/
	public abstract class PathBase<T> : IPathBase where T : FabNode, new() {

		public long? TypeId { get; protected set; }
		public Path Path { get; protected set; }

		protected abstract string TypeIdName { get; }
		protected abstract bool TypeIdIsLong { get; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		//protected PathBase() {}

		/*--------------------------------------------------------------------------------------------*/
		public void Id(long pTypeId) {
			if ( TypeId != null ) {
				throw new Exception("TypeId already set.");
			}

			TypeId = pTypeId;
			Path.Add("has('"+TypeIdName+"',Tokens.T.eq,"+TypeId+(TypeIdIsLong ? "L" : "")+")");
		}

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

		/*--------------------------------------------------------------------------------------------*/
		public IPathBase ExecuteUriPart(string pUriPart) {
			string part = pUriPart.ToLower();
			int parenI = part.IndexOf('(');
			string param = null;

			if ( parenI > 0 ) {
				param = part.Substring(parenI+1);
				param = param.Substring(0, param.Length-1);
				part = part.Substring(0, parenI);
			}

			IPathBase result = GetPathByString(part);

			if ( result == null ) {
				throw new Exception(pUriPart+" is not a valid path option for "+GetType().Name+".");
			}

			if ( param != null ) {
				long id;
				
				if ( !long.TryParse(param, out id) ) {
					throw new Exception("Could not parse Id value for '"+param+"'.");
				}

				result.Id(id);
			}

			return result;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected abstract IPathBase GetPathByString(string pName);

	}

}