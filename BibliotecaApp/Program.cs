using BibliotecaApp.Services;
using BibliotecaApp.Settings;

var builder = WebApplication.CreateBuilder(args);

// MVC Controllers
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB Settings (Options Pattern)
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDB"));

// Injeção do serviço de livros
builder.Services.AddSingleton<LivrosService>();

var app = builder.Build();

// Swagger sempre habilitado para facilitar a demo
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
