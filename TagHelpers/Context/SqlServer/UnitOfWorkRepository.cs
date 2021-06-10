using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TagHelpers.Context.Interface;
using TagHelpers.Repository;

namespace TagHelpers.Context.SqlServer
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IClientRepository _ClientRepository { get; }
        public UnitOfWorkRepository(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            _ClientRepository = new ClienteRepository(sqlConnection, sqlTransaction);
        }
    }
}
