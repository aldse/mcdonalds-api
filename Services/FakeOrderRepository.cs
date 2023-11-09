using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mcdonalds_api.Services;

using mcdonalds_api.Model;
using Model;

public class FakeOrderRepository : IOrderRepository
{
    int orderId = 42;
    public Task AddItem(int orderId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task CancelOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateOrder(int storeId)
    {
        return orderId;
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new NotImplementedException();
    }
}