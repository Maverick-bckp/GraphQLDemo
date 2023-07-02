using GraphQLDemo.API.Repositories;
using GraphQLDemo.API.Resolvers;
using GraphQLDemo.API.Schema;
using GraphQLDemo.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



/*---------- Add Resolvers/Controllers ----------*/
//builder.Services.AddGraphQLServer().AddQueryType<CourseRepository>();
builder.Services.AddGraphQLServer()
    .AddQueryType(q => q.Name("Tallysheets"))
    .AddTypeExtension<UnitdetailsTallysheetsResolver>()
    .AddTypeExtension<UnitdetailsTallysheetFilteredResolver>();

/*----------- Add Services-------------*/
builder.Services.AddScoped<IUnitdetailsTallysheets, UnitTallysheetRepository>();



builder.Services.AddInMemorySubscriptions();

var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWebSockets();

app.UseEndpoints(endpoints => endpoints.MapGraphQL());

app.MapControllers();

app.Run();
