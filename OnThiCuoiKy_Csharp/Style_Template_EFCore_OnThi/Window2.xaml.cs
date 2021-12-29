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
using System.Windows.Shapes;
//using Style_Template_EFCore_OnThi.Models;

namespace Style_Template_EFCore_OnThi
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //LoadData();
        }

        //public void LoadData()
        //{
        //    using var database = new QLBanHang1Context();

        //    var query = from elem in database.HoaDonChiTiets
        //                group elem by elem.MaSp into spGroup
        //                select new
        //                {
        //                    MaSP = spGroup.Key,
        //                    SoLuongDaBan = spGroup.Sum(x => x.SoLuongMua)
        //                };

        //    var query2 = from spBan in query
        //                 join sp in database.SanPhams
        //                 on spBan.MaSP equals sp.MaSp
        //                 select new
        //                 {
        //                     MaSP = sp.MaSp,
        //                     TenSP = sp.TenSp,
        //                     TenLoai = sp.MaLoaiNavigation.TenLoai,
        //                     DonGia = sp.DonGia,
        //                     SoLuongDaBan = spBan.SoLuongDaBan,
        //                     TongTien = sp.DonGia * spBan.SoLuongDaBan
        //                 };

        //    dgvSanPham.ItemsSource = query2.ToList();
        //}

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
