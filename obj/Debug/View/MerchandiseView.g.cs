﻿#pragma checksum "..\..\..\View\MerchandiseView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "55CAFBD99FB7B89870C4F6FFFE4D911FC61AD542A9D0442B6904930356622657"
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
    /// MerchandiseView
    /// </summary>
    public partial class MerchandiseView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\View\MerchandiseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid merchandiseDataGrid;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\View\MerchandiseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editBtn;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\View\MerchandiseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/scale;component/view/merchandiseview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MerchandiseView.xaml"
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
            this.merchandiseDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 33 "..\..\..\View\MerchandiseView.xaml"
            this.merchandiseDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.selectionChanged);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\View\MerchandiseView.xaml"
            this.merchandiseDataGrid.Loaded += new System.Windows.RoutedEventHandler(this.load);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 65 "..\..\..\View\MerchandiseView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addNewProduct);
            
            #line default
            #line hidden
            return;
            case 3:
            this.editBtn = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\View\MerchandiseView.xaml"
            this.editBtn.Click += new System.Windows.RoutedEventHandler(this.edit);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\View\MerchandiseView.xaml"
            this.deleteBtn.Click += new System.Windows.RoutedEventHandler(this.delete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

