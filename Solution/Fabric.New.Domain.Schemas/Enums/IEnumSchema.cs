﻿using System.Collections.Generic;

namespace Fabric.New.Domain.Schemas.Enums {

	/*================================================================================================*/
	public interface IEnumSchema {

		string Name { get; }
		IList<IEnumItemSchema> Items { get; }
		
	}

}