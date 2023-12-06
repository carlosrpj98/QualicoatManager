using GraphQL.Types;

namespace QualicoatManager.API.Query
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<AssessmentQuery>("assessmentQuery").Resolve(context => new { });
            Field<AssessmentsGroupQuery>("assessmentsGroupQuery").Resolve(context => new { });
            Field<FormulationItemQuery>("formulationItemQuery").Resolve(context => new { });
            Field<FormulationQuery>("formulationQuery").Resolve(context => new { });
            Field<FormulationsFolderQuery>("formulationsFolderQuery").Resolve(context => new { });
            Field<RawMaterialQuery>("rawMaterialQuery").Resolve(context => new { });
            Field<BaseUserQuery>("baseUserQuery").Resolve(context => new { });
            Field<UserRoleQuery>("userRoleQuery").Resolve(context => new { });
        }
    }
}
