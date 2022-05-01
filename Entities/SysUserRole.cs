using System;
using System.Collections.Generic;

namespace WarehouseAPI
{
    public partial class SysUserRole
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public virtual SysRole Role { get; set; } = null!;
        public virtual SysUser User { get; set; } = null!;
    }
}
