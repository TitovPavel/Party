using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyParty.Infrastructure
{
    public class DateTimeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;

            DateTime arrivalDate = DateTime.MinValue;

            if (valueProvider.GetValue("ArrivalDate").AttemptedValue != "")
            {

                arrivalDate = (DateTime)valueProvider.GetValue("ArrivalDate").ConvertTo(typeof(DateTime));
            }

            return arrivalDate;
        }
    }
}

