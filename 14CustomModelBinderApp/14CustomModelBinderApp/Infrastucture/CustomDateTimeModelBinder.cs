using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _14CustomModelBinderApp.Infrastucture
{
    public class CustomDateTimeModelBinder : IModelBinder
    {
        private readonly IModelBinder fallbackBinder;

        public CustomDateTimeModelBinder(IModelBinder fallbackBinder)
        {
            this.fallbackBinder = fallbackBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // if error return exception
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // get values from request
            var datePartValues = bindingContext.ValueProvider.GetValue("Date");
            var timePartValues = bindingContext.ValueProvider.GetValue("Time");

            // if values not found - use default binder
            if (datePartValues == ValueProviderResult.None || timePartValues == ValueProviderResult.None)
                return fallbackBinder.BindModelAsync(bindingContext);

            // get values
            string date = datePartValues.FirstValue;
            string time = timePartValues.FirstValue;

            // parsing date & time
            DateTime.TryParse(date, out var parsedDateValue);
            DateTime.TryParse(time, out var parsedTimeValue);

            // join values to DatiTime
            var result = new DateTime(parsedDateValue.Year,
                            parsedDateValue.Month, 
                            parsedDateValue.Day, 
                            parsedTimeValue.Hour,
                            parsedTimeValue.Minute, 
                            parsedTimeValue.Second);

            // set binding result
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
