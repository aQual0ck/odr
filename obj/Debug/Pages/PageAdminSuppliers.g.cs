﻿#pragma checksum "..\..\..\Pages\PageAdminSuppliers.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "803C2A7E9B80B7383C6B345637B0486105F658BF6143AC8AADA0AEDB96A8EC9F"
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
using odr.Classes;
using odr.Pages;


namespace odr.Pages {
    
    
    /// <summary>
    /// PageAdminSuppliers
    /// </summary>
    public partial class PageAdminSuppliers : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuMaterials;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuSuppliers;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuAdd;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuExit;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSearch;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSort;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cmbStandard;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbFilter;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem cmbFilterStandard;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Pages\PageAdminSuppliers.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListViewSuppliers;
        
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
            
            #line 24 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.menuMaterials.Click += new System.Windows.RoutedEventHandler(this.menuMaterials_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.menuSuppliers = ((System.Windows.Controls.MenuItem)(target));
            
            #line 26 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.menuSuppliers.Click += new System.Windows.RoutedEventHandler(this.menuSuppliers_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.menuAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 28 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.menuAdd.Click += new System.Windows.RoutedEventHandler(this.menuAdd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menuExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.menuExit.Click += new System.Windows.RoutedEventHandler(this.menuExit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.txbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmbSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.cmbSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbSort_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmbStandard = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.cmbFilter = ((System.Windows.Controls.ComboBox)(target));
            
            #line 47 "..\..\..\Pages\PageAdminSuppliers.xaml"
            this.cmbFilter.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbFilter_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cmbFilterStandard = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 10:
            this.ListViewSuppliers = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

