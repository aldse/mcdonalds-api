using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mcdonalds_api.Services;

using Model;

public class OrderRepository : IOrderRepository
{
    private readonly McDataBaseContext ctx;
    public OrderRepository(McDataBaseContext ctx)
        => this.ctx = ctx;

    public async Task<int> CreateOrder(int storeId)
    {
        var selectedStore =
            from store in ctx.Stores
            where store.Id == storeId
            select store;
        if (!selectedStore.Any())
            throw new Exception("Store don't exist.");

        var clientOrder = new ClientOrder();
        clientOrder.StoreId = storeId;
        clientOrder.OrderCode = "abcd1234";

        ctx.Add(clientOrder);
        await ctx.SaveChangesAsync();

        return clientOrder.Id;
    }

    public async Task CancelOrder(int orderId)
    {
        var currentOrder = await getOrder(orderId);
        if (currentOrder is null)
            throw new Exception("The order do not exist.");

        ctx.Remove(currentOrder);
        await ctx.SaveChangesAsync();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task AddItem(int orderId, int productId)
    {
        var order = await getOrder(orderId);
        if (order is null)
            throw new Exception("Order do not exist.");

        var products =
            from product in ctx.Products
            where product.Id == productId
            select product;
        var selectedProduct = await products
            .FirstOrDefaultAsync();
        if (selectedProduct is null)
            throw new Exception("Product do not exist.");

        var item = new ClientOrderItem();
        item.ClientOrderId = orderId;
        item.ProductId = productId;

        ctx.Add(item);
        await ctx.SaveChangesAsync();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task DeliveryOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    private async Task<ClientOrder> getOrder(int orderId)
    {
        var orders =
            from order in ctx.ClientOrders
            where order.Id == orderId
            select order;

        return await orders.FirstOrDefaultAsync();
    }
}