using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.EmployeeTypeService
{
    public class EmployeeTypeService : Service<EmployeeType>, IEmployeeTypeService
    {
        public EmployeeTypeService(SheCollectionContext context) : base(context)
        {
        }

        public override EmployeeType Create(EmployeeType entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<EmployeeType> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<EmployeeType> GetBy(Func<EmployeeType, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override EmployeeType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, EmployeeType entity)
        {
            throw new NotImplementedException();
        }
    }
}
