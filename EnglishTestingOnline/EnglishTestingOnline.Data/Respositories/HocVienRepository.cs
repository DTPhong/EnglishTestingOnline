using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface IHocVienRepository : IRepository<HocVien>
    {
    }
    public class HocVienRepository : RepositoryBase<HocVien>, IHocVienRepository
    {
        public HocVienRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
