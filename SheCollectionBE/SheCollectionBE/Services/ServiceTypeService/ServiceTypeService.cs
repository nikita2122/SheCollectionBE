using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ServiceTypeService
{
    public class ServiceTypeService : Service<ServiceType>, IServiceTypeService
    {
        public ServiceTypeService(SheCollectionContext context) : base(context)
        {
        }

        public override ServiceType Create(ServiceType entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            context.ServiceTypes.Remove(GetById(id));
            context.SaveChanges();
            return true;
        }

        public override List<ServiceType> GetAll()
        {
            return context.ServiceTypes.Include(x => x.ServiceCategory).ToList();
        }

        public override List<ServiceType> GetBy(Func<ServiceType, bool> predicate)
        {
            return context.ServiceTypes.Include(x => x.ServiceCategory).Where(predicate).ToList();
        }

        public override ServiceType GetById(int id)
        {
            return context.ServiceTypes.Include(x => x.ServiceCategory).FirstOrDefault(x => x.ServiceTypeId == id);
        }

        public override bool Update(int id, ServiceType entity)
        {
            throw new NotImplementedException();
        }
    }
}
