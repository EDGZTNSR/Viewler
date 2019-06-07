using System.Collections.Generic;
using System.IO;
using Viewler.Model;

namespace Viewler {
    class ItemProvider {
        public List<Item> GetItems(string _path) {
            var items = new List<Item>();
            var dirInfo = new DirectoryInfo(_path);

            foreach (var directory in dirInfo.GetDirectories()) {
                var item = new DirectoryItem {
                    Name = directory.Name,
                    Path = directory.FullName,
                    Items = GetItems(directory.FullName)
                };
                items.Add(item);
            }

            foreach (var file in dirInfo.GetFiles()) {
                var item = new FileItem {
                    Name = file.Name,
                    Path = file.FullName
                };
                items.Add(item);
            }
            return items;
        }
    }
}