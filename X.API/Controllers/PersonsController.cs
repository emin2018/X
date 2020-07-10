using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.API.DTOs;
using X.API.Filters;
using X.Core.Entities;
using X.Core.Services;

namespace X.API.Controllers
{
    [ValidationFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonsController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(persons));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Person>))]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(_mapper.Map<PersonDto>(person));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
           var newPerson = await _personService.AddAsync(_mapper.Map<Person>(personDto));
           return Created("", _mapper.Map<PersonDto>(newPerson));
        }

        [HttpPut]
        public IActionResult Update(PersonDto personDto)
        {
            var person = _personService.Update(_mapper.Map<Person>(personDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Person>))]
        public IActionResult Delete(int id)
        {
            var person = _personService.GetByIdAsync(id).Result;
            _personService.Delete(person);
            return NoContent();
        }

    }
}
