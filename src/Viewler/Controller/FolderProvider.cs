using System;
using System.IO;
using System.Windows.Forms;
using System.Windows;

namespace Viewler {
    class FolderProvider: Window {
        public string getDialogResult() {
            using (var fdb = new FolderBrowserDialog()) {
                DialogResult result = fdb.ShowDialog();
                if (DialogResult.HasValue) {
                    string[] files = Directory.GetFiles(fdb.SelectedPath);
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
                return fdb.SelectedPath;
            }
        }
    }
}
