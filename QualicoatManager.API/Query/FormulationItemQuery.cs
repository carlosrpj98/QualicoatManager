using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Query
{
    public class FormulationItemQuery : ObjectGraphType
    {
        public FormulationItemQuery(IGenericRepository<FormulationItem> repository)
        {
            Field<ListGraphType<FormulationItemType>>("FormulationItems").ResolveAsync(async context =>
            {
                return await repository.GetAllAsync();
            });

            Field<FormulationItemType>("FormulationItem").Arguments(new QueryArgument<IntGraphType> { Name = "formulationItemId" }).ResolveAsync(async context =>
            {
                return await repository.GetByIdAsync(context.GetArgument<int>("formulationItemId"));
            });
        }
    }
}
