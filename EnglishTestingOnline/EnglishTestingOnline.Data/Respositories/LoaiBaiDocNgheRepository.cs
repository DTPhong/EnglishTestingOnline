using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Respositories
{
    public interface ILoaiBaiDocNgheRepository : IRepository<LoaiBaiDocNghe>
    {
    }
    public class LoaiBaiDocNgheRepository : RepositoryBase<LoaiBaiDocNghe>, ILoaiBaiDocNgheRepository
    {
        public LoaiBaiDocNgheRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
