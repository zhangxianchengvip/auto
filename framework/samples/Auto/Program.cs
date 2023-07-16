using Auto.Core;
using Auto.Caching.Redis;
using Auto.Core.Options;
using Auto.DistributedLock.Redis;
using Auto.Caching.Redis;
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
            builder.Services.AddAutoRedis(builder.Configuration);
            builder.Services.AddAutoDisributedLockRedis(builder.Configuration);

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}