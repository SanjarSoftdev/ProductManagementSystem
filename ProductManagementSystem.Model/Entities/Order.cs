namespace ProductManagementSystem.Model.Entities
{
    public abstract class Order : BaseEntity
    {
        public Order()
        {
            KM = Guid.NewGuid();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid KM { get; set; }
    }
}
