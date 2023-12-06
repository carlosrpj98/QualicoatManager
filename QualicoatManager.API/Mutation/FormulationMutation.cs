using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Domain.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace QualicoatManager.API.Mutation
{
    public class FormulationMutation : ObjectGraphType
    {
        public FormulationMutation(IGenericRepository<Formulation> repository)
        {
            Field<FormulationType>("CreateFormulation")
                .Arguments(new QueryArguments(new QueryArgument<FormulationInputType> { Name = "formulation" }))
                .ResolveAsync(async context =>
                {
                    var formulation = context.GetArgument<Formulation>("formulation");
                    await repository.CreateItemAsync(formulation);
                    return formulation;
                });

            Field<FormulationType>("UpdateFormulation")
                     .Arguments(new QueryArguments(new QueryArgument<FormulationInputType> { Name = "formulation" },
                     new QueryArgument<IntGraphType> { Name = "formulationId" }))
                     .ResolveAsync(async context =>
                     {
                         var formulationId = context.GetArgument<int>("formulationId");
                         var formulation = context.GetArgument<Formulation>("formulation");
                         await repository.UpdateItemAsync(formulation, formulationId);
                         return formulation;
                     });

            Field<StringGraphType>("DeleteFormulation")
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


