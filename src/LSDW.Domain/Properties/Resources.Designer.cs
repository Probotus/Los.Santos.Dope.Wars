﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LSDW.Domain.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LSDW.Domain.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to The price of a drug can not be smaller than zero. Value: &apos;{0}&apos;.
        /// </summary>
        internal static string Exception_Drug_Add {
            get {
                return ResourceManager.GetString("Exception.Drug.Add", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The resulting quantity of a drug can not be smaller than zero. Value: &apos;{0}&apos;.
        /// </summary>
        internal static string Exception_Drug_Remove {
            get {
                return ResourceManager.GetString("Exception.Drug.Remove", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DEA is on your tail, get off your ass and get to safety!.
        /// </summary>
        internal static string Transaction_Message_Bust {
            get {
                return ResourceManager.GetString("Transaction.Message.Bust", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have just purchased {0} for ${1}..
        /// </summary>
        internal static string Transaction_Message_Buy_Sucess {
            get {
                return ResourceManager.GetString("Transaction.Message.Buy.Sucess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You want to sell the dealer goods for ${0} but he only has ${1} with him, are you stupid?.
        /// </summary>
        internal static string Transaction_Message_Dealer_NoMoney {
            get {
                return ResourceManager.GetString("Transaction.Message.Dealer.NoMoney", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not enough room in inventory for transaction..
        /// </summary>
        internal static string Transaction_Message_NoInventory {
            get {
                return ResourceManager.GetString("Transaction.Message.NoInventory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You want to buy for ${0} and you only have ${1} with you, are you an idiot?.
        /// </summary>
        internal static string Transaction_Message_Player_NoMoney {
            get {
                return ResourceManager.GetString("Transaction.Message.Player.NoMoney", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have just sold {0} for ${1}..
        /// </summary>
        internal static string Transaction_Message_Sell_Sucess {
            get {
                return ResourceManager.GetString("Transaction.Message.Sell.Sucess", resourceCulture);
            }
        }
    }
}
