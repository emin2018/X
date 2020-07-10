using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using X.API.DTOs;
using X.Core.Services;

namespace X.API.Filters
{
    public class NotFoundFilter<TEntity> : IAsyncActionFilter where TEntity:class
    {
        private readonly IService<TEntity> _service;

        public NotFoundFilter(IService<TEntity> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)

        {
            var id = (int) context.ActionArguments.Values.FirstOrDefault();
            var entry = await _service.GetByIdAsync(id);
            if (entry != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 400;
                errorDto.Errors.Add("Record Not Found");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
