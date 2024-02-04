using Escola.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });
        builder.Services.AddDbContext<EscolaDataContext>();

        var app = builder.Build();
        app.MapControllers();

        app.Run();
    }
}