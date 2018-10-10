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
    public interface ILoaiCauHoiSercive
    {
        LoaiCauHoi Add(LoaiCauHoi LoaiCauHoi);
        LoaiCauHoi Delete(int id);
        void Update(LoaiCauHoi LoaiCauHoi);
        LoaiCauHoi GetById(int id);
        IEnumerable<LoaiCauHoi> GetAll();
        void Save();
    }
    public class LoaiCauHoiService : ILoaiCauHoiSercive
    {
        private ILoaiCauHoiRepository _LoaiCauHoiRepository;
        private IUnitOfWork _unitOfWork;

        public LoaiCauHoiService(ILoaiCauHoiRepository LoaiCauHoiRepository, IUnitOfWork unitOfWork)
        {
            this._LoaiCauHoiRepository = LoaiCauHoiRepository;
            this._unitOfWork = unitOfWork;
        }
        public LoaiCauHoi Add(LoaiCauHoi LoaiCauHoi)
        {
            return _LoaiCauHoiRepository.Add(LoaiCauHoi);
        }

        public LoaiCauHoi Delete(int id)
        {
            return _LoaiCauHoiRepository.Delete(id);
        }

        public IEnumerable<LoaiCauHoi> GetAll()
        {
            return _LoaiCauHoiRepository.GetAll();
        }

        public LoaiCauHoi GetById(int id)
        {
            return _LoaiCauHoiRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(LoaiCauHoi LoaiCauHoi)
        {
            _LoaiCauHoiRepository.Update(LoaiCauHoi);
        }
    }
}

