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

namespace Bai9._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public enum WhiteSpaceTextBox : int
    {
        ChiSoDau,
        ChiSoCuoi,
        HoTen,
        KWTrongDinhMuc,
        KWVuotDinhMuc
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void setOnClick_btnThoat(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void setOnClick_btnTinh(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckIsNullOrWhiteSpace();
                
                string ThongBao = "Tên: " + txtHoTen.Text + "\n";

                int ChiSoDau, ChiSoCuoi;
                
                if(!int.TryParse(txtChiSoDau.Text, out ChiSoDau))
                {
                    throw new Exception("Chỉ số đầu không đúng định dạng");
                }

                if(!int.TryParse(txtChiSoCuoi.Text, out ChiSoCuoi))
                {
                    throw new Exception("Chỉ số cuối không đúng định dạng");
                }

                if(ChiSoDau > ChiSoCuoi)
                {
                    throw new Exception("Chỉ số đầu không được lớn hơn chỉ số cuối");
                }

                int SoKWTieuThu = ChiSoCuoi - ChiSoDau;
                txtSoKWTieuThu.Text = SoKWTieuThu.ToString();
                ThongBao += "Số KW Tiêu Thụ: " + txtSoKWTieuThu.Text + "\n";

                int SoKWTrongDinhMuc = Math.Min(SoKWTieuThu, 50);
                txtKWTrongDinhMuc.Text = SoKWTrongDinhMuc.ToString();

                int SoKWNgoaiDinhMuc = SoKWTieuThu - SoKWTrongDinhMuc;
                txtKWVuotDinhMuc.Text = SoKWNgoaiDinhMuc.ToString();

                int TongSoTien = SoKWTrongDinhMuc * 500 + SoKWNgoaiDinhMuc * 1000;
                txtTongTien.Text = TongSoTien.ToString();

                ThongBao += "Tổng số tiền: " + txtTongTien.Text;

                txtThongBao.Text = ThongBao;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CheckIsNullOrWhiteSpace()
        {
            string StringEmptyException = "Không được để trống các ô: ";
            string res = "";

            TextBox[] textBoxes = { txtChiSoDau, txtChiSoCuoi, txtHoTen };
            int i = 0;

            foreach (var item in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(item.Text))
                {
                    switch (i)
                    {
                        case (int)WhiteSpaceTextBox.ChiSoDau:
                            res += "Chỉ số đầu" + "-";
                            break;

                        case (int)WhiteSpaceTextBox.ChiSoCuoi:
                            res += "Chỉ số cuối" + "-";
                            break;

                        case (int)WhiteSpaceTextBox.HoTen:
                            res += "Họ Tên" + "-";
                            break;
                    }
                }

                i++;
            }

            var res1 = res.Split("-").ToList();

            res1 = (from elem in res1
                    where !string.IsNullOrWhiteSpace(elem)
                    select elem).ToList();

            res = string.Join(",", res1);

            if (!string.IsNullOrWhiteSpace(res))
            {
                StringEmptyException += res;
                throw new Exception(StringEmptyException);
            }
        }
    }
}
