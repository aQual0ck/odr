// Updated by XamlIntelliSenseFileGenerator 28.11.2024 18:30:27
#pragma checksum "..\..\..\Pages\PageUser.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D96EE543466EC981A65F9BE3FBCA70C2AE709F69AE3BF7C1E297E9497EAA6A90"
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


namespace odr.Pages
{


    /// <summary>
    /// PageUser
    /// </summary>
    public partial class PageUser : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/odr;component/pages/pageuser.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Pages\PageUser.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.MenuItem menuMaterials;
        internal System.Windows.Controls.MenuItem menuSuppliers;
        internal System.Windows.Controls.MenuItem menuExit;
        internal System.Windows.Controls.TextBox txbSearch;
        internal System.Windows.Controls.ComboBox cmbSort;
        internal System.Windows.Controls.ComboBoxItem cmbStandard;
        internal System.Windows.Controls.ComboBox cmbFilter;
        internal System.Windows.Controls.ListView ListViewMaterials;
    }
}

