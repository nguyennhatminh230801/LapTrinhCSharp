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
using Style_Template_EFCore_OnThi.Models;

namespace Style_Template_EFCore_OnThi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SanPham? SanPhamDuocChon;
        private List<LoaiSp> danhSachLoaiSanPham;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            using var database = new QLBanHang1Context();
            var queryUpdateCombobox = from elem in database.LoaiSps
                                      select elem.TenLoai;

            cboLoai.ItemsSource = queryUpdateCombobox.ToList();

            danhSachLoaiSanPham = (from elem in database.LoaiSps
                                   select elem).ToList();
        }

        private void DataGridLoadData()
        {
            using var database = new QLBanHang1Context();
            //don gia > 100, sap xep giam dan theo ten san pham
            var query = from elem in database.SanPhams
                        where elem.DonGia > 100
                        orderby elem.TenSp descending
                        select new
                        {
                            MaSP = elem.MaSp,
                            TenSP = elem.TenSp,
                            DonGia = elem.DonGia,
                            SoLuongCo = elem.SoLuongCo,
                            MaLoai = elem.MaLoai,
                            ThanhTien = elem.DonGia * elem.SoLuongCo
                        };

            dgvSanPham.ItemsSource = query.ToList();
        }

        private string ValidateData()
        {
            //Kiểm tra Text Box trống
            string WhiteSpace = "";

            if (string.IsNullOrWhiteSpace(txtMa.Text)) WhiteSpace += "Mã Sản Phẩm Không Được Để Trống\n";
            if (string.IsNullOrWhiteSpace(txtTen.Text)) WhiteSpace += "Tên Sản Phẩm Không Được Để Trống\n";
            if (string.IsNullOrWhiteSpace(txtSoLuongCo.Text)) WhiteSpace += "Số Lượng Có Không Được Để Trống\n";
            if (string.IsNullOrWhiteSpace(txtDonGia.Text)) WhiteSpace += "Đơn Giá Không Được Để Trống\n";

            //Nếu có ít nhất 1 thông báo lỗi thì trả về
            if (!string.IsNullOrWhiteSpace(WhiteSpace))
            {
                return WhiteSpace;
            }

            string WrongType = "";
            //Kiểm tra số lượng có và đơn giá phải là số nguyên và lớn hơn 0
            if (!Regex.IsMatch(txtSoLuongCo.Text, "^[0-9]+$")) WrongType += "Số Lượng Có Phải Là Số Nguyên Và Lớn Hơn 0\n";
            if (!Regex.IsMatch(txtDonGia.Text, "^[0-9]+$")) WrongType += "Đơn Giá Phải Là Số Nguyên Và Lớn Hơn 0\n";

            //Nếu có ít nhất 1 thông báo lỗi thì trả về
            if (!string.IsNullOrWhiteSpace(WrongType))
            {
                return WrongType;
            }

            return "No Error!!";
        }


        private void LoadWindow(object sender, RoutedEventArgs e)
        {
            DataGridLoadData();
        }

        ////5) Khi Thêm 1 bản ghi vào bảng SanPham cần kiểm tra dữ liệu hợp lệ và xử lý ngoại lệ  như sau: 
        ////+ Tất cả các trường dữ liệu phải nhập
        ////+ Kiểm tra số lượng có và đơn giá phải là số nguyên và > 0. 
        ////+ Khi thêm 1 bản ghi vào bảng, nếu trùng mã sản phẩm thì phải có thông báo.

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var database = new QLBanHang1Context();

                string Validate = ValidateData();

                if (!Validate.Equals("No Error!!")) throw new Exception(Validate);

                var query = (from elem in database.SanPhams
                             where elem.MaSp.ToLower().Equals(txtMa.Text.ToLower())
                             select elem).SingleOrDefault();

                if (query != null) throw new Exception("Không được thêm sản phẩm trùng mã!! Vui lòng chọn mã khác!!\n");

                var test1 = cboLoai.SelectedValue.ToString();

                //throw new Exception(test1);

                string? query2 = (from elem in database.LoaiSps
                                  where elem.TenLoai.Equals(test1)
                                  select elem.MaLoai).SingleOrDefault();

                if (!string.IsNullOrWhiteSpace(query2))
                {
                    database.SanPhams.Add(new SanPham()
                    {
                        MaSp = txtMa.Text,
                        TenSp = txtTen.Text,
                        DonGia = int.Parse(txtDonGia.Text),
                        SoLuongCo = int.Parse(txtSoLuongCo.Text),
                        MaLoai = query2
                    });

                    database.SaveChanges();

                    SanPhamDuocChon = null;
                    MessageBox.Show("Sửa thông tin thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    DataGridLoadData();
                }
                else
                {
                    throw new Exception("Không tồn tại loại sp này hoặc trùng tên!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ////6)	Khi sửa 1 bản ghi trong bảng SanPham cần kiểm tra dữ liệu hợp lệ và xử lý ngoại lệ như sau: 
        ////+Tất cả các trường dữ liệu phải nhập
        ////+Kiểm tra số lượng có và đơn giá phải là số nguyên và > 0. 
        ////+ Không sửa mã

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            //Phải làm yêu cầu click vào 1 dòng trên DataGrid mới thực hiện được mục sửa
            try
            {
                using var database = new QLBanHang1Context();

                string Validate = ValidateData(); //Kiểm tra dữ liệu

                if (!Validate.Equals("No Error!!")) throw new Exception(Validate);

                if (SanPhamDuocChon != null)
                {
                    if (!txtMa.Text.Equals(SanPhamDuocChon.MaSp))
                    {
                        txtMa.Text = SanPhamDuocChon.MaSp;
                        throw new Exception("Không cho phép sửa Mã Sản Phẩm");
                    }

                    MessageBoxResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn sửa lại thông tin sản phẩm này không ?", "Thông Báo", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        var SanPhamInDatabase = (from elem in database.SanPhams
                                                 where elem.MaSp.Equals(SanPhamDuocChon.MaSp)
                                                 select elem).SingleOrDefault();

                        if (SanPhamInDatabase == null)
                        {
                            throw new Exception("Không tìm được sản phẩm này!!!");
                        }

                        SanPhamInDatabase.TenSp = txtTen.Text;
                        SanPhamInDatabase.DonGia = int.Parse(txtDonGia.Text);
                        SanPhamInDatabase.SoLuongCo = int.Parse(txtSoLuongCo.Text);
                        SanPhamInDatabase.MaLoai = danhSachLoaiSanPham[cboLoai.SelectedIndex].MaLoai;

                        database.SaveChanges();

                        DataGridLoadData();
                        SanPhamDuocChon = null;
                        MessageBox.Show("Sửa thông tin thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hủy sửa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            //Phải làm yêu cầu click vào 1 dòng trên DataGrid mới thực hiện được mục xóa
            MessageBoxResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm này không ?", "Thông Báo", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (dialogResult == MessageBoxResult.Yes)
            {
                using var database = new QLBanHang1Context();

                var SanPhamInDatabase = (from elem in database.SanPhams
                                         where elem.MaSp.Equals(txtMa.Text)
                                         select elem).SingleOrDefault();

                if (SanPhamInDatabase == null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại trong CSDL", "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    database.SanPhams.Remove(SanPhamInDatabase); //Xóa sản phẩm
                    database.SaveChanges(); //Lưu vào database dữ liệu của bảng Sản Phẩm
                    DataGridLoadData(); //Load lại DataGrid cập nhật thông tin
                    SanPhamDuocChon = null; //giải phóng sản phẩm được chọn cho sự kiện Click dòng
                    MessageBox.Show("Xóa sản phẩm thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Hủy xóa thành công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //8)	Khi user chọn 1 dòng trong data grid thì hiển thị thông tin sản phẩm được chọn lên
        //      các điều khiển nhập liệu tương ứng
        private void SelectSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using var database = new QLBanHang1Context();

            var item = dgvSanPham.SelectedItem;

            if (item != null)
            {
                string MaSP = ((TextBlock)dgvSanPham.SelectedCells[0].Column.GetCellContent(item)).Text;
                SanPham sanPham = database.SanPhams.ToList().Find(elem => elem.MaSp.ToLower().Equals(MaSP.ToLower()));

                if (sanPham != null)
                {
                    txtMa.Text = sanPham.MaSp;
                    txtTen.Text = sanPham.TenSp;
                    txtDonGia.Text = sanPham.DonGia.ToString();
                    txtSoLuongCo.Text = sanPham.SoLuongCo.ToString();

                    for (int i = 0; i < danhSachLoaiSanPham.Count(); i++)
                    {
                        if (danhSachLoaiSanPham[i].MaLoai.Equals(sanPham.MaLoai))
                        {
                            cboLoai.SelectedIndex = i;
                        }
                    }

                    SanPhamDuocChon = sanPham; //Lưu sản phẩm để check mã
                }
            }
        }
    }
            private void btnTim_Click(object sender, RoutedEventArgs e)
            {
                new Window2().Show();
            }
        }
    }

