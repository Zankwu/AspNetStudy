using HttpClientEg.Options;
using HttpClientEg.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<FinnhubService>();
builder.Services.Configure<FinnHubOptions>(builder.Configuration.GetSection("FinnApi"));
var app = builder.Build();
app.MapControllers();
app.UseRouting();


app.Run();
