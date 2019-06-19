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
        // Area File
        private void OnClickMenuItemOpen(object sender, RoutedEventArgs e) {
            _path = _folderProvider.GetNewDialogResult();
            if (!String.IsNullOrEmpty(_path)) {
                RefreshTreeView();
                _itemProvider.TreeViewNodeIsExpanded(ItemTreeView, true);
            }
        }
        private void OnClickMenuItemExit(object sender, RoutedEventArgs e) {
            Close();
        }
        private void OnClickMenuItemOpenDoc(object sender, RoutedEventArgs e) {
            string itemPath = _itemProvider.GetItem(ItemTreeView, _path);
            _documentProvider.OpenDocument(itemPath);
        }
        private void OnClickMenuItemAdd(object sender, RoutedEventArgs e) {
            //Directory.CreateDirectory(_path + "\\New"); --> Adds new Folder but i need to create a FIle i think
            string itemPath = _documentProvider.AddFile(_path);
            if (!String.IsNullOrEmpty(itemPath)) {
                RefreshTreeView();
                _itemProvider.TreeViewNodeIsExpanded(ItemTreeView, true);
            }
        }
        private void OnClickMenuItemDelete(object sender, RoutedEventArgs e) {
            string itemPath = _itemProvider.GetItem(ItemTreeView, _path);
            File.Delete(itemPath);
            RefreshTreeView();
            _itemProvider.TreeViewNodeIsExpanded(ItemTreeView, true);
        }
        //Area Edit

        //Area Help
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
        public void RefreshTreeView() {
            DataContext = _itemProvider.InitializeItems(_path);
        }
    }
}
