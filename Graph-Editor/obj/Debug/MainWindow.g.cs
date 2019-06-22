﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3EC114AE7E387390A482731DF196357608633DC4F52C3628A6A40E7C1BEC2EE1"
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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas graphCanvas;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Algorimts_Window;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddVertex;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MoveVertex;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Connect;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid WaitPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/Graph-Editor;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.graphCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 28 "..\..\MainWindow.xaml"
            this.graphCanvas.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.GraphCanvas_MouseDown);
            
            #line default
            #line hidden
            
            #line 29 "..\..\MainWindow.xaml"
            this.graphCanvas.MouseMove += new System.Windows.Input.MouseEventHandler(this.GraphCanvas_MouseMove);
            
            #line default
            #line hidden
            
            #line 30 "..\..\MainWindow.xaml"
            this.graphCanvas.MouseLeave += new System.Windows.Input.MouseEventHandler(this.GraphCanvas_MouseLeave);
            
            #line default
            #line hidden
            
            #line 31 "..\..\MainWindow.xaml"
            this.graphCanvas.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GraphCanvas_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Algorimts_Window = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\MainWindow.xaml"
            this.Algorimts_Window.Click += new System.Windows.RoutedEventHandler(this.Algoritm_Button);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddVertex = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\MainWindow.xaml"
            this.AddVertex.Click += new System.Windows.RoutedEventHandler(this.Change_Tool_Button);
            
            #line default
            #line hidden
            
            #line 43 "..\..\MainWindow.xaml"
            this.AddVertex.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            
            #line 43 "..\..\MainWindow.xaml"
            this.AddVertex.MouseMove += new System.Windows.Input.MouseEventHandler(this.Button_MouseMove);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MoveVertex = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\MainWindow.xaml"
            this.MoveVertex.Click += new System.Windows.RoutedEventHandler(this.Change_Tool_Button);
            
            #line default
            #line hidden
            
            #line 51 "..\..\MainWindow.xaml"
            this.MoveVertex.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            
            #line 51 "..\..\MainWindow.xaml"
            this.MoveVertex.MouseMove += new System.Windows.Input.MouseEventHandler(this.Button_MouseMove);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Connect = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\MainWindow.xaml"
            this.Connect.Click += new System.Windows.RoutedEventHandler(this.Connect_Click);
            
            #line default
            #line hidden
            
            #line 57 "..\..\MainWindow.xaml"
            this.Connect.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            
            #line 57 "..\..\MainWindow.xaml"
            this.Connect.MouseMove += new System.Windows.Input.MouseEventHandler(this.Button_MouseMove);
            
            #line default
            #line hidden
            return;
            case 6:
            this.WaitPanel = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

