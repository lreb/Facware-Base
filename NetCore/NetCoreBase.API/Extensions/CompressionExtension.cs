﻿using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace NetCoreBase.API.Extensions
{
    public static class CompressionExtension
    {
        private static readonly string[] Second =
        [
            "application/json",
        "application/xml",
        "text/plain",
        "image/png",
        "image/jpeg"
        ];

        public static IServiceCollection AddCompressionCustom(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(Second);
                options.Providers.Add<BrotliCompressionProvider>();
            });
            services.Configure<BrotliCompressionProviderOptions>(options => options.Level = CompressionLevel.SmallestSize);
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            return services;
        }
    }
}
