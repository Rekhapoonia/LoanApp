using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Core.Interfaces
{
    public interface IFactoryRepository
    {
        IAuthRepository authRepository();
    }
}
