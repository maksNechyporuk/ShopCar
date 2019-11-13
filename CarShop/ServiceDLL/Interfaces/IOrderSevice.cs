using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Interfaces
{
    interface IOrderService
    {

        List<OrderShowVM> GetOrders();
        Task<List<OrderShowVM>> GetOrdersAsync();
        string Create(OrderAddVM name);
        Task<string> CreateAsync(OrderAddVM filter);
    }
}
