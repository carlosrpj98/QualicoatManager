using GraphQL.Types;

namespace QualicoatManager.API.Mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<AssessmentMutation>("assessmentMutation").Resolve(context => new { });
            Field<AssessmentsGroupMutation>("assessmentsGroupMutation").Resolve(context => new { });
            Field<FormulationItemMutation>("formulationItemMutation").Resolve(context => new { });
            Field<FormulationMutation>("formulationMutation").Resolve(context => new { });
            Field<FormulationsFolderMutation>("formulationsFolderMutation").Resolve(context => new { });
            Field<RawMaterialMutation>("rawMaterialMutation").Resolve(context => new { });
            Field<BaseUserMutation>("baseUserMutation").Resolve(context => new { });
            Field<UserRoleMutation>("userRoleMutation").Resolve(context => new { });
        }
    }
}
