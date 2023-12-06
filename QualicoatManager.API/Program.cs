using GraphiQl;
using GraphQL;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.Types;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using QualicoatManager.API.Mutation;
using QualicoatManager.API.Query;
using QualicoatManager.API.Schema;
using QualicoatManager.API.Services;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Domain.Repositories;
using QualicoatManager.Infrastructure.Context;
using QualicoatManager.Service;
//using QualicoatManager.Service;

var builder = WebApplication.CreateBuilder(args);
   
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddTransient<BaseUser>();
builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<AuthenticationService>();

builder.Services.AddTransient<AssessmentType>();
builder.Services.AddTransient<AssessmentsGroupType>();
builder.Services.AddTransient<BaseUserType>();
builder.Services.AddTransient<FormulationItemType>();
builder.Services.AddTransient<FormulationType>();
builder.Services.AddTransient<FormulationsFolderType>();
builder.Services.AddTransient<RawMaterialType>();
builder.Services.AddTransient<UserRoleType>();
builder.Services.AddTransient<RoleEnumType>();
builder.Services.AddTransient<RawMaterialCategoryEnumType>();


builder.Services.AddTransient<AssessmentInputType>();
builder.Services.AddTransient<AssessmentsGroupInputType>();
builder.Services.AddTransient<BaseUserInputType>();
builder.Services.AddTransient<FormulationItemInputType>();
builder.Services.AddTransient<FormulationInputType>();
builder.Services.AddTransient<FormulationsFolderInputType>();
builder.Services.AddTransient<RawMaterialInputType>();
builder.Services.AddTransient<UserRoleInputType>();

builder.Services.AddTransient<AssessmentQuery>();
builder.Services.AddTransient<AssessmentsGroupQuery>();
builder.Services.AddTransient<BaseUserQuery>();
builder.Services.AddTransient<FormulationItemQuery>();
builder.Services.AddTransient<FormulationQuery>();
builder.Services.AddTransient<FormulationsFolderQuery>();
builder.Services.AddTransient<RawMaterialQuery>();
builder.Services.AddTransient<UserRoleQuery>();
builder.Services.AddTransient<RootQuery>();

builder.Services.AddTransient<AssessmentMutation>();
builder.Services.AddTransient<AssessmentsGroupMutation>();
builder.Services.AddTransient<BaseUserMutation>();
builder.Services.AddTransient<FormulationItemMutation>();
builder.Services.AddTransient<FormulationMutation>();
builder.Services.AddTransient<FormulationsFolderMutation>();
builder.Services.AddTransient<RawMaterialMutation>();
builder.Services.AddTransient<UserRoleMutation>();
builder.Services.AddTransient<RootMutation>();


builder.Services.AddTransient<ISchema, RootSchema>();


builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson());
builder.Services.AddGraphQL(b => b.AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true));

//Entity
builder.Services.AddDbContext<QualicoatManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QualicoatManagerContextConnection")),
    ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseGraphiQl("/qualicoat");
app.UseGraphQL<ISchema>();


app.UseAuthorization();
app.MapControllers();
app.Run();