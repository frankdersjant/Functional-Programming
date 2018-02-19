using Data.Repo;
using Domain;
using Domain.Infrastructure;
using System.Web.Mvc;

namespace BillionDollarMistake.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerDataRepo<Customer> _database;

        public CustomerController(ICustomerDataRepo<Customer> database)
        {
            _database = database;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Option<Customer> customer = _database.GetById(id);

            if (customer.HasNoValue)
                return HttpNotFound(); 

            return View(customer.Value);
        }
    }
}