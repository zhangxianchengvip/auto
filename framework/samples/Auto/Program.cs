using Auto.Core;
using Auto.Caching.Redis;
using Auto.Core;
using AspectCore.DependencyInjection;
using Auto.Core.Options;
using Auto.Options;
using Microsoft.Extensions.Options;

namespace Auto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseServiceProviderFactory(new AutoServiceProviderFactory());
            builder.Services.AddControllers().AddControllersAsServices();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoCore(builder.Configuration);
            builder.Services.AddAutoRedis();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var redis = app.Configuration.GetOptions<Redis>();

            var rediss = app.Services.GetOptions<Redis>( );

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}