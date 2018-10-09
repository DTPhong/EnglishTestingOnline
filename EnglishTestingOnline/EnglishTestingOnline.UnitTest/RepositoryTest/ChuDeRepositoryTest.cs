using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Data.Respositories;
using EnglishTestingOnline.Model.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.UnitTest.RepositoryTest
{
    [TestClass]
    public class ChuDeRepositoryTest
    {
        private IDbFactory dbFactory;
        private IUnitOfWork unitOfWork;
        private ChuDeRepository chuDeRepository;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            unitOfWork = new UnitOfWork(dbFactory);
            chuDeRepository = new ChuDeRepository(dbFactory);
        }

        [TestMethod]
        public void ChuDe_Repository_Create()
        {
            ChuDe chuDe = new ChuDe();
            chuDe.TenChuDe = "ABC";

            var result = chuDeRepository.Add(chuDe);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.ID);
        }

        [TestMethod]
        public void ChuDe_Repository_Delete()
        {

            var result = chuDeRepository.Delete(2);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.ID);
        }
    }
}
