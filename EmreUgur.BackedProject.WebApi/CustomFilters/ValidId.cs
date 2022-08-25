using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmreUgur.BackedProject.WebApi.CustomFilters
{
    public class ValidId<T> : IActionFilter where T : class, ITable, new()
    {
        private readonly IGenericService<T> _genericService;

        public ValidId(IGenericService<T> genericService)
        {
            _genericService = genericService;

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(x => x.Key == "id").FirstOrDefault();

            var id = int.Parse(dictionary.Value.ToString());

            var entity = _genericService.FindByIdAsync(id).Result;

            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"Object with id {id} not found");
            }
        }
    }
}
