using Escola.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddDbContext<EscolaDataContext>();

        var app = builder.Build();
        app.MapControllers();

        app.Run();
    }
}