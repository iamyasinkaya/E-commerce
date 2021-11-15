using ECOM_PROJECT.Payment.WebAPI.Models;
using ECOM_PROJECT.Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Payment.WebAPI.Data.Abstract
{
    public interface IPaymentRepository
    {
        Task<IResult> ReceivePayment(CheckoutPayment checkoutPayment);
    }
}
