using FSTeam.Config;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configurationManager = builder.Configuration; 
var services = new ServiceRegistration();

services.OnLoad(builder.Services, configurationManager);

var app  = builder.Build();

if (app.Environment.IsDevelopment())

{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseForwardedHeaders();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
