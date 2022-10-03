using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.SizeService
{
    public class SizeService : Service<Size>, ISizeService
    {
        public SizeService(SheCollectionContext context) : base(context)
        {
        }

        public override Size Create(Size entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Size> GetAll()
        {
            return context.Sizes.ToList();
        }

        public override List<Size> GetBy(Func<Size, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override Size GetById(int id)
        {
            return context.Sizes.FirstOrDefault(s => s.SizeId == id);
        }

        public override bool Update(int id, Size entity)
        {
            throw new NotImplementedException();
        }
    }
}
