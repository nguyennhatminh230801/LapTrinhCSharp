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

namespace Bai9._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ChooseSubject 
        { 
            get
            {
                return "ChooseSubject.txt";
            }
        }
        public string UnchooseSubject
        {
            get
            {
                return "UnchooseSubject.txt";
            }
        }
        public void SavingData()
        {
            using (StreamWriter streamWriter = new StreamWriter(UnchooseSubject))
            {
                List<string> res1 = listUnchooseBook1.Items.Cast<string>().ToList();

                foreach (var item in res1)
                {
                    streamWriter.WriteLine(item);
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(ChooseSubject))
            {
                List<string> res2 = listChooseBook1.Items.Cast<string>().ToList();

                foreach (var item in listChooseBook1.ItemsSource)
                {
                    streamWriter.WriteLine(item);
                }
            }
        }
        public static void ShutdownApp()
        {
            Application.Current.Dispatcher.Invoke(() => Application.Current.Shutdown());
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        //Khoi chay form
        private void OnLoadingForm(object sender, RoutedEventArgs e)
        {
            List<string> monhoc = new List<string>();
            List<string> monhoc2 = new List<string>();

            using (StreamReader streamReader = new StreamReader(UnchooseSubject))
            {
                while (!streamReader.EndOfStream)
                {
                    monhoc.Add(streamReader.ReadLine());
                }
            }

            using (StreamReader streamReader = new StreamReader(ChooseSubject))
            {
                while (!streamReader.EndOfStream)
                {
                    monhoc2.Add(streamReader.ReadLine());
                }
            }

            if (monhoc.Count == 0 && monhoc2.Count == 0)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Lỗi: Không load được dữ liệu!!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);

                if (messageBoxResult == MessageBoxResult.OK)
                {
                    ShutdownApp();
                }
            }

            listUnchooseBook1.ItemsSource = monhoc;
            listChooseBook1.ItemsSource = monhoc2;

            listChooseBook1.SelectedIndex = 0;
            listChooseBook1.Items.Refresh();
            listUnchooseBook1.SelectedIndex = 0;
            listUnchooseBook1.Items.Refresh();
        }

        private void btnChooseOne1_Click(object sender, RoutedEventArgs e)
        {
            if (listUnchooseBook1.SelectedItem == null)
            {
                MessageBox.Show("Danh sách trống!!! Không thể thêm", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var choose = listUnchooseBook1.SelectedItem.ToString();

            List<string> res1 = listUnchooseBook1.Items.Cast<string>().ToList();
            res1.Remove(choose);
            listUnchooseBook1.ItemsSource = res1;

            List<string> res2 = listChooseBook1.Items.Cast<string>().ToList();
            res2.Add(choose);
            listChooseBook1.ItemsSource = res2;

            SavingData();
            OnLoadingForm(sender, e);
        }

        private void btnUnchooseOne_Click(object sender, RoutedEventArgs e)
        {
            if (listChooseBook1.SelectedItem == null)
            {
                MessageBox.Show("Danh sách trống!!! Không thể thêm", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var choose = listChooseBook1.SelectedItem.ToString();

            List<string> res1 = listChooseBook1.Items.Cast<string>().ToList();
            res1.Remove(choose);
            listChooseBook1.ItemsSource = res1;

            List<string> res2 = listUnchooseBook1.Items.Cast<string>().ToList();
            res2.Add(choose);
            listUnchooseBook1.ItemsSource = res2;

            SavingData();
            OnLoadingForm(sender, e);
        }
        private void btnChooseAll_Click(object sender, RoutedEventArgs e)
        {
            if (listUnchooseBook1.SelectedItem == null)
            {
                MessageBox.Show("Đã chuyển hết sang Danh Sách Đã Chọn", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            using (StreamWriter streamWriter = File.AppendText(ChooseSubject))
            {
                List<string> res1 = new List<string>();

                using (StreamReader streamReader = new StreamReader(UnchooseSubject))
                {
                    while(!streamReader.EndOfStream)
                    {
                        res1.Add(streamReader.ReadLine());
                    }
                }

                foreach (var item in res1)
                {
                    streamWriter.WriteLine(item);
                }
            }

            File.WriteAllText(UnchooseSubject, string.Empty);
            OnLoadingForm(sender, e);
        }

        private void btnUnchooseAll_Click(object sender, RoutedEventArgs e)
        {
            if (listChooseBook1.SelectedItem == null)
            {
                MessageBox.Show("Đã chuyển hết sang Danh Sách Chưa Chọn", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            using (StreamWriter streamWriter = File.AppendText(UnchooseSubject))
            {
                List<string> res1 = new List<string>();

                using (StreamReader streamReader = new StreamReader(ChooseSubject))
                {
                    while (!streamReader.EndOfStream)
                    {
                        res1.Add(streamReader.ReadLine());
                    }
                }

                foreach (var item in res1)
                {
                    streamWriter.WriteLine(item);
                }
            }

            File.WriteAllText(ChooseSubject, string.Empty);
            OnLoadingForm(sender, e);
        }
    }
}
