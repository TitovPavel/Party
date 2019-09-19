using MyParty.ViewModels;
using System;
using System.Web.Mvc;

namespace MyParty.Helpers
{
    public static class PartyHelper
    {
        public static MvcHtmlString CreateParty(this HtmlHelper html, PartyViewModel party, string actionName, string controllerName)
        {
            TagBuilder ul = new TagBuilder("a");          
            ul.SetInnerText(party.Title);
            ul.MergeAttribute("href", String.Concat("/", controllerName , "/", actionName, "/", party.Id));
            ul.MergeAttribute("data-toggle", "tooltip");
            ul.MergeAttribute("title", String.Concat("Дата: ", party.Date.ToShortDateString(), ", место: " , party.Location));
            return new MvcHtmlString(ul.ToString());
        }
    }
}