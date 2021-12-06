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

namespace NguyenNhatMinh_2019600285
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

        private void btnXoa_OnClick(object sender, RoutedEventArgs e)
        {
            txtHoTen.Clear();
            txtSoNgayCong.Clear();
            txtLuong.Clear();
            rdNam.IsChecked = true;
            txtHoTen.Focus();
        }

        private void btnChiTiet_OnClick(object sender, RoutedEventArgs e)
        {
            Employee employee = lviNhanVien.SelectedItem as Employee;

            if(employee == null)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên nào!!", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }    
            Window2 window2 = new Window2();
            window2.txtHoTen.Text = employee.HoTen;
            window2.rdNam.IsChecked = employee.IsGioiTinhNam;
            window2.txtSoNgayCong.Text = employee.SoNgayCong.ToString();
            window2.txtLuong.Text = employee.Luong.ToString();
            window2.txtThuong.Text = employee.Thuong.ToString();

            window2.Show(); //Chạy cửa sổ 2
            Close(); //Đóng cửa sổ 1
        }

        private void btnThem_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //kiểm tra khoảng trắng
                string whiteSpace = "";

                if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    whiteSpace += "Bạn không được để trống họ tên!!\n";
                }

                if (string.IsNullOrWhiteSpace(txtSoNgayCong.Text))
                {
                    whiteSpace += "Bạn không được để trống số ngày công!!\n";
                }

                if (string.IsNullOrWhiteSpace(txtLuong.Text))
                {
                    whiteSpace += "Bạn không được để trống lương!!\n";
                }

                if (!string.IsNullOrWhiteSpace(whiteSpace))
                {
                    throw new Exception(whiteSpace);
                }

                //Kiểm tra Pattern
                string RegexFail = "";

                if(!Regex.IsMatch(txtHoTen.Text, @"^[a-zA-Z\s]+$"))
                {
                    RegexFail += "Họ Tên Chỉ Có Chữ Và Khoảng Trắng\n";
                }

                if (!Regex.IsMatch(txtSoNgayCong.Text, @"^[0-9]+$"))
                {
                    RegexFail += "Số Ngày Công Là Số Nguyên\n";
                }

                if (!Regex.IsMatch(txtLuong.Text, @"^[0-9]+$"))
                {
                    RegexFail += "Lương Là Số Nguyên\n";
                }

                if (!string.IsNullOrWhiteSpace(RegexFail))
                {
                    throw new Exception(RegexFail);
                }

                string HoTen = txtHoTen.Text;
                bool GioiTinhNam = (bool)rdNam.IsChecked;
                Int64 SoNgayCong = Int64.Parse(txtSoNgayCong.Text);
                Int64 Luong = Int64.Parse(txtLuong.Text);

                string ValueError = "";

                if(SoNgayCong < 20 || SoNgayCong > 30)
                {
                    ValueError += "Số ngày công phải trong khoảng [20, 30]\n";
                }

                if(Luong < 3000 || Luong > 5000)
                {
                    ValueError += "Lương phải trong khoảng [3000, 5000]\n";
                }

                if (!string.IsNullOrWhiteSpace(ValueError))
                {
                    throw new Exception(ValueError);
                }

                //Thêm dữ liệu vào ListView
                lviNhanVien.Items.Add(new Employee(HoTen, GioiTinhNam, SoNgayCong, Luong));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
               
        }

        private void btnDong_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
