using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface IBaiDocNgheRepository : IRepository<BaiDocNghe>
    {
    }
    public class BaiDocNgheRepository : RepositoryBase<BaiDocNghe>, IBaiDocNgheRepository
    {
        public BaiDocNgheRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
