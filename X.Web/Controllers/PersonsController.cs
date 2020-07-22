using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X.Core.Entities;
using X.Core.Services;
using X.Web.DTOs;
using X.Web.Filters;

namespace X.Web.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public PersonsController(IPersonService personService,IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var persons = await _personService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonDto personDto)
        {
            await _personService.AddAsync(_mapper.Map<Person>(personDto));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return View(_mapper.Map<PersonDto>(person));
        }

        [HttpPost]
        public IActionResult Update(PersonDto personDto)
        {
            _personService.Update(_mapper.Map<Person>(personDto));
            return RedirectToAction("Index");
        }
        [ServiceFilter(typeof(NotFoundFilter<Person>))]
        public IActionResult Delete(int id)
        {
            var person = _personService.GetByIdAsync(id).Result;
            _personService.Delete(person);
            return RedirectToAction("Index");
        }
    }
}
