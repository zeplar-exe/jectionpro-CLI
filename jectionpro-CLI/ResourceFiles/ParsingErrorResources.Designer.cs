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
    internal class ParsingErrorResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ParsingErrorResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("jectionpro_CLI.ResourceFiles.ParsingErrorResources", typeof(ParsingErrorResources).Assembly);
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
        ///   Looks up a localized string similar to This command has not been implemented yet..
        /// </summary>
        internal static string CommandNotImplemented {
            get {
                return ResourceManager.GetString("CommandNotImplemented", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name cannot be empty..
        /// </summary>
        internal static string EmptyName {
            get {
                return ResourceManager.GetString("EmptyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This directory you are trying to read does not exist..
        /// </summary>
        internal static string InvalidDirectory {
            get {
                return ResourceManager.GetString("InvalidDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The project you are trying to open does not have a valid proj.xml file..
        /// </summary>
        internal static string InvalidProjXML {
            get {
                return ResourceManager.GetString("InvalidProjXML", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The project you are trying to open does not have a proj.xml file..
        /// </summary>
        internal static string MissingProjXML {
            get {
                return ResourceManager.GetString("MissingProjXML", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A project already exists in this directory. Use -f|--force if you would like to overwrite it..
        /// </summary>
        internal static string ProjectExistsError {
            get {
                return ResourceManager.GetString("ProjectExistsError", resourceCulture);
            }
        }
    }
}
