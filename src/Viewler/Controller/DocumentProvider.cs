using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Viewler {
    class DocumentProvider {
        public void OpenDocument(string filepath) {
            if (!String.IsNullOrEmpty(filepath)){
                ExecuteAsAdmin(@filepath);
            } else {
                MessageBox.Show("No Item selected");
            }
        }
        private void ExecuteAsAdmin(string filepath) { // Not working for Domain Users!!!! idk why
            Process p = new Process();
            p.StartInfo.FileName = filepath;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.Verb = "edit";
            p.Start();
        }
    }
}
