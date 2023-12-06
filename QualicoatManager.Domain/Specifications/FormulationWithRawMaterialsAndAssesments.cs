using QualicoatManager.Domain.Entities;

namespace QualicoatManager.Domain.Specifications
{
    public class FormulationWithRawMaterialsAndAssesments : BaseSpecification<Formulation>
    {
        public FormulationWithRawMaterialsAndAssesments()
        {
            AddInclude(x => x.Items.AsQueryable());
            AddInclude(x => x.AssesmentsGroup);
            AddInclude(x => x.AssesmentsGroup.Assesments);
        }

        public FormulationWithRawMaterialsAndAssesments(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Items.AsQueryable());
            AddInclude(x => x.AssesmentsGroup);
            AddInclude(x => x.AssesmentsGroup.Assesments);
        }
    }

}
