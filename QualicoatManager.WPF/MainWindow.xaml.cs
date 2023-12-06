using QualicoatManager.API.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace QualicoatManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserServices _userServices;

        public MainWindow()
        {
            InitializeComponent();

            _userServices = new UserServices();
            //Loaded += RawMaterialsList;
        }

        //private async void RawMaterialsList(object sender, RoutedEventArgs e)
        //{
        //    // Call the method you want to run at the start
        //   await _userServices.GetRawMaterialsList();


        //}

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _userServices.GetRawMaterialsList();
        }
    }
}