﻿using Microsoft.AspNetCore.Http.Features;
using Microsoft.Net.Http.Headers;

namespace KParfume_BackEnd.Startup
{
    public static class CorsConfiguration
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services, string corsPolicy)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsPolicy,
                    builder =>
                    {
                        builder.WithOrigins(ParseCorsOrigins())
                            .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "access_token")
                            .WithMethods("GET", "PUT", "POST", "PATCH", "DELETE", "OPTIONS");
                    });

            });
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            return services;
        }

        private static string[] ParseCorsOrigins()
        {
            var corsOrigins = new[] { "http://localhost:3000" };
            var corsOriginsPath = Environment.GetEnvironmentVariable("KPARFUME_CORS_ORIGINS");
            if (File.Exists(corsOriginsPath))
            {
                corsOrigins = File.ReadAllLines(corsOriginsPath);
            }

            return corsOrigins;
        }
    }

}

