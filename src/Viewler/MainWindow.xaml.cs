using System.Diagnostics;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Viewler
{
    public partial class MainWindow : Window
    {
        private string _path;
        private ItemProvider _itemProvider = new ItemProvider();
        private ImageProvider _imageProvider = new ImageProvider();
        private FolderProvider _folderProvider = new FolderProvider();

        public MainWindow() {
            InitializeComponent();
            DataContext =_itemProvider.InitializeItems("C:\\Users\\dpohland\\Documents\\temp");
        }
        private void OnClickMenuItemNew(object sender, RoutedEventArgs e) {
            //not implemented yet
        }
        private void OnClickMenuItemOpen(object sender, RoutedEventArgs e) {
            _path = _folderProvider.GetNewDialogResult();
            if (_path != "")
                DataContext = _itemProvider.InitializeItems(_path);
        }
        private void OnClickMenuItemExit(object sender, RoutedEventArgs e) {
            Close();
        }
        private void OnClickMenuItemInfo(object sender, RoutedEventArgs e) {
            Process.Start("https://github.com/EDGZTNSR/Viewler");
        }
        private void OnSelectedItemChange(object sender, RoutedPropertyChangedEventArgs<object> e) {
            if (ItemTreeView.SelectedItem != null) {
                string itemPath = _itemProvider.GetItem(ItemTreeView, _path);
                _imageProvider.SetImage(itemPath, ViewlerImage);
            }
        }
    }
}
