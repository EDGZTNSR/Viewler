using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Viewler.Model {
    class FolderIcon { // Not implemented yet
        private ImageSource _folderIcon;
        private string iconname;
        private string iconpath;

        public ImageSource imageSource{
            get { return _folderIcon; }
            set { _folderIcon = value; }
        }
    }
}
