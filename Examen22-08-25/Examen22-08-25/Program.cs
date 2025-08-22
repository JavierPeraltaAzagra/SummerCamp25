using Microsoft.EntityFrameworkCore;
using Examen22_08_25.Contexto;
using Examen22_08_25.Entidades;
using Bogus;
using Examen22_08_25.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Add DbContext for EF Core
builder.Services.AddDbContext<Examen22_08_25.Contexto.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de la implementación de IGestionGruposMusica
builder.Services.AddScoped<IGestionGruposMusica, GestionGruposMusicaBD>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// Seeding de datos con Bogus al iniciar la app
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.GruposMusica.Any())
    {
        var generos = new[] { "Rock", "Pop", "Jazz", "Metal", "Reggae", "Hip-Hop", "Country", "Electrónica", "Ska", "Folk", "Blues", "Punk", "Clásica", "Indie", "Cumbia", "Salsa", "Flamenco", "R&B", "Soul", "Disco" };
        var nombresBandas = new[]
        {
            "The Beatles", "Queen", "Pink Floyd", "Led Zeppelin", "The Rolling Stones", "U2", "Nirvana", "The Who", "Radiohead", "Metallica",
            "Coldplay", "The Doors", "AC/DC", "The Police", "Pearl Jam", "Red Hot Chili Peppers", "Oasis", "The Cure", "Genesis", "Aerosmith",
            "Foo Fighters", "Green Day", "Muse", "Arctic Monkeys", "The Killers", "Blur", "Bon Jovi", "Deep Purple", "Iron Maiden", "R.E.M.",
            "The Clash", "Guns N' Roses", "The Smiths", "Simple Plan", "Imagine Dragons", "Linkin Park", "Paramore", "The Strokes", "Journey", "Yes",
            "Fleetwood Mac", "The Kinks", "The Beach Boys", "The Eagles", "Kiss", "Def Leppard", "Supertramp", "The Offspring", "Sum 41", "No Doubt"
        };
        var faker = new Faker<GrupoMusica>("es")
            .RuleFor(g => g.Nombre, (f, g) => {
                // 25% probabilidad de nombre ficticio, 75% de la lista
                if (f.Random.Bool(0.25f))
                {
                    var nombre = f.Commerce.Color() + " " + f.Hacker.Noun();
                    if (nombre.Length < 5)
                        nombre = nombre.PadRight(5, 'X');
                    return nombre.Length > 50 ? nombre.Substring(0, 50) : nombre;
                }
                else
                {
                    var nombre = f.PickRandom(nombresBandas);
                    return nombre.Length > 50 ? nombre.Substring(0, 50) : nombre;
                }
            })
            .RuleFor(g => g.Genero, f => f.PickRandom(generos))
            .RuleFor(g => g.NumeroIntegrantes, f => f.Random.Int(1, 20))
            .RuleFor(g => g.FechaFormacion, f => f.Date.Past(50, DateTime.Now.AddYears(-1)))
            .RuleFor(g => g.Activo, f => f.Random.Bool(0.7f));
        var grupos = new List<GrupoMusica>();
        for (int i = 0; i < 200; i++)
        {
            grupos.Add(faker.Generate());
        }
        db.GruposMusica.AddRange(grupos);
        db.SaveChanges();
    }
}

app.Run();
