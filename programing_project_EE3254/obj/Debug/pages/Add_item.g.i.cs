﻿#pragma checksum "..\..\..\pages\Add_item.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "98E2AB5F17B3EE5ACFA291054F475CB52AAA0B109C499A4D4BD4D7089768FE25"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using programing_project_EE3254.pages;


namespace programing_project_EE3254.pages {
    
    
    /// <summary>
    /// Add_item
    /// </summary>
    public partial class Add_item : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\pages\Add_item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox categoryComboBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\pages\Add_item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\pages\Add_item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\pages\Add_item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock priceTextBlock;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\pages\Add_item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/programing_project_EE3254;component/pages/add_item.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pages\Add_item.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.categoryComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.nameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\pages\Add_item.xaml"
            this.nameTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.name_txt2_GotFocus);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\pages\Add_item.xaml"
            this.nameTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.name_txt2_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.priceTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.priceTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 101 "..\..\..\pages\Add_item.xaml"
            this.priceTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.price_txt2_GotFocus);
            
            #line default
            #line hidden
            
            #line 102 "..\..\..\pages\Add_item.xaml"
            this.priceTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.price_txt2_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 107 "..\..\..\pages\Add_item.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SubmitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

