using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface IDeThiRepository : IRepository<DeThi>
    {
    }
    public class DeThiRepository : RepositoryBase<DeThi>, IDeThiRepository
    {
        public DeThiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
