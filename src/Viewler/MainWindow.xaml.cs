using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Viewler {
    public partial class MainWindow : Window {
        public string _path;
        private ItemProvider _itemProvider = new ItemProvider();
        private ImageProvider _imageProvider = new ImageProvider();
        private FolderProvider _folderProvider = new FolderProvider();
        private DocumentProvider _documentProvider = new DocumentProvider();

        public MainWindow() {
            _path = "C:\\Temp"; // Temporary Path
            InitializeComponent();
            DataContext =_itemProvider.InitializeItems(_path);
            ItemProvider._TreeView = ItemTreeView;
            _itemProvider.TreeViewNodeIsExpanded(true); //Expaning doesnt work
        }
        // Area File
        private void OnClickMenuItemOpen(object sender, RoutedEventArgs e) {
            _path = _folderProvider.GetNewDialogResult();
            if (!String.IsNullOrEmpty(_path)) {
                RefreshTreeView();
                _itemProvider.TreeViewNodeIsExpanded(true);
            }
        }
        private void OnClickMenuItemExit(object sender, RoutedEventArgs e) => Close();

        private void OnClickMenuItemOpenDoc(object sender, RoutedEventArgs e) {
            string itemPath = _itemProvider.GetItem(ItemTreeView);
            _documentProvider.OpenDocument(itemPath);
            RefreshTreeView();
        }
        private void OnClickMenuItemAdd(object sender, RoutedEventArgs e) {
            //Directory.CreateDirectory(_path + "\\New"); --> Adds new Folder but i need to create a FIle i think
            string itemPath = _documentProvider.AddFile(_path);
            if (!String.IsNullOrEmpty(itemPath)) {
                RefreshTreeView();
                _itemProvider.TreeViewNodeIsExpanded(true);
            }
        }
        private void OnClickMenuItemDelete(object sender, RoutedEventArgs e) {
            string itemPath = _itemProvider.GetItem(ItemTreeView);
            File.Delete(itemPath);
            RefreshTreeView();
            _itemProvider.TreeViewNodeIsExpanded(true);
        }
        //Area Edit

        //Area Help
        private void OnClickMenuItemInfo(object sender, RoutedEventArgs e) => Process.Start("https://github.com/EDGZTNSR/Viewler");
        //Area Refresh
        private void OnClickMenuItemRefresh(object sender, RoutedEventArgs e) {
            RefreshTreeView();
        }
        //TreeView Area
        private void OnSelectedItemChange(object sender, RoutedPropertyChangedEventArgs<object> e) {
            if (ItemTreeView.SelectedItem != null) {
                string itemPath = _itemProvider.GetItem(ItemTreeView);
                _imageProvider.SetImage(itemPath, ViewlerImage);
            }
        }
        public void RefreshTreeView() {
            string itemPath = _itemProvider.GetItem(ItemTreeView);
            DataContext = _itemProvider.InitializeItems(_path);
            ItemTreeView.SelectedValuePath = itemPath;
            _itemProvider.TreeViewNodeIsExpanded(true);
        }
        // Buttons to Control Image Flow
        private void OnClickBtnNext(object sender, RoutedEventArgs e) {
            string itemPath = _itemProvider.GetItem(ItemTreeView);
            if (!String.IsNullOrEmpty(_path)) {
                _imageProvider.NextImage(ItemTreeView, _path);
            }
        }

        private void OnClickBtnPrevious(object sender, RoutedEventArgs e) {
            _imageProvider.PreviousImage();
        }
        
        private void CommandBinding_Executed_Next(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) {
            
        }

        private void CommandBinding_Executed_Previous(object sender, System.Windows.Input.ExecutedRoutedEventArgs e) {
            //Maybe raise Click Event of Previous Button instead of this Code here. Dont know how to do it tough
        }


    }
}
