using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewler.Model {
    class ExplorerManagement {
        public string getFilePath() {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog()) {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            }
        }
    }
}
