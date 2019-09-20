using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyParty.Helpers
{
    public class PartyTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            //output.Attributes.SetAttribute("href", String.Concat("/", controllerName, "/", actionName, "/", party.Id));
            //output.Attributes.SetAttribute("data-toggle", "tooltip");
            //output.Attributes.SetAttribute("title", String.Concat("Дата: ", party.Date.ToShortDateString(), ", место: ", party.Location));

        }
    }
}