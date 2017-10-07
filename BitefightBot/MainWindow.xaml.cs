﻿using System.Windows;
using DotNetBrowser.Events;
using DotNetBrowser.WPF;
using GalaSoft.MvvmLight.Messaging;

namespace BitefightBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var webView = new WPFBrowserView();
            webView.FinishLoadingFrameEvent += BrowserView_OnFinishLoadingFrameEvent;
            BrowserGrid.Children.Add((UIElement) webView.GetComponent());
            webView.Browser.LoadURL("https://en.bitefight.gameforge.com/game");
        }

        private void BrowserView_OnFinishLoadingFrameEvent(object sender, FinishLoadingEventArgs e)
        {
            Messenger.Default.Send(e);
        }
    }
}