using Fabric.Domain.Meta.Vertices.Tools;

namespace Fabric.Domain.Meta.Vertices {
	
	/*================================================================================================*/
	public class EmailSchema : VertexSchema {

		public DomainProperty<string> Address { get; private set; }
		public DomainProperty<string> Code { get; private set; }
		public DomainProperty<bool> Verified { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public EmailSchema() {
			Names = new NameProvider("Email", "Emails", "e");
			IsInternal = true;

			////

			Address = new DomainProperty<string>("Address", "e.ad");
			Address.IsUnique = true;
			Address.ToLowerCase = true;
			Address.IsIndexed = true;

			Code = new DomainProperty<string>("Code", "e.co");

			Verified = new DomainProperty<bool>("Verified", "e.ve");
		}

	}

}