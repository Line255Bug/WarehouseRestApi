using System;
using System.Collections.Generic;

namespace WarehouseAPI
{
    public partial class WarehouseSection
    {
        public int SectionId { get; set; }
        public int SectionWrhId { get; set; }
        public string SectionName { get; set; } = null!;

        public virtual Warehouse SectionWrh { get; set; } = null!;
    }
}
