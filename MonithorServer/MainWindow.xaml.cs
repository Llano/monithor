﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;


namespace MonithorServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SignalR s;
        public CommSocket _Csocket { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }

        public void Setup()
        {
            this.s = new SignalR("127.0.0.1", 8080);
            this._Csocket = new CommSocket(IPAddress.Any, 8056);
        }

        // Start SignalR server
        public void startSignalR()
        {

            if(s.start())
            {
                listBoxLog.Items.Add("SignalR has started on " + this.s.url);
                startSignalRButton.Content = "Stop";
            }
            else
            {
                listBoxLog.Items.Add("Could not start signalR");
            }
        }

        public void startTcpServer()
        {
            this._Csocket.start();
            startTcpListener.Content = "Stop TCP";
        }

        public void stopTcpServer()
        {
            this._Csocket.stop();
            startTcpListener.Content = "Start TCP";
        }

        // Stop SignalR server
        public void stopSignalR()
        {
            this.s.stop();
            startSignalRButton.Content = "Start";

        }

        // Button was pressed to either start or stop the server
        private void startSignalR_Click(object sender, RoutedEventArgs e)
        {
            if (s.isRunning())
            {
                listBoxLog.Items.Add("Stopping signalR");
                stopSignalR();
            }
            else
            {
                listBoxLog.Items.Add("Starting signalR..");
                startSignalR();
            }
            
        }

        private void startTcpListener_Click(object sender, RoutedEventArgs e)
        {
            if (this._Csocket.isRunning())
            {
                stopTcpServer();
                listBoxLog.Items.Add("Stopping TCP..");
            }
            else
            {
                listBoxLog.Items.Add("Starting TCP..");
                startTcpServer();
            }
        }
    }
}
