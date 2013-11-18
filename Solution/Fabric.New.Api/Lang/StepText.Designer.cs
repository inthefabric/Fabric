﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fabric.New.Api.Lang {
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
    internal class StepText {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StepText() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fabric.New.Api.Lang.StepText", typeof(StepText).Assembly);
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
        ///   Looks up a localized string similar to Finds results based on the authenticated state of this traversal request..
        /// </summary>
        internal static string Active {
            get {
                return ResourceManager.GetString("Active", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a named alias for the current step of the traversal path. Execution of the traversal path can return to this alias using the [[Back|Step|Back]] step..
        /// </summary>
        internal static string As {
            get {
                return ResourceManager.GetString("As", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Returns the execution of the traversal path to a particular named alias. This alias is created using the [[As|Step|As]] step.
        ///
        ///When traversal execution reaches a Back step, the execution retraces (steps backwards through) the traversal path until the alias is reached. Execution then proceeds using the traversal step(s) that immediately follow the Back function step.
        ///
        ///The return type of the Back step is determined by the return type of the corresponding alias.
        ///[(EX|Return Type Example|_Traversal Steps_        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Back {
            get {
                return ResourceManager.GetString("Back", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Traverses along an Edge type (connection) between one Vertex and zero, one, or many others.
        ///
        ///Links which will produce many results require further filtering (via relevant FabLink item) before arriving at the desired Vertex items. To complete this filtering, use the relevant [[Take|Step|Take]] step..
        /// </summary>
        internal static string Link {
            get {
                return ResourceManager.GetString("Link", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Restricts the number of results at the current traversal step..
        /// </summary>
        internal static string Take {
            get {
                return ResourceManager.GetString("Take", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Restricts the results to include only App vertices..
        /// </summary>
        internal static string To {
            get {
                return ResourceManager.GetString("To", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finds results where the target property is within the specified range of values..
        /// </summary>
        internal static string Where {
            get {
                return ResourceManager.GetString("Where", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finds results where the target property contains one or more of the specified tokens..
        /// </summary>
        internal static string WhereContains {
            get {
                return ResourceManager.GetString("WhereContains", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finds results where the target property is an exact match to the specified value..
        /// </summary>
        internal static string With {
            get {
                return ResourceManager.GetString("With", resourceCulture);
            }
        }
    }
}
