﻿#pragma checksum "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D16DC697120B1A999A175091DC5E2EBC"
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


namespace KursovayaRabota.Views.Styles {
    
    
    /// <summary>
    /// VS2012WindowStyle
    /// </summary>
    public partial class VS2012WindowStyle : System.Windows.ResourceDictionary, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
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
            System.Uri resourceLocater = new System.Uri("/KursovayaRabota;component/views/styles/vs2012windowstyle.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
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
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 98 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TitleBarMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 99 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Controls.Border)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.TitleBarMouseMove);
            
            #line default
            #line hidden
            break;
            case 2:
            
            #line 115 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.IconMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 131 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinButtonClick);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 147 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MaxButtonClick);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 164 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseButtonClick);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 178 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Shapes.Line)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeNorth);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 187 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Shapes.Line)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeSouth);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 197 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Shapes.Line)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeWest);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 206 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Shapes.Line)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeEast);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 216 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeNorthWest);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 224 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeNorthEast);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 232 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeSouthWest);
            
            #line default
            #line hidden
            break;
            case 13:
            
            #line 240 "..\..\..\..\Views\Styles\VS2012WindowStyle.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.OnSizeSouthEast);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

