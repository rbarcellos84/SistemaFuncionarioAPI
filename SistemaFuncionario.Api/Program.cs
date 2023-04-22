var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuração de CORS
builder.Services.AddCors(
    s => s.AddPolicy("DefaltPolicy", builder =>
    {
        //.WithOrigins() //seta os enderecos que podem chamar sua p
        builder.AllowAnyOrigin() //qualqur servico de origem pode acessar a api
               .AllowAnyMethod()  //qualquer metodo (POST,PUT,DELE,GET)
               .AllowAnyHeader(); //qualquer parametro de cabecalho (HEADER)
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//configuraão de CORS
app.UseCors("DefaltPolicy");

app.UseAuthorization();
app.MapControllers();
app.Run();
