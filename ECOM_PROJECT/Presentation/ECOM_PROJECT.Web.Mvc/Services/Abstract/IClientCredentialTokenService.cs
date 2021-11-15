using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOM_PROJECT.Web.Mvc.Services.Abstract
{
    public interface IClientCredentialTokenService
    {
        Task<String> GetToken();
    }
}
