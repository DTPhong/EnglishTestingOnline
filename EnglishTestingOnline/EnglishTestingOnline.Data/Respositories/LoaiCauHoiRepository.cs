using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface ILoaiCauHoiRepository : IRepository<LoaiCauHoi>
    {
    }
    public class LoaiCauHoiRepository : RepositoryBase<LoaiCauHoi>, ILoaiCauHoiRepository
    {
        public LoaiCauHoiRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
