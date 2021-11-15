using ECOM_PROJECT.Payment.WebAPI.Data.Abstract;
using ECOM_PROJECT.Payment.WebAPI.Models;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using ECOM_PROJECT.Shared.Utilities.Result.ComplexTypes;
using ECOM_PROJECT.Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Payment.WebAPI.Data.Concrete
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task<IResult> ReceivePayment(CheckoutPayment checkoutPayment)
        {
            return new Result(ResultStatus.Success, "SUCCESS");
        }
    }
}
