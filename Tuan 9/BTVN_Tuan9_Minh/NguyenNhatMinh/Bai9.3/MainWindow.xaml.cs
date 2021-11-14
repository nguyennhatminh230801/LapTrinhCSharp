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

namespace Bai9._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void setOnClick_btnThem(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    throw new Exception("Không được để trống Họ Tên!!!!");
                }

                string ThongBao = "Họ Tên: " + txtHoTen.Text + "\n";
                ThongBao += "Giới Tính: ";
                ThongBao += ((bool)rdNam.IsChecked) ? rdNam.Content : rdNu.Content;
                ThongBao += "\nTình Trạng Hôn Nhân: ";
                ThongBao += ((bool)rdChuaKetHon.IsChecked) ? rdChuaKetHon.Content : rdDaKetHon.Content;
                ThongBao += "\nSở Thích: ";

                string res = "";

                foreach (var item in new CheckBox[]{ chkAmNhac, chkBoiLoi, chkBongDa, chkLeoNui})
                {
                    if((bool)item.IsChecked)
                    {
                        res += item.Content + "-";
                    }    
                }

                res = string.Join(",", res.Split("-").Where(elem => !string.IsNullOrEmpty(elem)).ToArray());
                ThongBao += res;

                txtB_Answer.Text = ThongBao;
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void setOnClick_btnThoat(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
