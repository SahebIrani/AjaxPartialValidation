using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
                //options.AllowValidatingTopLevelNodes = false;

                options.ModelBindingMessageProvider
                    .SetMissingBindRequiredValueAccessor((_) => "{0} Khaliye .. !!!!");

                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                    (_) => "field {0} ejbariye .. !!!!");
            })
            .AddViewOptions(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.HtmlHelperOptions.ClientValidationEnabled = true;
                }
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            ;

            services.Configure<HtmlHelperOptions>(o => o.ClientValidationEnabled = false);

            //services.Configure<MvcOptions>(options =>
            //{
            //    options.MaxModelValidationErrors = 50;

            //    options.ModelBindingMessageProvider
            //        .SetMissingBindRequiredValueAccessor((_) => "{0} Khaliye ..");
            //});

            //services.Configure<MvcViewOptions>(options =>
            //{
            //    if (environment.IsDevelopment())
            //    {
            //        options.HtmlHelperOptions.ClientValidationEnabled = false;
            //    }
            //});

            services.AddSingleton<IValidationAttributeAdapterProvider,
                                    CustomValidationAttributeAdapterProvider>();

            // There is only one `IObjectModelValidator` object,
            // so AddSingleton replaces the default one.
            //You might still see model state errors that originate from model binding.
            services.AddSingleton<IObjectModelValidator>(new NullObjectModelValidator());
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
