﻿#pragma checksum "..\..\Documentation.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7FD0DEC0E1806E87C43AF08043E80868381B8C3F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Graph_Editor;
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


namespace Graph_Editor {
    
    
    /// <summary>
    /// Documentation
    /// </summary>
    public partial class Documentation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\Documentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox forWhatAndWho;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Documentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox useOfIt;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Documentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Instruct;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Documentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreatorsButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Documentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Creators;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Documentation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button end;
        
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
            System.Uri resourceLocater = new System.Uri("/Graph-Editor;component/documentation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Documentation.xaml"
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
            
            #line 8 "..\..\Documentation.xaml"
            ((Graph_Editor.Documentation)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.forWhatAndWho = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.useOfIt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Instruct = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.CreatorsButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\Documentation.xaml"
            this.CreatorsButton.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Creators = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.end = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\Documentation.xaml"
            this.end.Click += new System.Windows.RoutedEventHandler(this.End_Click);
            
            #line default
            #line hidden
            
            #line 53 "..\..\Documentation.xaml"
            this.end.MouseLeave += new System.Windows.Input.MouseEventHandler(this.End_MouseLeave);
            
            #line default
            #line hidden
            
            #line 53 "..\..\Documentation.xaml"
            this.end.MouseMove += new System.Windows.Input.MouseEventHandler(this.End_MouseMove);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

