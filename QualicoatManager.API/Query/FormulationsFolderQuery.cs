using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Query
{
    public class FormulationsFolderQuery : ObjectGraphType
    {
        public FormulationsFolderQuery(IGenericRepository<FormulationsFolder> repository)
        {
            Field<ListGraphType<FormulationsFolderType>>("FormulationsFolders").ResolveAsync(async context =>
            {
                return await repository.GetAllAsync();
            });

            Field<FormulationsFolderType>("FormulationsFolder").Arguments(new QueryArgument<IntGraphType> { Name = "formulationsFolderId" }).ResolveAsync(async context =>
            {
                return await repository.GetByIdAsync(context.GetArgument<int>("formulationsFolderId"));
            });
        }
    }
}
