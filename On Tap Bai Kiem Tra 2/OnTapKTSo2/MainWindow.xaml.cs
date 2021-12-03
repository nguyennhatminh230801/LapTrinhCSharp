using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace OnTapKTSo2
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

        private void setOnClick_btnNhap(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(txtHoTen.Text, @"^[a-zA-Z\s]+$")) //Chỉ nhận chữ và khoảng trắng
                {
                    throw new Exception("Họ Tên Chỉ Được Chứa Chữ Và Khoảng Trắng (Độ dài 6-35 kí tự)!!");
                }

                if (!Regex.IsMatch(txtSoTienBanHang.Text, @"(\d+)?.(\d+)?") ||  //số thực double
                   !Regex.IsMatch(txtSoTienBanHang.Text, @"\d+")) //số nguyên
                {
                    throw new Exception("Số Tiền Bán Hàng Phải Là Số");
                }

                string HoTen = txtHoTen.Text;
                string LoaiNV = (cbLoaiNV.SelectedItem as ComboBoxItem).Content.ToString();
                DateTime NgaySinh = dtpkNgaySinh.SelectedDate.Value;
                double SoTien = double.Parse(txtSoTienBanHang.Text);

                if (string.IsNullOrWhiteSpace(HoTen) ||
                string.IsNullOrWhiteSpace(txtSoTienBanHang.Text))
                {
                    throw new Exception("Không được để trống!!");
                }

                if (SoTien < 0)
                {
                    throw new Exception("Số tiền bán hàng phải là số thực, lớn hơn 0");
                }

                //Tính tuổi
                TimeSpan timeSpan = DateTime.Now - NgaySinh;
                int Tuoi = Convert.ToInt32(timeSpan.TotalDays / 365.25);

                if(Tuoi < 18 || Tuoi > 60)
                {
                    throw new Exception("Tuổi phải trong khoảng 18 đến 60");
                }

                lbxNhanVien.Items.Add(new NhanVien(HoTen, LoaiNV, NgaySinh, SoTien));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }

        private void setOnClick_btnXoa(object sender, RoutedEventArgs e)
        {
            txtHoTen.Clear();
            txtSoTienBanHang.Clear();
            dtpkNgaySinh.SelectedDate = DateTime.Now;
            cbLoaiNV.SelectedItem = null;
            txtHoTen.Focus();
        }

        private void setOnClick_btnWindows2(object sender, RoutedEventArgs e)
        {
            try
            {
                Window2 window2 = new Window2();
                NhanVien nhanVien = lbxNhanVien.SelectedItem as NhanVien;

                if (nhanVien == null)
                {
                    throw new Exception("Bạn chưa kích chọn vào Nhân Viên nào!!");
                }

                window2.txtHoTen.Text = nhanVien.HoTen;

                foreach (ComboBoxItem item in window2.cbLoaiNV.Items)
                {
                    if(item.Content.ToString().Equals(nhanVien.LoaiNV))
                    {
                        window2.cbLoaiNV.SelectedItem = item;
                        break;
                    }
                }

                window2.dtpkNgaySinh.SelectedDate = nhanVien.NgaySinh;
                window2.txtSoTienBanHang.Text = nhanVien.SoTienBanHang.ToString();

                window2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
