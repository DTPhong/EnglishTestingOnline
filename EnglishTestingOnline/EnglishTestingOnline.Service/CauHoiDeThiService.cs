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
    public interface ICauHoiDeThiService
    {
        CauHoiDeThi Add(CauHoiDeThi cauHoiDeThi);
        CauHoiDeThi Delete(int id);
        void Update(CauHoiDeThi cauHoiDeThi);
        CauHoiDeThi GetById(int id);
        IEnumerable<CauHoiDeThi> GetAll();
        void Save();
    }
    public class CauHoiDeThiService : ICauHoiDeThiService
    {
        private ICauHoiDeThiRepository _cauHoiDeThiRepository;
        private IUnitOfWork _unitOfWork;

        public CauHoiDeThiService(ICauHoiDeThiRepository cauHoiDeThiRepository, IUnitOfWork unitOfWork)
        {
            this._cauHoiDeThiRepository = cauHoiDeThiRepository;
            this._unitOfWork = unitOfWork;
        }
        public CauHoiDeThi Add(CauHoiDeThi cauHoiDeThi)
        {
            return _cauHoiDeThiRepository.Add(cauHoiDeThi);
        }

        public CauHoiDeThi Delete(int id)
        {
            return _cauHoiDeThiRepository.Delete(id);
        }

        public IEnumerable<CauHoiDeThi> GetAll()
        {
            return _cauHoiDeThiRepository.GetAll();
        }

        public CauHoiDeThi GetById(int id)
        {
            return _cauHoiDeThiRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CauHoiDeThi cauHoiDeThi)
        {
            _cauHoiDeThiRepository.Update(cauHoiDeThi);
        }
    }
}
