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

	}

}