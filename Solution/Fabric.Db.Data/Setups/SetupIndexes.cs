// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 6/23/2013 1:33:26 PM

using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Core.Query;
using Weaver.Titan;
using Weaver.Titan.Graph;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public class SetupIndexes {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			var su = new SetupIndexes(pSet);
		}
			

		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private SetupIndexes(DataSet pSet) {
			IWeaverQuery q;
			IWeaverVarAlias gv;
			IWeaverVarAlias pv;
			string dbName;

			IWeaverTitanGraph tg = Weave.Inst.TitanGraph();
			var propMap = new Dictionary<string, IWeaverVarAlias>();
			int groupId = 2;

			////

			q = tg.TypeGroupOf<App>(groupId++);
			q = WeaverQuery.StoreResultAsVar("Ap", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "Ap_Na";
				q = tg.MakeVertexPropertyKey<App>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Ap_NK";
				q = tg.MakeVertexPropertyKey<App>(x => x.NameKey, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Ap_Se";
				q = tg.MakeVertexPropertyKey<App>(x => x.Secret, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<Class>(groupId++);
			q = WeaverQuery.StoreResultAsVar("Cl", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "Cl_Na";
				q = tg.MakeVertexPropertyKey<Class>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Cl_NK";
				q = tg.MakeVertexPropertyKey<Class>(x => x.NameKey, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Cl_Di";
				q = tg.MakeVertexPropertyKey<Class>(x => x.Disamb, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Cl_No";
				q = tg.MakeVertexPropertyKey<Class>(x => x.Note, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<Email>(groupId++);
			q = WeaverQuery.StoreResultAsVar("E", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "E_Id";
				q = tg.MakeVertexPropertyKey<Email>(x => x.EmailId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "E_Ad";
				q = tg.MakeVertexPropertyKey<Email>(x => x.Address, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "E_Co";
				q = tg.MakeVertexPropertyKey<Email>(x => x.Code, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "E_Cr";
				q = tg.MakeVertexPropertyKey<Email>(x => x.Created, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "E_Ve";
				q = tg.MakeVertexPropertyKey<Email>(x => x.Verified, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<Instance>(groupId++);
			q = WeaverQuery.StoreResultAsVar("In", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "In_Na";
				q = tg.MakeVertexPropertyKey<Instance>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "In_Di";
				q = tg.MakeVertexPropertyKey<Instance>(x => x.Disamb, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "In_No";
				q = tg.MakeVertexPropertyKey<Instance>(x => x.Note, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<Member>(groupId++);
			q = WeaverQuery.StoreResultAsVar("M", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "M_Id";
				q = tg.MakeVertexPropertyKey<Member>(x => x.MemberId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<MemberTypeAssign>(groupId++);
			q = WeaverQuery.StoreResultAsVar("MTA", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "MTA_Id";
				q = tg.MakeVertexPropertyKey<MemberTypeAssign>(x => x.MemberTypeAssignId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "MTA_Mt";
				q = tg.MakeVertexPropertyKey<MemberTypeAssign>(x => x.MemberTypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<Url>(groupId++);
			q = WeaverQuery.StoreResultAsVar("Ur", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "Ur_Na";
				q = tg.MakeVertexPropertyKey<Url>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Ur_Ab";
				q = tg.MakeVertexPropertyKey<Url>(x => x.AbsoluteUrl, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<User>(groupId++);
			q = WeaverQuery.StoreResultAsVar("U", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "U_Na";
				q = tg.MakeVertexPropertyKey<User>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "U_NK";
				q = tg.MakeVertexPropertyKey<User>(x => x.NameKey, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "U_Pa";
				q = tg.MakeVertexPropertyKey<User>(x => x.Password, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<Factor>(groupId++);
			q = WeaverQuery.StoreResultAsVar("F", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "F_Id";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.FactorId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Fa";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.FactorAssertionId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Df";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.IsDefining, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Cr";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Created, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Dl";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Deleted, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Co";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Completed, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_No";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Note, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_DeT";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Descriptor_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_DiT";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Director_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_DiP";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Director_PrimaryActionId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_DiR";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Director_RelatedActionId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_EvT";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Eventor_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_EvP";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Eventor_PrecisionId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_EvD";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Eventor_DateTime, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_IdT";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Identor_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_IdV";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Identor_Value, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_LoT";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Locator_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_LoX";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Locator_ValueX, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_LoY";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Locator_ValueY, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_LoZ";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Locator_ValueZ, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_VeT";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Vector_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_VeU";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Vector_UnitId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_VeP";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Vector_UnitPrefixId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_VeV";
				q = tg.MakeVertexPropertyKey<Factor>(x => x.Vector_Value, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<OauthAccess>(groupId++);
			q = WeaverQuery.StoreResultAsVar("OA", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "OA_Id";
				q = tg.MakeVertexPropertyKey<OauthAccess>(x => x.OauthAccessId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OA_To";
				q = tg.MakeVertexPropertyKey<OauthAccess>(x => x.Token, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OA_Re";
				q = tg.MakeVertexPropertyKey<OauthAccess>(x => x.Refresh, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OA_Ex";
				q = tg.MakeVertexPropertyKey<OauthAccess>(x => x.Expires, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OA_CO";
				q = tg.MakeVertexPropertyKey<OauthAccess>(x => x.IsClientOnly, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<OauthDomain>(groupId++);
			q = WeaverQuery.StoreResultAsVar("OD", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "OD_Id";
				q = tg.MakeVertexPropertyKey<OauthDomain>(x => x.OauthDomainId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OD_Do";
				q = tg.MakeVertexPropertyKey<OauthDomain>(x => x.Domain, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<OauthGrant>(groupId++);
			q = WeaverQuery.StoreResultAsVar("OG", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "OG_Id";
				q = tg.MakeVertexPropertyKey<OauthGrant>(x => x.OauthGrantId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OG_Re";
				q = tg.MakeVertexPropertyKey<OauthGrant>(x => x.RedirectUri, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OG_Co";
				q = tg.MakeVertexPropertyKey<OauthGrant>(x => x.Code, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OG_Ex";
				q = tg.MakeVertexPropertyKey<OauthGrant>(x => x.Expires, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = tg.TypeGroupOf<OauthScope>(groupId++);
			q = WeaverQuery.StoreResultAsVar("OS", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "OS_Id";
				q = tg.MakeVertexPropertyKey<OauthScope>(x => x.OauthScopeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OS_Al";
				q = tg.MakeVertexPropertyKey<OauthScope>(x => x.Allow, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OS_Cr";
				q = tg.MakeVertexPropertyKey<OauthScope>(x => x.Created, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			Func<string, IWeaverVarAlias> f = (n => propMap[n]);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<AppUsesEmail>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<AppDefinesMember>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<MemberHasMemberTypeAssign>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<MemberHasHistoricMemberTypeAssign>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<MemberCreatesArtifact>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<MemberCreatesMemberTypeAssign>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<MemberCreatesFactor>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<UserUsesEmail>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<UserDefinesMember>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<FactorUsesPrimaryArtifact>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<FactorUsesRelatedArtifact>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<FactorDescriptorRefinesPrimaryWithArtifact>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<FactorDescriptorRefinesRelatedWithArtifact>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<FactorDescriptorRefinesTypeWithArtifact>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<FactorVectorUsesAxisArtifact>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<OauthAccessUsesApp>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<OauthAccessUsesUser>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<OauthDomainUsesApp>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<OauthGrantUsesApp>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<OauthGrantUsesUser>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<OauthScopeUsesApp>(f).ToQuery();
			pSet.AddIndexQuery(q);

			q = Weave.Inst.TitanGraph().BuildEdgeLabel<OauthScopeUsesUser>(f).ToQuery();
			pSet.AddIndexQuery(q);
		}

	}

}
