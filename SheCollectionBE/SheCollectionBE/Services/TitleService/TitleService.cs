using SheCollectionBE.Context;
using SheCollectionBE.Models;

namespace SheCollectionBE.Services.TitleService
{
    public class TitleService : Service<Title>, ITitleService
    {
        public TitleService(SheCollectionContext context) : base(context)
        {
        }

        public override Title Create(Title entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Title> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<Title> GetBy(Func<Title, bool> predicate)
        {
            return context.Titles.Where(predicate).ToList();
        }

        public override Title GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int id, Title entity)
        {
            throw new NotImplementedException();
        }
    }
}
