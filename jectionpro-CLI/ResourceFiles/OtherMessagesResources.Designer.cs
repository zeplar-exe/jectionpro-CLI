﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace jectionpro_CLI.ResourceFiles {
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
    internal class OtherMessagesResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal OtherMessagesResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("jectionpro_CLI.ResourceFiles.OtherMessagesResources", typeof(OtherMessagesResources).Assembly);
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
        ///   Looks up a localized string similar to Closed list {0}.
        /// </summary>
        internal static string ListClosed {
            get {
                return ResourceManager.GetString("ListClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Opened {0}.
        /// </summary>
        internal static string ListOpened {
            get {
                return ResourceManager.GetString("ListOpened", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Opened {0}.
        /// </summary>
        internal static string OpenedPin {
            get {
                return ResourceManager.GetString("OpenedPin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Moved pin {0} to list {1}.
        /// </summary>
        internal static string PinMoved {
            get {
                return ResourceManager.GetString("PinMoved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Some results may be omitted due to file access restrictions..
        /// </summary>
        internal static string ResultsOmitted {
            get {
                return ResourceManager.GetString("ResultsOmitted", resourceCulture);
            }
        }
    }
}
