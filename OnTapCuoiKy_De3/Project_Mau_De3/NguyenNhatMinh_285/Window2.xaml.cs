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
using NguyenNhatMinh_285.Models;

namespace NguyenNhatMinh_285
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private SALESMANAGEMENTContext database;

        public Window2()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            database = new SALESMANAGEMENTContext();
            LoadWindow2DataGrid();
        }

        private void LoadWindow2DataGrid()
        {
            var query = from elem in database.Products
                        group elem by elem.CatId into CategoryGroup
                        select new
                        {
                            CategoryID = CategoryGroup.Key, //Mã Nhóm
                            Total = CategoryGroup.Sum(prod => prod.Quantity * prod.UnitPrice)
                        };

            var queryHienThi = from elem1 in query
                               join elem2 in database.Categories
                               on elem1.CategoryID equals elem2.CatId
                               select new
                               {
                                   CategoryID = elem1.CategoryID,
                                   CategoryName = elem2.CatName,
                                   Total = elem1.Total
                               };

            dtgrProduct.ItemsSource = queryHienThi.ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
