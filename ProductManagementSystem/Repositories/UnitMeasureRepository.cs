using ProductManagementSystem.Model;
using ProductManagementSystem.Model.Entities;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Repositories
{
    public class UnitMeasureRepository : Repository<UnitMeasure>
    {
        public UnitMeasureRepository(EFContext context) : base(context)
        {
        }
    }
}
