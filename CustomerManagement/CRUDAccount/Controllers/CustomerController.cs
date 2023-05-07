using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDAccount.Models;


namespace CRUDAccount.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(customerService.GetCustomers());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            CustomerViewModel data = new CustomerViewModel();
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI TÀI KHOẢN" : "CẬP NHẬT TÀI KHOẢN";

            if (id != 0)
            {
                Customer res = customerService.GetCustomer(id);
                data = mapper.Map<CustomerViewModel>(res);
                if (data == null)
                {
                    return NotFound();
                }
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, CustomerViewModel data)
        {
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI KHÁCH HÀNG" : "CẬP NHẬT KHÁCH HÀNG";

            if (ModelState.IsValid)
            {
                try
                {
                    Customer res = mapper.Map<Customer>(data);
                    if (id != 0)
                    {
                        customerService.UpdateCustomer(res);
                    }
                    else
                    {
                        customerService.InsertCustomer(res);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "Customer");
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Customer res = customerService.GetCustomer(id);
            customerService.DeleteCustomer(res);

            return RedirectToAction("Index", "Customer");
        }
    }
}



