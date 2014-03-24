namespace Fabric.New.Domain.Schemas.Enums {

	/*================================================================================================*/
	public class EventorTypeSchema : EnumSchema {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EventorTypeSchema() : base("EventorType") {
			AddItem(1, "Start", "Start", "This Factor starts, begins, or commences on the specified date.");
			AddItem(2, "End", "End", "This Factor ends, stops, or terminates on the specified date.");
			AddItem(3, "Pause", "Pause", "This Factor pauses, suspendeds, or waits on the specified date.");
			AddItem(4, "Unpause", "Unpause", "This Factor unpauses or resumes on the specified date.");
			AddItem(5, "Continue", "Continue", "This Factor continues in its current state on the specified date.");
			AddItem(6, "Occur", "Occur", "This Factor occurrs or happens on the specified date.");
			AddItem(7, "Expected", "Expected", "This Factor is/was expected, anticipated, or due on the specified date.");
		}

	}

}