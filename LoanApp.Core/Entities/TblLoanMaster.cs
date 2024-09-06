using System;
using System.Collections.Generic;

namespace Entities;

public partial class TblLoanMaster
{
    public Guid LoanMasterId { get; set; }

    public Guid? LoanUserId { get; set; }

    public Guid? LoanTypeId { get; set; }

    public decimal? LoanPrincipal { get; set; }

    public decimal? LoanPrincipalPending { get; set; }

    public decimal? LoanIntrestRate { get; set; }

    public int? LoanPeriod { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? LoanCreateDate { get; set; }

    public DateTime? EmiDate { get; set; }

    public DateTime? EmiReceivedDate { get; set; }

    public int? PendingEmi { get; set; }

    public Guid? CreateBy { get; set; }

    public DateTime? LoanCloseDate { get; set; }

    public virtual TblUserMaster? CreateByNavigation { get; set; }

    public virtual TblLoanType? LoanType { get; set; }

    public virtual TblUserMaster? LoanUser { get; set; }
}
