﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoQA {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Locators {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Locators() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DemoQA.Locators", typeof(Locators).Assembly);
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
        ///   Looks up a localized string similar to #userName-value.
        /// </summary>
        internal static string accountUsername {
            get {
                return ResourceManager.GetString("accountUsername", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //div[@class=&apos;main-header&apos;].
        /// </summary>
        internal static string bookPage {
            get {
                return ResourceManager.GetString("bookPage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //h5[contains(text(),&apos;Book Store Application&apos;)].
        /// </summary>
        internal static string bookStoreApp {
            get {
                return ResourceManager.GetString("bookStoreApp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //div[@class=&apos;main-header&apos;].
        /// </summary>
        internal static string bookStorePage {
            get {
                return ResourceManager.GetString("bookStorePage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to arguments[0].click().
        /// </summary>
        internal static string JsClick {
            get {
                return ResourceManager.GetString("JsClick", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to arguments[0].scrollIntoView(true).
        /// </summary>
        internal static string JsScrollView {
            get {
                return ResourceManager.GetString("JsScrollView", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to login.
        /// </summary>
        internal static string login {
            get {
                return ResourceManager.GetString("login", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //h5[contains(text(),&apos;Login in Book Store&apos;)].
        /// </summary>
        internal static string loginWelcomePg {
            get {
                return ResourceManager.GetString("loginWelcomePg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //button[contains(text(),&apos;Log out&apos;)].
        /// </summary>
        internal static string logOut {
            get {
                return ResourceManager.GetString("logOut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to password.
        /// </summary>
        internal static string password {
            get {
                return ResourceManager.GetString("password", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #login.
        /// </summary>
        internal static string userLogin {
            get {
                return ResourceManager.GetString("userLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to userName.
        /// </summary>
        internal static string username {
            get {
                return ResourceManager.GetString("username", resourceCulture);
            }
        }
    }
}