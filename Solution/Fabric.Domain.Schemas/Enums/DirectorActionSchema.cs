namespace Fabric.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class DirectorActionSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public DirectorActionSchema() : base("DirectorAction") {
			AddItem(1, "Read", "Read", "Read the specified Artifact.");
			AddItem(2, "Listen", "Listen", "Listen to the specified Artifact.");
			AddItem(3, "View", "View", "View (or watch, observe) the specified Artifact.");
			AddItem(4, "Consume", "Consume", "Consume (or use, eat, drink, taste, smell) the specified Artifact.");
			AddItem(5, "Perform", "Perform", "Perform (or act, do, carry out, speak, sing, say, work, write) the specified Artifact.");
			AddItem(6, "Produce", "Produce", "Produce (or create, build, make, invent) the specified Artifact.");
			AddItem(7, "Destroy", "Destroy", "Destroy (or remove, delete, kill, erase) the specified Artifact.");
			AddItem(8, "Modify", "Modify", "Modify (or change) the specified Artifact.");
			AddItem(9, "Obtain", "Obtain", "Obtain (or get, purchase, acquire, steal) the specified Artifact.");
			AddItem(10, "Locate", "Locate", "Locate (or find) the specified Artifact.");
			AddItem(11, "Travel", "Travel", "Travel (or visit, walk, run, fly, ride, drive) the specified Artifact.");
			AddItem(12, "Become", "Become", "Become the specified Artifact.");
			AddItem(13, "Explain", "Explain", "Explain (or describe) the specified Artifact.");
			AddItem(14, "Give", "Give", "Give the specified Artifact.");
			AddItem(15, "Learn", "Learn", "Learn (or study, understand) the specified Artifact.");
			AddItem(16, "Start", "Start", "Start (or begin) the specified Artifact.");
			AddItem(17, "Stop", "Stop", "Stop (or end) the specified Artifact.");
		}

	}

}