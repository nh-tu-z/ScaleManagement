#pragma checksum "..\..\..\View\SheetsManagementView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "50F22440312570583633C63EC31C8A937237616D791A1BB0E2A3128A0ABA6362"
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
using scale.View;


namespace scale.View {
    
    
    /// <summary>
    /// SheetsManagementView
    /// </summary>
    public partial class SheetsManagementView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\View\SheetsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid mainDataGrid;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\View\SheetsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox dateCbx;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\View\SheetsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateTimePickerFrom;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\View\SheetsManagementView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateTimePickerTo;
        
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
            System.Uri resourceLocater = new System.Uri("/scale;component/view/sheetsmanagementview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\SheetsManagementView.xaml"
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
            
            #line 8 "..\..\..\View\SheetsManagementView.xaml"
            ((scale.View.SheetsManagementView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.dateCbx = ((System.Windows.Controls.CheckBox)(target));
            
            #line 87 "..\..\..\View\SheetsManagementView.xaml"
            this.dateCbx.Checked += new System.Windows.RoutedEventHandler(this.dateCbx_Checked);
            
            #line default
            #line hidden
            
            #line 87 "..\..\..\View\SheetsManagementView.xaml"
            this.dateCbx.Unchecked += new System.Windows.RoutedEventHandler(this.dateCbx_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dateTimePickerFrom = ((System.Windows.Controls.DatePicker)(target));
            
            #line 90 "..\..\..\View\SheetsManagementView.xaml"
            this.dateTimePickerFrom.CalendarClosed += new System.Windows.RoutedEventHandler(this.dateTimePickerFrom_CalendarClosed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dateTimePickerTo = ((System.Windows.Controls.DatePicker)(target));
            
            #line 94 "..\..\..\View\SheetsManagementView.xaml"
            this.dateTimePickerTo.CalendarClosed += new System.Windows.RoutedEventHandler(this.dateTimePickerTo_CalendarClosed);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

