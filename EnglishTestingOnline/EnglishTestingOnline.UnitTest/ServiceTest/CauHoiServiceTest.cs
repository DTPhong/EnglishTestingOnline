using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Data.Respositories;
using EnglishTestingOnline.Model.Model;
using EnglishTestingOnline.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.UnitTest.ServiceTest
{
    [TestClass]
    public class ProductServiceTest
    {
        private Mock<ICauHoiRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private ICauhoiService _cauhoiService;
        private List<CauHoi> _listCauhoi;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ICauHoiRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _cauhoiService = new CauHoiService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCauhoi = new List<CauHoi>()
            {
                new CauHoi() {ID=1, LoaiCauHoi_ID=1, BaiDocNghe_ID=1, ChuDe_ID=3, NoiDung="Lorem lorem lorem", DapAn="lorem" },
                new CauHoi() {ID=2, LoaiCauHoi_ID=1, BaiDocNghe_ID=1, ChuDe_ID=3, NoiDung="Lorem lorem lorem", DapAn="lorem" },
                new CauHoi() {ID=3, LoaiCauHoi_ID=1, BaiDocNghe_ID=1, ChuDe_ID=3, NoiDung="Lorem lorem lorem", DapAn="lorem" },
                new CauHoi() {ID=4, LoaiCauHoi_ID=1, BaiDocNghe_ID=1, ChuDe_ID=3, NoiDung="Lorem lorem lorem", DapAn="lorem" },
                new CauHoi() {ID=5, LoaiCauHoi_ID=1, BaiDocNghe_ID=1, ChuDe_ID=3, NoiDung="Lorem lorem lorem", DapAn="lorem" }
            };
        }

        [TestMethod]
        public void CauHoi_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCauhoi);

            //call action
            var result = _cauhoiService.GetAll() as List<CauHoi>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void CauHoi_Service_Create()
        {
            CauHoi cauHoi = new CauHoi() { ID = 5, LoaiCauHoi_ID = 1, BaiDocNghe_ID = 1, ChuDe_ID = 3, NoiDung = "Lorem lorem lorem", DapAn = "lorem" };

            _mockRepository.Setup(m => m.Add(cauHoi)).Returns((CauHoi c) =>
            {
                c.ID = 5;
                return c;
            });

            var result = _cauhoiService.Add(cauHoi);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.ID);
        }
    }
}
