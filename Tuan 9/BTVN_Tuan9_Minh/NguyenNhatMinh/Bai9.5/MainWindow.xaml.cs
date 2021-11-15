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

        private void setOnClick_btnChonGame(object sender, RoutedEventArgs e)
        {
            List<string> answer = new List<string>();

            foreach (StackPanel stackPanel in lbItem.Children)
            {
                CheckBox checkBox = stackPanel.Children.OfType<CheckBox>().FirstOrDefault();
                
                if (checkBox.IsChecked == false)
                {
                    continue;
                }
                
                var res = stackPanel.Children.OfType<Label>().FirstOrDefault().Content.ToString();
                answer.Add(res);
            }

            if(answer.Count == 0)
            {
                MessageBox.Show("Chưa có lựa chọn nào!!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string stringAnswer = answer.Aggregate((first, second) => first + "," + second);
                MessageBox.Show("Bạn đã chọn: " + stringAnswer, "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }      
        }
    }
}
