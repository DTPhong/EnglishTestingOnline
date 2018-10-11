using EnglishTestingOnline.Data.Infrastructure;
using EnglishTestingOnline.Data.Respositories;
using EnglishTestingOnline.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTestingOnline.Service
{
    public interface ICauhoiService
    {
        CauHoi Add(CauHoi cauHoi);

        CauHoi Delete(int id);

        void Update(CauHoi cauHoi);

        IEnumerable<CauHoi> GetAll();

        CauHoi GetById(int id);

        void Save();
    }
    public class CauHoiService : ICauhoiService
    {
        private ICauHoiRepository _cauHoiRepository;
        private IUnitOfWork _unitOfWork;

        public CauHoiService(ICauHoiRepository cauHoiRepository, IUnitOfWork unitOfWork)
        {
            this._cauHoiRepository = cauHoiRepository;
            this._unitOfWork = unitOfWork;
        }

        public CauHoi Add(CauHoi cauHoi)
        {
            return _cauHoiRepository.Add(cauHoi);
        }

        public CauHoi Delete(int id)
        {
            return _cauHoiRepository.Delete(id);
        }

        public IEnumerable<CauHoi> GetAll()
        {
            string[] includes = {"ChuDe", "LoaiCauHoi" };
            return _cauHoiRepository.GetAll(includes);
        }

        public CauHoi GetById(int id)
        {
            return _cauHoiRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CauHoi cauHoi)
        {
            _cauHoiRepository.Update(cauHoi);
        }
    }
}
