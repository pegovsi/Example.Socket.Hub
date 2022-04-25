namespace Example.Socket.Hub.Bootstrapper.Extensions;

public static class CorsExtension
{
    private const string CorsPolicy = "CorsPolicy";

    internal static IServiceCollection AddCorsConfig(this IServiceCollection services, IConfiguration config)
    {
        var cors = config
            .GetSection("Cors")
            .Get<List<string>>()
            .Where(x => x is not null)
            .ToArray();

        services.AddCors(option => option.AddPolicy(CorsPolicy, builder =>
        {
            builder.WithOrigins(cors)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }));

        return services;
    }
}