using ECOM_PROJECT.Web.Mvc.Models.Payment;
using ECOM_PROJECT.Web.Mvc.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Services.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput)
        {
            var response = await _httpClient.PostAsJsonAsync("payment", paymentInfoInput);

            return response.IsSuccessStatusCode;
        }
    }
}
