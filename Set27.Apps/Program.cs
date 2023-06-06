using AntDesign.ProLayout;
using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Set27.Infra;

var builder = WebApplication.CreateBuilder(args).Inject();

builder.Services.AddDatabaseAccessor(options =>
{
    var connectionStr = $@"Data Source=./Db/set.db";
    options.AddDbPool<MyDbContext>(DbProvider.Sqlite, connectionMetadata: connectionStr);
}, "Set27.Infra");
// Add services to the container.
builder.Services.AddAntDesign();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.UseRouting();
app.MapBlazorHub();

app.MapFallbackToPage("/_Host");
app.MapControllers();
app.UseInject();
app.Run();
