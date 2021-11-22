using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using PhieuGiaoBaiTap3.Models;

namespace PhieuGiaoBaiTap3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLBanHangContext database;
        private SanPham? sanPhamDuocChon;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            database = new QLBanHangContext();
        }

        private void OnLoadingForm(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = (from elem1 in database.SanPhams
                             join elem2 in database.LoaiSanPhams
                             on elem1.MaLoai equals elem2.MaLoai // toan tu equal de so sanh bang
                             select new
                             {
                                 MaSP = elem1.MaSp,
                                 TenSP = elem1.TenSp,
                                 DonGia = elem1.DonGia,
                                 SoLuong = elem1.SoLuong,
                                 TenLoai = elem2.TenLoai
                             }).ToList();

                dataGridSanPham.ItemsSource = query;
                
                //Loai bo Column thua
                while(dataGridSanPham.Columns.Count() != 5)
                {
                    var res = dataGridSanPham.Columns.Last();
                    dataGridSanPham.Columns.Remove(res);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }          
        }

        private void setOnClick_btnThem(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                    string.IsNullOrWhiteSpace(txTenSP.Text) ||
                    string.IsNullOrWhiteSpace(txMaLoai.Text) ||
                    string.IsNullOrWhiteSpace(txDonGia.Text) ||
                    string.IsNullOrWhiteSpace(txSoLuong.Text))
                {
                    throw new Exception("Không được để trống dữ liệu");
                }

                var query1 = (from elem in database.SanPhams
                              where elem.MaSp.Equals(txtMaSP.Text)
                              select elem).ToList();

                if(query1.Count > 0)
                {
                    throw new Exception("Không cho phép trùng mã sản phẩm");
                }

                var query2 = (from elem in database.LoaiSanPhams
                              where elem.MaLoai.Equals(txMaLoai.Text)
                              select elem).ToList();
                
                if(query2.Count == 0)
                {
                    throw new Exception("Không tìm được Mã Loại Sản Phẩm Này!!!");
                }

                SanPham sanPham = new SanPham();
                sanPham.MaSp = txtMaSP.Text;
                sanPham.TenSp = txTenSP.Text;
                sanPham.DonGia = int.Parse(txDonGia.Text);
                sanPham.SoLuong = int.Parse(txSoLuong.Text);
                sanPham.MaLoai = txMaLoai.Text;

                database.SanPhams.Add(sanPham);
                database.SaveChanges();

                txtMaSP.Clear();
                txTenSP.Clear();
                txDonGia.Clear();
                txMaLoai.Clear();
                txSoLuong.Clear();

                OnLoadingForm(sender, e);
                MessageBox.Show("Thêm mới thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dataGridSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = dataGridSanPham.SelectedItem;
            
            if(item != null)
            {
                string MaSP = (dataGridSanPham.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                SanPham sanPham = database.SanPhams.ToList().Find(elem => elem.MaSp.Equals(MaSP));
                
                if(sanPham != null)
                {
                    txtMaSP.Text = sanPham.MaSp;
                    txTenSP.Text = sanPham.TenSp;
                    txDonGia.Text = sanPham.DonGia.ToString();
                    txMaLoai.Text = sanPham.MaLoai;
                    txSoLuong.Text = sanPham.SoLuong.ToString();

                    sanPhamDuocChon = sanPham;
                }
            }
        }

        private void setOnClick_btnSua(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sanPhamDuocChon != null)
                {
                    if (!txtMaSP.Text.Equals(sanPhamDuocChon.MaSp))
                    {
                        txtMaSP.Text = sanPhamDuocChon.MaSp;
                        throw new Exception("Không cho phép sửa Mã Sản Phẩm");
                    }

                    var SanPhamInDatabase = (from elem in database.SanPhams
                                             where elem.MaSp.Equals(sanPhamDuocChon.MaSp)
                                             select elem).SingleOrDefault();

                    SanPhamInDatabase.TenSp = txTenSP.Text;
                    SanPhamInDatabase.DonGia = int.Parse(txDonGia.Text);
                    SanPhamInDatabase.SoLuong = int.Parse(txSoLuong.Text);
                    SanPhamInDatabase.MaLoai = txMaLoai.Text;

                    database.SaveChanges();

                    OnLoadingForm(sender, e);
                    MessageBox.Show("Sửa thông tin thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
        }

        private void setOnClick_btnXoa(object sender, RoutedEventArgs e)
        {
            try
            {
                var SanPhamInDatabase = (from elem in database.SanPhams
                                         where elem.MaSp.Equals(txtMaSP.Text)
                                         select elem).SingleOrDefault();

                database.SanPhams.Remove(SanPhamInDatabase);
                database.SaveChanges();

                OnLoadingForm(sender, e);
                MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
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
