// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 7/12/2013 3:41:42 PM

using System;
using System.Collections.Generic;
using Fabric.Domain;
using Fabric.Infrastructure.Weaver;
using Weaver.Core;
using Weaver.Core.Query;
using Weaver.Titan;

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

			WeaverInstance wi = Weave.Inst;
			var propMap = new Dictionary<string, IWeaverVarAlias>();
			int groupId = 2;

			////

			q = wi.TitanGraph().TypeGroupOf<Vertex>(groupId++);
			q = WeaverQuery.StoreResultAsVar("N", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "N_FT";
				q = wi.TitanGraph().MakeVertexPropertyKey<Vertex>(x => x.FabType, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<VertexForAction>(groupId++);
			q = WeaverQuery.StoreResultAsVar("NA", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "NA_Pe";
				q = wi.TitanGraph().MakeVertexPropertyKey<VertexForAction>(x => x.Performed, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "NA_No";
				q = wi.TitanGraph().MakeVertexPropertyKey<VertexForAction>(x => x.Note, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<Artifact>(groupId++);
			q = WeaverQuery.StoreResultAsVar("A", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "A_AId";
				q = wi.TitanGraph().MakeVertexPropertyKey<Artifact>(x => x.ArtifactId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "A_Cr";
				q = wi.TitanGraph().MakeVertexPropertyKey<Artifact>(x => x.Created, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<App>(groupId++);
			q = WeaverQuery.StoreResultAsVar("Ap", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "Ap_Na";
				q = wi.TitanGraph().MakeVertexPropertyKey<App>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Ap_NK";
				q = wi.TitanGraph().MakeVertexPropertyKey<App>(x => x.NameKey, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Ap_Se";
				q = wi.TitanGraph().MakeVertexPropertyKey<App>(x => x.Secret, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<Class>(groupId++);
			q = WeaverQuery.StoreResultAsVar("Cl", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "Cl_Na";
				q = wi.TitanGraph().MakeVertexPropertyKey<Class>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Cl_NK";
				q = wi.TitanGraph().MakeVertexPropertyKey<Class>(x => x.NameKey, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Cl_Di";
				q = wi.TitanGraph().MakeVertexPropertyKey<Class>(x => x.Disamb, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Cl_No";
				q = wi.TitanGraph().MakeVertexPropertyKey<Class>(x => x.Note, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<Email>(groupId++);
			q = WeaverQuery.StoreResultAsVar("E", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "E_Id";
				q = wi.TitanGraph().MakeVertexPropertyKey<Email>(x => x.EmailId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "E_Ad";
				q = wi.TitanGraph().MakeVertexPropertyKey<Email>(x => x.Address, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "E_Co";
				q = wi.TitanGraph().MakeVertexPropertyKey<Email>(x => x.Code, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "E_Cr";
				q = wi.TitanGraph().MakeVertexPropertyKey<Email>(x => x.Created, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "E_Ve";
				q = wi.TitanGraph().MakeVertexPropertyKey<Email>(x => x.Verified, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<Instance>(groupId++);
			q = WeaverQuery.StoreResultAsVar("In", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "In_Na";
				q = wi.TitanGraph().MakeVertexPropertyKey<Instance>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "In_Di";
				q = wi.TitanGraph().MakeVertexPropertyKey<Instance>(x => x.Disamb, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "In_No";
				q = wi.TitanGraph().MakeVertexPropertyKey<Instance>(x => x.Note, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<Member>(groupId++);
			q = WeaverQuery.StoreResultAsVar("M", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "M_Id";
				q = wi.TitanGraph().MakeVertexPropertyKey<Member>(x => x.MemberId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<MemberTypeAssign>(groupId++);
			q = WeaverQuery.StoreResultAsVar("MTA", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "MTA_Id";
				q = wi.TitanGraph().MakeVertexPropertyKey<MemberTypeAssign>(x => x.MemberTypeAssignId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "MTA_Mt";
				q = wi.TitanGraph().MakeVertexPropertyKey<MemberTypeAssign>(x => x.MemberTypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<Url>(groupId++);
			q = WeaverQuery.StoreResultAsVar("Ur", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "Ur_Na";
				q = wi.TitanGraph().MakeVertexPropertyKey<Url>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "Ur_Pa";
				q = wi.TitanGraph().MakeVertexPropertyKey<Url>(x => x.FullPath, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<User>(groupId++);
			q = WeaverQuery.StoreResultAsVar("U", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "U_Na";
				q = wi.TitanGraph().MakeVertexPropertyKey<User>(x => x.Name, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "U_NK";
				q = wi.TitanGraph().MakeVertexPropertyKey<User>(x => x.NameKey, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "U_Pa";
				q = wi.TitanGraph().MakeVertexPropertyKey<User>(x => x.Password, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<Factor>(groupId++);
			q = WeaverQuery.StoreResultAsVar("F", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "F_Id";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.FactorId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Fa";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.FactorAssertionId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Df";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.IsDefining, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Cr";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Created, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Dl";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Deleted, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_Co";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Completed, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_No";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Note, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_DeT";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Descriptor_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_DiT";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Director_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_DiP";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Director_PrimaryActionId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_DiR";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Director_RelatedActionId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_EvT";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Eventor_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_EvP";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Eventor_PrecisionId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_EvD";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Eventor_DateTime, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_IdT";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Identor_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_IdV";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Identor_Value, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_LoT";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Locator_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_LoX";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Locator_ValueX, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_LoY";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Locator_ValueY, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_LoZ";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Locator_ValueZ, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_VeT";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Vector_TypeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_VeU";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Vector_UnitId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_VeP";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Vector_UnitPrefixId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "F_VeV";
				q = wi.TitanGraph().MakeVertexPropertyKey<Factor>(x => x.Vector_Value, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<OauthAccess>(groupId++);
			q = WeaverQuery.StoreResultAsVar("OA", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "OA_Id";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthAccess>(x => x.OauthAccessId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OA_To";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthAccess>(x => x.Token, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OA_Re";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthAccess>(x => x.Refresh, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OA_Ex";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthAccess>(x => x.Expires, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OA_CO";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthAccess>(x => x.IsClientOnly, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<OauthDomain>(groupId++);
			q = WeaverQuery.StoreResultAsVar("OD", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "OD_Id";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthDomain>(x => x.OauthDomainId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OD_Do";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthDomain>(x => x.Domain, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<OauthGrant>(groupId++);
			q = WeaverQuery.StoreResultAsVar("OG", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "OG_Id";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthGrant>(x => x.OauthGrantId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OG_Re";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthGrant>(x => x.RedirectUri, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OG_Co";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthGrant>(x => x.Code, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OG_Ex";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthGrant>(x => x.Expires, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

			////

			q = wi.TitanGraph().TypeGroupOf<OauthScope>(groupId++);
			q = WeaverQuery.StoreResultAsVar("OS", q, out gv);
			pSet.AddIndexQuery(q);

				dbName = "OS_Id";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthScope>(x => x.OauthScopeId, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OS_Al";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthScope>(x => x.Allow, gv).ToQuery();
				q = WeaverQuery.StoreResultAsVar(dbName, q, out pv);
				pSet.AddIndexQuery(q);
				propMap.Add(dbName, pv);

				dbName = "OS_Cr";
				q = wi.TitanGraph().MakeVertexPropertyKey<OauthScope>(x => x.Created, gv).ToQuery();
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
