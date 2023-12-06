using GraphQL;
using GraphQL.Types;
using QualicoatManager.API.Type;
using QualicoatManager.Domain.Entities;
using QualicoatManager.Domain.Interfaces;
using QualicoatManager.Domain.Repositories;

namespace QualicoatManager.API.Mutation
{
    public class AssessmentMutation : ObjectGraphType
    {
        public AssessmentMutation(IGenericRepository<Assessment> repository)
        {
            Field<AssessmentType>("CreateAssessment")
                .Arguments(new QueryArguments(new QueryArgument<AssessmentInputType> { Name = "assessment" }))
                .ResolveAsync(async context =>
                {
                    var assessment = context.GetArgument<Assessment>("assessment");
                    await repository.CreateItemAsync(assessment);
                    return assessment;
                });

            Field<AssessmentType>("UpdateAssessment")
                    .Arguments(new QueryArguments(new QueryArgument<AssessmentInputType> { Name = "assessment" },
                    new QueryArgument<IntGraphType> { Name = "assessmentId" }))
                    .ResolveAsync(async context =>
                    {
                        var assessmentId = context.GetArgument<int>("assessmentId");
                        var assessment = context.GetArgument<Assessment>("assessment");
                        await repository.UpdateItemAsync(assessment, assessmentId);
                        return assessment;
                    });

            Field<StringGraphType>("DeleteAssessment")
                .Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "assessmentId" }))
                .ResolveAsync(async context =>
                {
                    var assessmentId = context.GetArgument<int>("assessmentId");
                    await repository.DeleteItemAsync(assessmentId);
                    return $"The assessment against the id {assessmentId} has been deleted successfully.";
                });



        }

    }
}


