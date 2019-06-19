using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.IO;
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
        // Open File Dialog for Add Functionality
        public string AddFile(string folderpath) {
            using (var dialog = new CommonOpenFileDialog()) {
                dialog.Title = "Please pick a File";
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok) {
                    string filename = Path.GetFileName(dialog.FileName);
                    string targetpath = folderpath + "\\" + filename;
                    File.Move(dialog.FileName, targetpath);
                    return targetpath;
                } else {
                    return "";
                }
            }
        }

    }
}
