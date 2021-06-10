using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpers.Context.Interface
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        public IUnitOfWorkRepository Repositories { get; }
        void SaveChanges();
    }
}
