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
        List<ClientVM> GetClients(ClientVM client);
        Task<List<ClientVM>> GetClientsAsync(ClientVM client);
        string Create(ClientAddVM client);
        string Delete(ClientDeleteVM client);
        string Update(ClientVM client);
        Task<string> DeleteAsync(ClientDeleteVM client);
        Task<string> CreateAsync(ClientAddVM client);
        Task<string> UpdateAsync(ClientVM client);
    }
}
