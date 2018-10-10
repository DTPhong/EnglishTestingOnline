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
    public interface IHocVienSercive
    {
        HocVien Add(HocVien HocVien);
        HocVien Delete(int id);
        void Update(HocVien HocVien);
        HocVien GetById(int id);
        IEnumerable<HocVien> GetAll();
        void Save();
    }
    public class HocVienService : IHocVienSercive
    {
        private IHocVienRepository _HocVienRepository;
        private IUnitOfWork _unitOfWork;

        public HocVienService(IHocVienRepository HocVienRepository, IUnitOfWork unitOfWork)
        {
            this._HocVienRepository = HocVienRepository;
            this._unitOfWork = unitOfWork;
        }
        public HocVien Add(HocVien HocVien)
        {
            return _HocVienRepository.Add(HocVien);
        }

        public HocVien Delete(int id)
        {
            return _HocVienRepository.Delete(id);
        }

        public IEnumerable<HocVien> GetAll()
        {
            return _HocVienRepository.GetAll();
        }

        public HocVien GetById(int id)
        {
            return _HocVienRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(HocVien HocVien)
        {
            _HocVienRepository.Update(HocVien);
        }
    }
}

