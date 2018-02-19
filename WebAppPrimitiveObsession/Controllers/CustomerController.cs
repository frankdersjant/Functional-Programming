using Domain;
using Domain.Infrastructure;
using Services;
using System.Collections.Generic;
using System.Web.Mvc;
using WebAppPrimitiveObsession.ViewModels;

namespace WebAppPrimitiveObsession.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerservice;

        public CustomerController(ICustomerService customerService)
        {
            _customerservice = customerService;
        }

        public ActionResult Index()
        {
            CustomerViewModel vm = new CustomerViewModel {Id = 1, EMail = "blaat", Name = "blaat"};
            CustomerViewModel vm2 = new CustomerViewModel { Id = 2, EMail = "blaater", Name = "blaater" };
            List<CustomerViewModel> list = new List<CustomerViewModel>();
            list.Add(vm);
            list.Add(vm2);

            return View(list);
        }

        [HttpGet]
        public ActionResult CreateCustomer()
        {
            CustomerViewModel vm = new CustomerViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerViewModel customervm)
        {
            Result<CustomerNameValue> customerNameResult =   CustomerNameValue.Create(customervm.Name);
            Result<EMailValue> EMailResult = EMailValue.Create(customervm.EMail);

            if (customerNameResult.isFailure)
                ModelState.AddModelError("CustomerName", customerNameResult.Error);
            if (EMailResult.isFailure)
                ModelState.AddModelError("EMailIncorrect", EMailResult.Error);

            if (!ModelState.IsValid)
                return View(customervm);

            var Customer = new Customer(customerNameResult.value, EMailResult.value);
            //save to db etc

            return RedirectToAction("Index");
        }
    }
}