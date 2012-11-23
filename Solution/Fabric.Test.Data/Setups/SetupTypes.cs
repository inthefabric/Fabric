using System.Collections.Generic;
using System.Linq;
using Fabric.Domain;
using Fabric.Domain.Schema;

namespace Fabric.Test.Data.Setups {

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
		public static IList<ISetupNode> SetupAll() {
			IEnumerable<ISetupNode> list = new List<ISetupNode>();

			list = list.Concat(SetupArtifactType());
			/*SetupCrowdUserType();
			SetupMemberType();

			SetupDescriptorRefineType();
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
			
			return list.ToList();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public static IList<ISetupNode> SetupArtifactType() {
			var list = new List<ISetupNode>();

			var at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.App;
			at.Name = "App";
			at.Description = "This Artifact is related to a specific App.";
			list.Add(SetupNode.Create(at, true));

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.User;
			at.Name = "User";
			at.Description = "This Artifact is related to a specific User.";
			list.Add(SetupNode.Create(at, true));

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Thing;
			at.Name = "Thing";
			at.Description = "This Artifact is related to a specific Thing.";
			list.Add(SetupNode.Create(at, true));

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Url;
			at.Name = "Url";
			at.Description = "This Artifact is related to a specific URL.";
			list.Add(SetupNode.Create(at, true));

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Label;
			at.Name = "Label";
			at.Description = "This Artifact is related to a specific Label.";
			list.Add(SetupNode.Create(at, true));

			/*at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Comment;
			at.Name = "Comment";
			at.Description = "This Artifact is related to a specific Comment.";
			list.Add(SetupNode.Create(at, true));*/

			at = new ArtifactType();
			at.ArtifactTypeId = (byte)ArtifactTypeId.Crowd;
			at.Name = "Crowd";
			at.Description = "This Artifact is related to a specific Crowd.";
			list.Add(SetupNode.Create(at, true));

			return list;
		}

	}

}