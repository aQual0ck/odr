﻿#pragma checksum "..\..\..\Pages\PageAdminSuppliers.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FD43AA234E4AE226780028A0097CE491499697509973C14E555BEC7DBCCF6E94"
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
using odr.Pages;


namespace odr.Pages {
    
    
    /// <summary>
    /// PageAdminSuppliers
    /// </summary>
    public partial class PageAdminSuppliers : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuMaterials;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuSuppliers;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuAdd;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuExit;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGSuppliers;
        
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
            System.Uri resourceLocater = new System.Uri("/odr;component/pages/pageadminsuppliers.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageAdminSuppliers.xaml"
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
            this.menuMaterials = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.menuMaterials.Click += new System.Windows.RoutedEventHandler(this.menuMaterials_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.menuSuppliers = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.menuSuppliers.Click += new System.Windows.RoutedEventHandler(this.menuSuppliers_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.menuAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 24 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.menuAdd.Click += new System.Windows.RoutedEventHandler(this.menuAdd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menuExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 25 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.menuExit.Click += new System.Windows.RoutedEventHandler(this.menuExit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DGSuppliers = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

