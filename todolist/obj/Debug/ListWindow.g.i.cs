﻿#pragma checksum "..\..\ListWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AD19F33DA6D9848D3866FCD0C77474BA62987308ED5AEC0C63F749EE572F0A4B"
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
using todolist;


namespace todolist {
    
    
    /// <summary>
    /// ListWindow
    /// </summary>
    public partial class ListWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblWelcome;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstToDo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddToDo;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteToDo;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spAddToDo;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtToDoName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateToDo;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\ListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ListWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowTasks;
        
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
            System.Uri resourceLocater = new System.Uri("/todolist;component/listwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ListWindow.xaml"
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
            this.lblWelcome = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lstToDo = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.btnAddToDo = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\ListWindow.xaml"
            this.btnAddToDo.Click += new System.Windows.RoutedEventHandler(this.btnAddToDo_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeleteToDo = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\ListWindow.xaml"
            this.btnDeleteToDo.Click += new System.Windows.RoutedEventHandler(this.btnDeleteToDo_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.spAddToDo = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.txtToDoName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnCreateToDo = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\ListWindow.xaml"
            this.btnCreateToDo.Click += new System.Windows.RoutedEventHandler(this.btnCreateToDo_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\ListWindow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnShowTasks = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\ListWindow.xaml"
            this.btnShowTasks.Click += new System.Windows.RoutedEventHandler(this.btnShowTasks_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
