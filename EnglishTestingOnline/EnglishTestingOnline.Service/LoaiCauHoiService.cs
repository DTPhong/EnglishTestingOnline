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
    public interface ILoaiCauHoiService
    {
        LoaiCauHoi Add(LoaiCauHoi LoaiCauHoi);
        LoaiCauHoi Delete(int id);
        void Update(LoaiCauHoi LoaiCauHoi);
        LoaiCauHoi GetById(int id);
        IEnumerable<LoaiCauHoi> GetAll();
        IEnumerable<LoaiCauHoi> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<LoaiCauHoi> SearchByName(string keyword, int page, int pageSize, out int totalRow);
        void Save();
    }
    public class LoaiCauHoiService : ILoaiCauHoiService
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
        public IEnumerable<LoaiCauHoi> SearchByName(string keyword, int page, int pageSize, out int totalRow)
        {
            var query = _LoaiCauHoiRepository.GetMulti(c => c.NoiDung.Contains(keyword));
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public LoaiCauHoi GetById(int id)
        {
            return _LoaiCauHoiRepository.GetSingleById(id);
        }
        public IEnumerable<LoaiCauHoi> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            var query = _LoaiCauHoiRepository.GetAll();
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
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

