using MyParty.ViewModels;
using System;
using System.Web.Mvc;

namespace MyParty.Helpers
{
    public static class PartyHtmlHelper
    {
        public static MvcHtmlString CreateParty(this HtmlHelper html, PartyViewModel party, string actionName, string controllerName)
        {
            TagBuilder a = new TagBuilder("a");
            a.SetInnerText(party.Title);
            a.MergeAttribute("href", String.Concat("/", controllerName , "/", actionName, "/", party.Id));
            a.MergeAttribute("data-toggle", "tooltip");
            a.MergeAttribute("title", String.Concat("Дата: ", party.Date.ToShortDateString(), ", место: " , party.Location));
            return new MvcHtmlString(a.ToString());
        }
    }
}