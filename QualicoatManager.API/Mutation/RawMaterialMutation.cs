using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Mutation
{
    public class RawMaterialMutation : ObjectGraphType
    {
        public RawMaterialMutation(IGenericRepository<RawMaterial> repository)
        {
            Field<RawMaterialType>("CreateRawMaterial")
                .Arguments(new QueryArguments(new QueryArgument<RawMaterialInputType> { Name = "rawMaterial" }))
                .ResolveAsync(async context =>
                {
                    var rawMaterial = context.GetArgument<RawMaterial>("rawMaterial");

                    await repository.CreateItemAsync(rawMaterial);

                    return rawMaterial;
                });


            Field<RawMaterialType>("UpdateRawMaterial")
                .Arguments(new QueryArguments(new QueryArgument<RawMaterialInputType> { Name = "rawMaterial" },
                new QueryArgument<IntGraphType> { Name = "rawMaterialId" }))
                .ResolveAsync(async context =>
                {
                    var rawMaterialId = context.GetArgument<int>("rawMaterialId");
                    var rawMaterial = context.GetArgument<RawMaterial>("rawMaterial");
                    await repository.UpdateItemAsync(rawMaterial, rawMaterialId);
                    return rawMaterial;
                });

            Field<StringGraphType>("DeleteRawMaterial")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "rawMaterialId" }))
                .ResolveAsync(async context =>
                {
                    var rawMaterialId = context.GetArgument<int>("rawMaterialId");
                    await repository.DeleteItemAsync(rawMaterialId);
                    return $"The rawMaterial against the id {rawMaterialId} has been deleted successfully.";
                });



        }

    }
}


