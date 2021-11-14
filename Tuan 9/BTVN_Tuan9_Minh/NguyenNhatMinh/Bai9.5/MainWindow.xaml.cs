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

namespace Bai9._5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void OnLoadingForm(object sender, RoutedEventArgs e)
        {

            List<GameItem> gameItems = new List<GameItem>();

            gameItems.Add(new GameItem() { GameName = "Fifa Online 4", ImageAddress = "Images\\icon1.png" });
            gameItems.Add(new GameItem() { GameName = "Fifa Online 4 Mobile", ImageAddress = "Images\\icon2.png" });
            gameItems.Add(new GameItem() { GameName = "Blade And Soul", ImageAddress = "Images\\icon3.png" });
            gameItems.Add(new GameItem() { GameName = "Liên Quân Mobile", ImageAddress = "Images\\icon4.png" });
            gameItems.Add(new GameItem() { GameName = "Free Fire", ImageAddress = "Images\\icon5.png" });
            gameItems.Add(new GameItem() { GameName = "Liên Minh Huyền Thoại", ImageAddress = "Images\\icon6.png" });

            lbItem.ItemsSource = null;
            lbItem.ItemsSource = gameItems;
        }

        private void setOnClick_btnGoiDoUong(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
