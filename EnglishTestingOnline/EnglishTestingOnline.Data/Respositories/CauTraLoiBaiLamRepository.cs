using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface ICauTraLoiBaiLamRepository : IRepository<CauTraLoiBaiLam>
    {
    }
    public class CauTraLoiBaiLamRepository : RepositoryBase<CauTraLoiBaiLam>, ICauTraLoiBaiLamRepository
    {
        public CauTraLoiBaiLamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
