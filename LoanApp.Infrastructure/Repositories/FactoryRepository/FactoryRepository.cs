using LoanApp.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Infrastructure.Repositories.FactoryRepository
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly IServiceProvider _serviceProvider;
        public FactoryRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAuthRepository authRepository()
        {
            return _serviceProvider.GetRequiredService<IAuthRepository>();
        }
    }
}
