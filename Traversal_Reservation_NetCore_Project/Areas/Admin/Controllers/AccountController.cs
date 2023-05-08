using BusinessLayer.Abstract.AbstractUnitOfWork;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Traversal_Reservation_NetCore_Project.Areas.Admin.Models;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area(nameof(Admin))]
    [Route("Admin/[controller]/[action]/{id?}")]

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel accountViewModel)
        {
            var senderValues =  _accountService.TGetById(accountViewModel.SenderId);
            var receiverValues = _accountService.TGetById(accountViewModel.ReceiverId);

            senderValues.Balance -= accountViewModel.Amount;
            receiverValues.Balance += accountViewModel.Amount;

            List<Account> modifiedAccount = new List<Account>()
            {
                senderValues,
                receiverValues
            };
            _accountService.TMultiUpdate(modifiedAccount);
            return View();
        }
    }
}
