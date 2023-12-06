using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;

namespace QualicoatManager.API.Mutation
{
    public class FormulationsFolderMutation : ObjectGraphType
    {
        public FormulationsFolderMutation(IGenericRepository<FormulationsFolder> repository)
        {
            Field<FormulationsFolderType>("CreateFormulationsFolder")
                .Arguments(new QueryArguments(new QueryArgument<FormulationsFolderInputType> { Name = "formulationsFolder" }))
                .ResolveAsync(async context =>
                {
                    var formulationsFolder = context.GetArgument<FormulationsFolder>("formulationsFolder");
                    await repository.CreateItemAsync(formulationsFolder);
                    return formulationsFolder;
                });

            Field<FormulationsFolderType>("UpdateFormulationsFolder")
                .Arguments(new QueryArguments(new QueryArgument<FormulationsFolderInputType> { Name = "formulationsFolder" },
                new QueryArgument<IntGraphType> { Name = "formulationsFolderId" }))
                .ResolveAsync(async context =>
                {
                    var formulationsFolderId = context.GetArgument<int>("formulationsFolderId");
                    var formulationsFolder = context.GetArgument<FormulationsFolder>("formulationsFolder");
                    await repository.UpdateItemAsync(formulationsFolder, formulationsFolderId);
                    return formulationsFolder;
                });

            Field<StringGraphType>("DeleteFormulationsFolder")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "formulationsFolderId" }))
                .ResolveAsync(async context =>
                {
                    var formulationsFolderId = context.GetArgument<int>("formulationsFolderId");
                    await repository.DeleteItemAsync(formulationsFolderId);
                    return $"The formulationsFolder against the id {formulationsFolderId} has been deleted successfully.";
                });



        }

    }
}


