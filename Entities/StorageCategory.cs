using System;
using System.Collections.Generic;

namespace WarehouseAPI
{
    public partial class StorageCategory
    {
        public int StorCatId { get; set; }
        public int StorCatWrhId { get; set; }
        public string StorCatName { get; set; } = null!;

        public virtual Warehouse StorCatWrh { get; set; } = null!;
    }
}
