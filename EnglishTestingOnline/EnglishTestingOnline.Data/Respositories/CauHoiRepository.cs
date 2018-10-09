using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface ICauHoiRepository : IRepository<CauHoi>
    {
    }
    public class CauHoiRepository : RepositoryBase<CauHoi>, ICauHoiRepository
    {
        public CauHoiRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
