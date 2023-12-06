namespace QualicoatManager.Domain.Entities
{
    public class Formulation : EntityWithName
    {
        private float _totalAmount = 0;

        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public List<FormulationItem>? Items { get; set; }
        public AssessmentsGroup? AssesmentsGroup { get; set; }

        public float TotalAmount
        {
            get => _totalAmount;
        }

        public void UpdateTotalAmount()
        {
            if (Items != null)
            {
                _totalAmount = Items.Sum(item => item.Amount);
            }
        }
    }
}
