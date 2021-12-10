using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MoviePage.Utility.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Extensions
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PagingLinkTagHelper: TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public bool PageCssEnabled { get; set; }
        public string PageCss { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder builder = new TagBuilder("div");
            for(var i = 0; i< 5; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = "https://google.com";
                if (PageCssEnabled)
                {
                    tag.AddCssClass(PageCss);
                }
                tag.InnerHtml.Append(i.ToString());
                builder.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(builder);
        }
    }
}
