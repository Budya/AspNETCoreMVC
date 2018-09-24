using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using _14CustomModelBinderApp.Models;

namespace _14CustomModelBinderApp.Infrastucture
{
    public class EventModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder binder = new EventModelBinder();
 
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(Event) ? binder : null;
        }
    }
}
