using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface IKyThiRepository : IRepository<KyThi>
    {
    }
    public class KyThiRepository : RepositoryBase<KyThi>, IKyThiRepository
    {
        public KyThiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
