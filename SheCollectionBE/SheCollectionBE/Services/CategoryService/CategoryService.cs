using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.CategoryService
{
    public class CategoryService : Service<ProductCategory>, ICategoryService
    {
        public CategoryService(SheCollectionContext context) : base(context)
        {
        }

        public override ProductCategory Create(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<ProductCategory> GetAll()
        {
            return context.ProductCategories.ToList();
        }

        public override List<ProductCategory> GetBy(Func<ProductCategory, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override ProductCategory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, ProductCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
