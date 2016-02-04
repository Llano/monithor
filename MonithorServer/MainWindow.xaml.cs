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
        public DatabaseConnection database { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }

        public void Setup()
        {
            this.s = new SignalR("127.0.0.1", 8080);
            this._Csocket = new CommSocket(IPAddress.Any, 8056);
            loadDatabaseSettings();
            
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
                stopSignalR();
                startSignalRButton.Content = "Start";
                this._Csocket.stop();
            }
            else
            {
                if(s.start())
                {
                    SignalRStatus.Fill = new SolidColorBrush(Color.FromRgb(0, 204, 0));
                    startSignalRButton.Content = "Stop";
                }

                if (this.database.databaseAvaiable())
                {
                    databaseStatus.Fill = new SolidColorBrush(Color.FromRgb(0, 204, 0));
                }

                try
                {
                    this._Csocket.start();
                    TCPStatus.Fill = new SolidColorBrush(Color.FromRgb(0, 204, 0));
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                
            }

            
            
        }

        private void testDatabaseConnection_Click(object sender, RoutedEventArgs e)
        {
            if (this.database.databaseAvaiable())
            {
                MessageBox.Show("Databas is available!");
            }
        }

        //Write status to listbox
        public void log(string message)
        {
            listBoxLog.Items.Add(DateTime.Now.ToString() + " - " + message);
        }

        public void loadDatabaseSettings()
        {
            if(Properties.Settings.Default.DatabaseName != null)
            {
                databaseName.Text = Properties.Settings.Default.DatabaseName;
            }

            if (Properties.Settings.Default.DatabaseUrl != null)
            {
                databaseIP.Text = Properties.Settings.Default.DatabaseUrl;
            }

            if (Properties.Settings.Default.DatabaseUsername != null)
            {
                databasUsername.Text = Properties.Settings.Default.DatabaseUsername;
            }

            if (Properties.Settings.Default.DatabasePassword != null)
            {
                databasPassword.Text = Properties.Settings.Default.DatabasePassword;
            }

            this.database = new DatabaseConnection(Properties.Settings.Default.DatabaseUsername, Properties.Settings.Default.DatabasePassword, Properties.Settings.Default.DatabaseUrl, Properties.Settings.Default.DatabaseName);
        }

        private void saveDatabase_Click(object sender, RoutedEventArgs e)
        {
            if (databaseIP.Text != null || databaseName.Text != null || databasPassword.Text != null || databasUsername.Text != null)
            {
                Properties.Settings.Default["DatabaseUrl"] = databaseIP.Text;
                Properties.Settings.Default["DatabaseName"] = databaseName.Text;
                Properties.Settings.Default["DatabaseUsername"] = databasUsername.Text;
                Properties.Settings.Default["DatabasePassword"] = databasPassword.Text;

                Properties.Settings.Default.Save();


            }
            
        }
    }
}
