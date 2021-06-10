using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TagHelpers.Repository;

namespace TagHelpers.Context.Interface
{
    public interface IUnitOfWorkRepository
    {
        public IClientRepository _ClientRepository { get; }
    }
}
