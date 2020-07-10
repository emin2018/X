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
    public class PersonProductRelationsController : ControllerBase
    {
        private readonly IPersonProductRelationService _personProductRelationService;
        private readonly IMapper _mapper;
        public PersonProductRelationsController(IPersonProductRelationService personProductRelationService, IMapper mapper)
        {
            _personProductRelationService = personProductRelationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ppRelations = await _personProductRelationService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonProductRelationDto>>(ppRelations));
        }

        [ServiceFilter(typeof(NotFoundFilter<PersonProductRelation>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ppRelation = await _personProductRelationService.GetByIdAsync(id);
            return Ok(_mapper.Map<PersonProductRelationDto>(ppRelation));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreateOrUpdatePersonProductRelationDto cPPRelationDto)
        {
            var newPPRelation= await _personProductRelationService.AddAsync(_mapper.Map<PersonProductRelation>(cPPRelationDto));
            return Created("", _mapper.Map<PersonProductRelationDto>(newPPRelation));
        }

        [HttpPut]
        public IActionResult Update(CreateOrUpdatePersonProductRelationDto cPPRelationDto)
        {
            var ppRelation = _personProductRelationService.Update(_mapper.Map<PersonProductRelation>(cPPRelationDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<PersonProductRelation>))]
        public IActionResult Delete(int id)
        {
            var ppRelation = _personProductRelationService.GetByIdAsync(id).Result;
            _personProductRelationService.Delete(ppRelation);
            return NoContent();
        }
        
        [HttpGet("WithRelations/{id}")]
        [ServiceFilter(typeof(NotFoundFilter<PersonProductRelation>))]
        public async Task<IActionResult> GetWithPersonAndProductById(int id)
        {
            var ppRelation = await _personProductRelationService.GetWithPersonProductByIdAsync(id);
            return Ok(_mapper.Map<PersonProductRelationDto>(ppRelation));
        }
    }
}
