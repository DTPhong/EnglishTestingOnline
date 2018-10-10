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
    public interface ILoaiCauTraLoiTracNghiemSercive
    {
        LoaiCauTraLoiTracNghiem Add(LoaiCauTraLoiTracNghiem LoaiCauTraLoiTracNghiem);
        LoaiCauTraLoiTracNghiem Delete(int id);
        void Update(LoaiCauTraLoiTracNghiem LoaiCauTraLoiTracNghiem);
        LoaiCauTraLoiTracNghiem GetById(int id);
        IEnumerable<LoaiCauTraLoiTracNghiem> GetAll();
        void Save();
    }
    public class LoaiCauTraLoiTracNghiemService : ILoaiCauTraLoiTracNghiemSercive
    {
        private ILoaiCauTraLoiTracNghiemRepository _LoaiCauTraLoiTracNghiemRepository;
        private IUnitOfWork _unitOfWork;

        public LoaiCauTraLoiTracNghiemService(ILoaiCauTraLoiTracNghiemRepository LoaiCauTraLoiTracNghiemRepository, IUnitOfWork unitOfWork)
        {
            this._LoaiCauTraLoiTracNghiemRepository = LoaiCauTraLoiTracNghiemRepository;
            this._unitOfWork = unitOfWork;
        }
        public LoaiCauTraLoiTracNghiem Add(LoaiCauTraLoiTracNghiem LoaiCauTraLoiTracNghiem)
        {
            return _LoaiCauTraLoiTracNghiemRepository.Add(LoaiCauTraLoiTracNghiem);
        }

        public LoaiCauTraLoiTracNghiem Delete(int id)
        {
            return _LoaiCauTraLoiTracNghiemRepository.Delete(id);
        }

        public IEnumerable<LoaiCauTraLoiTracNghiem> GetAll()
        {
            return _LoaiCauTraLoiTracNghiemRepository.GetAll();
        }

        public LoaiCauTraLoiTracNghiem GetById(int id)
        {
            return _LoaiCauTraLoiTracNghiemRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(LoaiCauTraLoiTracNghiem LoaiCauTraLoiTracNghiem)
        {
            _LoaiCauTraLoiTracNghiemRepository.Update(LoaiCauTraLoiTracNghiem);
        }
    }
}

