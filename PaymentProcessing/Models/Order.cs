﻿namespace PaymentProcessing.Models;

public class Order
{
    private readonly Dictionary<LineItem, int> _lineItems = [];
    public IReadOnlyDictionary<LineItem, int> LineItems => _lineItems;

    private readonly List<Payment> _selectedPayments = [];
    public IReadOnlyList<Payment> SelectedPayments => _selectedPayments.AsReadOnly();

    private readonly List<Payment> _finalizedPayments = [];
    public IReadOnlyList<Payment> FinalizedPayments => _finalizedPayments.AsReadOnly();

    public decimal AmountDue => _lineItems.Sum(item => item.Key.Price * item.Value) - FinalizedPayments.Sum(payment => payment.Amount);

    public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;

    public void AddLineItem(LineItem lineItem, int count)
    {
        _lineItems.Add(lineItem, count);
    }

    public void AddPayment(Payment payment)
    {
        _selectedPayments.Add(payment);
    }

    public void FinalizePayment(Payment payment)
    {
        _finalizedPayments.Add(payment);
    }
}

public enum ShippingStatus
{
    WaitingForPayment,
    ReadyForShipment,
    Shipped
}