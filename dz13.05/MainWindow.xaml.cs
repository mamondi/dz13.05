using Data;
using System.Windows;

namespace dz13._05
{
    public partial class MainWindow : Window
    {
        DBManager dBManager;

        public MainWindow()
        {
            InitializeComponent();
            dBManager = new DBManager();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TBConnection.Text))
                {
                    throw new Exception("Connection string is null");
                }

                dBManager.ConnectionString = TBConnection.Text;
                var result = dBManager.Connect();

                if (result)
                {
                    MessageBox.Show("Connection successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    var window1 = new Window1(dBManager.ConnectionString);
                    window1.Show();
                    this.Close();
                }
            }
            catch (Exception errorText)
            {
                MessageBox.Show(errorText.Message, "System Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TBConnection_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            dBManager.ConnectionString = TBConnection.Text;
        }
    }
}
