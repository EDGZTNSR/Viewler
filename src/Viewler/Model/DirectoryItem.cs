using System.Collections.Generic;

namespace Viewler.Model {
    class DirectoryItem: Item {
        public List<Item> Items { get; set; }

        public DirectoryItem() {
            Items = new List<Item>();
        }
    }
}
