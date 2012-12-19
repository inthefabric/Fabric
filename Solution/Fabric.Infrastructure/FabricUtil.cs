using System;
using System.Security.Cryptography;
using System.Text;
using Weaver;

namespace Fabric.Infrastructure {

	/*================================================================================================*/
	public static class FabricUtil {

		//Reduced bounds stop the Gremlin/Neo4j Java complaints
		public const double DoubleMin = double.MinValue+1E+294;
		public const double DoubleMax = double.MaxValue-1E+294;

		
		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static string WeaverQueryToJson(WeaverQuery pQuery) {
			string json = "{\"script\":\""+JsonUnquote(pQuery.Script)+"\",\"params\":{";
			bool first = true;

			foreach ( string key in pQuery.Params.Keys ) {
				json += (first ? "" : ",")+"\""+JsonUnquote(key)+"\":\""+
					JsonUnquote(pQuery.Params[key])+"\"";
				first = false;
			}

			return json+"}}";
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string JsonUnquote(string pText) {
			return pText.Replace("\"", "\\\"");
		}

		/*--------------------------------------------------------------------------------------------*/
		public static string Code32 { get { return Guid.NewGuid().ToString("N"); } }


		////////////////////////////////////////////////////////////////////////////////////////////////
		// Authentication
		/*--------------------------------------------------------------------------------------------*/
		public static string HashPassword(string pPassword) {
			//var hash = new SHA512Managed(); //64 byte hash
			var hash = new MD5CryptoServiceProvider(); //16 byte hash
			byte[] bytes = hash.ComputeHash(Encoding.Unicode.GetBytes(pPassword));
			var sb = new StringBuilder();

			for ( int i = 0 ; i < 16 ; i++ ) {
				sb.Append(bytes[i].ToString("x2"));
			}

			return sb.ToString();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		// Member
		/*--------------------------------------------------------------------------------------------* /
		public static bool IsAcceptedMember(Member pMember) {
			if ( pMember == null ) { return false; }

			if ( pMember.MemberType == null ) {
				throw new ArgumentNullException("Member.MemberType");
			}

			switch ( pMember.MemberType.Id ) {
				case (int)MemberTypeIds.None:
				case (int)MemberTypeIds.Invite:
				case (int)MemberTypeIds.Request:
					return false;
			}

			return true;
		}

		/*--------------------------------------------------------------------------------------------* /
		public static bool CanMemberSetFactorIsDefining(Member pActiveMember, Member pCreatorMember) {
			if ( pActiveMember.Id == pCreatorMember.Id ) {
				return true;
			}

			if ( pActiveMember.App.Id == pCreatorMember.App.Id ) {
				if ( pActiveMember.MemberType.Id == (int)MemberTypeIds.DataProvider ) { return true; }
			}

			return false;
		}*/

	}

}