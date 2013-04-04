namespace Fabric.Domain {

	/*================================================================================================*/
	public enum NodeFabType {
		Abstract = -2,
		BaseClass = -1,

		App = 1000,
		Class,
		Instance,
		Url,
		User,

		Member = 2000,
		MemberType,
		MemberTypeAssign,
			
		Factor = 3000,
		FactorAssertion,
		Descriptor,
		DescriptorType,
		Director,
		DirectorType,
		DirectorAction,
		Eventor,
		EventorType,
		EventorPrecision,
		Identor,
		IdentorType,
		Locator,
		LocatorType,
		Vector,
		VectorType,
		VectorRange,
		VectorRangeLevel,
		VectorUnit,
		VectorUnitPrefix,
		VectorUnitDerived,
			
		Email = 4000,
		OauthAccess,
		OauthDomain,
		OauthGrant,
		OauthScope
	}

}