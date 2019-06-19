using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Viewler {
    public partial class MainWindow : Window {
        public string _path;
        private ItemProvider _itemProvider = new ItemProvider();
        private ImageProvider _imageProvider = new ImageProvider();
        private FolderProvider _folderProvider = new FolderProvider();
        private DocumentProvider _documentProvider = new DocumentProvider();

        public MainWindow() {
            InitializeComponent();
            DataContext =_itemProvider.InitializeItems("C:\\Temp");// Temporary Path
            _itemProvider.TreeViewNodeIsExpanded(ItemTreeView, true);
        }
        // Area Folder
        private void OnClickMenuItemOpen(object sender, RoutedEventArgs e) {
            _path = _folderProvider.GetNewDialogResult();
            if (!String.IsNullOrEmpty(_path)) {
                DataContext = _itemProvider.InitializeItems(_path);
                _itemProvider.TreeViewNodeIsExpanded(ItemTreeView, true);
            }
        }
        private void OnClickMenuItemExit(object sender, RoutedEventArgs e) {
            Close();
        }
        //Area Process
        private void OnClickMenuItemOpenDoc(object sender, RoutedEventArgs e) {
            string itemPath = _itemProvider.GetItem(ItemTreeView, _path);
            _documentProvider.OpenDocument(itemPath);
        }
        private void OnClickMenuItemDelete(object sender, RoutedEventArgs e) {
            string itemPath = _itemProvider.GetItem(ItemTreeView, _path);
            File.Delete(itemPath);
            DataContext = _itemProvider.InitializeItems(_path);
            _itemProvider.TreeViewNodeIsExpanded(ItemTreeView, true);
        }
        //Area Info
        private void OnClickMenuItemInfo(object sender, RoutedEventArgs e) {
            Process.Start("https://github.com/EDGZTNSR/Viewler");
        }
        //TreeView Area
        private void OnSelectedItemChange(object sender, RoutedPropertyChangedEventArgs<object> e) {
            if (ItemTreeView.SelectedItem != null) {
                string itemPath = _itemProvider.GetItem(ItemTreeView, _path);
                _imageProvider.SetImage(itemPath, ViewlerImage);
            }
        }
    }
}
