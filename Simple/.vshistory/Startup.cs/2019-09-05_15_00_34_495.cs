using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

using Simple.Attributes;

namespace Simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<MvcOptions>(options =>
            {
                options.MaxModelValidationErrors = 50;

                options.ModelBindingMessageProvider
                    .SetMissingBindRequiredValueAccessor((_) => "{0} Khaliye ..");
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
