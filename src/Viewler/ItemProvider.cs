using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Viewler.Model;

namespace Viewler {
    class ItemProvider { // Item handler Class
        public List<Item> GetItems(string path) {
            var items = new List<Item>();
            var dirInfo = new DirectoryInfo(path);
            // Get all the directories
            foreach (var directory in dirInfo.GetDirectories()) {
                if (IsValidImage(directory.FullName)) {
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
                if (IsValidImage(file.FullName)) {
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
        // Public Function to set the Image on the ViewlerImage
        public bool SetImage(string imagePath, Image image) {
            if (imagePath != null) {
                BitmapImage bitMapImg = new BitmapImage();
                bitMapImg.BeginInit();
                bitMapImg.UriSource = new Uri(imagePath);
                bitMapImg.EndInit();
                image.Source = bitMapImg;
                return true;
            } else {
                return false;
            }
        }

        // Validating if its a Picture type (GIF is currently not tested)
        private bool IsValidImage(string filepath) {
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
            var fileExtension = Path.GetExtension(filepath);
            if (ImageExtensions.Contains(Path.GetExtension(filepath).ToUpperInvariant())) {
                return true;
            } 
            FileAttributes attr = File.GetAttributes(@filepath);
            if (attr.HasFlag(FileAttributes.Directory)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}