﻿#pragma checksum "C:\Users\Juanfran\Desktop\Proyecto fin de aula\DiscountMeWP7\DiscountMe.WP7\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BBBBAAAE352A6AA5921B8CEC2D3320E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17379
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using Tomers.Phone.Shell;


namespace DiscountMe {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Tomers.Phone.Shell.ApplicationBarIconButton appbar_search;
        
        internal Tomers.Phone.Shell.ApplicationBarIconButton SettingsMenuItem;
        
        internal Tomers.Phone.Shell.ApplicationBarMenuItem ProfileMenuItem;
        
        internal Tomers.Phone.Shell.ApplicationBarMenuItem AboutMenuItem;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/DiscountMe;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.appbar_search = ((Tomers.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbar_search")));
            this.SettingsMenuItem = ((Tomers.Phone.Shell.ApplicationBarIconButton)(this.FindName("SettingsMenuItem")));
            this.ProfileMenuItem = ((Tomers.Phone.Shell.ApplicationBarMenuItem)(this.FindName("ProfileMenuItem")));
            this.AboutMenuItem = ((Tomers.Phone.Shell.ApplicationBarMenuItem)(this.FindName("AboutMenuItem")));
        }
    }
}

