using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ProiectOBS.Data;
using ProiectOBS.Repositories;
using ProiectOBS.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProiectOBSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<AddressRepository>();
builder.Services.AddTransient<AdminRepository>();
builder.Services.AddTransient<CardRepository>();
builder.Services.AddTransient<ClientRepository>();
builder.Services.AddTransient<DepositRepository>();
builder.Services.AddTransient<TransactionsRepository>();
builder.Services.AddTransient<TransferRepository>();
builder.Services.AddTransient<WithdrawalRepository>();


builder.Services.AddTransient<TransactionsService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
