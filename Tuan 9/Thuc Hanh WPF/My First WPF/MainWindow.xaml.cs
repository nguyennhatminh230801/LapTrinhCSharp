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

namespace My_First_WPF
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

        private void btnNhapLai_Click(object sender, RoutedEventArgs e)
        {
            txtTen.Clear();
            txtHoDem.Clear();
            rdNam.IsChecked = true;
            rdNu.IsChecked = false;
            chkTiengAnh.IsChecked = false;
            chkTiengViet.IsChecked = false;
            cbQueQuan.SelectedIndex = 0;
            MessageBox.Show("Đã Cập Nhật Về Trạng Thái Ban Đầu", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnXemThongTin_Click(object sender, RoutedEventArgs e)
        {
            string thongBao = "Xin Chào: ";
            
            if((bool)rdNam.IsChecked)
            {
                thongBao += "Mr.";
            }
            else
            {
                thongBao += "Mrs.";
            }

            thongBao += txtHoDem.Text + " " + txtTen.Text + "\n";
            thongBao += "Ngoại Ngữ: ";

            if((bool)chkTiengAnh.IsChecked && (bool)chkTiengViet.IsChecked)
            {
                thongBao += chkTiengAnh.Content + "," + chkTiengViet.Content;
            }
            else if((bool)chkTiengViet.IsChecked)
            {
                thongBao += chkTiengViet.Content;
            }
            else if((bool)chkTiengAnh.IsChecked)
            {
                thongBao += chkTiengAnh.Content;
            }
            else
            {
                thongBao += "Không có";
            }

            thongBao += "\n";
            thongBao += "Quê Quán: ";
            thongBao += (cbQueQuan.SelectedItem as ComboBoxItem).Content.ToString();

            MessageBox.Show(thongBao, "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
