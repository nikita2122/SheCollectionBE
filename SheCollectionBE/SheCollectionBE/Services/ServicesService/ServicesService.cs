using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ServicesService
{
    public class ServicesService : Service<ServiceTable>, IServicesService
    {
        public ServicesService(SheCollectionContext context) : base(context)
        {
        }

        public override ServiceTable Create(ServiceTable entity)
        {
            ServiceTable e = context.ServiceTables.Add(entity).Entity;
            context.SaveChanges();
            return e;
        }

        public override bool Delete(int id)
        {
            context.ServiceTables.Remove(GetById(id));
            context.SaveChanges();
            return true;
        }

        public override List<ServiceTable> GetAll()
        {
            return context.ServiceTables.Include(x => x.ServiceType).Include(x => x.ServiceType.ServiceCategory).ToList();
        }

        public override List<ServiceTable> GetBy(Func<ServiceTable, bool> predicate)
        {
            return context.ServiceTables.Include(x => x.ServiceType).Include(x => x.ServiceType.ServiceCategory).Where(predicate).ToList();
        }

        public override ServiceTable GetById(int id)
        {
            return context.ServiceTables.Include(x => x.ServiceType).Include(x => x.ServiceType.ServiceCategory).FirstOrDefault(x => x.ServiceTableId == id);
        }

        public override bool Update(int id, ServiceTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
