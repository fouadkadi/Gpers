﻿#pragma checksum "..\..\objectif_ajout.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AA6A7E5BBDF10C089D0BB6F9BDC0A9C8FB9B5A04"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Authentification;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Authentification {
    
    
    /// <summary>
    /// objectif_ajout
    /// </summary>
    public partial class objectif_ajout : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\objectif_ajout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.ColorZone colzone;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\objectif_ajout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox employée;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\objectif_ajout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox type_objectif;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\objectif_ajout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_debut;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\objectif_ajout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but1;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\objectif_ajout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel list_of_obj;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\objectif_ajout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but2;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\objectif_ajout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost alert;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\objectif_ajout.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock alert_text;
        
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
            System.Uri resourceLocater = new System.Uri("/Authentification;component/objectif_ajout.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\objectif_ajout.xaml"
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
            this.colzone = ((MaterialDesignThemes.Wpf.ColorZone)(target));
            return;
            case 2:
            this.employée = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.type_objectif = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.date_debut = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.but1 = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\objectif_ajout.xaml"
            this.but1.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.list_of_obj = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.but2 = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\objectif_ajout.xaml"
            this.but2.Click += new System.Windows.RoutedEventHandler(this.ajout_obj);
            
            #line default
            #line hidden
            return;
            case 8:
            this.alert = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 9:
            this.alert_text = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

