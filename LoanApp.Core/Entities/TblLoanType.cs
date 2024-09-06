using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblLoanType
{
    public Guid LoanTypeId { get; set; }

    public string? LoanTypeName { get; set; }

    public decimal? LoanForecloserCharge { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblLoanMaster> TblLoanMasters { get; set; } = new List<TblLoanMaster>();
}
