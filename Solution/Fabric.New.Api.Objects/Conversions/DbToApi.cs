
// GENERATED CODE
// Changes made to this source file will be overwritten

using Fabric.New.Api.Objects.Traversal;
using Fabric.New.Domain;
using Fabric.New.Domain.Enums;
using Fabric.New.Infrastructure.Data;

namespace Fabric.New.Api.Objects.Conversions {

	/*================================================================================================*/
	public static partial class DbToApi {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabVertex FromVertexData(IDataDto pDto) {
			switch ( pDto.VertexType ) {
				case VertexType.Id.App: return ConvertApp(pDto);
				case VertexType.Id.Artifact: return ConvertArtifact(pDto);
				case VertexType.Id.Class: return ConvertClass(pDto);
				case VertexType.Id.Factor: return ConvertFactor(pDto);
				case VertexType.Id.Instance: return ConvertInstance(pDto);
				case VertexType.Id.Member: return ConvertMember(pDto);
				case VertexType.Id.Url: return ConvertUrl(pDto);
				case VertexType.Id.User: return ConvertUser(pDto);
				case VertexType.Id.Vertex: return ConvertVertex(pDto);
			}

			return null; //throw new Exception("Unknown VertexType: "+pDto.VertexType);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabLink FromEdgeData(IDataDto pDto) {
			switch ( pDto.EdgeLabel ) {
				case "pdm": return new FabAppDefinesMember();
				case "apbf": return new FabArtifactUsedAsPrimaryByFactor();
				case "arbf": return new FabArtifactUsedAsRelatedByFactor();
				case "mca": return new FabMemberCreatesArtifact();
				case "mcf": return new FabMemberCreatesFactor();
				case "udm": return new FabUserDefinesMember();
			}
			
			return null;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static FabApp ConvertApp(IDataDto pDto) {
			var dom = new App();
			FillApp(pDto, dom);
			return DomainToApi.FromApp(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabArtifact ConvertArtifact(IDataDto pDto) {
			var dom = new Artifact();
			FillArtifact(pDto, dom);
			return DomainToApi.FromArtifact(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabClass ConvertClass(IDataDto pDto) {
			var dom = new Class();
			FillClass(pDto, dom);
			return DomainToApi.FromClass(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabFactor ConvertFactor(IDataDto pDto) {
			var dom = new Factor();
			FillFactor(pDto, dom);
			return DomainToApi.FromFactor(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabInstance ConvertInstance(IDataDto pDto) {
			var dom = new Instance();
			FillInstance(pDto, dom);
			return DomainToApi.FromInstance(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabMember ConvertMember(IDataDto pDto) {
			var dom = new Member();
			FillMember(pDto, dom);
			return DomainToApi.FromMember(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabUrl ConvertUrl(IDataDto pDto) {
			var dom = new Url();
			FillUrl(pDto, dom);
			return DomainToApi.FromUrl(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabUser ConvertUser(IDataDto pDto) {
			var dom = new User();
			FillUser(pDto, dom);
			return DomainToApi.FromUser(dom);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static FabVertex ConvertVertex(IDataDto pDto) {
			var dom = new Vertex();
			FillVertex(pDto, dom);
			return DomainToApi.FromVertex(dom);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		private static void FillApp(IDataDto pDto, App pDom) {
			FillArtifact(pDto, pDom);
			pDom.Name = GetString(pDto, "p_na", true);
			pDom.NameKey = GetString(pDto, "p_nk", true);
			pDom.Secret = GetString(pDto, "p_se", true);
			pDom.OauthDomains = GetString(pDto, "p_od", false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillArtifact(IDataDto pDto, Artifact pDom) {
			FillVertex(pDto, pDom);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillClass(IDataDto pDto, Class pDom) {
			FillArtifact(pDto, pDom);
			pDom.Name = GetString(pDto, "c_na", true);
			pDom.NameKey = GetString(pDto, "c_nk", true);
			pDom.Disamb = GetString(pDto, "c_di", false);
			pDom.Note = GetString(pDto, "c_no", false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillFactor(IDataDto pDto, Factor pDom) {
			FillVertex(pDto, pDom);
			pDom.AssertionType = GetByte(pDto, "f_at", true);
			pDom.IsDefining = GetBool(pDto, "f_de", true);
			pDom.Note = GetString(pDto, "f_no", true);
			pDom.DescriptorType = GetByte(pDto, "f_det", true);
			pDom.DirectorType = GetNullableByte(pDto, "f_dit", false);
			pDom.DirectorPrimaryAction = GetNullableByte(pDto, "f_dip", false);
			pDom.DirectorRelatedAction = GetNullableByte(pDto, "f_dir", false);
			pDom.EventorType = GetNullableByte(pDto, "f_evt", false);
			pDom.EventorDateTime = GetNullableLong(pDto, "f_evd", false);
			pDom.IdentorType = GetNullableByte(pDto, "f_idt", false);
			pDom.IdentorValue = GetString(pDto, "f_idv", false);
			pDom.LocatorType = GetNullableByte(pDto, "f_lot", false);
			pDom.LocatorValueX = GetNullableDouble(pDto, "f_lox", false);
			pDom.LocatorValueY = GetNullableDouble(pDto, "f_loy", false);
			pDom.LocatorValueZ = GetNullableDouble(pDto, "f_loz", false);
			pDom.VectorType = GetNullableByte(pDto, "f_vet", false);
			pDom.VectorUnit = GetNullableByte(pDto, "f_veu", false);
			pDom.VectorUnitPrefix = GetNullableByte(pDto, "f_vep", false);
			pDom.VectorValue = GetNullableLong(pDto, "f_vev", false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillInstance(IDataDto pDto, Instance pDom) {
			FillArtifact(pDto, pDom);
			pDom.Name = GetString(pDto, "i_na", false);
			pDom.Disamb = GetString(pDto, "i_di", false);
			pDom.Note = GetString(pDto, "i_no", false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillMember(IDataDto pDto, Member pDom) {
			FillVertex(pDto, pDom);
			pDom.MemberType = GetByte(pDto, "m_mt", true);
			pDom.OauthScopeAllow = GetNullableBool(pDto, "m_osa", false);
			pDom.OauthGrantRedirectUri = GetString(pDto, "m_ogr", false);
			pDom.OauthGrantCode = GetString(pDto, "m_ogc", false);
			pDom.OauthGrantExpires = GetNullableLong(pDto, "m_oge", false);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillUrl(IDataDto pDto, Url pDom) {
			FillArtifact(pDto, pDom);
			pDom.Name = GetString(pDto, "r_na", false);
			pDom.FullPath = GetString(pDto, "r_fp", true);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillUser(IDataDto pDto, User pDom) {
			FillArtifact(pDto, pDom);
			pDom.Name = GetString(pDto, "u_na", true);
			pDom.NameKey = GetString(pDto, "u_nk", true);
			pDom.Password = GetString(pDto, "u_pa", true);
		}

		/*--------------------------------------------------------------------------------------------*/
		private static void FillVertex(IDataDto pDto, Vertex pDom) {
			FillElement(pDto, pDom);
			pDom.VertexId = GetLong(pDto, "v_id", true);
			pDom.Timestamp = GetLong(pDto, "v_ts", true);
			pDom.VertexType = GetByte(pDto, "v_t", true);
		}

	}

}