using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;
using Viewler.Model;

namespace Viewler {
    class ItemProvider { // Item handler Class
        public List<Item> GetItems(string path) {
            var items = new List<Item>();
            var dirInfo = new DirectoryInfo(path);
            ImageProvider imageProvider = new ImageProvider();
            // Get all the directories
            foreach (var directory in dirInfo.GetDirectories()) {
                if (imageProvider.IsValidImage(directory.FullName)) {
                    var item = new DirectoryItem {
                        Name = directory.Name,
                        Path = directory.FullName,
                        Items = GetItems(directory.FullName)
                    };
                    items.Add(item);
                }
            }
            // Get all the Files
            foreach (var file in dirInfo.GetFiles()) {
                if (imageProvider.IsValidImage(file.FullName)) {
                    var item = new FileItem {
                        Name = file.Name,
                        Path = file.FullName
                    };
                    items.Add(item);
                }
            }
            return items;
        }
        // Get Single Item
        public string GetItem(TreeView ItemTreeView, string path) {
            var selectedItem = ItemTreeView.SelectedItem as FileItem;
            if (selectedItem != null)
                return selectedItem.Path;
            return null;
        }
        //initilaize Items
        public List<Item> InitializeItems(string path) {
            ItemProvider itemProvider = new ItemProvider();
            var items = itemProvider.GetItems(path);
            return items;
        }
    }
}