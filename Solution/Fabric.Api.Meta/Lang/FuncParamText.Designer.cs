﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
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
    internal class FuncParamText {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal FuncParamText() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fabric.Api.Meta.Lang.FuncParamText", typeof(FuncParamText).Assembly);
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
        ///   Looks up a localized string similar to A named alias, which represents a particular place in the traversal path. This value must be unique across all other aliases in the traversal path..
        /// </summary>
        internal static string As_Alias {
            get {
                return ResourceManager.GetString("As_Alias", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The target named alias, which was defined by an [[As|Func|As]] function earlier in the traversal path..
        /// </summary>
        internal static string Back_Alias {
            get {
                return ResourceManager.GetString("Back_Alias", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The maximum number of nodes to return..
        /// </summary>
        internal static string Limit_Count {
            get {
                return ResourceManager.GetString("Limit_Count", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The starting index for the returned list of nodes..
        /// </summary>
        internal static string Limit_Index {
            get {
                return ResourceManager.GetString("Limit_Index", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The target node Id..
        /// </summary>
        internal static string WhereId_Id {
            get {
                return ResourceManager.GetString("WhereId_Id", resourceCulture);
            }
        }
    }
}
