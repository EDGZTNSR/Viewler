using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using Viewler.Model;

namespace Viewler {
    class ItemProvider {
        public List<Item> GetItems(string path) {
            var items = new List<Item>();
            var dirInfo = new DirectoryInfo(path);

            foreach (var directory in dirInfo.GetDirectories()) {
                if (IsValidImage(directory.FullName) || IsFolder(directory.FullName)) {
                    var item = new DirectoryItem {
                        Name = directory.Name,
                        Path = directory.FullName,
                        Items = GetItems(directory.FullName)
                    };
                    items.Add(item);
                }
            }

            foreach (var file in dirInfo.GetFiles()) {
                if (IsValidImage(file.FullName) || IsFolder(file.FullName)) {
                    var item = new FileItem {
                        Name = file.Name,
                        Path = file.FullName
                    };
                    items.Add(item);
                }
            }
            return items;
        }
        public string GetItem(TreeView ItemTreeView, string path) {
            var selectedItem = ItemTreeView.SelectedItem as FileItem;
            if (selectedItem != null)
                return selectedItem.Path;
            return "No Item Found";
        }
        private bool IsValidImage(string filePath) {
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
            var fileExtension = Path.GetExtension(filePath);
            if (ImageExtensions.Contains(Path.GetExtension(filePath).ToUpperInvariant())) {
                return true;
            } else {
                return false;
            }
        }
        public bool IsFolder(string filepath) {
            FileAttributes attr = File.GetAttributes(@filepath);
            if (attr.HasFlag(FileAttributes.Directory)) {
                return true;
            } else {
                return false;
            }
        }
    }
}