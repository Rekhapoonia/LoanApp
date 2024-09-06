using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblAccountType
{
    public Guid AccountTypeId { get; set; }

    public string? AccountTypeName { get; set; }

    public bool? IsActive { get; set; }
}
