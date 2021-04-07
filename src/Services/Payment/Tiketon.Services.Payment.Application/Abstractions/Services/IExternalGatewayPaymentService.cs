using System.Threading.Tasks;
using Tiketon.Services.Payment.Domain;

namespace Tiketon.Services.Payment.Application.Abstractions.Services
{
    public interface IExternalGatewayPaymentService
    {
        Task<bool> PerformPayment(PaymentInfo paymentInfo);
    }
}