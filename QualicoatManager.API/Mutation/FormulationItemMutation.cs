using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Domain.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace QualicoatManager.API.Mutation
{
    public class FormulationItemMutation : ObjectGraphType
    {
        public FormulationItemMutation(IGenericRepository<FormulationItem> repository)
        {
            Field<FormulationItemType>("CreateFormulationItem")
                .Arguments(new QueryArguments(new QueryArgument<FormulationItemInputType> { Name = "formulation" }))
                .ResolveAsync(async context =>
                {
                    var formulationItem = context.GetArgument<FormulationItem>("formulation");
                    await repository.CreateItemAsync(formulationItem);
                    return formulationItem;
                });

            Field<FormulationItemType>("UpdateFormulationItem")
                 .Arguments(new QueryArguments(new QueryArgument<FormulationItemInputType> { Name = "formulationItem" },
                 new QueryArgument<IntGraphType> { Name = "formulationItemId" }))
                 .ResolveAsync(async context =>
                 {
                     var formulationItemId = context.GetArgument<int>("formulationItemId");
                     var formulationItem = context.GetArgument<FormulationItem>("formulationItem");
                     await repository.UpdateItemAsync(formulationItem, formulationItemId);
                     return formulationItem;
                 });

            Field<StringGraphType>("DeleteFormulationItem")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "formulationId" }))
                .ResolveAsync(async context =>
                {
                    var formulationId = context.GetArgument<int>("formulationId");
                    await repository.DeleteItemAsync(formulationId);
                    return $"The formulation against the id {formulationId} has been deleted successfully.";
                });



        }

    }
}


