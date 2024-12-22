using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace ToDo.Api.Configurations;

internal static class LocalizationConfig
{
    internal static IServiceCollection AddLocalizationConfig(this IServiceCollection services)
    {
        services.AddLocalization();

        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("ar")
        };

            options.DefaultRequestCulture = new RequestCulture("en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;

            options.RequestCultureProviders = new List<IRequestCultureProvider>
        {
            new QueryStringRequestCultureProvider(),
            new CookieRequestCultureProvider(),
            new AcceptLanguageHeaderRequestCultureProvider()
        };
        });


        return services;
    }
}
