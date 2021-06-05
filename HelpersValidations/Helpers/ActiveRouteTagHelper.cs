using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersValidations.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(Attributes = "asp-active-route")]
    public class ActiveRouteTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string controller = ViewContext.RouteData.Values["Controller"].ToString();
            string action = ViewContext.RouteData.Values["Action"].ToString();

            string tagController = context.AllAttributes.FirstOrDefault(m => m.Name == "asp-controller").Value.ToString();
            string tagAction = context.AllAttributes.FirstOrDefault(m => m.Name == "asp-action").Value.ToString();
            if (controller == tagController && action == tagAction)
            {
                string activeClass = context.AllAttributes.FirstOrDefault(m => m.Name == "asp-active-route").Value.ToString();
                string cssClasses = context.AllAttributes.FirstOrDefault(m => m.Name == "class").Value.ToString();

                output.Attributes.SetAttribute("class", cssClasses + " " + activeClass);
            }
        }
    }
}
