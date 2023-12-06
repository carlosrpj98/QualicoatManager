using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Query
{
    public class FormulationQuery : ObjectGraphType
    {
        public FormulationQuery(IGenericRepository<Formulation> repository)
        {
            Field<ListGraphType<FormulationType>>("Formulations").ResolveAsync(async context =>
            {
                return await repository.GetAllAsync();
            });

            Field<FormulationType>("Formulation").Arguments(new QueryArgument<IntGraphType> { Name = "formulationId" }).ResolveAsync(async context =>
            {
                return await repository.GetByIdAsync(context.GetArgument<int>("formulationId"));
            });
        }
    }
}
