using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface ILoaiCauTraLoiTracNghiemRepository : IRepository<LoaiCauTraLoiTracNghiem>
    {
    }
    public class LoaiCauTraLoiTracNghiemRepository : RepositoryBase<LoaiCauTraLoiTracNghiem>, ILoaiCauTraLoiTracNghiemRepository
    {
        public LoaiCauTraLoiTracNghiemRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
