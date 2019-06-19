using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Viewler.Controller {
    public static class TreeViewExtender {
        public static void SelectItem(this TreeView treeView, object item) {
            var TreeViewItem = treeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
            if (TreeViewItem != null) {
                TreeViewItem.IsSelected = true;
            }
        }
    }
}
