using System;
using System.Collections.Generic;
using System.IO;
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

namespace Bai9._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string MySavingFile 
        { 
            get
            {
                return "MySavingFile.txt";
            }
        }

        private static void ShutDownApp()
        {
            Application.Current.Shutdown();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoadingForm(object sender, RoutedEventArgs e)
        {
            List<string> res1 = new List<string>();

            try
            {
                using (StreamReader streamReader = new StreamReader(MySavingFile))
                {
                    while (!streamReader.EndOfStream)
                    {
                        res1.Add(streamReader.ReadLine());
                    }
                }

                lbThongTin.ItemsSource = res1;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Không Tìm Được File Lưu \n(File Lưu Có Dạng MySavingFile.txt ở Thư Mục Debug)", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                ShutDownApp();
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Bạn có muốn thêm thông tin này không ?", "Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (messageBoxResult == MessageBoxResult.No)
                {
                    return;
                }

                using (StreamWriter streamWriter = File.AppendText(MySavingFile))
                {
                    if(string.IsNullOrWhiteSpace(txtHoTen.Text))
                    {
                        throw new Exception("Không được để trống tên!!!");
                    }

                    string res2 = txtHoTen.Text + " - ";
                    res2 += (cbGioiTinh.SelectedItem as ComboBoxItem).Content.ToString() + " - ";
                    res2 += (cbPhongBan.SelectedItem as ComboBoxItem).Content.ToString();

                    streamWriter.WriteLine(res2);
                }

                OnLoadingForm(sender, e);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Không Tìm Được File Lưu \n(File Lưu Có Dạng MySavingFile.txt ở Thư Mục Debug)", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                ShutDownApp();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            ShutDownApp(); 
        }

        private void OnClosingForm(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.No)
            {
                e.Cancel = true; //Khi đặt e.Cancel = true, sự kiện Tắt app sẽ không được chạy
                return;
            }
        }
    }
}
