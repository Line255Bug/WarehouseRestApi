using System;
using System.Collections.Generic;

namespace WarehouseAPI
{
    public partial class SysUser
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
