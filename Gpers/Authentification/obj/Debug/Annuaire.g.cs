﻿#pragma checksum "..\..\Annuaire.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3B453DECAC06CEF5351D652F9210033CB078E307"
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
    /// Annuaire
    /// </summary>
    public partial class Annuaire : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mygrid;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel panel;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.ColorZone colzone;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox search;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchbutton;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filtre;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock filtret;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button retour;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar bar;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost alert;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nontrouvé;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost alert2;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\Annuaire.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl annuaire;
        
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
            System.Uri resourceLocater = new System.Uri("/Authentification;component/annuaire.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Annuaire.xaml"
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
            this.mygrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.panel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 3:
            this.colzone = ((MaterialDesignThemes.Wpf.ColorZone)(target));
            return;
            case 4:
            this.search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.searchbutton = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\Annuaire.xaml"
            this.searchbutton.Click += new System.Windows.RoutedEventHandler(this.searchbutton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.filtre = ((System.Windows.Controls.ComboBox)(target));
            
            #line 47 "..\..\Annuaire.xaml"
            this.filtre.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.filtre_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.filtret = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.retour = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\Annuaire.xaml"
            this.retour.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.bar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 10:
            this.alert = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 11:
            this.nontrouvé = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\Annuaire.xaml"
            this.nontrouvé.Click += new System.Windows.RoutedEventHandler(this.nontrouvé_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.alert2 = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 13:
            this.annuaire = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

