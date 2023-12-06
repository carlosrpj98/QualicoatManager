using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Query
{
    public class RawMaterialQuery : ObjectGraphType
    {

        public RawMaterialQuery(IGenericRepository<RawMaterial> repository)
        {
            Field<ListGraphType<RawMaterialType>>("RawMaterials").ResolveAsync(async context =>
            {
                return await repository.GetAllAsync();
            });

            Field<RawMaterialType>("RawMaterial").Arguments(new QueryArgument<IntGraphType> { Name = "rawMaterialId" }).ResolveAsync(async context =>
            {
                return await repository.GetByIdAsync(context.GetArgument<int>("rawMaterialId"));
            });
        }
    }
}
