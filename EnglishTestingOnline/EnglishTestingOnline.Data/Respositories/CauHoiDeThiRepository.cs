using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface ICauHoiDeThiRepository : IRepository<CauHoiDeThi>
    {
    }
    public class CauHoiDeThiRepository : RepositoryBase<CauHoiDeThi>, ICauHoiDeThiRepository
    {
        public CauHoiDeThiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
