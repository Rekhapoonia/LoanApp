using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblCityMaster
{
    public Guid CityId { get; set; }

    public string? CityName { get; set; }

    public Guid? DistrictId { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblDistrictMaster? District { get; set; }

    public virtual ICollection<TblUserMaster> TblUserMasters { get; set; } = new List<TblUserMaster>();
}
