using System;
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


namespace MonithorServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SignalR s;
        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }

        public void Setup()
        {
            this.s = new SignalR("127.0.0.1", 8080);
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
    }
}
