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
using NguyenNhatMinh_285.Models;

namespace NguyenNhatMinh_285
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Product? SanPhamDuocChon;
        private SALESMANAGEMENTContext database;
        public MainWindow()
        {
            InitializeComponent();
            //Đặt app giữa màn hình
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //Kết nối đến CSDL
            database = new SALESMANAGEMENTContext();
            SanPhamDuocChon = null;
            //Câu 2f:Sử dụng ComboBox hiển thị Category Name từ bảng Category
            //nhưng khi chọn thì lấy Category ID để cập nhật dữ liệu.
            LoadCategoryComboBox();
        }

        private void LoadCategoryComboBox()
        {
            //Lấy ra danh sách đối tượng Category
            var query = (from elem in database.Categories
                         select elem);

            //Gán vào combobox
            cboCategory.ItemsSource = query.ToList();

            //DisplayMemberPath: thuộc tính hiển thị thông tin
            cboCategory.DisplayMemberPath = "CatName";

            //SelectedValuePath: giá trị nhận về khi chọn 1 phần trong ComboBox
            cboCategory.SelectedValuePath = "CatId";
            cboCategory.SelectedIndex = 0;
        }

        public void LoadDataGrid()
        {
            //elem: 1 dòng trong bảng Product
            //ascending : tăng dần
            var query = from elem in database.Products
                        where elem.Quantity <= 150
                        orderby elem.ProductName ascending
                        select new
                        {
                            ProductID = elem.ProductId,
                            ProductName = elem.ProductName,
                            CategoryID = elem.CatId,
                            UnitPrice = elem.UnitPrice,
                            Quantity = elem.Quantity,
                            Amount = elem.UnitPrice * elem.Quantity
                        };

            //ItemSource chứa dữ liệu datagrid
            dtgrProduct.ItemsSource = query.ToList();
        }

        //Xứ lý ngoại lệ và kiểm tra người dùng nhập vào
        private bool ValidateData()
        {
            try
            {
                //Có ít nhất 1 ô chưa điền hoặc chọn thông tin
                //IsNullOrWhiteSpace : kiểm tra trống hoặc chỉ có khoảng trắng
                if (string.IsNullOrWhiteSpace(txtProductID.Text) ||
                    string.IsNullOrWhiteSpace(txtProductName.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                    string.IsNullOrWhiteSpace(txtUnitPrice.Text) ||
                    cboCategory.SelectedIndex < 0)
                {
                    //Khi throw 1 exception thì chương trình dừng ngay lập tức và chuyển sang việc khác
                    throw new Exception("Thông tin phải được điền đầy đủ!!");
                }

                //Nhập vào đảm bảo là chữ số
                if (Regex.IsMatch(txtQuantity.Text, @"\d+"))
                {
                    int value1 = int.Parse(txtQuantity.Text);

                    if (value1 < 0)
                    {
                        //Khi throw 1 exception thì chương trình dừng ngay lập tức và chuyển sang việc khác
                        throw new Exception("Số lượng nhập vào phải lớn hơn hoặc bằng 0");
                    }
                }
                else
                {
                    //Khi throw 1 exception thì chương trình dừng ngay lập tức và chuyển sang việc khác
                    throw new Exception("Số Lượng Nhập Vào Phải Là Số Nguyên!!");
                }

                if (Regex.IsMatch(txtUnitPrice.Text, @"\d+"))
                {
                    int value1 = int.Parse(txtUnitPrice.Text);

                    if (value1 < 0)
                    {
                        //Khi throw 1 exception thì chương trình dừng ngay lập tức và chuyển sang việc khác
                        throw new Exception("Đơn giá nhập vào phải lớn hơn hoặc bằng 0");
                    }
                }
                else
                {
                    //Khi throw 1 exception thì chương trình dừng ngay lập tức và chuyển sang việc khác
                    throw new Exception("Đơn giá nhập vào Nhập Vào Phải Là Số Nguyên!!");
                }

                //Nếu không có bất kỳ lỗi gì trả về True
                return true;
            }
            catch (Exception ex)
            {   
                //Có ít nhất 1 lỗi trả về False và đưa ra thông báo
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void LoadWindow(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Kiểm tra dữ liệu họp lệ hay ko
                if (ValidateData())
                {
                    //Check trùng mã
                    var CheckTrungMa = (from elem in database.Products
                                        where elem.ProductId.Equals(txtProductID.Text)
                                        select elem).SingleOrDefault();

                    //Nếu sản phẩm không null tức là có ít nhất 1 sản phẩm trùng mã
                    if (CheckTrungMa != null)
                    {
                        //Khi throw 1 exception thì chương trình dừng ngay lập tức và chuyển sang việc khác
                        throw new Exception("Mã Sản Phẩm Đã Tồn Tại Trong CSDL");
                    }

                    //Tạo 1 sản phẩm và thêm vào trong CSDL
                    database.Products.Add(new Product()
                    {
                        ProductId = txtProductID.Text,
                        ProductName = txtProductName.Text,
                        Quantity = int.Parse(txtQuantity.Text),
                        UnitPrice = int.Parse(txtUnitPrice.Text),
                        CatId = cboCategory.SelectedValue.ToString()
                    });

                    //Lưu lại
                    database.SaveChanges();

                    //Cập nhật lại DataGrid, hiển thị dữ liệu mới
                    LoadDataGrid();

                    //Đặt về trạng thái ban đầu
                    Reset();
                    MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Đặt về trạng thái ban đầu
        private void Reset()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtQuantity.Clear();
            txtUnitPrice.Clear();
            cboCategory.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ValidateData() && SanPhamDuocChon != null)
                {
                    //Nếu phát hiện sửa mã
                    if (!txtProductID.Text.Equals(SanPhamDuocChon.ProductId))
                    {
                        txtProductID.Text = SanPhamDuocChon.ProductId;
                        throw new Exception("Không cho phép sửa mã!!!");
                    }

                    //Tìm về CSDL sản phẩm đấy
                    var SanPhamInDB = (from elem in database.Products
                                       where elem.ProductId.Equals(txtProductID.Text)
                                       select elem).SingleOrDefault();

                    //Gán lại thông tin
                    if(SanPhamInDB != null)
                    {
                        SanPhamInDB.ProductName = txtProductName.Text;
                        SanPhamInDB.CatId = cboCategory.SelectedValue.ToString();
                        SanPhamInDB.UnitPrice = int.Parse(txtUnitPrice.Text);
                        SanPhamInDB.Quantity = int.Parse(txtQuantity.Text);

                        SanPhamDuocChon = null;

                        //Lưu lại
                        database.SaveChanges();

                        //Cập nhật lại DataGrid, hiển thị dữ liệu mới
                        LoadDataGrid();

                        //Đặt về trạng thái ban đầu
                        Reset();
                        MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }    
                    
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateData() && SanPhamDuocChon != null)
                {
                    //Nếu phát hiện sửa mã
                    if (!txtProductID.Text.Equals(SanPhamDuocChon.ProductId))
                    {
                        txtProductID.Text = SanPhamDuocChon.ProductId;
                        throw new Exception("Không cho phép sửa mã!!!");
                    }

                    //Tìm về CSDL sản phẩm đấy
                    var SanPhamInDB = (from elem in database.Products
                                       where elem.ProductId.Equals(txtProductID.Text)
                                       select elem).SingleOrDefault();

                    //Gán lại thông tin
                    if (SanPhamInDB != null)
                    {
                        database.Products.Remove(SanPhamInDB);
                        SanPhamDuocChon = null;

                        //Lưu lại
                        database.SaveChanges();

                        //Cập nhật lại DataGrid, hiển thị dữ liệu mới
                        LoadDataGrid();

                        //Đặt về trạng thái ban đầu
                        Reset();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show(); //Chạy chương trình
        }

        private void ChonSanPham(object sender, SelectionChangedEventArgs e)
        {
            //Khi kích 1 dòng trên DataGrid sẽ trả về 1 SelectedItem
            var SanPham = dtgrProduct.SelectedItem;

            //Chắc chắn đã chọn sản phẩm thì không null
            if(SanPham != null)
            {
                string ProductID = (dtgrProduct.SelectedCells[0].Column.GetCellContent(SanPham) as TextBlock).Text;

                //Tìm về CSDL sản phẩm đấy
                var SanPhamInDB = (from elem in database.Products
                                   where elem.ProductId.Equals(ProductID)
                                   select elem).SingleOrDefault();

                if(SanPhamInDB != null)
                {
                    txtProductID.Text = SanPhamInDB.ProductId;
                    txtProductName.Text = SanPhamInDB.ProductName;
                    txtQuantity.Text = SanPhamInDB.Quantity.ToString();
                    txtUnitPrice.Text = SanPhamInDB.UnitPrice.ToString();
                    cboCategory.SelectedValue = SanPhamInDB.CatId;

                    SanPhamDuocChon = SanPhamInDB;
                }
            }    
        }
    }
}
