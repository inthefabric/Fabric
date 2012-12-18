﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fabric.Api.Spec.Lang {
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
    internal class OauthPropText {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal OauthPropText() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fabric.Api.Spec.Lang.OauthPropText", typeof(OauthPropText).Assembly);
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
        ///   Looks up a localized string similar to A 32-character code that maps to various authentication information. Notably, it is refers to exactly one App and at most one User..
        /// </summary>
        internal static string OauthAccess_AccessToken {
            get {
                return ResourceManager.GetString("OauthAccess_AccessToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The number of seconds until the access token expires..
        /// </summary>
        internal static string OauthAccess_ExpiresIn {
            get {
                return ResourceManager.GetString("OauthAccess_ExpiresIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A 32-character code that refreshes the authentication session for an expired OAuth access token. App-only access tokens do not include a refresh token; instead, the App should [[request a new access token|Req|oauth.access_token.client_credentials.get]]..
        /// </summary>
        internal static string OauthAccess_RefreshToken {
            get {
                return ResourceManager.GetString("OauthAccess_RefreshToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to For the current Fabric OAuth implementation, this value is always equal to &quot;bearer&quot;..
        /// </summary>
        internal static string OauthAccess_TokenType {
            get {
                return ResourceManager.GetString("OauthAccess_TokenType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error code as defined by the OAuth 2.0 specification..
        /// </summary>
        internal static string OauthError_Error {
            get {
                return ResourceManager.GetString("OauthError_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides specific details about the error. A single error code may have one or more possible error descriptions..
        /// </summary>
        internal static string OauthError_ErrorDescription {
            get {
                return ResourceManager.GetString("OauthError_ErrorDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use this 32-character string (also called the &apos;authorization code&apos;) to generate a new OAuth access token. For security purposes, each code is valid for a single use, and expires 120 seconds after creation..
        /// </summary>
        internal static string OauthLogin_Code {
            get {
                return ResourceManager.GetString("OauthLogin_Code", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error code as defined by the OAuth 2.0 specification..
        /// </summary>
        internal static string OauthLogin_Error {
            get {
                return ResourceManager.GetString("OauthLogin_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides specific details about the error. A single error code may have one or more possible error descriptions. For use in the redirect URI, this string uses a &apos;+&apos; character in place of each space character..
        /// </summary>
        internal static string OauthLogin_ErrorDescription {
            get {
                return ResourceManager.GetString("OauthLogin_ErrorDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Returns the &apos;state&apos; value that the App provided in the original Oauth request. For security reasons, the App should reject the response if the original and returned values are not equal..
        /// </summary>
        internal static string OauthLogin_State {
            get {
                return ResourceManager.GetString("OauthLogin_State", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Identifies a particular OAuth session..
        /// </summary>
        internal static string OauthLogout_AccessToken {
            get {
                return ResourceManager.GetString("OauthLogout_AccessToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the result of the logout attempt. Successful logout attempts return a value of 1..
        /// </summary>
        internal static string OauthLogout_Success {
            get {
                return ResourceManager.GetString("OauthLogout_Success", resourceCulture);
            }
        }
    }
}
