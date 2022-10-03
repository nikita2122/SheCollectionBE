using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ProductColourService
{
    public class ProductColourService : Service<ProductColour>, IProductColourService
    {
        public ProductColourService(SheCollectionContext context) : base(context)
        {
        }

        public override ProductColour Create(ProductColour entity)
        {
            ProductColour result = context.ProductColours.Add(entity).Entity;
            context.SaveChanges();
            return result;
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<ProductColour> GetAll()
        {
            return context.ProductColours
                .Include(pc => pc.Product)
                .Include(pc => pc.Colour)
                .Include(pc => pc.Product.ProductType)
                .Include(pc => pc.Product.ProductType.ProductCategory)
                .ToList();
        }

        public override List<ProductColour> GetBy(Func<ProductColour, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override ProductColour GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductColour> GetByProductId(int id)
        {
            return context.ProductColours
                .Include(pc => pc.Product)
                .Include(pc => pc.Colour)
                .Include(pc => pc.Product.ProductType)
                .Include(pc => pc.Product.ProductType.ProductCategory)
                .Where(pc => pc.Product.ProductId == id)
                .ToList();
        }

        public override bool Update(int id, ProductColour entity)
        {
            throw new NotImplementedException();
        }
    }
}
