using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Interfaces
{
    public interface IClientService
    {
        List<ClientVM> GetClients();

        Task<List<ClientVM>> GetClientsAsync();

        void Create(ClientAddVM client);
        int Delete(ClientDeleteVM client);
        void Update(ClientVM client);
    }
}
