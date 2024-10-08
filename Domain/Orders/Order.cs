﻿namespace IWantApp.Domain.Orders;

public class Order : Entity
{
    public string ClientId { get; private set; }
    public List<Product> Products { get; private set; }
    public decimal Total { get; private set; }
    public string DeliveryAddress { get; private set; }

    private Order() { }

    public Order(string clientId, string clientName, List<Product> products, string deliveryAddress)
    {
        ClientId = clientId;
        Products = products;
        DeliveryAddress = deliveryAddress;

        EditedBy = clientName;
        CreatedBy = clientName;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;

        Total = 0;
        foreach (var item in products)
        {
            Total += item.Price;
        }

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Order>()
            .IsNotNull(ClientId, "Client")
            .IsTrue(Products != null && Products.Count != 0, "Products")
            .IsNotNullOrEmpty(DeliveryAddress, "DeliveryAddress");

        AddNotifications(contract);
    }

}
