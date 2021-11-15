using ECOM_PROJECT.Payment.WebAPI.Data.Abstract;
using ECOM_PROJECT.Payment.WebAPI.Models;
using ECOM_PROJECT.Shared.RabbitMQ;
using ECOM_PROJECT.Shared.Utilities.Result.Concrete;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Payment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public PaymentController(IPaymentRepository paymentRepository, ISendEndpointProvider sendEndpointProvider)
        {
            _paymentRepository = paymentRepository;
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Receive(PaymentDto payment)
        {
            var sendEnpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));
            var createorderMessageCommand = new CreateOrderMessageCommand();
            createorderMessageCommand.BuyerId = payment.Order.BuyerId;
            createorderMessageCommand.Province = payment.Order.Address.Province;
            createorderMessageCommand.District = payment.Order.Address.District;
            createorderMessageCommand.Street = payment.Order.Address.Street;
            createorderMessageCommand.Line = payment.Order.Address.Line;
            createorderMessageCommand.ZipCode = payment.Order.Address.ZipCode;
            payment.Order.OrderItems.ForEach(x =>
            {
                createorderMessageCommand.OrderItems.Add(new OrderItem
                {
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName
                });;
            });

           await sendEnpoint.Send<CreateOrderMessageCommand>(createorderMessageCommand);

            return Ok(createorderMessageCommand);
        }
    }
}
