<<<<<<< HEAD
﻿#pragma checksum "..\..\ConnectVertices.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A2BAF759B04665A456357EBFB9F87D5E09A1FA99214C96A86F123C878263A594"
=======
﻿#pragma checksum "..\..\ConnectVertices.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D63C6D1BC263BACD49BC9EB7BD42C8349FD2D6424ED9837B8D73004A3014272F"
>>>>>>> master
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
        
        
        #line 28 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstVertex;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SecondVertex;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider WeightSlider;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Weight;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Directed;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\ConnectVertices.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Undirected;
        
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
            ((Graph_Editor.ConnectVertices)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\ConnectVertices.xaml"
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
            
            #line 42 "..\..\ConnectVertices.xaml"
            this.WeightSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBox_Weight = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\ConnectVertices.xaml"
            this.TextBox_Weight.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_Weight_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 57 "..\..\ConnectVertices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Create_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 63 "..\..\ConnectVertices.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Directed = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\ConnectVertices.xaml"
            this.Directed.Click += new System.Windows.RoutedEventHandler(this.Directed_Button_Choose);
            
            #line default
            #line hidden
            
            #line 69 "..\..\ConnectVertices.xaml"
            this.Directed.MouseMove += new System.Windows.Input.MouseEventHandler(this.DirecteMouseMove);
            
            #line default
            #line hidden
            
            #line 69 "..\..\ConnectVertices.xaml"
            this.Directed.MouseLeave += new System.Windows.Input.MouseEventHandler(this.DirecteMouseLeave);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Undirected = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\ConnectVertices.xaml"
            this.Undirected.Click += new System.Windows.RoutedEventHandler(this.Undirected_Button_Choose);
            
            #line default
            #line hidden
            
            #line 75 "..\..\ConnectVertices.xaml"
            this.Undirected.MouseMove += new System.Windows.Input.MouseEventHandler(this.DirecteMouseMove);
            
            #line default
            #line hidden
            
            #line 75 "..\..\ConnectVertices.xaml"
            this.Undirected.MouseLeave += new System.Windows.Input.MouseEventHandler(this.DirecteMouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

