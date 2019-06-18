using System.Windows.Forms;

namespace Viewler.Model {
    class ExplorerManagement {
        // Gets the Path to the currnet item
        public string getFilePath() {
            using (var dialog = new FolderBrowserDialog()) {
                DialogResult result = dialog.ShowDialog();
                
            }
            return "";
        }
    }
}
