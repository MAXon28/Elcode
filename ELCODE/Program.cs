using DapperAssistant;
using ELCODE.Repositories.Implementations;
using ELCODE.Repositories.Interfaces;
using ELCODE.Services.Implementations;
using ELCODE.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped(dbConnectionKeeper => new DbConnectionKeeper(connection));

builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientCriteriaRepository, ClientCriteriaRepository>();
builder.Services.AddScoped<IRequestCriteriaRepository, RequestCriteriaRepository>();
builder.Services.AddScoped<IImportanceRepository, ImportanceRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IPriorityService, PriorityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Elcode}/{action=Index}/{id?}");
});

app.Run();
