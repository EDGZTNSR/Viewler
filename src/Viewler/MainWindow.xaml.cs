using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Viewler.Model;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Viewler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _path;

        public MainWindow() {
            InitializeComponent();
            InitializeItems("C:\\Users\\dpohland\\Documents\\temp");
        }

        private void OnClickMenuItemNew(object sender, RoutedEventArgs e) {

        }

        private void OnClickMenuItemOpen(object sender, RoutedEventArgs e) {

            _path = getDialogResult();
            if (_path != "")
                InitializeItems(_path);
        }

        private void OnClickMenuItemExit(object sender, RoutedEventArgs e) {
            Close();
        }
        // Please Test
        private void OnSelectedItemChange(object sender, RoutedPropertyChangedEventArgs<object> e) {
            if (ItemTreeView.SelectedItem != null) { //&& _path != null
                ItemProvider itemProvider = new ItemProvider();
                string itemPath = itemProvider.GetItem(ItemTreeView, _path);
                itemProvider.SetImage(itemPath, ViewlerImage);
            }
        }

        //Methods
        private string getDialogResult() {
            using (var fdb = new FolderBrowserDialog()) {
                DialogResult result = fdb.ShowDialog();
                if (DialogResult.HasValue) {
                    string[] files = Directory.GetFiles(fdb.SelectedPath);
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
                return fdb.SelectedPath;
            }
        }
        private void InitializeItems(string path) {
            ItemProvider itemProvider = new ItemProvider();
            var items = itemProvider.GetItems(path);
            DataContext = items;
        }
    }
}
