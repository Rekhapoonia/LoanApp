using Data;
using LoanApp.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbLoanContext _context;
        private readonly IConfiguration _configuration;

        public IAuthRepository authRepository { get; private set; }
        public UnitOfWork(DbLoanContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            authRepository = new AuthRepository(_context, _configuration);
        }
    }
}
