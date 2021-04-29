using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo.App.Extensions
{
    [HtmlTargetElement("*", Attributes = "supress-by-claim-name")]
    [HtmlTargetElement("*", Attributes = "supress-by-claim-value")]
    public class ApagarElementoByClaimTAgHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAcccessor;

        public ApagarElementoByClaimTAgHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAcccessor = httpContextAccessor;
        }

        [HtmlAttributeName("supress-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("supress-by-claim-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentException(nameof(context));

            if (output == null)
                throw new ArgumentException(nameof(context));

            var temAcesso = CustomAuthorization.ValidarClaimUsuario(_httpContextAcccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

            if (temAcesso) return;

            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("a", Attributes = "disable-by-claim-name")]
    [HtmlTargetElement("a", Attributes = "disable-by-claim-value")]
    public class DesabilitarElementoByClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAcccessor;

        public DesabilitarElementoByClaimTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAcccessor = httpContextAccessor;
        }

        [HtmlAttributeName("disable-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("disable-by-claim-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentException(nameof(context));

            if (output == null)
                throw new ArgumentException(nameof(context));

            var temAcesso = CustomAuthorization.ValidarClaimUsuario(_httpContextAcccessor.HttpContext, IdentityClaimName, IdentityClaimValue);

            if (temAcesso) return;

            output.SuppressOutput();

            output.Attributes.RemoveAll("href");
            output.Attributes.Add(new TagHelperAttribute("style", "cursor: not-allowed"));
            output.Attributes.Add(new TagHelperAttribute("style", "cursor: Você não tem permissão"));

        }
    }
}
