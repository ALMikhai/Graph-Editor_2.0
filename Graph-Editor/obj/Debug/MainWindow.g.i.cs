<<<<<<< HEAD
﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7D810677F2A466F7BEB02BBA4C0D7570474AAEB80DB66D4B39EE5E10A894995D"
=======
﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23BDDBB229C553D109A61BA9AC7E6E6AA4F9FD90"
>>>>>>> Alexander_Mikhailenko
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
        
        
        #line 37 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas GraphCanvas;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Algorimts_Window;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddVertex;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MoveVertex;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DelVertex;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DelEdge;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Connect;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid WaitPanel;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Exit_Dialog;
        
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
            
            #line 8 "..\..\MainWindow.xaml"
            ((Graph_Editor.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.DataWindow_Closing);
            
            #line default
            #line hidden
            
            #line 9 "..\..\MainWindow.xaml"
            ((Graph_Editor.MainWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GraphCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 40 "..\..\MainWindow.xaml"
            this.GraphCanvas.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.GraphCanvas_MouseDown);
            
            #line default
            #line hidden
            
            #line 41 "..\..\MainWindow.xaml"
            this.GraphCanvas.MouseMove += new System.Windows.Input.MouseEventHandler(this.GraphCanvas_MouseMove);
            
            #line default
            #line hidden
            
            #line 42 "..\..\MainWindow.xaml"
            this.GraphCanvas.MouseLeave += new System.Windows.Input.MouseEventHandler(this.GraphCanvas_MouseLeave);
            
            #line default
            #line hidden
            
            #line 43 "..\..\MainWindow.xaml"
            this.GraphCanvas.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GraphCanvas_MouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Algorimts_Window = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\MainWindow.xaml"
            this.Algorimts_Window.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseLeave);
            
            #line default
            #line hidden
            
            #line 46 "..\..\MainWindow.xaml"
            this.Algorimts_Window.MouseMove += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseMove);
            
            #line default
            #line hidden
            
            #line 50 "..\..\MainWindow.xaml"
            this.Algorimts_Window.Click += new System.Windows.RoutedEventHandler(this.AlgoritmButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddVertex = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\MainWindow.xaml"
            this.AddVertex.Click += new System.Windows.RoutedEventHandler(this.Change_Tool_Button);
            
            #line default
            #line hidden
            
            #line 57 "..\..\MainWindow.xaml"
            this.AddVertex.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseLeave);
            
            #line default
            #line hidden
            
            #line 57 "..\..\MainWindow.xaml"
            this.AddVertex.MouseMove += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseMove);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MoveVertex = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\MainWindow.xaml"
            this.MoveVertex.Click += new System.Windows.RoutedEventHandler(this.Change_Tool_Button);
            
            #line default
            #line hidden
            
            #line 69 "..\..\MainWindow.xaml"
            this.MoveVertex.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseLeave);
            
            #line default
            #line hidden
            
            #line 69 "..\..\MainWindow.xaml"
            this.MoveVertex.MouseMove += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseMove);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DelVertex = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\MainWindow.xaml"
            this.DelVertex.Click += new System.Windows.RoutedEventHandler(this.Change_Tool_Button);
            
            #line default
            #line hidden
            
            #line 81 "..\..\MainWindow.xaml"
            this.DelVertex.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseLeave);
            
            #line default
            #line hidden
            
            #line 81 "..\..\MainWindow.xaml"
            this.DelVertex.MouseMove += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseMove);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DelEdge = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\MainWindow.xaml"
            this.DelEdge.Click += new System.Windows.RoutedEventHandler(this.Change_Tool_Button);
            
            #line default
            #line hidden
            
            #line 93 "..\..\MainWindow.xaml"
            this.DelEdge.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseLeave);
            
            #line default
            #line hidden
            
            #line 93 "..\..\MainWindow.xaml"
            this.DelEdge.MouseMove += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseMove);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Connect = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\MainWindow.xaml"
            this.Connect.Click += new System.Windows.RoutedEventHandler(this.Change_Tool_Button);
            
            #line default
            #line hidden
            
            #line 103 "..\..\MainWindow.xaml"
            this.Connect.MouseLeave += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseLeave);
            
            #line default
            #line hidden
            
            #line 103 "..\..\MainWindow.xaml"
            this.Connect.MouseMove += new System.Windows.Input.MouseEventHandler(this.ToolButton_MouseMove);
            
            #line default
            #line hidden
            return;
            case 9:
            this.WaitPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            
            #line 121 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 122 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Load_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 124 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 126 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearAll_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 132 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowMatrix);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 143 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewDocumentation);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 145 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.GoToOptions);
            
            #line default
            #line hidden
            return;
            case 17:
            this.Exit_Dialog = ((System.Windows.Controls.Grid)(target));
            return;
            case 18:
            
            #line 155 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Exit_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 156 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Exit_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 157 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

