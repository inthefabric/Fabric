using System.Collections.Generic;
using Fabric.Domain;

namespace Fabric.Db.Data.Setups {

	/*================================================================================================*/
	public static class SetupTypes {

		public const byte NumArtifactTypes = 7;
		public const byte NumCrowdUserTypes = 4;
		public const byte NumMemberTypes = 8;

		public const byte NumDescriptorRefineTypes = 3;
		public const byte NumDescriptorTypes = 20;
		public const byte NumDirectorActions = 17;
		public const byte NumDirectorTypes = 5;
		public const byte NumEventorPrecisions = 6;
		public const byte NumEventorTypes = 7;
		public const byte NumFactorAccesses = 2;
		public const byte NumFactorAsserts = 4;
		public const byte NumIdentorTypes = 2;
		public const byte NumLocatorTypes = 6;
		public const byte NumVectorRanges = 7;
		public const byte NumVectorRangeLevels = 29;
		public const byte NumVectorTypes = 10;
		public const byte NumVectorUnitPrefixes = 19;
		public const byte NumVectorUnits = 28;
		public const byte NumVectorUnitDeriveds = 27;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupAll(DataSet pSet) {
			SetupArtifactType(pSet);
			SetupCrowdianType(pSet);
			SetupMemberType(pSet);

			/*SetupDescriptorRefineType();
			SetupDescriptorType();
			SetupDirectorAction();
			SetupDirectorType();
			SetupEventorPrecision();
			SetupEventorType();
			SetupFactorAccess();
			SetupFactorAssert();
			SetupIdentorType();
			SetupLocatorType();
			SetupVectorRange();
			SetupVectorRangeLevel();
			SetupVectorType();
			SetupVectorUnitPrefix();
			SetupVectorUnit();
			SetupVectorUnitDerived();*/
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static void SetupArtifactType(DataSet pSet) {
			var at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.App;
			at.Name = "App";
			at.Description = "This Artifact is related to a specific App.";
			pSet.AddNodeAndIndex(at, x => x.ArtifactTypeId, false);
			pSet.AddRootRel<RootContainsArtifactType>(at, false);

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.User;
			at.Name = "User";
			at.Description = "This Artifact is related to a specific User.";
			pSet.AddNodeAndIndex(at, x => x.ArtifactTypeId, false);
			pSet.AddRootRel<RootContainsArtifactType>(at, false);

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Thing;
			at.Name = "Thing";
			at.Description = "This Artifact is related to a specific Thing.";
			pSet.AddNodeAndIndex(at, x => x.ArtifactTypeId, false);
			pSet.AddRootRel<RootContainsArtifactType>(at, false);

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Url;
			at.Name = "Url";
			at.Description = "This Artifact is related to a specific URL.";
			pSet.AddNodeAndIndex(at, x => x.ArtifactTypeId, false);
			pSet.AddRootRel<RootContainsArtifactType>(at, false);

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Label;
			at.Name = "Label";
			at.Description = "This Artifact is related to a specific Label.";
			pSet.AddNodeAndIndex(at, x => x.ArtifactTypeId, false);
			pSet.AddRootRel<RootContainsArtifactType>(at, false);

			/*at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Comment;
			at.Name = "Comment";
			at.Description = "This Artifact is related to a specific Comment.";
			pSet.AddNode(DataNode.Create(at));
			pSet.AddRootRel<RootContainsArtifactType>(at, false);*/

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Crowd;
			at.Name = "Crowd";
			at.Description = "This Artifact is related to a specific Crowd.";
			pSet.AddNodeAndIndex(at, x => x.ArtifactTypeId, false);
			pSet.AddRootRel<RootContainsArtifactType>(at, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupCrowdianType(DataSet pSet) {
			var list = new List<IDataNode>();

			var ct = new CrowdianType();
			ct.CrowdianTypeId = (byte)CrowdianTypeId.Request;
			ct.Name = "Request";
			ct.Description = "You would like to be a member of this Crowd.";
			pSet.AddNodeAndIndex(ct, x => x.CrowdianTypeId, false);
			pSet.AddRootRel<RootContainsCrowdianType>(ct, false);

			ct = new CrowdianType();
			ct.CrowdianTypeId = (byte)CrowdianTypeId.Invite;
			ct.Name = "Invite";
			ct.Description = "You have been invited to join this Crowd.";
			pSet.AddNodeAndIndex(ct, x => x.CrowdianTypeId, false);
			pSet.AddRootRel<RootContainsCrowdianType>(ct, false);

			ct = new CrowdianType();
			ct.CrowdianTypeId = (byte)CrowdianTypeId.Member;
			ct.Name = "Member";
			ct.Description = "You are a member of this Crowd.";
			pSet.AddNodeAndIndex(ct, x => x.CrowdianTypeId, false);
			pSet.AddRootRel<RootContainsCrowdianType>(ct, false);

			ct = new CrowdianType();
			ct.CrowdianTypeId = (byte)CrowdianTypeId.Admin;
			ct.Name = "Admin";
			ct.Description = "You are an administrator of this Crowd.";
			pSet.AddNodeAndIndex(ct, x => x.CrowdianTypeId, false);
			pSet.AddRootRel<RootContainsCrowdianType>(ct, false);
		}

		/*--------------------------------------------------------------------------------------------*/
		public static void SetupMemberType(DataSet pSet) {
			var mt = new MemberType();
			mt.MemberTypeId = (byte)MemberTypeId.None;
			mt.Name = "None";
			mt.Description = "You are not associated with this App.";
			pSet.AddNodeAndIndex(mt, x => x.MemberTypeId, false);
			pSet.AddRootRel<RootContainsMemberType>(mt, false);

			mt = new MemberType();
			mt.MemberTypeId = (byte)MemberTypeId.Request;
			mt.Name = "Request";
			mt.Description = "You would like to be a member of this App.";
			pSet.AddNodeAndIndex(mt, x => x.MemberTypeId, false);
			pSet.AddRootRel<RootContainsMemberType>(mt, false);

			mt = new MemberType();
			mt.MemberTypeId = (byte)MemberTypeId.Invite;
			mt.Name = "Invite";
			mt.Description = "You have been invited to join this App.";
			pSet.AddNodeAndIndex(mt, x => x.MemberTypeId, false);
			pSet.AddRootRel<RootContainsMemberType>(mt, false);

			mt = new MemberType();
			mt.MemberTypeId = (byte)MemberTypeId.Member;
			mt.Name = "Member";
			mt.Description = "You are a member of this App.";
			pSet.AddNodeAndIndex(mt, x => x.MemberTypeId, false);
			pSet.AddRootRel<RootContainsMemberType>(mt, false);

			mt = new MemberType();
			mt.MemberTypeId = (byte)MemberTypeId.Staff;
			mt.Name = "Staff";
			mt.Description = "You are a staff member of this App.";
			pSet.AddNodeAndIndex(mt, x => x.MemberTypeId, false);
			pSet.AddRootRel<RootContainsMemberType>(mt, false);

			mt = new MemberType();
			mt.MemberTypeId = (byte)MemberTypeId.Admin;
			mt.Name = "Admin";
			mt.Description = "You are an administrator of this App.";
			pSet.AddNodeAndIndex(mt, x => x.MemberTypeId, false);
			pSet.AddRootRel<RootContainsMemberType>(mt, false);

			mt = new MemberType();
			mt.MemberTypeId = (byte)MemberTypeId.Owner;
			mt.Name = "Owner";
			mt.Description = "You are the owner of this App.";
			pSet.AddNodeAndIndex(mt, x => x.MemberTypeId, false);
			pSet.AddRootRel<RootContainsMemberType>(mt, false);

			mt = new MemberType();
			mt.MemberTypeId = (byte)MemberTypeId.DataProvider;
			mt.Name = "DataProvider";
			mt.Description = "A special membership which allows a App to add items that "+
				"are accessible by all of its users.";
			pSet.AddNodeAndIndex(mt, x => x.MemberTypeId, false);
			pSet.AddRootRel<RootContainsMemberType>(mt, false);
		}

	}

}