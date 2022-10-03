using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ProductSizeService
{
    public class ProductSizeService : Service<ProductSize>, IProductSizeService
    {
        public ProductSizeService(SheCollectionContext context) : base(context)
        {
        }

        public override ProductSize Create(ProductSize entity)
        {
            ProductSize result = context.ProductSizes.Add(entity).Entity;
            context.SaveChanges();
            return result;
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<ProductSize> GetAll()
        {
            return context.ProductSizes
                .Include(ps => ps.Product)
                .Include(pc => pc.Product.ProductType)
                .Include(pc => pc.Product.ProductType.ProductCategory)
                .Include(ps => ps.Size)
                .ToList();
        }

        public override List<ProductSize> GetBy(Func<ProductSize, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override ProductSize GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductSize> GetByProductId(int id)
        {
            return context.ProductSizes
                .Include(ps => ps.Product)
                .Include(pc => pc.Product.ProductType)
                .Include(pc => pc.Product.ProductType.ProductCategory)
                .Include(ps => ps.Size)
                .Where(ps => ps.Product.ProductId == id)
                .ToList();
        }

        public override bool Update(int id, ProductSize entity)
        {
            throw new NotImplementedException();
        }
    }
}
