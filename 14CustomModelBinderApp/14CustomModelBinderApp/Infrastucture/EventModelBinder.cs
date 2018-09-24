using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using _14CustomModelBinderApp.Models;

namespace _14CustomModelBinderApp.Infrastucture
{
    public class EventModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // for exception
            if(bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            // get data
            var datePartValues = bindingContext.ValueProvider.GetValue("Date");
            var timePartValues = bindingContext.ValueProvider.GetValue("Time");
            var namePartValues = bindingContext.ValueProvider.GetValue("Name");
            var idPartValues = bindingContext.ValueProvider.GetValue("Id");

            string date = datePartValues.FirstValue;
            string time = timePartValues.FirstValue;
            string name = namePartValues.FirstValue;
            string id = idPartValues.FirstValue;

            // if id is empty => generate it
            if (string.IsNullOrEmpty(id)) id = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(name)) name = "Unknown event";

            // Парсим дату и время
            DateTime.TryParse(date, out var parsedDateValue);
            DateTime.TryParse(time, out var parsedTimeValue);
             
            // Объединяем полученные значения в один объект DateTime
            DateTime fullDateTime = new DateTime(parsedDateValue.Year,
                parsedDateValue.Month,
                parsedDateValue.Day,
                parsedTimeValue.Hour,
                parsedTimeValue.Minute,
                parsedTimeValue.Second);
            // устанавливаем результат привязки
            bindingContext.Result = ModelBindingResult.Success(new Event { Id = id, EventDate = fullDateTime, Name = name } );
            return Task.CompletedTask;

        }
    }
}
