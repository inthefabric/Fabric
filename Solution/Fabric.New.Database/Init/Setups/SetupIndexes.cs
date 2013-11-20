﻿// GENERATED CODE
// Changes made to this source file will be overwritten
// Generated on 9/16/2013 2:16:03 PM

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
...
...
