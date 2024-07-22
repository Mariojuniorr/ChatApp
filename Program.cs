var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddControllers();
//builder.Services.AddSwaggerGen();

// Configurar Kestrel para escutar em portas específicas
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000); // Porta HTTP
    options.ListenLocalhost(5001, listenOptions =>
    {
        listenOptions.UseHttps(); // Porta HTTPS
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    /*app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste1");
        c.RoutePrefix = string.Empty;
    });*/
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllers(); // Mapa de Controllers
app.MapRazorPages();

// Configuração do hub SignalR
app.MapHub<ChatHub>("/chathub");

app.Run();