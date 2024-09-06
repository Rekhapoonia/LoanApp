using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblUserMaster
{
    public Guid UserId { get; set; }

    public Guid? UserRoleId { get; set; }

    public string? UserName { get; set; }

    public string? UserSpouseName { get; set; }

    public string? UserMobile { get; set; }

    public string? UserAddress { get; set; }

    public Guid? UserCityId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsEnabled { get; set; }

    public DateTime? UserCreateDate { get; set; }

    public Guid? CreateBy { get; set; }

    public string Password { get; set; } = null!;

    public virtual TblUserMaster? CreateByNavigation { get; set; }

    public virtual ICollection<TblUserMaster> InverseCreateByNavigation { get; set; } = new List<TblUserMaster>();

    public virtual ICollection<TblLoanMaster> TblLoanMasterCreateByNavigations { get; set; } = new List<TblLoanMaster>();

    public virtual ICollection<TblLoanMaster> TblLoanMasterLoanUsers { get; set; } = new List<TblLoanMaster>();

    public virtual TblCityMaster? UserCity { get; set; }

    public virtual TblRoleMaster? UserRole { get; set; }
}
