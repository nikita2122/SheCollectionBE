using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.ColourService
{
    public class ColourService : Service<Colour>, IColourService
    {
        public ColourService(SheCollectionContext context) : base(context)
        {
        }

        public override Colour Create(Colour entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Colour> GetAll()
        {
            return context.Colours.ToList();
        }

        public override List<Colour> GetBy(Func<Colour, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override Colour GetById(int id)
        {
            return context.Colours.FirstOrDefault(c => c.ColourId == id);
        }

        public override bool Update(int id, Colour entity)
        {
            throw new NotImplementedException();
        }
    }
}
