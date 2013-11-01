using System.Collections.Generic;

namespace Fabric.Domain.Meta.Builders {
	
	/*================================================================================================*/
	public abstract class VertexBase {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Fill(IDictionary<string, string> pData) {}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected string TryGetString(IDictionary<string, string> pData, string pDbName) {
			string val;
			pData.TryGetValue(pDbName, out val);
			return val;
		}

		/*--------------------------------------------------------------------------------------------*/
		protected long TryGetLong(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? 0 : long.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected int TryGetInt(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? 0 : int.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected byte TryGetByte(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? (byte)0 : byte.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected double TryGetDouble(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? 0 : double.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected float TryGetFloat(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? 0 : float.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected bool TryGetBool(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? false : bool.Parse(val));
		}

	}

}