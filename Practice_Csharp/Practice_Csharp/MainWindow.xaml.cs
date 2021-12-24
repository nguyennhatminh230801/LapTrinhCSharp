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

namespace Practice_Csharp
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

        private void btnNhap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtSoNgayLamViec.Text))
                {
                    throw new Exception("Không được để khoảng trắng!!");
                }

                string HoTen = txtHoTen.Text;
                int SoNgayLamViec = int.Parse(txtSoNgayLamViec.Text);
                DateTime NgaySinh = dtpkNgaySinh.SelectedDate.Value;
                string GioiTinh = (bool)rdNam.IsChecked ? "Nam" : "Nữ";

                dtGridNhanVien.Items.Add(new NhanVien(HoTen, NgaySinh, GioiTinh, SoNgayLamViec));   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            txtHoTen.Clear();
            txtSoNgayLamViec.Clear();
            rdNam.IsChecked = true;
            dtpkNgaySinh.SelectedDate = DateTime.Now;
        }

        private void btnWindow2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
