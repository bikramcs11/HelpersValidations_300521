using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersValidations.Helpers
{
    public static class SubmitButtonExtension
    {
        public static IHtmlContent SubmitButton(this IHtmlHelper htmlHelper, string name, string value)
        {
            string button = $"<input type='submit' value='{value}' name='{name}'>";
            return new HtmlString(button);
        }
    }
}
