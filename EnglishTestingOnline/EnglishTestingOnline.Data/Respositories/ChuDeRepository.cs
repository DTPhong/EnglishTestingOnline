using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface IChuDeRepository : IRepository<ChuDe>
    {
    }
    public class ChuDeRepository : RepositoryBase<ChuDe>, IChuDeRepository
    {
        public ChuDeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
