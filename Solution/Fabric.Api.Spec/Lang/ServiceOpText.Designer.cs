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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fabric.Api.Spec.Lang.ServiceOpText", typeof(ServiceOpText).Assembly);
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
        ///   Looks up a localized string similar to Create a new App..
        /// </summary>
        internal static string Modify_AddApp {
            get {
                return ResourceManager.GetString("Modify_AddApp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Class. Attach Factors to this Class immediately after creation to give it meaning and relevance within Fabric..
        /// </summary>
        internal static string Modify_AddClass {
            get {
                return ResourceManager.GetString("Modify_AddClass", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Factor. The Factor begins in the &apos;incomplete&apos; state, with no FactorElements attached..
        /// </summary>
        internal static string Modify_AddFactor {
            get {
                return ResourceManager.GetString("Modify_AddFactor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Instance. Attach Factors to this Instance immediately after creation to give it meaning and relevance within Fabric..
        /// </summary>
        internal static string Modify_AddInstance {
            get {
                return ResourceManager.GetString("Modify_AddInstance", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Url..
        /// </summary>
        internal static string Modify_AddUrl {
            get {
                return ResourceManager.GetString("Modify_AddUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new User..
        /// </summary>
        internal static string Modify_AddUser {
            get {
                return ResourceManager.GetString("Modify_AddUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Descriptor and attach it to the specified Factor..
        /// </summary>
        internal static string Modify_AttachDescriptorToFactor {
            get {
                return ResourceManager.GetString("Modify_AttachDescriptorToFactor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Director and attach it to the specified Factor..
        /// </summary>
        internal static string Modify_AttachDirectorToFactor {
            get {
                return ResourceManager.GetString("Modify_AttachDirectorToFactor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Eventor and attach it to the specified Factor..
        /// </summary>
        internal static string Modify_AttachEventorToFactor {
            get {
                return ResourceManager.GetString("Modify_AttachEventorToFactor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Identor and attach it to the specified Factor..
        /// </summary>
        internal static string Modify_AttachIdentorToFactor {
            get {
                return ResourceManager.GetString("Modify_AttachIdentorToFactor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Locator and attach it to the specified Factor..
        /// </summary>
        internal static string Modify_AttachLocatorToFactor {
            get {
                return ResourceManager.GetString("Modify_AttachLocatorToFactor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a new Vector and attach it to the specified Factor..
        /// </summary>
        internal static string Modify_AttachVectorToFactor {
            get {
                return ResourceManager.GetString("Modify_AttachVectorToFactor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Move a Factor from the &apos;incomplete&apos; state to the &apos;complete&apos; state.  A Factor must have a Descriptor before it can be completed. Once a Factor is completed, it can only be deleted -- no further modifications are permitted..
        /// </summary>
        internal static string Modify_CompleteFactor {
            get {
                return ResourceManager.GetString("Modify_CompleteFactor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete a Factor..
        /// </summary>
        internal static string Modify_DeleteFactor {
            get {
                return ResourceManager.GetString("Modify_DeleteFactor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Get an OAuth access token using one of four &apos;flows&apos;.  Fabric offers separate requests for these access token flows, but also provides this generic request for compatibility with the OAuth 2.0 specification.  See the other access token flows (such as the &apos;[[Client Credentials|Func|Oauth.AccessTokenClientCredentials]]&apos; flow) for information about the available OAuth flows.
        ///
        ///An OAuth access token must be included with every Fabric API request (with the exception of the OAuth requests).  This token is the res [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Oauth_AccessToken {
            get {
                return ResourceManager.GetString("Oauth_AccessToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This OAuth flow should be used immediately after obtaining an authorization code from the OAuth entry process. Fabric verifies the authorization code, determines the associated App and User IDs, and generates a new access token.
        ///
        ///See [[Access Token|Func|Oauth.AccessToken]] for general information about the OAuth process..
        /// </summary>
        internal static string Oauth_AccessTokenAuthCode {
            get {
                return ResourceManager.GetString("Oauth_AccessTokenAuthCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This OAuth flow should be used to begin an OAuth session for your Fabric App. This flow does not require an authorization code from the typical OAuth entry process.
        ///
        ///See [[Access Token|Func|Oauth.AccessToken]] or general information about the OAuth process..
        /// </summary>
        internal static string Oauth_AccessTokenClientCredentials {
            get {
                return ResourceManager.GetString("Oauth_AccessTokenClientCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This OAuth flow should be used to begin an OAuth session for your Fabric App&apos;s Data Provider User. This flow does not require an authorization code from the typical OAuth entry process. Note: this flow is not defined by the OAuth 2.0 specification; it is specifically designed to meet a Fabric App&apos;s OAuth needs.
        ///
        ///See [[Access Token|Func|Oauth.AccessToken]] for general information about the OAuth process..
        /// </summary>
        internal static string Oauth_AccessTokenClientDataProv {
            get {
                return ResourceManager.GetString("Oauth_AccessTokenClientDataProv", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This OAuth flow should be used to refresh an expired access token. If the refresh token is valid, Fabric generates new access and refresh tokens for the given OAuth session. This process also invalidates the original refresh token.
        ///
        ///App-only access tokens (obtained with the &apos;[[Client Credentials|Func|Oauth.AccessTokenClientCredentials]]&apos; flow) should not be refreshed; the App should simply request a new access token.
        ///
        ///See [[Access Token|Func|Oauth.AccessToken]] for general information about the OAuth pr [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Oauth_AccessTokenRefresh {
            get {
                return ResourceManager.GetString("Oauth_AccessTokenRefresh", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This API request is unique -- it represents the entry point for Fabric&apos;s OAuth 2.0 authentication process.  Instead of making this API request directly from a Fabric App, the App should provide a link so that its users can load this request&apos;s URL (including the required query-string parameters) in their browser.
        ///
        ///A web-based Fabric App would typically load this OAuth entry page as a browser popup window. Once the user completes the full OAuth process (or upon an error), Fabric will redirect the browser to [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Oauth_Login {
            get {
                return ResourceManager.GetString("Oauth_Login", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Terminates a particular OAuth session by invalidating the session&apos;s access token. Any further OAuth requests made with this particular access token are rejected.
        ///
        ///Logging out of an OAuth session does not revoke the the App scope accepted by the User (during the first OAuth login process).  Furthermore, it does not end the User&apos;s authenticated session with Fabric.  Thus, a subsequent OAuth entry by the same user may actually require zero input from the user -- they could potentially bypass both OAuth entry [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Oauth_Logout {
            get {
                return ResourceManager.GetString("Oauth_Logout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The latest specification and documentation for all Fabric API services. This is useful for building Fabric API clients and reference documentation sites like the one you are viewing right now..
        /// </summary>
        internal static string Spec_Document {
            get {
                return ResourceManager.GetString("Spec_Document", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The starting point for all traversal queries. Use traversal links and traversal functions to navigate through Fabric&apos;s objects. These links and functions are capable of performing both simple and highly complex queries..
        /// </summary>
        internal static string Traversal_Root {
            get {
                return ResourceManager.GetString("Traversal_Root", resourceCulture);
            }
        }
    }
}
