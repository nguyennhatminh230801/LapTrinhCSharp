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

namespace OnTapCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<NhanVien> danhSachNhanVien;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            danhSachNhanVien = new List<NhanVien>();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenNV.Text)
                    || string.IsNullOrEmpty(txtSoNgayLamViec.Text)
                    || string.IsNullOrEmpty(dtpkNgaySinh.Text))
                {
                    throw new Exception("Không được để trống dữ liệu!!!");
                }

                Func<DateTime, DateTime, int> GetDifferenceInYears = (startDate, endDate) =>
                {
                    return (endDate.Year - startDate.Year - 1) +
                    (((endDate.Month > startDate.Month) ||
                    ((endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day))) ? 1 : 0);
                };

                if(GetDifferenceInYears(dtpkNgaySinh.SelectedDate.Value, DateTime.Now) < 18)
                {
                    throw new Exception("Phải đủ 18 tuổi");
                }    

                if(int.Parse(txtSoNgayLamViec.Text) <= 0)
                {
                    throw new Exception("Số ngày làm việc phải lớn hơn 0");
                }

                //Neu dat dieu kien thi add nhan vien
                NhanVien nhanVien = new NhanVien();
                nhanVien.TenNV = txtTenNV.Text;
                nhanVien.PhongBan = ((ComboBoxItem)cbxPhongBan.SelectedItem).Content.ToString();
                nhanVien.TiengAnh = (bool)chkAnh.IsChecked;
                nhanVien.TiengPhap = (bool)chkPhap.IsChecked;
                nhanVien.TiengTrung = (bool)chkTrung.IsChecked;
                nhanVien.NgaySinh = dtpkNgaySinh.SelectedDate.Value;
                nhanVien.SoNgayLamViec = int.Parse(txtSoNgayLamViec.Text);

                danhSachNhanVien.Add(nhanVien);

                MainWindow_LoadingForm(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            txtTenNV.Clear();
            cbxPhongBan.SelectedIndex = 0;
            txtSoNgayLamViec.Clear();
            chkAnh.IsChecked = false;
            chkPhap.IsChecked = false;
            chkTrung.IsChecked = false;
        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();

            NhanVien nhanVien = danhSachNhanVien.Last();

            if (nhanVien == null)
            {
                MessageBox.Show("Danh Sách Trống", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            window2.txtTenNV.Text = nhanVien.TenNV;
            ComboBoxItem comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = nhanVien.PhongBan;
            window2.cbxPhongBan.SelectedItem = comboBoxItem;
            window2.chkAnh.IsChecked = nhanVien.TiengAnh;
            window2.chkPhap.IsChecked = nhanVien.TiengPhap;
            window2.chkTrung.IsChecked = nhanVien.TiengTrung;
            window2.txtSoNgayLamViec.Text = nhanVien.SoNgayLamViec.ToString();
            window2.txtTienLuong.Text = nhanVien.LuongNhanVien.ToString();

            //show() de chay;
            window2.Show();
        }

        private void MainWindow_LoadingForm(object sender, RoutedEventArgs e)
        {
            List<string> res = new List<string>();

            foreach (var item in danhSachNhanVien)
            {
                res.Add(item.ToString());
            }

            lbData.ItemsSource = res;
        }
    }
}
