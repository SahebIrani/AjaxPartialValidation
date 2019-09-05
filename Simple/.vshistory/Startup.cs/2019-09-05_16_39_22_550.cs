using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Simple.Attributes;

namespace Simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment environment)
        {
            services.AddControllersWithViews(options =>
            {
                options.MaxModelValidationErrors = 50;

                options.ModelBindingMessageProvider
                    .SetMissingBindRequiredValueAccessor((_) => "{0} Khaliye ..");
            })
            .AddViewOptions(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.HtmlHelperOptions.ClientValidationEnabled = false;
                }
            })
            ;

            services.Configure<MvcOptions>(options =>
            {
                options.MaxModelValidationErrors = 50;

                options.ModelBindingMessageProvider
                    .SetMissingBindRequiredValueAccessor((_) => "{0} Khaliye ..");
            });

            services.Configure<MvcViewOptions>(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.HtmlHelperOptions.ClientValidationEnabled = false;
                }
            });

            services.AddSingleton<IValidationAttributeAdapterProvider,
                                    CustomValidationAttributeAdapterProvider>();


        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
