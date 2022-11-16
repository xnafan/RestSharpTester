using CustomerDataAccessLayer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Register our DAO class for getting customer objects
builder.Services.AddSingleton<ICustomerDao, CustomerDao>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
