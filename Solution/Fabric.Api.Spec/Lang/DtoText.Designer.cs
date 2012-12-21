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
    internal class DtoText {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DtoText() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fabric.Api.Spec.Lang.DtoText", typeof(DtoText).Assembly);
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
        ///   Looks up a localized string similar to The {{Item}} is one of seven Artifact Owners. Each {{Item}}-owned Artifact {{Access}} and {{Talk}}..
        /// </summary>
        internal static string _ArtItem_Main {
            get {
                return ResourceManager.GetString("_ArtItem_Main", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to is accessible only to the User who created it.
        /// </summary>
        internal static string _ArtItem_Private {
            get {
                return ResourceManager.GetString("_ArtItem_Private", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to is publicly accessible.
        /// </summary>
        internal static string _ArtItem_Public {
            get {
                return ResourceManager.GetString("_ArtItem_Public", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to can have either public or private accessibility.
        /// </summary>
        internal static string _ArtItem_VariedAccess {
            get {
                return ResourceManager.GetString("_ArtItem_VariedAccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The essential data for a particular {{Item}}..
        /// </summary>
        internal static string _Core_Common {
            get {
                return ResourceManager.GetString("_Core_Common", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Current version information for the Fabric API. 
        ///
        ///The API versioning format is: &apos;Major.Minor.ReleaseIndex.Build&apos;. Major, Minor, and ReleaseIndex values are sequential integer values. Minor resets to zero after each Major increase. ReleaseIndex resets to zero after each Minor increase. Build is a 12-character hashtag, and can typically be ignored.
        ///
        ///In general, each increment of...
        ///- ReleaseIndex represents internal improvements and fixes.
        ///- Minor represents external additions, such as a new API request [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string _Version {
            get {
                return ResourceManager.GetString("_Version", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A registered project, application, or business that has direct access to the Fabric API.
        ///
        ///An !App&apos;s primary purpose is to facilitate User interaction with Fabric. To accomplish this, an !App typically creates an interface for its Users. This interface hides the complex details of the Fabric API, and instead provides intuitive features like custom inputs, searches, summaries, and visualizations. 
        ///
        ///When a User becomes a Member of an !App, they are granting that !App permission to perform various actions o [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string App {
            get {
                return ResourceManager.GetString("App", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An object which is able to (via Factor connections) accumulate meaning, context, user sentiment, and relationships.  !Artifacts and Factors are the central components of the Fabric architecture.
        ///
        ///Every !Artifact maps exclusively to one other item in the Fabric architecture (such as an App, Crowd, or User). Fabric generates an !Artifact automatically each time a new !Artifact-enabled item is created.  Technically, each of these items &apos;has&apos; an associated !Artifact. However, due to the item&apos;s exclusive owner [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Artifact {
            get {
                return ResourceManager.GetString("Artifact", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string ArtifactOwnerNode {
            get {
                return ResourceManager.GetString("ArtifactOwnerNode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the object type associated with a particular Artifact. Example types include: !App, !Thing, !Comment, etc..
        /// </summary>
        internal static string ArtifactType {
            get {
                return ResourceManager.GetString("ArtifactType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A group or collection of Users. The members of a !Crowd are called Crowdians.
        ///
        ///A !Crowd can be public or private. A public !Crowd and its Crowdians are accessible to all Apps and Users. A private !Crowd (also called a &apos;Circle&apos;) is only accessible to the User who created it.
        ///
        ///A public !Crowd can be open or restricted. An open !Crowd does not require an invitation to join.  A restricted !Crowd requires an invitation.
        ///
        ///!Crowds are useful on many levels, as they:
        ///- allow like-minded Users to connect and  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Crowd {
            get {
                return ResourceManager.GetString("Crowd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A User who is a member of a particular Crowd. The Crowd administrator(s) can grant various access privileges to a !Crowdian by adjusting its CrowdianType.
        ///
        ///If desired, the Crowd administrator(s) can also apply a weighting value to each !Crowdian. When performing data analysis on a Crowd, this value allows each !Crowdian to have a different level of impact on the results. A high weighting value equates to high Crowdian imact.
        ///
        ///There are various restrictions (based on Crowd properties) for !Crowdian creat [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Crowdian {
            get {
                return ResourceManager.GetString("Crowdian", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the level of access and control given to a particular Crowdian. Example types include: Invite, !Member, Admin, etc..
        /// </summary>
        internal static string CrowdianType {
            get {
                return ResourceManager.GetString("CrowdianType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string CrowdianTypeAssign {
            get {
                return ResourceManager.GetString("CrowdianTypeAssign", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes and refines the relationship between the two Artifacts of a particular Factor.
        ///
        ///The primary purpose of a !Descriptor is to describe the relationship between a Factor&apos;s primary Artifact and related Artifact. The DescriptorType provides this description, establishing meaningful connections like a A &apos;is a&apos; B, or C &apos;sounds like&apos; D.
        ///
        ///The Artifact relationship (defined by a Factor) is directional, flowing from the primary Artifact to the related Artifact. The DescriptorType, therefore, must coordina [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Descriptor {
            get {
                return ResourceManager.GetString("Descriptor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides meaning (via Descriptor) to the relationship between the two Artifacts in a particular Factor. Example types include: Is A, Refers To, Sounds Like, etc..
        /// </summary>
        internal static string DescriptorType {
            get {
                return ResourceManager.GetString("DescriptorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creates a directional, action-based pathway between the two Artifacts of a particular Factor.
        ///
        ///The nature of a !Director&apos;s pathway depends on its DirectorType. The !Director can  represent a factual, well-defined path, a virtual link, a suggested flow, etc.
        ///
        ///A !Director specifies a DirectorAction for each of the Factor&apos;s Artifacts, which give additional meaning to the !Director&apos;s pathway. The primary action is meant to be performed on the primary Artifact before the pathway begins. The related action is [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Director {
            get {
                return ResourceManager.GetString("Director", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes an action to be taken (via Director) on one of the two Artifacts in a particular Factor. Example actions include: Read, Learn, Obtain, etc..
        /// </summary>
        internal static string DirectorAction {
            get {
                return ResourceManager.GetString("DirectorAction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides meaning (via Director) to the directional connection between the two Artifacts in a particular Factor. Example types include: Hyperlink, Suggested Path, Defined Path, etc..
        /// </summary>
        internal static string DirectorType {
            get {
                return ResourceManager.GetString("DirectorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to When a fault or error occurs, a !FabError is returned in place of the expected response data. The information it provides should help determine what caused the issue for the given request..
        /// </summary>
        internal static string Error {
            get {
                return ResourceManager.GetString("Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Applies the concept of time to a particular Factor.
        ///
        ///An !Eventor places a Factor at a specific point in time and describes why it is significant to the Factor. The EventorType provides this significance, establishing that this particular point in time is when the Factor started, occurred, is expected, etc.
        ///
        ///Each !Eventor represents one particular point in time, however, the precision of that point in time can vary. The EventorPrecision allows a point in time to specify a level of accuracy ranging from o [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Eventor {
            get {
                return ResourceManager.GetString("Eventor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the level of date/time precision (via Eventor) given to a particular Factor. Example precisions include: Year, Day, Second, etc..
        /// </summary>
        internal static string EventorPrecision {
            get {
                return ResourceManager.GetString("EventorPrecision", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides temporal significance (via Eventor) for a particular Factor.  Example types include: Start, Occur, Expected, etc..
        /// </summary>
        internal static string EventorType {
            get {
                return ResourceManager.GetString("EventorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides a specific piece of information, knowledge, or opinion about a pair of Artifacts. !Factors and Artifacts are the central components of the Fabric architecture.
        ///
        ///A !Factor forms a directional relationship from its primary Artifact to its related Artifact. There are various !Factor-related components (known as !Factor Elements) available. Each has a specific ability to refine, describe, and/or supplement this Artifact relationship in a meaningful way.
        ///
        ///The six !Factor Elements are called Descript [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Factor {
            get {
                return ResourceManager.GetString("Factor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the type of information (and/or level of confidence) provided by a particular Factor. Example assertions include: Fact, Opinion, Guess, etc..
        /// </summary>
        internal static string FactorAssertion {
            get {
                return ResourceManager.GetString("FactorAssertion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {{Item}} is one of six Factor Elements. Each Element provides a specific type of meaning to a Factor..
        /// </summary>
        internal static string FactorElem_Main {
            get {
                return ResourceManager.GetString("FactorElem_Main", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string FactorElementNode {
            get {
                return ResourceManager.GetString("FactorElementNode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The base class for all Fault objects..
        /// </summary>
        internal static string Fault {
            get {
                return ResourceManager.GetString("Fault", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Applies a name or identifier to a particular Factor.
        ///
        ///An !Identor attaches a text-based value to a Factor. This value can represent a a full name, a nickname, a globally-unique identifier, a reference key to some other system, etc.
        ///
        ///The IdentorType hints at the purpose or intent of the !Identor. A &apos;Text&apos; IdentorType is typically meant to provide enhanced search capabilities (like finding a person by an alternate name) or some other organizational use.  A &apos;Key&apos; IdentorType is typically meant to associate [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Identor {
            get {
                return ResourceManager.GetString("Identor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides a hint about the text (via Identor) that identifies a particular Factor. Example types include: Text, Key, etc..
        /// </summary>
        internal static string IdentorType {
            get {
                return ResourceManager.GetString("IdentorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A word, phrase, code, or other text-based value.
        ///
        ///!Labels are less formal (and less effective) than a Thing, and should only be used in certain circumstances.  For example, some value or code (like &apos;A-1234&apos; or &apos;study for science test&apos;) might have a useful purpose for a particular User..
        /// </summary>
        internal static string Label {
            get {
                return ResourceManager.GetString("Label", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Positions a Factor using geographic or relative coordinates.
        ///
        ///A !Locator attaches a three-dimensional coordinate to a Factor. The LocatorType defines the spatial context of the coordinate, supporting both geographic and relative positioning.
        ///
        ///Geographic coordinates represent a position on a sphere, like Earth.  They use X for longitude, Y for latitude, and Z for elevation (in metres above sea level). Use zero for elevation if it is not known or specified.
        ///[(EX|Geographic Example|_Objective:_
        ///Specify t [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Locator {
            get {
                return ResourceManager.GetString("Locator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides spatial context and boundaries (via Locator) for a particular Factor. Example types include: Earth Coordinate, Mars Coordinate, Relative 3D Position, etc..
        /// </summary>
        internal static string LocatorType {
            get {
                return ResourceManager.GetString("LocatorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An association between a User and an App. The App administrator(s) can grant various access privileges to a !Member by adjusting its MemberType.
        ///
        ///Every item added to Fabric is associated with a particular !Member. Thus, Fabric can determine which App or User is responsible for any particular item, enforce applicable access rights, analyze the data for a particular App and/or User, etc..
        /// </summary>
        internal static string Member {
            get {
                return ResourceManager.GetString("Member", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Describes the level of access and control given to a particular Member.  Example types include: !Member, Admin, Data Provider, etc..
        /// </summary>
        internal static string MemberType {
            get {
                return ResourceManager.GetString("MemberType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string MemberTypeAssign {
            get {
                return ResourceManager.GetString("MemberTypeAssign", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string Node {
            get {
                return ResourceManager.GetString("Node", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string NodeForAction {
            get {
                return ResourceManager.GetString("NodeForAction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string NodeForType {
            get {
                return ResourceManager.GetString("NodeForType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string Oauth {
            get {
                return ResourceManager.GetString("Oauth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides an OAuth access token and other related information. Every Fabric API request requires an access token. To include an OAuth access token with a FabricAPI request, add an &quot;Authorization&quot; header to the HTTP request with a value of &quot;Bearer=[your OAuth access code here]&quot;..
        /// </summary>
        internal static string OauthAccess {
            get {
                return ResourceManager.GetString("OauthAccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To comply with the OAuth 2.0 specification, all Fabric OAuth requests return a FabOauthError (instead of FabFault or FabError) when errors occur..
        /// </summary>
        internal static string OauthError {
            get {
                return ResourceManager.GetString("OauthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This DTO is unique -- the API never returns this object directly. Instead, the properties shown below are included as query-string parameters for a redirect URI. This URI is provided by an App, and the App is responsible for accepting (and reacting to) the incoming redirect.
        ///
        ///This redirect is used in one particular scenario: the [[OAuth login process|Req|oauth.get]]. After the user completes this process, Fabric performs a redirect with success or failure information.  The success redirect includes the &apos;c [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string OauthLogin {
            get {
                return ResourceManager.GetString("OauthLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The result of an OAuth logout..
        /// </summary>
        internal static string OauthLogout {
            get {
                return ResourceManager.GetString("OauthLogout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The API response wrapper; contains the Data payload and other metadata..
        /// </summary>
        internal static string Response {
            get {
                return ResourceManager.GetString("Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string Root {
            get {
                return ResourceManager.GetString("Root", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Represents any item (real, imaginary, virtual, conceptual, or otherwise) that an App or User can define and/or use to generate meaning. A !Thing is the primary method for generating new Artifacts. There are two distinct !Thing types: Class and Instance.
        ///[(EX|Documentation Note|To explain the !Thing DTO more intuitively, this documentation simplifies some concepts of the Fabric architecture. Please be aware of the full complexity:
        ///- A !Thing receives Factors via its associated Artifact.
        ///- Each Factor refe [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Thing {
            get {
                return ResourceManager.GetString("Thing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A hyperlink or path (uniform resource locator) to some web page, a file, or some other type of content.
        ///
        ///While a !Url does have an associated Artifact, it should be used with certain constraints. Consider an scenario where a !Url leads to web page with a news article and a photo. The proper prodedure is to create a new Thing for both the news article and photo. With this method:
        ///- The news article and photo (via their Artifacts) can receive Factors independently.
        ///- The !Url (via its Artifact) should onl [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Url {
            get {
                return ResourceManager.GetString("Url", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A registered Fabric account that has indirect access (via Apps) to the Fabric API. A !User can become a Member of an App, and then use the App&apos;s interface to interact with Fabric. An App&apos;s interface hides the complex details of the Fabric API, and instead provides intuitive features like custom inputs, searches, summaries, and visualizations. 
        ///
        ///!Users control their private account data and preferences using the Fabric website.
        ///
        ///Every item added to Fabric is associated with (via Member) a !User and and a [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string User {
            get {
                return ResourceManager.GetString("User", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Applies a meaningful numeric axis and value to a particular Factor.
        ///
        ///A !Vector attaches a numeric value to a Factor, using an arbitrary Artifact to define its &apos;axis&apos;. This axis depends entirely upon the !Vector&apos;s purpose. For example, a factual !Vector might use an Artifact like &apos;Height&apos; or &apos;Shutter Speed&apos;. A !Vector that provides an opinion might use an Artifact like &apos;Quality&apos; or &apos;Excitement&apos;. While the choice of an axis Artififact is not restricted, it can be beneficial to use Artifacts which are other  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Vector {
            get {
                return ResourceManager.GetString("Vector", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides meaning (using relatively-positioned points/labels) across the numerical range of a particular VectorType. Example ranges include: Negative Numeric, Full Agreement, Positive Favorability, etc..
        /// </summary>
        internal static string VectorRange {
            get {
                return ResourceManager.GetString("VectorRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A relatively-positioned point which provides meaning to a numerical range. Example levels include: Maximum, Somewhat Disagree, Mostly Favorable, etc..
        /// </summary>
        internal static string VectorRangeLevel {
            get {
                return ResourceManager.GetString("VectorRangeLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides meaning and boundaries (via Vector) for a numeric value given to a particular Factor. Example types include: Full Percentage, Standard Agreement, Opposable Favorability, etc..
        /// </summary>
        internal static string VectorType {
            get {
                return ResourceManager.GetString("VectorType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides a unit of measurement for the numeric value of a particular Vector. Example units include: Metre, Second, Byte, etc..
        /// </summary>
        internal static string VectorUnit {
            get {
                return ResourceManager.GetString("VectorUnit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TODO.
        /// </summary>
        internal static string VectorUnitDerived {
            get {
                return ResourceManager.GetString("VectorUnitDerived", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provides a level of magnitude for the numeric value of a particular Vector. Example unit prefixes include: Kilo, Nano, Gibi, etc..
        /// </summary>
        internal static string VectorUnitPrefix {
            get {
                return ResourceManager.GetString("VectorUnitPrefix", resourceCulture);
            }
        }
    }
}
