using Azure.AI.OpenAI.Chat;
using iasalesmk.application.Services;
using iasalesmk.infrastructure.Repositories;
using iasalesmk.infrastructure.Services;
using OpenAI.Chat;

namespace iasalesmk.api.Extensions;

public static class AplicationServiceExtensions
{


    public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.WithOrigins("http://localhost:5048/api/Chat")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });

    public static void AddAplicacionServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IOpenAIService, OpenAIService>();
        services.AddScoped<IChatIAService, ChatIAService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();


        // services.AddSingleton<ChatClient>(sp =>
        // {
        //     var configuration = sp.GetRequiredService<IConfiguration>();
        //     var apiKey = configuration["OpenAI:ApiKey"];
        //     var endpoint = configuration["OpenAI:Endpoint"];
        //     return new ChatClient(apiKey, endpoint);

        // });
    }

}
