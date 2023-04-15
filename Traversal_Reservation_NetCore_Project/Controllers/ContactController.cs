using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Traversal_Reservation_NetCore_Project.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactUsDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.TAdd(new ContactUs()
                {
                    MessageBody = contactDTO.MessageBody,
                    Mail = contactDTO.Mail,
                    MessageStatus = true,
                    Name = contactDTO.Name,
                    Subject = contactDTO.Subject,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index", "Default");

            }
            return View(contactDTO);
        }
    }
}
