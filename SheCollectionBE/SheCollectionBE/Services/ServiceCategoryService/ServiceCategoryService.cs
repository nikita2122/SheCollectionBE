using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ServiceCategoryService
{
    public class ServiceCategoryService : Service<ServiceCategory>, IServiceCategoryService
    {
        public ServiceCategoryService(SheCollectionContext context) : base(context)
        {
        }

        public override ServiceCategory Create(ServiceCategory entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            context.ServiceCategories.Remove(GetById(id));
            context.SaveChanges();
            return true;
        }

        public override List<ServiceCategory> GetAll()
        {
            return context.ServiceCategories.ToList();
        }

        public override List<ServiceCategory> GetBy(Func<ServiceCategory, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override ServiceCategory GetById(int id)
        {
            return context.ServiceCategories.FirstOrDefault(x => x.ServiceCategoryId == id);
        }

        public override bool Update(int id, ServiceCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
