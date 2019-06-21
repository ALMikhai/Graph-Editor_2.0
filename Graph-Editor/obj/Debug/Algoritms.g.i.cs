﻿#pragma checksum "..\..\Algoritms.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "79232415D625F2C07207BD5B78194CEBAD928312B572095FB99C80A792202C02"
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
    /// Algoritms
    /// </summary>
    public partial class Algoritms : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BFS_Button;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DFS_Button;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LockPanel;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid BFS_DFS;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FS_Ready;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FS_Cancel;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FSstartVertex;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Dijkstra;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Dijkstra_Ready;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Dijkstra_Cancel;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DijkstrastartVertex;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\Algoritms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DijkstrafinalVertex;
        
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
            System.Uri resourceLocater = new System.Uri("/Graph-Editor;component/algoritms.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Algoritms.xaml"
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
            
            #line 8 "..\..\Algoritms.xaml"
            ((Graph_Editor.Algoritms)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.DataWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BFS_Button = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Algoritms.xaml"
            this.BFS_Button.Click += new System.Windows.RoutedEventHandler(this.Button_Alg_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DFS_Button = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\Algoritms.xaml"
            this.DFS_Button.Click += new System.Windows.RoutedEventHandler(this.Button_Alg_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 48 "..\..\Algoritms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Alg_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 54 "..\..\Algoritms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Alg_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 60 "..\..\Algoritms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Alg_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 66 "..\..\Algoritms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Alg_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 72 "..\..\Algoritms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Alg_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 78 "..\..\Algoritms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Alg_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 84 "..\..\Algoritms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Alg_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 91 "..\..\Algoritms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.main_Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.LockPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.BFS_DFS = ((System.Windows.Controls.Grid)(target));
            return;
            case 14:
            this.FS_Ready = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\Algoritms.xaml"
            this.FS_Ready.Click += new System.Windows.RoutedEventHandler(this.Button_ReadyExitAlgoritm_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.FS_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\Algoritms.xaml"
            this.FS_Cancel.Click += new System.Windows.RoutedEventHandler(this.Button_ExitAlgoritm_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.FSstartVertex = ((System.Windows.Controls.TextBox)(target));
            return;
            case 17:
            this.Dijkstra = ((System.Windows.Controls.Grid)(target));
            return;
            case 18:
            this.Dijkstra_Ready = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\Algoritms.xaml"
            this.Dijkstra_Ready.Click += new System.Windows.RoutedEventHandler(this.Button_ReadyExitAlgoritm_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.Dijkstra_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 141 "..\..\Algoritms.xaml"
            this.Dijkstra_Cancel.Click += new System.Windows.RoutedEventHandler(this.Button_ExitAlgoritm_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.DijkstrastartVertex = ((System.Windows.Controls.TextBox)(target));
            return;
            case 21:
            this.DijkstrafinalVertex = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

