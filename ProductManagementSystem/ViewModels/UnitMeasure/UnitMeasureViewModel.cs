namespace ProductManagementSystem.ViewModels.UnitMeasure
{
    using ProductManagementSystem.Model.Entities;
    public class UnitMeasureViewModel
    {
        public UnitMeasure UnitMeasure { get; set; }
        public UnitMeasureViewModel()
        {
            UnitMeasures = new List<UnitMeasure>();
        }
        public IEnumerable<UnitMeasure> UnitMeasures { get; set; }
        public IEnumerable<UnitMeasure> Add(UnitMeasure unit)
        {
            UnitMeasures.ToList().Add(unit);
            return UnitMeasures;
        }
    }
}
