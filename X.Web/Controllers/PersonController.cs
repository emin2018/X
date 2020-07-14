using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.Core.Services;

namespace X.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public PersonController(IPersonService personService,IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
