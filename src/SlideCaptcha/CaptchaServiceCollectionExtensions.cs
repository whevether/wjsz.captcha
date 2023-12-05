using SlideCaptcha.Core;
using SlideCaptcha.Core.Generator;
using SlideCaptcha.Core.Resources;
using SlideCaptcha.Core.Resources.Handler;
using SlideCaptcha.Core.Resources.Provider;
using SlideCaptcha.Core.Storage;
using SlideCaptcha.Core.Validator;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CaptchaServiceCollectionExtensions
    {
        public static CaptchaBuilder AddSlideCaptcha(this IServiceCollection services, IConfiguration configuration, Action<CaptchaOptions> optionsAction = default)
        {
            services.Configure<CaptchaOptions>(configuration?.GetSection("SlideCaptcha"));
            if (optionsAction != null) services.PostConfigure(optionsAction);

            var builder = new CaptchaBuilder(services);
            services.AddSingleton<IResourceProvider, OptionsResourceProvider>();
            services.AddSingleton<IResourceProvider, EmbeddedResourceProvider>();
            services.AddSingleton<IResourceHandlerManager, CachedResourceHandlerManager>();
            services.AddSingleton<IResourceManager, DefaultResourceManager>();
            services.AddSingleton<IResourceHandler, FileResourceHandler>();
            services.AddSingleton<IResourceHandler, EmbeddedResourceHandler>();
            services.AddScoped<ICaptchaImageGenerator, DefaultCaptchaImageGenerator>();
            services.AddScoped<ICaptcha, DefaultCaptcha>();
            services.AddScoped<IStorage, DefaultStorage>();
            services.AddScoped<IValidator, SimpleValidator>();
            return builder;
        }
    }
}
