using FinanceApp.Infrastructure.Data;
using FinanceApp.Infrastructure.DependencyInjection;
using FinanceApp.Infrastructure.Repositories;
using FinanceApp.Domain.Repositories;
using FinanceApp.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Infraestrutura
builder.Services.AddInfrastructure();

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
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IPurchaseGroupRepository, PurchaseGroupRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<CreditCardService>();
builder.Services.AddScoped<PurchaseService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<SupplierService>();

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

/*
 * Sempre que você criar:

nova entidade ?
novo repository ?

Você precisa:

Interface
Implementação
Injeção no Service

?? Esse é o padrão de arquitetura limpa
*/