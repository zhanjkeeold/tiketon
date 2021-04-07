using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Tiketon.Services.Payment.Application.Abstractions.Services;
using Tiketon.Services.Payment.Domain;

namespace Tiketon.Services.Payment.Infrastucture.Services
{
    public class ExternalGatewayPaymentService : IExternalGatewayPaymentService
    {
        private readonly HttpClient _client;


        public ExternalGatewayPaymentService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> PerformPayment(PaymentInfo paymentInfo)
        {
            var dataAsString = JsonSerializer.Serialize(paymentInfo);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response =
                await _client.PostAsync("/api/paymentapprover", content);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<bool>(responseString,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }
    }
}