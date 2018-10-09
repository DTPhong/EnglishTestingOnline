using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface ICauTraLoiTracNghiemRepository : IRepository<CauTraLoiTracNghiem>
    {
    }
    public class CauTraLoiTracNghiemRepository : RepositoryBase<CauTraLoiTracNghiem>, ICauTraLoiTracNghiemRepository
    {
        public CauTraLoiTracNghiemRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
