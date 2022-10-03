using Microsoft.EntityFrameworkCore;
using SheCollectionBE.Context;
using SheCollectionBE.Models;
using System.Linq;

namespace SheCollectionBE.Services.ProductService
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(SheCollectionContext context) : base(context)
        {
        }

        public override Product Create(Product entity)
        {
            Product p = context.Products.Add(entity).Entity;
            context.SaveChanges();
            return p;
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Product> GetAll()
        {
            return context.Products.Include(p => p.ProductType).Include(p => p.ProductType.ProductCategory).ToList();
        }

        public override List<Product> GetBy(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override Product GetById(int id)
        {
            return context.Products.Include(p => p.ProductType).Include(p => p.ProductType.ProductCategory).FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetProductByType(int id)
        {
            return context.Products.Include(p => p.ProductType).Include(p => p.ProductType.ProductCategory).Where(p => p.ProductType.ProductTypeId == id).ToList();
        }

        public void ReduceQuantity(int id, int amount)
        {
            Product p = GetById(id);
            p.QuantityAvailable -= amount;
            context.SaveChanges();
        }

        public override bool Update(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
