namespace Fabric.New.Domain.Schemas.Utils {

	/*================================================================================================*/
	public abstract class EdgeProperty {

		public string Name { get; internal set; }
		public string DbName { get; internal set; }
		public DomainProperty DomainProp { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName, DomainProperty pDomProp) {
			DomainProp = pDomProp;
		}

	}


	/*================================================================================================*/
	public class EdgeProperty<T> : EdgeProperty {

		public DomainProperty<T> DomainPropT { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EdgeProperty(string pName, string pDbName, DomainProperty<T> pDomProp) : 
																		base(pName, pDbName,pDomProp) {
			DomainPropT = pDomProp;
		}

	}

}