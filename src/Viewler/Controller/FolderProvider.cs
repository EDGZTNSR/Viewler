using System;
using System.IO;
using System.Windows.Forms;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Viewler {
    class FolderProvider: Window {
        //--EDGZTNSR New FolderDialog. Delete Code in next Refactoring
        //public string getDialogResult() {
        //    using (var fdb = new FolderBrowserDialog()) {
        //        DialogResult result = fdb.ShowDialog();
        //        if (DialogResult.HasValue) {
        //            string[] files = Directory.GetFiles(fdb.SelectedPath);
        //        };
        //        return fdb.SelectedPath;
        //    }
        //}
        //++EDGZTNSR
        public string GetNewDialogResult() {
            using( var dialog = new CommonOpenFileDialog()) {
                dialog.IsFolderPicker = true;
                dialog.Title = "Please pick a Folder to open in Viewler";
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok) {
                    return dialog.FileName;
                } else {
                    return "";
                }
            }
        }
    }
}
