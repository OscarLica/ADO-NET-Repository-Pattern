using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagHelpers.Context.Interface;

namespace TagHelpers.Context.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IUnitOfWorkAdapter Create()
        {
            var connectionString = _configuration.GetValue<string>("DefaultConnection");
            return new UnitOfWorkSqlAdapter(connectionString);
        }
    }
}
