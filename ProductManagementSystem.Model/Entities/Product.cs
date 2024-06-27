namespace ProductManagementSystem.Model.Entities
{
    public class Product : Order
    {
        public byte[] Image { get; set; }
        public Guid UnitMeasureId { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; }
        public Guid ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
