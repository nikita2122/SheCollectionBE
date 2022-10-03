using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ProductTypeService
{
    public class ProductTypeService : Service<ProductType>, IProductTypeService
    {
        public ProductTypeService(SheCollectionContext context) : base(context)
        {
        }

        public override ProductType Create(ProductType entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<ProductType> GetAll()
        {
            return context.ProductTypes.Include(pt => pt.ProductCategory).ToList();
        }

        public override List<ProductType> GetBy(Func<ProductType, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override ProductType GetById(int id)
        {
            return context.ProductTypes.Include(pt => pt.ProductCategory).FirstOrDefault(pt => pt.ProductTypeId == id);
        }

        public List<ProductType> GetProductTypesByCategory(int categoryId)
        {
            return context.ProductTypes
                .Include(pt => pt.ProductCategory).Where(pt => pt.ProductCategory.ProductCategoryId == categoryId)
                .ToList();
        }

        public override bool Update(int id, ProductType entity)
        {
            throw new NotImplementedException();
        }
    }
}
