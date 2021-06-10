using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TagHelpers.Context.Interface;
using TagHelpers.Models;
using TagHelpers.Util;

namespace TagHelpers.Service
{
    public interface IClientService {
        public Response Create(Cliente cliente);
        public Response Update(Cliente cliente);
        public List<Cliente> GetAll();
        public Cliente Get(int id);
    }
    public class ClientService : IClientService
    {
        private IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Response Create(Cliente cliente)
        {
            using (var context = _unitOfWork.Create())
            {
                return context.Repositories._ClientRepository.Create(cliente);
            }
        }

        public Cliente Get(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                return context.Repositories._ClientRepository.Get(id);
            }
        }

        public List<Cliente> GetAll()
        {
            using (var context = _unitOfWork.Create())
            {
                return context.Repositories._ClientRepository.GetAll();
            }
        }

        public Response Update(Cliente cliente)
        {
            using (var context = _unitOfWork.Create())
            {
                return context.Repositories._ClientRepository.Update(cliente);
            }
        }
    }
}
