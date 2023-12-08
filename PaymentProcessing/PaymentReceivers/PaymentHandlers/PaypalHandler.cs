using PaymentProcessing.Models;

namespace PaymentProcessing.PaymentReceivers.PaymentHandlers;

public class PaypalHandler : IReceiver<Order>
{
    public void Handle(Order order)
    {
        // Invoke the PayPal API to finalize payment

        var payment = order.SelectedPayments.FirstOrDefault(x => x.PaymentProvider == PaymentProvider.Paypal);

        if (payment == null) return;

        order.FinalizePayment(payment);
    }
}