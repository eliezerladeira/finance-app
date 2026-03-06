using FinanceApp.Infrastructure.Data;
using FinanceApp.Infrastructure.Repositories;
using FinanceApp.Domain.Repositories;
using FinanceApp.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton(new DbConnectionFactory(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ICreditCardRepository, CreditCardRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<CreditCardService>();
builder.Services.AddScoped<PurchaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();