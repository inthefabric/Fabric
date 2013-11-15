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
    internal class ServiceOpText {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ServiceOpText() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fabric.New.Api.Lang.ServiceOpText", typeof(ServiceOpText).Assembly);
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
        ///   Looks up a localized string similar to Get the latest specifications and documentation for all Fabric API services. This is useful for building Fabric API clients and reference documentation sites like the one you are viewing right now..
        /// </summary>
        internal static string Meta_Spec_GET {
            get {
                return ResourceManager.GetString("Meta_Spec_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Get the current Fabric server time..
        /// </summary>
        internal static string Meta_Time_GET {
            get {
                return ResourceManager.GetString("Meta_Time_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Get the current Fabric version..
        /// </summary>
        internal static string Meta_Version_GET {
            get {
                return ResourceManager.GetString("Meta_Version_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Class. Attach Factors to this Class immediately after creation to give it meaning and relevance within Fabric..
        /// </summary>
        internal static string Modify_Classes_POST {
            get {
                return ResourceManager.GetString("Modify_Classes_POST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Factor. The Factor begins in the &apos;incomplete&apos; state, with no FactorElements attached..
        /// </summary>
        internal static string Modify_Factors_POST {
            get {
                return ResourceManager.GetString("Modify_Factors_POST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Instance. Attach Factors to this Instance immediately after creation to give it meaning and relevance within Fabric..
        /// </summary>
        internal static string Modify_Instances_POST {
            get {
                return ResourceManager.GetString("Modify_Instances_POST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string Modify_Members_POST {
            get {
                return ResourceManager.GetString("Modify_Members_POST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Url..
        /// </summary>
        internal static string Modify_Urls_POST {
            get {
                return ResourceManager.GetString("Modify_Urls_POST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Get an OAuth access token using one of four &apos;flows&apos;.  Fabric offers separate requests for these access token flows, but also provides this generic request for compatibility with the OAuth 2.0 specification.  See the other access token flows (such as the &apos;[[Client Credentials|Oper|Oauth.AccessTokenClientCredentials]]&apos; flow) for information about the available OAuth flows.
        ///
        ///An OAuth access token must be included with every Fabric API request (with the exception of the OAuth requests).  This token is the res [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Oauth_AccessToken_GET {
            get {
                return ResourceManager.GetString("Oauth_AccessToken_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This OAuth flow should be used immediately after obtaining an authorization code from the OAuth entry process. Fabric verifies the authorization code, determines the associated App and User IDs, and generates a new access token.
        ///
        ///See [[Access Token|Oper|Oauth.AccessToken]] for general information about the OAuth process..
        /// </summary>
        internal static string Oauth_AccessTokenAuthCode_GET {
            get {
                return ResourceManager.GetString("Oauth_AccessTokenAuthCode_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This OAuth flow should be used to begin an OAuth session for your Fabric App. This flow does not require an authorization code from the typical OAuth entry process.
        ///
        ///See [[Access Token|Oper|Oauth.AccessToken]] or general information about the OAuth process..
        /// </summary>
        internal static string Oauth_AccessTokenClientCredentials_GET {
            get {
                return ResourceManager.GetString("Oauth_AccessTokenClientCredentials_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This OAuth flow should be used to begin an OAuth session for your Fabric App&apos;s Data Provider User. This flow does not require an authorization code from the typical OAuth entry process. Note: this flow is not defined by the OAuth 2.0 specification; it is specifically designed to meet a Fabric App&apos;s OAuth needs.
        ///
        ///See [[Access Token|Oper|Oauth.AccessToken]] for general information about the OAuth process..
        /// </summary>
        internal static string Oauth_AccessTokenClientDataProv_GET {
            get {
                return ResourceManager.GetString("Oauth_AccessTokenClientDataProv_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This OAuth flow should be used to refresh an expired access token. If the refresh token is valid, Fabric generates new access and refresh tokens for the given OAuth session. This process also invalidates the original refresh token.
        ///
        ///App-only access tokens (obtained with the &apos;[[Client Credentials|Oper|Oauth.AccessTokenClientCredentials]]&apos; flow) should not be refreshed; the App should simply request a new access token.
        ///
        ///See [[Access Token|Oper|Oauth.AccessToken]] for general information about the OAuth pr [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Oauth_AccessTokenRefresh_GET {
            get {
                return ResourceManager.GetString("Oauth_AccessTokenRefresh_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This API request is unique -- it represents the entry point for Fabric&apos;s OAuth 2.0 authentication process.  Instead of making this API request directly from a Fabric App, the App should provide a link so that its users can load this request&apos;s URL (including the required query-string parameters) in their browser.
        ///
        ///A web-based Fabric App would typically load this OAuth entry page as a browser popup window. Once the user completes the full OAuth process (or upon an error), Fabric will redirect the browser to [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Oauth_Login_GET {
            get {
                return ResourceManager.GetString("Oauth_Login_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Terminates a particular OAuth session by invalidating the session&apos;s access token. Any further OAuth requests made with this particular access token are rejected.
        ///
        ///Logging out of an OAuth session does not revoke the the App scope accepted by the User (during the first OAuth login process).  Furthermore, it does not end the User&apos;s authenticated session with Fabric.  Thus, a subsequent OAuth entry by the same user may actually require zero input from the user -- they could potentially bypass both OAuth entry [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Oauth_Logout_GET {
            get {
                return ResourceManager.GetString("Oauth_Logout_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Begins a traversal with an App entry point..
        /// </summary>
        internal static string Traversal_Apps_GET {
            get {
                return ResourceManager.GetString("Traversal_Apps_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Begins a traversal with an Artifact entry point..
        /// </summary>
        internal static string Traversal_Artifacts_GET {
            get {
                return ResourceManager.GetString("Traversal_Artifacts_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Begins a traversal with an Class entry point..
        /// </summary>
        internal static string Traversal_Classes_GET {
            get {
                return ResourceManager.GetString("Traversal_Classes_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Begins a traversal with an Factor entry point..
        /// </summary>
        internal static string Traversal_Factors_GET {
            get {
                return ResourceManager.GetString("Traversal_Factors_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Begins a traversal with an Instance entry point..
        /// </summary>
        internal static string Traversal_Instances_GET {
            get {
                return ResourceManager.GetString("Traversal_Instances_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Begins a traversal with an Member entry point..
        /// </summary>
        internal static string Traversal_Members_GET {
            get {
                return ResourceManager.GetString("Traversal_Members_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Begins a traversal with an Url entry point..
        /// </summary>
        internal static string Traversal_Urls_GET {
            get {
                return ResourceManager.GetString("Traversal_Urls_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Begins a traversal with an User entry point..
        /// </summary>
        internal static string Traversal_Users_GET {
            get {
                return ResourceManager.GetString("Traversal_Users_GET", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Begins a traversal with an Vertex entry point..
        /// </summary>
        internal static string Traversal_Vertices_GET {
            get {
                return ResourceManager.GetString("Traversal_Vertices_GET", resourceCulture);
            }
        }
    }
}
