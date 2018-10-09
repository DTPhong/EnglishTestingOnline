using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private EnglishDbContext dbContext;

        public EnglishDbContext Init()
        {
            return dbContext ?? (dbContext = new EnglishDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
