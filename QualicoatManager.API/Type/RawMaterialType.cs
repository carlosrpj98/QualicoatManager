using GraphQL.Types;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.API.Type
{
    public class RawMaterialType : ObjectGraphType<RawMaterial>
    {
        public RawMaterialType()
        {
            Field(r => r.Id);
            Field(r => r.Name);
            Field(r => r.Description);
            Field(r => r.Category);
        }
    }
}
