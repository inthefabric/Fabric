﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fabric.Api.Lang {
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
    internal class ServiceOpParamText {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ServiceOpParamText() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fabric.Api.Lang.ServiceOpParamText", typeof(ServiceOpParamText).Assembly);
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
        ///   Looks up a localized string similar to The data (in JSON format) for the new Class..
        /// </summary>
        internal static string Modify_Classes_Data {
            get {
                return ResourceManager.GetString("Modify_Classes_Data", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The data (in JSON format) for the new Factor..
        /// </summary>
        internal static string Modify_Factors_Data {
            get {
                return ResourceManager.GetString("Modify_Factors_Data", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The data (in JSON format) for the new Instance..
        /// </summary>
        internal static string Modify_Instances_Data {
            get {
                return ResourceManager.GetString("Modify_Instances_Data", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The data (in JSON format) for the new Member..
        /// </summary>
        internal static string Modify_Members_Data {
            get {
                return ResourceManager.GetString("Modify_Members_Data", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The data (in JSON format) for the new Url..
        /// </summary>
        internal static string Modify_Urls_Data {
            get {
                return ResourceManager.GetString("Modify_Urls_Data", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The App ID value (an integer) for the App making the request. This parameter is only used by the &apos;[[Client Credentials|Oper|Oauth.AccessTokenClientCredentials]]&apos; flow..
        /// </summary>
        internal static string Oauth_AccessToken_ClientId {
            get {
                return ResourceManager.GetString("Oauth_AccessToken_ClientId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The authorization code obtained after a successful OAuth entry process. This parameter is only used by the &apos;[[Authorization Code|Oper|Oauth.AccessTokenAuthCode]]&apos; flow..
        /// </summary>
        internal static string Oauth_AccessToken_Code {
            get {
                return ResourceManager.GetString("Oauth_AccessToken_Code", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Defines the desired access token flow.  The three accepted (case-sensitive) values are &apos;[[authorization_code|Oper|Oauth.AccessTokenAuthCode]]&apos;, &apos;[[refresh|Oper|Oauth.AccessTokenRefresh]]&apos;, and &apos;[[client_credentials|Oper|Oauth.AccessTokenClientCredentials]]&apos;..
        /// </summary>
        internal static string Oauth_AccessToken_GrantType {
            get {
                return ResourceManager.GetString("Oauth_AccessToken_GrantType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This value must be exactly the same as the redirect URI provided for the OAuth entry process..
        /// </summary>
        internal static string Oauth_AccessToken_RedirectUri {
            get {
                return ResourceManager.GetString("Oauth_AccessToken_RedirectUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The refresh token obtained after a successful &apos;[[Authorization Code|Oper|Oauth.AccessTokenAuthCode]]&apos; access token flow.  A refresh token only applies to User-based OAuth sessions, not for App-based OAuth sessions.  This parameter is only used by the &apos;[[Refresh|Oper|Oauth.AccessTokenRefresh]]&apos; flow..
        /// </summary>
        internal static string Oauth_AccessToken_Refresh {
            get {
                return ResourceManager.GetString("Oauth_AccessToken_Refresh", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The alpha-numeric Secret for the App making the request. This verifies that the App itself is making the request, and not an imposter.  For this reason, the secret code should not be shared with anyone..
        /// </summary>
        internal static string Oauth_AccessToken_Secret {
            get {
                return ResourceManager.GetString("Oauth_AccessToken_Secret", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The ID of the Fabric App making the OAuth Login request.  The access code provided after a successful OAuth process will be associated with this App ID and the authenticated User&apos;s ID..
        /// </summary>
        internal static string Oauth_Login_ClientId {
            get {
                return ResourceManager.GetString("Oauth_Login_ClientId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The URL which will receive success/error redirects from the OAuth Login process.  This URL should handle the following query-string parameters: access_code, error, error_description, state..
        /// </summary>
        internal static string Oauth_Login_RedirUri {
            get {
                return ResourceManager.GetString("Oauth_Login_RedirUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes which type of authentication should be performed. For now, this value should always be &apos;code&apos;. Fabric may accept more response types in the future..
        /// </summary>
        internal static string Oauth_Login_ResponseType {
            get {
                return ResourceManager.GetString("Oauth_Login_ResponseType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the level of access the App will have to the User&apos;s account.  This value is required by the OAuth 2.0 specification, however, Fabric currently ignores it.  All OAuth requests currently receive the same level of access to the User&apos;s account.  Fabric may begin using this parameter in the future..
        /// </summary>
        internal static string Oauth_Login_Scope {
            get {
                return ResourceManager.GetString("Oauth_Login_Scope", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides a security function for a Fabric App.  All success/message redirect responses include a &apos;state&apos; query-string parameter.  The App should check this value against the state value provided in the initial request.  The two values should always be equal. If the values are not equal, then the redirect did not come from the Fabric OAuth process (or from a different user&apos;s process), and should be handled accordingly..
        /// </summary>
        internal static string Oauth_Login_State {
            get {
                return ResourceManager.GetString("Oauth_Login_State", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Causes the login process to behave in different ways.  If a value of &apos;1&apos; is provided, the user will see the login page even if they are currently authenticated with Fabric.  This is useful shared-computer scenarios, where the most-recently authenticated user may be different from the user making the current request..
        /// </summary>
        internal static string Oauth_Login_Switch {
            get {
                return ResourceManager.GetString("Oauth_Login_Switch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The access token for the desired OAuth session. This request will fail if the token has already been invalidated by a previous logout..
        /// </summary>
        internal static string Oauth_Logout_Token {
            get {
                return ResourceManager.GetString("Oauth_Logout_Token", resourceCulture);
            }
        }
    }
}
