using EnglishTestingOnline.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface ILoaiCauHoiTracNghiemRepository : IRepository<LoaiCauHoiTracNghiem>
    {
    }
    public class LoaiCauHoiTracNghiemRepository : RepositoryBase<LoaiCauHoiTracNghiem>, ILoaiCauHoiTracNghiemRepository
    {
        public LoaiCauHoiTracNghiemRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
