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
using Tuan12.Models;

namespace Tuan12
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

        private void setOnClick_btnLogin(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không được để trống!!");
                }    

                QLBanHangContext database = new QLBanHangContext();

                var querySize = (from account in database.NguoiDungs
                                 where account.TenDangNhap.Equals(txtUsername.Text) 
                                 && account.MatKhau.Equals(txtPassword.Password)
                                 select account).ToList().Count;

                if (querySize == 1)
                {
                    QuanLyBanHang window = new QuanLyBanHang();
                    window.txtUsername.Text = txtUsername.Text;

                    MessageBox.Show("Đăng Nhập Thành Công!!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                   
                    window.Show();
                    Close(); 
                }
                else
                {
                    throw new Exception("Đăng Nhập Không Thành Công!!!!\n\nMật Khẩu Hoặc Tài Khoản Của Bạn Sai!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
