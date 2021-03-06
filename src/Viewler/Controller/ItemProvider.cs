﻿using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;
using Viewler.Model;

namespace Viewler {
    class ItemProvider { // Item handler Class
        
        public static TreeView _TreeView { private get; set; }

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
        public string GetItem(TreeView ItemTreeView) {
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
        // Open all TreeNodes (Will be an Option later to chose if Open or Not)
        public void TreeViewNodeIsExpanded(bool status) {
            if (status) {
                TreeViewItem tvi = new TreeViewItem();
                tvi = GetTreeViewItem(_TreeView, _TreeView.SelectedItem);
                if (tvi != null) {
                    tvi.ExpandSubtree();
                }
            }
        }
        //Traverse TreeView to find the TreeView Item
        private TreeViewItem GetTreeViewItem(ItemsControl parent, object item) {
            TreeViewItem tvi =
                parent.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
            if (tvi == null) {
                foreach (object child in parent.Items) {
                    TreeViewItem childItem =
                        parent.ItemContainerGenerator.ContainerFromItem(child) as TreeViewItem;
                    if (childItem != null) {
                        tvi = GetTreeViewItem(childItem, item);
                    }
                }
            }
            return tvi;
        }
    }
}