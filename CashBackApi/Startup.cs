using CashBackApi.Extensions;
using CashBackApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using ZNetCS.AspNetCore.Compression;
using ZNetCS.AspNetCore.Compression.Compressors;

namespace CashBackApi
{
    public sealed class Startup
    {
        public IConfiguration conf { get; }
        public Startup(IConfiguration configuration) => conf = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddCompression(options => { options.Compressors = new List<ICompressor> { new GZipCompressor(CompressionLevel.Fastest), new DeflateCompressor(CompressionLevel.Fastest), new BrotliCompressor(CompressionLevel.Fastest) }; });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                        });
            });

            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddMemoryCache();
            services.AddMyDatabaseService(conf);
            services.AddMyAuthentication(conf);
            services.AddMySwagger();
            services.AddHttpContextAccessor();
            services.AddCashBackServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseCompression();
            app.UseDeveloperExceptionPage();

            app.UseRequestLocalization();

            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            var FileStorePath = AppDomain.CurrentDomain.BaseDirectory + $"wwwroot{Path.DirectorySeparatorChar}store";
            if (!Directory.Exists(FileStorePath)) Directory.CreateDirectory(FileStorePath);
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx => { ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age=604800"); },
                FileProvider = new PhysicalFileProvider(FileStorePath),
                RequestPath = "/store"
            });

            app.UseRouting();

            app.UseCors("AllowAllHeaders");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSerilogRequestLogging();
            app.UseMySwagger();

            app.UpdateMigrateDatabase();
        }
    }
}
