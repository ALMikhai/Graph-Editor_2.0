﻿#pragma checksum "..\..\ConnectVertices.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "238494904EB19FA6B3973A918DBBB9C82D923562"
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
    /// ConnectVertices
    /// </summary>
    public partial class ConnectVertices : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstVertex;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SecondVertex;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider WeightSlider;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Weight;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Directed;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Undirected;
        
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
            System.Uri resourceLocater = new System.Uri("/Graph-Editor;component/connectvertices.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ConnectVertices.xaml"
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
            
            #line 7 "..\..\ConnectVertices.xaml"
            ((Graph_Editor.ConnectVertices)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.DataWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FirstVertex = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.SecondVertex = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.WeightSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 27 "..\..\ConnectVertices.xaml"
            this.WeightSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBox_Weight = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\ConnectVertices.xaml"
            this.TextBox_Weight.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_Weight_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 42 "..\..\ConnectVertices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Create_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 48 "..\..\ConnectVertices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Directed = ((System.Windows.Controls.RadioButton)(target));
            
            #line 54 "..\..\ConnectVertices.xaml"
            this.Directed.Checked += new System.Windows.RoutedEventHandler(this.Directed_Button_Choose);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Undirected = ((System.Windows.Controls.RadioButton)(target));
            
            #line 60 "..\..\ConnectVertices.xaml"
            this.Undirected.Checked += new System.Windows.RoutedEventHandler(this.Undirected_Button_Choose);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

