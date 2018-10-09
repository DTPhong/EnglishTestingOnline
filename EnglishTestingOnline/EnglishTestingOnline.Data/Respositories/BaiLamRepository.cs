using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface IBaiLamRepository : IRepository<BaiLam>
    {
    }
    public class BaiLamRepository : RepositoryBase<BaiLam>, IBaiLamRepository
    {
        public BaiLamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
