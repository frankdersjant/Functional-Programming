using CustomerManagement.API.DTO;
using Domain;
using Domain.Infrastructure;
using System.Net.Http;
using System.Web.Http;

namespace CustomerManagement.API.Controllers
{
    public class CustomerController : BaseController
    {

        [HttpPost]
        public HttpResponseMessage Create(CustomerModelDTO customermodel)
        {
            Result<CustomerNameValue> validatecustomermodelname = CustomerNameValue.Create(customermodel.Name);
            return Ok();
        }
    }
}
