﻿using System.Collections.Generic;

namespace Fabric.Domain.NewSchema {

	/*================================================================================================*/
	public enum VertexDomainType : byte {
		Artifact = 0,
		Vertex = 0,
		//Skip = 1,
		App = 2,
		Class = 3,
		Instance = 4,
		Url = 5,
		User = 6,
		Member = 7,
		//Skip = 8,
		Factor = 9,
		Email = 10,
		OauthAccess = 11,
		OauthDomain = 12,
		OauthGrant = 13,
		OauthScope = 14,
	}

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
		protected long? TryGetNullableLong(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? (long?)null : long.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected int? TryGetNullableInt(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? (int?)null : int.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected byte? TryGetNullableByte(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? (byte?)null : byte.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected double? TryGetNullableDouble(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? (double?)null : double.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected float? TryGetNullableFloat(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? (float?)null : float.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected bool? TryGetNullableBool(IDictionary<string, string> pData, string pDbName) {
			string val = TryGetString(pData, pDbName);
			return (val == null ? (bool?)null : bool.Parse(val));
		}

		/*--------------------------------------------------------------------------------------------*/
		protected long TryGetLong(IDictionary<string, string> pData, string pDbName) {
			return (TryGetNullableLong(pData, pDbName) ?? 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected int TryGetInt(IDictionary<string, string> pData, string pDbName) {
			return (TryGetNullableInt(pData, pDbName) ?? 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected byte TryGetByte(IDictionary<string, string> pData, string pDbName) {
			return (TryGetNullableByte(pData, pDbName) ?? 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected double TryGetDouble(IDictionary<string, string> pData, string pDbName) {
			return (TryGetNullableDouble(pData, pDbName) ?? 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected float TryGetFloat(IDictionary<string, string> pData, string pDbName) {
			return (TryGetNullableFloat(pData, pDbName) ?? 0);
		}

		/*--------------------------------------------------------------------------------------------*/
		protected bool TryGetBool(IDictionary<string, string> pData, string pDbName) {
			return (TryGetNullableBool(pData, pDbName) ?? false);
		}

	}

}