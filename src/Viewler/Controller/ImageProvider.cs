using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Viewler {
    class ImageProvider {
        // Public Function to set the Image on the ViewlerImage
        public bool SetImage(string imagePath, Image image) {
            if (imagePath != null) {
                BitmapImage bitMapImg = new BitmapImage();
                bitMapImg.BeginInit();
                bitMapImg.CacheOption = BitmapCacheOption.OnLoad;
                bitMapImg.UriSource = new Uri(imagePath);
                bitMapImg.EndInit();
                image.Source = bitMapImg;
                return true;
            } else {
                return false;
            }
        }
        // Validating if its a Picture type (GIF is currently not tested)
        public bool IsValidImage(string filepath) {
            List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".ICO"};
            var fileExtension = Path.GetExtension(filepath);
            if (ImageExtensions.Contains(Path.GetExtension(filepath).ToUpperInvariant())) {
                return true;
            }
            FileAttributes attr = File.GetAttributes(@filepath);
            if (attr.HasFlag(FileAttributes.Directory)) {
                return true;
            } else {
                return false;
            }
        }
    }
}
