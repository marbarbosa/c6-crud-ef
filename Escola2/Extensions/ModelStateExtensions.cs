using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Escola.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = new List<string>();
            foreach (var item in modelState.Values)
                errors.AddRange(item.Errors.Select(errors => errors.ErrorMessage));

            return errors;
        }
    }
}
