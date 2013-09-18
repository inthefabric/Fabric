﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fabric.Api.Meta.Lang {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class EnumText {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EnumText() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fabric.Api.Meta.Lang.EnumText", typeof(EnumText).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the object type associated with a particular Artifact..
        /// </summary>
        internal static string ArtifactType {
            get {
                return ResourceManager.GetString("ArtifactType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The base class for all Fabric enumerations..
        /// </summary>
        internal static string BaseEnum {
            get {
                return ResourceManager.GetString("BaseEnum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the level of access and control given to a particular Crowdian..
        /// </summary>
        internal static string CrowdianType {
            get {
                return ResourceManager.GetString("CrowdianType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides meaning (via Descriptor) to the relationship between the two Artifacts in a particular Factor..
        /// </summary>
        internal static string DescriptorType {
            get {
                return ResourceManager.GetString("DescriptorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes an action to be taken (via Director) on one of the two Artifacts in a particular Factor..
        /// </summary>
        internal static string DirectorAction {
            get {
                return ResourceManager.GetString("DirectorAction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides meaning (via Director) to the directional connection between the two Artifacts in a particular Factor..
        /// </summary>
        internal static string DirectorType {
            get {
                return ResourceManager.GetString("DirectorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides temporal significance (via Eventor) for a particular Factor..
        /// </summary>
        internal static string EventorType {
            get {
                return ResourceManager.GetString("EventorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the type of information (and/or level of confidence) provided by a particular Factor..
        /// </summary>
        internal static string FactorAssertion {
            get {
                return ResourceManager.GetString("FactorAssertion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides a hint about the text (via Identor) that identifies a particular Factor..
        /// </summary>
        internal static string IdentorType {
            get {
                return ResourceManager.GetString("IdentorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides spatial context and boundaries (via Locator) for a particular Factor..
        /// </summary>
        internal static string LocatorType {
            get {
                return ResourceManager.GetString("LocatorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the level of access and control given to a particular Member..
        /// </summary>
        internal static string MemberType {
            get {
                return ResourceManager.GetString("MemberType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides meaning (using relatively-positioned points/labels) across the numerical range of a particular VectorType..
        /// </summary>
        internal static string VectorRange {
            get {
                return ResourceManager.GetString("VectorRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A relatively-positioned point which provides meaning to a numerical range..
        /// </summary>
        internal static string VectorRangeLevel {
            get {
                return ResourceManager.GetString("VectorRangeLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides meaning and boundaries (via Vector) for a numeric value given to a particular Factor..
        /// </summary>
        internal static string VectorType {
            get {
                return ResourceManager.GetString("VectorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides a unit of measurement for the numeric value of a particular Vector..
        /// </summary>
        internal static string VectorUnit {
            get {
                return ResourceManager.GetString("VectorUnit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides conversion formulas from the [[&quot;derived&quot; unit|Enum|VectorUnit]] to one or more [[&quot;raises&quot; units|Enum|VectorUnit]]. Each &quot;raises&quot; unit receives a [[unit prefix|Enum|VectorUnitPrefix]] and an exponent value.
        ///
        ///[(EX|Watt Example|_Description_
        ///The Watt unit conversion is defined with three seperate VectorUnitDerived items:
        ///- WattGram
        ///- WattMetre
        ///- WattSec
        ///
        ///_Equation_
        ///Those three items represent the Watt conversion equation:
        ///1 Watt = 1 (Kg)*(m^2)/(s^3))].
        /// </summary>
        internal static string VectorUnitDerived {
            get {
                return ResourceManager.GetString("VectorUnitDerived", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides a level of magnitude for the numeric value of a particular Vector..
        /// </summary>
        internal static string VectorUnitPrefix {
            get {
                return ResourceManager.GetString("VectorUnitPrefix", resourceCulture);
            }
        }
    }
}
