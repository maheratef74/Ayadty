using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace presentationLayer.Middlewares;

public class RequestCultureMiddleware
{
   /* private readonly RequestDelegate _next;

    public RequestCultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // to set first Lang that apear for user as browser lang
        var currentLang = context.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
        var browserLang = context.Request.Headers["Accept-Language"].ToString()[..2];
       
        if (string.IsNullOrEmpty(currentLang))
        {
            var culture = "ar-EG";
            if (browserLang == "en") culture = "en_US";
                
            // this to set lang in the navbar to defult browser lang
            var requestCulture = new RequestCulture(culture, culture);
            context.Features.Set<IRequestCultureFeature>(new RequestCultureFeature(requestCulture , null));
                
                
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            CultureInfo.CurrentUICulture = new CultureInfo(culture);
        }
        await _next(context);
    }*/
}